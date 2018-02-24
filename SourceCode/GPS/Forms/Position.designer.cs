﻿//Please, if you use this, share the improvements

using System;
using System.Collections.Generic;

namespace AgraBot
{
    public partial class FormGPS
    {
        //very first fix to setup grid etc
        public bool isFirstFixPositionSet = false, isGPSPositionInitialized = false;

        // autosteer variables for sending serial
        public Int16 guidanceLineDistanceOff, guidanceLineSteerAngle;

        //how many fix updates per sec
        public int fixUpdateHz = 5;
        public double fixUpdateTime = 0.2;

        //for heading or Atan2 as camera
        public bool isHeadingFromFix = true;

        public vec3 pivotAxlePos = new vec3(0, 0, 0);
        public vec3 toolPos = new vec3(0, 0, 0);
        public vec3 tankPos = new vec3(0, 0, 0);
        public vec2 hitchPos = new vec2(0, 0);

        //history
        public vec2 prevFix = new vec2(0, 0);

        //headings
        public double fixHeading = 0.0, camHeading = 0.0, gpsHeading = 0.0, prevGPSHeading = 0.0, prevPrevGPSHeading = 0.0;

        //storage for the cos and sin of heading
        public double cosSectionHeading = 1.0, sinSectionHeading = 0.0;

        //a distance between previous and current fix
        private double distance = 0.0, userDistance = 0;
  
        //how far travelled since last section was added, section points
        double sectionTriggerDistance = 0, sectionTriggerStepDistance = 0; 
        public vec2 prevSectionPos = new vec2(0, 0);
        
        //step distances and positions for boundary, 4 meters before next point
        public double boundaryTriggerDistance = 4.0;
        public vec2 prevBoundaryPos = new vec2(0, 0);

        //are we still getting valid data from GPS, resets to 0 in NMEA OGI block, watchdog 
        public int recvCounter = 20;

        //Everything is so wonky at the start
        int startCounter = 0;

        //individual points for the flags in a list
        List<CFlag> flagPts = new List<CFlag>();

        //tally counters for display
        public double totalSquareMeters = 0, totalUserSquareMeters = 0, userSquareMetersAlarm = 0;

        //used to determine NMEA sentence frequency
        private double hzTime = 0;

        public double[] avgSpeed = new double[10];//for average speed
        public int ringCounter = 0;

        //youturn
        double distPivot = -2;
        public double distTool;
        double distanceToStartAutoTurn;  
        
        //the value to fill in you turn progress bar
        public int youTurnProgressBar = 0;

        //IMU 
        double rollCorrectionDistance = 0;
        double gyroDelta, gyroCorrection, gyroRaw, gyroCorrected;

        //step position - slow speed spinner killer
        private int totalFixSteps = 10, currentStepFix = 0;
        private vec3 vHold;
        public vec3[] stepFixPts = new vec3[50];
        public double distanceCurrentStepFix = 0, fixStepDist, minFixStepDist = 0;        
        bool isFixHolding = false, isFixHoldLoaded = false;
        
        //called by watchdog timer every 50 ms
        private void ScanForNMEA()
        {
            //parse any data from pn.rawBuffer
            pn.ParseNMEA();

            //time for a frame update with new valid nmea data
            if (pn.updatedGGA | pn.updatedOGI)
            {
                //if saving a file ignore any movement
                if (isSavingFile) return;

                //accumulate time over multiple frames  
                hzTime = swFrame.ElapsedMilliseconds;

                //reset the timer         
                swFrame.Reset();

                //start the watch and time till it gets back here
                swFrame.Start();

                //reset both flags
                pn.updatedGGA = false;
                pn.updatedOGI = false;

                //update all data for new frame
                UpdateFixPosition();
            }

            //must make sure arduinos are kept off if initializing
            else
            {
                if (!isGPSPositionInitialized)  mc.ResetAllModuleCommValues();
            }

            //Update the port connecition counter - is reset every time new sentence is valid and ready
            recvCounter++;
        }

        public double eastingBeforeRoll;
        public double eastingAfterRoll;
        public double rollUsed;

