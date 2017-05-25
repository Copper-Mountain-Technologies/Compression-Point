namespace CompressionPoint
{
    partial class FormMain
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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelVnaInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerReady = new System.Windows.Forms.Timer(this.components);
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.comboBoxChannel = new System.Windows.Forms.ComboBox();
            this.comboBoxTrace = new System.Windows.Forms.ComboBox();
            this.labelSelectAndConfigureChannel = new System.Windows.Forms.Label();
            this.comboBoxSearchMarker = new System.Windows.Forms.ComboBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxCompressionPointValue = new System.Windows.Forms.GroupBox();
            this.labelCompressionPointUnits = new System.Windows.Forms.Label();
            this.labelCompressionPointValue = new System.Windows.Forms.Label();
            this.groupBoxSearchForCompressionPoint = new System.Windows.Forms.GroupBox();
            this.checkBoxSearchLoop = new System.Windows.Forms.CheckBox();
            this.labelSearchForCompressionPoint = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.groupBoxSelectSearchMarker = new System.Windows.Forms.GroupBox();
            this.labelSelectSearchMarker = new System.Windows.Forms.Label();
            this.buttonAddMarker = new System.Windows.Forms.Button();
            this.buttonRemoveMarker = new System.Windows.Forms.Button();
            this.groupBoxMoveReferenceMarker = new System.Windows.Forms.GroupBox();
            this.labelMoveReferenceMarker = new System.Windows.Forms.Label();
            this.groupBoxlSelectTrace = new System.Windows.Forms.GroupBox();
            this.labelSelectAndConfigureTrace = new System.Windows.Forms.Label();
            this.checkBoxReferenceMarker = new System.Windows.Forms.CheckBox();
            this.groupBoxSelectAndConfigureChannel = new System.Windows.Forms.GroupBox();
            this.checkBoxPowerSweep = new System.Windows.Forms.CheckBox();
            this.timerSearchLoop = new System.Windows.Forms.Timer(this.components);
            this.buttonS21 = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxCompressionPointValue.SuspendLayout();
            this.groupBoxSearchForCompressionPoint.SuspendLayout();
            this.groupBoxSelectSearchMarker.SuspendLayout();
            this.groupBoxMoveReferenceMarker.SuspendLayout();
            this.groupBoxlSelectTrace.SuspendLayout();
            this.groupBoxSelectAndConfigureChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelVnaInfo,
            this.toolStripStatusLabelSpacer,
            this.toolStripStatusLabelVersion});
            this.statusStrip.Location = new System.Drawing.Point(0, 453);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 27;
            // 
            // toolStripStatusLabelVnaInfo
            // 
            this.toolStripStatusLabelVnaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVnaInfo.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVnaInfo.Name = "toolStripStatusLabelVnaInfo";
            this.toolStripStatusLabelVnaInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.toolStripStatusLabelVnaInfo.Size = new System.Drawing.Size(27, 17);
            this.toolStripStatusLabelVnaInfo.Text = "     ";
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(206, 17);
            this.toolStripStatusLabelSpacer.Spring = true;
            // 
            // toolStripStatusLabelVersion
            // 
            this.toolStripStatusLabelVersion.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelVersion.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripStatusLabelVersion.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.toolStripStatusLabelVersion.Name = "toolStripStatusLabelVersion";
            this.toolStripStatusLabelVersion.Size = new System.Drawing.Size(26, 17);
            this.toolStripStatusLabelVersion.Text = "v ---";
            this.toolStripStatusLabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timerReady
            // 
            this.timerReady.Interval = 1000;
            this.timerReady.Tick += new System.EventHandler(this.timerReady_Tick);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 1000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // comboBoxChannel
            // 
            this.comboBoxChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannel.FormattingEnabled = true;
            this.comboBoxChannel.Location = new System.Drawing.Point(7, 37);
            this.comboBoxChannel.Name = "comboBoxChannel";
            this.comboBoxChannel.Size = new System.Drawing.Size(128, 21);
            this.comboBoxChannel.TabIndex = 1;
            this.comboBoxChannel.SelectedIndexChanged += new System.EventHandler(this.comboBoxChannel_SelectedIndexChanged);
            // 
            // comboBoxTrace
            // 
            this.comboBoxTrace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTrace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrace.FormattingEnabled = true;
            this.comboBoxTrace.Location = new System.Drawing.Point(7, 37);
            this.comboBoxTrace.Name = "comboBoxTrace";
            this.comboBoxTrace.Size = new System.Drawing.Size(60, 21);
            this.comboBoxTrace.TabIndex = 1;
            this.comboBoxTrace.SelectedIndexChanged += new System.EventHandler(this.comboBoxTrace_SelectedIndexChanged);
            // 
            // labelSelectAndConfigureChannel
            // 
            this.labelSelectAndConfigureChannel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectAndConfigureChannel.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectAndConfigureChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectAndConfigureChannel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelSelectAndConfigureChannel.Location = new System.Drawing.Point(5, 14);
            this.labelSelectAndConfigureChannel.Name = "labelSelectAndConfigureChannel";
            this.labelSelectAndConfigureChannel.Size = new System.Drawing.Size(250, 20);
            this.labelSelectAndConfigureChannel.TabIndex = 0;
            this.labelSelectAndConfigureChannel.Text = "1) Select and Configure the Channel";
            // 
            // comboBoxSearchMarker
            // 
            this.comboBoxSearchMarker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchMarker.FormattingEnabled = true;
            this.comboBoxSearchMarker.Location = new System.Drawing.Point(6, 37);
            this.comboBoxSearchMarker.Name = "comboBoxSearchMarker";
            this.comboBoxSearchMarker.Size = new System.Drawing.Size(85, 21);
            this.comboBoxSearchMarker.TabIndex = 1;
            this.comboBoxSearchMarker.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchMarker_SelectedIndexChanged);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxCompressionPointValue);
            this.panelMain.Controls.Add(this.groupBoxSearchForCompressionPoint);
            this.panelMain.Controls.Add(this.groupBoxSelectSearchMarker);
            this.panelMain.Controls.Add(this.groupBoxMoveReferenceMarker);
            this.panelMain.Controls.Add(this.groupBoxlSelectTrace);
            this.panelMain.Controls.Add(this.groupBoxSelectAndConfigureChannel);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(284, 453);
            this.panelMain.TabIndex = 34;
            // 
            // groupBoxCompressionPointValue
            // 
            this.groupBoxCompressionPointValue.Controls.Add(this.labelCompressionPointUnits);
            this.groupBoxCompressionPointValue.Controls.Add(this.labelCompressionPointValue);
            this.groupBoxCompressionPointValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCompressionPointValue.Location = new System.Drawing.Point(12, 385);
            this.groupBoxCompressionPointValue.Name = "groupBoxCompressionPointValue";
            this.groupBoxCompressionPointValue.Size = new System.Drawing.Size(260, 55);
            this.groupBoxCompressionPointValue.TabIndex = 5;
            this.groupBoxCompressionPointValue.TabStop = false;
            this.groupBoxCompressionPointValue.Text = "1 dB Compression Point";
            // 
            // labelCompressionPointUnits
            // 
            this.labelCompressionPointUnits.AutoSize = true;
            this.labelCompressionPointUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompressionPointUnits.Location = new System.Drawing.Point(218, 29);
            this.labelCompressionPointUnits.Name = "labelCompressionPointUnits";
            this.labelCompressionPointUnits.Size = new System.Drawing.Size(36, 16);
            this.labelCompressionPointUnits.TabIndex = 0;
            this.labelCompressionPointUnits.Text = "dBm";
            // 
            // labelCompressionPointValue
            // 
            this.labelCompressionPointValue.BackColor = System.Drawing.Color.Transparent;
            this.labelCompressionPointValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompressionPointValue.Location = new System.Drawing.Point(6, 20);
            this.labelCompressionPointValue.Name = "labelCompressionPointValue";
            this.labelCompressionPointValue.Size = new System.Drawing.Size(218, 29);
            this.labelCompressionPointValue.TabIndex = 0;
            this.labelCompressionPointValue.Text = "--.-------";
            this.labelCompressionPointValue.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBoxSearchForCompressionPoint
            // 
            this.groupBoxSearchForCompressionPoint.Controls.Add(this.checkBoxSearchLoop);
            this.groupBoxSearchForCompressionPoint.Controls.Add(this.labelSearchForCompressionPoint);
            this.groupBoxSearchForCompressionPoint.Controls.Add(this.buttonSearch);
            this.groupBoxSearchForCompressionPoint.Location = new System.Drawing.Point(12, 297);
            this.groupBoxSearchForCompressionPoint.Name = "groupBoxSearchForCompressionPoint";
            this.groupBoxSearchForCompressionPoint.Size = new System.Drawing.Size(260, 81);
            this.groupBoxSearchForCompressionPoint.TabIndex = 4;
            this.groupBoxSearchForCompressionPoint.TabStop = false;
            // 
            // checkBoxSearchLoop
            // 
            this.checkBoxSearchLoop.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSearchLoop.Image = global::CompressionPoint.Properties.Resources.loop_16;
            this.checkBoxSearchLoop.Location = new System.Drawing.Point(219, 36);
            this.checkBoxSearchLoop.Name = "checkBoxSearchLoop";
            this.checkBoxSearchLoop.Size = new System.Drawing.Size(35, 35);
            this.checkBoxSearchLoop.TabIndex = 2;
            this.checkBoxSearchLoop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxSearchLoop.UseVisualStyleBackColor = true;
            this.checkBoxSearchLoop.CheckedChanged += new System.EventHandler(this.checkBoxSearchLoop_CheckedChanged);
            // 
            // labelSearchForCompressionPoint
            // 
            this.labelSearchForCompressionPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSearchForCompressionPoint.BackColor = System.Drawing.Color.Transparent;
            this.labelSearchForCompressionPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSearchForCompressionPoint.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelSearchForCompressionPoint.Location = new System.Drawing.Point(4, 14);
            this.labelSearchForCompressionPoint.Name = "labelSearchForCompressionPoint";
            this.labelSearchForCompressionPoint.Size = new System.Drawing.Size(250, 20);
            this.labelSearchForCompressionPoint.TabIndex = 0;
            this.labelSearchForCompressionPoint.Text = "5) Search for the 1 dB Compression Point";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearch.Location = new System.Drawing.Point(6, 36);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(210, 35);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "&Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // groupBoxSelectSearchMarker
            // 
            this.groupBoxSelectSearchMarker.Controls.Add(this.labelSelectSearchMarker);
            this.groupBoxSelectSearchMarker.Controls.Add(this.comboBoxSearchMarker);
            this.groupBoxSelectSearchMarker.Controls.Add(this.buttonAddMarker);
            this.groupBoxSelectSearchMarker.Controls.Add(this.buttonRemoveMarker);
            this.groupBoxSelectSearchMarker.Location = new System.Drawing.Point(12, 221);
            this.groupBoxSelectSearchMarker.Name = "groupBoxSelectSearchMarker";
            this.groupBoxSelectSearchMarker.Size = new System.Drawing.Size(260, 70);
            this.groupBoxSelectSearchMarker.TabIndex = 3;
            this.groupBoxSelectSearchMarker.TabStop = false;
            // 
            // labelSelectSearchMarker
            // 
            this.labelSelectSearchMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectSearchMarker.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectSearchMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectSearchMarker.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelSelectSearchMarker.Location = new System.Drawing.Point(5, 14);
            this.labelSelectSearchMarker.Name = "labelSelectSearchMarker";
            this.labelSelectSearchMarker.Size = new System.Drawing.Size(250, 20);
            this.labelSelectSearchMarker.TabIndex = 0;
            this.labelSelectSearchMarker.Text = "4) Select a Search Marker";
            // 
            // buttonAddMarker
            // 
            this.buttonAddMarker.Location = new System.Drawing.Point(94, 36);
            this.buttonAddMarker.Name = "buttonAddMarker";
            this.buttonAddMarker.Size = new System.Drawing.Size(79, 23);
            this.buttonAddMarker.TabIndex = 2;
            this.buttonAddMarker.Text = "&Add";
            this.buttonAddMarker.UseVisualStyleBackColor = true;
            this.buttonAddMarker.Click += new System.EventHandler(this.buttonAddMarker_Click);
            // 
            // buttonRemoveMarker
            // 
            this.buttonRemoveMarker.Location = new System.Drawing.Point(175, 36);
            this.buttonRemoveMarker.Name = "buttonRemoveMarker";
            this.buttonRemoveMarker.Size = new System.Drawing.Size(79, 23);
            this.buttonRemoveMarker.TabIndex = 3;
            this.buttonRemoveMarker.Text = "&Remove";
            this.buttonRemoveMarker.UseVisualStyleBackColor = true;
            this.buttonRemoveMarker.Click += new System.EventHandler(this.buttonRemoveMarker_Click);
            // 
            // groupBoxMoveReferenceMarker
            // 
            this.groupBoxMoveReferenceMarker.Controls.Add(this.labelMoveReferenceMarker);
            this.groupBoxMoveReferenceMarker.Location = new System.Drawing.Point(12, 160);
            this.groupBoxMoveReferenceMarker.Name = "groupBoxMoveReferenceMarker";
            this.groupBoxMoveReferenceMarker.Size = new System.Drawing.Size(260, 55);
            this.groupBoxMoveReferenceMarker.TabIndex = 2;
            this.groupBoxMoveReferenceMarker.TabStop = false;
            // 
            // labelMoveReferenceMarker
            // 
            this.labelMoveReferenceMarker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMoveReferenceMarker.BackColor = System.Drawing.Color.Transparent;
            this.labelMoveReferenceMarker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveReferenceMarker.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelMoveReferenceMarker.Location = new System.Drawing.Point(5, 14);
            this.labelMoveReferenceMarker.Name = "labelMoveReferenceMarker";
            this.labelMoveReferenceMarker.Size = new System.Drawing.Size(250, 35);
            this.labelMoveReferenceMarker.TabIndex = 0;
            this.labelMoveReferenceMarker.Text = "3) Move the Reference Marker (R) to a                 Linear Region of the Trace";
            // 
            // groupBoxlSelectTrace
            // 
            this.groupBoxlSelectTrace.Controls.Add(this.buttonS21);
            this.groupBoxlSelectTrace.Controls.Add(this.labelSelectAndConfigureTrace);
            this.groupBoxlSelectTrace.Controls.Add(this.checkBoxReferenceMarker);
            this.groupBoxlSelectTrace.Controls.Add(this.comboBoxTrace);
            this.groupBoxlSelectTrace.Location = new System.Drawing.Point(12, 84);
            this.groupBoxlSelectTrace.Name = "groupBoxlSelectTrace";
            this.groupBoxlSelectTrace.Size = new System.Drawing.Size(260, 70);
            this.groupBoxlSelectTrace.TabIndex = 1;
            this.groupBoxlSelectTrace.TabStop = false;
            // 
            // labelSelectAndConfigureTrace
            // 
            this.labelSelectAndConfigureTrace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectAndConfigureTrace.BackColor = System.Drawing.Color.Transparent;
            this.labelSelectAndConfigureTrace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectAndConfigureTrace.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelSelectAndConfigureTrace.Location = new System.Drawing.Point(5, 14);
            this.labelSelectAndConfigureTrace.Name = "labelSelectAndConfigureTrace";
            this.labelSelectAndConfigureTrace.Size = new System.Drawing.Size(250, 20);
            this.labelSelectAndConfigureTrace.TabIndex = 0;
            this.labelSelectAndConfigureTrace.Text = "2)  Select and Configure the Trace";
            // 
            // checkBoxReferenceMarker
            // 
            this.checkBoxReferenceMarker.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxReferenceMarker.Location = new System.Drawing.Point(137, 36);
            this.checkBoxReferenceMarker.Name = "checkBoxReferenceMarker";
            this.checkBoxReferenceMarker.Size = new System.Drawing.Size(117, 23);
            this.checkBoxReferenceMarker.TabIndex = 2;
            this.checkBoxReferenceMarker.Text = "Ref &Marker On/Off";
            this.checkBoxReferenceMarker.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxReferenceMarker.UseVisualStyleBackColor = true;
            this.checkBoxReferenceMarker.CheckedChanged += new System.EventHandler(this.checkBoxReferenceMarker_CheckedChanged);
            // 
            // groupBoxSelectAndConfigureChannel
            // 
            this.groupBoxSelectAndConfigureChannel.Controls.Add(this.checkBoxPowerSweep);
            this.groupBoxSelectAndConfigureChannel.Controls.Add(this.comboBoxChannel);
            this.groupBoxSelectAndConfigureChannel.Controls.Add(this.labelSelectAndConfigureChannel);
            this.groupBoxSelectAndConfigureChannel.Location = new System.Drawing.Point(12, 8);
            this.groupBoxSelectAndConfigureChannel.Name = "groupBoxSelectAndConfigureChannel";
            this.groupBoxSelectAndConfigureChannel.Size = new System.Drawing.Size(260, 70);
            this.groupBoxSelectAndConfigureChannel.TabIndex = 0;
            this.groupBoxSelectAndConfigureChannel.TabStop = false;
            // 
            // checkBoxPowerSweep
            // 
            this.checkBoxPowerSweep.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxPowerSweep.Location = new System.Drawing.Point(137, 36);
            this.checkBoxPowerSweep.Name = "checkBoxPowerSweep";
            this.checkBoxPowerSweep.Size = new System.Drawing.Size(117, 23);
            this.checkBoxPowerSweep.TabIndex = 2;
            this.checkBoxPowerSweep.Text = "Enable &Power Sweep";
            this.checkBoxPowerSweep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxPowerSweep.UseVisualStyleBackColor = true;
            this.checkBoxPowerSweep.MouseUp += new System.Windows.Forms.MouseEventHandler(this.checkBoxPowerSweep_MouseUp);
            // 
            // timerSearchLoop
            // 
            this.timerSearchLoop.Interval = 1000;
            this.timerSearchLoop.Tick += new System.EventHandler(this.timerSearchLoop_Tick);
            // 
            // buttonS21
            // 
            this.buttonS21.Location = new System.Drawing.Point(70, 36);
            this.buttonS21.Name = "buttonS21";
            this.buttonS21.Size = new System.Drawing.Size(65, 23);
            this.buttonS21.TabIndex = 3;
            this.buttonS21.Text = "&Set to S21";
            this.buttonS21.UseVisualStyleBackColor = true;
            this.buttonS21.Click += new System.EventHandler(this.buttonS21_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 475);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusStrip);
            this.Name = "FormMain";
            this.Text = "< application title goes here >";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.groupBoxCompressionPointValue.ResumeLayout(false);
            this.groupBoxCompressionPointValue.PerformLayout();
            this.groupBoxSearchForCompressionPoint.ResumeLayout(false);
            this.groupBoxSelectSearchMarker.ResumeLayout(false);
            this.groupBoxMoveReferenceMarker.ResumeLayout(false);
            this.groupBoxlSelectTrace.ResumeLayout(false);
            this.groupBoxSelectAndConfigureChannel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVnaInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSpacer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelVersion;
        private System.Windows.Forms.Timer timerReady;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.ComboBox comboBoxChannel;
        private System.Windows.Forms.ComboBox comboBoxTrace;
        private System.Windows.Forms.Label labelSelectAndConfigureChannel;
        private System.Windows.Forms.ComboBox comboBoxSearchMarker;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonRemoveMarker;
        private System.Windows.Forms.Button buttonAddMarker;
        private System.Windows.Forms.GroupBox groupBoxlSelectTrace;
        private System.Windows.Forms.Label labelSelectAndConfigureTrace;
        private System.Windows.Forms.GroupBox groupBoxSelectAndConfigureChannel;
        private System.Windows.Forms.GroupBox groupBoxMoveReferenceMarker;
        private System.Windows.Forms.Label labelMoveReferenceMarker;
        private System.Windows.Forms.GroupBox groupBoxSelectSearchMarker;
        private System.Windows.Forms.Label labelSelectSearchMarker;
        private System.Windows.Forms.GroupBox groupBoxSearchForCompressionPoint;
        private System.Windows.Forms.Label labelSearchForCompressionPoint;
        private System.Windows.Forms.CheckBox checkBoxPowerSweep;
        private System.Windows.Forms.CheckBox checkBoxReferenceMarker;
        private System.Windows.Forms.CheckBox checkBoxSearchLoop;
        private System.Windows.Forms.Timer timerSearchLoop;
        private System.Windows.Forms.GroupBox groupBoxCompressionPointValue;
        private System.Windows.Forms.Label labelCompressionPointUnits;
        private System.Windows.Forms.Label labelCompressionPointValue;
        private System.Windows.Forms.Button buttonS21;
    }
}

