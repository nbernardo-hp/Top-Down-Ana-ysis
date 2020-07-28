namespace TopDownAnalysis
{
    partial class frmTopDownAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTopDownAnalysis));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSaveExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLoadXml = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarketCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarketCols = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSectorCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSectorCols = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmActualPerformance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmViewOutlook = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tslOverallRating = new System.Windows.Forms.ToolStripLabel();
            this.tsl = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNotes = new System.Windows.Forms.ToolStripButton();
            this.tabStocks = new System.Windows.Forms.TabControl();
            this.tabMarkets = new System.Windows.Forms.TabPage();
            this.dgvMarkets = new System.Windows.Forms.DataGridView();
            this.tabSectors = new System.Windows.Forms.TabPage();
            this.dgvSectors = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabStocks.SuspendLayout();
            this.tabMarkets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkets)).BeginInit();
            this.tabSectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectors)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.tsmViewOutlook});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmSaveExit,
            this.tsmLoadXml,
            this.tsmExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmSave
            // 
            this.tsmSave.Image = global::TopDownAnalysis.Properties.Resources.save;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(180, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmSaveExit
            // 
            this.tsmSaveExit.Image = global::TopDownAnalysis.Properties.Resources.save;
            this.tsmSaveExit.Name = "tsmSaveExit";
            this.tsmSaveExit.Size = new System.Drawing.Size(180, 22);
            this.tsmSaveExit.Text = "Save and Exit";
            this.tsmSaveExit.Click += new System.EventHandler(this.tsmSaveExit_Click);
            // 
            // tsmLoadXml
            // 
            this.tsmLoadXml.Image = global::TopDownAnalysis.Properties.Resources.folder;
            this.tsmLoadXml.Name = "tsmLoadXml";
            this.tsmLoadXml.Size = new System.Drawing.Size(180, 22);
            this.tsmLoadXml.Text = "Load Backup File";
            this.tsmLoadXml.Click += new System.EventHandler(this.tsmLoadXml_Click);
            // 
            // tsmExit
            // 
            this.tsmExit.Image = global::TopDownAnalysis.Properties.Resources.exit;
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(180, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marketToolStripMenuItem,
            this.sectorToolStripMenuItem,
            this.tsmActualPerformance});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.preferencesToolStripMenuItem.Text = "Settings";
            // 
            // marketToolStripMenuItem
            // 
            this.marketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMarketCalc,
            this.tsmMarketCols});
            this.marketToolStripMenuItem.Name = "marketToolStripMenuItem";
            this.marketToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.marketToolStripMenuItem.Text = "Market";
            // 
            // tsmMarketCalc
            // 
            this.tsmMarketCalc.Name = "tsmMarketCalc";
            this.tsmMarketCalc.Size = new System.Drawing.Size(158, 22);
            this.tsmMarketCalc.Text = "Calculation";
            this.tsmMarketCalc.Click += new System.EventHandler(this.tsmMarketCalc_Click);
            // 
            // tsmMarketCols
            // 
            this.tsmMarketCols.Name = "tsmMarketCols";
            this.tsmMarketCols.Size = new System.Drawing.Size(158, 22);
            this.tsmMarketCols.Text = "Column Display";
            this.tsmMarketCols.Click += new System.EventHandler(this.tsmMarketCols_Click);
            // 
            // sectorToolStripMenuItem
            // 
            this.sectorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSectorCalc,
            this.tsmSectorCols});
            this.sectorToolStripMenuItem.Name = "sectorToolStripMenuItem";
            this.sectorToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.sectorToolStripMenuItem.Text = "Sector";
            // 
            // tsmSectorCalc
            // 
            this.tsmSectorCalc.Name = "tsmSectorCalc";
            this.tsmSectorCalc.Size = new System.Drawing.Size(158, 22);
            this.tsmSectorCalc.Text = "Calculation";
            this.tsmSectorCalc.Click += new System.EventHandler(this.tsmSectorCalc_Click);
            // 
            // tsmSectorCols
            // 
            this.tsmSectorCols.Name = "tsmSectorCols";
            this.tsmSectorCols.Size = new System.Drawing.Size(158, 22);
            this.tsmSectorCols.Text = "Column Display";
            this.tsmSectorCols.Click += new System.EventHandler(this.tsmSectorCols_Click);
            // 
            // tsmActualPerformance
            // 
            this.tsmActualPerformance.Name = "tsmActualPerformance";
            this.tsmActualPerformance.Size = new System.Drawing.Size(222, 22);
            this.tsmActualPerformance.Text = "Actual Performance Prompt";
            this.tsmActualPerformance.Click += new System.EventHandler(this.tsmActualPerformance_Click);
            // 
            // tsmViewOutlook
            // 
            this.tsmViewOutlook.Name = "tsmViewOutlook";
            this.tsmViewOutlook.Size = new System.Drawing.Size(90, 20);
            this.tsmViewOutlook.Text = "View Outlook";
            this.tsmViewOutlook.Click += new System.EventHandler(this.tsmViewOutlook_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbEdit,
            this.toolStripSeparator2,
            this.tsbDelete,
            this.tslOverallRating,
            this.tsl,
            this.toolStripSeparator3,
            this.tsbNotes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(718, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsbAdd.Image = global::TopDownAnalysis.Properties.Resources.add_icon;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(54, 23);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsbEdit.Image = global::TopDownAnalysis.Properties.Resources.edit_icon;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(52, 23);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsbDelete.Image = global::TopDownAnalysis.Properties.Resources.Very_Basic_Minus_icon;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(68, 23);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tslOverallRating
            // 
            this.tslOverallRating.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslOverallRating.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tslOverallRating.Name = "tslOverallRating";
            this.tslOverallRating.Size = new System.Drawing.Size(101, 23);
            this.tslOverallRating.Text = "toolStripLabel1";
            // 
            // tsl
            // 
            this.tsl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsl.Name = "tsl";
            this.tsl.Size = new System.Drawing.Size(92, 23);
            this.tsl.Text = "Overall Score:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbNotes
            // 
            this.tsbNotes.Enabled = false;
            this.tsbNotes.Image = global::TopDownAnalysis.Properties.Resources.Note_icon;
            this.tsbNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotes.Name = "tsbNotes";
            this.tsbNotes.Size = new System.Drawing.Size(58, 23);
            this.tsbNotes.Text = "Notes";
            this.tsbNotes.Click += new System.EventHandler(this.tsbNotes_Click);
            // 
            // tabStocks
            // 
            this.tabStocks.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabStocks.Controls.Add(this.tabMarkets);
            this.tabStocks.Controls.Add(this.tabSectors);
            this.tabStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStocks.Location = new System.Drawing.Point(0, 50);
            this.tabStocks.Name = "tabStocks";
            this.tabStocks.SelectedIndex = 0;
            this.tabStocks.Size = new System.Drawing.Size(718, 415);
            this.tabStocks.TabIndex = 2;
            this.tabStocks.SelectedIndexChanged += new System.EventHandler(this.tabStocks_SelectedIndexChanged);
            // 
            // tabMarkets
            // 
            this.tabMarkets.Controls.Add(this.dgvMarkets);
            this.tabMarkets.Location = new System.Drawing.Point(4, 27);
            this.tabMarkets.Name = "tabMarkets";
            this.tabMarkets.Padding = new System.Windows.Forms.Padding(3);
            this.tabMarkets.Size = new System.Drawing.Size(710, 384);
            this.tabMarkets.TabIndex = 0;
            this.tabMarkets.Text = "Markets";
            this.tabMarkets.UseVisualStyleBackColor = true;
            // 
            // dgvMarkets
            // 
            this.dgvMarkets.AllowUserToAddRows = false;
            this.dgvMarkets.AllowUserToDeleteRows = false;
            this.dgvMarkets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarkets.Location = new System.Drawing.Point(3, 3);
            this.dgvMarkets.MultiSelect = false;
            this.dgvMarkets.Name = "dgvMarkets";
            this.dgvMarkets.ReadOnly = true;
            this.dgvMarkets.Size = new System.Drawing.Size(704, 378);
            this.dgvMarkets.TabIndex = 0;
            this.dgvMarkets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarkets_CellDoubleClick);
            this.dgvMarkets.SelectionChanged += new System.EventHandler(this.dgvMarkets_SelectionChanged);
            // 
            // tabSectors
            // 
            this.tabSectors.Controls.Add(this.dgvSectors);
            this.tabSectors.Location = new System.Drawing.Point(4, 27);
            this.tabSectors.Name = "tabSectors";
            this.tabSectors.Padding = new System.Windows.Forms.Padding(3);
            this.tabSectors.Size = new System.Drawing.Size(710, 384);
            this.tabSectors.TabIndex = 1;
            this.tabSectors.Text = "Sectors";
            this.tabSectors.UseVisualStyleBackColor = true;
            // 
            // dgvSectors
            // 
            this.dgvSectors.AllowUserToAddRows = false;
            this.dgvSectors.AllowUserToDeleteRows = false;
            this.dgvSectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSectors.Location = new System.Drawing.Point(3, 3);
            this.dgvSectors.MultiSelect = false;
            this.dgvSectors.Name = "dgvSectors";
            this.dgvSectors.ReadOnly = true;
            this.dgvSectors.Size = new System.Drawing.Size(704, 378);
            this.dgvSectors.TabIndex = 0;
            this.dgvSectors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSectors_CellDoubleClick);
            // 
            // frmTopDownAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 465);
            this.Controls.Add(this.tabStocks);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTopDownAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top Down Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTopDownAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.frmTopDownAnalysis_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabStocks.ResumeLayout(false);
            this.tabMarkets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkets)).EndInit();
            this.tabSectors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmLoadXml;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmMarketCalc;
        private System.Windows.Forms.ToolStripMenuItem tsmMarketCols;
        private System.Windows.Forms.ToolStripMenuItem sectorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSectorCalc;
        private System.Windows.Forms.ToolStripMenuItem tsmSectorCols;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.TabControl tabStocks;
        private System.Windows.Forms.TabPage tabMarkets;
        private System.Windows.Forms.TabPage tabSectors;
        private System.Windows.Forms.DataGridView dgvMarkets;
        private System.Windows.Forms.DataGridView dgvSectors;
        private System.Windows.Forms.ToolStripLabel tslOverallRating;
        private System.Windows.Forms.ToolStripLabel tsl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbNotes;
        private System.Windows.Forms.ToolStripMenuItem tsmSaveExit;
        private System.Windows.Forms.ToolStripMenuItem tsmViewOutlook;
        private System.Windows.Forms.ToolStripMenuItem tsmActualPerformance;
    }
}

