using SharpGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormGenerate : Form
    {
        private readonly FormGPS mf = null;

        private double maxFieldX, maxFieldY, minFieldX, minFieldY, fieldCenterX, fieldCenterY, maxFieldDistance;
        private double headlandLineToolWidths;
        private bool isDrawingStart, isDrawingHeading;
        private bool doneDrawingPtAndDirection;
        private Point fixPt;

        private bool isDrawingHeadland;

        public FormGenerate(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormGenerate_Load(object sender, EventArgs e)
        {
            nudWidths.ValueChanged -= nudWidths_ValueChanged;
            headlandLineToolWidths = Properties.Vehicle.Default.set_youToolWidths;
            nudWidths.Value = (decimal)headlandLineToolWidths;
            nudWidths.ValueChanged += nudWidths_ValueChanged;

            nudHeadlandIncludeAngle.ValueChanged -= nudHeadlandIncludeAngle_ValueChanged;
            nudHeadlandIncludeAngle.Value = (int)((mf.hl.includeAngle / glm.PIBy2) * 10) * 10;
            nudHeadlandIncludeAngle.ValueChanged += nudHeadlandIncludeAngle_ValueChanged;

            lblNumPassesTotal.Text = mf.genPath.numHeadlandPasses.ToString();

            mf.genPath.GenerateGuideHelper();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            mf.FileSaveHeadland();
        }

        private void btnNumHeadlandPassesUp_Click(object sender, EventArgs e)
        {
            if (mf.genPath.numHeadlandPasses++ > 5) mf.genPath.numHeadlandPasses = 5;
            lblNumPassesTotal.Text = mf.genPath.numHeadlandPasses.ToString();
        }

        private void btnNumHeadlandPassesDn_Click(object sender, EventArgs e)
        {
            mf.genPath.numHeadlandPasses--;
            if (mf.genPath.numHeadlandPasses < 0) mf.genPath.numHeadlandPasses = 0;
            lblNumPassesTotal.Text = mf.genPath.numHeadlandPasses.ToString();
        }

        private void btnBringUpABLine_Click(object sender, EventArgs e)
        {
            mf.btnABLine.PerformClick();
        }

        private void nudWidths_ValueChanged(object sender, EventArgs e)
        {
            headlandLineToolWidths = (double)nudWidths.Value;
            Properties.Vehicle.Default.set_youToolWidths = (double)nudWidths.Value;
            Properties.Vehicle.Default.Save();
            //mf.hl.BuildHeadland((double)nudWidths.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //mf.hl.ResetHeadland();
            mf.genPath.genList.Clear();
            mf.genPath.startInfieldPoint.easting = 99999;
            mf.genPath.startInfieldPoint.northing = 99999;
            mf.genPath.startInfieldPoint.heading = 0;
            mf.genPath.headingInfieldPoint.easting = 99999;
            mf.genPath.headingInfieldPoint.northing = 99999;
            mf.genPath.headingInfieldPoint.heading = 0;
        }

        private void btnPathToInfieldStart_Click(object sender, EventArgs e)
        {
            mf.genPath.GeneratePathToStartInfield();
        }

        private void nudHeadlandIncludeAngle_ValueChanged(object sender, EventArgs e)
        {
            mf.hl.includeAngle = ((double)nudHeadlandIncludeAngle.Value / 100) * glm.PIBy2;
            //mf.hl.FixHeadlandList();
            //Enable the save ok button
            btnOK.Enabled = true;
        }

        private void btnStartDrawingHeadland_Click(object sender, EventArgs e)
        {
            //clear the headland point list
            //mf.hl.hlLine.Clear();
            isDrawingHeadland = true;

            btnStartDrawingHeadland.Enabled = false;
            btnDeleteLastPoint.Enabled = true;
            btnDoneDrawingHeadland.Enabled = true;

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            nudWidths.Enabled = false;
            nudHeadlandIncludeAngle.Enabled = false;
        }

        private void btnDeleteLastPoint_Click(object sender, EventArgs e)
        {
            //int ptCnt = mf.hl.hlLine.Count;
            //if (ptCnt > 0)
            //{
            //    mf.hl.hlLine.RemoveAt(ptCnt - 1);
            //}
        }

        private void btnDoneDrawingHeadland_Click(object sender, EventArgs e)
        {
            isDrawingHeadland = false;

            //if (mf.hl.hlLine.Count > 3)
            //{
            //    mf.hl.FixHeadlandList();

            //    //pre calculate all the constants and multiples
            //    mf.hl.PreCalcHeadlandLines();

            //}
            //else
            //{
            //    mf.hl.hlLine.Clear();
            //    mf.hl.isSet = false;
            //}

            btnStartDrawingHeadland.Enabled = true;
            btnDeleteLastPoint.Enabled = false;
            btnDoneDrawingHeadland.Enabled = false;

            btnOK.Enabled = true;
            btnCancel.Enabled = true;
            nudWidths.Enabled = true;
            nudHeadlandIncludeAngle.Enabled = true;
        }

        private void openGLHead_MouseDown(object sender, MouseEventArgs e)
        {
            Point pt = openGLHead.PointToClient(Cursor.Position);
            //lblX.Text = (pt.X - 400).ToString();
            //lblY.Text = ((800 - pt.Y) - 400).ToString();

            //Convert to Origin in the center of window, 800 pixels
            fixPt.X = pt.X - 480;
            fixPt.Y = (960 - pt.Y - 480);
            vec3 plotPt = new vec3
            {
                //convert screen coordinates to field coordinates
                easting = ((double)fixPt.X) * (double)maxFieldDistance / 925.0,
                northing = ((double)fixPt.Y) * (double)maxFieldDistance / 925.0,
                heading = 0
            };

            plotPt.easting += fieldCenterX;
            plotPt.northing += fieldCenterY;

            //if (isDrawingHeadland)
            //{
            //    //make sure point is in boundary
            //    if (mf.boundz.IsPointInsideBoundary(plotPt)) mf.hl.hlLine.Add(plotPt);
            //    else mf.TimedMessageBox(2000, "Outside of boundary", "Click inside the boundary!");
            //}

            if (isDrawingStart)
            {
                if (mf.bndArr[mf.bnd.boundarySelected].IsPointInsideBoundary(plotPt))
                {
                    mf.genPath.startInfieldPoint.easting = plotPt.easting;
                    mf.genPath.startInfieldPoint.northing = plotPt.northing;
                    isDrawingStart = false;
                    doneDrawingPtAndDirection = true;
                }
                else
                {
                    mf.TimedMessageBox(2000, "Outside of boundary", "Click inside the boundary!");
                }
            }

            if (isDrawingHeading)
            {
                if (mf.bndArr[mf.bnd.boundarySelected].IsPointInsideBoundary(plotPt))
                {
                    doneDrawingPtAndDirection = false;
                    mf.genPath.headingInfieldPoint.easting = plotPt.easting;
                    mf.genPath.headingInfieldPoint.northing = plotPt.northing;
                    mf.genPath.startInfieldPoint.heading = Math.Atan2(mf.genPath.headingInfieldPoint.easting - mf.genPath.startInfieldPoint.easting,
                        mf.genPath.headingInfieldPoint.northing - mf.genPath.startInfieldPoint.northing);
                    if (mf.genPath.startInfieldPoint.heading < 0) mf.genPath.startInfieldPoint.heading += glm.twoPI;

                    isDrawingHeading = false;
                    mf.genPath.isStartInfieldPointSet = true;

                    btnOK.Enabled = true;
                    btnCancel.Enabled = true;
                    btnStartPt.Enabled = true;
                    lblStartEasting.Text = "East: " + mf.genPath.startInfieldPoint.easting.ToString("N1");
                    lblStartNorthing.Text = "North: " + mf.genPath.startInfieldPoint.northing.ToString("N1");
                    lblStartHeading.Text = "Dir:" + (glm.toDegrees(mf.genPath.startInfieldPoint.heading)).ToString("N1");
                }
                else
                {
                    mf.TimedMessageBox(2000, "Outside of boundary", "Click inside the boundary!");
                }
            }

            if (doneDrawingPtAndDirection) isDrawingHeading = true;
        }

        private void btnMakeHeadRecPath_Click(object sender, EventArgs e)
        {
            mf.genPath.GenerateHeadlandPath();
        }

        private void btnStartPt_Click(object sender, EventArgs e)
        {
            mf.TimedMessageBox(1000, "Create the field Start Point", "And then click a direction");

            mf.genPath.headingInfieldPoint.easting = 0;
            mf.genPath.headingInfieldPoint.northing = 0;
            mf.genPath.startInfieldPoint.heading = 0;

            isDrawingStart = true;
            mf.genPath.isStartInfieldPointSet = false;

            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            btnStartPt.Enabled = false;
        }

        private void openGLHead_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL glh = openGLHead.OpenGL;

            glh.Enable(OpenGL.GL_CULL_FACE);
            glh.CullFace(OpenGL.GL_BACK);
        }

        private void openGLHead_Resized(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL glh = openGLHead.OpenGL;

            glh.MatrixMode(OpenGL.GL_PROJECTION);

            //  Set the clear color.
            glh.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            //  Load the identity.
            glh.LoadIdentity();

            //  Create a perspective transformation.
            glh.Perspective(55f, 1, 1, 20000);

            //  Set the modelview matrix.
            glh.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void openGLHead_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL glh = openGLHead.OpenGL;
            glh.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	// Clear The Screen And The Depth Buffer
            glh.LoadIdentity();                  // Reset The View

            CalculateMinMax();

            //back the camera up
            glh.Translate(0, 0, -maxFieldDistance);

            //translate to that spot in the world
            glh.Translate(-fieldCenterX, -fieldCenterY, 0);

            //calculate the frustum for the section control window
            mf.CalcFrustum(glh);

            //to draw or not the triangle patch
            bool isDraw;

            glh.Color(0.2f, 0.5f, 0.4f);

            //draw patches j= # of sections
            for (int j = 0; j < mf.vehicle.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = mf.section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in mf.section[j].patchList)
                    {
                        isDraw = false;
                        int count2 = triList.Count;
                        for (int i = 0; i < count2; i += 3)
                        {
                            //determine if point is in frustum or not since 2d only 4 planes required
                            if ((mf.frustum[0] * triList[i].easting) + (mf.frustum[1] * triList[i].northing) + mf.frustum[3] <= 0)
                                continue;//right
                            if ((mf.frustum[4] * triList[i].easting) + (mf.frustum[5] * triList[i].northing) + mf.frustum[7] <= 0)
                                continue;//left
                            if ((mf.frustum[16] * triList[i].easting) + (mf.frustum[17] * triList[i].northing) + mf.frustum[19] <= 0)
                                continue;//bottom
                            if ((mf.frustum[20] * triList[i].easting) + (mf.frustum[21] * triList[i].northing) + mf.frustum[23] <= 0)
                                continue;//top

                            //point is in frustum so draw the entire patch
                            isDraw = true;
                            break;
                        }

                        if (isDraw)
                        {
                            //draw the triangle in each triangle strip
                            glh.Begin(OpenGL.GL_TRIANGLE_STRIP);
                            count2 = triList.Count;
                            const int mipmap = 8;

                            //if large enough patch and camera zoomed out, fake mipmap the patches, skip triangles
                            if (count2 >= (mipmap + 2))
                            {
                                int step = mipmap;
                                for (int i = 0; i < count2; i += step)
                                {
                                    glh.Vertex(triList[i].easting, triList[i].northing, 0); i++;
                                    glh.Vertex(triList[i].easting, triList[i].northing, 0); i++;

                                    //too small to mipmap it
                                    if (count2 - i <= (mipmap + 2)) step = 0;
                                }
                            }
                            else { for (int i = 0; i < count2; i++) glh.Vertex(triList[i].easting, triList[i].northing, 0); }
                            glh.End();
                        }
                    }
                }
            } //end of section patches

            glh.PointSize(8.0f);
            glh.Begin(OpenGL.GL_POINTS);
            glh.Color(0.95f, 0.90f, 0.60f);

