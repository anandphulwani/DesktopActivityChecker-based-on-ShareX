
namespace DesktopActivityChecker
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.tabCreateEditEntry = new System.Windows.Forms.TabPage();
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.comboBoxColorMatches = new System.Windows.Forms.ComboBox();
            this.labelColorMatches = new System.Windows.Forms.Label();
            this.entryScaleFactor = new System.Windows.Forms.TextBox();
            this.labelScaleFactor = new System.Windows.Forms.Label();
            this.entryOCRRegexGroup = new System.Windows.Forms.TextBox();
            this.labelOCRRegexGroup = new System.Windows.Forms.Label();
            this.entryOCRRegex = new System.Windows.Forms.TextBox();
            this.labelOCRRegex = new System.Windows.Forms.Label();
            this.comboBoxMatchCaptures = new System.Windows.Forms.ComboBox();
            this.labelMatchCaptures = new System.Windows.Forms.Label();
            this.entrySleepBetweenCaptures = new System.Windows.Forms.TextBox();
            this.labelSleepBetweenCaptures = new System.Windows.Forms.Label();
            this.entryCapturePerInterval = new System.Windows.Forms.TextBox();
            this.labelCapturePerInterval = new System.Windows.Forms.Label();
            this.comboBoxWaitFor = new System.Windows.Forms.ComboBox();
            this.labelWaitFor = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.labelEnabled = new System.Windows.Forms.Label();
            this.entryPostMessage = new System.Windows.Forms.TextBox();
            this.labelPostMessage = new System.Windows.Forms.Label();
            this.entryComparisonValue = new System.Windows.Forms.TextBox();
            this.labelComparisonValue = new System.Windows.Forms.Label();
            this.entryId = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.regionPicker = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.entryPostRequestUrl = new System.Windows.Forms.TextBox();
            this.labelPostRequestUrl = new System.Windows.Forms.Label();
            this.comboBoxComparisonOption = new System.Windows.Forms.ComboBox();
            this.labelComparisonOption = new System.Windows.Forms.Label();
            this.entryRepeatTime = new System.Windows.Forms.TextBox();
            this.labelRepeatTime = new System.Windows.Forms.Label();
            this.entryHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.entryWidth = new System.Windows.Forms.TextBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.entryY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.entryX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.entryName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelHeading = new System.Windows.Forms.Label();
            this.tabEntriesTable = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.isEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameOfEntry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width_W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height_H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepeatTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComparisonOption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WaitFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueToCompare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCRRegex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OCRRegexGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScaleFactor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColorMatches = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SleepBetweenCaptures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CapturePerInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchCaptures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostRequestURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainTabControl.SuspendLayout();
            this.tabCreateEditEntry.SuspendLayout();
            this.tableLayoutMain.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabEntriesTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.tabCreateEditEntry);
            this.mainTabControl.Controls.Add(this.tabEntriesTable);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1032, 616);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabCreateEditEntry
            // 
            this.tabCreateEditEntry.Controls.Add(this.tableLayoutMain);
            this.tabCreateEditEntry.Location = new System.Drawing.Point(4, 22);
            this.tabCreateEditEntry.Name = "tabCreateEditEntry";
            this.tabCreateEditEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateEditEntry.Size = new System.Drawing.Size(1024, 590);
            this.tabCreateEditEntry.TabIndex = 0;
            this.tabCreateEditEntry.Text = "Create/Edit Entry";
            this.tabCreateEditEntry.UseVisualStyleBackColor = true;
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutMain.ColumnCount = 3;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.panelMain, 1, 1);
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1028, 590);
            this.tableLayoutMain.TabIndex = 26;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.comboBoxColorMatches);
            this.panelMain.Controls.Add(this.labelColorMatches);
            this.panelMain.Controls.Add(this.entryScaleFactor);
            this.panelMain.Controls.Add(this.labelScaleFactor);
            this.panelMain.Controls.Add(this.entryOCRRegexGroup);
            this.panelMain.Controls.Add(this.labelOCRRegexGroup);
            this.panelMain.Controls.Add(this.entryOCRRegex);
            this.panelMain.Controls.Add(this.labelOCRRegex);
            this.panelMain.Controls.Add(this.comboBoxMatchCaptures);
            this.panelMain.Controls.Add(this.labelMatchCaptures);
            this.panelMain.Controls.Add(this.entrySleepBetweenCaptures);
            this.panelMain.Controls.Add(this.labelSleepBetweenCaptures);
            this.panelMain.Controls.Add(this.entryCapturePerInterval);
            this.panelMain.Controls.Add(this.labelCapturePerInterval);
            this.panelMain.Controls.Add(this.comboBoxWaitFor);
            this.panelMain.Controls.Add(this.labelWaitFor);
            this.panelMain.Controls.Add(this.buttonReset);
            this.panelMain.Controls.Add(this.checkBoxEnabled);
            this.panelMain.Controls.Add(this.labelEnabled);
            this.panelMain.Controls.Add(this.entryPostMessage);
            this.panelMain.Controls.Add(this.labelPostMessage);
            this.panelMain.Controls.Add(this.entryComparisonValue);
            this.panelMain.Controls.Add(this.labelComparisonValue);
            this.panelMain.Controls.Add(this.entryId);
            this.panelMain.Controls.Add(this.labelId);
            this.panelMain.Controls.Add(this.regionPicker);
            this.panelMain.Controls.Add(this.buttonCreate);
            this.panelMain.Controls.Add(this.entryPostRequestUrl);
            this.panelMain.Controls.Add(this.labelPostRequestUrl);
            this.panelMain.Controls.Add(this.comboBoxComparisonOption);
            this.panelMain.Controls.Add(this.labelComparisonOption);
            this.panelMain.Controls.Add(this.entryRepeatTime);
            this.panelMain.Controls.Add(this.labelRepeatTime);
            this.panelMain.Controls.Add(this.entryHeight);
            this.panelMain.Controls.Add(this.labelHeight);
            this.panelMain.Controls.Add(this.entryWidth);
            this.panelMain.Controls.Add(this.labelWidth);
            this.panelMain.Controls.Add(this.entryY);
            this.panelMain.Controls.Add(this.labelY);
            this.panelMain.Controls.Add(this.entryX);
            this.panelMain.Controls.Add(this.labelX);
            this.panelMain.Controls.Add(this.entryName);
            this.panelMain.Controls.Add(this.labelName);
            this.panelMain.Controls.Add(this.labelHeading);
            this.panelMain.Location = new System.Drawing.Point(283, 3);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(462, 584);
            this.panelMain.TabIndex = 27;
            // 
            // comboBoxColorMatches
            // 
            this.comboBoxColorMatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorMatches.FormattingEnabled = true;
            this.comboBoxColorMatches.Items.AddRange(new object[] {
            "All",
            "Any"});
            this.comboBoxColorMatches.Location = new System.Drawing.Point(144, 365);
            this.comboBoxColorMatches.Name = "comboBoxColorMatches";
            this.comboBoxColorMatches.Size = new System.Drawing.Size(249, 21);
            this.comboBoxColorMatches.TabIndex = 68;
            // 
            // labelColorMatches
            // 
            this.labelColorMatches.AutoSize = true;
            this.labelColorMatches.Location = new System.Drawing.Point(55, 368);
            this.labelColorMatches.Name = "labelColorMatches";
            this.labelColorMatches.Size = new System.Drawing.Size(78, 13);
            this.labelColorMatches.TabIndex = 67;
            this.labelColorMatches.Text = "Color Matches:";
            // 
            // entryScaleFactor
            // 
            this.entryScaleFactor.Location = new System.Drawing.Point(326, 334);
            this.entryScaleFactor.Name = "entryScaleFactor";
            this.entryScaleFactor.Size = new System.Drawing.Size(69, 20);
            this.entryScaleFactor.TabIndex = 66;
            this.entryScaleFactor.Text = "4";
            this.entryScaleFactor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelScaleFactor
            // 
            this.labelScaleFactor.AutoSize = true;
            this.labelScaleFactor.Location = new System.Drawing.Point(254, 337);
            this.labelScaleFactor.Name = "labelScaleFactor";
            this.labelScaleFactor.Size = new System.Drawing.Size(70, 13);
            this.labelScaleFactor.TabIndex = 65;
            this.labelScaleFactor.Text = "Scale Factor:";
            // 
            // entryOCRRegexGroup
            // 
            this.entryOCRRegexGroup.Location = new System.Drawing.Point(146, 334);
            this.entryOCRRegexGroup.Name = "entryOCRRegexGroup";
            this.entryOCRRegexGroup.Size = new System.Drawing.Size(69, 20);
            this.entryOCRRegexGroup.TabIndex = 64;
            this.entryOCRRegexGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelOCRRegexGroup
            // 
            this.labelOCRRegexGroup.AutoSize = true;
            this.labelOCRRegexGroup.Location = new System.Drawing.Point(41, 337);
            this.labelOCRRegexGroup.Name = "labelOCRRegexGroup";
            this.labelOCRRegexGroup.Size = new System.Drawing.Size(99, 13);
            this.labelOCRRegexGroup.TabIndex = 63;
            this.labelOCRRegexGroup.Text = "OCR Regex Group:";
            // 
            // entryOCRRegex
            // 
            this.entryOCRRegex.Location = new System.Drawing.Point(146, 304);
            this.entryOCRRegex.Name = "entryOCRRegex";
            this.entryOCRRegex.Size = new System.Drawing.Size(249, 20);
            this.entryOCRRegex.TabIndex = 62;
            // 
            // labelOCRRegex
            // 
            this.labelOCRRegex.AutoSize = true;
            this.labelOCRRegex.Location = new System.Drawing.Point(40, 307);
            this.labelOCRRegex.Name = "labelOCRRegex";
            this.labelOCRRegex.Size = new System.Drawing.Size(67, 13);
            this.labelOCRRegex.TabIndex = 61;
            this.labelOCRRegex.Text = "OCR Regex:";
            // 
            // comboBoxMatchCaptures
            // 
            this.comboBoxMatchCaptures.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMatchCaptures.FormattingEnabled = true;
            this.comboBoxMatchCaptures.Items.AddRange(new object[] {
            "All",
            "Any"});
            this.comboBoxMatchCaptures.Location = new System.Drawing.Point(144, 431);
            this.comboBoxMatchCaptures.Name = "comboBoxMatchCaptures";
            this.comboBoxMatchCaptures.Size = new System.Drawing.Size(249, 21);
            this.comboBoxMatchCaptures.TabIndex = 60;
            // 
            // labelMatchCaptures
            // 
            this.labelMatchCaptures.AutoSize = true;
            this.labelMatchCaptures.Location = new System.Drawing.Point(55, 434);
            this.labelMatchCaptures.Name = "labelMatchCaptures";
            this.labelMatchCaptures.Size = new System.Drawing.Size(85, 13);
            this.labelMatchCaptures.TabIndex = 59;
            this.labelMatchCaptures.Text = "Match Captures:";
            // 
            // entrySleepBetweenCaptures
            // 
            this.entrySleepBetweenCaptures.Location = new System.Drawing.Point(146, 400);
            this.entrySleepBetweenCaptures.Name = "entrySleepBetweenCaptures";
            this.entrySleepBetweenCaptures.Size = new System.Drawing.Size(69, 20);
            this.entrySleepBetweenCaptures.TabIndex = 58;
            this.entrySleepBetweenCaptures.Text = "250";
            this.entrySleepBetweenCaptures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelSleepBetweenCaptures
            // 
            this.labelSleepBetweenCaptures.Location = new System.Drawing.Point(4, 396);
            this.labelSleepBetweenCaptures.Name = "labelSleepBetweenCaptures";
            this.labelSleepBetweenCaptures.Size = new System.Drawing.Size(144, 31);
            this.labelSleepBetweenCaptures.TabIndex = 57;
            this.labelSleepBetweenCaptures.Text = "Sleep between Captures in Single Interval (milliseconds):";
            // 
            // entryCapturePerInterval
            // 
            this.entryCapturePerInterval.Location = new System.Drawing.Point(326, 400);
            this.entryCapturePerInterval.Name = "entryCapturePerInterval";
            this.entryCapturePerInterval.Size = new System.Drawing.Size(69, 20);
            this.entryCapturePerInterval.TabIndex = 54;
            this.entryCapturePerInterval.Text = "10";
            this.entryCapturePerInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelCapturePerInterval
            // 
            this.labelCapturePerInterval.AutoSize = true;
            this.labelCapturePerInterval.Location = new System.Drawing.Point(220, 404);
            this.labelCapturePerInterval.Name = "labelCapturePerInterval";
            this.labelCapturePerInterval.Size = new System.Drawing.Size(104, 13);
            this.labelCapturePerInterval.TabIndex = 53;
            this.labelCapturePerInterval.Text = "Capture Per Interval:";
            // 
            // comboBoxWaitFor
            // 
            this.comboBoxWaitFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWaitFor.FormattingEnabled = true;
            this.comboBoxWaitFor.Location = new System.Drawing.Point(146, 237);
            this.comboBoxWaitFor.Name = "comboBoxWaitFor";
            this.comboBoxWaitFor.Size = new System.Drawing.Size(249, 21);
            this.comboBoxWaitFor.TabIndex = 52;
            // 
            // labelWaitFor
            // 
            this.labelWaitFor.AutoSize = true;
            this.labelWaitFor.Location = new System.Drawing.Point(90, 240);
            this.labelWaitFor.Name = "labelWaitFor";
            this.labelWaitFor.Size = new System.Drawing.Size(50, 13);
            this.labelWaitFor.TabIndex = 51;
            this.labelWaitFor.Text = "Wait For:";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(259, 552);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 50;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.Location = new System.Drawing.Point(146, 526);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(15, 14);
            this.checkBoxEnabled.TabIndex = 49;
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // labelEnabled
            // 
            this.labelEnabled.AutoSize = true;
            this.labelEnabled.Location = new System.Drawing.Point(91, 525);
            this.labelEnabled.Name = "labelEnabled";
            this.labelEnabled.Size = new System.Drawing.Size(49, 13);
            this.labelEnabled.TabIndex = 48;
            this.labelEnabled.Text = "Enabled:";
            // 
            // entryPostMessage
            // 
            this.entryPostMessage.Location = new System.Drawing.Point(146, 494);
            this.entryPostMessage.Name = "entryPostMessage";
            this.entryPostMessage.Size = new System.Drawing.Size(249, 20);
            this.entryPostMessage.TabIndex = 47;
            // 
            // labelPostMessage
            // 
            this.labelPostMessage.AutoSize = true;
            this.labelPostMessage.Location = new System.Drawing.Point(55, 497);
            this.labelPostMessage.Name = "labelPostMessage";
            this.labelPostMessage.Size = new System.Drawing.Size(85, 13);
            this.labelPostMessage.TabIndex = 46;
            this.labelPostMessage.Text = "POST Message:";
            // 
            // entryComparisonValue
            // 
            this.entryComparisonValue.Location = new System.Drawing.Point(146, 272);
            this.entryComparisonValue.Name = "entryComparisonValue";
            this.entryComparisonValue.Size = new System.Drawing.Size(249, 20);
            this.entryComparisonValue.TabIndex = 45;
            // 
            // labelComparisonValue
            // 
            this.labelComparisonValue.Location = new System.Drawing.Point(12, 251);
            this.labelComparisonValue.Name = "labelComparisonValue";
            this.labelComparisonValue.Size = new System.Drawing.Size(128, 62);
            this.labelComparisonValue.TabIndex = 44;
            this.labelComparisonValue.Text = "Comparison Value:";
            this.labelComparisonValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // entryId
            // 
            this.entryId.Enabled = false;
            this.entryId.Location = new System.Drawing.Point(147, 41);
            this.entryId.Name = "entryId";
            this.entryId.ReadOnly = true;
            this.entryId.Size = new System.Drawing.Size(249, 20);
            this.entryId.TabIndex = 43;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(121, 44);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(19, 13);
            this.labelId.TabIndex = 42;
            this.labelId.Text = "Id:";
            // 
            // regionPicker
            // 
            this.regionPicker.Location = new System.Drawing.Point(405, 102);
            this.regionPicker.Name = "regionPicker";
            this.regionPicker.Size = new System.Drawing.Size(38, 23);
            this.regionPicker.TabIndex = 41;
            this.regionPicker.UseVisualStyleBackColor = true;
            this.regionPicker.Click += new System.EventHandler(this.regionPicker_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(169, 552);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(75, 23);
            this.buttonCreate.TabIndex = 40;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // entryPostRequestUrl
            // 
            this.entryPostRequestUrl.Location = new System.Drawing.Point(146, 463);
            this.entryPostRequestUrl.Name = "entryPostRequestUrl";
            this.entryPostRequestUrl.Size = new System.Drawing.Size(249, 20);
            this.entryPostRequestUrl.TabIndex = 39;
            this.entryPostRequestUrl.Text = "https://www.ntfy.sh/";
            // 
            // labelPostRequestUrl
            // 
            this.labelPostRequestUrl.AutoSize = true;
            this.labelPostRequestUrl.Location = new System.Drawing.Point(33, 466);
            this.labelPostRequestUrl.Name = "labelPostRequestUrl";
            this.labelPostRequestUrl.Size = new System.Drawing.Size(107, 13);
            this.labelPostRequestUrl.TabIndex = 38;
            this.labelPostRequestUrl.Text = "POST Request URL:";
            // 
            // comboBoxComparisonOption
            // 
            this.comboBoxComparisonOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxComparisonOption.FormattingEnabled = true;
            this.comboBoxComparisonOption.Items.AddRange(new object[] {
            "Match from Initial Capture",
            "Match from Last Capture",
            "OCR compare",
            "Check pixel color present",
            "Check same color background"});
            this.comboBoxComparisonOption.Location = new System.Drawing.Point(146, 203);
            this.comboBoxComparisonOption.Name = "comboBoxComparisonOption";
            this.comboBoxComparisonOption.Size = new System.Drawing.Size(249, 21);
            this.comboBoxComparisonOption.TabIndex = 37;
            this.comboBoxComparisonOption.SelectedIndexChanged += new System.EventHandler(this.comboBoxComparisonOption_SelectedIndexChanged);
            // 
            // labelComparisonOption
            // 
            this.labelComparisonOption.AutoSize = true;
            this.labelComparisonOption.Location = new System.Drawing.Point(41, 206);
            this.labelComparisonOption.Name = "labelComparisonOption";
            this.labelComparisonOption.Size = new System.Drawing.Size(99, 13);
            this.labelComparisonOption.TabIndex = 36;
            this.labelComparisonOption.Text = "Comparison Option:";
            // 
            // entryRepeatTime
            // 
            this.entryRepeatTime.Location = new System.Drawing.Point(146, 167);
            this.entryRepeatTime.Name = "entryRepeatTime";
            this.entryRepeatTime.Size = new System.Drawing.Size(100, 20);
            this.entryRepeatTime.TabIndex = 35;
            this.entryRepeatTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelRepeatTime
            // 
            this.labelRepeatTime.AutoSize = true;
            this.labelRepeatTime.Location = new System.Drawing.Point(9, 170);
            this.labelRepeatTime.Name = "labelRepeatTime";
            this.labelRepeatTime.Size = new System.Drawing.Size(131, 13);
            this.labelRepeatTime.TabIndex = 34;
            this.labelRepeatTime.Text = "Repeat Time (in seconds):";
            // 
            // entryHeight
            // 
            this.entryHeight.Location = new System.Drawing.Point(295, 134);
            this.entryHeight.Name = "entryHeight";
            this.entryHeight.Size = new System.Drawing.Size(100, 20);
            this.entryHeight.TabIndex = 33;
            this.entryHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(248, 137);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(41, 13);
            this.labelHeight.TabIndex = 32;
            this.labelHeight.Text = "Height:";
            // 
            // entryWidth
            // 
            this.entryWidth.Location = new System.Drawing.Point(146, 134);
            this.entryWidth.Name = "entryWidth";
            this.entryWidth.Size = new System.Drawing.Size(100, 20);
            this.entryWidth.TabIndex = 31;
            this.entryWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(102, 137);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(38, 13);
            this.labelWidth.TabIndex = 30;
            this.labelWidth.Text = "Width:";
            // 
            // entryY
            // 
            this.entryY.Location = new System.Drawing.Point(295, 103);
            this.entryY.Name = "entryY";
            this.entryY.Size = new System.Drawing.Size(100, 20);
            this.entryY.TabIndex = 29;
            this.entryY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(272, 106);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 13);
            this.labelY.TabIndex = 28;
            this.labelY.Text = "Y:";
            // 
            // entryX
            // 
            this.entryX.Location = new System.Drawing.Point(146, 103);
            this.entryX.Name = "entryX";
            this.entryX.Size = new System.Drawing.Size(100, 20);
            this.entryX.TabIndex = 27;
            this.entryX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(123, 106);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(17, 13);
            this.labelX.TabIndex = 26;
            this.labelX.Text = "X:";
            // 
            // entryName
            // 
            this.entryName.Location = new System.Drawing.Point(146, 71);
            this.entryName.Name = "entryName";
            this.entryName.Size = new System.Drawing.Size(249, 20);
            this.entryName.TabIndex = 25;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(102, 74);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 24;
            this.labelName.Text = "Name:";
            // 
            // labelHeading
            // 
            this.labelHeading.AutoSize = true;
            this.labelHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeading.Location = new System.Drawing.Point(185, 11);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(147, 20);
            this.labelHeading.TabIndex = 23;
            this.labelHeading.Text = "Create/Edit Entry";
            // 
            // tabEntriesTable
            // 
            this.tabEntriesTable.Controls.Add(this.dataGridView1);
            this.tabEntriesTable.Location = new System.Drawing.Point(4, 22);
            this.tabEntriesTable.Name = "tabEntriesTable";
            this.tabEntriesTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabEntriesTable.Size = new System.Drawing.Size(1024, 590);
            this.tabEntriesTable.TabIndex = 1;
            this.tabEntriesTable.Text = "Entries";
            this.tabEntriesTable.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isEnabled,
            this.Edit,
            this.Delete,
            this.Id,
            this.NameOfEntry,
            this.X,
            this.Y,
            this.Width_W,
            this.Height_H,
            this.RepeatTime,
            this.ComparisonOption,
            this.WaitFor,
            this.ValueToCompare,
            this.OCRRegex,
            this.OCRRegexGroup,
            this.ScaleFactor,
            this.ColorMatches,
            this.SleepBetweenCaptures,
            this.CapturePerInterval,
            this.MatchCaptures,
            this.PostRequestURL,
            this.PostMessage});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1018, 584);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // isEnabled
            // 
            this.isEnabled.DataPropertyName = "Enabled";
            this.isEnabled.HeaderText = "";
            this.isEnabled.Name = "isEnabled";
            this.isEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isEnabled.Width = 20;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.Width = 21;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.Width = 21;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 41;
            // 
            // NameOfEntry
            // 
            this.NameOfEntry.DataPropertyName = "Name";
            this.NameOfEntry.HeaderText = "Name";
            this.NameOfEntry.Name = "NameOfEntry";
            this.NameOfEntry.ReadOnly = true;
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.X.DataPropertyName = "X";
            this.X.HeaderText = "X";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            this.X.Width = 39;
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Y.DataPropertyName = "Y";
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.Width = 39;
            // 
            // Width_W
            // 
            this.Width_W.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Width_W.DataPropertyName = "Width";
            this.Width_W.HeaderText = "W";
            this.Width_W.Name = "Width_W";
            this.Width_W.ReadOnly = true;
            this.Width_W.Width = 43;
            // 
            // Height_H
            // 
            this.Height_H.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Height_H.DataPropertyName = "Height";
            this.Height_H.HeaderText = "H";
            this.Height_H.Name = "Height_H";
            this.Height_H.ReadOnly = true;
            this.Height_H.Width = 40;
            // 
            // RepeatTime
            // 
            this.RepeatTime.DataPropertyName = "RepeatTime";
            this.RepeatTime.HeaderText = "RepeatTime";
            this.RepeatTime.Name = "RepeatTime";
            this.RepeatTime.ReadOnly = true;
            this.RepeatTime.Width = 68;
            // 
            // ComparisonOption
            // 
            this.ComparisonOption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ComparisonOption.DataPropertyName = "ComparisonOption";
            this.ComparisonOption.HeaderText = "ComparisonOption";
            this.ComparisonOption.Name = "ComparisonOption";
            this.ComparisonOption.ReadOnly = true;
            this.ComparisonOption.Width = 118;
            // 
            // WaitFor
            // 
            this.WaitFor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.WaitFor.DataPropertyName = "WaitFor";
            this.WaitFor.HeaderText = "WaitFor";
            this.WaitFor.Name = "WaitFor";
            this.WaitFor.ReadOnly = true;
            this.WaitFor.Width = 69;
            // 
            // ValueToCompare
            // 
            this.ValueToCompare.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValueToCompare.DataPropertyName = "ComparisonValue";
            this.ValueToCompare.HeaderText = "ComparisonValue";
            this.ValueToCompare.Name = "ValueToCompare";
            this.ValueToCompare.ReadOnly = true;
            this.ValueToCompare.Width = 114;
            // 
            // OCRRegex
            // 
            this.OCRRegex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OCRRegex.DataPropertyName = "OCRRegex";
            this.OCRRegex.HeaderText = "OCRRegex";
            this.OCRRegex.Name = "OCRRegex";
            this.OCRRegex.ReadOnly = true;
            this.OCRRegex.Width = 86;
            // 
            // OCRRegexGroup
            // 
            this.OCRRegexGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OCRRegexGroup.DataPropertyName = "OCRRegexGroup";
            this.OCRRegexGroup.HeaderText = "OCRRegexGroup";
            this.OCRRegexGroup.Name = "OCRRegexGroup";
            this.OCRRegexGroup.ReadOnly = true;
            this.OCRRegexGroup.Width = 115;
            // 
            // ScaleFactor
            // 
            this.ScaleFactor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ScaleFactor.DataPropertyName = "ScaleFactor";
            this.ScaleFactor.HeaderText = "ScaleFactor";
            this.ScaleFactor.Name = "ScaleFactor";
            this.ScaleFactor.ReadOnly = true;
            this.ScaleFactor.Width = 89;
            // 
            // ColorMatches
            // 
            this.ColorMatches.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColorMatches.DataPropertyName = "ColorMatches";
            this.ColorMatches.HeaderText = "ColorMatches";
            this.ColorMatches.Name = "ColorMatches";
            this.ColorMatches.ReadOnly = true;
            this.ColorMatches.Width = 97;
            // 
            // SleepBetweenCaptures
            // 
            this.SleepBetweenCaptures.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SleepBetweenCaptures.DataPropertyName = "SleepBetweenCaptures";
            this.SleepBetweenCaptures.HeaderText = "SleepBetweenCaptures";
            this.SleepBetweenCaptures.Name = "SleepBetweenCaptures";
            this.SleepBetweenCaptures.ReadOnly = true;
            this.SleepBetweenCaptures.Width = 143;
            // 
            // CapturePerInterval
            // 
            this.CapturePerInterval.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CapturePerInterval.DataPropertyName = "CapturePerInterval";
            this.CapturePerInterval.HeaderText = "CapturePerInterval";
            this.CapturePerInterval.Name = "CapturePerInterval";
            this.CapturePerInterval.ReadOnly = true;
            this.CapturePerInterval.Width = 120;
            // 
            // MatchCaptures
            // 
            this.MatchCaptures.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MatchCaptures.DataPropertyName = "MatchCaptures";
            this.MatchCaptures.HeaderText = "MatchCaptures";
            this.MatchCaptures.Name = "MatchCaptures";
            this.MatchCaptures.ReadOnly = true;
            this.MatchCaptures.Width = 104;
            // 
            // PostRequestURL
            // 
            this.PostRequestURL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PostRequestURL.DataPropertyName = "PostRequestUrl";
            this.PostRequestURL.HeaderText = "PostRequestURL";
            this.PostRequestURL.Name = "PostRequestURL";
            this.PostRequestURL.ReadOnly = true;
            this.PostRequestURL.Width = 115;
            // 
            // PostMessage
            // 
            this.PostMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PostMessage.DataPropertyName = "PostMessage";
            this.PostMessage.HeaderText = "PostMessage";
            this.PostMessage.Name = "PostMessage";
            this.PostMessage.ReadOnly = true;
            this.PostMessage.Width = 96;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 616);
            this.Controls.Add(this.mainTabControl);
            this.Name = "MainForm";
            this.Text = "Desktop Activity Checker";
            this.mainTabControl.ResumeLayout(false);
            this.tabCreateEditEntry.ResumeLayout(false);
            this.tableLayoutMain.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.tabEntriesTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage tabCreateEditEntry;
        private System.Windows.Forms.TabPage tabEntriesTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox entryComparisonValue;
        private System.Windows.Forms.Label labelComparisonValue;
        private System.Windows.Forms.TextBox entryId;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Button regionPicker;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox entryPostRequestUrl;
        private System.Windows.Forms.Label labelPostRequestUrl;
        private System.Windows.Forms.ComboBox comboBoxComparisonOption;
        private System.Windows.Forms.Label labelComparisonOption;
        private System.Windows.Forms.TextBox entryRepeatTime;
        private System.Windows.Forms.Label labelRepeatTime;
        private System.Windows.Forms.TextBox entryHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox entryWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox entryY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox entryX;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.TextBox entryName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox entryPostMessage;
        private System.Windows.Forms.Label labelPostMessage;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Label labelEnabled;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox entryScaleFactor;
        private System.Windows.Forms.Label labelScaleFactor;
        private System.Windows.Forms.TextBox entryOCRRegexGroup;
        private System.Windows.Forms.Label labelOCRRegexGroup;
        private System.Windows.Forms.TextBox entryOCRRegex;
        private System.Windows.Forms.Label labelOCRRegex;
        private System.Windows.Forms.ComboBox comboBoxMatchCaptures;
        private System.Windows.Forms.Label labelMatchCaptures;
        private System.Windows.Forms.TextBox entrySleepBetweenCaptures;
        private System.Windows.Forms.Label labelSleepBetweenCaptures;
        private System.Windows.Forms.TextBox entryCapturePerInterval;
        private System.Windows.Forms.Label labelCapturePerInterval;
        private System.Windows.Forms.ComboBox comboBoxWaitFor;
        private System.Windows.Forms.Label labelWaitFor;
        private System.Windows.Forms.ComboBox comboBoxColorMatches;
        private System.Windows.Forms.Label labelColorMatches;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isEnabled;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOfEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width_W;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height_H;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepeatTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComparisonOption;
        private System.Windows.Forms.DataGridViewTextBoxColumn WaitFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueToCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCRRegex;
        private System.Windows.Forms.DataGridViewTextBoxColumn OCRRegexGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScaleFactor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorMatches;
        private System.Windows.Forms.DataGridViewTextBoxColumn SleepBetweenCaptures;
        private System.Windows.Forms.DataGridViewTextBoxColumn CapturePerInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchCaptures;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRequestURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostMessage;
    }
}

