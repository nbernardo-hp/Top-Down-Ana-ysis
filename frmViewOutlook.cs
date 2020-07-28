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
    public partial class frmViewOutlook : Form
    {
        public frmViewOutlook(DataTable dt)
        {
            InitializeComponent();
            foreach(DataRow dr in dt.Rows)
            {
                listView1.Items.Add(new ListViewItem(new string[] { dr.Field<string>("ESTIMATED_DATE"), dr.Field<string>("ESTIMATED_OUTLOOK"), dr.Field<string>("ACTUAL_DATE"), dr.Field<string>("PERFORMANCE") }));
            }//end foreach
            
        }//end one argument constructor

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end button1_Click
    }
}
