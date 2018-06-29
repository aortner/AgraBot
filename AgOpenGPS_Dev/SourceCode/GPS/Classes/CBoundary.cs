﻿using SharpGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CBoundary
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        private readonly OpenGL gl;
        private readonly OpenGL glb;

        //constructor
        public CBoundary(OpenGL _gl, OpenGL _glb, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            glb = _glb;

            area = 0;
            isSet = false;
            isDrawRightSide = true;
            isOkToAddPoints = false;
        }

        //list of coordinates of boundary line
        public List<vec3> ptList = new List<vec3>();

        //the list of constants and multiples of the boundary
        public List<vec2> calcList = new List<vec2>();

        // the list of possible bounds points
        public List<vec2> bdList = new List<vec2>();

        //area variable
        public double area;

        public string areaHectare = "";
        public string areaAcre = "";

        //boundary variables
        public bool isOkToAddPoints, isSet, isDrawRightSide;

        //generated box for finding closest point
        public vec2 boxA = new vec2(9000, 9000), boxB = new vec2(9000, 9002);
        public vec2 boxC = new vec2(9001, 9001), boxD = new vec2(9002, 9003);

        //point at the farthest boundary segment from pivotAxle
        public vec2 closestBoundaryPt = new vec2(-10000, -10000);

        public void CalculateHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = ptList.Count;
            vec3[] arr = new vec3[cnt];
            cnt--;
            ptList.CopyTo(arr);
            ptList.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            ptList.Add(pt3);

            //middle points
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i+1].easting - arr[i-1].easting, arr[i+1].northing - arr[i-1].northing);
                if (pt3.heading < 0) pt3.heading += glm.twoPI;
                ptList.Add(pt3);
            }

            //last and first point
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt-1].easting, arr[0].northing - arr[cnt-1].northing);
            if (pt3.heading < 0) pt3.heading += glm.twoPI;
            ptList.Add(pt3);
        }

        public void FindClosestBoundaryPoint(vec2 fromPt)
        {
            boxA.easting = fromPt.easting - (Math.Sin(mf.fixHeading + glm.PIBy2) * mf.vehicle.toolWidth * 0.5);
            boxA.northing = fromPt.northing - (Math.Cos(mf.fixHeading + glm.PIBy2) * mf.vehicle.toolWidth * 0.5);

            boxB.easting = fromPt.easting + (Math.Sin(mf.fixHeading + glm.PIBy2) * mf.vehicle.toolWidth * 0.5);
            boxB.northing = fromPt.northing + (Math.Cos(mf.fixHeading + glm.PIBy2) * mf.vehicle.toolWidth * 0.5);

            boxC.easting = boxB.easting + (Math.Sin(mf.fixHeading) * 2000.0);
            boxC.northing = boxB.northing + (Math.Cos(mf.fixHeading) * 2000.0);

            boxD.easting = boxA.easting + (Math.Sin(mf.fixHeading) * 2000.0);
            boxD.northing = boxA.northing + (Math.Cos(mf.fixHeading) * 2000.0);

            //determine if point is inside bounding box
            bdList.Clear();
            int ptCount = ptList.Count;
            for (int p = 0; p < ptCount; p++)
            {
                if ((((boxB.easting - boxA.easting) * (ptList[p].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (ptList[p].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (ptList[p].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (ptList[p].easting - boxC.easting))) < 0) { continue; }

                if ((((boxC.easting - boxB.easting) * (ptList[p].northing - boxB.northing))
                        - ((boxC.northing - boxB.northing) * (ptList[p].easting - boxB.easting))) < 0) { continue; }

                if ((((boxA.easting - boxD.easting) * (ptList[p].northing - boxD.northing))
                        - ((boxA.northing - boxD.northing) * (ptList[p].easting - boxD.easting))) < 0) { continue; }

                //it's in the box, so add to list
                closestBoundaryPt.easting = ptList[p].easting;
                closestBoundaryPt.northing = ptList[p].northing;
                bdList.Add(closestBoundaryPt);
            }

            //which of the points is closest
            closestBoundaryPt.easting = -1; closestBoundaryPt.northing = -1;
            ptCount = bdList.Count;
            if (ptCount == 0)
            {
                return;
            }
            else
            {
                //determine closest point
                double minDistance = 9999999;
                for (int i = 0; i < ptCount; i++)
                {
                    double dist = ((fromPt.easting - bdList[i].easting) * (fromPt.easting - bdList[i].easting))
                                    + ((fromPt.northing - bdList[i].northing) * (fromPt.northing - bdList[i].northing));
                    if (minDistance >= dist)
                    {
                        minDistance = dist;
                        closestBoundaryPt = bdList[i];
                    }
                }
            }
        }

        public void ResetBoundary()
        {
            calcList.Clear();
            ptList.Clear();
            area = 0;
            areaAcre = "";
            areaHectare = "";

            isDrawRightSide = true;
            isSet = false;
            isOkToAddPoints = false;
        }

        public void PreCalcBoundaryLines()
        {
            int j = ptList.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < ptList.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(ptList[i].northing - ptList[j].northing) < 0.00000000001)
                {
                    constantMultiple.easting = ptList[i].easting;
                    constantMultiple.northing = 0;
                    calcList.Add(constantMultiple);
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = ptList[i].easting - ((ptList[i].northing * ptList[j].easting)
                                    / (ptList[j].northing - ptList[i].northing)) + ((ptList[i].northing * ptList[i].easting)
                                        / (ptList[j].northing - ptList[i].northing));
                    constantMultiple.northing = (ptList[j].easting - ptList[i].easting) / (ptList[j].northing - ptList[i].northing);
                    calcList.Add(constantMultiple);
                }
            }

            areaHectare = Math.Round(mf.boundz.area * 0.0001, 1) + " Ha";
            areaAcre = Math.Round(mf.boundz.area * 0.000247105, 1) + " Ac";
        }

        public bool IsPointInsideBoundary(vec3 testPointv3)
        {
            if (calcList.Count < 3) return false;
            int j = ptList.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < ptList.Count; j = i++)
            {
                if ((ptList[i].northing < testPointv3.northing && ptList[j].northing >= testPointv3.northing)
                || (ptList[j].northing < testPointv3.northing && ptList[i].northing >= testPointv3.northing))
                {
                    oddNodes ^= ((testPointv3.northing * calcList[i].northing) + calcList[i].easting < testPointv3.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public bool IsPointInsideBoundary(vec2 testPointv2)
        {
            if (calcList.Count < 3) return false;
            int j = ptList.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < ptList.Count; j = i++)
            {
                if ((ptList[i].northing < testPointv2.northing && ptList[j].northing >= testPointv2.northing)
                || (ptList[j].northing < testPointv2.northing && ptList[i].northing >= testPointv2.northing))
                {
                    oddNodes ^= ((testPointv2.northing * calcList[i].northing) + calcList[i].easting < testPointv2.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawBoundaryLine()
        {
            ////draw the perimeter line so far
            int ptCount = ptList.Count;
            if (ptCount < 1) return;
            gl.LineWidth(2);
            gl.Color(0.95f, 0.2f, 0.60f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) gl.Vertex(ptList[h].easting, ptList[h].northing, 0);
            gl.End();

            //the "close the loop" line
            gl.LineWidth(2);
            gl.Color(0.9f, 0.632f, 0.4170f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(ptList[ptCount - 1].easting, ptList[ptCount - 1].northing, 0);
            gl.Vertex(ptList[0].easting, ptList[0].northing, 0);
            gl.End();

            gl.LineWidth(2);
            gl.Color(0.98f, 0.2f, 0.60f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(boxD.easting, boxD.northing, 0);
            gl.Vertex(boxA.easting, boxA.northing, 0);
            gl.Vertex(boxB.easting, boxB.northing, 0);
            gl.Vertex(boxC.easting, boxC.northing, 0);
            gl.End();

            ptCount = bdList.Count;
            if (ptCount < 1) return;
            gl.PointSize(4);
            gl.Color(0.19f, 0.932f, 0.70f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(closestBoundaryPt.easting, closestBoundaryPt.northing, 0);
            gl.End();
        }

        //draw a blue line in the back buffer for section control over boundary line
        public void DrawBoundaryLineOnBackBuffer()
        {
            ////draw the perimeter line so far
            int ptCount = ptList.Count;
            if (ptCount < 1) return;
            glb.LineWidth(4);
            glb.Color(0.0f, 0.99f, 0.0f);
            glb.Begin(OpenGL.GL_LINE_STRIP);
            for (int h = 0; h < ptCount; h++) glb.Vertex(ptList[h].easting, ptList[h].northing, 0);
            glb.End();

            //the "close the loop" line
            glb.LineWidth(4);
            glb.Color(0.0f, 0.990f, 0.0f);
            glb.Begin(OpenGL.GL_LINE_STRIP);
            glb.Vertex(ptList[ptCount - 1].easting, ptList[ptCount - 1].northing, 0);
            glb.Vertex(ptList[0].easting, ptList[0].northing, 0);
            glb.End();
        }

        //obvious
        public void CalculateBoundaryArea()
        {
            int ptCount = ptList.Count;
            if (ptCount < 1) return;

            area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (ptList[j].easting + ptList[i].easting) * (ptList[j].northing - ptList[i].northing);
            }
            area = Math.Abs(area / 2);
        }
    }
}