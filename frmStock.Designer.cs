namespace TopDownAnalysis
{
    partial class frmStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStock));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStock = new System.Windows.Forms.TabPage();
            this.picSMA200Error = new System.Windows.Forms.PictureBox();
            this.picSMA50Error = new System.Windows.Forms.PictureBox();
            this.picSMA20Error = new System.Windows.Forms.PictureBox();
            this.picFinvizRankError = new System.Windows.Forms.PictureBox();
            this.picUnexpectedItemsError = new System.Windows.Forms.PictureBox();
            this.picChartPatternError = new System.Windows.Forms.PictureBox();
            this.picSymbolError = new System.Windows.Forms.PictureBox();
            this.picNameError = new System.Windows.Forms.PictureBox();
            this.chkSector = new System.Windows.Forms.CheckBox();
            this.cmbFinvizRank = new System.Windows.Forms.ComboBox();
            this.cmbUnexpectedItems = new System.Windows.Forms.ComboBox();
            this.cmbChartPattern = new System.Windows.Forms.ComboBox();
            this.cmbSMA20 = new System.Windows.Forms.ComboBox();
            this.cmbSMA50 = new System.Windows.Forms.ComboBox();
            this.cmbSMA200 = new System.Windows.Forms.ComboBox();
            this.lblIndividualRating = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblFinvizRank = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabNotes = new System.Windows.Forms.TabPage();
            this.pnlNoNotes = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveNote = new System.Windows.Forms.Button();
            this.rtbNote = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSMA200Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMA50Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMA20Error)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinvizRankError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnexpectedItemsError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChartPatternError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSymbolError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNameError)).BeginInit();
            this.tabNotes.SuspendLayout();
            this.pnlNoNotes.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(216, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(310, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabStock);
            this.tabControl1.Controls.Add(this.tabNotes);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 409);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabStock
            // 
            this.tabStock.Controls.Add(this.picSMA200Error);
            this.tabStock.Controls.Add(this.picSMA50Error);
            this.tabStock.Controls.Add(this.picSMA20Error);
            this.tabStock.Controls.Add(this.picFinvizRankError);
            this.tabStock.Controls.Add(this.picUnexpectedItemsError);
            this.tabStock.Controls.Add(this.picChartPatternError);
            this.tabStock.Controls.Add(this.picSymbolError);
            this.tabStock.Controls.Add(this.picNameError);
            this.tabStock.Controls.Add(this.chkSector);
            this.tabStock.Controls.Add(this.cmbFinvizRank);
            this.tabStock.Controls.Add(this.cmbUnexpectedItems);
            this.tabStock.Controls.Add(this.cmbChartPattern);
            this.tabStock.Controls.Add(this.cmbSMA20);
            this.tabStock.Controls.Add(this.cmbSMA50);
            this.tabStock.Controls.Add(this.cmbSMA200);
            this.tabStock.Controls.Add(this.lblIndividualRating);
            this.tabStock.Controls.Add(this.label10);
            this.tabStock.Controls.Add(this.lblFinvizRank);
            this.tabStock.Controls.Add(this.label8);
            this.tabStock.Controls.Add(this.label7);
            this.tabStock.Controls.Add(this.txtSymbol);
            this.tabStock.Controls.Add(this.label6);
            this.tabStock.Controls.Add(this.txtName);
            this.tabStock.Controls.Add(this.label5);
            this.tabStock.Controls.Add(this.label4);
            this.tabStock.Controls.Add(this.label3);
            this.tabStock.Controls.Add(this.label1);
            this.tabStock.Location = new System.Drawing.Point(4, 27);
            this.tabStock.Name = "tabStock";
            this.tabStock.Padding = new System.Windows.Forms.Padding(3);
            this.tabStock.Size = new System.Drawing.Size(592, 378);
            this.tabStock.TabIndex = 0;
            this.tabStock.Text = "Stock Information";
            this.tabStock.UseVisualStyleBackColor = true;
            // 
            // picSMA200Error
            // 
            this.picSMA200Error.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSMA200Error.BackgroundImage")));
            this.picSMA200Error.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSMA200Error.Location = new System.Drawing.Point(555, 42);
            this.picSMA200Error.Name = "picSMA200Error";
            this.picSMA200Error.Size = new System.Drawing.Size(28, 21);
            this.picSMA200Error.TabIndex = 11;
            this.picSMA200Error.TabStop = false;
            this.toolTip1.SetToolTip(this.picSMA200Error, "You must select a value for SMA200.");
            this.picSMA200Error.Visible = false;
            // 
            // picSMA50Error
            // 
            this.picSMA50Error.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSMA50Error.BackgroundImage")));
            this.picSMA50Error.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSMA50Error.Location = new System.Drawing.Point(524, 101);
            this.picSMA50Error.Name = "picSMA50Error";
            this.picSMA50Error.Size = new System.Drawing.Size(28, 21);
            this.picSMA50Error.TabIndex = 11;
            this.picSMA50Error.TabStop = false;
            this.toolTip1.SetToolTip(this.picSMA50Error, "You must select a value for SMA50.");
            this.picSMA50Error.Visible = false;
            // 
            // picSMA20Error
            // 
            this.picSMA20Error.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSMA20Error.BackgroundImage")));
            this.picSMA20Error.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSMA20Error.Location = new System.Drawing.Point(524, 158);
            this.picSMA20Error.Name = "picSMA20Error";
            this.picSMA20Error.Size = new System.Drawing.Size(28, 21);
            this.picSMA20Error.TabIndex = 11;
            this.picSMA20Error.TabStop = false;
            this.toolTip1.SetToolTip(this.picSMA20Error, "You must select a value for SMA20.");
            this.picSMA20Error.Visible = false;
            // 
            // picFinvizRankError
            // 
            this.picFinvizRankError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picFinvizRankError.BackgroundImage")));
            this.picFinvizRankError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picFinvizRankError.Location = new System.Drawing.Point(476, 214);
            this.picFinvizRankError.Name = "picFinvizRankError";
            this.picFinvizRankError.Size = new System.Drawing.Size(28, 21);
            this.picFinvizRankError.TabIndex = 11;
            this.picFinvizRankError.TabStop = false;
            this.toolTip1.SetToolTip(this.picFinvizRankError, "You must select a value for Finviz Rank.");
            this.picFinvizRankError.Visible = false;
            // 
            // picUnexpectedItemsError
            // 
            this.picUnexpectedItemsError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picUnexpectedItemsError.BackgroundImage")));
            this.picUnexpectedItemsError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picUnexpectedItemsError.Location = new System.Drawing.Point(250, 214);
            this.picUnexpectedItemsError.Name = "picUnexpectedItemsError";
            this.picUnexpectedItemsError.Size = new System.Drawing.Size(28, 21);
            this.picUnexpectedItemsError.TabIndex = 11;
            this.picUnexpectedItemsError.TabStop = false;
            this.toolTip1.SetToolTip(this.picUnexpectedItemsError, "You must select a value for Unexpected Items.");
            this.picUnexpectedItemsError.Visible = false;
            // 
            // picChartPatternError
            // 
            this.picChartPatternError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picChartPatternError.BackgroundImage")));
            this.picChartPatternError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picChartPatternError.Location = new System.Drawing.Point(250, 158);
            this.picChartPatternError.Name = "picChartPatternError";
            this.picChartPatternError.Size = new System.Drawing.Size(28, 21);
            this.picChartPatternError.TabIndex = 11;
            this.picChartPatternError.TabStop = false;
            this.toolTip1.SetToolTip(this.picChartPatternError, "You must select a value for Chart Pattern.");
            this.picChartPatternError.Visible = false;
            // 
            // picSymbolError
            // 
            this.picSymbolError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picSymbolError.BackgroundImage")));
            this.picSymbolError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picSymbolError.Location = new System.Drawing.Point(171, 99);
            this.picSymbolError.Name = "picSymbolError";
            this.picSymbolError.Size = new System.Drawing.Size(28, 21);
            this.picSymbolError.TabIndex = 11;
            this.picSymbolError.TabStop = false;
            this.picSymbolError.Visible = false;
            // 
            // picNameError
            // 
            this.picNameError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picNameError.BackgroundImage")));
            this.picNameError.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picNameError.Location = new System.Drawing.Point(243, 42);
            this.picNameError.Name = "picNameError";
            this.picNameError.Size = new System.Drawing.Size(28, 21);
            this.picNameError.TabIndex = 11;
            this.picNameError.TabStop = false;
            this.toolTip1.SetToolTip(this.picNameError, "Name can\'t be left blank.");
            this.picNameError.Visible = false;
            // 
            // chkSector
            // 
            this.chkSector.AutoSize = true;
            this.chkSector.Location = new System.Drawing.Point(381, 241);
            this.chkSector.Name = "chkSector";
            this.chkSector.Size = new System.Drawing.Size(116, 19);
            this.chkSector.TabIndex = 8;
            this.chkSector.Text = "Stock is a Sector";
            this.chkSector.UseVisualStyleBackColor = true;
            this.chkSector.Visible = false;
            this.chkSector.CheckedChanged += new System.EventHandler(this.chkSector_CheckedChanged);
            // 
            // cmbFinvizRank
            // 
            this.cmbFinvizRank.FormattingEnabled = true;
            this.cmbFinvizRank.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbFinvizRank.Location = new System.Drawing.Point(381, 212);
            this.cmbFinvizRank.Name = "cmbFinvizRank";
            this.cmbFinvizRank.Size = new System.Drawing.Size(89, 23);
            this.cmbFinvizRank.TabIndex = 7;
            this.cmbFinvizRank.SelectedIndexChanged += new System.EventHandler(this.cmbFinvizRank_SelectedIndexChanged);
            // 
            // cmbUnexpectedItems
            // 
            this.cmbUnexpectedItems.FormattingEnabled = true;
            this.cmbUnexpectedItems.Items.AddRange(new object[] {
            "Very Good",
            "Good",
            "Average",
            "Bad",
            "Very Bad",
            "No News"});
            this.cmbUnexpectedItems.Location = new System.Drawing.Point(96, 212);
            this.cmbUnexpectedItems.Name = "cmbUnexpectedItems";
            this.cmbUnexpectedItems.Size = new System.Drawing.Size(148, 23);
            this.cmbUnexpectedItems.TabIndex = 3;
            this.cmbUnexpectedItems.SelectedIndexChanged += new System.EventHandler(this.cmbUnexpectedItems_SelectedIndexChanged);
            // 
            // cmbChartPattern
            // 
            this.cmbChartPattern.FormattingEnabled = true;
            this.cmbChartPattern.Items.AddRange(new object[] {
            "Bull Run",
            "Bull Consolidation",
            "Consolidation",
            "Bear Consolidation",
            "Bear Run"});
            this.cmbChartPattern.Location = new System.Drawing.Point(95, 156);
            this.cmbChartPattern.Name = "cmbChartPattern";
            this.cmbChartPattern.Size = new System.Drawing.Size(149, 23);
            this.cmbChartPattern.TabIndex = 2;
            this.cmbChartPattern.SelectedIndexChanged += new System.EventHandler(this.cmbChartPattern_SelectedIndexChanged);
            // 
            // cmbSMA20
            // 
            this.cmbSMA20.FormattingEnabled = true;
            this.cmbSMA20.Items.AddRange(new object[] {
            "Above",
            "At",
            "Below"});
            this.cmbSMA20.Location = new System.Drawing.Point(381, 156);
            this.cmbSMA20.Name = "cmbSMA20";
            this.cmbSMA20.Size = new System.Drawing.Size(137, 23);
            this.cmbSMA20.TabIndex = 6;
            this.cmbSMA20.SelectedIndexChanged += new System.EventHandler(this.cmbSMA20_SelectedIndexChanged);
            // 
            // cmbSMA50
            // 
            this.cmbSMA50.FormattingEnabled = true;
            this.cmbSMA50.Items.AddRange(new object[] {
            "Above",
            "At",
            "Below"});
            this.cmbSMA50.Location = new System.Drawing.Point(381, 99);
            this.cmbSMA50.Name = "cmbSMA50";
            this.cmbSMA50.Size = new System.Drawing.Size(137, 23);
            this.cmbSMA50.TabIndex = 5;
            this.cmbSMA50.SelectedIndexChanged += new System.EventHandler(this.cmbSMA50_SelectedIndexChanged);
            // 
            // cmbSMA200
            // 
            this.cmbSMA200.FormattingEnabled = true;
            this.cmbSMA200.Items.AddRange(new object[] {
            "Up",
            "Up and Down",
            "Down"});
            this.cmbSMA200.Location = new System.Drawing.Point(412, 42);
            this.cmbSMA200.Name = "cmbSMA200";
            this.cmbSMA200.Size = new System.Drawing.Size(137, 23);
            this.cmbSMA200.TabIndex = 4;
            this.cmbSMA200.SelectedIndexChanged += new System.EventHandler(this.cmbSMA200_SelectedIndexChanged);
            // 
            // lblIndividualRating
            // 
            this.lblIndividualRating.AutoSize = true;
            this.lblIndividualRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndividualRating.Location = new System.Drawing.Point(340, 288);
            this.lblIndividualRating.Name = "lblIndividualRating";
            this.lblIndividualRating.Size = new System.Drawing.Size(0, 17);
            this.lblIndividualRating.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(216, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Individual Rating:";
            // 
            // lblFinvizRank
            // 
            this.lblFinvizRank.AutoSize = true;
            this.lblFinvizRank.Location = new System.Drawing.Point(292, 216);
            this.lblFinvizRank.Name = "lblFinvizRank";
            this.lblFinvizRank.Size = new System.Drawing.Size(73, 15);
            this.lblFinvizRank.TabIndex = 5;
            this.lblFinvizRank.Text = "Finviz Rank:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 5;
            this.label8.Text = "Market News:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Chart Pattern:";
            // 
            // txtSymbol
            // 
            this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Location = new System.Drawing.Point(65, 99);
            this.txtSymbol.MaxLength = 4;
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(100, 21);
            this.txtSymbol.TabIndex = 1;
            this.txtSymbol.TextChanged += new System.EventHandler(this.txtSymbol_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "SMA20:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(58, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(179, 21);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "SMA50:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Both SMA Slopes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Symbol:";
            // 
            // tabNotes
            // 
            this.tabNotes.Controls.Add(this.pnlNoNotes);
            this.tabNotes.Controls.Add(this.lblTime);
            this.tabNotes.Controls.Add(this.lblDate);
            this.tabNotes.Controls.Add(this.label9);
            this.tabNotes.Controls.Add(this.label2);
            this.tabNotes.Controls.Add(this.btnSaveNote);
            this.tabNotes.Controls.Add(this.rtbNote);
            this.tabNotes.Controls.Add(this.toolStrip1);
            this.tabNotes.Controls.Add(this.lstNotes);
            this.tabNotes.Location = new System.Drawing.Point(4, 27);
            this.tabNotes.Name = "tabNotes";
            this.tabNotes.Padding = new System.Windows.Forms.Padding(3);
            this.tabNotes.Size = new System.Drawing.Size(592, 378);
            this.tabNotes.TabIndex = 1;
            this.tabNotes.Text = "Notes";
            this.tabNotes.UseVisualStyleBackColor = true;
            // 
            // pnlNoNotes
            // 
            this.pnlNoNotes.Controls.Add(this.label11);
            this.pnlNoNotes.Location = new System.Drawing.Point(3, 28);
            this.pnlNoNotes.Name = "pnlNoNotes";
            this.pnlNoNotes.Size = new System.Drawing.Size(586, 79);
            this.pnlNoNotes.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(145, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(296, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "This stock has no notes.  Click Add to add a new note.";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(281, 118);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 15);
            this.lblTime.TabIndex = 6;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(50, 118);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 15);
            this.lblDate.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 5;
            this.label9.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(237, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Time:";
            // 
            // btnSaveNote
            // 
            this.btnSaveNote.Location = new System.Drawing.Point(259, 344);
            this.btnSaveNote.Name = "btnSaveNote";
            this.btnSaveNote.Size = new System.Drawing.Size(75, 23);
            this.btnSaveNote.TabIndex = 3;
            this.btnSaveNote.Text = "Save &Note";
            this.btnSaveNote.UseVisualStyleBackColor = true;
            this.btnSaveNote.Visible = false;
            this.btnSaveNote.Click += new System.EventHandler(this.btnSaveNote_Click);
            // 
            // rtbNote
            // 
            this.rtbNote.Enabled = false;
            this.rtbNote.Location = new System.Drawing.Point(1, 144);
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(588, 191);
            this.rtbNote.TabIndex = 12;
            this.rtbNote.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbEdit,
            this.toolStripSeparator2,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(586, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::TopDownAnalysis.Properties.Resources.add_icon;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(49, 22);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Image = global::TopDownAnalysis.Properties.Resources.edit_icon;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(47, 22);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = global::TopDownAnalysis.Properties.Resources.Very_Basic_Minus_icon;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(60, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // lstNotes
            // 
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.ItemHeight = 15;
            this.lstNotes.Location = new System.Drawing.Point(3, 28);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(586, 79);
            this.lstNotes.TabIndex = 11;
            this.lstNotes.SelectedIndexChanged += new System.EventHandler(this.lstNotes_SelectedIndexChanged);
            this.lstNotes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstNotes_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(600, 450);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 7;
            // 
            // frmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStock";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStock_FormClosing);
            this.Load += new System.EventHandler(this.frmStock_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStock.ResumeLayout(false);
            this.tabStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSMA200Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMA50Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSMA20Error)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFinvizRankError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUnexpectedItemsError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChartPatternError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSymbolError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNameError)).EndInit();
            this.tabNotes.ResumeLayout(false);
            this.tabNotes.PerformLayout();
            this.pnlNoNotes.ResumeLayout(false);
            this.pnlNoNotes.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStock;
        private System.Windows.Forms.TabPage tabNotes;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveNote;
        private System.Windows.Forms.RichTextBox rtbNote;
        private System.Windows.Forms.ListBox lstNotes;
        private System.Windows.Forms.Label lblIndividualRating;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblFinvizRank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbUnexpectedItems;
        private System.Windows.Forms.ComboBox cmbChartPattern;
        private System.Windows.Forms.ComboBox cmbSMA20;
        private System.Windows.Forms.ComboBox cmbSMA50;
        private System.Windows.Forms.ComboBox cmbSMA200;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFinvizRank;
        private System.Windows.Forms.CheckBox chkSector;
        private System.Windows.Forms.PictureBox picNameError;
        private System.Windows.Forms.PictureBox picSMA200Error;
        private System.Windows.Forms.PictureBox picSMA50Error;
        private System.Windows.Forms.PictureBox picSMA20Error;
        private System.Windows.Forms.PictureBox picFinvizRankError;
        private System.Windows.Forms.PictureBox picUnexpectedItemsError;
        private System.Windows.Forms.PictureBox picChartPatternError;
        private System.Windows.Forms.PictureBox picSymbolError;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel pnlNoNotes;
        private System.Windows.Forms.Label label11;
    }
}