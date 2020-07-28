using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopDownAnalysis
{
    public partial class frmActualPerformance : Form
    {
        int state = -1;
        public frmActualPerformance()
        {
            InitializeComponent();
        }

        public frmActualPerformance(int state, int days)
        {
            InitializeComponent();
            this.state = state;
            if(state == 0)
            {
                panel1.Visible = true;
                nudDays.Value = days;
                this.ControlBox = true;
                this.Text = "Performance Prompt Settings";
                btnOK.Location = new Point(74, 108);
                Button btnCancel = new Button();
                btnCancel.Text = "Cancel";
                btnCancel.DialogResult = DialogResult.Cancel;
                btnCancel.Location = new Point(166, 108);
                this.Controls.Add(btnCancel);
            }//end if
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string getPerformance() { return txtPerformance.Text; }

        public int getPromptDays() { return (int)nudDays.Value; }
        private void frmActualPerformance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(state == -1 && txtPerformance.Text.Trim() == "")
            {
                e.Cancel = true;
                MessageBox.Show("You must enter the performance for last week in the text box");
            } else if (state == 0 && nudDays.Value < 1 && this.DialogResult != DialogResult.Cancel)
            {
                e.Cancel = true;
                MessageBox.Show("The number of days between prompts must be greater than or equal to 1");
            }//end if-else if
        }
    }//end frmActualPerformance
}
