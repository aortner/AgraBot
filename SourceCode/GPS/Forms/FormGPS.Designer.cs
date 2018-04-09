namespace AgraBot
{
    partial class FormGPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGPS));
            this.openGLControl = new SharpGL.OpenGLControl();
            this.txtDistanceOffABLine = new System.Windows.Forms.TextBox();
            this.openGLControlBack = new SharpGL.OpenGLControl();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.menustripLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDeutsch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageRussian = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageDutch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageSpanish = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageFrench = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLanguageItalian = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.setWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.loadVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.fieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripUnitsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.metricToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.imperialToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.bigAltitudeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sideGuideLines = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logNMEAMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pursuitLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skyToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.simulatorOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tmrWatchdog = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stripHz = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolstripUDPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripUSBPortsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripDisplayConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripVehicleConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripAutoSteerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripYouTurnConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.stripDistance = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownBtnFuncs = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolstripField = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripBoundary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripHeadland = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripResetTrip = new System.Windows.Forms.ToolStripMenuItem();
            this.stripAreaRate = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnHideTabs = new System.Windows.Forms.ToolStripDropDownButton();
            this.stripEqWidth = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripPortGPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripOnlineGPS = new System.Windows.Forms.ToolStripProgressBar();
            this.stripPortArduino = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripOnlineArduino = new System.Windows.Forms.ToolStripProgressBar();
            this.stripPortAutoSteer = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripOnlineAutoSteer = new System.Windows.Forms.ToolStripProgressBar();
            this.lblNorthing = new System.Windows.Forms.Label();
            this.lblEasting = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.tboxSentence = new System.Windows.Forms.TextBox();
            this.lblZone = new System.Windows.Forms.Label();
            this.lblSpeedUnits = new System.Windows.Forms.Label();
            this.lblHeading = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.openGLControlZoom = new SharpGL.OpenGLControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFieldWidthNorthSouth = new System.Windows.Forms.Label();
            this.lblFieldWidthEastWest = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DataPage = new System.Windows.Forms.TabPage();
            this.tboxFromUDP = new System.Windows.Forms.TextBox();
            this.lblEmlidPitch = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblSats = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblFixQuality = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblHeadlandDistanceFromTool = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHeadlandDistanceAway = new System.Windows.Forms.Label();
            this.lblBoundaryArea = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblGPSHeading = new System.Windows.Forms.Label();
            this.lblYawHeading = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.zoomPage2 = new System.Windows.Forms.TabPage();
            this.btnDeleteAllData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblZooom = new System.Windows.Forms.Label();
            this.configPage1 = new System.Windows.Forms.TabPage();
            this.btnWebCam = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnFileExplorer = new System.Windows.Forms.Button();
            this.btnGPSData = new System.Windows.Forms.Button();
            this.autoPage4 = new System.Windows.Forms.TabPage();
            this.btnDrivePath = new System.Windows.Forms.Button();
            this.btnResetSim = new System.Windows.Forms.Button();
            this.btnResetSteerAngle = new System.Windows.Forms.Button();
            this.lblPureSteerAngle = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSteerAngle = new System.Windows.Forms.Label();
            this.tbarSteerAngle = new System.Windows.Forms.TrackBar();
            this.tbarStepDistance = new System.Windows.Forms.TrackBar();
            this.timerSim = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSimControls = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTiltDown = new ProXoft.WinForms.RepeatButton();
            this.btnTiltUp = new ProXoft.WinForms.RepeatButton();
            this.btnZoomIn = new ProXoft.WinForms.RepeatButton();
            this.btnZoomOut = new ProXoft.WinForms.RepeatButton();
            this.btnSectionOffAutoOn = new System.Windows.Forms.Button();
            this.btnManualOffOn = new System.Windows.Forms.Button();
            this.btnSection8Man = new System.Windows.Forms.Button();
            this.btnSection7Man = new System.Windows.Forms.Button();
            this.btnSection6Man = new System.Windows.Forms.Button();
            this.btnSection5Man = new System.Windows.Forms.Button();
            this.btnSection4Man = new System.Windows.Forms.Button();
            this.btnSection3Man = new System.Windows.Forms.Button();
            this.btnSection2Man = new System.Windows.Forms.Button();
            this.btnSection1Man = new System.Windows.Forms.Button();
            this.btnStopDrivingPath = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlZoom)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.DataPage.SuspendLayout();
            this.zoomPage2.SuspendLayout();
            this.configPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarSteerAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarStepDistance)).BeginInit();
            this.panelSimControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            resources.ApplyResources(this.openGLControl, "openGLControl");
            this.openGLControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControl.FrameRate = 5;
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            // 
            // txtDistanceOffABLine
            // 
            resources.ApplyResources(this.txtDistanceOffABLine, "txtDistanceOffABLine");
            this.txtDistanceOffABLine.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtDistanceOffABLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDistanceOffABLine.ForeColor = System.Drawing.Color.Green;
            this.txtDistanceOffABLine.Name = "txtDistanceOffABLine";
            this.txtDistanceOffABLine.ReadOnly = true;
            // 
            // openGLControlBack
            // 
            this.openGLControlBack.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openGLControlBack.DrawFPS = false;
            this.openGLControlBack.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.openGLControlBack.FrameRate = 1;
            resources.ApplyResources(this.openGLControlBack, "openGLControlBack");
            this.openGLControlBack.Name = "openGLControlBack";
            this.openGLControlBack.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlBack.RenderContextType = SharpGL.RenderContextType.HiddenWindow;
            this.openGLControlBack.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControlBack.OpenGLInitialized += new System.EventHandler(this.openGLControlBack_OpenGLInitialized);
            this.openGLControlBack.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlBack_OpenGLDraw);
            this.openGLControlBack.Resized += new System.EventHandler(this.openGLControlBack_Resized);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator9,
            this.menustripLanguage,
            this.toolStripSeparator11,
            this.setWorkingDirectoryToolStripMenuItem,
            this.toolStripSeparator10,
            this.loadVehicleToolStripMenuItem,
            this.saveVehicleToolStripMenuItem,
            this.toolStripSeparator8,
            this.fieldToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // menustripLanguage
            // 
            this.menustripLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLanguageEnglish,
            this.menuLanguageDeutsch,
            this.menuLanguageRussian,
            this.menuLanguageDutch,
            this.menuLanguageSpanish,
            this.menuLanguageFrench,
            this.menuLanguageItalian});
            this.menustripLanguage.Name = "menustripLanguage";
            resources.ApplyResources(this.menustripLanguage, "menustripLanguage");
            // 
            // menuLanguageEnglish
            // 
            this.menuLanguageEnglish.CheckOnClick = true;
            this.menuLanguageEnglish.Name = "menuLanguageEnglish";
            resources.ApplyResources(this.menuLanguageEnglish, "menuLanguageEnglish");
            this.menuLanguageEnglish.Click += new System.EventHandler(this.menuLanguageEnglish_Click);
            // 
            // menuLanguageDeutsch
            // 
            this.menuLanguageDeutsch.CheckOnClick = true;
            this.menuLanguageDeutsch.Name = "menuLanguageDeutsch";
            resources.ApplyResources(this.menuLanguageDeutsch, "menuLanguageDeutsch");
            this.menuLanguageDeutsch.Click += new System.EventHandler(this.menuLanguageDeutsch_Click);
            // 
            // menuLanguageRussian
            // 
            this.menuLanguageRussian.CheckOnClick = true;
            this.menuLanguageRussian.Name = "menuLanguageRussian";
            resources.ApplyResources(this.menuLanguageRussian, "menuLanguageRussian");
            this.menuLanguageRussian.Click += new System.EventHandler(this.menuLanguageRussian_Click);
            // 
            // menuLanguageDutch
            // 
            this.menuLanguageDutch.CheckOnClick = true;
            this.menuLanguageDutch.Name = "menuLanguageDutch";
            resources.ApplyResources(this.menuLanguageDutch, "menuLanguageDutch");
            this.menuLanguageDutch.Click += new System.EventHandler(this.menuLanguageDutch_Click);
            // 
            // menuLanguageSpanish
            // 
            this.menuLanguageSpanish.CheckOnClick = true;
            this.menuLanguageSpanish.Name = "menuLanguageSpanish";
            resources.ApplyResources(this.menuLanguageSpanish, "menuLanguageSpanish");
            this.menuLanguageSpanish.Click += new System.EventHandler(this.menuLanguageSpanish_Click);
            // 
            // menuLanguageFrench
            // 
            this.menuLanguageFrench.CheckOnClick = true;
            this.menuLanguageFrench.Name = "menuLanguageFrench";
            resources.ApplyResources(this.menuLanguageFrench, "menuLanguageFrench");
            this.menuLanguageFrench.Click += new System.EventHandler(this.menuLanguageFrench_Click);
            // 
            // menuLanguageItalian
            // 
            this.menuLanguageItalian.Name = "menuLanguageItalian";
            resources.ApplyResources(this.menuLanguageItalian, "menuLanguageItalian");
            this.menuLanguageItalian.Click += new System.EventHandler(this.menuLanguageItalian_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // setWorkingDirectoryToolStripMenuItem
            // 
            this.setWorkingDirectoryToolStripMenuItem.Name = "setWorkingDirectoryToolStripMenuItem";
            resources.ApplyResources(this.setWorkingDirectoryToolStripMenuItem, "setWorkingDirectoryToolStripMenuItem");
            this.setWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setWorkingDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // loadVehicleToolStripMenuItem
            // 
            this.loadVehicleToolStripMenuItem.Name = "loadVehicleToolStripMenuItem";
            resources.ApplyResources(this.loadVehicleToolStripMenuItem, "loadVehicleToolStripMenuItem");
            this.loadVehicleToolStripMenuItem.Click += new System.EventHandler(this.loadVehicleToolStripMenuItem_Click);
            // 
            // saveVehicleToolStripMenuItem
            // 
            this.saveVehicleToolStripMenuItem.Name = "saveVehicleToolStripMenuItem";
            resources.ApplyResources(this.saveVehicleToolStripMenuItem, "saveVehicleToolStripMenuItem");
            this.saveVehicleToolStripMenuItem.Click += new System.EventHandler(this.saveVehicleToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            resources.ApplyResources(this.fieldToolStripMenuItem, "fieldToolStripMenuItem");
            this.fieldToolStripMenuItem.Click += new System.EventHandler(this.fieldToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.resetALLToolStripMenuItem,
            this.toolStripSeparator2,
            this.colorsToolStripMenuItem,
            this.toolStripUnitsMenu,
            this.bigAltitudeToolStripMenuItem,
            this.sideGuideLines,
            this.gridToolStripMenuItem,
            this.lightbarToolStripMenuItem,
            this.logNMEAMenuItem,
            this.polygonsToolStripMenuItem,
            this.pursuitLineToolStripMenuItem,
            this.skyToolStripMenu,
            this.toolStripSeparator6,
            this.simulatorOnToolStripMenuItem,
            this.toolStripSeparator7});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            resources.ApplyResources(this.settingsToolStripMenuItem, "settingsToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // resetALLToolStripMenuItem
            // 
            this.resetALLToolStripMenuItem.Name = "resetALLToolStripMenuItem";
            resources.ApplyResources(this.resetALLToolStripMenuItem, "resetALLToolStripMenuItem");
            this.resetALLToolStripMenuItem.Click += new System.EventHandler(this.resetALLToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectionToolStripMenuItem,
            this.fieldToolStripMenuItem1});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            resources.ApplyResources(this.colorsToolStripMenuItem, "colorsToolStripMenuItem");
            // 
            // sectionToolStripMenuItem
            // 
            this.sectionToolStripMenuItem.Name = "sectionToolStripMenuItem";
            resources.ApplyResources(this.sectionToolStripMenuItem, "sectionToolStripMenuItem");
            this.sectionToolStripMenuItem.Click += new System.EventHandler(this.sectionToolStripMenuItem_Click);
            // 
            // fieldToolStripMenuItem1
            // 
            this.fieldToolStripMenuItem1.Name = "fieldToolStripMenuItem1";
            resources.ApplyResources(this.fieldToolStripMenuItem1, "fieldToolStripMenuItem1");
            this.fieldToolStripMenuItem1.Click += new System.EventHandler(this.fieldToolStripMenuItem1_Click);
            // 
            // toolStripUnitsMenu
            // 
            this.toolStripUnitsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.metricToolStrip,
            this.imperialToolStrip});
            this.toolStripUnitsMenu.Name = "toolStripUnitsMenu";
            resources.ApplyResources(this.toolStripUnitsMenu, "toolStripUnitsMenu");
            // 
            // metricToolStrip
            // 
            this.metricToolStrip.CheckOnClick = true;
            this.metricToolStrip.Name = "metricToolStrip";
            resources.ApplyResources(this.metricToolStrip, "metricToolStrip");
            this.metricToolStrip.Click += new System.EventHandler(this.metricToolStrip_Click);
            // 
            // imperialToolStrip
            // 
            this.imperialToolStrip.CheckOnClick = true;
            this.imperialToolStrip.Name = "imperialToolStrip";
            resources.ApplyResources(this.imperialToolStrip, "imperialToolStrip");
            this.imperialToolStrip.Click += new System.EventHandler(this.imperialToolStrip_Click);
            // 
            // bigAltitudeToolStripMenuItem
            // 
            this.bigAltitudeToolStripMenuItem.Checked = true;
            this.bigAltitudeToolStripMenuItem.CheckOnClick = true;
            this.bigAltitudeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bigAltitudeToolStripMenuItem.Name = "bigAltitudeToolStripMenuItem";
            resources.ApplyResources(this.bigAltitudeToolStripMenuItem, "bigAltitudeToolStripMenuItem");
            this.bigAltitudeToolStripMenuItem.Click += new System.EventHandler(this.bigAltitudeToolStripMenuItem_Click);
            // 
            // sideGuideLines
            // 
            this.sideGuideLines.Checked = true;
            this.sideGuideLines.CheckOnClick = true;
            this.sideGuideLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sideGuideLines.Name = "sideGuideLines";
            resources.ApplyResources(this.sideGuideLines, "sideGuideLines");
            this.sideGuideLines.Click += new System.EventHandler(this.sideGuideLines_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            resources.ApplyResources(this.gridToolStripMenuItem, "gridToolStripMenuItem");
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // lightbarToolStripMenuItem
            // 
            this.lightbarToolStripMenuItem.Name = "lightbarToolStripMenuItem";
            resources.ApplyResources(this.lightbarToolStripMenuItem, "lightbarToolStripMenuItem");
            this.lightbarToolStripMenuItem.Click += new System.EventHandler(this.lightbarToolStripMenuItem_Click);
            // 
            // logNMEAMenuItem
            // 
            this.logNMEAMenuItem.Name = "logNMEAMenuItem";
            resources.ApplyResources(this.logNMEAMenuItem, "logNMEAMenuItem");
            this.logNMEAMenuItem.Click += new System.EventHandler(this.logNMEAMenuItem_Click);
            // 
            // polygonsToolStripMenuItem
            // 
            this.polygonsToolStripMenuItem.Checked = true;
            this.polygonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.polygonsToolStripMenuItem.Name = "polygonsToolStripMenuItem";
            resources.ApplyResources(this.polygonsToolStripMenuItem, "polygonsToolStripMenuItem");
            this.polygonsToolStripMenuItem.Click += new System.EventHandler(this.polygonsToolStripMenuItem_Click);
            // 
            // pursuitLineToolStripMenuItem
            // 
            this.pursuitLineToolStripMenuItem.Checked = true;
            this.pursuitLineToolStripMenuItem.CheckOnClick = true;
            this.pursuitLineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pursuitLineToolStripMenuItem.Name = "pursuitLineToolStripMenuItem";
            resources.ApplyResources(this.pursuitLineToolStripMenuItem, "pursuitLineToolStripMenuItem");
            this.pursuitLineToolStripMenuItem.Click += new System.EventHandler(this.pursuitLineToolStripMenuItem_Click);
            // 
            // skyToolStripMenu
            // 
            this.skyToolStripMenu.Checked = true;
            this.skyToolStripMenu.CheckOnClick = true;
            this.skyToolStripMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.skyToolStripMenu.Name = "skyToolStripMenu";
            resources.ApplyResources(this.skyToolStripMenu, "skyToolStripMenu");
            this.skyToolStripMenu.Click += new System.EventHandler(this.skyToolStripMenu_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // simulatorOnToolStripMenuItem
            // 
            this.simulatorOnToolStripMenuItem.Checked = true;
            this.simulatorOnToolStripMenuItem.CheckOnClick = true;
            this.simulatorOnToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.simulatorOnToolStripMenuItem.Name = "simulatorOnToolStripMenuItem";
            resources.ApplyResources(this.simulatorOnToolStripMenuItem, "simulatorOnToolStripMenuItem");
            this.simulatorOnToolStripMenuItem.Click += new System.EventHandler(this.simulatorOnToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // tmrWatchdog
            // 
            this.tmrWatchdog.Interval = 50;
            this.tmrWatchdog.Tick += new System.EventHandler(this.tmrWatchdog_tick);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripHz,
            this.toolStripDropDownButton2,
            this.stripDistance,
            this.toolStripDropDownBtnFuncs,
            this.stripAreaRate,
            this.btnHideTabs,
            this.stripEqWidth,
            this.stripPortGPS,
            this.stripOnlineGPS,
            this.stripPortArduino,
            this.stripOnlineArduino,
            this.stripPortAutoSteer,
            this.stripOnlineAutoSteer});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            // 
            // stripHz
            // 
            resources.ApplyResources(this.stripHz, "stripHz");
            this.stripHz.Margin = new System.Windows.Forms.Padding(0);
            this.stripHz.Name = "stripHz";
            // 
            // toolStripDropDownButton2
            // 
            resources.ApplyResources(this.toolStripDropDownButton2, "toolStripDropDownButton2");
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripUDPConfig,
            this.toolstripUSBPortsConfig,
            this.toolstripDisplayConfig,
            this.toolstripVehicleConfig,
            this.toolstripAutoSteerConfig,
            this.toolstripYouTurnConfig});
            this.toolStripDropDownButton2.Image = global::AgraBot.Properties.Resources.SetupStatusStrip;
            this.toolStripDropDownButton2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.ShowDropDownArrow = false;
            // 
            // toolstripUDPConfig
            // 
            this.toolstripUDPConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripUDPConfig, "toolstripUDPConfig");
            this.toolstripUDPConfig.Name = "toolstripUDPConfig";
            this.toolstripUDPConfig.Click += new System.EventHandler(this.toolstripUDPConfig_Click);
            // 
            // toolstripUSBPortsConfig
            // 
            this.toolstripUSBPortsConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripUSBPortsConfig, "toolstripUSBPortsConfig");
            this.toolstripUSBPortsConfig.Name = "toolstripUSBPortsConfig";
            this.toolstripUSBPortsConfig.Click += new System.EventHandler(this.toolstripUSBPortsConfig_Click);
            // 
            // toolstripDisplayConfig
            // 
            this.toolstripDisplayConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripDisplayConfig, "toolstripDisplayConfig");
            this.toolstripDisplayConfig.Image = global::AgraBot.Properties.Resources.gyro;
            this.toolstripDisplayConfig.Name = "toolstripDisplayConfig";
            this.toolstripDisplayConfig.Click += new System.EventHandler(this.toolstripDisplayConfig_Click);
            // 
            // toolstripVehicleConfig
            // 
            this.toolstripVehicleConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripVehicleConfig, "toolstripVehicleConfig");
            this.toolstripVehicleConfig.Name = "toolstripVehicleConfig";
            this.toolstripVehicleConfig.Click += new System.EventHandler(this.toolstripVehicleConfig_Click);
            // 
            // toolstripAutoSteerConfig
            // 
            this.toolstripAutoSteerConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripAutoSteerConfig, "toolstripAutoSteerConfig");
            this.toolstripAutoSteerConfig.Name = "toolstripAutoSteerConfig";
            this.toolstripAutoSteerConfig.Click += new System.EventHandler(this.toolstripAutoSteerConfig_Click);
            // 
            // toolstripYouTurnConfig
            // 
            this.toolstripYouTurnConfig.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripYouTurnConfig, "toolstripYouTurnConfig");
            this.toolstripYouTurnConfig.Name = "toolstripYouTurnConfig";
            // 
            // stripDistance
            // 
            resources.ApplyResources(this.stripDistance, "stripDistance");
            this.stripDistance.Margin = new System.Windows.Forms.Padding(-4, 0, 0, 0);
            this.stripDistance.Name = "stripDistance";
            // 
            // toolStripDropDownBtnFuncs
            // 
            resources.ApplyResources(this.toolStripDropDownBtnFuncs, "toolStripDropDownBtnFuncs");
            this.toolStripDropDownBtnFuncs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripField,
            this.toolstripBoundary,
            this.toolstripHeadland,
            this.toolstripResetTrip});
            this.toolStripDropDownBtnFuncs.Image = global::AgraBot.Properties.Resources.start;
            this.toolStripDropDownBtnFuncs.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.toolStripDropDownBtnFuncs.Name = "toolStripDropDownBtnFuncs";
            this.toolStripDropDownBtnFuncs.ShowDropDownArrow = false;
            // 
            // toolstripField
            // 
            this.toolstripField.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripField, "toolstripField");
            this.toolstripField.Name = "toolstripField";
            this.toolstripField.Click += new System.EventHandler(this.toolstripField_Click);
            // 
            // toolstripBoundary
            // 
            this.toolstripBoundary.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripBoundary, "toolstripBoundary");
            this.toolstripBoundary.Name = "toolstripBoundary";
            this.toolstripBoundary.Click += new System.EventHandler(this.toolstripBoundary_Click);
            // 
            // toolstripHeadland
            // 
            this.toolstripHeadland.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripHeadland, "toolstripHeadland");
            this.toolstripHeadland.Name = "toolstripHeadland";
            // 
            // toolstripResetTrip
            // 
            this.toolstripResetTrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.toolstripResetTrip, "toolstripResetTrip");
            this.toolstripResetTrip.Name = "toolstripResetTrip";
            this.toolstripResetTrip.Click += new System.EventHandler(this.toolstripResetTrip_Click_1);
            // 
            // stripAreaRate
            // 
            resources.ApplyResources(this.stripAreaRate, "stripAreaRate");
            this.stripAreaRate.Margin = new System.Windows.Forms.Padding(0);
            this.stripAreaRate.Name = "stripAreaRate";
            // 
            // btnHideTabs
            // 
            resources.ApplyResources(this.btnHideTabs, "btnHideTabs");
            this.btnHideTabs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHideTabs.Name = "btnHideTabs";
            this.btnHideTabs.ShowDropDownArrow = false;
            this.btnHideTabs.Click += new System.EventHandler(this.btnHideTabs_Click);
            // 
            // stripEqWidth
            // 
            this.stripEqWidth.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.stripEqWidth, "stripEqWidth");
            this.stripEqWidth.Margin = new System.Windows.Forms.Padding(0);
            this.stripEqWidth.Name = "stripEqWidth";
            this.stripEqWidth.Spring = true;
            // 
            // stripPortGPS
            // 
            this.stripPortGPS.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            resources.ApplyResources(this.stripPortGPS, "stripPortGPS");
            this.stripPortGPS.ForeColor = System.Drawing.Color.Red;
            this.stripPortGPS.Name = "stripPortGPS";
            // 
            // stripOnlineGPS
            // 
            resources.ApplyResources(this.stripOnlineGPS, "stripOnlineGPS");
            this.stripOnlineGPS.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.stripOnlineGPS.Name = "stripOnlineGPS";
            this.stripOnlineGPS.Value = 1;
            // 
            // stripPortArduino
            // 
            resources.ApplyResources(this.stripPortArduino, "stripPortArduino");
            this.stripPortArduino.ForeColor = System.Drawing.Color.Red;
            this.stripPortArduino.Name = "stripPortArduino";
            // 
            // stripOnlineArduino
            // 
            this.stripOnlineArduino.AutoToolTip = true;
            this.stripOnlineArduino.ForeColor = System.Drawing.Color.Chartreuse;
            this.stripOnlineArduino.Name = "stripOnlineArduino";
            resources.ApplyResources(this.stripOnlineArduino, "stripOnlineArduino");
            this.stripOnlineArduino.Value = 1;
            // 
            // stripPortAutoSteer
            // 
            resources.ApplyResources(this.stripPortAutoSteer, "stripPortAutoSteer");
            this.stripPortAutoSteer.ForeColor = System.Drawing.Color.Red;
            this.stripPortAutoSteer.Name = "stripPortAutoSteer";
            // 
            // stripOnlineAutoSteer
            // 
            this.stripOnlineAutoSteer.AutoToolTip = true;
            this.stripOnlineAutoSteer.ForeColor = System.Drawing.Color.Chartreuse;
            this.stripOnlineAutoSteer.Name = "stripOnlineAutoSteer";
            resources.ApplyResources(this.stripOnlineAutoSteer, "stripOnlineAutoSteer");
            this.stripOnlineAutoSteer.Value = 1;
            // 
            // lblNorthing
            // 
            resources.ApplyResources(this.lblNorthing, "lblNorthing");
            this.lblNorthing.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblNorthing.Name = "lblNorthing";
            // 
            // lblEasting
            // 
            resources.ApplyResources(this.lblEasting, "lblEasting");
            this.lblEasting.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblEasting.Name = "lblEasting";
            // 
            // lblSpeed
            // 
            resources.ApplyResources(this.lblSpeed, "lblSpeed");
            this.lblSpeed.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSpeed.Name = "lblSpeed";
            // 
            // tboxSentence
            // 
            resources.ApplyResources(this.tboxSentence, "tboxSentence");
            this.tboxSentence.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxSentence.Name = "tboxSentence";
            this.tboxSentence.ReadOnly = true;
            // 
            // lblZone
            // 
            resources.ApplyResources(this.lblZone, "lblZone");
            this.lblZone.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblZone.Name = "lblZone";
            // 
            // lblSpeedUnits
            // 
            resources.ApplyResources(this.lblSpeedUnits, "lblSpeedUnits");
            this.lblSpeedUnits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSpeedUnits.Name = "lblSpeedUnits";
            // 
            // lblHeading
            // 
            resources.ApplyResources(this.lblHeading, "lblHeading");
            this.lblHeading.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblHeading.Name = "lblHeading";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SettingsGear64.png");
            this.imageList1.Images.SetKeyName(1, "Satellite64.png");
            this.imageList1.Images.SetKeyName(2, "Rate64.png");
            this.imageList1.Images.SetKeyName(3, "FieldView.png");
            // 
            // openGLControlZoom
            // 
            this.openGLControlZoom.DrawFPS = false;
            resources.ApplyResources(this.openGLControlZoom, "openGLControlZoom");
            this.openGLControlZoom.Name = "openGLControlZoom";
            this.openGLControlZoom.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlZoom.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControlZoom.RenderTrigger = SharpGL.RenderTrigger.Manual;
            this.openGLControlZoom.OpenGLInitialized += new System.EventHandler(this.openGLControlZoom_OpenGLInitialized);
            this.openGLControlZoom.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlZoom_OpenGLDraw);
            this.openGLControlZoom.Resized += new System.EventHandler(this.openGLControlZoom_Resized);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Name = "label4";
            // 
            // lblFieldWidthNorthSouth
            // 
            resources.ApplyResources(this.lblFieldWidthNorthSouth, "lblFieldWidthNorthSouth");
            this.lblFieldWidthNorthSouth.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFieldWidthNorthSouth.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFieldWidthNorthSouth.Name = "lblFieldWidthNorthSouth";
            // 
            // lblFieldWidthEastWest
            // 
            resources.ApplyResources(this.lblFieldWidthEastWest, "lblFieldWidthEastWest");
            this.lblFieldWidthEastWest.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblFieldWidthEastWest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFieldWidthEastWest.Name = "lblFieldWidthEastWest";
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.DataPage);
            this.tabControl1.Controls.Add(this.zoomPage2);
            this.tabControl1.Controls.Add(this.configPage1);
            this.tabControl1.Controls.Add(this.autoPage4);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            // 
            // DataPage
            // 
            this.DataPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DataPage.Controls.Add(this.tboxFromUDP);
            this.DataPage.Controls.Add(this.lblEmlidPitch);
            this.DataPage.Controls.Add(this.label20);
            this.DataPage.Controls.Add(this.lblSats);
            this.DataPage.Controls.Add(this.label17);
            this.DataPage.Controls.Add(this.lblFixQuality);
            this.DataPage.Controls.Add(this.label16);
            this.DataPage.Controls.Add(this.lblAltitude);
            this.DataPage.Controls.Add(this.label19);
            this.DataPage.Controls.Add(this.label18);
            this.DataPage.Controls.Add(this.lblLongitude);
            this.DataPage.Controls.Add(this.lblLatitude);
            this.DataPage.Controls.Add(this.label15);
            this.DataPage.Controls.Add(this.label14);
            this.DataPage.Controls.Add(this.lblHeadlandDistanceFromTool);
            this.DataPage.Controls.Add(this.label7);
            this.DataPage.Controls.Add(this.lblHeadlandDistanceAway);
            this.DataPage.Controls.Add(this.lblBoundaryArea);
            this.DataPage.Controls.Add(this.lblRoll);
            this.DataPage.Controls.Add(this.lblGPSHeading);
            this.DataPage.Controls.Add(this.lblYawHeading);
            this.DataPage.Controls.Add(this.tboxSentence);
            this.DataPage.Controls.Add(this.label10);
            this.DataPage.Controls.Add(this.label9);
            this.DataPage.Controls.Add(this.label8);
            this.DataPage.Controls.Add(this.lblEasting);
            this.DataPage.Controls.Add(this.lblNorthing);
            this.DataPage.Controls.Add(this.lblZone);
            this.DataPage.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.DataPage, "DataPage");
            this.DataPage.Name = "DataPage";
            // 
            // tboxFromUDP
            // 
            resources.ApplyResources(this.tboxFromUDP, "tboxFromUDP");
            this.tboxFromUDP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tboxFromUDP.Name = "tboxFromUDP";
            this.tboxFromUDP.ReadOnly = true;
            // 
            // lblEmlidPitch
            // 
            resources.ApplyResources(this.lblEmlidPitch, "lblEmlidPitch");
            this.lblEmlidPitch.Name = "lblEmlidPitch";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // lblSats
            // 
            resources.ApplyResources(this.lblSats, "lblSats");
            this.lblSats.Name = "lblSats";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // lblFixQuality
            // 
            resources.ApplyResources(this.lblFixQuality, "lblFixQuality");
            this.lblFixQuality.Name = "lblFixQuality";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // lblAltitude
            // 
            resources.ApplyResources(this.lblAltitude, "lblAltitude");
            this.lblAltitude.Name = "lblAltitude";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // lblLongitude
            // 
            resources.ApplyResources(this.lblLongitude, "lblLongitude");
            this.lblLongitude.Name = "lblLongitude";
            // 
            // lblLatitude
            // 
            resources.ApplyResources(this.lblLatitude, "lblLatitude");
            this.lblLatitude.Name = "lblLatitude";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // lblHeadlandDistanceFromTool
            // 
            resources.ApplyResources(this.lblHeadlandDistanceFromTool, "lblHeadlandDistanceFromTool");
            this.lblHeadlandDistanceFromTool.Name = "lblHeadlandDistanceFromTool";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblHeadlandDistanceAway
            // 
            resources.ApplyResources(this.lblHeadlandDistanceAway, "lblHeadlandDistanceAway");
            this.lblHeadlandDistanceAway.Name = "lblHeadlandDistanceAway";
            // 
            // lblBoundaryArea
            // 
            resources.ApplyResources(this.lblBoundaryArea, "lblBoundaryArea");
            this.lblBoundaryArea.Name = "lblBoundaryArea";
            // 
            // lblRoll
            // 
            resources.ApplyResources(this.lblRoll, "lblRoll");
            this.lblRoll.Name = "lblRoll";
            // 
            // lblGPSHeading
            // 
            resources.ApplyResources(this.lblGPSHeading, "lblGPSHeading");
            this.lblGPSHeading.Name = "lblGPSHeading";
            // 
            // lblYawHeading
            // 
            resources.ApplyResources(this.lblYawHeading, "lblYawHeading");
            this.lblYawHeading.Name = "lblYawHeading";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // zoomPage2
            // 
            this.zoomPage2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.zoomPage2.Controls.Add(this.btnDeleteAllData);
            this.zoomPage2.Controls.Add(this.openGLControlZoom);
            this.zoomPage2.Controls.Add(this.label6);
            this.zoomPage2.Controls.Add(this.lblZooom);
            this.zoomPage2.Controls.Add(this.label5);
            this.zoomPage2.Controls.Add(this.label4);
            this.zoomPage2.Controls.Add(this.lblFieldWidthEastWest);
            this.zoomPage2.Controls.Add(this.lblFieldWidthNorthSouth);
            resources.ApplyResources(this.zoomPage2, "zoomPage2");
            this.zoomPage2.Name = "zoomPage2";
            // 
            // btnDeleteAllData
            // 
            this.btnDeleteAllData.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnDeleteAllData, "btnDeleteAllData");
            this.btnDeleteAllData.Name = "btnDeleteAllData";
            this.btnDeleteAllData.UseVisualStyleBackColor = false;
            this.btnDeleteAllData.Click += new System.EventHandler(this.btnDeleteAllData_Click);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Name = "label6";
            // 
            // lblZooom
            // 
            resources.ApplyResources(this.lblZooom, "lblZooom");
            this.lblZooom.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblZooom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblZooom.Name = "lblZooom";
            // 
            // configPage1
            // 
            this.configPage1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.configPage1.Controls.Add(this.btnWebCam);
            this.configPage1.Controls.Add(this.btnHelp);
            this.configPage1.Controls.Add(this.btnFileExplorer);
            this.configPage1.Controls.Add(this.btnGPSData);
            resources.ApplyResources(this.configPage1, "configPage1");
            this.configPage1.Name = "configPage1";
            // 
            // btnWebCam
            // 
            this.btnWebCam.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnWebCam, "btnWebCam");
            this.btnWebCam.Name = "btnWebCam";
            this.btnWebCam.UseVisualStyleBackColor = false;
            this.btnWebCam.Click += new System.EventHandler(this.btnWebCam_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnFileExplorer
            // 
            this.btnFileExplorer.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnFileExplorer, "btnFileExplorer");
            this.btnFileExplorer.Name = "btnFileExplorer";
            this.btnFileExplorer.UseVisualStyleBackColor = false;
            this.btnFileExplorer.Click += new System.EventHandler(this.btnFileExplorer_Click);
            // 
            // btnGPSData
            // 
            this.btnGPSData.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnGPSData, "btnGPSData");
            this.btnGPSData.Name = "btnGPSData";
            this.btnGPSData.UseVisualStyleBackColor = false;
            this.btnGPSData.Click += new System.EventHandler(this.btnGPSData_Click);
            // 
            // autoPage4
            // 
            resources.ApplyResources(this.autoPage4, "autoPage4");
            this.autoPage4.Name = "autoPage4";
            this.autoPage4.UseVisualStyleBackColor = true;
            // 
            // btnDrivePath
            // 
            this.btnDrivePath.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnDrivePath, "btnDrivePath");
            this.btnDrivePath.Name = "btnDrivePath";
            this.btnDrivePath.UseVisualStyleBackColor = false;
            this.btnDrivePath.Click += new System.EventHandler(this.btnDrivePath_Click);
            // 
            // btnResetSim
            // 
            resources.ApplyResources(this.btnResetSim, "btnResetSim");
            this.btnResetSim.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnResetSim.Name = "btnResetSim";
            this.btnResetSim.UseVisualStyleBackColor = false;
            this.btnResetSim.Click += new System.EventHandler(this.btnResetSim_Click);
            // 
            // btnResetSteerAngle
            // 
            resources.ApplyResources(this.btnResetSteerAngle, "btnResetSteerAngle");
            this.btnResetSteerAngle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnResetSteerAngle.Name = "btnResetSteerAngle";
            this.btnResetSteerAngle.UseVisualStyleBackColor = false;
            this.btnResetSteerAngle.Click += new System.EventHandler(this.btnResetSteerAngle_Click);
            // 
            // lblPureSteerAngle
            // 
            resources.ApplyResources(this.lblPureSteerAngle, "lblPureSteerAngle");
            this.lblPureSteerAngle.Name = "lblPureSteerAngle";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // lblSteerAngle
            // 
            resources.ApplyResources(this.lblSteerAngle, "lblSteerAngle");
            this.lblSteerAngle.Name = "lblSteerAngle";
            // 
            // tbarSteerAngle
            // 
            resources.ApplyResources(this.tbarSteerAngle, "tbarSteerAngle");
            this.tbarSteerAngle.LargeChange = 10;
            this.tbarSteerAngle.Maximum = 300;
            this.tbarSteerAngle.Minimum = -300;
            this.tbarSteerAngle.Name = "tbarSteerAngle";
            this.tbarSteerAngle.TickFrequency = 30;
            this.tbarSteerAngle.Scroll += new System.EventHandler(this.tbarSteerAngle_Scroll);
            // 
            // tbarStepDistance
            // 
            resources.ApplyResources(this.tbarStepDistance, "tbarStepDistance");
            this.tbarStepDistance.LargeChange = 10;
            this.tbarStepDistance.Maximum = 300;
            this.tbarStepDistance.Name = "tbarStepDistance";
            this.tbarStepDistance.TickFrequency = 10;
            this.tbarStepDistance.Value = 20;
            this.tbarStepDistance.Scroll += new System.EventHandler(this.tbarStepDistance_Scroll);
            // 
            // timerSim
            // 
            this.timerSim.Enabled = true;
            this.timerSim.Interval = 200;
            this.timerSim.Tick += new System.EventHandler(this.timerSim_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // panelSimControls
            // 
            resources.ApplyResources(this.panelSimControls, "panelSimControls");
            this.panelSimControls.Controls.Add(this.btnResetSteerAngle);
            this.panelSimControls.Controls.Add(this.label3);
            this.panelSimControls.Controls.Add(this.btnResetSim);
            this.panelSimControls.Controls.Add(this.lblSteerAngle);
            this.panelSimControls.Controls.Add(this.label11);
            this.panelSimControls.Controls.Add(this.label12);
            this.panelSimControls.Controls.Add(this.tbarSteerAngle);
            this.panelSimControls.Controls.Add(this.tbarStepDistance);
            this.panelSimControls.Name = "panelSimControls";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnTiltDown
            // 
            resources.ApplyResources(this.btnTiltDown, "btnTiltDown");
            this.btnTiltDown.BackColor = System.Drawing.Color.Lavender;
            this.btnTiltDown.Name = "btnTiltDown";
            this.btnTiltDown.UseVisualStyleBackColor = false;
            this.btnTiltDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTiltDown_MouseDown);
            // 
            // btnTiltUp
            // 
            resources.ApplyResources(this.btnTiltUp, "btnTiltUp");
            this.btnTiltUp.BackColor = System.Drawing.Color.Lavender;
            this.btnTiltUp.Name = "btnTiltUp";
            this.btnTiltUp.UseVisualStyleBackColor = false;
            this.btnTiltUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTiltUp_MouseDown);
            // 
            // btnZoomIn
            // 
            resources.ApplyResources(this.btnZoomIn, "btnZoomIn");
            this.btnZoomIn.BackColor = System.Drawing.Color.Lavender;
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomIn_MouseDown);
            // 
            // btnZoomOut
            // 
            resources.ApplyResources(this.btnZoomOut, "btnZoomOut");
            this.btnZoomOut.BackColor = System.Drawing.Color.Lavender;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnZoomOut_MouseDown);
            // 
            // btnSectionOffAutoOn
            // 
            resources.ApplyResources(this.btnSectionOffAutoOn, "btnSectionOffAutoOn");
            this.btnSectionOffAutoOn.BackColor = System.Drawing.Color.Lavender;
            this.btnSectionOffAutoOn.Name = "btnSectionOffAutoOn";
            this.btnSectionOffAutoOn.UseVisualStyleBackColor = false;
            this.btnSectionOffAutoOn.Click += new System.EventHandler(this.btnSectionOffAutoOn_Click);
            // 
            // btnManualOffOn
            // 
            resources.ApplyResources(this.btnManualOffOn, "btnManualOffOn");
            this.btnManualOffOn.BackColor = System.Drawing.Color.Lavender;
            this.btnManualOffOn.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnManualOffOn.Name = "btnManualOffOn";
            this.btnManualOffOn.UseVisualStyleBackColor = false;
            this.btnManualOffOn.Click += new System.EventHandler(this.btnManualOffOn_Click);
            // 
            // btnSection8Man
            // 
            resources.ApplyResources(this.btnSection8Man, "btnSection8Man");
            this.btnSection8Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection8Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection8Man.FlatAppearance.BorderSize = 0;
            this.btnSection8Man.Name = "btnSection8Man";
            this.btnSection8Man.UseVisualStyleBackColor = false;
            this.btnSection8Man.Click += new System.EventHandler(this.btnSection8Man_Click);
            // 
            // btnSection7Man
            // 
            resources.ApplyResources(this.btnSection7Man, "btnSection7Man");
            this.btnSection7Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection7Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection7Man.FlatAppearance.BorderSize = 0;
            this.btnSection7Man.Name = "btnSection7Man";
            this.btnSection7Man.UseVisualStyleBackColor = false;
            this.btnSection7Man.Click += new System.EventHandler(this.btnSection7Man_Click);
            // 
            // btnSection6Man
            // 
            resources.ApplyResources(this.btnSection6Man, "btnSection6Man");
            this.btnSection6Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection6Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection6Man.FlatAppearance.BorderSize = 0;
            this.btnSection6Man.Name = "btnSection6Man";
            this.btnSection6Man.UseVisualStyleBackColor = false;
            this.btnSection6Man.Click += new System.EventHandler(this.btnSection6Man_Click);
            // 
            // btnSection5Man
            // 
            resources.ApplyResources(this.btnSection5Man, "btnSection5Man");
            this.btnSection5Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection5Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection5Man.FlatAppearance.BorderSize = 0;
            this.btnSection5Man.Name = "btnSection5Man";
            this.btnSection5Man.UseVisualStyleBackColor = false;
            this.btnSection5Man.Click += new System.EventHandler(this.btnSection5Man_Click);
            // 
            // btnSection4Man
            // 
            resources.ApplyResources(this.btnSection4Man, "btnSection4Man");
            this.btnSection4Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection4Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection4Man.FlatAppearance.BorderSize = 0;
            this.btnSection4Man.Name = "btnSection4Man";
            this.btnSection4Man.UseVisualStyleBackColor = false;
            this.btnSection4Man.Click += new System.EventHandler(this.btnSection4Man_Click);
            // 
            // btnSection3Man
            // 
            resources.ApplyResources(this.btnSection3Man, "btnSection3Man");
            this.btnSection3Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection3Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection3Man.FlatAppearance.BorderSize = 0;
            this.btnSection3Man.Name = "btnSection3Man";
            this.btnSection3Man.UseVisualStyleBackColor = false;
            this.btnSection3Man.Click += new System.EventHandler(this.btnSection3Man_Click);
            // 
            // btnSection2Man
            // 
            resources.ApplyResources(this.btnSection2Man, "btnSection2Man");
            this.btnSection2Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection2Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection2Man.FlatAppearance.BorderSize = 0;
            this.btnSection2Man.Name = "btnSection2Man";
            this.btnSection2Man.UseVisualStyleBackColor = false;
            this.btnSection2Man.Click += new System.EventHandler(this.btnSection2Man_Click);
            // 
            // btnSection1Man
            // 
            resources.ApplyResources(this.btnSection1Man, "btnSection1Man");
            this.btnSection1Man.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnSection1Man.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnSection1Man.FlatAppearance.BorderSize = 0;
            this.btnSection1Man.Name = "btnSection1Man";
            this.btnSection1Man.UseVisualStyleBackColor = false;
            this.btnSection1Man.Click += new System.EventHandler(this.btnSection1Man_Click);
            // 
            // btnStopDrivingPath
            // 
            this.btnStopDrivingPath.BackColor = System.Drawing.Color.AliceBlue;
            resources.ApplyResources(this.btnStopDrivingPath, "btnStopDrivingPath");
            this.btnStopDrivingPath.Image = global::AgraBot.Properties.Resources.Cancel64;
            this.btnStopDrivingPath.Name = "btnStopDrivingPath";
            this.btnStopDrivingPath.UseVisualStyleBackColor = false;
            this.btnStopDrivingPath.Click += new System.EventHandler(this.btnStopDrivingPath_Click);
            // 
            // FormGPS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Controls.Add(this.btnStopDrivingPath);
            this.Controls.Add(this.btnDrivePath);
            this.Controls.Add(this.btnTiltDown);
            this.Controls.Add(this.btnTiltUp);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPureSteerAngle);
            this.Controls.Add(this.btnSectionOffAutoOn);
            this.Controls.Add(this.btnManualOffOn);
            this.Controls.Add(this.lblSpeedUnits);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.txtDistanceOffABLine);
            this.Controls.Add(this.btnSection8Man);
            this.Controls.Add(this.btnSection7Man);
            this.Controls.Add(this.btnSection6Man);
            this.Controls.Add(this.btnSection5Man);
            this.Controls.Add(this.btnSection4Man);
            this.Controls.Add(this.btnSection3Man);
            this.Controls.Add(this.btnSection2Man);
            this.Controls.Add(this.btnSection1Man);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.openGLControlBack);
            this.Controls.Add(this.panelSimControls);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormGPS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGPS_FormClosing);
            this.Load += new System.EventHandler(this.FormGPS_Load);
            this.Resize += new System.EventHandler(this.FormGPS_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlBack)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlZoom)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.DataPage.ResumeLayout(false);
            this.DataPage.PerformLayout();
            this.zoomPage2.ResumeLayout(false);
            this.zoomPage2.PerformLayout();
            this.configPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbarSteerAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbarStepDistance)).EndInit();
            this.panelSimControls.ResumeLayout(false);
            this.panelSimControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private SharpGL.OpenGLControl openGLControlBack;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer tmrWatchdog;
        private System.Windows.Forms.ToolStripMenuItem polygonsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stripDistance;
        private System.Windows.Forms.ToolStripStatusLabel stripPortGPS;
        private System.Windows.Forms.ToolStripStatusLabel stripAreaRate;
        private System.Windows.Forms.ToolStripStatusLabel stripPortArduino;
        private System.Windows.Forms.ToolStripMenuItem resetALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveVehicleToolStripMenuItem;
        private System.Windows.Forms.Button btnManualOffOn;
        private System.Windows.Forms.Button btnSection1Man;
        private System.Windows.Forms.Button btnSection2Man;
        private System.Windows.Forms.Button btnSection3Man;
        private System.Windows.Forms.Button btnSection4Man;
        private System.Windows.Forms.Button btnSection5Man;
        private System.Windows.Forms.ToolStripStatusLabel stripHz;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightbarToolStripMenuItem;
        private System.Windows.Forms.Label lblNorthing;
        private System.Windows.Forms.Label lblEasting;
        private System.Windows.Forms.Label lblSpeed;
        private ProXoft.WinForms.RepeatButton btnZoomOut;
        private ProXoft.WinForms.RepeatButton btnZoomIn;
        private ProXoft.WinForms.RepeatButton btnTiltUp;
        private ProXoft.WinForms.RepeatButton btnTiltDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineGPS;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineArduino;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldToolStripMenuItem1;
        private System.Windows.Forms.Button btnSection8Man;
        private System.Windows.Forms.Button btnSection7Man;
        private System.Windows.Forms.Button btnSection6Man;
        private System.Windows.Forms.ToolStripStatusLabel stripPortAutoSteer;
        private System.Windows.Forms.ToolStripProgressBar stripOnlineAutoSteer;
        private System.Windows.Forms.ToolStripMenuItem logNMEAMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripUnitsMenu;
        private System.Windows.Forms.ToolStripMenuItem metricToolStrip;
        private System.Windows.Forms.ToolStripMenuItem imperialToolStrip;
        private System.Windows.Forms.ToolStripMenuItem skyToolStripMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.TextBox tboxSentence;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Button btnGPSData;
        private System.Windows.Forms.Button btnFileExplorer;
        private System.Windows.Forms.Label lblSpeedUnits;
        private System.Windows.Forms.ToolStripMenuItem sideGuideLines;
        private System.Windows.Forms.ToolStripMenuItem pursuitLineToolStripMenuItem;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.ImageList imageList1;
        private SharpGL.OpenGLControl openGLControlZoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFieldWidthNorthSouth;
        private System.Windows.Forms.Label lblFieldWidthEastWest;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage configPage1;
        private System.Windows.Forms.TabPage zoomPage2;
        private System.Windows.Forms.TabPage DataPage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblZooom;
        private System.Windows.Forms.Timer timerSim;
        private System.Windows.Forms.TrackBar tbarStepDistance;
        private System.Windows.Forms.TrackBar tbarSteerAngle;
        private System.Windows.Forms.Button btnResetSteerAngle;
        private System.Windows.Forms.Label lblSteerAngle;
        private System.Windows.Forms.Button btnResetSim;
        private System.Windows.Forms.ToolStripMenuItem simulatorOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownBtnFuncs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Label lblPureSteerAngle;
        private System.Windows.Forms.Label lblGPSHeading;
        private System.Windows.Forms.Label lblYawHeading;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem toolstripUSBPortsConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripVehicleConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripAutoSteerConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripYouTurnConfig;
        private System.Windows.Forms.ToolStripMenuItem toolstripResetTrip;
        private System.Windows.Forms.ToolStripMenuItem toolstripField;
        private System.Windows.Forms.ToolStripMenuItem toolstripBoundary;
        private System.Windows.Forms.ToolStripMenuItem toolstripHeadland;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHeadlandDistanceAway;
        private System.Windows.Forms.Label lblBoundaryArea;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblHeadlandDistanceFromTool;
        private System.Windows.Forms.ToolStripMenuItem toolstripUDPConfig;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblFixQuality;
        private System.Windows.Forms.Label lblSats;
        private System.Windows.Forms.Panel panelSimControls;
        private System.Windows.Forms.ToolStripDropDownButton btnHideTabs;
        public System.Windows.Forms.Button btnSectionOffAutoOn;
        private System.Windows.Forms.ToolStripStatusLabel stripEqWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem bigAltitudeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menustripLanguage;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageEnglish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDeutsch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripMenuItem setWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageRussian;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageDutch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageSpanish;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageFrench;
        private System.Windows.Forms.ToolStripMenuItem menuLanguageItalian;
        private System.Windows.Forms.Label lblEmlidPitch;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.TextBox txtDistanceOffABLine;
        private System.Windows.Forms.TabPage autoPage4;
        private System.Windows.Forms.Button btnWebCam;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button btnDeleteAllData;
        private System.Windows.Forms.ToolStripMenuItem toolstripDisplayConfig;
        private System.Windows.Forms.Button btnDrivePath;
        public System.Windows.Forms.Button btnStopDrivingPath;
        private System.Windows.Forms.TextBox tboxFromUDP;
    }
}

