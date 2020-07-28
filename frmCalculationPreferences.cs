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
    public partial class frmCalculationPreferences : Form
    {
        Dictionary<string, bool> calcMap = new Dictionary<string, bool>();
        public frmCalculationPreferences()
        {
            InitializeComponent();
        }//end default constructor

        public frmCalculationPreferences(Dictionary<string, Stock> map, char type, List<string> calc)
        {
            InitializeComponent();
            int i = 0;
            foreach (var kvp in map)
            {
                if(kvp.Value.getType() == type)
                {
                    string name = kvp.Key + " - " + kvp.Value.getName();
                    bool isChecked = (calc.Contains(kvp.Key) ? true : false);
                    calcMap.Add(kvp.Key, isChecked);
                    lstvStocks.Items.Add(new ListViewItem(new string[] { null, kvp.Value.getName(), kvp.Key }));
                    lstvStocks.Items[i].Checked = (calc.Contains(kvp.Key) ? true : false);
                    i++;
                }//end if
            }//end foreach
        }//end three argument constructor

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lstvStocks.Items)
            {
                item.Checked = true;
            }//end foreach
        }//end btnSelectAll_Click

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstvStocks.Items)
            {
                item.Checked = false;
            }//end foreach
        }//end btnSelectAll_Click
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btnOK_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btnCancel_Click

        /// <summary>
        /// Returns the calculation preferences list to the calling function
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> getCalculationPreferences()
        {
            foreach(ListViewItem item in lstvStocks.Items)
            {
                var symbol = item.SubItems[2].Text.Trim();
                calcMap[symbol] = item.Checked;
            }//end foreach

            return calcMap;
        }//end getCalculationPreferences

    }//end frmCalculationPreferences
}
