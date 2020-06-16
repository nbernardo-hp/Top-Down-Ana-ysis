namespace StockTopDownAnalysis
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLoadXML = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNotes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tslRating = new System.Windows.Forms.ToolStripLabel();
            this.tslTab = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMarkets = new System.Windows.Forms.TabPage();
            this.dgvMarkets = new System.Windows.Forms.DataGridView();
            this.tabSectors = new System.Windows.Forms.TabPage();
            this.dgvSectors = new System.Windows.Forms.DataGridView();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarketOverallCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMarketDisplayedCols = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSectorOverallCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSectorsDisplayedCols = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMarkets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkets)).BeginInit();
            this.tabSectors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectors)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmExit,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmExit
            // 
            this.tsmExit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSave,
            this.tsmLoadXML,
            this.exitToolStripMenuItem});
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(37, 20);
            this.tsmExit.Text = "File";
            // 
            // tsmSave
            // 
            this.tsmSave.Image = global::StockTopDownAnalysis.Properties.Resources.save;
            this.tsmSave.Name = "tsmSave";
            this.tsmSave.Size = new System.Drawing.Size(180, 22);
            this.tsmSave.Text = "Save";
            this.tsmSave.Click += new System.EventHandler(this.tsmSave_Click);
            // 
            // tsmLoadXML
            // 
            this.tsmLoadXML.Image = global::StockTopDownAnalysis.Properties.Resources.folder;
            this.tsmLoadXML.Name = "tsmLoadXML";
            this.tsmLoadXML.Size = new System.Drawing.Size(180, 22);
            this.tsmLoadXML.Text = "Load XML";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::StockTopDownAnalysis.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbEdit,
            this.toolStripSeparator2,
            this.tsbNotes,
            this.toolStripSeparator3,
            this.tsbDelete,
            this.tslRating,
            this.tslTab});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(686, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tsbAdd.Image = global::StockTopDownAnalysis.Properties.Resources.add_icon;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(57, 24);
            this.tsbAdd.Text = "Add";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Enabled = false;
            this.tsbEdit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tsbEdit.Image = global::StockTopDownAnalysis.Properties.Resources.edit_icon;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(55, 24);
            this.tsbEdit.Text = "Edit";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbNotes
            // 
            this.tsbNotes.Enabled = false;
            this.tsbNotes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tsbNotes.Image = global::StockTopDownAnalysis.Properties.Resources.Note_icon;
            this.tsbNotes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotes.Name = "tsbNotes";
            this.tsbNotes.Size = new System.Drawing.Size(68, 24);
            this.tsbNotes.Text = "Notes";
            this.tsbNotes.Click += new System.EventHandler(this.tsbNotes_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tsbDelete.Image = global::StockTopDownAnalysis.Properties.Resources.Very_Basic_Minus_icon;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(73, 24);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tslRating
            // 
            this.tslRating.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslRating.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tslRating.Name = "tslRating";
            this.tslRating.Size = new System.Drawing.Size(111, 24);
            this.tslRating.Text = "toolStripLabel1";
            // 
            // tslTab
            // 
            this.tslTab.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslTab.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tslTab.Name = "tslTab";
            this.tslTab.Size = new System.Drawing.Size(105, 24);
            this.tslTab.Text = "Market Rating:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMarkets);
            this.tabControl1.Controls.Add(this.tabSectors);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 343);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabMarkets
            // 
            this.tabMarkets.BackColor = System.Drawing.SystemColors.Control;
            this.tabMarkets.Controls.Add(this.dgvMarkets);
            this.tabMarkets.Location = new System.Drawing.Point(4, 22);
            this.tabMarkets.Name = "tabMarkets";
            this.tabMarkets.Padding = new System.Windows.Forms.Padding(3);
            this.tabMarkets.Size = new System.Drawing.Size(678, 317);
            this.tabMarkets.TabIndex = 0;
            this.tabMarkets.Text = "Markets";
            // 
            // dgvMarkets
            // 
            this.dgvMarkets.AllowUserToAddRows = false;
            this.dgvMarkets.AllowUserToDeleteRows = false;
            this.dgvMarkets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarkets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMarkets.Location = new System.Drawing.Point(3, 3);
            this.dgvMarkets.Name = "dgvMarkets";
            this.dgvMarkets.ReadOnly = true;
            this.dgvMarkets.Size = new System.Drawing.Size(672, 311);
            this.dgvMarkets.TabIndex = 0;
            this.dgvMarkets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMarkets_CellClick);
            // 
            // tabSectors
            // 
            this.tabSectors.BackColor = System.Drawing.SystemColors.Control;
            this.tabSectors.Controls.Add(this.dgvSectors);
            this.tabSectors.Location = new System.Drawing.Point(4, 22);
            this.tabSectors.Name = "tabSectors";
            this.tabSectors.Padding = new System.Windows.Forms.Padding(3);
            this.tabSectors.Size = new System.Drawing.Size(678, 317);
            this.tabSectors.TabIndex = 1;
            this.tabSectors.Text = "Sectors";
            // 
            // dgvSectors
            // 
            this.dgvSectors.AllowUserToAddRows = false;
            this.dgvSectors.AllowUserToDeleteRows = false;
            this.dgvSectors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSectors.Location = new System.Drawing.Point(3, 3);
            this.dgvSectors.Name = "dgvSectors";
            this.dgvSectors.ReadOnly = true;
            this.dgvSectors.Size = new System.Drawing.Size(672, 311);
            this.dgvSectors.TabIndex = 0;
            this.dgvSectors.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSectors_CellClick);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.marketToolStripMenuItem,
            this.sectorsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // marketToolStripMenuItem
            // 
            this.marketToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMarketOverallCalc,
            this.tsmMarketDisplayedCols});
            this.marketToolStripMenuItem.Name = "marketToolStripMenuItem";
            this.marketToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.marketToolStripMenuItem.Text = "Markets";
            // 
            // tsmMarketOverallCalc
            // 
            this.tsmMarketOverallCalc.Name = "tsmMarketOverallCalc";
            this.tsmMarketOverallCalc.Size = new System.Drawing.Size(180, 22);
            this.tsmMarketOverallCalc.Text = "Overall Calculation";
            this.tsmMarketOverallCalc.Click += new System.EventHandler(this.tsmMarketOverallCalc_Click);
            // 
            // tsmMarketDisplayedCols
            // 
            this.tsmMarketDisplayedCols.Name = "tsmMarketDisplayedCols";
            this.tsmMarketDisplayedCols.Size = new System.Drawing.Size(180, 22);
            this.tsmMarketDisplayedCols.Text = "Displayed Columns";
            this.tsmMarketDisplayedCols.Click += new System.EventHandler(this.tsmMarketDisplayedCols_Click);
            // 
            // sectorsToolStripMenuItem
            // 
            this.sectorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSectorOverallCalc,
            this.tsmSectorsDisplayedCols});
            this.sectorsToolStripMenuItem.Name = "sectorsToolStripMenuItem";
            this.sectorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sectorsToolStripMenuItem.Text = "Sectors";
            // 
            // tsmSectorOverallCalc
            // 
            this.tsmSectorOverallCalc.Name = "tsmSectorOverallCalc";
            this.tsmSectorOverallCalc.Size = new System.Drawing.Size(180, 22);
            this.tsmSectorOverallCalc.Text = "Overall Calculation";
            this.tsmSectorOverallCalc.Click += new System.EventHandler(this.tsmSectorOverallCalc_Click);
            // 
            // tsmSectorsDisplayedCols
            // 
            this.tsmSectorsDisplayedCols.Name = "tsmSectorsDisplayedCols";
            this.tsmSectorsDisplayedCols.Size = new System.Drawing.Size(180, 22);
            this.tsmSectorsDisplayedCols.Text = "Displayed Columns";
            this.tsmSectorsDisplayedCols.Click += new System.EventHandler(this.tsmSectorsDisplayedCols_Click);
            // 
            // frmTopDownAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 394);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmTopDownAnalysis";
            this.Text = "Top Down Analysis";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTopDownAnalysis_FormClosing);
            this.Load += new System.EventHandler(this.frmTopDownAnalysis_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMarkets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkets)).EndInit();
            this.tabSectors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmSave;
        private System.Windows.Forms.ToolStripMenuItem tsmLoadXML;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbNotes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripLabel tslRating;
        private System.Windows.Forms.ToolStripLabel tslTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMarkets;
        private System.Windows.Forms.DataGridView dgvMarkets;
        private System.Windows.Forms.TabPage tabSectors;
        private System.Windows.Forms.DataGridView dgvSectors;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmMarketOverallCalc;
        private System.Windows.Forms.ToolStripMenuItem tsmMarketDisplayedCols;
        private System.Windows.Forms.ToolStripMenuItem sectorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSectorOverallCalc;
        private System.Windows.Forms.ToolStripMenuItem tsmSectorsDisplayedCols;
    }
}

