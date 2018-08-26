using SharpGL;
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

        private readonly double scanWidth, boxLength;

        //constructor
        public CBoundary(OpenGL _gl, OpenGL _glb, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            glb = _glb;

            boundarySelected = 0;
            scanWidth = 1.0;
            boxLength = 2000;
        }

        // the list of possible bounds points
        public List<vec4> bndClosestList = new List<vec4>();

        public int boundarySelected, closestBoundaryNum;

        //generated box for finding closest point
        public vec2 boxA = new vec2(9000, 9000), boxB = new vec2(9000, 9002);
        public vec2 boxC = new vec2(9001, 9001), boxD = new vec2(9002, 9003);

        //point at the farthest boundary segment from pivotAxle
        public vec3 closestBoundaryPt = new vec3(-10000, -10000, 9);

        public bool FindBoundaryPointInPath(vec3 fromPt, double headAB, int bndNum)
        {
            boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * -scanWidth);
            boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * -scanWidth);

            boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
            boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

            boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
            boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

            boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
            boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);

            //determine if point is inside bounding box
            bndClosestList.Clear();
            int ptCount = mf.bndArr[bndNum].bndLine.Count;
            for (int p = 0; p < ptCount; p++)
            {
                if ((((boxB.easting - boxA.easting) * (mf.bndArr[bndNum].bndLine[p].northing - boxA.northing))
                        - ((boxB.northing - boxA.northing) * (mf.bndArr[bndNum].bndLine[p].easting - boxA.easting))) < 0) { continue; }

                if ((((boxD.easting - boxC.easting) * (mf.bndArr[bndNum].bndLine[p].northing - boxC.northing))
                        - ((boxD.northing - boxC.northing) * (mf.bndArr[bndNum].bndLine[p].easting - boxC.easting))) < 0) { continue; }

                if ((((boxC.easting - boxB.easting) * (mf.bndArr[bndNum].bndLine[p].northing - boxB.northing))
                        - ((boxC.northing - boxB.northing) * (mf.bndArr[bndNum].bndLine[p].easting - boxB.easting))) < 0) { continue; }

                if ((((boxA.easting - boxD.easting) * (mf.bndArr[bndNum].bndLine[p].northing - boxD.northing))
                        - ((boxA.northing - boxD.northing) * (mf.bndArr[bndNum].bndLine[p].easting - boxD.easting))) < 0) { continue; }

                //there is a boundary point in the box.
                return true;
            }

            //no boundary point in box
            return false;
        }

        public void FindClosestBoundaryPoint(vec3 fromPt, double headAB)
        {
            //heading is based on ABLine, average Curve, and going same direction as AB or not
            //Draw a bounding box to determine if points are in it

            //if (mf.yt.isYouTurnTriggered || mf.yt.isEnteringDriveThru || mf.yt.isExitingDriveThru)
            //{
            //    boxA.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * -scanWidth); //subtract if positive
            //    boxA.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * -scanWidth);

            //    boxB.easting = fromPt.easting + (Math.Sin(headAB + glm.PIBy2) * scanWidth);
            //    boxB.northing = fromPt.northing + (Math.Cos(headAB + glm.PIBy2) * scanWidth);

            //    boxC.easting = boxB.easting + (Math.Sin(headAB) * boxLength);
            //    boxC.northing = boxB.northing + (Math.Cos(headAB) * boxLength);

            //    boxD.easting = boxA.easting + (Math.Sin(headAB) * boxLength);
            //    boxD.northing = boxA.northing + (Math.Cos(headAB) * boxLength);

            //    boxA.easting -= (Math.Sin(headAB) * boxLength);
            //    boxA.northing -= (Math.Cos(headAB) * boxLength);

            //    boxB.easting -= (Math.Sin(headAB) * boxLength);
            //    boxB.northing -= (Math.Cos(headAB) * boxLength);
            //}
            //else
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

            int ptCount;

            //determine if point is inside bounding box
            bndClosestList.Clear();
            vec4 inBox;
            for (int i = 0; i < FormGPS.MAXHEADS; i++)
            {
                //skip the drive thru
                if (mf.bndArr[i].isDriveThru) continue;

                ptCount = mf.bndArr[i].bndLine.Count;
                for (int p = 0; p < ptCount; p++)
                {
                    if ((((boxB.easting - boxA.easting) * (mf.bndArr[i].bndLine[p].northing - boxA.northing))
                            - ((boxB.northing - boxA.northing) * (mf.bndArr[i].bndLine[p].easting - boxA.easting))) < 0) { continue; }

                    if ((((boxD.easting - boxC.easting) * (mf.bndArr[i].bndLine[p].northing - boxC.northing))
                            - ((boxD.northing - boxC.northing) * (mf.bndArr[i].bndLine[p].easting - boxC.easting))) < 0) { continue; }

                    if ((((boxC.easting - boxB.easting) * (mf.bndArr[i].bndLine[p].northing - boxB.northing))
                            - ((boxC.northing - boxB.northing) * (mf.bndArr[i].bndLine[p].easting - boxB.easting))) < 0) { continue; }

                    if ((((boxA.easting - boxD.easting) * (mf.bndArr[i].bndLine[p].northing - boxD.northing))
                            - ((boxA.northing - boxD.northing) * (mf.bndArr[i].bndLine[p].easting - boxD.easting))) < 0) { continue; }

                    //it's in the box, so add to list
                    inBox.easting = mf.bndArr[i].bndLine[p].easting;
                    inBox.northing = mf.bndArr[i].bndLine[p].northing;
                    inBox.heading = mf.bndArr[i].bndLine[p].heading;
                    inBox.boundary = i;

                    //which boundary/headland is it from
                    bndClosestList.Add(inBox);
                }
            }

            //which of the points is closest
            closestBoundaryPt.easting = -20000; closestBoundaryPt.northing = -20000;
            ptCount = bndClosestList.Count;
            if (ptCount != 0)
            {
                //determine closest point
                double minDistance = 9999999;
                for (int i = 0; i < ptCount; i++)
                {
                    double dist = ((fromPt.easting - bndClosestList[i].easting) * (fromPt.easting - bndClosestList[i].easting))
                                    + ((fromPt.northing - bndClosestList[i].northing) * (fromPt.northing - bndClosestList[i].northing));
                    if (minDistance >= dist)
                    {
                        minDistance = dist;

                        closestBoundaryPt.easting = bndClosestList[i].easting;
                        closestBoundaryPt.northing = bndClosestList[i].northing;
                        closestBoundaryPt.heading = bndClosestList[i].heading;
                        mf.bnd.closestBoundaryNum = (int)bndClosestList[i].boundary;
                    }
                }
                if (closestBoundaryPt.heading < 0) closestBoundaryPt.heading += glm.twoPI;
            }
        }

        //draws the derived closest point
        public void DrawClosestPoint()
        {
            gl.PointSize(4.0f);

            gl.Color(0.919f, 0.932f, 0.070f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(closestBoundaryPt.easting, closestBoundaryPt.northing, 0);
            gl.End();

            gl.LineWidth(2);
            gl.Color(0.92f, 0.62f, 0.42f);
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(boxD.easting, boxD.northing, 0);
            gl.Vertex(boxA.easting, boxA.northing, 0);
            gl.Vertex(boxB.easting, boxB.northing, 0);
            gl.Vertex(boxC.easting, boxC.northing, 0);
            gl.End();
        }
    }
}