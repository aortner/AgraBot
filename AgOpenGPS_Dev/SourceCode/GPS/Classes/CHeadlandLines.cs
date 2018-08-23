using SharpGL;
using System;
using System.Collections.Generic;

namespace AgOpenGPS
{
    public class CHeadlandLines
    {
        private readonly FormGPS mf;
        private readonly OpenGL gl;

        public bool isSet;
        public bool isPassThru;

        private double oneSide, distance;

        //list of coordinates of headland line
        public List<vec3> hlLine = new List<vec3>();

        //the list of constants and multiples of the headland
        public List<vec2> calcList = new List<vec2>();

        //// the final list of possible headland points
        //public List<vec3> hdList = new List<vec3>();

        public CHeadlandLines(OpenGL _gl, FormGPS _f)
        {
            mf = _f;
            gl = _gl;
            isSet = false;
            isPassThru = false;
        }

        public void BuildHeadland(double widthSet, int inBndNum)
        {
            //count the points from the boundary
            int ptCount = mf.bndArr[inBndNum].bndLine.Count;

            //first find out which side is inside the boundary
            oneSide = glm.PIBy2;
            vec3 point = new vec3(mf.bndArr[inBndNum].bndLine[3].easting - (Math.Sin(oneSide + mf.bndArr[inBndNum].bndLine[3].heading) * 2.0),
            mf.bndArr[inBndNum].bndLine[3].northing - (Math.Cos(oneSide + mf.bndArr[inBndNum].bndLine[3].heading) * 2.0), 0.0);

            if (inBndNum == 0 && !mf.bndArr[inBndNum].IsPointInsideBoundary(point)) oneSide *= -1.0;
            if (inBndNum != 0 && mf.bndArr[inBndNum].IsPointInsideBoundary(point)) oneSide *= -1.0;

            //clear the headland point list
            hlLine.Clear();

            //determine how wide a headland space
            double totalHeadWidth = (mf.vehicle.toolWidth - mf.vehicle.toolOverlap) * widthSet;

            for (int i = 0; i < ptCount; i++)
            {
                //calculate the point inside the boundary
                point.easting = mf.bndArr[inBndNum].bndLine[i].easting - (Math.Sin(oneSide + mf.bndArr[inBndNum].bndLine[i].heading) * totalHeadWidth);
                point.northing = mf.bndArr[inBndNum].bndLine[i].northing - (Math.Cos(oneSide + mf.bndArr[inBndNum].bndLine[i].heading) * totalHeadWidth);
                point.heading = mf.bndArr[inBndNum].bndLine[i].heading;

                //only add if inside actual field boundary, outer boundary is 0 and opposite
                if (inBndNum == 0 && mf.bndArr[inBndNum].IsPointInsideBoundary(point)) hlLine.Add(point);
                if (inBndNum != 0 && !mf.bndArr[inBndNum].IsPointInsideBoundary(point)) hlLine.Add(point);
            }

            int headCount = hlLine.Count;

            //remove the points too close to boundary
            for (int i = 0; i < ptCount; i++)
            {
                for (int j = 0; j < headCount; j++)
                {
                    //make sure distance between headland and boundary is not less then width
                    distance = glm.Distance(mf.bndArr[inBndNum].bndLine[i], hlLine[j]);
                    if (distance < (totalHeadWidth * 0.98))
                    {
                        hlLine.RemoveAt(j);
                        headCount = hlLine.Count;
                        j = 0;
                    }
                }
            }

            //fix the gaps and overlaps
            FixHeadlandList();

            //pre calculate all the constants and multiples
            PreCalcHeadlandLines();
        }

        public void FixHeadlandList()
        {
            //make sure distance isn't too small between points on headland
            int headCount = hlLine.Count;
            //double spacing = mf.vehicle.toolWidth * 0.25;
            const double spacing = 0.9;
            double distance;
            for (int i = 0; i < headCount - 1; i++)
            {
                distance = glm.Distance(hlLine[i], hlLine[i + 1]);
                if (distance < spacing)
                {
                    hlLine.RemoveAt(i + 1);
                    headCount = hlLine.Count;
                    i = 0;
                }
            }

            //make sure distance isn't too big between points on headland
            vec3 point;
            headCount = hlLine.Count;
            for (int i = 0; i < headCount; i++)
            {
                int j = i + 1;
                if (j == headCount) j = 0;
                distance = glm.Distance(hlLine[i], hlLine[j]);
                if (distance > (spacing * 1.05))
                {
                    point.easting = (hlLine[i].easting + hlLine[j].easting) / 2.0;
                    point.northing = (hlLine[i].northing + hlLine[j].northing) / 2.0;
                    point.heading = hlLine[i].heading;

                    hlLine.Insert(j, point);
                    headCount = hlLine.Count;
                    i = 0;
                }
            }

            //make sure headings are correct for calculated points
            CalculateHeadings();

            //must be perpendicularish to the guidance line to be a headland point
            headCount = hlLine.Count;
            double ref2, abHead;

            //fix the heading so it goes from 0 to PI
            abHead = mf.ABLine.abHeading;
            if (abHead > Math.PI) abHead -= Math.PI;

            //remove any points
            if (mf.ABLine.isABLineSet)
            {
                for (int i = 0; i < headCount; i++)
                {
                    ref2 = Math.PI - Math.Abs(Math.Abs(abHead - hlLine[i].heading) - Math.PI);
                    if (ref2 < (glm.PIBy2 - mf.hl.includeAngle) || (ref2 > glm.PIBy2 + mf.hl.includeAngle))
                    {
                        hlLine.RemoveAt(i);
                        headCount = hlLine.Count;
                        i = 0;
                    }
                }
            }
            else
            {
                for (int i = 0; i < headCount; i++)
                {
                    ref2 = Math.PI - Math.Abs(Math.Abs(mf.curve.aveLineHeading - hlLine[i].heading) - Math.PI);
                    if (ref2 < (glm.PIBy2 - mf.hl.includeAngle) || (ref2 > glm.PIBy2 + mf.hl.includeAngle))
                    {
                        hlLine.RemoveAt(i);
                        headCount = hlLine.Count;
                        i = 0;
                    }
                }
            }

            //line is built
            isSet = true;
        }

