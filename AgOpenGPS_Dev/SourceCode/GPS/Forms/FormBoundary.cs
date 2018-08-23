using System;
using System.Globalization;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundary : Form
    {
        private readonly FormGPS mf = null;

        public FormBoundary(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void UpdateChart()
        {
            if (mf.isMetric)
            {
                //outer metric
                lvLines.Items[0].SubItems[2].Text = "NA";
                if (mf.bndArr[0].isSet) lvLines.Items[0].SubItems[1].Text = Math.Round(mf.bndArr[0].area * 0.0001, 2) + " Ha";
                else lvLines.Items[0].SubItems[1].Text = "*";

                //inner metric
                for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                {
                    if (mf.bndArr[i].isSet)
                    {
                        lvLines.Items[i].SubItems[2].Text = mf.bndArr[i].isDriveThru.ToString();
                        lvLines.Items[i].SubItems[1].Text = Math.Round(mf.bndArr[i].area * 0.0001, 2) + " Ha";
                    }
                    else
                    {
                        lvLines.Items[i].SubItems[2].Text = "-";
                        lvLines.Items[i].SubItems[1].Text = "*";
                    }
                }
            }
            else
            {
                //outer
                lvLines.Items[0].SubItems[2].Text = "NA";
                if (mf.bndArr[0].isSet) lvLines.Items[0].SubItems[1].Text = Math.Round(mf.bndArr[0].area * 0.000247105, 2) + " Ac";
                else lvLines.Items[0].SubItems[1].Text = "*";

                //inner
                for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
                {
                    if (mf.bndArr[i].isSet)
                    {
                        lvLines.Items[i].SubItems[2].Text = mf.bndArr[i].isDriveThru.ToString();
                        lvLines.Items[i].SubItems[1].Text = Math.Round(mf.bndArr[i].area * 0.000247105, 2) + " Ac";
                    }
                    else
                    {
                        lvLines.Items[i].SubItems[2].Text = "-";
                        lvLines.Items[i].SubItems[1].Text = "*";
                    }
                }
            }
        }

        private void FormBoundary_Load(object sender, EventArgs e)
        {
            btnLeftRight.Image = Properties.Resources.BoundaryRight;
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnOpenGoogleEarth.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            cboxDriveThru.Visible = false;
            label2.Visible = false;

            //create a 6 row by 3 column ListView
            ListViewItem itm;
            const string line = "Outer,False,0.0";
            string[] words = line.Split(',');
            itm = new ListViewItem(words);
            lvLines.Items.Add(itm);
            for (int i = 1; i < FormGPS.MAXBOUNDARIES; i++)
            {
                words[0] = "Inner " + i.ToString();
                itm = new ListViewItem(words);
                lvLines.Items.Add(itm);
            }

            //update the list view with real data
            UpdateChart();
        }

        private void cboxSelectBoundary_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.bnd.boundarySelected = cboxSelectBoundary.SelectedIndex;

            if (mf.bnd.boundarySelected == 0)
            {
                if (mf.bndArr[0].isSet)
                {
                    btnOuter.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = false;
                    btnOpenGoogleEarth.Enabled = false;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnOuter.Enabled = true;
                    btnLoadBoundaryFromGE.Enabled = true;
                    btnOpenGoogleEarth.Enabled = true;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = false;
                    cboxSelectBoundary.Enabled = false;
                }
            }
            //must be an inner selected
            else if (mf.bndArr[0].isSet)
            {
                if (mf.bndArr[mf.bnd.boundarySelected].isSet)
                {
                    btnOuter.Enabled = false;
                    btnLoadBoundaryFromGE.Enabled = false;
                    btnOpenGoogleEarth.Enabled = false;
                    btnGo.Enabled = false;
                    btnDelete.Enabled = true;
                }
                else
                {
                    cboxSelectBoundary.Enabled = false;
                    cboxDriveThru.Visible = true;
                    label2.Visible = true;
                    btnDelete.Enabled = false;
                }
            }
            else
            {
                mf.TimedMessageBox(1000, "No Outer Boundary", "Create Outer Boundary First");
            }

            UpdateChart();
        }

        private void cboxDriveThru_SelectedIndexChanged(object sender, EventArgs e)
        {
            mf.bndArr[mf.bnd.boundarySelected].isDriveThru = cboxDriveThru.SelectedIndex != 0;
            cboxDriveThru.Visible = false;
            label2.Visible = false;
            btnOuter.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = true;
            btnOpenGoogleEarth.Enabled = true;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            UpdateChart();
        }

        private void btnOuter_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = true;
            btnLoadBoundaryFromGE.Enabled = false;
            btnOpenGoogleEarth.Enabled = false;
            btnOuter.Enabled = false;
            btnGo.Enabled = true;

            UpdateChart();
        }

        private void btnSerialCancel_Click(object sender, EventArgs e)
        {
            mf.bndArr[mf.bnd.boundarySelected].isOkToAddPoints = false;
        }

        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            mf.bndArr[mf.bnd.boundarySelected].isDrawRightSide = !mf.bndArr[mf.bnd.boundarySelected].isDrawRightSide;

            btnLeftRight.Image = mf.bndArr[mf.bnd.boundarySelected].isDrawRightSide ? Properties.Resources.BoundaryRight : Properties.Resources.BoundaryLeft;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnLeftRight.Enabled = false;
            btnOuter.Enabled = false;
            btnLoadBoundaryFromGE.Enabled = false;
            btnOpenGoogleEarth.Enabled = false;
            btnGo.Enabled = false;
            btnDelete.Enabled = false;
            cboxSelectBoundary.Enabled = true;
            {
                mf.bndArr[mf.bnd.boundarySelected].ResetBoundary();
                mf.FileSaveBoundary();
            }
            btnLeftRight.Image = Properties.Resources.BoundaryRight;
            UpdateChart();
        }

        private double easting, northing, latK, lonK;

        private void btnLoadBoundaryFromGE_Click(object sender, EventArgs e)
        {
            string fileAndDirectory;
            {
                //create the dialog instance
                OpenFileDialog ofd = new OpenFileDialog
                {
                    //set the filter to text KML only
                    Filter = "KML files (*.KML)|*.KML",

                    //the initial directory, fields, for the open dialog
                    InitialDirectory = mf.fieldsDirectory + mf.currentFieldDirectory
                };

                //was a file selected
                if (ofd.ShowDialog() == DialogResult.Cancel) return;
                else fileAndDirectory = ofd.FileName;
            }

            //start to read the file
            string line = null;
            int index;
            using (System.IO.StreamReader reader = new System.IO.StreamReader(fileAndDirectory))
            {
                bool done = false;
                try
                {
                    while (!reader.EndOfStream && !done)
                    {
                        line = reader.ReadLine();
                        index = line.IndexOf("coord");

                        if (index != -1)
                        {
                            line = reader.ReadLine();
                            line = line.Trim();
                            string[] numberSets = line.Split(' ');
                            done = true;

                            //at least 3 points
                            if (numberSets.Length > 2)
                            {
                                //reset boundary
                                mf.bndArr[mf.bnd.boundarySelected].ResetBoundary();
                                foreach (var item in numberSets)
                                {
                                    string[] fix = item.Split(',');
                                    double.TryParse(fix[0], NumberStyles.Float, CultureInfo.InvariantCulture, out lonK);
                                    double.TryParse(fix[1], NumberStyles.Float, CultureInfo.InvariantCulture, out latK);
                                    DecDeg2UTM(latK, lonK);
                                    CBndPt bndPt = new CBndPt(easting, northing, 0);
                                    mf.bndArr[mf.bnd.boundarySelected].bndLine.Add(bndPt);
                                }

                                //fix the points if there are gaps bigger then
                                mf.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                                mf.bndArr[mf.bnd.boundarySelected].FixBoundaryLine(mf.bnd.boundarySelected);

                                ////make sure distance isn't too small between points on headland
                                //int headCount = mf.bndArr[mf.bnd.boundarySelected].bndLine.Count;
                                ////double spacing = mf.vehicle.toolWidth * 0.25;
                                //const double spacing = 3.0;
                                //double distance;
                                //for (int i = 0; i < headCount - 1; i++)
                                //{
                                //    distance = glm.Distance(mf.bndArr[mf.bnd.boundarySelected].bndLine[i], mf.bndArr[mf.bnd.boundarySelected].bndLine[i + 1]);
                                //    if (distance < spacing)
                                //    {
                                //        mf.bndArr[mf.bnd.boundarySelected].bndLine.RemoveAt(i + 1);
                                //        headCount = mf.bndArr[mf.bnd.boundarySelected].bndLine.Count;
                                //        i = 0;
                                //    }
                                //}

                                ////make sure distance isn't too big between points on headland
                                //headCount = mf.bndArr[mf.bnd.boundarySelected].bndLine.Count;
                                //for (int i = 0; i < headCount; i++)
                                //{
                                //    int j = i + 1;
                                //    if (j == headCount) j = 0;
                                //    distance = glm.Distance(mf.bndArr[mf.bnd.boundarySelected].bndLine[i], mf.bndArr[mf.bnd.boundarySelected].bndLine[j]);
                                //    if (distance > (spacing * 1.333))
                                //    {
                                //        CBndPt point = new CBndPt((mf.bndArr[mf.bnd.boundarySelected].bndLine[i].easting + mf.bndArr[mf.bnd.boundarySelected].bndLine[j].easting) / 2.0,
                                //        (mf.bndArr[mf.bnd.boundarySelected].bndLine[i].northing + mf.bndArr[mf.bnd.boundarySelected].bndLine[j].northing) / 2.0,
                                //         mf.bndArr[mf.bnd.boundarySelected].bndLine[i].heading);

                                //        mf.bndArr[mf.bnd.boundarySelected].bndLine.Insert(j, point);
                                //        headCount = mf.bndArr[mf.bnd.boundarySelected].bndLine.Count;
                                //        i = 0;
                                //    }
                                //}

                                ////Google earth doesn't have headings so need to calc them
                                //mf.bndArr[mf.bnd.boundarySelected].CalculateBoundaryHeadings();

                                //boundary area, pre calcs etc
                                mf.bndArr[mf.bnd.boundarySelected].CalculateBoundaryArea();
                                mf.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                                mf.bndArr[mf.bnd.boundarySelected].isSet = true;
                                for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++)
                                {
                                    mf.FileSaveBoundary();
                                }
                                Close();
                            }
                            else
                            {
                                mf.TimedMessageBox(2000, "Error reading KML", "Choose or Build a Different one");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private const double sm_a = 6378137.0;
        private const double sm_b = 6356752.314;
        private const double UTMScaleFactor = 0.9996;

        public void DecDeg2UTM(double latitude, double longitude)
        {
            //zone = Math.Floor((longitude + 180.0) * 0.16666666666666666666666666666667) + 1;
            GeoUTMConverterXY(latitude * 0.01745329251994329576923690766743,
                                longitude * 0.01745329251994329576923690766743);
        }

        private void btnOpenGoogleEarth_Click(object sender, EventArgs e)
        {
            //save new copy of kml with selected flag and view in GoogleEarth
            mf.FileMakeCurrentKML(mf.pn.latitude, mf.pn.longitude);
            System.Diagnostics.Process.Start(mf.fieldsDirectory + mf.currentFieldDirectory + "\\CurrentPosition.KML");
        }

        private double ArcLengthOfMeridian(double phi)
        {
            const double n = (sm_a - sm_b) / (sm_a + sm_b);
            double alpha = ((sm_a + sm_b) / 2.0) * (1.0 + (Math.Pow(n, 2.0) / 4.0) + (Math.Pow(n, 4.0) / 64.0));
            double beta = (-3.0 * n / 2.0) + (9.0 * Math.Pow(n, 3.0) * 0.0625) + (-3.0 * Math.Pow(n, 5.0) / 32.0);
            double gamma = (15.0 * Math.Pow(n, 2.0) * 0.0625) + (-15.0 * Math.Pow(n, 4.0) / 32.0);
            double delta = (-35.0 * Math.Pow(n, 3.0) / 48.0) + (105.0 * Math.Pow(n, 5.0) / 256.0);
            double epsilon = (315.0 * Math.Pow(n, 4.0) / 512.0);
            return alpha * (phi + (beta * Math.Sin(2.0 * phi))
                    + (gamma * Math.Sin(4.0 * phi))
                    + (delta * Math.Sin(6.0 * phi))
                    + (epsilon * Math.Sin(8.0 * phi)));
        }

        private double[] MapLatLonToXY(double phi, double lambda, double lambda0)
        {
            double[] xy = new double[2];
            double ep2 = (Math.Pow(sm_a, 2.0) - Math.Pow(sm_b, 2.0)) / Math.Pow(sm_b, 2.0);
            double nu2 = ep2 * Math.Pow(Math.Cos(phi), 2.0);
            double n = Math.Pow(sm_a, 2.0) / (sm_b * Math.Sqrt(1 + nu2));
            double t = Math.Tan(phi);
            double t2 = t * t;
            double l = lambda - lambda0;
            double l3Coef = 1.0 - t2 + nu2;
            double l4Coef = 5.0 - t2 + (9 * nu2) + (4.0 * (nu2 * nu2));
            double l5Coef = 5.0 - (18.0 * t2) + (t2 * t2) + (14.0 * nu2) - (58.0 * t2 * nu2);
            double l6Coef = 61.0 - (58.0 * t2) + (t2 * t2) + (270.0 * nu2) - (330.0 * t2 * nu2);
            double l7Coef = 61.0 - (479.0 * t2) + (179.0 * (t2 * t2)) - (t2 * t2 * t2);
            double l8Coef = 1385.0 - (3111.0 * t2) + (543.0 * (t2 * t2)) - (t2 * t2 * t2);

            /* Calculate easting (x) */
            xy[0] = (n * Math.Cos(phi) * l)
                + (n / 6.0 * Math.Pow(Math.Cos(phi), 3.0) * l3Coef * Math.Pow(l, 3.0))
                + (n / 120.0 * Math.Pow(Math.Cos(phi), 5.0) * l5Coef * Math.Pow(l, 5.0))
                + (n / 5040.0 * Math.Pow(Math.Cos(phi), 7.0) * l7Coef * Math.Pow(l, 7.0));

            /* Calculate northing (y) */
            xy[1] = ArcLengthOfMeridian(phi)
                + (t / 2.0 * n * Math.Pow(Math.Cos(phi), 2.0) * Math.Pow(l, 2.0))
                + (t / 24.0 * n * Math.Pow(Math.Cos(phi), 4.0) * l4Coef * Math.Pow(l, 4.0))
                + (t / 720.0 * n * Math.Pow(Math.Cos(phi), 6.0) * l6Coef * Math.Pow(l, 6.0))
                + (t / 40320.0 * n * Math.Pow(Math.Cos(phi), 8.0) * l8Coef * Math.Pow(l, 8.0));

            return xy;
        }

        private void GeoUTMConverterXY(double lat, double lon)
        {
            double[] xy = MapLatLonToXY(lat, lon, (-183.0 + (mf.pn.zone * 6.0)) * 0.01745329251994329576923690766743);

            xy[0] = (xy[0] * UTMScaleFactor) + 500000.0;
            xy[1] *= UTMScaleFactor;
            if (xy[1] < 0.0)
                xy[1] += 10000000.0;

            //keep a copy of actual easting and northings
            //actualEasting = xy[0];
            //actualNorthing = xy[1];

            //if a field is open, the real one is subtracted from the integer
            easting = xy[0] - mf.pn.utmEast;
            northing = xy[1] - mf.pn.utmNorth;
        }
    }
}