using System;
using System.Windows.Forms;

namespace AgOpenGPS
{
    public partial class FormBoundaryPlayer : Form
    {
        //properties
        private readonly FormGPS mf = null;

        //constructor
        public FormBoundaryPlayer(Form callingForm)
        {
            mf = callingForm as FormGPS;
            InitializeComponent();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (mf.bndArr[mf.bnd.boundarySelected].bndLine.Count > 5)
            {
                mf.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bndArr[mf.bnd.boundarySelected].FixBoundaryLine(mf.bnd.boundarySelected);
                mf.bndArr[mf.bnd.boundarySelected].PreCalcBoundaryLines();
                mf.bndArr[mf.bnd.boundarySelected].isSet = true;
            }
            else
            {
                mf.bndArr[mf.bnd.boundarySelected].calcList.Clear();
                mf.bndArr[mf.bnd.boundarySelected].bndLine.Clear();
                mf.bndArr[mf.bnd.boundarySelected].area = 0;
                mf.bndArr[mf.bnd.boundarySelected].isSet = false;
            }

            mf.FileSaveBoundary();

            //stop it all for adding
            for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++) mf.bndArr[i].isOkToAddPoints = false;

            //close window
            Close();
        }

        //actually the record button
        private void btnPausePlay_Click(object sender, EventArgs e)
        {
         if (mf.bndArr[mf.bnd.boundarySelected].isOkToAddPoints)
            {
                for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++) mf.bndArr[i].isOkToAddPoints = false;
                btnPausePlay.Image = Properties.Resources.BoundaryRecord;
                btnPausePlay.Text = "Record";
            }
            else
            {
                mf.bndArr[mf.bnd.boundarySelected].isOkToAddPoints = true;
                btnPausePlay.Image = Properties.Resources.boundaryPause;
                btnPausePlay.Text = "Pause";
            }
        }

        private void FormBoundaryPlayer_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < FormGPS.MAXBOUNDARIES; i++) mf.bndArr[i].isOkToAddPoints = false;
            btnPausePlay.Image = Properties.Resources.BoundaryRecord;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                mf.bndArr[mf.bnd.boundarySelected].CalculateBoundaryArea();

                if (mf.isMetric)
                {
                    lblArea.Text = Math.Round(mf.bndArr[mf.bnd.boundarySelected].area * 0.0001, 2) + " Ha";
                }
                else
                {
                    lblArea.Text = Math.Round(mf.bndArr[mf.bnd.boundarySelected].area * 0.000247105, 2) + " Acre";
                }
            }
        }
    }
}