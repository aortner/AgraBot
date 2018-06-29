namespace AgOpenGPS
{
    partial class FormGenerate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerate));
            this.openGLHead = new SharpGL.OpenGLControl();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnMakeHeadRecPath = new System.Windows.Forms.Button();
            this.lblStartHeading = new System.Windows.Forms.Label();
            this.lblStartNorthing = new System.Windows.Forms.Label();
            this.lblStartEasting = new System.Windows.Forms.Label();
            this.btnStartPt = new System.Windows.Forms.Button();
            this.btnNumHeadlandPassesDn = new ProXoft.WinForms.RepeatButton();
            this.btnNumHeadlandPassesUp = new ProXoft.WinForms.RepeatButton();
            this.lblNumPassesTotal = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.btnBringUpABLine = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudWidths = new System.Windows.Forms.NumericUpDown();
            this.btnPathToInfieldStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudHeadlandIncludeAngle = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDeleteLastPoint = new System.Windows.Forms.Button();
            this.btnDoneDrawingHeadland = new System.Windows.Forms.Button();
            this.btnStartDrawingHeadland = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboxStayInBounds = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeadlandIncludeAngle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLHead
            // 
            this.openGLHead.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLHead.Cursor = System.Windows.Forms.Cursors.Cross;
            this.openGLHead.DrawFPS = false;
            this.openGLHead.FrameRate = 2;
            this.openGLHead.Location = new System.Drawing.Point(3, 3);
            this.openGLHead.Margin = new System.Windows.Forms.Padding(4);
            this.openGLHead.Name = "openGLHead";
            this.openGLHead.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLHead.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLHead.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLHead.Size = new System.Drawing.Size(960, 960);
            this.openGLHead.TabIndex = 71;
            this.openGLHead.OpenGLInitialized += new System.EventHandler(this.openGLHead_OpenGLInitialized);
            this.openGLHead.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLHead_OpenGLDraw);
            this.openGLHead.Resized += new System.EventHandler(this.openGLHead_Resized);
            this.openGLHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLHead_MouseDown);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = global::AgOpenGPS.Properties.Resources.Cancel64;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.Location = new System.Drawing.Point(1033, 864);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 88);
            this.btnCancel.TabIndex = 73;
            this.btnCancel.Text = "Delete Path";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOK.Image = global::AgOpenGPS.Properties.Resources.OK64;
            this.btnOK.Location = new System.Drawing.Point(1258, 864);
            this.btnOK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 88);
            this.btnOK.TabIndex = 72;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnMakeHeadRecPath
            // 
            this.btnMakeHeadRecPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeHeadRecPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMakeHeadRecPath.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeHeadRecPath.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnMakeHeadRecPath.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMakeHeadRecPath.Location = new System.Drawing.Point(278, 110);
            this.btnMakeHeadRecPath.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnMakeHeadRecPath.Name = "btnMakeHeadRecPath";
            this.btnMakeHeadRecPath.Size = new System.Drawing.Size(125, 116);
            this.btnMakeHeadRecPath.TabIndex = 93;
            this.btnMakeHeadRecPath.Text = "Make Headland";
            this.btnMakeHeadRecPath.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMakeHeadRecPath.UseVisualStyleBackColor = true;
            this.btnMakeHeadRecPath.Click += new System.EventHandler(this.btnMakeHeadRecPath_Click);
            // 
            // lblStartHeading
            // 
            this.lblStartHeading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartHeading.AutoSize = true;
            this.lblStartHeading.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartHeading.Location = new System.Drawing.Point(9, 337);
            this.lblStartHeading.Name = "lblStartHeading";
            this.lblStartHeading.Size = new System.Drawing.Size(14, 13);
            this.lblStartHeading.TabIndex = 92;
            this.lblStartHeading.Text = "D";
            // 
            // lblStartNorthing
            // 
            this.lblStartNorthing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartNorthing.AutoSize = true;
            this.lblStartNorthing.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartNorthing.Location = new System.Drawing.Point(9, 305);
            this.lblStartNorthing.Name = "lblStartNorthing";
            this.lblStartNorthing.Size = new System.Drawing.Size(13, 13);
            this.lblStartNorthing.TabIndex = 91;
            this.lblStartNorthing.Text = "Y";
            // 
            // lblStartEasting
            // 
            this.lblStartEasting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartEasting.AutoSize = true;
            this.lblStartEasting.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartEasting.Location = new System.Drawing.Point(9, 272);
            this.lblStartEasting.Name = "lblStartEasting";
            this.lblStartEasting.Size = new System.Drawing.Size(13, 13);
            this.lblStartEasting.TabIndex = 90;
            this.lblStartEasting.Text = "X";
            // 
            // btnStartPt
            // 
            this.btnStartPt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartPt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartPt.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartPt.Location = new System.Drawing.Point(100, 266);
            this.btnStartPt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnStartPt.Name = "btnStartPt";
            this.btnStartPt.Size = new System.Drawing.Size(134, 90);
            this.btnStartPt.TabIndex = 89;
            this.btnStartPt.Text = "Create Infield Start Point";
            this.btnStartPt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStartPt.UseVisualStyleBackColor = true;
            this.btnStartPt.Click += new System.EventHandler(this.btnStartPt_Click);
            // 
            // btnNumHeadlandPassesDn
            // 
            this.btnNumHeadlandPassesDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNumHeadlandPassesDn.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumHeadlandPassesDn.Image = ((System.Drawing.Image)(resources.GetObject("btnNumHeadlandPassesDn.Image")));
            this.btnNumHeadlandPassesDn.Location = new System.Drawing.Point(51, 176);
            this.btnNumHeadlandPassesDn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnNumHeadlandPassesDn.Name = "btnNumHeadlandPassesDn";
            this.btnNumHeadlandPassesDn.Size = new System.Drawing.Size(59, 69);
            this.btnNumHeadlandPassesDn.TabIndex = 161;
            this.btnNumHeadlandPassesDn.UseVisualStyleBackColor = true;
            this.btnNumHeadlandPassesDn.Click += new System.EventHandler(this.btnNumHeadlandPassesDn_Click);
            // 
            // btnNumHeadlandPassesUp
            // 
            this.btnNumHeadlandPassesUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNumHeadlandPassesUp.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNumHeadlandPassesUp.Image = ((System.Drawing.Image)(resources.GetObject("btnNumHeadlandPassesUp.Image")));
            this.btnNumHeadlandPassesUp.Location = new System.Drawing.Point(51, 97);
            this.btnNumHeadlandPassesUp.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnNumHeadlandPassesUp.Name = "btnNumHeadlandPassesUp";
            this.btnNumHeadlandPassesUp.Size = new System.Drawing.Size(59, 69);
            this.btnNumHeadlandPassesUp.TabIndex = 162;
            this.btnNumHeadlandPassesUp.UseVisualStyleBackColor = true;
            this.btnNumHeadlandPassesUp.Click += new System.EventHandler(this.btnNumHeadlandPassesUp_Click);
            // 
            // lblNumPassesTotal
            // 
            this.lblNumPassesTotal.AutoSize = true;
            this.lblNumPassesTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumPassesTotal.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPassesTotal.Location = new System.Drawing.Point(143, 176);
            this.lblNumPassesTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumPassesTotal.Name = "lblNumPassesTotal";
            this.lblNumPassesTotal.Size = new System.Drawing.Size(70, 45);
            this.lblNumPassesTotal.TabIndex = 163;
            this.lblNumPassesTotal.Text = "XX";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(127, 117);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(122, 50);
            this.label47.TabIndex = 164;
            this.label47.Text = "# of \r\nHeadlands";
            // 
            // btnBringUpABLine
            // 
            this.btnBringUpABLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBringUpABLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBringUpABLine.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBringUpABLine.Image = global::AgOpenGPS.Properties.Resources.ArrowRight;
            this.btnBringUpABLine.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBringUpABLine.Location = new System.Drawing.Point(1033, 14);
            this.btnBringUpABLine.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnBringUpABLine.Name = "btnBringUpABLine";
            this.btnBringUpABLine.Size = new System.Drawing.Size(128, 82);
            this.btnBringUpABLine.TabIndex = 165;
            this.btnBringUpABLine.Text = "ABLine";
            this.btnBringUpABLine.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBringUpABLine.UseVisualStyleBackColor = true;
            this.btnBringUpABLine.Click += new System.EventHandler(this.btnBringUpABLine_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 23);
            this.label1.TabIndex = 167;
            this.label1.Text = "Tool Widths In";
            // 
            // nudWidths
            // 
            this.nudWidths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWidths.DecimalPlaces = 1;
            this.nudWidths.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudWidths.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWidths.Location = new System.Drawing.Point(263, 72);
            this.nudWidths.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudWidths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWidths.Name = "nudWidths";
            this.nudWidths.Size = new System.Drawing.Size(128, 85);
            this.nudWidths.TabIndex = 166;
            this.nudWidths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidths.ValueChanged += new System.EventHandler(this.nudWidths_ValueChanged);
            // 
            // btnPathToInfieldStart
            // 
            this.btnPathToInfieldStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPathToInfieldStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPathToInfieldStart.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPathToInfieldStart.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPathToInfieldStart.Location = new System.Drawing.Point(278, 266);
            this.btnPathToInfieldStart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPathToInfieldStart.Name = "btnPathToInfieldStart";
            this.btnPathToInfieldStart.Size = new System.Drawing.Size(134, 90);
            this.btnPathToInfieldStart.TabIndex = 168;
            this.btnPathToInfieldStart.Text = "Generate Path to Infield Start";
            this.btnPathToInfieldStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPathToInfieldStart.UseVisualStyleBackColor = true;
            this.btnPathToInfieldStart.Click += new System.EventHandler(this.btnPathToInfieldStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1213, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 25);
            this.label2.TabIndex = 169;
            this.label2.Text = "Create AB Line";
            // 
            // nudHeadlandIncludeAngle
            // 
            this.nudHeadlandIncludeAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudHeadlandIncludeAngle.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudHeadlandIncludeAngle.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHeadlandIncludeAngle.Location = new System.Drawing.Point(22, 72);
            this.nudHeadlandIncludeAngle.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudHeadlandIncludeAngle.Name = "nudHeadlandIncludeAngle";
            this.nudHeadlandIncludeAngle.Size = new System.Drawing.Size(129, 85);
            this.nudHeadlandIncludeAngle.TabIndex = 172;
            this.nudHeadlandIncludeAngle.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudHeadlandIncludeAngle.ValueChanged += new System.EventHandler(this.nudHeadlandIncludeAngle_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 171;
            this.label4.Text = "Include %";
            // 
            // btnDeleteLastPoint
            // 
            this.btnDeleteLastPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteLastPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeleteLastPoint.Enabled = false;
            this.btnDeleteLastPoint.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLastPoint.Image = global::AgOpenGPS.Properties.Resources.PointDelete;
            this.btnDeleteLastPoint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteLastPoint.Location = new System.Drawing.Point(149, 212);
            this.btnDeleteLastPoint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDeleteLastPoint.Name = "btnDeleteLastPoint";
            this.btnDeleteLastPoint.Size = new System.Drawing.Size(128, 88);
            this.btnDeleteLastPoint.TabIndex = 175;
            this.btnDeleteLastPoint.UseVisualStyleBackColor = true;
            this.btnDeleteLastPoint.Click += new System.EventHandler(this.btnDeleteLastPoint_Click);
            // 
            // btnDoneDrawingHeadland
            // 
            this.btnDoneDrawingHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoneDrawingHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDoneDrawingHeadland.Enabled = false;
            this.btnDoneDrawingHeadland.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoneDrawingHeadland.Image = global::AgOpenGPS.Properties.Resources.PointDone;
            this.btnDoneDrawingHeadland.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDoneDrawingHeadland.Location = new System.Drawing.Point(285, 212);
            this.btnDoneDrawingHeadland.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDoneDrawingHeadland.Name = "btnDoneDrawingHeadland";
            this.btnDoneDrawingHeadland.Size = new System.Drawing.Size(128, 88);
            this.btnDoneDrawingHeadland.TabIndex = 174;
            this.btnDoneDrawingHeadland.Text = "Done";
            this.btnDoneDrawingHeadland.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDoneDrawingHeadland.UseVisualStyleBackColor = true;
            this.btnDoneDrawingHeadland.Click += new System.EventHandler(this.btnDoneDrawingHeadland_Click);
            // 
            // btnStartDrawingHeadland
            // 
            this.btnStartDrawingHeadland.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartDrawingHeadland.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnStartDrawingHeadland.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartDrawingHeadland.Image = global::AgOpenGPS.Properties.Resources.PointStart;
            this.btnStartDrawingHeadland.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStartDrawingHeadland.Location = new System.Drawing.Point(9, 212);
            this.btnStartDrawingHeadland.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnStartDrawingHeadland.Name = "btnStartDrawingHeadland";
            this.btnStartDrawingHeadland.Size = new System.Drawing.Size(128, 88);
            this.btnStartDrawingHeadland.TabIndex = 173;
            this.btnStartDrawingHeadland.UseVisualStyleBackColor = true;
            this.btnStartDrawingHeadland.Click += new System.EventHandler(this.btnStartDrawingHeadland_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.btnStartDrawingHeadland);
            this.groupBox1.Controls.Add(this.btnDeleteLastPoint);
            this.groupBox1.Controls.Add(this.nudWidths);
            this.groupBox1.Controls.Add(this.btnDoneDrawingHeadland);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudHeadlandIncludeAngle);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(973, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 309);
            this.groupBox1.TabIndex = 176;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Headland";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboxStayInBounds);
            this.groupBox2.Controls.Add(this.btnStartPt);
            this.groupBox2.Controls.Add(this.lblStartEasting);
            this.groupBox2.Controls.Add(this.lblStartNorthing);
            this.groupBox2.Controls.Add(this.btnPathToInfieldStart);
            this.groupBox2.Controls.Add(this.lblStartHeading);
            this.groupBox2.Controls.Add(this.btnMakeHeadRecPath);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.lblNumPassesTotal);
            this.groupBox2.Controls.Add(this.btnNumHeadlandPassesDn);
            this.groupBox2.Controls.Add(this.btnNumHeadlandPassesUp);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(982, 466);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 367);
            this.groupBox2.TabIndex = 177;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate Path";
            // 
            // cboxStayInBounds
            // 
            this.cboxStayInBounds.AutoSize = true;
            this.cboxStayInBounds.Location = new System.Drawing.Point(140, 51);
            this.cboxStayInBounds.Name = "cboxStayInBounds";
            this.cboxStayInBounds.Size = new System.Drawing.Size(258, 39);
            this.cboxStayInBounds.TabIndex = 169;
            this.cboxStayInBounds.Text = "Stay In Bounds";
            this.cboxStayInBounds.UseVisualStyleBackColor = true;
            this.cboxStayInBounds.CheckedChanged += new System.EventHandler(this.cboxStayInBounds_CheckedChanged);
            // 
            // FormGenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1410, 920);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBringUpABLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.openGLHead);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGenerate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Path";
            this.Load += new System.EventHandler(this.FormGenerate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openGLHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeadlandIncludeAngle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLHead;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnMakeHeadRecPath;
        private System.Windows.Forms.Label lblStartHeading;
        private System.Windows.Forms.Label lblStartNorthing;
        private System.Windows.Forms.Label lblStartEasting;
        private System.Windows.Forms.Button btnStartPt;
        private ProXoft.WinForms.RepeatButton btnNumHeadlandPassesDn;
        private ProXoft.WinForms.RepeatButton btnNumHeadlandPassesUp;
        private System.Windows.Forms.Label lblNumPassesTotal;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnBringUpABLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudWidths;
        private System.Windows.Forms.Button btnPathToInfieldStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudHeadlandIncludeAngle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDeleteLastPoint;
        private System.Windows.Forms.Button btnDoneDrawingHeadland;
        private System.Windows.Forms.Button btnStartDrawingHeadland;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cboxStayInBounds;
    }
}