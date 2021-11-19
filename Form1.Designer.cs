namespace Emulator_v1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MarketDropdown = new System.Windows.Forms.ComboBox();
            this.MarketLabel = new System.Windows.Forms.Label();
            this.SourceBox = new System.Windows.Forms.TextBox();
            this.SourceLabel = new System.Windows.Forms.Label();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.DestinationBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SaveAsButton = new System.Windows.Forms.Button();
            this.DataTypeLabel = new System.Windows.Forms.Label();
            this.DataTypeButtonPanel = new System.Windows.Forms.GroupBox();
            this.LT6DataButton = new System.Windows.Forms.RadioButton();
            this.LT4DataButton = new System.Windows.Forms.RadioButton();
            this.LT3DataButton = new System.Windows.Forms.RadioButton();
            this.RDRDataButton = new System.Windows.Forms.RadioButton();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.ModeButtonPanel = new System.Windows.Forms.GroupBox();
            this.AutomaticModeButton = new System.Windows.Forms.RadioButton();
            this.DefaultModeButton = new System.Windows.Forms.RadioButton();
            this.ManualModeButton = new System.Windows.Forms.RadioButton();
            this.StatusBox = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.AutoBox = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.StartBox = new System.Windows.Forms.ComboBox();
            this.StartDateTimeLabel = new System.Windows.Forms.Label();
            this.DataIntervalsGrid = new System.Windows.Forms.DataGridView();
            this.RDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WTR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LTZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResetButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.DataIntervalLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.HelpPDFButton = new System.Windows.Forms.Button();
            this.DefaultBox = new System.Windows.Forms.Label();
            this.DataTypeButtonPanel.SuspendLayout();
            this.ModeButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataIntervalsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MarketDropdown
            // 
            this.MarketDropdown.FormattingEnabled = true;
            this.MarketDropdown.Location = new System.Drawing.Point(33, 63);
            this.MarketDropdown.Name = "MarketDropdown";
            this.MarketDropdown.Size = new System.Drawing.Size(155, 21);
            this.MarketDropdown.TabIndex = 0;
            this.MarketDropdown.SelectedIndexChanged += new System.EventHandler(this.MarketDropdown_SelectedIndexChanged);
            // 
            // MarketLabel
            // 
            this.MarketLabel.AutoSize = true;
            this.MarketLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MarketLabel.Location = new System.Drawing.Point(58, 26);
            this.MarketLabel.Name = "MarketLabel";
            this.MarketLabel.Size = new System.Drawing.Size(78, 25);
            this.MarketLabel.TabIndex = 1;
            this.MarketLabel.Text = "Market";
            this.MarketLabel.Click += new System.EventHandler(this.MarketLabel_Click);
            // 
            // SourceBox
            // 
            this.SourceBox.Location = new System.Drawing.Point(141, 117);
            this.SourceBox.Name = "SourceBox";
            this.SourceBox.Size = new System.Drawing.Size(703, 20);
            this.SourceBox.TabIndex = 2;
            this.SourceBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SourceBox_MouseDoubleClick);
            // 
            // SourceLabel
            // 
            this.SourceLabel.AutoSize = true;
            this.SourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SourceLabel.Location = new System.Drawing.Point(38, 111);
            this.SourceLabel.Name = "SourceLabel";
            this.SourceLabel.Size = new System.Drawing.Size(80, 25);
            this.SourceLabel.TabIndex = 3;
            this.SourceLabel.Text = "Source";
            this.SourceLabel.Click += new System.EventHandler(this.SourceLabel_Click);
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DestinationLabel.Location = new System.Drawing.Point(0, 138);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(120, 25);
            this.DestinationLabel.TabIndex = 5;
            this.DestinationLabel.Text = "Destination";
            this.DestinationLabel.Click += new System.EventHandler(this.DestinationLabel_Click);
            // 
            // DestinationBox
            // 
            this.DestinationBox.Location = new System.Drawing.Point(141, 143);
            this.DestinationBox.Name = "DestinationBox";
            this.DestinationBox.Size = new System.Drawing.Size(703, 20);
            this.DestinationBox.TabIndex = 4;
            this.DestinationBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DestinationBox_MouseDoubleClick);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(224, 184);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 32);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(400, 184);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 32);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SaveAsButton
            // 
            this.SaveAsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAsButton.Location = new System.Drawing.Point(305, 184);
            this.SaveAsButton.Name = "SaveAsButton";
            this.SaveAsButton.Size = new System.Drawing.Size(89, 32);
            this.SaveAsButton.TabIndex = 8;
            this.SaveAsButton.Text = "Save As";
            this.SaveAsButton.UseVisualStyleBackColor = true;
            this.SaveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // DataTypeLabel
            // 
            this.DataTypeLabel.AutoSize = true;
            this.DataTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataTypeLabel.Location = new System.Drawing.Point(410, 299);
            this.DataTypeLabel.Name = "DataTypeLabel";
            this.DataTypeLabel.Size = new System.Drawing.Size(111, 25);
            this.DataTypeLabel.TabIndex = 9;
            this.DataTypeLabel.Text = "Data Type";
            // 
            // DataTypeButtonPanel
            // 
            this.DataTypeButtonPanel.Controls.Add(this.LT6DataButton);
            this.DataTypeButtonPanel.Controls.Add(this.LT4DataButton);
            this.DataTypeButtonPanel.Controls.Add(this.LT3DataButton);
            this.DataTypeButtonPanel.Controls.Add(this.RDRDataButton);
            this.DataTypeButtonPanel.Location = new System.Drawing.Point(409, 327);
            this.DataTypeButtonPanel.Name = "DataTypeButtonPanel";
            this.DataTypeButtonPanel.Size = new System.Drawing.Size(115, 125);
            this.DataTypeButtonPanel.TabIndex = 11;
            this.DataTypeButtonPanel.TabStop = false;
            // 
            // LT6DataButton
            // 
            this.LT6DataButton.AutoSize = true;
            this.LT6DataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LT6DataButton.Location = new System.Drawing.Point(7, 97);
            this.LT6DataButton.Name = "LT6DataButton";
            this.LT6DataButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LT6DataButton.Size = new System.Drawing.Size(55, 20);
            this.LT6DataButton.TabIndex = 3;
            this.LT6DataButton.TabStop = true;
            this.LT6DataButton.Text = "  LT6";
            this.LT6DataButton.UseVisualStyleBackColor = true;
            this.LT6DataButton.CheckedChanged += new System.EventHandler(this.LT6DataButton_CheckedChanged);
            // 
            // LT4DataButton
            // 
            this.LT4DataButton.AutoSize = true;
            this.LT4DataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LT4DataButton.Location = new System.Drawing.Point(7, 71);
            this.LT4DataButton.Name = "LT4DataButton";
            this.LT4DataButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LT4DataButton.Size = new System.Drawing.Size(55, 20);
            this.LT4DataButton.TabIndex = 2;
            this.LT4DataButton.TabStop = true;
            this.LT4DataButton.Text = "  LT4";
            this.LT4DataButton.UseVisualStyleBackColor = true;
            this.LT4DataButton.CheckedChanged += new System.EventHandler(this.LT4DataButton_CheckedChanged);
            // 
            // LT3DataButton
            // 
            this.LT3DataButton.AutoSize = true;
            this.LT3DataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LT3DataButton.Location = new System.Drawing.Point(7, 45);
            this.LT3DataButton.Name = "LT3DataButton";
            this.LT3DataButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.LT3DataButton.Size = new System.Drawing.Size(55, 20);
            this.LT3DataButton.TabIndex = 1;
            this.LT3DataButton.TabStop = true;
            this.LT3DataButton.Text = "  LT3";
            this.LT3DataButton.UseVisualStyleBackColor = true;
            this.LT3DataButton.CheckedChanged += new System.EventHandler(this.LT3DataButton_CheckedChanged);
            // 
            // RDRDataButton
            // 
            this.RDRDataButton.AutoSize = true;
            this.RDRDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RDRDataButton.Location = new System.Drawing.Point(6, 19);
            this.RDRDataButton.Name = "RDRDataButton";
            this.RDRDataButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RDRDataButton.Size = new System.Drawing.Size(56, 20);
            this.RDRDataButton.TabIndex = 0;
            this.RDRDataButton.TabStop = true;
            this.RDRDataButton.Text = "RDR";
            this.RDRDataButton.UseVisualStyleBackColor = true;
            this.RDRDataButton.CheckedChanged += new System.EventHandler(this.RDRDataButton_CheckedChanged);
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeLabel.Location = new System.Drawing.Point(68, 259);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(120, 25);
            this.ModeLabel.TabIndex = 12;
            this.ModeLabel.Text = "Mode Type";
            // 
            // ModeButtonPanel
            // 
            this.ModeButtonPanel.Controls.Add(this.AutomaticModeButton);
            this.ModeButtonPanel.Controls.Add(this.DefaultModeButton);
            this.ModeButtonPanel.Controls.Add(this.ManualModeButton);
            this.ModeButtonPanel.Location = new System.Drawing.Point(43, 287);
            this.ModeButtonPanel.Name = "ModeButtonPanel";
            this.ModeButtonPanel.Size = new System.Drawing.Size(126, 131);
            this.ModeButtonPanel.TabIndex = 13;
            this.ModeButtonPanel.TabStop = false;
            // 
            // AutomaticModeButton
            // 
            this.AutomaticModeButton.AutoSize = true;
            this.AutomaticModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.AutomaticModeButton.Location = new System.Drawing.Point(22, 85);
            this.AutomaticModeButton.Name = "AutomaticModeButton";
            this.AutomaticModeButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AutomaticModeButton.Size = new System.Drawing.Size(82, 28);
            this.AutomaticModeButton.TabIndex = 2;
            this.AutomaticModeButton.TabStop = true;
            this.AutomaticModeButton.Text = "   Auto";
            this.AutomaticModeButton.UseVisualStyleBackColor = true;
            this.AutomaticModeButton.CheckedChanged += new System.EventHandler(this.AutomaticModeButton_CheckedChanged);
            // 
            // DefaultModeButton
            // 
            this.DefaultModeButton.AutoSize = true;
            this.DefaultModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DefaultModeButton.Location = new System.Drawing.Point(19, 54);
            this.DefaultModeButton.Name = "DefaultModeButton";
            this.DefaultModeButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DefaultModeButton.Size = new System.Drawing.Size(85, 28);
            this.DefaultModeButton.TabIndex = 1;
            this.DefaultModeButton.TabStop = true;
            this.DefaultModeButton.Text = "Default";
            this.DefaultModeButton.UseVisualStyleBackColor = true;
            this.DefaultModeButton.CheckedChanged += new System.EventHandler(this.DefaultModeButton_CheckedChanged);
            // 
            // ManualModeButton
            // 
            this.ManualModeButton.AutoSize = true;
            this.ManualModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ManualModeButton.Location = new System.Drawing.Point(14, 19);
            this.ManualModeButton.Name = "ManualModeButton";
            this.ManualModeButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ManualModeButton.Size = new System.Drawing.Size(90, 28);
            this.ManualModeButton.TabIndex = 0;
            this.ManualModeButton.TabStop = true;
            this.ManualModeButton.Text = "Manual";
            this.ManualModeButton.UseVisualStyleBackColor = true;
            this.ManualModeButton.CheckedChanged += new System.EventHandler(this.ManualModeButton_CheckedChanged);
            // 
            // StatusBox
            // 
            this.StatusBox.Location = new System.Drawing.Point(705, 456);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(47, 20);
            this.StatusBox.TabIndex = 14;
            this.StatusBox.Text = "20";
            this.StatusBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(571, 456);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(117, 20);
            this.StatusLabel.TabIndex = 15;
            this.StatusLabel.Text = "StratSysStatus";
            // 
            // AutoBox
            // 
            this.AutoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoBox.Location = new System.Drawing.Point(175, 379);
            this.AutoBox.Name = "AutoBox";
            this.AutoBox.Size = new System.Drawing.Size(104, 29);
            this.AutoBox.TabIndex = 17;
            this.AutoBox.Text = "5";
            this.AutoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ExecuteButton.Location = new System.Drawing.Point(175, 306);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(104, 28);
            this.ExecuteButton.TabIndex = 18;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // StartBox
            // 
            this.StartBox.FormattingEnabled = true;
            this.StartBox.Location = new System.Drawing.Point(256, 63);
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(215, 21);
            this.StartBox.TabIndex = 19;
            this.StartBox.SelectedIndexChanged += new System.EventHandler(this.StartBox_SelectedIndexChanged);
            this.StartBox.Click += new System.EventHandler(this.StartBox_Clicked);
            // 
            // StartDateTimeLabel
            // 
            this.StartDateTimeLabel.AutoSize = true;
            this.StartDateTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDateTimeLabel.Location = new System.Drawing.Point(251, 26);
            this.StartDateTimeLabel.Name = "StartDateTimeLabel";
            this.StartDateTimeLabel.Size = new System.Drawing.Size(203, 25);
            this.StartDateTimeLabel.TabIndex = 20;
            this.StartDateTimeLabel.Text = "Start Date and Time";
            // 
            // DataIntervalsGrid
            // 
            this.DataIntervalsGrid.AllowUserToAddRows = false;
            this.DataIntervalsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataIntervalsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RDR,
            this.WTR,
            this.LT,
            this.LTX,
            this.LTY,
            this.LTZ});
            this.DataIntervalsGrid.Location = new System.Drawing.Point(541, 319);
            this.DataIntervalsGrid.Name = "DataIntervalsGrid";
            this.DataIntervalsGrid.RowTemplate.Height = 27;
            this.DataIntervalsGrid.Size = new System.Drawing.Size(343, 131);
            this.DataIntervalsGrid.TabIndex = 21;
            this.DataIntervalsGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataIntervalsGrid_CellEndEdit);
            // 
            // RDR
            // 
            this.RDR.HeaderText = "RDR";
            this.RDR.Name = "RDR";
            this.RDR.Width = 50;
            // 
            // WTR
            // 
            this.WTR.HeaderText = "WTR";
            this.WTR.Name = "WTR";
            this.WTR.Width = 50;
            // 
            // LT
            // 
            this.LT.HeaderText = "LT";
            this.LT.Name = "LT";
            this.LT.Width = 50;
            // 
            // LTX
            // 
            this.LTX.HeaderText = "LTX";
            this.LTX.Name = "LTX";
            this.LTX.Width = 50;
            // 
            // LTY
            // 
            this.LTY.HeaderText = "LTY";
            this.LTY.Name = "LTY";
            this.LTY.Width = 50;
            // 
            // LTZ
            // 
            this.LTZ.HeaderText = "LTZ";
            this.LTZ.Name = "LTZ";
            this.LTZ.Width = 50;
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ResetButton.Location = new System.Drawing.Point(649, 59);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(153, 25);
            this.ResetButton.TabIndex = 22;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoadButton.Location = new System.Drawing.Point(649, 34);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(153, 25);
            this.LoadButton.TabIndex = 23;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // PauseButton
            // 
            this.PauseButton.Image = ((System.Drawing.Image)(resources.GetObject("PauseButton.Image")));
            this.PauseButton.Location = new System.Drawing.Point(537, 34);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(50, 50);
            this.PauseButton.TabIndex = 24;
            this.PauseButton.UseVisualStyleBackColor = true;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Image = ((System.Drawing.Image)(resources.GetObject("PlayButton.Image")));
            this.PlayButton.Location = new System.Drawing.Point(481, 34);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(50, 50);
            this.PlayButton.TabIndex = 25;
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Image = ((System.Drawing.Image)(resources.GetObject("StopButton.Image")));
            this.StopButton.Location = new System.Drawing.Point(593, 34);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(50, 50);
            this.StopButton.TabIndex = 26;
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // DataIntervalLabel
            // 
            this.DataIntervalLabel.AutoSize = true;
            this.DataIntervalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataIntervalLabel.Location = new System.Drawing.Point(644, 280);
            this.DataIntervalLabel.Name = "DataIntervalLabel";
            this.DataIntervalLabel.Size = new System.Drawing.Size(198, 25);
            this.DataIntervalLabel.TabIndex = 27;
            this.DataIntervalLabel.Text = "Data Intervals (min)";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(758, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "(sec)";
            // 
            // HelpPDFButton
            // 
            this.HelpPDFButton.Location = new System.Drawing.Point(5, 5);
            this.HelpPDFButton.Name = "HelpPDFButton";
            this.HelpPDFButton.Size = new System.Drawing.Size(47, 23);
            this.HelpPDFButton.TabIndex = 29;
            this.HelpPDFButton.Text = "Help";
            this.HelpPDFButton.UseVisualStyleBackColor = true;
            this.HelpPDFButton.Click += new System.EventHandler(this.HelpPDFButton_Click);
            // 
            // DefaultBox
            // 
            this.DefaultBox.AutoSize = true;
            this.DefaultBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefaultBox.Location = new System.Drawing.Point(199, 346);
            this.DefaultBox.Name = "DefaultBox";
            this.DefaultBox.Size = new System.Drawing.Size(60, 24);
            this.DefaultBox.TabIndex = 30;
            this.DefaultBox.Text = "label2";
            this.DefaultBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 496);
            this.Controls.Add(this.DefaultBox);
            this.Controls.Add(this.HelpPDFButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DataIntervalLabel);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.DataIntervalsGrid);
            this.Controls.Add(this.StartDateTimeLabel);
            this.Controls.Add(this.StartBox);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.AutoBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.StatusBox);
            this.Controls.Add(this.ModeButtonPanel);
            this.Controls.Add(this.ModeLabel);
            this.Controls.Add(this.DataTypeButtonPanel);
            this.Controls.Add(this.DataTypeLabel);
            this.Controls.Add(this.SaveAsButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.DestinationBox);
            this.Controls.Add(this.SourceLabel);
            this.Controls.Add(this.SourceBox);
            this.Controls.Add(this.MarketLabel);
            this.Controls.Add(this.MarketDropdown);
            this.Name = "Form1";
            this.Text = "Emulator v2.2";
            this.DataTypeButtonPanel.ResumeLayout(false);
            this.DataTypeButtonPanel.PerformLayout();
            this.ModeButtonPanel.ResumeLayout(false);
            this.ModeButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataIntervalsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox MarketDropdown;
        private System.Windows.Forms.Label MarketLabel;
        private System.Windows.Forms.TextBox SourceBox;
        private System.Windows.Forms.Label SourceLabel;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.TextBox DestinationBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SaveAsButton;
        private System.Windows.Forms.Label DataTypeLabel;
        private System.Windows.Forms.GroupBox DataTypeButtonPanel;
        private System.Windows.Forms.RadioButton LT6DataButton;
        private System.Windows.Forms.RadioButton LT4DataButton;
        private System.Windows.Forms.RadioButton LT3DataButton;
        private System.Windows.Forms.RadioButton RDRDataButton;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.GroupBox ModeButtonPanel;
        private System.Windows.Forms.RadioButton AutomaticModeButton;
        private System.Windows.Forms.RadioButton DefaultModeButton;
        private System.Windows.Forms.RadioButton ManualModeButton;
        private System.Windows.Forms.TextBox StatusBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox AutoBox;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.ComboBox StartBox;
        private System.Windows.Forms.Label StartDateTimeLabel;
        private System.Windows.Forms.DataGridView DataIntervalsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn RDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn WTR;
        private System.Windows.Forms.DataGridViewTextBoxColumn LT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTX;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn LTZ;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label DataIntervalLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button HelpPDFButton;
        private System.Windows.Forms.Label DefaultBox;
    }
}