        //call for position update after valid NMEA sentence
        private void UpdateFixPosition()
        {
            startCounter++;
            totalFixSteps = fixUpdateHz * 4;
            if (!isGPSPositionInitialized) { InitializeFirstFewGPSPositions(); return; }

            #region Roll

            rollUsed = 0;

            if ((ahrs.isRollBrick | ahrs.isRollDogs | ahrs.isRollPAOGI) && mc.rollRaw != 9999)
            {
                //for charting in GPS Data window
                eastingBeforeRoll = pn.fix.easting;
                rollUsed = (double)mc.rollRaw/16;

                //calculate how far the antenna moves based on sidehill roll
                double roll = Math.Sin(glm.toRadians((mc.rollRaw - ahrs.rollZero) * 0.0625));
                rollCorrectionDistance = Math.Abs(roll * vehicle.antennaHeight);


                // roll to left is positive  **** important!!
                if (roll > 0)
                {
                    pn.fix.easting = (Math.Cos(fixHeading) * rollCorrectionDistance) + pn.fix.easting;
                    pn.fix.northing = (Math.Sin(fixHeading) * -rollCorrectionDistance) + pn.fix.northing;
                }
                else
                {
                    pn.fix.easting = (Math.Cos(fixHeading) * -rollCorrectionDistance) + pn.fix.easting;
                    pn.fix.northing = (Math.Sin(fixHeading) * rollCorrectionDistance) + pn.fix.northing;
                }

                //for charting the position after roll adjustment
                eastingAfterRoll = pn.fix.easting;
            }
            else
            {
                eastingAfterRoll = pn.fix.easting;
                eastingBeforeRoll = pn.fix.easting;
            }

            //pitchDistance = (pitch * vehicle.antennaHeight);
            ////pn.fix.easting = (Math.Sin(fixHeading) * pitchDistance) + pn.fix.easting;
            //pn.fix.northing = (Math.Cos(fixHeading) * pitchDistance) + pn.fix.northing;

            #endregion Roll

            #region Step Fix

            //**** heading of the vec3 structure is used for distance in Step fix!!!!!

            //grab the most current fix and save the distance from the last fix
            distanceCurrentStepFix = glm.Distance(pn.fix, stepFixPts[0]);
            fixStepDist = distanceCurrentStepFix;

            //if  min distance isn't exceeded, keep adding old fixes till it does
            if (distanceCurrentStepFix <= minFixStepDist)
            {
                for (currentStepFix = 0; currentStepFix < totalFixSteps; currentStepFix++)
                {
                    fixStepDist += stepFixPts[currentStepFix].heading;
                    if (fixStepDist > minFixStepDist)
                    {
                        //if we reached end, keep the oldest and stay till distance is exceeded
                        if (currentStepFix < (totalFixSteps - 1)) currentStepFix++;
                        isFixHolding = false;
                        break;
                    }
                    else isFixHolding = true;
                }
            }

            // only takes a single fix to exceeed min distance
            else currentStepFix = 0;

            //if total distance is less then the addition of all the fixes, keep last one as reference
            if (isFixHolding)
            {
                if (isFixHoldLoaded == false)
                {
                    vHold = stepFixPts[(totalFixSteps - 1)];
                    isFixHoldLoaded = true;
                }

                //cycle thru like normal
                for (int i = totalFixSteps - 1; i > 0; i--) stepFixPts[i] = stepFixPts[i - 1];

                //fill in the latest distance and fix
                stepFixPts[0].heading = glm.Distance(pn.fix, stepFixPts[0]);
                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;

                //reload the last position that was triggered.
                stepFixPts[(totalFixSteps - 1)].heading = glm.Distance(vHold, stepFixPts[(totalFixSteps - 1)]);
                stepFixPts[(totalFixSteps - 1)].easting = vHold.easting;
                stepFixPts[(totalFixSteps - 1)].northing = vHold.northing;
            }

            else //distance is exceeded, time to do all calcs and next frame
            {
                //positions and headings 
                CalculatePositionHeading();

                //get rid of hold position
                isFixHoldLoaded = false;

                //don't add the total distance again
                stepFixPts[(totalFixSteps - 1)].heading = 0;

                //grab sentences for logging
                if (isLogNMEA)  { if (ct.isContourOn)  { pn.logNMEASentence.Append(recvSentenceSettings); } }

                //To prevent drawing high numbers of triangles, determine and test before drawing vertex
                sectionTriggerDistance = glm.Distance(pn.fix, prevSectionPos);

                //section on off and points, contour points
                if (sectionTriggerDistance > sectionTriggerStepDistance && isJobStarted)
                {
                    AddSectionContourPathPoints();
                }

                //test if travelled far enough for new boundary point
                double boundaryDistance = glm.Distance(pn.fix, prevBoundaryPos);
                if (boundaryDistance > boundaryTriggerDistance) AddBoundaryAndPerimiterPoint();

                //calc distance travelled since last GPS fix
                distance = glm.Distance(pn.fix, prevFix);
                if ((userDistance += distance) > 3000) userDistance = 0; ;//userDistance can be reset

                //most recent fixes are now the prev ones
                prevFix.easting = pn.fix.easting; prevFix.northing = pn.fix.northing;

                //load up history with valid data
                for (int i = totalFixSteps - 1; i > 0; i--) stepFixPts[i] = stepFixPts[i - 1];
                stepFixPts[0].heading = glm.Distance(pn.fix, stepFixPts[0]);
                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;
            }
            #endregion fix

            #region AutoSteer

            guidanceLineDistanceOff = 32000;    //preset the values

            //do the distance from line calculations for contour and AB
            if (ct.isContourBtnOn) ct.DistanceFromContourLine();
            if (ABLine.isABLineSet && !ct.isContourBtnOn)
            {
                ABLine.GetCurrentABLine();
                if (yt.isRecordingCustomYouTurn)
                {
                    //save reference of first point
                    if (yt.youFileList.Count == 0)
                    {
                        vec2 start = new vec2(pn.fix.easting, pn.fix.northing);
                        yt.youFileList.Add(start);
                    }
                    else
                    {
                        //keep adding points
                        vec2 point = new vec2(pn.fix.easting - yt.youFileList[0].easting, pn.fix.northing - yt.youFileList[0].northing);
                        yt.youFileList.Add(point);
                    }
                }
            }

            // autosteer at full speed of updates
            if (!isAutoSteerBtnOn) //32020 means auto steer is off
            {
                guidanceLineDistanceOff = 32020;
            }

            // If Drive button enabled be normal, or just fool the autosteer and fill values
            if (!ast.isInFreeDriveMode)
            {

                //fill up0 the auto steer array with new values
                mc.autoSteerData[mc.sdSpeed] = (byte)(pn.speed * 4.0);

                mc.autoSteerData[mc.sdDistanceHi] = (byte)(guidanceLineDistanceOff >> 8);
                mc.autoSteerData[mc.sdDistanceLo] = (byte)guidanceLineDistanceOff;

                mc.autoSteerData[mc.sdSteerAngleHi] = (byte)(guidanceLineSteerAngle >> 8);
                mc.autoSteerData[mc.sdSteerAngleLo] = (byte)guidanceLineSteerAngle;

                //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
                AutoSteerDataOutToPort();
                
                //autosteer data out the UDP Steer port
                //SendUDPMessage(guidanceLineSteerAngle + "," + guidanceLineDistanceOff);
            }

            else
            {
                //fill up the auto steer array with free drive values
                mc.autoSteerData[mc.sdSpeed] = (byte)(pn.speed * 4.0 + 8);

                //make steer module think everything is normal
                mc.autoSteerData[mc.sdDistanceHi] = (byte)(0);
                mc.autoSteerData[mc.sdDistanceLo] = (byte)0;

                //out serial to autosteer module  //indivdual classes load the distance and heading deltas 
                AutoSteerDataOutToPort();
            }
            #endregion

            #region relayRatecontrol
            //do the relayRateControl
            if (rc.isRateControlOn)
            {
                rc.CalculateRateLitersPerMinute();
                mc.relayRateData[mc.rdRateSetPointHi] = (byte)((Int16)(rc.rateSetPoint * 100.0) >> 8);
                mc.relayRateData[mc.rdRateSetPointLo] = (byte)(rc.rateSetPoint * 100.0);

                mc.relayRateData[mc.rdSpeedXFour] = (byte)(pn.speed * 4.0);
                //relay byte is built in SerialComm function BuildRelayByte()
                //youturn control byte is built in SerialComm BuildYouTurnByte()
            }
            else
            {
                mc.relayRateData[mc.rdRateSetPointHi] = (byte)0;
                mc.relayRateData[mc.rdRateSetPointHi] = (byte)0;
                mc.relayRateData[mc.rdSpeedXFour] = (byte)(pn.speed * 4.0);
                //relay byte is built in SerialComm.cs - function BuildRelayByte()
                //youturn control byte is built in SerialComm BuildYouTurnByte()
            }

            //send out the port
            RateRelayOutToPort(mc.relayRateData, AgraBot.CModuleComm.numRelayRateDataItems);

            #endregion

            #region Youturn

            //do the auto youturn logic if everything is on.
            if (hl.isSet && yt.isYouTurnBtnOn && isAutoSteerBtnOn)
            {
                //figure out where we are
                yt.isInBoundz = boundz.IsPointInsideBoundary(toolPos);
                yt.isInWorkArea = hl.IsPointInsideHeadland(toolPos);

                //Are we in the headland?
                if (!yt.isInWorkArea && yt.isInBoundz) yt.isInHeadland = true;
                else yt.isInHeadland = false;

                //are we in boundary? Then calc a distance
                if (yt.isInBoundz)
                {
                    hl.FindClosestHeadlandPoint(pivotAxlePos);
                    if ((int)hl.closestHeadlandPt.easting != -1)
                    {
                        distPivot = glm.Distance(pivotAxlePos, hl.closestHeadlandPt);
                    }
                    else distPivot = -2;
                }
                else distPivot = -2;

                //trigger the "its ready to generate a youturn when 25m away" but don't make it just yet
                if (distPivot < 25.0 && distPivot > 22 && !yt.isYouTurnTriggered && yt.isInWorkArea)
                {
                    //begin the whole process, all conditions are met
                    yt.YouTurnTrigger();
                }

                //Do the sequencing of functions around the turn.
                if (yt.isSequenceTriggered)
                {
                    yt.DoSequenceEvent();
                }

                distanceToStartAutoTurn = -1;

                //start counting down - this is not run if shape is drawn
                if (yt.isYouTurnTriggerPointSet && yt.isYouTurnBtnOn)
                {
                    //if we are too much off track - 5 degrees 500 mm, pointing wrong way, kill the turn
                    if ((Math.Abs(guidanceLineSteerAngle) > 500) && (Math.Abs(ABLine.distanceFromCurrentLine) > 500))
                    {
                        yt.ResetYouTurnAndSequenceEvents();
                    }
                    else

                    {
                        //how far have we gone since youturn request was triggered
                        distanceToStartAutoTurn = glm.Distance(pivotAxlePos, yt.youTurnTriggerPoint);
                        
                        //youTurnProgressBar = (int)(distanceToStartAutoTurn / (45 + yt.youTurnStartOffset) * 100);                 

                        if (distanceToStartAutoTurn > (25 + yt.youTurnStartOffset))
                        {
                            //keep from running this again since youturn is plotted now
                            yt.isYouTurnTriggerPointSet = false;
                            youTurnProgressBar = 0;
                            yt.isLastYouTurnRight = yt.isYouTurnRight;
                            yt.BuildYouTurnListToRight(yt.isYouTurnRight);
                        }
                    }
                }
            }

            else //make sure youturn and sequence is off - we are not in normal turn here
            {
                if(yt.isYouTurnTriggered | yt.isSequenceTriggered)
                {
                    yt.ResetYouTurnAndSequenceEvents();
                }
            }

            #endregion

            //calculate lookahead at full speed, no sentence misses
            CalculateSectionLookAhead(toolPos.northing, toolPos.easting, cosSectionHeading, sinSectionHeading);

            //openGLControl_Draw routine triggered manually
            openGLControl.DoRender();

        //end of UppdateFixPosition
        }

