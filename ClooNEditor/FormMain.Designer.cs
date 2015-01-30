namespace ClooNEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <para Name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</para>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDevice = new System.Windows.Forms.ComboBox();
            this.groupBoxDeviceInfo = new System.Windows.Forms.GroupBox();
            this.listBoxExtensions = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelProfile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelVendor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonImplicit = new System.Windows.Forms.RadioButton();
            this.radioButtonExplicit = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSeed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonRound = new System.Windows.Forms.Button();
            this.buttonPower = new System.Windows.Forms.Button();
            this.buttonMax = new System.Windows.Forms.Button();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonLerp = new System.Windows.Forms.Button();
            this.buttonAbs = new System.Windows.Forms.Button();
            this.buttonVoronoi = new System.Windows.Forms.Button();
            this.buttonTurbulence = new System.Windows.Forms.Button();
            this.buttonRMF = new System.Windows.Forms.Button();
            this.buttonFBM = new System.Windows.Forms.Button();
            this.labelParseMessage = new System.Windows.Forms.Label();
            this.timerRefresher = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelResolution = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelCloonTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelOverhead = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonContrastSub = new System.Windows.Forms.Button();
            this.buttonContrastAdd = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonZUp = new System.Windows.Forms.Button();
            this.buttonZDown = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonResetPosition = new System.Windows.Forms.Button();
            this.buttonShiftRight = new System.Windows.Forms.Button();
            this.buttonShiftLeft = new System.Windows.Forms.Button();
            this.buttonShiftUp = new System.Windows.Forms.Button();
            this.buttonShiftDown = new System.Windows.Forms.Button();
            this.toolTipButtons = new System.Windows.Forms.ToolTip(this.components);
            this.timerButtonDown = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.boxCode = new System.Windows.Forms.TextBox();
            this.groupBoxDeviceInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // comboBoxDevice
            // 
            this.comboBoxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDevice.FormattingEnabled = true;
            this.comboBoxDevice.Location = new System.Drawing.Point(3, 16);
            this.comboBoxDevice.Name = "comboBoxDevice";
            this.comboBoxDevice.Size = new System.Drawing.Size(250, 21);
            this.comboBoxDevice.TabIndex = 0;
            this.comboBoxDevice.SelectedValueChanged += new System.EventHandler(this.comboBoxDevice_SelectedValueChanged);
            // 
            // groupBoxDeviceInfo
            // 
            this.groupBoxDeviceInfo.Controls.Add(this.listBoxExtensions);
            this.groupBoxDeviceInfo.Controls.Add(this.label5);
            this.groupBoxDeviceInfo.Controls.Add(this.labelVersion);
            this.groupBoxDeviceInfo.Controls.Add(this.label4);
            this.groupBoxDeviceInfo.Controls.Add(this.labelProfile);
            this.groupBoxDeviceInfo.Controls.Add(this.label3);
            this.groupBoxDeviceInfo.Controls.Add(this.labelVendor);
            this.groupBoxDeviceInfo.Controls.Add(this.label2);
            this.groupBoxDeviceInfo.Location = new System.Drawing.Point(3, 43);
            this.groupBoxDeviceInfo.Name = "groupBoxDeviceInfo";
            this.groupBoxDeviceInfo.Size = new System.Drawing.Size(250, 151);
            this.groupBoxDeviceInfo.TabIndex = 3;
            this.groupBoxDeviceInfo.TabStop = false;
            this.groupBoxDeviceInfo.Text = "Device Info";
            // 
            // listBoxExtensions
            // 
            this.listBoxExtensions.FormattingEnabled = true;
            this.listBoxExtensions.Location = new System.Drawing.Point(9, 71);
            this.listBoxExtensions.Name = "listBoxExtensions";
            this.listBoxExtensions.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxExtensions.Size = new System.Drawing.Size(235, 69);
            this.listBoxExtensions.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Extensions:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(56, 42);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(55, 13);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = "VERSION";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Version:";
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(56, 29);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(52, 13);
            this.labelProfile.TabIndex = 3;
            this.labelProfile.Text = "PROFILE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Profile:";
            // 
            // labelVendor
            // 
            this.labelVendor.AutoSize = true;
            this.labelVendor.Location = new System.Drawing.Point(56, 16);
            this.labelVendor.Name = "labelVendor";
            this.labelVendor.Size = new System.Drawing.Size(53, 13);
            this.labelVendor.TabIndex = 1;
            this.labelVendor.Text = "VENDOR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vendor:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.radioButtonImplicit);
            this.panel1.Controls.Add(this.radioButtonExplicit);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textBoxSeed);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.buttonRound);
            this.panel1.Controls.Add(this.buttonPower);
            this.panel1.Controls.Add(this.buttonMax);
            this.panel1.Controls.Add(this.buttonMin);
            this.panel1.Controls.Add(this.buttonLerp);
            this.panel1.Controls.Add(this.buttonAbs);
            this.panel1.Controls.Add(this.buttonVoronoi);
            this.panel1.Controls.Add(this.buttonTurbulence);
            this.panel1.Controls.Add(this.buttonRMF);
            this.panel1.Controls.Add(this.buttonFBM);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxDevice);
            this.panel1.Controls.Add(this.groupBoxDeviceInfo);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 439);
            this.panel1.TabIndex = 4;
            // 
            // radioButtonImplicit
            // 
            this.radioButtonImplicit.AutoSize = true;
            this.radioButtonImplicit.Checked = true;
            this.radioButtonImplicit.Location = new System.Drawing.Point(6, 203);
            this.radioButtonImplicit.Name = "radioButtonImplicit";
            this.radioButtonImplicit.Size = new System.Drawing.Size(84, 17);
            this.radioButtonImplicit.TabIndex = 35;
            this.radioButtonImplicit.TabStop = true;
            this.radioButtonImplicit.Text = "Implicit Input";
            this.radioButtonImplicit.UseVisualStyleBackColor = true;
            // 
            // radioButtonExplicit
            // 
            this.radioButtonExplicit.AutoSize = true;
            this.radioButtonExplicit.Location = new System.Drawing.Point(6, 226);
            this.radioButtonExplicit.Name = "radioButtonExplicit";
            this.radioButtonExplicit.Size = new System.Drawing.Size(85, 17);
            this.radioButtonExplicit.TabIndex = 34;
            this.radioButtonExplicit.Text = "Explicit Input";
            this.radioButtonExplicit.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Available operators: + - * /";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(109, 203);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Seed:";
            // 
            // textBoxSeed
            // 
            this.textBoxSeed.Location = new System.Drawing.Point(147, 200);
            this.textBoxSeed.Name = "textBoxSeed";
            this.textBoxSeed.Size = new System.Drawing.Size(100, 20);
            this.textBoxSeed.TabIndex = 31;
            this.textBoxSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSeed.TextChanged += new System.EventHandler(this.textBoxSeed_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-3, 423);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Module:";
            // 
            // buttonRound
            // 
            this.buttonRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRound.Location = new System.Drawing.Point(150, 396);
            this.buttonRound.Name = "buttonRound";
            this.buttonRound.Size = new System.Drawing.Size(100, 24);
            this.buttonRound.TabIndex = 30;
            this.buttonRound.Text = "Round";
            this.buttonRound.UseVisualStyleBackColor = true;
            this.buttonRound.Click += new System.EventHandler(this.buttonRound_Click);
            // 
            // buttonPower
            // 
            this.buttonPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPower.BackColor = System.Drawing.SystemColors.Control;
            this.buttonPower.Location = new System.Drawing.Point(150, 367);
            this.buttonPower.Name = "buttonPower";
            this.buttonPower.Size = new System.Drawing.Size(100, 23);
            this.buttonPower.TabIndex = 29;
            this.buttonPower.Text = "Power";
            this.buttonPower.UseVisualStyleBackColor = false;
            this.buttonPower.Click += new System.EventHandler(this.buttonPower_Click);
            // 
            // buttonMax
            // 
            this.buttonMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMax.Location = new System.Drawing.Point(150, 336);
            this.buttonMax.Name = "buttonMax";
            this.buttonMax.Size = new System.Drawing.Size(100, 24);
            this.buttonMax.TabIndex = 28;
            this.buttonMax.Text = "Max";
            this.buttonMax.UseVisualStyleBackColor = true;
            this.buttonMax.Click += new System.EventHandler(this.buttonMax_Click);
            // 
            // buttonMin
            // 
            this.buttonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMin.Location = new System.Drawing.Point(150, 305);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(100, 25);
            this.buttonMin.TabIndex = 27;
            this.buttonMin.Text = "Min";
            this.buttonMin.UseVisualStyleBackColor = true;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonLerp
            // 
            this.buttonLerp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLerp.Location = new System.Drawing.Point(150, 275);
            this.buttonLerp.Name = "buttonLerp";
            this.buttonLerp.Size = new System.Drawing.Size(100, 24);
            this.buttonLerp.TabIndex = 22;
            this.buttonLerp.Text = "Lerp";
            this.buttonLerp.UseVisualStyleBackColor = true;
            this.buttonLerp.Click += new System.EventHandler(this.buttonLerp_Click);
            // 
            // buttonAbs
            // 
            this.buttonAbs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAbs.Location = new System.Drawing.Point(150, 246);
            this.buttonAbs.Name = "buttonAbs";
            this.buttonAbs.Size = new System.Drawing.Size(100, 24);
            this.buttonAbs.TabIndex = 21;
            this.buttonAbs.Text = "Abs";
            this.buttonAbs.UseVisualStyleBackColor = true;
            this.buttonAbs.Click += new System.EventHandler(this.buttonAbs_Click);
            // 
            // buttonVoronoi
            // 
            this.buttonVoronoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonVoronoi.Location = new System.Drawing.Point(6, 336);
            this.buttonVoronoi.Name = "buttonVoronoi";
            this.buttonVoronoi.Size = new System.Drawing.Size(138, 24);
            this.buttonVoronoi.TabIndex = 19;
            this.buttonVoronoi.Text = "Voronoi";
            this.buttonVoronoi.UseVisualStyleBackColor = true;
            this.buttonVoronoi.Click += new System.EventHandler(this.buttonVoronoi_Click);
            // 
            // buttonTurbulence
            // 
            this.buttonTurbulence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTurbulence.Location = new System.Drawing.Point(6, 306);
            this.buttonTurbulence.Name = "buttonTurbulence";
            this.buttonTurbulence.Size = new System.Drawing.Size(138, 24);
            this.buttonTurbulence.TabIndex = 18;
            this.buttonTurbulence.Text = "Turbulence";
            this.buttonTurbulence.UseVisualStyleBackColor = true;
            this.buttonTurbulence.Click += new System.EventHandler(this.buttonTurbulence_Click);
            // 
            // buttonRMF
            // 
            this.buttonRMF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRMF.Location = new System.Drawing.Point(6, 276);
            this.buttonRMF.Name = "buttonRMF";
            this.buttonRMF.Size = new System.Drawing.Size(138, 24);
            this.buttonRMF.TabIndex = 17;
            this.buttonRMF.Text = "RidgedMultifractal";
            this.buttonRMF.UseVisualStyleBackColor = true;
            this.buttonRMF.Click += new System.EventHandler(this.buttonRMF_Click);
            // 
            // buttonFBM
            // 
            this.buttonFBM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFBM.Location = new System.Drawing.Point(6, 246);
            this.buttonFBM.Name = "buttonFBM";
            this.buttonFBM.Size = new System.Drawing.Size(138, 24);
            this.buttonFBM.TabIndex = 16;
            this.buttonFBM.Text = "FractalBrownianMotion";
            this.buttonFBM.UseVisualStyleBackColor = true;
            this.buttonFBM.Click += new System.EventHandler(this.buttonFBM_Click);
            // 
            // labelParseMessage
            // 
            this.labelParseMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelParseMessage.BackColor = System.Drawing.Color.Black;
            this.labelParseMessage.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParseMessage.ForeColor = System.Drawing.Color.Red;
            this.labelParseMessage.Location = new System.Drawing.Point(274, 12);
            this.labelParseMessage.Name = "labelParseMessage";
            this.labelParseMessage.Size = new System.Drawing.Size(432, 401);
            this.labelParseMessage.TabIndex = 6;
            this.labelParseMessage.Text = "Empty module";
            this.labelParseMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerRefresher
            // 
            this.timerRefresher.Enabled = true;
            this.timerRefresher.Interval = 500;
            this.timerRefresher.Tick += new System.EventHandler(this.timerRefresher_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelResolution,
            this.toolStripStatusLabel1,
            this.statusLabelCloonTime,
            this.toolStripStatusLabel2,
            this.statusLabelOverhead});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(718, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelResolution
            // 
            this.statusLabelResolution.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabelResolution.Name = "statusLabelResolution";
            this.statusLabelResolution.Size = new System.Drawing.Size(48, 17);
            this.statusLabelResolution.Text = "Res: 0x0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(74, 17);
            this.toolStripStatusLabel1.Text = "ClooN Time:";
            // 
            // statusLabelCloonTime
            // 
            this.statusLabelCloonTime.Name = "statusLabelCloonTime";
            this.statusLabelCloonTime.Size = new System.Drawing.Size(29, 17);
            this.statusLabelCloonTime.Text = "0ms";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabel2.Text = "Overhead:";
            // 
            // statusLabelOverhead
            // 
            this.statusLabelOverhead.Name = "statusLabelOverhead";
            this.statusLabelOverhead.Size = new System.Drawing.Size(29, 17);
            this.statusLabelOverhead.Text = "0ms";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.buttonContrastSub);
            this.panel2.Controls.Add(this.buttonContrastAdd);
            this.panel2.Controls.Add(this.buttonExport);
            this.panel2.Controls.Add(this.buttonZUp);
            this.panel2.Controls.Add(this.buttonZDown);
            this.panel2.Controls.Add(this.buttonZoomOut);
            this.panel2.Controls.Add(this.buttonZoomIn);
            this.panel2.Controls.Add(this.buttonRefresh);
            this.panel2.Controls.Add(this.buttonResetPosition);
            this.panel2.Controls.Add(this.buttonShiftRight);
            this.panel2.Controls.Add(this.buttonShiftLeft);
            this.panel2.Controls.Add(this.buttonShiftUp);
            this.panel2.Controls.Add(this.buttonShiftDown);
            this.panel2.Location = new System.Drawing.Point(274, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 32);
            this.panel2.TabIndex = 10;
            // 
            // buttonContrastSub
            // 
            this.buttonContrastSub.BackgroundImage = global::ClooNEditor.Properties.Resources.contrast_sub;
            this.buttonContrastSub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContrastSub.Location = new System.Drawing.Point(327, 3);
            this.buttonContrastSub.Name = "buttonContrastSub";
            this.buttonContrastSub.Size = new System.Drawing.Size(24, 24);
            this.buttonContrastSub.TabIndex = 12;
            this.toolTipButtons.SetToolTip(this.buttonContrastSub, "Refresh");
            this.buttonContrastSub.UseVisualStyleBackColor = true;
            this.buttonContrastSub.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonContrastSub_MouseDown);
            this.buttonContrastSub.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonContrastAdd
            // 
            this.buttonContrastAdd.BackgroundImage = global::ClooNEditor.Properties.Resources.contrast_add;
            this.buttonContrastAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonContrastAdd.Location = new System.Drawing.Point(297, 3);
            this.buttonContrastAdd.Name = "buttonContrastAdd";
            this.buttonContrastAdd.Size = new System.Drawing.Size(24, 24);
            this.buttonContrastAdd.TabIndex = 11;
            this.toolTipButtons.SetToolTip(this.buttonContrastAdd, "Refresh");
            this.buttonContrastAdd.UseVisualStyleBackColor = true;
            this.buttonContrastAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonContrastAdd_MouseDown);
            this.buttonContrastAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonExport
            // 
            this.buttonExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExport.BackgroundImage = global::ClooNEditor.Properties.Resources.export_code;
            this.buttonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExport.Location = new System.Drawing.Point(403, 3);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(24, 24);
            this.buttonExport.TabIndex = 10;
            this.toolTipButtons.SetToolTip(this.buttonExport, "Save C# Module Code to Clipboard ");
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonZUp
            // 
            this.buttonZUp.BackgroundImage = global::ClooNEditor.Properties.Resources.arrow_forward;
            this.buttonZUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZUp.Location = new System.Drawing.Point(168, 3);
            this.buttonZUp.Name = "buttonZUp";
            this.buttonZUp.Size = new System.Drawing.Size(24, 24);
            this.buttonZUp.TabIndex = 9;
            this.toolTipButtons.SetToolTip(this.buttonZUp, "Go Z Up");
            this.buttonZUp.UseVisualStyleBackColor = true;
            this.buttonZUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZUp_MouseDown);
            this.buttonZUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonZDown
            // 
            this.buttonZDown.BackgroundImage = global::ClooNEditor.Properties.Resources.arrow_backward;
            this.buttonZDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZDown.Location = new System.Drawing.Point(198, 3);
            this.buttonZDown.Name = "buttonZDown";
            this.buttonZDown.Size = new System.Drawing.Size(24, 24);
            this.buttonZDown.TabIndex = 8;
            this.toolTipButtons.SetToolTip(this.buttonZDown, "Go Z Down");
            this.buttonZDown.UseVisualStyleBackColor = true;
            this.buttonZDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZDown_MouseDown);
            this.buttonZDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.BackgroundImage = global::ClooNEditor.Properties.Resources.zoom_out;
            this.buttonZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZoomOut.Location = new System.Drawing.Point(267, 3);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(24, 24);
            this.buttonZoomOut.TabIndex = 7;
            this.toolTipButtons.SetToolTip(this.buttonZoomOut, "Zoom Out");
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseDown);
            this.buttonZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.BackgroundImage = global::ClooNEditor.Properties.Resources.zoom_in;
            this.buttonZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonZoomIn.Location = new System.Drawing.Point(237, 3);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(24, 24);
            this.buttonZoomIn.TabIndex = 6;
            this.toolTipButtons.SetToolTip(this.buttonZoomIn, "Zoom In");
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseDown);
            this.buttonZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackgroundImage = global::ClooNEditor.Properties.Resources.refresh;
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRefresh.Location = new System.Drawing.Point(369, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(24, 24);
            this.buttonRefresh.TabIndex = 5;
            this.toolTipButtons.SetToolTip(this.buttonRefresh, "Refresh");
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonResetPosition
            // 
            this.buttonResetPosition.BackgroundImage = global::ClooNEditor.Properties.Resources.home;
            this.buttonResetPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonResetPosition.Location = new System.Drawing.Point(3, 3);
            this.buttonResetPosition.Name = "buttonResetPosition";
            this.buttonResetPosition.Size = new System.Drawing.Size(24, 24);
            this.buttonResetPosition.TabIndex = 4;
            this.toolTipButtons.SetToolTip(this.buttonResetPosition, "Reset Position");
            this.buttonResetPosition.UseVisualStyleBackColor = true;
            this.buttonResetPosition.Click += new System.EventHandler(this.buttonResetPosition_Click);
            // 
            // buttonShiftRight
            // 
            this.buttonShiftRight.BackgroundImage = global::ClooNEditor.Properties.Resources.arrow_right;
            this.buttonShiftRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShiftRight.Location = new System.Drawing.Point(67, 3);
            this.buttonShiftRight.Name = "buttonShiftRight";
            this.buttonShiftRight.Size = new System.Drawing.Size(24, 24);
            this.buttonShiftRight.TabIndex = 3;
            this.toolTipButtons.SetToolTip(this.buttonShiftRight, "Shift Right");
            this.buttonShiftRight.UseVisualStyleBackColor = true;
            this.buttonShiftRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShiftRight_MouseDown);
            this.buttonShiftRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonShiftLeft
            // 
            this.buttonShiftLeft.BackgroundImage = global::ClooNEditor.Properties.Resources.arrow_left;
            this.buttonShiftLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShiftLeft.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShiftLeft.Location = new System.Drawing.Point(37, 3);
            this.buttonShiftLeft.Name = "buttonShiftLeft";
            this.buttonShiftLeft.Size = new System.Drawing.Size(24, 24);
            this.buttonShiftLeft.TabIndex = 2;
            this.toolTipButtons.SetToolTip(this.buttonShiftLeft, "Shift Left");
            this.buttonShiftLeft.UseVisualStyleBackColor = true;
            this.buttonShiftLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShiftLeft_MouseDown);
            this.buttonShiftLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonShiftUp
            // 
            this.buttonShiftUp.BackgroundImage = global::ClooNEditor.Properties.Resources.arrow_up;
            this.buttonShiftUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShiftUp.Location = new System.Drawing.Point(97, 3);
            this.buttonShiftUp.Name = "buttonShiftUp";
            this.buttonShiftUp.Size = new System.Drawing.Size(24, 24);
            this.buttonShiftUp.TabIndex = 1;
            this.toolTipButtons.SetToolTip(this.buttonShiftUp, "Shift Up");
            this.buttonShiftUp.UseVisualStyleBackColor = true;
            this.buttonShiftUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShiftUp_MouseDown);
            this.buttonShiftUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // buttonShiftDown
            // 
            this.buttonShiftDown.BackgroundImage = global::ClooNEditor.Properties.Resources.arrow_down;
            this.buttonShiftDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShiftDown.Location = new System.Drawing.Point(127, 3);
            this.buttonShiftDown.Name = "buttonShiftDown";
            this.buttonShiftDown.Size = new System.Drawing.Size(24, 24);
            this.buttonShiftDown.TabIndex = 0;
            this.toolTipButtons.SetToolTip(this.buttonShiftDown, "Shift Down");
            this.buttonShiftDown.UseVisualStyleBackColor = true;
            this.buttonShiftDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonShiftDown_MouseDown);
            this.buttonShiftDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.modifierButton_MouseUp);
            // 
            // toolTipButtons
            // 
            this.toolTipButtons.IsBalloon = true;
            // 
            // timerButtonDown
            // 
            this.timerButtonDown.Interval = 40;
            this.timerButtonDown.Tick += new System.EventHandler(this.timerButtonDown_Tick);
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxResult.BackColor = System.Drawing.Color.Black;
            this.pictureBoxResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxResult.Location = new System.Drawing.Point(274, 12);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(432, 401);
            this.pictureBoxResult.TabIndex = 0;
            this.pictureBoxResult.TabStop = false;
            // 
            // boxCode
            // 
            this.boxCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxCode.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxCode.Location = new System.Drawing.Point(15, 457);
            this.boxCode.Multiline = true;
            this.boxCode.Name = "boxCode";
            this.boxCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.boxCode.Size = new System.Drawing.Size(691, 64);
            this.boxCode.TabIndex = 12;
            this.boxCode.TextChanged += new System.EventHandler(this.boxCode_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(718, 546);
            this.Controls.Add(this.boxCode);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.labelParseMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxResult);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(734, 585);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClooN Editor";
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.groupBoxDeviceInfo.ResumeLayout(false);
            this.groupBoxDeviceInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDevice;
        private System.Windows.Forms.GroupBox groupBoxDeviceInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelVendor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxExtensions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonVoronoi;
        private System.Windows.Forms.Button buttonTurbulence;
        private System.Windows.Forms.Button buttonRMF;
        private System.Windows.Forms.Button buttonFBM;
        private System.Windows.Forms.Button buttonLerp;
        private System.Windows.Forms.Button buttonAbs;
        private System.Windows.Forms.Button buttonRound;
        private System.Windows.Forms.Button buttonPower;
        private System.Windows.Forms.Button buttonMax;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Label labelParseMessage;
        private System.Windows.Forms.Timer timerRefresher;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelCloonTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSeed;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.Button buttonShiftDown;
        private System.Windows.Forms.Button buttonZUp;
        private System.Windows.Forms.Button buttonZDown;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonResetPosition;
        private System.Windows.Forms.Button buttonShiftRight;
        private System.Windows.Forms.Button buttonShiftLeft;
        private System.Windows.Forms.Button buttonShiftUp;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.ToolTip toolTipButtons;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelOverhead;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelResolution;
        private System.Windows.Forms.Timer timerButtonDown;
        private System.Windows.Forms.Button buttonContrastAdd;
        private System.Windows.Forms.Button buttonContrastSub;
        private System.Windows.Forms.TextBox boxCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonImplicit;
        private System.Windows.Forms.RadioButton radioButtonExplicit;
    }
}

