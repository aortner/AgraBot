namespace AgOpenGPS
{
    partial class FormDisplaySettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bntOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDisplay = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudLightbarCmPerPixel = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.nudBoundaryDistance = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudTriangleResolution = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.nudMinFixStepDistance = new System.Windows.Forms.NumericUpDown();
            this.tabIMU = new System.Windows.Forms.TabPage();
            this.headingGroupBox = new System.Windows.Forms.GroupBox();
            this.rbtnHeadingHDT = new System.Windows.Forms.RadioButton();
            this.rbtnHeadingGPS = new System.Windows.Forms.RadioButton();
            this.rbtnHeadingFix = new System.Windows.Forms.RadioButton();
            this.btnRollZero = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRemoveZeroOffsetPitch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnZeroPitch = new System.Windows.Forms.Button();
            this.btnRemoveZeroOffset = new System.Windows.Forms.Button();
            this.lblRollZeroOffset = new System.Windows.Forms.Label();
            this.btnZeroRoll = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cboxHeadingPAOGI = new System.Windows.Forms.CheckBox();
            this.cboxHeadingBNO = new System.Windows.Forms.CheckBox();
            this.cboxHeadingBrick = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cboxRollPAOGI = new System.Windows.Forms.CheckBox();
            this.cboxRollDogs = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tboxTinkerUID = new System.Windows.Forms.TextBox();
            this.tabGuidance = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_max1 = new System.Windows.Forms.NumericUpDown();
            this.checkBox_PID = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown_D = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_I = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_P = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonspeedlookahed = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButtonFixed = new System.Windows.Forms.RadioButton();
            this.radioButtonSchelter = new System.Windows.Forms.RadioButton();
            this.radioButtonOrtner = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxlookahedtext = new System.Windows.Forms.NumericUpDown();
            this.minlookahedtext = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabDisplay.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLightbarCmPerPixel)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoundaryDistance)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleResolution)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinFixStepDistance)).BeginInit();
            this.tabIMU.SuspendLayout();
            this.headingGroupBox.SuspendLayout();
            this.btnRollZero.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabGuidance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_D)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_I)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_P)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxlookahedtext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minlookahedtext)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(687, 542);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 72);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bntOK
            // 
            this.bntOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.bntOK.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.bntOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.bntOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bntOK.Location = new System.Drawing.Point(800, 542);
            this.bntOK.Name = "bntOK";
            this.bntOK.Size = new System.Drawing.Size(156, 72);
            this.bntOK.TabIndex = 4;
            this.bntOK.Text = "Save";
            this.bntOK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.bntOK.UseVisualStyleBackColor = true;
            this.bntOK.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDisplay);
            this.tabControl1.Controls.Add(this.tabIMU);
            this.tabControl1.Controls.Add(this.tabGuidance);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(260, 50);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 528);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 6;
            // 
            // tabDisplay
            // 
            this.tabDisplay.Controls.Add(this.groupBox3);
            this.tabDisplay.Controls.Add(this.groupBox5);
            this.tabDisplay.Controls.Add(this.groupBox2);
            this.tabDisplay.Controls.Add(this.groupBox4);
            this.tabDisplay.Location = new System.Drawing.Point(4, 54);
            this.tabDisplay.Name = "tabDisplay";
            this.tabDisplay.Size = new System.Drawing.Size(948, 470);
            this.tabDisplay.TabIndex = 5;
            this.tabDisplay.Text = " Display Calcs";
            this.tabDisplay.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudLightbarCmPerPixel);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(21, 229);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 142);
            this.groupBox3.TabIndex = 119;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Offline cm per Lightbar Pixel";
            // 
            // nudLightbarCmPerPixel
            // 
            this.nudLightbarCmPerPixel.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudLightbarCmPerPixel.Location = new System.Drawing.Point(23, 40);
            this.nudLightbarCmPerPixel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.Name = "nudLightbarCmPerPixel";
            this.nudLightbarCmPerPixel.Size = new System.Drawing.Size(148, 85);
            this.nudLightbarCmPerPixel.TabIndex = 117;
            this.nudLightbarCmPerPixel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudLightbarCmPerPixel.ValueChanged += new System.EventHandler(this.nudLightbarCmPerPixel_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.nudBoundaryDistance);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox5.Location = new System.Drawing.Point(488, 229);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(387, 142);
            this.groupBox5.TabIndex = 62;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boundary Point to Point Distance";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label31.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label31.Location = new System.Drawing.Point(190, 66);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(140, 25);
            this.label31.TabIndex = 67;
            this.label31.Text = "2 to 4 is good\r\n";
            // 
            // nudBoundaryDistance
            // 
            this.nudBoundaryDistance.DecimalPlaces = 1;
            this.nudBoundaryDistance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudBoundaryDistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudBoundaryDistance.Location = new System.Drawing.Point(30, 40);
            this.nudBoundaryDistance.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudBoundaryDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudBoundaryDistance.Name = "nudBoundaryDistance";
            this.nudBoundaryDistance.Size = new System.Drawing.Size(147, 85);
            this.nudBoundaryDistance.TabIndex = 66;
            this.nudBoundaryDistance.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudBoundaryDistance.ValueChanged += new System.EventHandler(this.nudBoundaryDistance_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.nudTriangleResolution);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox2.Location = new System.Drawing.Point(488, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 142);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Distance Between Section Triggers";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(205, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 25);
            this.label7.TabIndex = 67;
            this.label7.Text = "4 -> Few triangles";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(183, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 25);
            this.label6.TabIndex = 66;
            this.label6.Text = "1 -> Many Triangles";
            // 
            // nudTriangleResolution
            // 
            this.nudTriangleResolution.DecimalPlaces = 1;
            this.nudTriangleResolution.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTriangleResolution.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudTriangleResolution.Location = new System.Drawing.Point(30, 40);
            this.nudTriangleResolution.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.nudTriangleResolution.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudTriangleResolution.Name = "nudTriangleResolution";
            this.nudTriangleResolution.Size = new System.Drawing.Size(147, 85);
            this.nudTriangleResolution.TabIndex = 64;
            this.nudTriangleResolution.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudTriangleResolution.ValueChanged += new System.EventHandler(this.nudTriangleResolution_ValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.nudMinFixStepDistance);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox4.Location = new System.Drawing.Point(21, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(387, 142);
            this.groupBox4.TabIndex = 60;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Distance Back for Heading Calc";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(273, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 50);
            this.label4.TabIndex = 68;
            this.label4.Text = "More is\r\nsmoother";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label20.Location = new System.Drawing.Point(192, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(94, 29);
            this.label20.TabIndex = 67;
            this.label20.Text = "Meters";
            // 
            // nudMinFixStepDistance
            // 
            this.nudMinFixStepDistance.DecimalPlaces = 1;
            this.nudMinFixStepDistance.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMinFixStepDistance.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.Location = new System.Drawing.Point(23, 40);
            this.nudMinFixStepDistance.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.Name = "nudMinFixStepDistance";
            this.nudMinFixStepDistance.Size = new System.Drawing.Size(163, 85);
            this.nudMinFixStepDistance.TabIndex = 66;
            this.nudMinFixStepDistance.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudMinFixStepDistance.ValueChanged += new System.EventHandler(this.nudMinFixStepDistance_ValueChanged);
            // 
            // tabIMU
            // 
            this.tabIMU.Controls.Add(this.headingGroupBox);
            this.tabIMU.Controls.Add(this.btnRollZero);
            this.tabIMU.Controls.Add(this.label10);
            this.tabIMU.Controls.Add(this.groupBox7);
            this.tabIMU.Controls.Add(this.groupBox6);
            this.tabIMU.Controls.Add(this.label9);
            this.tabIMU.Controls.Add(this.tboxTinkerUID);
            this.tabIMU.Location = new System.Drawing.Point(4, 54);
            this.tabIMU.Name = "tabIMU";
            this.tabIMU.Size = new System.Drawing.Size(948, 470);
            this.tabIMU.TabIndex = 13;
            this.tabIMU.Text = "IMU - GPS";
            this.tabIMU.UseVisualStyleBackColor = true;
            // 
            // headingGroupBox
            // 
            this.headingGroupBox.Controls.Add(this.rbtnHeadingHDT);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingGPS);
            this.headingGroupBox.Controls.Add(this.rbtnHeadingFix);
            this.headingGroupBox.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.headingGroupBox.Location = new System.Drawing.Point(727, 221);
            this.headingGroupBox.Name = "headingGroupBox";
            this.headingGroupBox.Size = new System.Drawing.Size(211, 229);
            this.headingGroupBox.TabIndex = 84;
            this.headingGroupBox.TabStop = false;
            this.headingGroupBox.Text = "Heading By...";
            this.headingGroupBox.Enter += new System.EventHandler(this.headingGroupBox_Enter);
            // 
            // rbtnHeadingHDT
            // 
            this.rbtnHeadingHDT.AutoSize = true;
            this.rbtnHeadingHDT.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingHDT.Location = new System.Drawing.Point(53, 171);
            this.rbtnHeadingHDT.Name = "rbtnHeadingHDT";
            this.rbtnHeadingHDT.Size = new System.Drawing.Size(75, 29);
            this.rbtnHeadingHDT.TabIndex = 2;
            this.rbtnHeadingHDT.TabStop = true;
            this.rbtnHeadingHDT.Text = "HDT";
            this.rbtnHeadingHDT.UseVisualStyleBackColor = true;
            // 
            // rbtnHeadingGPS
            // 
            this.rbtnHeadingGPS.AutoSize = true;
            this.rbtnHeadingGPS.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingGPS.Location = new System.Drawing.Point(53, 113);
            this.rbtnHeadingGPS.Name = "rbtnHeadingGPS";
            this.rbtnHeadingGPS.Size = new System.Drawing.Size(73, 29);
            this.rbtnHeadingGPS.TabIndex = 1;
            this.rbtnHeadingGPS.TabStop = true;
            this.rbtnHeadingGPS.Text = "GPS";
            this.rbtnHeadingGPS.UseVisualStyleBackColor = true;
            // 
            // rbtnHeadingFix
            // 
            this.rbtnHeadingFix.AutoSize = true;
            this.rbtnHeadingFix.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHeadingFix.Location = new System.Drawing.Point(53, 55);
            this.rbtnHeadingFix.Name = "rbtnHeadingFix";
            this.rbtnHeadingFix.Size = new System.Drawing.Size(61, 29);
            this.rbtnHeadingFix.TabIndex = 0;
            this.rbtnHeadingFix.TabStop = true;
            this.rbtnHeadingFix.Text = "Fix";
            this.rbtnHeadingFix.UseVisualStyleBackColor = true;
            this.rbtnHeadingFix.CheckedChanged += new System.EventHandler(this.rbtnHeadingFix_CheckedChanged);
            // 
            // btnRollZero
            // 
            this.btnRollZero.Controls.Add(this.label2);
            this.btnRollZero.Controls.Add(this.label3);
            this.btnRollZero.Controls.Add(this.btnRemoveZeroOffsetPitch);
            this.btnRollZero.Controls.Add(this.label1);
            this.btnRollZero.Controls.Add(this.btnZeroPitch);
            this.btnRollZero.Controls.Add(this.btnRemoveZeroOffset);
            this.btnRollZero.Controls.Add(this.lblRollZeroOffset);
            this.btnRollZero.Controls.Add(this.btnZeroRoll);
            this.btnRollZero.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRollZero.Location = new System.Drawing.Point(41, 221);
            this.btnRollZero.Name = "btnRollZero";
            this.btnRollZero.Size = new System.Drawing.Size(377, 229);
            this.btnRollZero.TabIndex = 83;
            this.btnRollZero.TabStop = false;
            this.btnRollZero.Text = "Roll / Pitch Zero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(218, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "Pitch";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(218, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 16);
            this.label3.TabIndex = 85;
            this.label3.Text = "Roll";
            // 
            // btnRemoveZeroOffsetPitch
            // 
            this.btnRemoveZeroOffsetPitch.Enabled = false;
            this.btnRemoveZeroOffsetPitch.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveZeroOffsetPitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveZeroOffsetPitch.Location = new System.Drawing.Point(32, 153);
            this.btnRemoveZeroOffsetPitch.Name = "btnRemoveZeroOffsetPitch";
            this.btnRemoveZeroOffsetPitch.Size = new System.Drawing.Size(79, 48);
            this.btnRemoveZeroOffsetPitch.TabIndex = 79;
            this.btnRemoveZeroOffsetPitch.Text = "Remove Offset";
            this.btnRemoveZeroOffsetPitch.UseVisualStyleBackColor = true;
            this.btnRemoveZeroOffsetPitch.Click += new System.EventHandler(this.btnRemoveZeroOffsetPitch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(119, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 33);
            this.label1.TabIndex = 78;
            this.label1.Text = "--";
            // 
            // btnZeroPitch
            // 
            this.btnZeroPitch.Enabled = false;
            this.btnZeroPitch.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroPitch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroPitch.Location = new System.Drawing.Point(221, 153);
            this.btnZeroPitch.Name = "btnZeroPitch";
            this.btnZeroPitch.Size = new System.Drawing.Size(103, 48);
            this.btnZeroPitch.TabIndex = 77;
            this.btnZeroPitch.Text = "> 0 <";
            this.btnZeroPitch.UseVisualStyleBackColor = true;
            this.btnZeroPitch.Click += new System.EventHandler(this.btnZeroPitch_Click);
            // 
            // btnRemoveZeroOffset
            // 
            this.btnRemoveZeroOffset.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveZeroOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoveZeroOffset.Location = new System.Drawing.Point(32, 46);
            this.btnRemoveZeroOffset.Name = "btnRemoveZeroOffset";
            this.btnRemoveZeroOffset.Size = new System.Drawing.Size(79, 48);
            this.btnRemoveZeroOffset.TabIndex = 76;
            this.btnRemoveZeroOffset.Text = "Remove Offset";
            this.btnRemoveZeroOffset.UseVisualStyleBackColor = true;
            this.btnRemoveZeroOffset.Click += new System.EventHandler(this.btnRemoveZeroOffset_Click);
            // 
            // lblRollZeroOffset
            // 
            this.lblRollZeroOffset.AutoSize = true;
            this.lblRollZeroOffset.Font = new System.Drawing.Font("Tahoma", 20.25F);
            this.lblRollZeroOffset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblRollZeroOffset.Location = new System.Drawing.Point(119, 55);
            this.lblRollZeroOffset.Name = "lblRollZeroOffset";
            this.lblRollZeroOffset.Size = new System.Drawing.Size(100, 33);
            this.lblRollZeroOffset.TabIndex = 75;
            this.lblRollZeroOffset.Text = "label11";
            // 
            // btnZeroRoll
            // 
            this.btnZeroRoll.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZeroRoll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnZeroRoll.Location = new System.Drawing.Point(221, 46);
            this.btnZeroRoll.Name = "btnZeroRoll";
            this.btnZeroRoll.Size = new System.Drawing.Size(103, 48);
            this.btnZeroRoll.TabIndex = 73;
            this.btnZeroRoll.Text = "> 0 <";
            this.btnZeroRoll.UseVisualStyleBackColor = true;
            this.btnZeroRoll.Click += new System.EventHandler(this.btnZeroRoll_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(13, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 16);
            this.label10.TabIndex = 82;
            this.label10.Text = "*Most Settings Require Restart";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cboxHeadingPAOGI);
            this.groupBox7.Controls.Add(this.cboxHeadingBNO);
            this.groupBox7.Controls.Add(this.cboxHeadingBrick);
            this.groupBox7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(624, 21);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(314, 171);
            this.groupBox7.TabIndex = 81;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "IMU Yaw Source";
            // 
            // cboxHeadingPAOGI
            // 
            this.cboxHeadingPAOGI.AutoSize = true;
            this.cboxHeadingPAOGI.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingPAOGI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingPAOGI.Location = new System.Drawing.Point(16, 129);
            this.cboxHeadingPAOGI.Name = "cboxHeadingPAOGI";
            this.cboxHeadingPAOGI.Size = new System.Drawing.Size(101, 29);
            this.cboxHeadingPAOGI.TabIndex = 71;
            this.cboxHeadingPAOGI.Text = "PAOGI";
            this.cboxHeadingPAOGI.UseVisualStyleBackColor = true;
            this.cboxHeadingPAOGI.CheckedChanged += new System.EventHandler(this.cboxHeadingPAOGI_CheckedChanged);
            // 
            // cboxHeadingBNO
            // 
            this.cboxHeadingBNO.AutoSize = true;
            this.cboxHeadingBNO.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingBNO.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingBNO.Location = new System.Drawing.Point(16, 39);
            this.cboxHeadingBNO.Name = "cboxHeadingBNO";
            this.cboxHeadingBNO.Size = new System.Drawing.Size(226, 29);
            this.cboxHeadingBNO.TabIndex = 69;
            this.cboxHeadingBNO.Text = "Arduino + BNO055";
            this.cboxHeadingBNO.UseVisualStyleBackColor = true;
            this.cboxHeadingBNO.CheckedChanged += new System.EventHandler(this.cboxHeadingBNO_CheckedChanged);
            // 
            // cboxHeadingBrick
            // 
            this.cboxHeadingBrick.AutoSize = true;
            this.cboxHeadingBrick.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxHeadingBrick.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxHeadingBrick.Location = new System.Drawing.Point(16, 84);
            this.cboxHeadingBrick.Name = "cboxHeadingBrick";
            this.cboxHeadingBrick.Size = new System.Drawing.Size(115, 29);
            this.cboxHeadingBrick.TabIndex = 70;
            this.cboxHeadingBrick.Text = "Brick v2";
            this.cboxHeadingBrick.UseVisualStyleBackColor = true;
            this.cboxHeadingBrick.CheckedChanged += new System.EventHandler(this.cboxHeadingBrick_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cboxRollPAOGI);
            this.groupBox6.Controls.Add(this.cboxRollDogs);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(282, 21);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(314, 171);
            this.groupBox6.TabIndex = 80;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Roll/Pitch Source";
            // 
            // cboxRollPAOGI
            // 
            this.cboxRollPAOGI.AutoSize = true;
            this.cboxRollPAOGI.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRollPAOGI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxRollPAOGI.Location = new System.Drawing.Point(20, 99);
            this.cboxRollPAOGI.Name = "cboxRollPAOGI";
            this.cboxRollPAOGI.Size = new System.Drawing.Size(101, 29);
            this.cboxRollPAOGI.TabIndex = 73;
            this.cboxRollPAOGI.Text = "PAOGI";
            this.cboxRollPAOGI.UseVisualStyleBackColor = true;
            this.cboxRollPAOGI.CheckedChanged += new System.EventHandler(this.cboxRollPAOGI_CheckedChanged);
            // 
            // cboxRollDogs
            // 
            this.cboxRollDogs.AutoSize = true;
            this.cboxRollDogs.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboxRollDogs.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboxRollDogs.Location = new System.Drawing.Point(20, 42);
            this.cboxRollDogs.Name = "cboxRollDogs";
            this.cboxRollDogs.Size = new System.Drawing.Size(245, 29);
            this.cboxRollDogs.TabIndex = 72;
            this.cboxRollDogs.Text = "DOGS2 Inclinometer";
            this.cboxRollDogs.UseVisualStyleBackColor = true;
            this.cboxRollDogs.CheckedChanged += new System.EventHandler(this.cboxRollDogs_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(36, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 23);
            this.label9.TabIndex = 79;
            this.label9.Text = "IMU Brick v2 UID";
            // 
            // tboxTinkerUID
            // 
            this.tboxTinkerUID.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.tboxTinkerUID.Location = new System.Drawing.Point(41, 107);
            this.tboxTinkerUID.Name = "tboxTinkerUID";
            this.tboxTinkerUID.Size = new System.Drawing.Size(169, 33);
            this.tboxTinkerUID.TabIndex = 78;
            this.tboxTinkerUID.TextChanged += new System.EventHandler(this.tboxTinkerUID_TextChanged);
            // 
            // tabGuidance
            // 
            this.tabGuidance.Controls.Add(this.label14);
            this.tabGuidance.Controls.Add(this.numericUpDown_max1);
            this.tabGuidance.Controls.Add(this.checkBox_PID);
            this.tabGuidance.Controls.Add(this.label13);
            this.tabGuidance.Controls.Add(this.label12);
            this.tabGuidance.Controls.Add(this.label11);
            this.tabGuidance.Controls.Add(this.numericUpDown_D);
            this.tabGuidance.Controls.Add(this.numericUpDown_I);
            this.tabGuidance.Controls.Add(this.numericUpDown_P);
            this.tabGuidance.Controls.Add(this.groupBox1);
            this.tabGuidance.Controls.Add(this.label8);
            this.tabGuidance.Controls.Add(this.label5);
            this.tabGuidance.Controls.Add(this.maxlookahedtext);
            this.tabGuidance.Controls.Add(this.minlookahedtext);
            this.tabGuidance.Location = new System.Drawing.Point(4, 54);
            this.tabGuidance.Name = "tabGuidance";
            this.tabGuidance.Size = new System.Drawing.Size(948, 470);
            this.tabGuidance.TabIndex = 11;
            this.tabGuidance.Text = "Guidance";
            this.tabGuidance.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(814, 310);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 39);
            this.label14.TabIndex = 103;
            this.label14.Text = "MAX I";
            // 
            // numericUpDown_max1
            // 
            this.numericUpDown_max1.DecimalPlaces = 2;
            this.numericUpDown_max1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_max1.Location = new System.Drawing.Point(739, 368);
            this.numericUpDown_max1.Name = "numericUpDown_max1";
            this.numericUpDown_max1.Size = new System.Drawing.Size(163, 85);
            this.numericUpDown_max1.TabIndex = 102;
            this.numericUpDown_max1.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_max1.Click += new System.EventHandler(this.numericUpDown_max1_Click);
            // 
            // checkBox_PID
            // 
            this.checkBox_PID.AutoSize = true;
            this.checkBox_PID.Location = new System.Drawing.Point(30, 296);
            this.checkBox_PID.Name = "checkBox_PID";
            this.checkBox_PID.Size = new System.Drawing.Size(425, 43);
            this.checkBox_PID.TabIndex = 101;
            this.checkBox_PID.Text = "Use PID Steering Controller";
            this.checkBox_PID.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(480, 388);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 39);
            this.label13.TabIndex = 99;
            this.label13.Text = "D";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(182, 388);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 39);
            this.label12.TabIndex = 98;
            this.label12.Text = "I";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-7, 388);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 39);
            this.label11.TabIndex = 97;
            this.label11.Text = "P";
            // 
            // numericUpDown_D
            // 
            this.numericUpDown_D.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_D.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_D.Location = new System.Drawing.Point(525, 368);
            this.numericUpDown_D.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_D.Name = "numericUpDown_D";
            this.numericUpDown_D.Size = new System.Drawing.Size(163, 85);
            this.numericUpDown_D.TabIndex = 96;
            this.numericUpDown_D.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_D.Click += new System.EventHandler(this.numericUpDown_D_Click);
            // 
            // numericUpDown_I
            // 
            this.numericUpDown_I.DecimalPlaces = 4;
            this.numericUpDown_I.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_I.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numericUpDown_I.Location = new System.Drawing.Point(217, 368);
            this.numericUpDown_I.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            327680});
            this.numericUpDown_I.Name = "numericUpDown_I";
            this.numericUpDown_I.Size = new System.Drawing.Size(257, 85);
            this.numericUpDown_I.TabIndex = 95;
            this.numericUpDown_I.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_I.Click += new System.EventHandler(this.numericUpDown_I_Click);
            // 
            // numericUpDown_P
            // 
            this.numericUpDown_P.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_P.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_P.Location = new System.Drawing.Point(30, 368);
            this.numericUpDown_P.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDown_P.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_P.Name = "numericUpDown_P";
            this.numericUpDown_P.Size = new System.Drawing.Size(125, 85);
            this.numericUpDown_P.TabIndex = 94;
            this.numericUpDown_P.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.numericUpDown_P.Click += new System.EventHandler(this.numericUpDown_P_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonspeedlookahed);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButtonFixed);
            this.groupBox1.Controls.Add(this.radioButtonSchelter);
            this.groupBox1.Controls.Add(this.radioButtonOrtner);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(487, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 325);
            this.groupBox1.TabIndex = 93;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alternative LookAhead";
            // 
            // radioButtonspeedlookahed
            // 
            this.radioButtonspeedlookahed.AutoSize = true;
            this.radioButtonspeedlookahed.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonspeedlookahed.Location = new System.Drawing.Point(53, 290);
            this.radioButtonspeedlookahed.Name = "radioButtonspeedlookahed";
            this.radioButtonspeedlookahed.Size = new System.Drawing.Size(246, 29);
            this.radioButtonspeedlookahed.TabIndex = 4;
            this.radioButtonspeedlookahed.Text = "speed*maxlookahed";
            this.toolTip4.SetToolTip(this.radioButtonspeedlookahed, "Verwendet Geschwindkeit mal max Lookahed. Gute Werte zw 0,7 und 1. Min lookahed w" +
        "ird als begrenzung nach unten verwendet in meter 3-4");
            this.radioButtonspeedlookahed.UseVisualStyleBackColor = true;
            this.radioButtonspeedlookahed.CheckedChanged += new System.EventHandler(this.radioButtonspeedlookahed_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(53, 231);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(122, 29);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Standart";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged_1);
            // 
            // radioButtonFixed
            // 
            this.radioButtonFixed.AutoSize = true;
            this.radioButtonFixed.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonFixed.Location = new System.Drawing.Point(53, 171);
            this.radioButtonFixed.Name = "radioButtonFixed";
            this.radioButtonFixed.Size = new System.Drawing.Size(138, 29);
            this.radioButtonFixed.TabIndex = 2;
            this.radioButtonFixed.Text = "Brian New";
            this.toolTip3.SetToolTip(this.radioButtonFixed, "Fixer Look Ahead, muss je nach Geschwindkeit neu eingestellt werden.");
            this.radioButtonFixed.UseVisualStyleBackColor = true;
            this.radioButtonFixed.CheckedChanged += new System.EventHandler(this.radioButtonFixed_CheckedChanged);
            // 
            // radioButtonSchelter
            // 
            this.radioButtonSchelter.AutoSize = true;
            this.radioButtonSchelter.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSchelter.Location = new System.Drawing.Point(53, 113);
            this.radioButtonSchelter.Name = "radioButtonSchelter";
            this.radioButtonSchelter.Size = new System.Drawing.Size(115, 29);
            this.radioButtonSchelter.TabIndex = 1;
            this.radioButtonSchelter.Text = "Schelter";
            this.toolTip2.SetToolTip(this.radioButtonSchelter, "Änlich wie Ortner nur mit Fixen Werten. Min LookAhead ist aktiv");
            this.radioButtonSchelter.UseVisualStyleBackColor = true;
            this.radioButtonSchelter.CheckedChanged += new System.EventHandler(this.radioButtonSchelter_CheckedChanged);
            // 
            // radioButtonOrtner
            // 
            this.radioButtonOrtner.AutoSize = true;
            this.radioButtonOrtner.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonOrtner.Location = new System.Drawing.Point(53, 55);
            this.radioButtonOrtner.Name = "radioButtonOrtner";
            this.radioButtonOrtner.Size = new System.Drawing.Size(98, 29);
            this.radioButtonOrtner.TabIndex = 0;
            this.radioButtonOrtner.Text = "Ortner";
            this.toolTip1.SetToolTip(this.radioButtonOrtner, "Verwendet Min und Maxlookahed. Verringert den Abstand je weiter man von der Linie" +
        " wegkommt. Als Faktor wird hier LookAhead genommen welcher auf 10 - 20 eingestel" +
        "lt werden soll. Min lookahead in Meter");
            this.radioButtonOrtner.UseVisualStyleBackColor = true;
            this.radioButtonOrtner.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(26, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(300, 23);
            this.label8.TabIndex = 92;
            this.label8.Text = "MaxlookAhead als Faktor zu Speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(26, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 23);
            this.label5.TabIndex = 91;
            this.label5.Text = "MinLookAhead in Meter";
            // 
            // maxlookahedtext
            // 
            this.maxlookahedtext.DecimalPlaces = 2;
            this.maxlookahedtext.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxlookahedtext.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.maxlookahedtext.Location = new System.Drawing.Point(30, 190);
            this.maxlookahedtext.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.maxlookahedtext.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.maxlookahedtext.Name = "maxlookahedtext";
            this.maxlookahedtext.Size = new System.Drawing.Size(163, 85);
            this.maxlookahedtext.TabIndex = 90;
            this.maxlookahedtext.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // minlookahedtext
            // 
            this.minlookahedtext.DecimalPlaces = 1;
            this.minlookahedtext.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minlookahedtext.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.minlookahedtext.Location = new System.Drawing.Point(30, 55);
            this.minlookahedtext.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            65536});
            this.minlookahedtext.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.minlookahedtext.Name = "minlookahedtext";
            this.minlookahedtext.Size = new System.Drawing.Size(163, 85);
            this.minlookahedtext.TabIndex = 89;
            this.minlookahedtext.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.Test);
            // 
            // FormDisplaySettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 626);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.bntOK);
            this.Name = "FormDisplaySettings";
            this.Text = "FormDisplaySettings";
            this.Load += new System.EventHandler(this.FormDisplaySettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDisplay.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLightbarCmPerPixel)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBoundaryDistance)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTriangleResolution)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinFixStepDistance)).EndInit();
            this.tabIMU.ResumeLayout(false);
            this.tabIMU.PerformLayout();
            this.headingGroupBox.ResumeLayout(false);
            this.headingGroupBox.PerformLayout();
            this.btnRollZero.ResumeLayout(false);
            this.btnRollZero.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabGuidance.ResumeLayout(false);
            this.tabGuidance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_max1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_D)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_I)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_P)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxlookahedtext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minlookahedtext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button bntOK;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDisplay;
        private System.Windows.Forms.NumericUpDown nudLightbarCmPerPixel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown nudBoundaryDistance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudTriangleResolution;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown nudMinFixStepDistance;
        private System.Windows.Forms.TabPage tabGuidance;
        private System.Windows.Forms.TabPage tabIMU;
        private System.Windows.Forms.GroupBox headingGroupBox;
        private System.Windows.Forms.GroupBox btnRollZero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveZeroOffsetPitch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnZeroPitch;
        private System.Windows.Forms.Button btnRemoveZeroOffset;
        private System.Windows.Forms.Label lblRollZeroOffset;
        private System.Windows.Forms.Button btnZeroRoll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox cboxHeadingPAOGI;
        private System.Windows.Forms.CheckBox cboxHeadingBNO;
        private System.Windows.Forms.CheckBox cboxHeadingBrick;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cboxRollPAOGI;
        private System.Windows.Forms.CheckBox cboxRollDogs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tboxTinkerUID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnHeadingHDT;
        private System.Windows.Forms.RadioButton rbtnHeadingGPS;
        private System.Windows.Forms.RadioButton rbtnHeadingFix;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown maxlookahedtext;
        private System.Windows.Forms.NumericUpDown minlookahedtext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonFixed;
        private System.Windows.Forms.RadioButton radioButtonSchelter;
        private System.Windows.Forms.RadioButton radioButtonOrtner;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButtonspeedlookahed;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown_D;
        private System.Windows.Forms.NumericUpDown numericUpDown_I;
        private System.Windows.Forms.NumericUpDown numericUpDown_P;
        private System.Windows.Forms.CheckBox checkBox_PID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_max1;
    }
}