        //all the hitch, pivot, section, trailing hitch, headings and fixes
        private void CalculatePositionHeading()
        {
            if (isHeadingFromFix)
            {
                gpsHeading = Math.Atan2(pn.fix.easting - stepFixPts[currentStepFix].easting, pn.fix.northing - stepFixPts[currentStepFix].northing);
                if (gpsHeading < 0) gpsHeading += glm.twoPI;
                fixHeading = gpsHeading;

                //determine fix positions and heading in degrees for glRotate opengl methods.
                int camStep = currentStepFix * 4;
                if (camStep > (totalFixSteps - 1)) camStep = (totalFixSteps - 1);
                camHeading = Math.Atan2(pn.fix.easting - stepFixPts[camStep].easting, pn.fix.northing - stepFixPts[camStep].northing);
                if (camHeading < 0) camHeading += glm.twoPI;
                camHeading = glm.toDegrees(camHeading);
            }

            //if from dual antenna use true heading
            else
            {
                //use NMEA headings for camera and tractor graphic
                fixHeading = glm.toRadians(pn.headingHDT);
                camHeading = pn.headingTrue;
                gpsHeading = glm.toRadians(pn.headingHDT);
            }


            //make sure there is a gyro otherwise 9999 are sent from autosteer
            if ((ahrs.isHeadingBrick | ahrs.isHeadingBNO | ahrs.isHeadingPAOGI) && mc.gyroHeading != 9999)
            {
                //current gyro angle in radians
                gyroRaw = (glm.toRadians((double)mc.prevGyroHeading * 0.0625));

                //Difference between the IMU heading and the GPS heading
                gyroDelta = (gyroRaw + gyroCorrection) - gpsHeading;
                if (gyroDelta < 0) gyroDelta += glm.twoPI;

                //calculate delta based on circular data problem 0 to 360 to 0, clamp to +- 2 Pi
                if (gyroDelta >= -glm.PIBy2 && gyroDelta <= glm.PIBy2) gyroDelta *= -1.0;
                else
                {
                    if (gyroDelta > glm.PIBy2) { gyroDelta = glm.twoPI - gyroDelta; }
                    else { gyroDelta = (glm.twoPI + gyroDelta) * -1.0; }
                }
                if (gyroDelta > glm.twoPI) gyroDelta -= glm.twoPI;
                if (gyroDelta < -glm.twoPI) gyroDelta += glm.twoPI;

                //calculate current turn rate of vehicle
                prevPrevGPSHeading = prevGPSHeading;
                prevGPSHeading = gpsHeading;
                //turnDelta = Math.Abs(Math.Atan2(Math.Sin(fixHeading - prevPrevGPSHeading), Math.Cos(fixHeading - prevPrevGPSHeading)));

                //if the gyro and last corrected fix is < 10 degrees, super low pass for gps
                if (Math.Abs(gyroDelta) < 0.18)
                {
                    //a bit of delta and add to correction to current gyro
                    gyroCorrection += (gyroDelta * (0.5 / fixUpdateHz));
                    if (gyroCorrection > glm.twoPI) gyroCorrection -= glm.twoPI;
                    if (gyroCorrection < -glm.twoPI) gyroCorrection += glm.twoPI;
                    //gyroRaw = (glm.toRadians((double)mc.gyroHeading * 0.0625));
                }
                else
                {
                    //a bit of delta and add to correction to current gyro
                    gyroCorrection += (gyroDelta * (2.0 / fixUpdateHz));
                    if (gyroCorrection > glm.twoPI) gyroCorrection -= glm.twoPI;
                    if (gyroCorrection < -glm.twoPI) gyroCorrection += glm.twoPI;
                    //gyroRaw = (glm.toRadians((double)mc.gyroHeading * 0.0625));
                }

                //determine the Corrected heading based on gyro and GPS
                gyroCorrected = gyroRaw + gyroCorrection;
                if (gyroCorrected > glm.twoPI) gyroCorrected -= glm.twoPI;
                if (gyroCorrected < 0) gyroCorrected += glm.twoPI;

                fixHeading = gyroCorrected;
            }

       #region pivot hitch trail

            //translate world to the pivot axle
            pivotAxlePos.easting = pn.fix.easting - (Math.Sin(fixHeading) * vehicle.antennaPivot);
            pivotAxlePos.northing = pn.fix.northing - (Math.Cos(fixHeading) * vehicle.antennaPivot);
            pivotAxlePos.heading = fixHeading;

            //determine where the rigid vehicle hitch ends
            hitchPos.easting = pn.fix.easting + (Math.Sin(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));
            hitchPos.northing = pn.fix.northing + (Math.Cos(fixHeading) * (vehicle.hitchLength - vehicle.antennaPivot));

            //tool attached via a trailing hitch
            if (vehicle.isToolTrailing)
            {
                double over;
                if (vehicle.tankTrailingHitchLength < -2.0)
                {
                    //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                    if (distanceCurrentStepFix != 0)
                    {
                        double t = (vehicle.tankTrailingHitchLength) / distanceCurrentStepFix;
                        tankPos.easting = hitchPos.easting + t * (hitchPos.easting - tankPos.easting);
                        tankPos.northing = hitchPos.northing + t * (hitchPos.northing - tankPos.northing);
                        tankPos.heading = Math.Atan2(hitchPos.easting - tankPos.easting, hitchPos.northing - tankPos.northing);
                    }

                    ////the tool is seriously jacknifed or just starting out so just spring it back.
                    over = Math.Abs(Math.PI - Math.Abs(Math.Abs(tankPos.heading - fixHeading) - Math.PI));

                    if (over < 2.0 && startCounter > 50)
                    {
                        tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                        tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                    }

                    //criteria for a forced reset to put tool directly behind vehicle
                    if (over > 2.0 | startCounter < 51 )
                    {
                        tankPos.heading = fixHeading;
                        tankPos.easting = hitchPos.easting + (Math.Sin(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                        tankPos.northing = hitchPos.northing + (Math.Cos(tankPos.heading) * (vehicle.tankTrailingHitchLength));
                    }

                }

                else
                {
                    tankPos.heading = fixHeading;
                    tankPos.easting = hitchPos.easting;
                    tankPos.northing = hitchPos.northing;
                }

                //Torriem rules!!!!! Oh yes, this is all his. Thank-you
                if (distanceCurrentStepFix != 0)
                {
                    double t = (vehicle.toolTrailingHitchLength) / distanceCurrentStepFix;
                    toolPos.easting = tankPos.easting + t * (tankPos.easting - toolPos.easting);
                    toolPos.northing = tankPos.northing + t * (tankPos.northing - toolPos.northing);
                    toolPos.heading = Math.Atan2(tankPos.easting - toolPos.easting, tankPos.northing - toolPos.northing);
                }


                ////the tool is seriously jacknifed or just starting out so just spring it back.
                over = Math.Abs(Math.PI - Math.Abs(Math.Abs(toolPos.heading - tankPos.heading) - Math.PI));

                if (over < 1.9 && startCounter > 50)
                {
                    toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                    toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                }

                //criteria for a forced reset to put tool directly behind vehicle
                if (over > 1.9 | startCounter < 51 )
                {
                    toolPos.heading = tankPos.heading;
                    toolPos.easting = tankPos.easting + (Math.Sin(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                    toolPos.northing = tankPos.northing + (Math.Cos(toolPos.heading) * (vehicle.toolTrailingHitchLength));
                }
            }

            //rigidly connected to vehicle
            else
            {
                toolPos.heading = fixHeading;
                toolPos.easting = hitchPos.easting;
                toolPos.northing = hitchPos.northing;
            }

#endregion

            //used to increase triangle count when going around corners, less on straight
            //pick the slow moving side edge of tool
            double metersPerSec = pn.speed * 0.277777777;

            //whichever is less
            if (vehicle.toolFarLeftSpeed < vehicle.toolFarRightSpeed)
                sectionTriggerStepDistance = vehicle.toolFarLeftSpeed / metersPerSec;
            else sectionTriggerStepDistance = vehicle.toolFarRightSpeed / metersPerSec;

            //finally determine distance
            sectionTriggerStepDistance = sectionTriggerStepDistance * sectionTriggerStepDistance * 
                metersPerSec * camera.triangleResolution *2.0 + 1.0;

            //  ** Torriem Cam   *****
            //Default using fix Atan2 to calc cam, if unchecked in display settings use True Heading from NMEA

            //check to make sure the grid is big enough
            worldGrid.checkZoomWorldGrid(pn.fix.northing, pn.fix.easting);

            //precalc the sin and cos of heading * -1
            sinSectionHeading = Math.Sin(-toolPos.heading);
            cosSectionHeading = Math.Cos(-toolPos.heading);
        }

        //perimeter and boundary point generation
        private void AddBoundaryAndPerimiterPoint()
        {
            //save the north & east as previous
            prevBoundaryPos.easting = pn.fix.easting;
            prevBoundaryPos.northing = pn.fix.northing;

            //build the boundary line
            if (boundz.isOkToAddPoints)
            {
                if (boundz.isDrawRightSide)
                {
                    //Right side
                    vec3 point = new vec3(cosSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.easting,
                        sinSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.northing, toolPos.heading);
                    boundz.ptList.Add(point);
                }

                    //draw on left side
                else
                {
                    //Right side
                    vec3 point = new vec3(cosSectionHeading * (section[0].positionLeft) + toolPos.easting,
                        sinSectionHeading * (section[0].positionLeft) + toolPos.northing, toolPos.heading);
                    boundz.ptList.Add(point);
                }

            }

            //build the polygon to calculate area
            if (periArea.isBtnPerimeterOn)
            {
                if (isAreaOnRight)
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.easting,
                        sinSectionHeading * (section[vehicle.numOfSections - 1].positionRight) + toolPos.northing);
                    periArea.periPtList.Add(point);
                }

                    //draw on left side
                else
                {
                    //Right side
                    vec2 point = new vec2(cosSectionHeading * (section[0].positionLeft) + toolPos.easting,
                        sinSectionHeading * (section[0].positionLeft) + toolPos.northing);
                    periArea.periPtList.Add(point);
                }

            }
        }

        //add the points for section, contour line points, Area Calc feature
        private void AddSectionContourPathPoints()
        {
            //if (recPath.isBtnOn & recPath.isRecordOn)
            {
                //keep minimum speed of 1.0
                double speed = pn.speed;
                if (pn.speed < 1.0) speed = 1.0;

                CRecPathPt pt = new CRecPathPt(pn.fix.easting, pn.fix.northing, fixHeading, pn.speed);
                recPath.recList.Add(pt);
            }

            //save the north & east as previous
            prevSectionPos.northing = pn.fix.northing;
            prevSectionPos.easting = pn.fix.easting;

            // if non zero, at least one section is on.
            int sectionCounter = 0;

            //send the current and previous GPS fore/aft corrected fix to each section
            for (int j = 0; j < vehicle.numOfSections + 1; j++)
            {
                if (section[j].isSectionOn)
                {
                    section[j].AddPathPoint(toolPos.northing, toolPos.easting, cosSectionHeading, sinSectionHeading);
                    sectionCounter++;
                }
            }

            //Contour Base Track.... At least One section on, turn on if not
            if (sectionCounter != 0)
            {
                //keep the line going, everything is on for recording path
                if (ct.isContourOn) ct.AddPoint();
                else { ct.StartContourLine(); ct.AddPoint(); }
            }

            //All sections OFF so if on, turn off
            else { if (ct.isContourOn) { ct.StopContourLine(); } }

            //Build contour line if close enough to a patch
            if (ct.isContourBtnOn) ct.BuildContourGuidanceLine(pn.fix.easting, pn.fix.northing);

        }
       
        //calculate the extreme tool left, right velocities, each section lookahead, and whether or not its going backwards
        public void CalculateSectionLookAhead(double northing, double easting, double cosHeading, double sinHeading)
        {            
            //calculate left side of section 1
            vec2 left = new vec2(0, 0);
            vec2 right = left;
            double leftSpeed = 0, rightSpeed = 0, leftLook = 0, rightLook = 0;

            //now loop all the section rights and the one extreme left
            for (int j = 0; j < vehicle.numOfSections; j++)
            {
                if (j == 0)
                {
                    //only one first left point, the rest are all rights moved over to left
                    section[j].leftPoint = new vec2(cosHeading * (section[j].positionLeft) + easting,
                                       sinHeading * (section[j].positionLeft) + northing);

                    left = section[j].leftPoint - section[j].lastLeftPoint;
                    
                    //save a copy for next time
                    section[j].lastLeftPoint = section[j].leftPoint;
                    
                    //get the speed for left side only once
                    leftSpeed = left.GetLength() / fixUpdateTime * 10;
                    leftLook = leftSpeed * vehicle.toolLookAhead;

                    //save the far left speed
                    vehicle.toolFarLeftSpeed = leftSpeed;
                }
                else
                {
                    //right point from last section becomes this left one
                    section[j].leftPoint = section[j-1].rightPoint;
                    left = section[j].leftPoint - section[j].lastLeftPoint;

                    //save a copy for next time
                    section[j].lastLeftPoint = section[j].leftPoint;
                    leftSpeed = rightSpeed;
                }

                section[j].rightPoint = new vec2(cosHeading * (section[j].positionRight) + easting,
                                    sinHeading * (section[j].positionRight) + northing);

                //now we have left and right for this section
                right = section[j].rightPoint - section[j].lastRightPoint;

                //save a copy for next time
                section[j].lastRightPoint = section[j].rightPoint;

                //grab vector length and convert to meters/sec/10 pixels per meter                
                rightSpeed = right.GetLength() / fixUpdateTime * 10;
                rightLook = rightSpeed * vehicle.toolLookAhead;

                //Is section outer going forward or backward
                double head = left.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - toolPos.heading) - Math.PI) > glm.PIBy2) leftLook *= -1;

                head = right.HeadingXZ();
                if (Math.PI - Math.Abs(Math.Abs(head - toolPos.heading) - Math.PI) > glm.PIBy2) rightLook *= -1;

                //choose fastest speed
                if (leftLook > rightLook)  section[j].sectionLookAhead = leftLook;
                else section[j].sectionLookAhead = rightLook;

                if (section[j].sectionLookAhead > 190) section[j].sectionLookAhead = 190;

                //Doing the slow mo, exceeding buffer so just set as minimum 0.5 meter
                if (currentStepFix >= totalFixSteps - 1) section[j].sectionLookAhead = 5;
            }//endfor

