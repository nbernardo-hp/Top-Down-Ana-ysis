using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockTopDownAnalysis
{
    public partial class frmOverallCalculation : Form
    {
        List<bool> res;

        /// <summary>
        /// Two argument constructor.  Populates the ListView with the information from the arrays.
        /// String multidimensional arry contains the stock name and symbol.  Bool array contains whether
        /// it is included in the calculation or not.
        /// </summary>
        public frmOverallCalculation(string[,] stocks, bool[] isChecked)
        {
            InitializeComponent();

            int i = 0;
            foreach(var chk in isChecked)
            {
                lstvOverall.Items.Add(new ListViewItem(new string[] { null, stocks[i, 0], stocks[i, 1] }));
                lstvOverall.Items[i].Checked = (isChecked[i] == true ? true : false);
                i++;
            }//end foreach
        }//end Two argument constructor

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnOk_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnCancel_Click

        private void frmOverallCalculation_FormClosing(object sender, FormClosingEventArgs e)
        {
            res = new List<bool>();
            foreach(ListViewItem item in lstvOverall.Items)
            {
                res.Add(item.Checked);
            }//foreach
        }//end frmOverallCalculation_FormClosing

        public List<bool> getResult() { return res; }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lstvOverall.Items)
            {
                item.Checked = true;
            }
        }//end btnSelectAll_Click

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstvOverall.Items)
            {
                item.Checked = false;
            }
        }//end btnUnselectAll_Click
    }//end frmOverallCalculation
}
