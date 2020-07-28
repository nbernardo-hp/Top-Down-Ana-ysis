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
    public partial class frmBackupView : Form
    {
        public frmBackupView()
        {
            InitializeComponent();
        }//end default constructor

        public frmBackupView(DataTable dt, string name)
        {
            InitializeComponent();
            foreach (DataRow dr in dt.Rows)
            {
                string finviz = (dr.Field<string>("FINVIZ_RANK").Trim() == "-1" ? "NA" : dr.Field<string>("FINVIZ_RANK"));
                ListViewItem row = new ListViewItem(new string[] { dr.Field<string>("NAME"), dr.Field<string>("SYMBOL"), dr.Field<string>("SMA200"), dr.Field<string>("SMA50"), dr.Field<string>("SMA20"), dr.Field<string>("CHART_PATTERN"), dr.Field<string>("UNEXPECTED_ITEMS"), finviz, dr.Field<string>("INDIVIDUAL_RATING") });
                if (dr.Field<string>("TYPE") == "M")
                {
                    listView1.Groups[0].Items.Add(row);
                }
                else
                {
                    listView1.Groups[1].Items.Add(row);
                }//end if-else
                listView1.Items.Add(row);
            }//end foreach

            string[] temp = name.Split(new char[] { '(', ')' });
            this.Text = "Stock Data - " + temp[1];
        }//end Two argument constructor
    }//end frmBackupView
}