            //set up the super for youturn
            section[vehicle.numOfSections].isInsideBoundary = true;

            //determine if section is in boundary using the section left/right positions
            for (int j = 0; j < vehicle.numOfSections; j++)
            {
                if (boundz.isSet)
                {
                    bool isLeftIn = true, isRightIn = true;
                    if (j == 0)
                    {
                        //only one first left point, the rest are all rights moved over to left
                        isLeftIn = boundz.IsPointInsideBoundary(section[j].leftPoint);
                        isRightIn = boundz.IsPointInsideBoundary(section[j].rightPoint);

                        if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                        else section[j].isInsideBoundary = false;
                    }

                    else
                    {
                        //grab the right of previous section, its the left of this section
                        isLeftIn = isRightIn;
                        isRightIn = boundz.IsPointInsideBoundary(section[j].rightPoint);
                        if (isLeftIn && isRightIn) section[j].isInsideBoundary = true;
                        else section[j].isInsideBoundary = false;
                    }

                    section[vehicle.numOfSections].isInsideBoundary &= section[j].isInsideBoundary;
                }

                //no boundary created so always inside
                else
                {
                    section[j].isInsideBoundary = true;
                    section[vehicle.numOfSections].isInsideBoundary = false;
                }
            }

            //with left and right tool velocity to determine rate of triangle generation, corners are more
            //save far right speed, 0 if going backwards, in meters/sec
            if (section[vehicle.numOfSections - 1].sectionLookAhead > 0) vehicle.toolFarRightSpeed = rightSpeed * 0.05;
            else vehicle.toolFarRightSpeed = 0;

