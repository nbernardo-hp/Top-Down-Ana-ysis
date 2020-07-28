namespace TopDownAnalysis
{
    partial class frmViewOutlook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewOutlook));
            this.listView1 = new System.Windows.Forms.ListView();
            this.EST_DATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EST_OUTLOOK = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ACTUAL_DATE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PERFORMANCE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EST_DATE,
            this.EST_OUTLOOK,
            this.ACTUAL_DATE,
            this.PERFORMANCE});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 12);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(478, 359);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // EST_DATE
            // 
            this.EST_DATE.Tag = "EST_DATE";
            this.EST_DATE.Text = "Est. Outlook Date";
            this.EST_DATE.Width = 100;
            // 
            // EST_OUTLOOK
            // 
            this.EST_OUTLOOK.Tag = "EST_OUTLOOK";
            this.EST_OUTLOOK.Text = "Est. Outlook";
            this.EST_OUTLOOK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EST_OUTLOOK.Width = 75;
            // 
            // ACTUAL_DATE
            // 
            this.ACTUAL_DATE.Tag = "ACTUAL_DATE";
            this.ACTUAL_DATE.Text = "Actual Outlook Date";
            this.ACTUAL_DATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ACTUAL_DATE.Width = 115;
            // 
            // PERFORMANCE
            // 
            this.PERFORMANCE.Tag = "PERFORMANCE";
            this.PERFORMANCE.Text = "Performance";
            this.PERFORMANCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PERFORMANCE.Width = 184;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmViewOutlook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 409);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewOutlook";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Outlook";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader EST_DATE;
        private System.Windows.Forms.ColumnHeader EST_OUTLOOK;
        private System.Windows.Forms.ColumnHeader ACTUAL_DATE;
        private System.Windows.Forms.ColumnHeader PERFORMANCE;
    }
}