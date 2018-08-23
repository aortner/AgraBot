using SharpGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CHeadland
    {
        //copy of the mainform address
        private readonly FormGPS mf;

        private readonly OpenGL gl;

        public double includeAngle;
        public double boxLength;
        private readonly double scanWidth = 1.0;

        //closest headland segment from pivotAxle, heading contains which headland it came from
        public vec3 closestHeadlandPt = new vec3(-10000, -10000, 9);

        //generated box for finding closest point
        public vec2 boxA = new vec2(9999, 0), boxB = new vec2(9990, 2);

        public vec2 boxC = new vec2(9991, 1), boxD = new vec2(9992, 3);

        // the final list of possible headland points
        public List<vec3> hdClosestList = new List<vec3>();

        //constructor
        public CHeadland(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            includeAngle = glm.PIBy2 / 2.0;
            boxLength = mf.vehicle.toolWidth * 3.0;
            //scanWidth = mf.vehicle.toolWidth * 0.5;
            scanWidth = 1.0;
        }

        public void FindClosestHeadlandPoint(vec3 fromPt, double headAB, int bndNum)
        {
            //heading is based on ABLine, average Curve, and going same direction as AB or not
            //Draw a bounding box to determine if points are in it

            if (mf.yt.isYouTurnTriggered || mf.yt.isEnteringDriveThru || mf.yt.isExitingDriveThru)
            {
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * -scanWidth); //subtract if positive
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * -scanWidth);

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);

                boxA.easting -= (Math.Sin(headAB) * boxLength);
                boxA.northing -= (Math.Cos(headAB) * boxLength);

                boxB.easting -= (Math.Sin(headAB) * boxLength);
                boxB.northing -= (Math.Cos(headAB) * boxLength);
            }
            else
            {
                boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * -scanWidth);
                boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * -scanWidth);

                boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
                boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

                boxC.easting = boxB.easting + (Math.Sin(headAB) * 2000.0);
                boxC.northing = boxB.northing + (Math.Cos(headAB) * 2000.0);

                boxD.easting = boxA.easting + (Math.Sin(headAB) * 2000.0);
                boxD.northing = boxA.northing + (Math.Cos(headAB) * 2000.0);
            }

            //determine if point is inside bounding box
            int ptCount;
            hdClosestList.Clear();
            vec3 inBox;

            ptCount = mf.hlArr[bndNum].hlLine.Count;
            for (int p = 0; p < ptCount; p++)
            {
                if ((((boxB.easting - boxA.easting) * (mf.hlArr[bndNum].hlLine[p].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (mf.hlArr[bndNum].hlLine[p].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (mf.hlArr[bndNum].hlLine[p].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (mf.hlArr[bndNum].hlLine[p].easting - boxC.easting))) < 0) { continue; }

                if ((((boxC.easting - boxB.easting) * (mf.hlArr[bndNum].hlLine[p].northing - boxB.northing))
                        - ((boxC.northing - boxB.northing) * (mf.hlArr[bndNum].hlLine[p].easting - boxB.easting))) < 0) { continue; }

                if ((((boxA.easting - boxD.easting) * (mf.hlArr[bndNum].hlLine[p].northing - boxD.northing))
                        - ((boxA.northing - boxD.northing) * (mf.hlArr[bndNum].hlLine[p].easting - boxD.easting))) < 0) { continue; }

                //it's in the box, so add to list
                inBox = mf.hlArr[bndNum].hlLine[p];

                //which boundary/headland is it from
                hdClosestList.Add(inBox);
            }

            //which of the points is closest
            closestHeadlandPt.easting = -20000; closestHeadlandPt.northing = -20000;
            ptCount = hdClosestList.Count;
            if (ptCount != 0)
            {
                //determine closest point
                double minDistance = 9999999;
                for (int i = 0; i < ptCount; i++)
                {
                    double dist = ((fromPt.easting - hdClosestList[i].easting) * (fromPt.easting - hdClosestList[i].easting))
                                    + ((fromPt.northing - hdClosestList[i].northing) * (fromPt.northing - hdClosestList[i].northing));
                    if (minDistance >= dist)
                    {
                        minDistance = dist;
                        closestHeadlandPt.easting = hdClosestList[i].easting;
                        closestHeadlandPt.northing = hdClosestList[i].northing;
                        closestHeadlandPt.heading = hdClosestList[i].heading;
                    }
                }
                if (closestHeadlandPt.heading < 0) closestHeadlandPt.heading += glm.twoPI;
            }
        }

        //draws the derived closest point
        public void DrawClosestPoint()
        {
            gl.Color(0.919f, 0.0932f, 0.070f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(closestHeadlandPt.easting, closestHeadlandPt.northing, 0);
            gl.End();

            gl.LineWidth(2);
            gl.Color(0.2f, 0.62f, 0.42f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(boxD.easting, boxD.northing, 0);
            gl.Vertex(boxA.easting, boxA.northing, 0);
            gl.Vertex(boxB.easting, boxB.northing, 0);
            gl.Vertex(boxC.easting, boxC.northing, 0);
            gl.End();
        }
    }// end of CHeadland
}