#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception
            glh.Vertex(mf.pivotAxlePos.easting, mf.pivotAxlePos.northing, 0.0);
#pragma warning restore CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception

            //draw the pivot, startPt and Heading Pt and line
            glh.Color(0.95f, 0.0f, 0.0f);
            glh.Vertex(mf.genPath.startInfieldPoint.easting, mf.genPath.startInfieldPoint.northing, 0);
            glh.Color(0.90f, 0.90f, 0.0f);
            glh.Vertex(mf.genPath.headingInfieldPoint.easting, mf.genPath.headingInfieldPoint.northing, 0);
            glh.End();

            if (mf.genPath.isStartInfieldPointSet)
            {
                glh.LineWidth(4);
                glh.Color(0.95f, 0.0f, 0.30f);
                glh.Begin(OpenGL.GL_LINE_STRIP);
                glh.Vertex(mf.genPath.startInfieldPoint.easting, mf.genPath.startInfieldPoint.northing, 0);
                glh.Color(0.90f, 0.90f, 0.30f);
                glh.Vertex(mf.genPath.headingInfieldPoint.easting, mf.genPath.headingInfieldPoint.northing, 0);
                glh.End();
            }

            //set pointsize
            glh.PointSize(2.0f);

            ////draw the outside boundary
            glh.LineWidth(2);

            int ptCount = mf.bndArr[mf.bnd.boundarySelected].bndLine.Count;
            if (ptCount > 0)
            {
                glh.Color(0.98f, 0.2f, 0.90f);
                glh.Begin(OpenGL.GL_LINE_STRIP);
                for (int h = 0; h < ptCount; h++) glh.Vertex(mf.bndArr[mf.bnd.boundarySelected].bndLine[h].easting, mf.bndArr[mf.bnd.boundarySelected].bndLine[h].northing, 0);

                //the "close the loop" line
                //glh.LineWidth(4);
                glh.Color(0.0f, 0.990f, 0.0f);
                glh.Vertex(mf.bndArr[mf.bnd.boundarySelected].bndLine[ptCount - 1].easting, mf.bndArr[mf.bnd.boundarySelected].bndLine[ptCount - 1].northing, 0);
                glh.Vertex(mf.bndArr[mf.bnd.boundarySelected].bndLine[0].easting, mf.bndArr[mf.bnd.boundarySelected].bndLine[0].northing, 0);
                glh.End();

                glh.Begin(OpenGL.GL_LINE_STRIP);
                ptCount = mf.genPath.genList.Count;
                glh.Color(0.9574f, 0.959760f, 0.43f);
                for (int h = 1; h < ptCount; h++) glh.Vertex(mf.genPath.genList[h].easting, mf.genPath.genList[h].northing, 0);
                glh.End();
            }

            ////draw the headland line
            for (int i = 0; i < FormGPS.MAXHEADS; i++)
            {
                if (mf.hlArr[i].isSet)
                {
                    ptCount = mf.hlArr[i].hlLine.Count;
                    glh.PointSize(4.0f);
                    if (ptCount > 0)
                    {
                        glh.Color(0.009038f, 0.9892f, 0.10f);
                        glh.Begin(OpenGL.GL_POINTS);
                        for (int h = 0; h < ptCount; h++) glh.Vertex(mf.hlArr[i].hlLine[h].easting, mf.hlArr[i].hlLine[h].northing, 0);
                        glh.End();
                    }
                }
            }

            ////draw the guide helper line
            ptCount = mf.genPath.guideList.Count;
            if (ptCount > 0)
            {
                glh.Color(0.23009038f, 0.332f, 0.8430f);
                glh.Begin(OpenGL.GL_POINTS);
                for (int h = 0; h < ptCount; h++) glh.Vertex(mf.genPath.guideList[h].easting, mf.genPath.guideList[h].northing, 0);
                glh.End();
            }

            //plot the touch points so far
            if (isDrawingHeadland)
            {
                ////draw the headland line so far
                //ptCount = mf.hl.hlLine.Count;
                //if (ptCount > 0)
                //{
                //    glh.Color(0.08f, 0.9892f, 0.2710f);
                //    glh.Begin(OpenGL.GL_LINE_STRIP);
                //    for (int h = 0; h < ptCount; h++) glh.Vertex(mf.hl.hlLine[h].easting, mf.hl.hlLine[h].northing, 0);
                //    glh.End();

                //    glh.Color(0.978f, 0.392f, 0.10f);
                //    //the "close the loop" line
                //    glh.Begin(OpenGL.GL_LINE_STRIP);
                //    glh.Vertex(mf.hl.hlLine[ptCount - 1].easting, mf.hl.hlLine[ptCount - 1].northing, 0);
                //    glh.Vertex(mf.hl.hlLine[0].easting, mf.hl.hlLine[0].northing, 0);
                //    glh.End();
                //}
            }

            //draw the ABLine
            if (mf.ABLine.isABLineSet | mf.ABLine.isABLineBeingSet)
            {
                //Draw reference AB line
                glh.LineWidth(1);
                glh.Enable(OpenGL.GL_LINE_STIPPLE);
                glh.LineStipple(1, 0x00F0);

                glh.Begin(OpenGL.GL_LINES);
                glh.Color(0.9f, 0.45f, 0.87f);
                glh.Vertex(mf.ABLine.refABLineP1.easting, mf.ABLine.refABLineP1.northing, 0);
                glh.Vertex(mf.ABLine.refABLineP2.easting, mf.ABLine.refABLineP2.northing, 0);
                glh.End();
                glh.Disable(OpenGL.GL_LINE_STIPPLE);

                //raw current AB Line
                glh.Begin(OpenGL.GL_LINES);
                glh.Color(0.9f, 0.0f, 0.50f);
                glh.Vertex(mf.ABLine.currentABLineP1.easting, mf.ABLine.currentABLineP1.northing, 0.0);
                glh.Vertex(mf.ABLine.currentABLineP2.easting, mf.ABLine.currentABLineP2.northing, 0.0);
                glh.End();
            }

            //draw curve if there is one
            if (mf.curve.isCurveSet)
            {
                int ptC = mf.curve.curList.Count;
                if (ptC > 0)
                {
                    glh.LineWidth(2);
                    glh.Color(0.95f, 0.25f, 0.50f);
                    glh.Begin(OpenGL.GL_LINE_STRIP);
                    for (int h = 0; h < ptC; h++) glh.Vertex(mf.curve.curList[h].easting, mf.curve.curList[h].northing, 0);
                    glh.End();
                }
            }

            glh.PointSize(1.0f);
        }

        //determine mins maxs of patches and whole field.
        private void CalculateMinMax()
        {
            minFieldX = 9999999; minFieldY = 9999999;
            maxFieldX = -9999999; maxFieldY = -9999999;

            //draw patches j= # of sections
            for (int j = 0; j < mf.vehicle.numSuperSection; j++)
            {
                //every time the section turns off and on is a new patch
                int patchCount = mf.section[j].patchList.Count;

                if (patchCount > 0)
                {
                    //for every new chunk of patch
                    foreach (var triList in mf.section[j].patchList)
                    {
                        int count2 = triList.Count;
                        for (int i = 0; i < count2; i += 3)
                        {
                            double x = triList[i].easting;
                            double y = triList[i].northing;

                            //also tally the max/min of field x and z
                            if (minFieldX > x) minFieldX = x;
                            if (maxFieldX < x) maxFieldX = x;
                            if (minFieldY > y) minFieldY = y;
                            if (maxFieldY < y) maxFieldY = y;
                        }
                    }
                }

                //min max of the boundary
                int bndCnt = mf.bndArr[mf.bnd.boundarySelected].bndLine.Count;
                if (bndCnt > 0)
                {
                    for (int i = 0; i < bndCnt; i++)
                    {
                        double x = mf.bndArr[mf.bnd.boundarySelected].bndLine[i].easting;
                        double y = mf.bndArr[mf.bnd.boundarySelected].bndLine[i].northing;

                        //also tally the max/min of field x and z
                        if (minFieldX > x) minFieldX = x;
                        if (maxFieldX < x) maxFieldX = x;
                        if (minFieldY > y) minFieldY = y;
                        if (maxFieldY < y) maxFieldY = y;
                    }
                }

                if (maxFieldX == -9999999 | minFieldX == 9999999 | maxFieldY == -9999999 | minFieldY == 9999999)
                {
                    maxFieldX = 0; minFieldX = 0; maxFieldY = 0; minFieldY = 0;
                }
                else
                {
                    //the largest distancew across field
                    double dist = Math.Abs(minFieldX - maxFieldX);
                    double dist2 = Math.Abs(minFieldY - maxFieldY);

                    if (dist > dist2) maxFieldDistance = dist;
                    else maxFieldDistance = dist2;

                    if (maxFieldDistance < 100) maxFieldDistance = 100;
                    if (maxFieldDistance > 19900) maxFieldDistance = 19900;
                    //lblMax.Text = ((int)maxFieldDistance).ToString();

                    fieldCenterX = (maxFieldX + minFieldX) / 2.0;
                    fieldCenterY = (maxFieldY + minFieldY) / 2.0;
                }

                //if (isMetric)
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX)).ToString("N0") + " m";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY)).ToString("N0") + " m";
                //}
                //else
                //{
                //    lblFieldWidthEastWest.Text = Math.Abs((maxFieldX - minFieldX) * glm.m2ft).ToString("N0") + " ft";
                //    lblFieldWidthNorthSouth.Text = Math.Abs((maxFieldY - minFieldY) * glm.m2ft).ToString("N0") + " ft";
                //}
            }
        }
    }
}