            //save left side, 0 if going backwards, in meters/sec convert back from pixels/m
            if (section[0].sectionLookAhead > 0) vehicle.toolFarLeftSpeed = vehicle.toolFarLeftSpeed * 0.05;
            else vehicle.toolFarLeftSpeed = 0;                
        }

        //the start of first few frames to initialize entire program
        private void InitializeFirstFewGPSPositions()
        {
            if (!isFirstFixPositionSet)
            {
                //reduce the huge utm coordinates
                pn.utmEast = (int)(pn.fix.easting);
                pn.utmNorth = (int)(pn.fix.northing);
                pn.fix.easting = pn.fix.easting - pn.utmEast;
                pn.fix.northing = pn.fix.northing - pn.utmNorth;

                //Draw a grid once we know where in the world we are.
                isFirstFixPositionSet = true;
                worldGrid.CreateWorldGrid(pn.fix.northing, pn.fix.easting);

                //most recent fixes
                prevFix.easting = pn.fix.easting;
                prevFix.northing = pn.fix.northing;

                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;
                stepFixPts[0].heading = 0;

                //run once and return
                isFirstFixPositionSet = true;
                return;
            }

            else
            {
 
                //most recent fixes
                prevFix.easting = pn.fix.easting; prevFix.northing = pn.fix.northing;

                //load up history with valid data
                for (int i = totalFixSteps - 1; i > 0; i--)
                {
                    stepFixPts[i].easting = stepFixPts[i - 1].easting;
                    stepFixPts[i].northing = stepFixPts[i - 1].northing;
                    stepFixPts[i].heading = stepFixPts[i - 1].heading;
                }

                stepFixPts[0].heading = glm.Distance(pn.fix, stepFixPts[0]);
                stepFixPts[0].easting = pn.fix.easting;
                stepFixPts[0].northing = pn.fix.northing;

                //keep here till valid data
                if (startCounter > (totalFixSteps/2)) isGPSPositionInitialized = true;

                //in radians
                fixHeading = Math.Atan2(pn.fix.easting - stepFixPts[totalFixSteps - 1].easting, pn.fix.northing - stepFixPts[totalFixSteps - 1].northing); 
                if (fixHeading < 0) fixHeading += glm.twoPI;
                toolPos.heading = fixHeading;

                //send out initial zero settings
                if (isGPSPositionInitialized) AutoSteerSettingsOutToPort();

                return;
            }
        }

