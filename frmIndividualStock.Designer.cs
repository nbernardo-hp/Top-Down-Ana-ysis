namespace StockTopDownAnalysis
{
    partial class frmIndividualStock
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstNotes = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSymbol = new System.Windows.Forms.TextBox();
            this.cmbSMA200 = new System.Windows.Forms.ComboBox();
            this.cmbSMA50 = new System.Windows.Forms.ComboBox();
            this.cmbSMA20 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbChartPattern = new System.Windows.Forms.ComboBox();
            this.cmbUnexpectedItems = new System.Windows.Forms.ComboBox();
            this.lblFinvizRank = new System.Windows.Forms.Label();
            this.txtFinvizRank = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(137, 305);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstNotes
            // 
            this.lstNotes.FormattingEnabled = true;
            this.lstNotes.Location = new System.Drawing.Point(12, 201);
            this.lstNotes.Name = "lstNotes";
            this.lstNotes.Size = new System.Drawing.Size(423, 95);
            this.lstNotes.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(62, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(143, 172);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(224, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            this.toolTip1.SetToolTip(this.label1, "Can not be left blank");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Symbol:";
            this.toolTip1.SetToolTip(this.label2, "Must be characters A-Z with a maximum of 4 characters");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "200 SMA:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "50 SMA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(254, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "20 SMA:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(62, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 20);
            this.txtName.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtName, "Can not be left blank");
            // 
            // txtSymbol
            // 
            this.txtSymbol.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSymbol.Location = new System.Drawing.Point(62, 49);
            this.txtSymbol.MaxLength = 4;
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(84, 20);
            this.txtSymbol.TabIndex = 7;
            this.toolTip1.SetToolTip(this.txtSymbol, "Must be characters A-Z with a maximum of 4 characters");
            // 
            // cmbSMA200
            // 
            this.cmbSMA200.FormattingEnabled = true;
            this.cmbSMA200.Items.AddRange(new object[] {
            "Up",
            "Up and Down",
            "Down"});
            this.cmbSMA200.Location = new System.Drawing.Point(314, 12);
            this.cmbSMA200.Name = "cmbSMA200";
            this.cmbSMA200.Size = new System.Drawing.Size(121, 21);
            this.cmbSMA200.TabIndex = 8;
            // 
            // cmbSMA50
            // 
            this.cmbSMA50.FormattingEnabled = true;
            this.cmbSMA50.Items.AddRange(new object[] {
            "Above",
            "At",
            "Below"});
            this.cmbSMA50.Location = new System.Drawing.Point(314, 49);
            this.cmbSMA50.Name = "cmbSMA50";
            this.cmbSMA50.Size = new System.Drawing.Size(121, 21);
            this.cmbSMA50.TabIndex = 8;
            // 
            // cmbSMA20
            // 
            this.cmbSMA20.FormattingEnabled = true;
            this.cmbSMA20.Items.AddRange(new object[] {
            "Above",
            "At",
            "Below"});
            this.cmbSMA20.Location = new System.Drawing.Point(314, 88);
            this.cmbSMA20.Name = "cmbSMA20";
            this.cmbSMA20.Size = new System.Drawing.Size(121, 21);
            this.cmbSMA20.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Chart Pattern:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Unexpected Items:";
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
            this.cmbChartPattern.Location = new System.Drawing.Point(90, 88);
            this.cmbChartPattern.Name = "cmbChartPattern";
            this.cmbChartPattern.Size = new System.Drawing.Size(145, 21);
            this.cmbChartPattern.TabIndex = 8;
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
            this.cmbUnexpectedItems.Location = new System.Drawing.Point(114, 127);
            this.cmbUnexpectedItems.Name = "cmbUnexpectedItems";
            this.cmbUnexpectedItems.Size = new System.Drawing.Size(121, 21);
            this.cmbUnexpectedItems.TabIndex = 8;
            // 
            // lblFinvizRank
            // 
            this.lblFinvizRank.AutoSize = true;
            this.lblFinvizRank.Location = new System.Drawing.Point(254, 130);
            this.lblFinvizRank.Name = "lblFinvizRank";
            this.lblFinvizRank.Size = new System.Drawing.Size(66, 13);
            this.lblFinvizRank.TabIndex = 10;
            this.lblFinvizRank.Text = "Finviz Rank:";
            this.toolTip1.SetToolTip(this.lblFinvizRank, "Must be a number between 1 and 11");
            // 
            // txtFinvizRank
            // 
            this.txtFinvizRank.Location = new System.Drawing.Point(326, 127);
            this.txtFinvizRank.Name = "txtFinvizRank";
            this.txtFinvizRank.Size = new System.Drawing.Size(76, 20);
            this.txtFinvizRank.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtFinvizRank, "Must be a number between 1 and 11");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Notes:";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // frmIndividualStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 342);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFinvizRank);
            this.Controls.Add(this.lblFinvizRank);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbSMA20);
            this.Controls.Add(this.cmbSMA50);
            this.Controls.Add(this.cmbUnexpectedItems);
            this.Controls.Add(this.cmbChartPattern);
            this.Controls.Add(this.cmbSMA200);
            this.Controls.Add(this.txtSymbol);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstNotes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "frmIndividualStock";
            this.Text = "frmIndividualStock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIndividualStock_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstNotes;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSymbol;
        private System.Windows.Forms.ComboBox cmbSMA200;
        private System.Windows.Forms.ComboBox cmbSMA50;
        private System.Windows.Forms.ComboBox cmbSMA20;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbChartPattern;
        private System.Windows.Forms.ComboBox cmbUnexpectedItems;
        private System.Windows.Forms.Label lblFinvizRank;
        private System.Windows.Forms.TextBox txtFinvizRank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}