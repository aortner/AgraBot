﻿using SharpGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CRecPathPt
    {
        public double easting { get; set; }
        public double northing { get; set; }
        public double heading { get; set; }
        public double speed { get; set; }
        public bool autoBtnState { get; set; }

        //constructor
        public CRecPathPt(double _easting, double _northing, double _heading, double _speed,
                            bool _autoBtnState)
        {
            easting = _easting;
            northing = _northing;
            heading = _heading;
            speed = _speed;
            autoBtnState = _autoBtnState;
        }
    }

    public class CRecordedPath
    {
        //constructor
        public CRecordedPath(OpenGL _gl, FormGPS _f)
        {
            gl = _gl;
            mf = _f;
        }

        //pointers to mainform controls
        private readonly OpenGL gl;

        private readonly FormGPS mf;

        //the recorded path from driving around
        public List<CRecPathPt> recList = new List<CRecPathPt>();

        public int recListCount;

        //the dubins path to get there
        public List<CRecPathPt> dubList = new List<CRecPathPt>();

        public int dubListCount;

        //list of vec3 points of Dubins shortest path between 2 points - To be converted to RecPt
        public List<vec3> dubinsList = new List<vec3>();

        //generated reference line
        public vec2 refPoint1 = new vec2(1, 1), refPoint2 = new vec2(2, 2);

        public double distanceFromRefLine, distanceFromCurrentLine, refLineSide = 1.0;
        private int A, B, C;
        public double abFixHeadingDelta, segmentHeading;
        public bool isABSameAsFixHeading = true, isOnRightSideCurrentLine = true;

        public int lastPointFound = -1, currentPositonIndex;

        //pure pursuit values
        public vec3 pivotAxlePosRP = new vec3(0, 0, 0);

        public vec3 homePos = new vec3();
        public vec2 goalPointRP = new vec2(0, 0);
        public vec2 radiusPointRP = new vec2(0, 0);
        public double steerAngleRP, rEastRP, rNorthRP, ppRadiusRP;

        public bool isBtnFollowOn, isEndOfTheRecLine, isRecordOn;
        public bool isDrivingRecordedPath, isPausedDrivingRecordedPath, isFollowingDubinsToPath, isFollowingRecPath, isFollowingDubinsHome;

        public bool StartDrivingRecordedPath()
        {
            CDubins.turningRadius = mf.vehicle.minTurningRadius * 1.3;
            //create the dubins path based on start and goal to start of recorded path

            recListCount = recList.Count;
            if (recListCount < 5) return false;

            //the goal is the first point of path, the start is the current position
            vec3 goal = new vec3(recList[0].easting, recList[0].northing, recList[0].heading);

            //save a copy of where we started.
            homePos = mf.pivotAxlePos;

            //get the dubins for approach to recorded path
            GetDubinsPath(goal);
            dubListCount = dubList.Count;

            //has a valid dubins path been created?
            if (dubListCount == 0) return false;

            //technically all good if we get here so set all the flags
            isFollowingDubinsHome = false;
            isFollowingRecPath = false;
            isFollowingDubinsToPath = true;
            isEndOfTheRecLine = false;
            currentPositonIndex = 0;
            isDrivingRecordedPath = true;

            mf.btnDrivePath.Image = Properties.Resources.AutoGo;
            isPausedDrivingRecordedPath = false;
            return true;
        }

        public bool trig;
        public double north;

        public void UpdatePosition()
        {
            if (isFollowingDubinsToPath)
            {
                //set a speed of 7 kmh
                mf.sim.stepDistance = 7 / 17.86;

                pivotAxlePosRP = mf.pivotAxlePos;

                FindGoalPointDubinsPath(dubListCount);
                PurePursuit();

                //check if close to recorded path
                double distSqr = glm.DistanceSquared(pivotAxlePosRP.northing, pivotAxlePosRP.easting, recList[0].northing, recList[0].easting);
                if (distSqr < 2)
                {
                    isFollowingRecPath = true;
                    isFollowingDubinsToPath = false;
                    dubList.Clear();
                    dubinsList.Clear();
                }
            }

            if (isFollowingRecPath)
            {
                pivotAxlePosRP = mf.pivotAxlePos;

                FindGoalPointRecPath(recListCount);
                PurePursuit();

                //if end of the line then stop
                if (!isEndOfTheRecLine)
                {
                    mf.sim.stepDistance = recList[C].speed / 17.86;
                    north = recList[C].northing;

                    //section control - only if different click the button
                    bool autoBtn = (mf.autoBtnState == FormGPS.btnStates.Auto);
                    trig = autoBtn;
                    if (autoBtn != recList[C].autoBtnState) mf.btnSectionOffAutoOn.PerformClick();
                }
                else
                {
                    //create the dubins path based on start and goal to start of recorded path
                    GetDubinsPath(homePos);
                    dubListCount = dubList.Count;

                    //its too small
                    if (dubListCount < 5)
                    {
                        StopDrivingRecordedPath();
                    }

                    //set all the flags
                    isFollowingDubinsHome = true;
                    isFollowingRecPath = false;
                    isFollowingDubinsToPath = false;
                    isEndOfTheRecLine = false;
                }
            }

            if (isFollowingDubinsHome)
            {
                mf.sim.stepDistance = 7 / 17.86;
                pivotAxlePosRP = mf.pivotAxlePos;

                FindGoalPointDubinsPath(dubListCount);
                PurePursuit();

                //check if close to home position
                double distSqr = glm.DistanceSquared(pivotAxlePosRP.easting, pivotAxlePosRP.northing, homePos.easting, homePos.northing);
                if (distSqr < 3)
                {
                    StopDrivingRecordedPath();
                }
            }

            //if paused, set the sim to 0
            if (isPausedDrivingRecordedPath) mf.sim.stepDistance = 0 / 17.86;
        }

        public void StopDrivingRecordedPath()
        {
            isFollowingDubinsHome = false;
            isFollowingRecPath = false;
            isFollowingDubinsToPath = false;
            dubList.Clear();
            dubinsList.Clear();
            mf.sim.stepDistance = 0;
            isDrivingRecordedPath = false;
            mf.btnDrivePath.Image = Properties.Resources.AutoGo;
            isPausedDrivingRecordedPath = false;
        }

        private void GetDubinsPath(vec3 goal)
        {
            CDubins dubPath = new CDubins();

            //get the dubins path vec3 point coordinates of turn
            dubinsList.Clear();
            dubinsList = dubPath.GenerateDubins(mf.pivotAxlePos, goal);

            //transfer point list to recPath class point style
            dubList.Clear();
            for (int i = 0; i < dubinsList.Count; i++)
            {
                CRecPathPt pt = new CRecPathPt(dubinsList[i].easting, dubinsList[i].northing, dubinsList[i].heading, 5.0, false);
                dubList.Add(pt);
            }
        }

        private void PurePursuit()
        {
            //calc "D" the distance from pivot axle to lookahead point
            double goalPointDistanceSquared = glm.DistanceSquared(goalPointRP.northing, goalPointRP.easting, pivotAxlePosRP.northing, pivotAxlePosRP.easting);

            //calculate the the delta x in local coordinates and steering angle degrees based on wheelbase
            double localHeading = glm.twoPI - mf.fixHeading;
            ppRadiusRP = goalPointDistanceSquared / (2 * (((goalPointRP.easting - pivotAxlePosRP.easting) * Math.Cos(localHeading)) + ((goalPointRP.northing - pivotAxlePosRP.northing) * Math.Sin(localHeading))));

            steerAngleRP = glm.toDegrees(Math.Atan(2 * (((goalPointRP.easting - pivotAxlePosRP.easting) * Math.Cos(localHeading))
                + ((goalPointRP.northing - pivotAxlePosRP.northing) * Math.Sin(localHeading))) * mf.vehicle.wheelbase / goalPointDistanceSquared));

            if (steerAngleRP < -mf.vehicle.maxSteerAngle) steerAngleRP = -mf.vehicle.maxSteerAngle;
            if (steerAngleRP > mf.vehicle.maxSteerAngle) steerAngleRP = mf.vehicle.maxSteerAngle;

            if (ppRadiusRP < -500) ppRadiusRP = -500;
            if (ppRadiusRP > 500) ppRadiusRP = 500;

            radiusPointRP.easting = pivotAxlePosRP.easting + (ppRadiusRP * Math.Cos(localHeading));
            radiusPointRP.northing = pivotAxlePosRP.northing + (ppRadiusRP * Math.Sin(localHeading));

            //angular velocity in rads/sec  = 2PI * m/sec * radians/meters
            double angVel = glm.twoPI * 0.277777 * mf.pn.speed * (Math.Tan(glm.toRadians(steerAngleRP))) / mf.vehicle.wheelbase;

            //clamp the steering angle to not exceed safe angular velocity
            if (Math.Abs(angVel) > mf.vehicle.maxAngularVelocity)
            {
                steerAngleRP = glm.toDegrees(steerAngleRP > 0 ?
                        (Math.Atan((mf.vehicle.wheelbase * mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777)))
                    : (Math.Atan((mf.vehicle.wheelbase * -mf.vehicle.maxAngularVelocity) / (glm.twoPI * mf.pn.speed * 0.277777))));
            }
            //Convert to centimeters
            distanceFromCurrentLine = Math.Round(distanceFromCurrentLine * 1000.0, MidpointRounding.AwayFromZero);

            //distance is negative if on left, positive if on right
            //if you're going the opposite direction left is right and right is left
            if (isABSameAsFixHeading)
            {
                if (!isOnRightSideCurrentLine) distanceFromCurrentLine *= -1.0;
            }

            //opposite way so right is left
            else if (isOnRightSideCurrentLine)
            {
                distanceFromCurrentLine *= -1.0;
            }

            mf.guidanceLineDistanceOff = (Int16)distanceFromCurrentLine;
            mf.guidanceLineSteerAngle = (Int16)(steerAngleRP * 100);
        }

        private vec2 FindGoalPointRecPath(int ptCount)
        {
            //find the closest 2 points to current fix
            double minDistA = 9999999999;

            //set the search range close to current position
            int top = currentPositonIndex + 5;
            if (top > ptCount) top = ptCount;

            double dist;
            for (int t = currentPositonIndex; t < top; t++)
            {
                dist = ((pivotAxlePosRP.easting - recList[t].easting) * (pivotAxlePosRP.easting - recList[t].easting))
                                + ((pivotAxlePosRP.northing - recList[t].northing) * (pivotAxlePosRP.northing - recList[t].northing));
                if (dist < minDistA)
                {
                    minDistA = dist;
                    A = t;
                }
            }

            //Save the closest point
            C = A;

            //next point is the next in list
            B = A + 1;
            if (B == ptCount)
            {
                //don't go past the end of the list - "end of the line" trigger
                A--;
                B--;
                isEndOfTheRecLine = true;
            }

            //save current position
            currentPositonIndex = A;

            //get the distance from currently active AB line
            //x2-x1
            double dx = recList[B].easting - recList[A].easting;
            //z2-z1
            double dz = recList[B].northing - recList[A].northing;

            if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return goalPointRP;

            //abHeading = Math.Atan2(dz, dx);
            segmentHeading = recList[A].heading;

            //how far from current AB Line is fix
            distanceFromCurrentLine = ((dz * pivotAxlePosRP.easting) - (dx * pivotAxlePosRP
                .northing) + (recList[B].easting
                        * recList[A].northing) - (recList[B].northing * recList[A].easting))
                            / Math.Sqrt((dz * dz) + (dx * dx));

            //are we on the right side or not
            isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

            //absolute the distance
            distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

            // ** Pure pursuit ** - calc point on ABLine closest to current position
            double U = (((pivotAxlePosRP.easting - recList[A].easting) * dx)
                        + ((pivotAxlePosRP.northing - recList[A].northing) * dz))
                        / ((dx * dx) + (dz * dz));

            rEastRP = recList[A].easting + (U * dx);
            rNorthRP = recList[A].northing + (U * dz);

            //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
            abFixHeadingDelta = (Math.Abs(mf.fixHeading - segmentHeading));
            if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

            //used for accumulating distance to find goal point
            double distSoFar;

            //how far should goal point be away  - speed * seconds * kmph -> m/s then limit min value
            double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;

            if (distanceFromCurrentLine < 1.0)
                goalPointDistance += distanceFromCurrentLine * goalPointDistance * mf.vehicle.goalPointDistanceMultiplier;
            else
                goalPointDistance += goalPointDistance * mf.vehicle.goalPointDistanceMultiplier;

            if (goalPointDistance < mf.vehicle.goalPointLookAheadMinimum) goalPointDistance = mf.vehicle.goalPointLookAheadMinimum;

            mf.test1 = goalPointDistance;

            //minimum of 4.0 meters look ahead
            if (goalPointDistance < 4.0) goalPointDistance = 4.0;

            // used for calculating the length squared of next segment.
            double tempDist = 0.0;

            //counting up
            isABSameAsFixHeading = true;
            distSoFar = glm.Distance(recList[B].easting, recList[B].northing, rEastRP, rNorthRP);

            //Is this segment long enough to contain the full lookahead distance?
            if (distSoFar > goalPointDistance)
            {
                //treat current segment like an AB Line
                goalPointRP.easting = rEastRP + (Math.Sin(recList[A].heading) * goalPointDistance);
                goalPointRP.northing = rNorthRP + (Math.Cos(recList[A].heading) * goalPointDistance);
            }

            //multiple segments required
            else
            {
                //cycle thru segments and keep adding lengths. check if end and break if so.
                // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
                while (B < ptCount - 1)
                {
                    B++; A++;
                    tempDist = glm.Distance(recList[B].easting, recList[B].northing, recList[A].easting, recList[A].northing);

                    //will we go too far?
                    if ((tempDist + distSoFar) > goalPointDistance)
                    {
                        //A--; B--;
                        break; //tempDist contains the full length of next segment
                    }

                    distSoFar += tempDist;
                }

                // the remainder to yet travel
                double t = (goalPointDistance - distSoFar);
                t /= tempDist;

                goalPointRP.easting = (((1 - t) * recList[A].easting) + (t * recList[B].easting));
                goalPointRP.northing = (((1 - t) * recList[A].northing) + (t * recList[B].northing));
            }

            //mf.guidanceLineHeadingDelta = (Int16)((Math.Atan2(Math.Sin(temp - mf.fixHeading),
            //                                    Math.Cos(temp - mf.fixHeading))) * 10000);
            //}
            //else
            //{
            //    //invalid distance so tell AS module
            //    distanceFromCurrentLine = 32000;
            //    mf.guidanceLineDistanceOff = 32000;
            //}
            return goalPointRP;
        }

        private vec2 FindGoalPointDubinsPath(int ptCount)
        {
            //distanceFromCurrentLine = 9999;
            //find the closest 2 points to current fix
            double minDistA = 9999999999;
            for (int t = 0; t < ptCount; t++)
            {
                double dist = ((pivotAxlePosRP.easting - dubList[t].easting) * (pivotAxlePosRP.easting - dubList[t].easting))
                                + ((pivotAxlePosRP.northing - dubList[t].northing) * (pivotAxlePosRP.northing - dubList[t].northing));
                if (dist < minDistA)
                {
                    minDistA = dist;
                    A = t;
                }
            }

            //save the closest point
            C = A;
            //next point is the next in list
            B = A + 1;
            if (B == ptCount) { A--; B--; }                //don't go past the end of the list - "end of the line" trigger

            //get the distance from currently active AB line
            //x2-x1
            double dx = dubList[B].easting - dubList[A].easting;
            //z2-z1
            double dz = dubList[B].northing - dubList[A].northing;

            if (Math.Abs(dx) < Double.Epsilon && Math.Abs(dz) < Double.Epsilon) return goalPointRP;

            //abHeading = Math.Atan2(dz, dx);
            segmentHeading = dubList[A].heading;

            //how far from current AB Line is fix
            distanceFromCurrentLine = ((dz * pivotAxlePosRP.easting) - (dx * pivotAxlePosRP
                .northing) + (dubList[B].easting
                        * dubList[A].northing) - (dubList[B].northing * dubList[A].easting))
                            / Math.Sqrt((dz * dz) + (dx * dx));

            //are we on the right side or not
            isOnRightSideCurrentLine = distanceFromCurrentLine > 0;

            //absolute the distance
            distanceFromCurrentLine = Math.Abs(distanceFromCurrentLine);

            // ** Pure pursuit ** - calc point on ABLine closest to current position
            double U = (((pivotAxlePosRP.easting - dubList[A].easting) * dx)
                        + ((pivotAxlePosRP.northing - dubList[A].northing) * dz))
                        / ((dx * dx) + (dz * dz));

            rEastRP = dubList[A].easting + (U * dx);
            rNorthRP = dubList[A].northing + (U * dz);

            //Subtract the two headings, if > 1.57 its going the opposite heading as refAB
            abFixHeadingDelta = (Math.Abs(mf.fixHeading - segmentHeading));
            if (abFixHeadingDelta >= Math.PI) abFixHeadingDelta = Math.Abs(abFixHeadingDelta - glm.twoPI);

            //used for accumulating distance to find goal point
            double distSoFar;

            //how far should goal point be away  - speed * seconds * kmph -> m/s + min value
            //double goalPointDistance = mf.pn.speed * mf.vehicle.goalPointLookAhead * 0.27777777;
            double goalPointDistance = mf.vehicle.goalPointLookAhead;

            //minimum of 4.0 meters look ahead
            if (goalPointDistance < 4.0) goalPointDistance = 4.0;

            // used for calculating the length squared of next segment.
            double tempDist = 0.0;

            //counting up
            isABSameAsFixHeading = true;
            distSoFar = glm.Distance(dubList[B].easting, dubList[B].northing, rEastRP, rNorthRP);

            //Is this segment long enough to contain the full lookahead distance?
            if (distSoFar > goalPointDistance)
            {
                //treat current segment like an AB Line
                goalPointRP.easting = rEastRP + (Math.Sin(dubList[A].heading) * goalPointDistance);
                goalPointRP.northing = rNorthRP + (Math.Cos(dubList[A].heading) * goalPointDistance);
            }

            //multiple segments required
            else
            {
                //cycle thru segments and keep adding lengths. check if end and break if so.
                while (B < ptCount - 1)
                {
                    B++; A++;
                    tempDist = glm.Distance(dubList[B].easting, dubList[B].northing, dubList[A].easting, dubList[A].northing);

                    //will we go too far?
                    if ((tempDist + distSoFar) > goalPointDistance)
                    {
                        //A--; B--;
                        break; //tempDist contains the full length of next segment
                    }

                    distSoFar += tempDist;
                }

                // the remainder to yet travel
                double t = (goalPointDistance - distSoFar);
                t /= tempDist;

                goalPointRP.easting = (((1 - t) * dubList[A].easting) + (t * dubList[B].easting));
                goalPointRP.northing = (((1 - t) * dubList[A].northing) + (t * dubList[B].northing));
            }

            return goalPointRP;
        }

        public void DrawRecordedLine()
        {
            int ptCount = recList.Count;
            if (ptCount < 1) return;
            gl.LineWidth(1);
            gl.Color(0.98f, 0.92f, 0.460f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(recList[h].easting, recList[h].northing, 0);
            gl.End();

            if (mf.isPureDisplayOn)
            {
                const int numSegments = 100;
                {
                    gl.Color(0.95f, 0.630f, 0.950f);

                    double theta = glm.twoPI / numSegments;
                    double c = Math.Cos(theta);//precalculate the sine and cosine
                    double s = Math.Sin(theta);

                    double x = ppRadiusRP;//we start at angle = 0
                    double y = 0;

                    gl.LineWidth(1);
                    gl.Begin(OpenGL.GL_LINE_LOOP);
                    for (int ii = 0; ii < numSegments; ii++)
                    {
                        //glVertex2f(x + cx, y + cy);//output vertex
                        gl.Vertex(x + radiusPointRP.easting, y + radiusPointRP.northing);//output vertex

                        //apply the rotation matrix
                        double t = x;
                        x = (c * x) - (s * y);
                        y = (s * t) + (c * y);
                    }
                    gl.End();

                    //Draw lookahead Point
                    gl.PointSize(8.0f);
                    gl.Begin(OpenGL.GL_POINTS);

                    //gl.Color(1.0f, 1.0f, 0.25f);
                    //gl.Vertex(rEast, rNorth, 0.0);

                    gl.Color(1.0f, 0.5f, 0.95f);
                    gl.Vertex(goalPointRP.easting, goalPointRP.northing, 0.0);

                    gl.End();
                    gl.PointSize(1.0f);
                }
            }
        }

        public void DrawDubins()
        {
            if (dubinsList.Count > 1)
            {
                gl.LineWidth(2);
                gl.Color(0.298f, 0.96f, 0.2960f);
                gl.Begin(OpenGL.GL_LINE_STRIP);
                for (int h = 0; h < dubinsList.Count; h++)
                    gl.Vertex(dubinsList[h].easting, dubinsList[h].northing, 0);
                gl.End();
            }
        }
    }
}