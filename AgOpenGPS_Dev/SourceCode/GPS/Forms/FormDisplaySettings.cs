using System;
using System.Linq;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormDisplaySettings : Form
    {
        private readonly FormGPS mf = null;

        private decimal triResolution, minFixStepDistance, boundaryDistance;
        private int lightbarCmPerPixie;
        private bool isHeadingBNO, isHeadingBrick, isHeadingPAOGI, isRollDogs, isRollBrick, isRollPAOGI;
        private string headingFromWhichSource;


        public FormDisplaySettings(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        #region EntryExit

        private void FormDisplaySettings_Load(object sender, EventArgs e)
        {
            triResolution = (decimal)Properties.Settings.Default.setDisplay_triangleResolution;
            if (nudTriangleResolution.CheckValue(ref triResolution)) nudTriangleResolution.BackColor = System.Drawing.Color.OrangeRed;
            nudTriangleResolution.Value = triResolution;

            boundaryDistance = (decimal)Properties.Settings.Default.setF_boundaryTriggerDistance;
            if (nudBoundaryDistance.CheckValue(ref boundaryDistance)) nudBoundaryDistance.BackColor = System.Drawing.Color.OrangeRed;
            nudBoundaryDistance.Value = boundaryDistance;

            minFixStepDistance = (decimal)Properties.Settings.Default.setF_minFixStep;
            if (nudMinFixStepDistance.CheckValue(ref minFixStepDistance)) nudMinFixStepDistance.BackColor = System.Drawing.Color.OrangeRed;
            nudMinFixStepDistance.Value = minFixStepDistance;

            nudLightbarCmPerPixel.Value = (Properties.Settings.Default.setDisplay_lightbarCmPerPixel);

            tboxTinkerUID.Text = Properties.Settings.Default.setIMU_UID;
            maxlookahedtext.Value = (decimal)Properties.Settings.Default.speedmaxlookahead;
            minlookahedtext.Value = (decimal)Properties.Settings.Default.speedminlookahead;
            numericUpDown_xtefilterfactor.Value = (int)Properties.Settings.Default.xtefilter;
            lookaheadortner.Value = (int)Properties.Settings.Default.minuslookahedortner;

          
            checkBox_XTEFilter.Checked = Properties.Settings.Default.is_xte;

            cboxHeadingBNO.Checked = Properties.Settings.Default.setIMU_isHeadingFromBNO;
            cboxHeadingBrick.Checked = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            cboxRollDogs.Checked = Properties.Settings.Default.setIMU_isRollFromDogs;
            cboxHeadingPAOGI.Checked = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            cboxRollPAOGI.Checked = Properties.Settings.Default.setIMU_isRollFromPAOGI;
            radioButtonOrtner.Checked = mf.ABLine.iscabortner;
            radioButtonSchelter.Checked = mf.ABLine.iscabschelter;
            radioButtonspeedlookahed.Checked = mf.ABLine.iscabspeed;

    
            isHeadingBNO = Properties.Settings.Default.setIMU_isHeadingFromBNO;
            isHeadingBrick = Properties.Settings.Default.setIMU_isHeadingFromBrick;
            isRollDogs = Properties.Settings.Default.setIMU_isRollFromDogs;
            isRollBrick = Properties.Settings.Default.setIMU_isRollFromBrick;
            isHeadingPAOGI = Properties.Settings.Default.setIMU_isHeadingFromPAOGI;
            isRollPAOGI = Properties.Settings.Default.setIMU_isRollFromPAOGI;

            lblRollZeroOffset.Text = ((double)Properties.Settings.Default.setIMU_rollZero / 16).ToString("N2");

            headingFromWhichSource = Properties.Settings.Default.setGPS_headingFromWhichSource;
            if (headingFromWhichSource == "Fix") rbtnHeadingFix.Checked = true;
            else if (headingFromWhichSource == "GPS") rbtnHeadingGPS.Checked = true;
            else if (headingFromWhichSource == "HDT") rbtnHeadingHDT.Checked = true;

        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            ////Display ---load the delay slides --------------------------------------------------------------------
            if (headingFromWhichSource == "Fix") Properties.Settings.Default.setGPS_headingFromWhichSource = "Fix";
            else if (headingFromWhichSource == "GPS") Properties.Settings.Default.setGPS_headingFromWhichSource = "GPS";
            else if (headingFromWhichSource == "HDT") Properties.Settings.Default.setGPS_headingFromWhichSource = "HDT";
            mf.headingFromSource = headingFromWhichSource;

            mf.boundaryTriggerDistance = (double)boundaryDistance;
            Properties.Settings.Default.setF_boundaryTriggerDistance = mf.boundaryTriggerDistance;

            mf.camera.triangleResolution = (double)triResolution;
            Properties.Settings.Default.setDisplay_triangleResolution = mf.camera.triangleResolution;

            mf.minFixStepDist = (double)minFixStepDistance;
            Properties.Settings.Default.setF_minFixStep = mf.minFixStepDist;

            Properties.Settings.Default.setIMU_UID = tboxTinkerUID.Text.Trim();

            Properties.Settings.Default.setIMU_isHeadingFromBNO = isHeadingBNO;
            Properties.Settings.Default.setIMU_isHeadingFromBrick = isHeadingBrick;
            Properties.Settings.Default.setIMU_isRollFromDogs = isRollDogs;
            mf.ahrs.isRollDogs = isRollDogs;
            Properties.Settings.Default.setIMU_isRollFromBrick = isRollBrick;
            mf.ahrs.isRollBrick = isRollBrick;
            Properties.Settings.Default.setIMU_isRollFromPAOGI = isRollPAOGI;
            Properties.Settings.Default.setIMU_isHeadingFromPAOGI = isHeadingPAOGI;
            mf.ABLine.speedmaxlahead = (double)maxlookahedtext.Value;
            mf.ABLine.speedminlahead = (double)minlookahedtext.Value;
            Properties.Settings.Default.speedmaxlookahead = (double)maxlookahedtext.Value;

            Properties.Settings.Default.speedminlookahead = (double)minlookahedtext.Value;
            Properties.Settings.Default.xtefilter = (int)numericUpDown_xtefilterfactor.Value;
           

          
            Properties.Settings.Default.is_xte = checkBox_XTEFilter.Checked;




            Properties.Settings.Default.setDisplay_lightbarCmPerPixel = lightbarCmPerPixie;
            mf.lightbarCmPerPixel = lightbarCmPerPixie;

            Properties.Settings.Default.Save();
            Properties.Vehicle.Default.Save();

            //back to FormGPS
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            { DialogResult = DialogResult.Cancel; Close(); }
        }

        #endregion EntryExit

        #region DisplayCalcs

        private void nudMinFixStepDistance_ValueChanged(object sender, EventArgs e)
        {
            minFixStepDistance = nudMinFixStepDistance.Value;
        }

        private void nudTriangleResolution_ValueChanged(object sender, EventArgs e)
        {
            triResolution = nudTriangleResolution.Value;
        }

        private void nudLightbarCmPerPixel_ValueChanged(object sender, EventArgs e)
        {
            lightbarCmPerPixie = (int)nudLightbarCmPerPixel.Value;
        }

        private void nudBoundaryDistance_ValueChanged(object sender, EventArgs e)
        {
            boundaryDistance = nudBoundaryDistance.Value;
        }

        #endregion DisplayCalcs

        private void rbtnHeadingFix_CheckedChanged(object sender, EventArgs e)
        {
            var checkedButton = headingGroupBox.Controls.OfType<RadioButton>()
                          .FirstOrDefault(r => r.Checked);
            headingFromWhichSource = checkedButton.Text;
        }

        private void cboxRollDogs_CheckedChanged(object sender, EventArgs e)
        {
            isRollDogs = cboxRollDogs.Checked;
            if (isRollDogs)
            {
                isRollBrick = false;
                cboxRollPAOGI.Checked = false;
                isRollPAOGI = false;
            }
        }

        private void cboxRollPAOGI_CheckedChanged(object sender, EventArgs e)
        {
            isRollPAOGI = cboxRollPAOGI.Checked;
            if (isRollPAOGI)
            {
                cboxRollDogs.Checked = false;
                isRollDogs = false;
                isRollBrick = false;
            }
        }

        private void tboxTinkerUID_TextChanged(object sender, EventArgs e)
        {

        }

        private void minlookahedtext_ValueChanged(object sender, EventArgs e)
        {
        }

        private void maxlookahedtext_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Brian_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void headingGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void Brian_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void Brian_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            mf.ABLine.iscabortner = true;
            mf.ABLine.iscabschelter = false;
            
            mf.ABLine.iscabspeed = false;

        }

        private void radioButtonSchelter_CheckedChanged(object sender, EventArgs e)
        {
            mf.ABLine.iscabortner = false;
            mf.ABLine.iscabschelter = true;
           ;
            mf.ABLine.iscabspeed = false;

        }

        

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            mf.ABLine.iscabortner = false;
            mf.ABLine.iscabschelter = false;
         
            mf.ABLine.iscabspeed = false;
        }

        private void radioButtonspeedlookahed_CheckedChanged(object sender, EventArgs e)
        {
            mf.ABLine.iscabortner = false;
            mf.ABLine.iscabschelter = false;
          
            mf.ABLine.iscabspeed = true;
        }

        private void Test(object sender, PopupEventArgs e)
        {

        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {

        }

               

        private void checkBox_XTEFilter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.is_xte = checkBox_XTEFilter.Checked;
        }

        private void numericUpDown_XTE_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.xtefilter = (int)numericUpDown_xtefilterfactor.Value;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void toolTip4_Popup(object sender, PopupEventArgs e)
        {

        }

        private void lookaheadortner_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.minuslookahedortner = (int)lookaheadortner.Value;
        }

        private void cboxHeadingBNO_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingBNO = cboxHeadingBNO.Checked;
            if (isHeadingBNO)
            {
                cboxHeadingBrick.Checked = false;
                isHeadingBrick = false;
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
            }
        }

        private void cboxHeadingBrick_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingBrick = cboxHeadingBrick.Checked;
            if (isHeadingBrick)
            {
                cboxHeadingBNO.Checked = false;
                isHeadingBNO = false;
                cboxHeadingPAOGI.Checked = false;
                isHeadingPAOGI = false;
            }
        }

        private void cboxHeadingPAOGI_CheckedChanged(object sender, EventArgs e)
        {
            isHeadingPAOGI = cboxHeadingPAOGI.Checked;
            if (isHeadingPAOGI)
            {
                cboxHeadingBNO.Checked = false;
                isHeadingBNO = false;
                cboxHeadingBrick.Checked = false;
                isHeadingBrick = false;
            }
        }

        private void btnRemoveZeroOffset_Click(object sender, EventArgs e)
        {
            mf.ahrs.rollZero = 0;
            lblRollZeroOffset.Text = "0.00";
            Properties.Settings.Default.setIMU_rollZero = 0;
            Properties.Settings.Default.Save();
        }

        private void btnZeroRoll_Click(object sender, EventArgs e)
        {
            if (mf.mc.rollRaw == 9999)
            {
                lblRollZeroOffset.Text = "***";
            }
            else
            {
                mf.ahrs.rollZero = mf.mc.rollRaw;
                lblRollZeroOffset.Text = ((double)mf.ahrs.rollZero / 16).ToString("N2");
                Properties.Settings.Default.setIMU_rollZero = mf.mc.rollRaw;
                Properties.Settings.Default.Save();
            }
        }

        private void btnRemoveZeroOffsetPitch_Click(object sender, EventArgs e)
        {
        }

        private void btnZeroPitch_Click(object sender, EventArgs e)
        {
        }
    }
}