        // intense math section....   the lat long converted to utm   *********************************************************
 #region utm Calcualtions
        private double sm_a = 6378137.0;
        private double sm_b = 6356752.314;
        private double UTMScaleFactor2 = 1.0004001600640256102440976390556;

        //the result is placed in these two
        public double utmLat = 0;
        public double utmLon = 0;

        //public double RollDistance { get => rollCorrectionDistance; set => rollCorrectionDistance = value; }

        public void UTMToLatLon(double X, double Y)
        {
            double cmeridian;

            X -= 500000.0;
            X *= UTMScaleFactor2;

            /* If in southern hemisphere, adjust y accordingly. */
            if (pn.hemisphere == 'S')
                Y -= 10000000.0;
            Y *= UTMScaleFactor2;

            cmeridian = (-183.0 + (pn.zone * 6.0)) * 0.01745329251994329576923690766743;
            double[] latlon = new double[2]; //= MapXYToLatLon(X, Y, cmeridian);          
  
            double phif, Nf, Nfpow, nuf2, ep2, tf, tf2, tf4, cf;
            double x1frac, x2frac, x3frac, x4frac, x5frac, x6frac, x7frac, x8frac;
            double x2poly, x3poly, x4poly, x5poly, x6poly, x7poly, x8poly;

            /* Get the value of phif, the footpoint latitude. */
            phif = FootpointLatitude(Y);

            /* Precalculate ep2 */
            ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0))
                  / Math.Pow(sm_b, 2.0);

            /* Precalculate cos (phif) */
            cf = Math.Cos(phif);

            /* Precalculate nuf2 */
            nuf2 = ep2 * Math.Pow(cf, 2.0);

            /* Precalculate Nf and initialize Nfpow */
            Nf = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nuf2));
            Nfpow = Nf;

            /* Precalculate tf */
            tf = Math.Tan(phif);
            tf2 = tf * tf;
            tf4 = tf2 * tf2;

            /* Precalculate fractional coefficients for x**n in the equations
               below to simplify the expressions for latitude and longitude. */
            x1frac = 1.0 / (Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**2) */
            x2frac = tf / (2.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**3) */
            x3frac = 1.0 / (6.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**4) */
            x4frac = tf / (24.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**5) */
            x5frac = 1.0 / (120.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**6) */
            x6frac = tf / (720.0 * Nfpow);

            Nfpow *= Nf;   /* now equals Nf**7) */
            x7frac = 1.0 / (5040.0 * Nfpow * cf);

            Nfpow *= Nf;   /* now equals Nf**8) */
            x8frac = tf / (40320.0 * Nfpow);

            /* Precalculate polynomial coefficients for x**n.
               -- x**1 does not have a polynomial coefficient. */
            x2poly = -1.0 - nuf2;

            x3poly = -1.0 - 2 * tf2 - nuf2;

            x4poly = 5.0 + 3.0 * tf2 + 6.0 * nuf2 - 6.0 * tf2 * nuf2
                - 3.0 * (nuf2 * nuf2) - 9.0 * tf2 * (nuf2 * nuf2);

            x5poly = 5.0 + 28.0 * tf2 + 24.0 * tf4 + 6.0 * nuf2 + 8.0 * tf2 * nuf2;

            x6poly = -61.0 - 90.0 * tf2 - 45.0 * tf4 - 107.0 * nuf2
                + 162.0 * tf2 * nuf2;

            x7poly = -61.0 - 662.0 * tf2 - 1320.0 * tf4 - 720.0 * (tf4 * tf2);

            x8poly = 1385.0 + 3633.0 * tf2 + 4095.0 * tf4 + 1575 * (tf4 * tf2);

            /* Calculate latitude */
            latlon[0] = phif + x2frac * x2poly * (X * X)
                + x4frac * x4poly * Math.Pow(X, 4.0)
                + x6frac * x6poly * Math.Pow(X, 6.0)
                + x8frac * x8poly * Math.Pow(X, 8.0);

            /* Calculate longitude */
            latlon[1] = cmeridian + x1frac * X
                + x3frac * x3poly * Math.Pow(X, 3.0)
                + x5frac * x5poly * Math.Pow(X, 5.0)
                + x7frac * x7poly * Math.Pow(X, 7.0);

            utmLat = latlon[0] * 57.295779513082325225835265587528;
            utmLon = latlon[1] * 57.295779513082325225835265587528;
        }
 
        private double FootpointLatitude(double y)
        {
            double y_, alpha_, beta_, gamma_, delta_, epsilon_, n;
            double result;

            /* Precalculate n (Eq. 10.18) */
            n = (sm_a - sm_b) / (sm_a + sm_b);

            /* Precalculate alpha_ (Eq. 10.22) */
            /* (Same as alpha in Eq. 10.17) */
            alpha_ = ((sm_a + sm_b) / 2.0)
                * (1 + (Math.Pow(n, 2.0) / 4) + (Math.Pow(n, 4.0) / 64));

            /* Precalculate y_ (Eq. 10.23) */
            y_ = y / alpha_;

            /* Precalculate beta_ (Eq. 10.22) */
            beta_ = (3.0 * n / 2.0) + (-27.0 * Math.Pow(n, 3.0) / 32.0)
                + (269.0 * Math.Pow(n, 5.0) / 512.0);

            /* Precalculate gamma_ (Eq. 10.22) */
            gamma_ = (21.0 * Math.Pow(n, 2.0) * 0.0625)
                + (-55.0 * Math.Pow(n, 4.0) / 32.0);

            /* Precalculate delta_ (Eq. 10.22) */
            delta_ = (151.0 * Math.Pow(n, 3.0) / 96.0)
                + (-417.0 * Math.Pow(n, 5.0) / 128.0);

            /* Precalculate epsilon_ (Eq. 10.22) */
            epsilon_ = (1097.0 * Math.Pow(n, 4.0) / 512.0);

            /* Now calculate the sum of the series (Eq. 10.21) */
            result = y_ + (beta_ * Math.Sin(2.0 * y_))
                + (gamma_ * Math.Sin(4.0 * y_))
                + (delta_ * Math.Sin(6.0 * y_))
                + (epsilon_ * Math.Sin(8.0 * y_));

            return result;
        }

#endregion

    }//end class
}//end namespace