        public void CalculateHeadings()
        {
            //to calc heading based on next and previous points to give an average heading.
            int cnt = hlLine.Count;
            if (cnt == 0) return;
            vec3[] arr = new vec3[cnt];
            cnt--;
            hlLine.CopyTo(arr);
            hlLine.Clear();

            //first point needs last, first, second points
            vec3 pt3 = arr[0];
            pt3.heading = Math.Atan2(arr[1].easting - arr[cnt].easting, arr[1].northing - arr[cnt].northing);
            hlLine.Add(pt3);
            for (int i = 1; i < cnt; i++)
            {
                pt3 = arr[i];
                pt3.heading = Math.Atan2(arr[i + 1].easting - arr[i - 1].easting, arr[i + 1].northing - arr[i - 1].northing);
                hlLine.Add(pt3);
            }
            pt3 = arr[cnt];
            pt3.heading = Math.Atan2(arr[0].easting - arr[cnt - 1].easting, arr[0].northing - arr[cnt - 1].northing);
            hlLine.Add(pt3);
        }

        public void ResetHeadland()
        {
            calcList.Clear();
            hlLine.Clear();
            isSet = false;
            isPassThru = false;
        }

        public bool IsPointInsideHeadland(vec2 testPoint)
        {
            if (calcList.Count < 10) return false;
            int j = hlLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < hlLine.Count; j = i++)
            {
                if ((hlLine[i].northing < testPoint.northing && hlLine[j].northing >= testPoint.northing)
                || (hlLine[j].northing < testPoint.northing && hlLine[i].northing >= testPoint.northing))
                {
                    oddNodes ^= ((testPoint.northing * calcList[i].northing) + calcList[i].easting < testPoint.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public bool IsPointInsideHeadland(vec3 testPoint)
        {
            if (calcList.Count < 10) return false;
            int j = hlLine.Count - 1;
            bool oddNodes = false;

            //test against the constant and multiples list the test point
            for (int i = 0; i < hlLine.Count; j = i++)
            {
                if ((hlLine[i].northing < testPoint.northing && hlLine[j].northing >= testPoint.northing)
                || (hlLine[j].northing < testPoint.northing && hlLine[i].northing >= testPoint.northing))
                {
                    oddNodes ^= ((testPoint.northing * calcList[i].northing) + calcList[i].easting < testPoint.easting);
                }
            }
            return oddNodes; //true means inside.
        }

        public void DrawHeadlandLine()
        {
            int ptCount = hlLine.Count;
            if (ptCount < 1) return;
            gl.PointSize(2);
            gl.Color(0.08629198f, 0.969272f, 0.5360f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int h = 1; h < ptCount; h++) gl.Vertex(hlLine[h].easting, hlLine[h].northing, 0);
            //gl.End();

            //gl.Color(0.919f, 0.0932f, 0.070f);
            //gl.Begin(OpenGL.GL_POINTS);
            //gl.Vertex(closestHeadlandPt.easting, closestHeadlandPt.northing, 0);
            gl.End();
        }

        public void PreCalcHeadlandLines()
        {
            int j = hlLine.Count - 1;
            //clear the list, constant is easting, multiple is northing
            calcList.Clear();
            vec2 constantMultiple = new vec2(0, 0);

            for (int i = 0; i < hlLine.Count; j = i++)
            {
                //check for divide by zero
                if (Math.Abs(hlLine[i].northing - hlLine[j].northing) < 0.00000000001)
                {
                    constantMultiple.easting = hlLine[i].easting;
                    constantMultiple.northing = 0;
                    calcList.Add(constantMultiple);
                }
                else
                {
                    //determine constant and multiple and add to list
                    constantMultiple.easting = hlLine[i].easting - ((hlLine[i].northing * hlLine[j].easting)
                                    / (hlLine[j].northing - hlLine[i].northing)) + ((hlLine[i].northing * hlLine[i].easting)
                                        / (hlLine[j].northing - hlLine[i].northing));
                    constantMultiple.northing = (hlLine[j].easting - hlLine[i].easting) / (hlLine[j].northing - hlLine[i].northing);
                    calcList.Add(constantMultiple);
                }
            }
        }

        public double CalculateHeadlandArea()
        {
            int ptCount = hlLine.Count;
            if (ptCount < 1) return 0.0;

            double area = 0;         // Accumulates area in the loop
            int j = ptCount - 1;  // The last vertex is the 'previous' one to the first

            for (int i = 0; i < ptCount; j = i++)
            {
                area += (hlLine[j].easting + hlLine[i].easting) * (hlLine[j].northing - hlLine[i].northing);
            }
            return Math.Abs(area / 2);
        }
    }
}