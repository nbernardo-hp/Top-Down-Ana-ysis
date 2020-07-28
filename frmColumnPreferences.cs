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
    public partial class frmColumnPreferences : Form
    {
        public frmColumnPreferences()
        {
            InitializeComponent();
        }//end default constructor

        private void lstAllCols_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleButtons();
        }//end lstAllCols_SelectedIndexChanged
        private void lstConfiguredCols_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleButtons();
        }//end lstConfiguredCols_SelectedIndexChanged

        private void lstConfiguredCols_Click(object sender, EventArgs e)
        {
            lstAllCols.SelectedIndex = -1;
        }//end lstConfiguredCols_Click

        private void lstAllCols_Click(object sender, EventArgs e)
        {
            lstConfiguredCols.SelectedIndex = -1;
        }//end lstAllCols_Click

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string column = lstAllCols.SelectedItem.ToString();
            lstConfiguredCols.Items.Add(column);
            lstAllCols.Items.Remove(column);
        }//end btnAdd_Click

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string column = lstConfiguredCols.SelectedItem.ToString();
            lstAllCols.Items.Add(column);
            lstConfiguredCols.Items.Remove(column);
        }//end btnRemove_Click

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i = lstConfiguredCols.SelectedIndex;
            var temp = lstConfiguredCols.Items[i];
            lstConfiguredCols.Items[i] = lstConfiguredCols.Items[i - 1];
            lstConfiguredCols.Items[i-1] = temp;
            lstConfiguredCols.SelectedIndex = i - 1;
        }//end btnUp_Click

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i = lstConfiguredCols.SelectedIndex;
            var temp = lstConfiguredCols.Items[i];
            lstConfiguredCols.Items[i] = lstConfiguredCols.Items[i + 1];
            lstConfiguredCols.Items[i + 1] = temp;
            lstConfiguredCols.SelectedIndex = i + 1;
        }//end btnDown_Click
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnOK_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnCancel_Click
        private void toggleButtons()
        {
            btnAdd.Enabled = (lstAllCols.SelectedIndex > -1 ? true : false);
            btnRemove.Enabled = (lstConfiguredCols.SelectedIndex > -1 && lstConfiguredCols.SelectedItem.ToString().Trim() != "SYMBOL" ? true : false);
            btnUp.Enabled = (lstConfiguredCols.SelectedIndex > 0 ? true : false);
            btnDown.Enabled = (lstConfiguredCols.SelectedIndex < lstConfiguredCols.Items.Count - 1 && lstConfiguredCols.SelectedIndex > -1 ? true : false);
        }//end enableButtons
        public void setFormInformation(string table, Dictionary<string, bool> map)
        {
            this.Text = table + " Column Preferences";
            foreach(var kvp in map)
            {
                if(kvp.Value)
                {
                    lstConfiguredCols.Items.Add(kvp.Key);
                } else
                {
                    lstAllCols.Items.Add(kvp.Key);
                }//end if-else
            }//end foreach
        }//end setFormInformation


        public Dictionary<string, bool> getColumns()
        {
            Dictionary<string, bool> res = new Dictionary<string, bool>();

            List<ListBox> lists = new List<ListBox>() { lstConfiguredCols, lstAllCols };
            foreach(var list in this.Controls.OfType<ListBox>().Reverse())
            {
                bool display = (list.Name == "lstConfiguredCols" ? true : false);
                foreach(var l in list.Items)
                {
                    res.Add(l.ToString(), display);
                }//end nested foreach
            }//end foreach

            return res;
        }
    }//end frmColumnPreferences
}
