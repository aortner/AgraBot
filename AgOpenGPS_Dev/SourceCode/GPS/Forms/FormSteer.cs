using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgOpenGPS
{
    public partial class FormSteer : Form
    {
        private readonly FormGPS mf = null;
        private string[] words;

        //chart data
        private string dataSteerAngle = "0";

        //private string dataP = "4";
        //private string dataI = "6";
        //private string dataD = "-6";
        private string dataPWM = "-10";

        //the trackbar angle for free drive
        private Int16 driveFreeSteerAngle = 0;

        //Form stuff
        public FormSteer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void FormSteer_Load(object sender, EventArgs e)
        {
            //btnPMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKp].ToString();
            //btnIMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKi].ToString();
            //btnDMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKd].ToString();
            //btnOMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssKo].ToString();

            hsbarSteerAngleSensorZero.Value = Properties.Settings.Default.setAS_steerAngleOffset - 127;
            lblSteerAngleSensorZero.Text = hsbarSteerAngleSensorZero.Value.ToString();

            hsbarCountsPerDegree.Value = Properties.Settings.Default.setAS_countsPerDegree;
            lblCountsPerDegree.Text = hsbarCountsPerDegree.Value.ToString();

            hsbarMinPWM.Value = Properties.Settings.Default.setAS_minSteerPWM;
            lblMinPWM.Text = hsbarMinPWM.Value.ToString();

            hsbarProportionalGain.Value = Properties.Settings.Default.setAS_Kp;
            lblProportionalGain.Text = hsbarProportionalGain.Value.ToString();

            hsbarOutputGain.Value = Properties.Settings.Default.setAS_Ko;
            lblOutputGain.Text = hsbarOutputGain.Value.ToString();

            hsbarSidehillDraftGain.Value = Properties.Settings.Default.setAS_Kd;
            lblSidehillDraftGain.Text = hsbarSidehillDraftGain.Value.ToString();

            hsbarIntegralGain.Value = Properties.Settings.Default.setAS_Ki;
            lblIntegralGain.Text = hsbarIntegralGain.Value.ToString();

            hsbarIntegralMax.Value = Properties.Settings.Default.setAS_maxIntegral;
            lblIntegralMax.Text = hsbarIntegralMax.Value.ToString();

            mf.vehicle.maxSteerAngle = Properties.Vehicle.Default.setVehicle_maxSteerAngle;
            hsbarMaxSteerAngle.Value = (Int16)mf.vehicle.maxSteerAngle;
            lblMaxSteerAngle.Text = hsbarMaxSteerAngle.Value.ToString();

            mf.vehicle.goalPointLookAhead = Properties.Vehicle.Default.setVehicle_goalPointLookAhead;
            hsbarLookAhead.Value = (Int16)mf.vehicle.goalPointLookAhead;
            lblLookAhead.Text = hsbarLookAhead.Value.ToString();

            mf.vehicle.maxAngularVelocity = Properties.Vehicle.Default.setVehicle_maxAngularVelocity;
            hsbarMaxAngularVelocity.Value = (Int16)mf.vehicle.maxAngularVelocity;
            lblMaxAngularVelocity.Text = hsbarMaxAngularVelocity.Value.ToString();

            //make sure free drive is off
            btnFreeDrive.BackColor = Color.Red;
            mf.ast.isInFreeDriveMode = false;
            btnFreeDriveZero.Enabled = false;
            hSBarFreeDrive.Enabled = false;
            hSBarFreeDrive.Value = 0;
            driveFreeSteerAngle = 0;
            lblFreeDriveAngle.Text = "0";
        }

        private void FormSteer_FormClosing(object sender, FormClosingEventArgs e)
        {
            mf.ast.isInFreeDriveMode = false;
        }

        //Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!mf.ast.isInFreeDriveMode)
            {
                //normal mode
                tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
                tboxSerialToAutoSteer.Text = mf.mc.autoSteerData[mf.mc.sdRelayLo] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                        + ", " + mf.guidanceLineDistanceOff + ", " + mf.guidanceLineSteerAngle;
            }
            else
            {
                //free drive mode
                mf.mc.autoSteerData[mf.mc.sdSteerAngleHi] = (byte)((driveFreeSteerAngle * 100) >> 8);
                mf.mc.autoSteerData[mf.mc.sdSteerAngleLo] = (byte)(driveFreeSteerAngle * 100);

                tboxSerialFromAutoSteer.Text = mf.mc.serialRecvAutoSteerStr;
                tboxSerialToAutoSteer.Text = mf.mc.autoSteerData[mf.mc.sdRelayLo] + ", " + mf.mc.autoSteerData[mf.mc.sdSpeed]
                                        + ", " + mf.mc.autoSteerData[mf.mc.sdDistanceLo] + ", " + (driveFreeSteerAngle * 100);
            }

            DrawChart();
        }

        //Scrollbars
        private void hsbarCountsPerDegree_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree] = (byte)hsbarCountsPerDegree.Value;
            lblCountsPerDegree.Text = (mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]).ToString();
            Properties.Settings.Default.setAS_countsPerDegree = mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarMaxSteerAngle_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.maxSteerAngle = hsbarMaxSteerAngle.Value;
            lblMaxSteerAngle.Text = hsbarMaxSteerAngle.Value.ToString();
            Properties.Vehicle.Default.setVehicle_maxSteerAngle = mf.vehicle.maxSteerAngle;
            Properties.Vehicle.Default.Save();
        }

        private void hsbarSteerAngleSensorZero_ValueChanged(object sender, EventArgs e)
        {
            lblSteerAngleSensorZero.Text = hsbarSteerAngleSensorZero.Value.ToString();
            mf.mc.autoSteerSettings[mf.mc.ssSteerOffset] = (byte)(127 + hsbarSteerAngleSensorZero.Value);
            Properties.Settings.Default.setAS_steerAngleOffset = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarMinPWM_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssMinPWM] = (byte)hsbarMinPWM.Value;
            lblMinPWM.Text = (mf.mc.autoSteerSettings[mf.mc.ssMinPWM]).ToString();
            Properties.Settings.Default.setAS_minSteerPWM = mf.mc.autoSteerSettings[mf.mc.ssMinPWM];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarProportionalGain_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKp] = (byte)hsbarProportionalGain.Value;
            lblProportionalGain.Text = (mf.mc.autoSteerSettings[mf.mc.ssKp]).ToString();
            Properties.Settings.Default.setAS_Kp = mf.mc.autoSteerSettings[mf.mc.ssKp];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarOutputGain_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKo] = (byte)hsbarOutputGain.Value;
            lblOutputGain.Text = (mf.mc.autoSteerSettings[mf.mc.ssKo]).ToString();
            Properties.Settings.Default.setAS_Ko = mf.mc.autoSteerSettings[mf.mc.ssKo];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarSidehillDraftGain_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKd] = (byte)hsbarSidehillDraftGain.Value;
            lblSidehillDraftGain.Text = (mf.mc.autoSteerSettings[mf.mc.ssKd]).ToString();
            Properties.Settings.Default.setAS_Kd = mf.mc.autoSteerSettings[mf.mc.ssKd];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarIntegralGain_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssKi] = (byte)hsbarIntegralGain.Value;
            lblIntegralGain.Text = (mf.mc.autoSteerSettings[mf.mc.ssKi]).ToString();
            Properties.Settings.Default.setAS_Ki = mf.mc.autoSteerSettings[mf.mc.ssKi];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarIntegralMax_ValueChanged(object sender, EventArgs e)
        {
            mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral] = (byte)hsbarIntegralMax.Value;
            lblIntegralMax.Text = (mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral]).ToString();
            Properties.Settings.Default.setAS_maxIntegral = mf.mc.autoSteerSettings[mf.mc.ssMaxIntegral];
            Properties.Settings.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarMaxAngularVelocity_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.maxAngularVelocity = (byte)hsbarMaxAngularVelocity.Value;
            lblMaxAngularVelocity.Text = mf.vehicle.maxAngularVelocity.ToString();
            Properties.Vehicle.Default.setVehicle_maxAngularVelocity = mf.vehicle.maxAngularVelocity;
            Properties.Vehicle.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        private void hsbarLookAhead_ValueChanged(object sender, EventArgs e)
        {
            mf.vehicle.goalPointLookAhead = (byte)hsbarLookAhead.Value;
            lblLookAhead.Text = mf.vehicle.goalPointLookAhead.ToString();
            Properties.Vehicle.Default.setVehicle_goalPointLookAhead = mf.vehicle.goalPointLookAhead;
            Properties.Vehicle.Default.Save();
            mf.AutoSteerSettingsOutToPort();
        }

        //FREE DRIVE SECTION
        private void btnSteerWizard_Click(object sender, EventArgs e)
        {
            if (mf.isJobStarted)
            {
                var form = new FormTimedMessage(3000, gStr.gsFieldIsOpen, gStr.gsCloseFieldFirst);
                form.Show();
                return;
            }

            WindowState = FormWindowState.Minimized;
            Hide();

            using (var form = new FormWizardSteer(mf))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //lblCountsPerDegree.Text = (mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]).ToString();
                    //btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
                    //mf.AutoSteerSettingsOutToPort();
                }
                else
                {
                    //btnCountsPerDegreeMinus.Text = (mf.mc.autoSteerSettings[mf.mc.ssCountsPerDegree]).ToString();
                    //btnSteerMinus.Text = mf.mc.autoSteerSettings[mf.mc.ssSteerOffset].ToString();
                    //mf.AutoSteerSettingsOutToPort();
                }
            }

            //restore the autosteer window
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void hSBarFreeDrive_ValueChanged(object sender, EventArgs e)
        {
            driveFreeSteerAngle = (Int16)hSBarFreeDrive.Value;
            lblFreeDriveAngle.Text = Convert.ToString(driveFreeSteerAngle);
        }

        private void btnFreeDrive_Click(object sender, EventArgs e)
        {
            if (mf.ast.isInFreeDriveMode)
            {
                //turn OFF free drive mode
                btnFreeDrive.BackColor = Color.Red;
                mf.ast.isInFreeDriveMode = false;
                btnFreeDriveZero.Enabled = false;
                hSBarFreeDrive.Enabled = false;
                hSBarFreeDrive.Value = 0;
                driveFreeSteerAngle = 0;
                lblFreeDriveAngle.Text = "0";
            }
            else
            {
                //turn ON free drive mode
                btnFreeDrive.BackColor = Color.LimeGreen;
                mf.ast.isInFreeDriveMode = true;
                btnFreeDriveZero.Enabled = true;
                hSBarFreeDrive.Enabled = true;
                hSBarFreeDrive.Value = 0;
                driveFreeSteerAngle = 0;
                lblFreeDriveAngle.Text = "0";
            }
        }

        private void btnFreeDriveZero_Click(object sender, EventArgs e)
        {
            driveFreeSteerAngle = 0;
            hSBarFreeDrive.Value = driveFreeSteerAngle;
            lblFreeDriveAngle.Text = Convert.ToString(driveFreeSteerAngle);
        }

        //chart
        private void DrawChart()
        {
            //just data
            words = mf.mc.serialRecvAutoSteerStr.Split(',');
            if (words.Length < 5)
            {
                dataSteerAngle = "0";
                //dataP = "1";
                //dataI = "2";
                //dataD = "-1";
                dataPWM = "-2";
            }
            else
            {
                //word 0 - steerangle, 1 - pwmDisplay
                dataSteerAngle = mf.mc.serialRecvAutoSteerStr.Split(',')[0];
                //dataP = mf.mc.serialRecvAutoSteerStr.Split(',')[1];
                //dataI = mf.mc.serialRecvAutoSteerStr.Split(',')[2];
                //dataD = mf.mc.serialRecvAutoSteerStr.Split(',')[3];
                dataPWM = mf.mc.serialRecvAutoSteerStr.Split(',')[1];

                lblSteerAng.Text = dataSteerAngle;
                //lblP.Text = dataP;
                //lblI.Text = dataI;
                //lblD.Text = dataD;
                lblPWM.Text = dataPWM;
            }

            //chart data
            Series s = unoChart.Series["S"];
            //Series t = unoChart.Series["P"];
            //Series u = unoChart.Series["I"];
            //Series v = unoChart.Series["D"];
            Series w = unoChart.Series["PWM"];
            double nextX = 1;
            //double nextX2 = 1;
            //double nextX3 = 1;
            //double nextX4 = 1;
            double nextX5 = 1;

            if (s.Points.Count > 0) nextX = s.Points[s.Points.Count - 1].XValue + 1;
            //if (t.Points.Count > 0) nextX2 = t.Points[t.Points.Count - 1].XValue + 1;
            //if (u.Points.Count > 0) nextX3 = u.Points[u.Points.Count - 1].XValue + 1;
            //if (v.Points.Count > 0) nextX4 = u.Points[u.Points.Count - 1].XValue + 1;
            if (w.Points.Count > 0) nextX5 = w.Points[w.Points.Count - 1].XValue + 1;

            unoChart.Series["S"].Points.AddXY(nextX, dataSteerAngle);
            //unoChart.Series["P"].Points.AddXY(nextX2, dataP);
            //unoChart.Series["I"].Points.AddXY(nextX3, dataI);
            //unoChart.Series["D"].Points.AddXY(nextX4, dataD);
            unoChart.Series["PWM"].Points.AddXY(nextX5, dataPWM);

            //if (isScroll)
            {
                while (s.Points.Count > 100)
                {
                    s.Points.RemoveAt(0);
                }
                //while (t.Points.Count > 100)
                //{
                //    t.Points.RemoveAt(0);
                //}
                //while (u.Points.Count > 100)
                //{
                //    u.Points.RemoveAt(0);
                //}
                //while (v.Points.Count > 100)
                //{
                //    v.Points.RemoveAt(0);
                //}
                while (w.Points.Count > 100)
                {
                    w.Points.RemoveAt(0);
                }
                unoChart.ResetAutoValues();
            }
        }

        //private void btnAuto_Click(object sender, EventArgs e)
        //{
        //    unoChart.ChartAreas[0].AxisY.Maximum = Double.NaN;
        //    unoChart.ChartAreas[0].RecalculateAxesScale();
        //    unoChart.ResetAutoValues();
        //}

        //private void btnPlus_Click(object sender, EventArgs e)
        //{
        //    if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
        //        unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
        //    else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;
        //    unoChart.ChartAreas[0].AxisY.Minimum -= 50;
        //    unoChart.ChartAreas[0].AxisY.Maximum += 50;
        //    unoChart.ResetAutoValues();
        //}

        //private void btnMinus_Click(object sender, EventArgs e)
        //{
        //    if (Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum) > Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum))
        //        unoChart.ChartAreas[0].AxisY.Maximum = Math.Abs(unoChart.ChartAreas[0].AxisY.Minimum);
        //    else unoChart.ChartAreas[0].AxisY.Minimum = Math.Abs(unoChart.ChartAreas[0].AxisY.Maximum) * -1;

        //    if (unoChart.ChartAreas[0].AxisY.Maximum <= 51)
        //    {
        //        unoChart.ChartAreas[0].AxisY.Maximum = 60;
        //        unoChart.ChartAreas[0].AxisY.Minimum = -60;
        //    }
        //    unoChart.ChartAreas[0].AxisY.Minimum += 50;
        //    unoChart.ChartAreas[0].AxisY.Maximum -= 50;
        //    unoChart.ResetAutoValues();
        //}
    }
}