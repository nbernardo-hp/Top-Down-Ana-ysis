using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTopDownAnalysis
{
    public partial class frmColumns : Form
    {
        /// <summary>
        /// Initalizes the form and adds the items from the Lists to the ListBoxes
        /// </summary>
        /// <param name="table"></param>
        /// <param name="attributes"></param>
        /// <param name="cols"></param>
        public frmColumns(string table, List<string> attributes, List<string> cols)
        {
            InitializeComponent();
            this.Text = "Congifure " + table + " Columns";
            foreach(string a in attributes)
            {
                if(!cols.Contains(a))
                {
                    lstAllCols.Items.Add(a);
                }//end if
            }//end foreach

            foreach(string c in cols)
            {
                lstMyCols.Items.Add(c);
            }
        }//end 2 argument constructor

        /// <summary>
        /// Removes a list item from lstAllCols and adds it to lstMyCols
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string col = lstAllCols.SelectedItem.ToString();
                lstMyCols.Items.Add(col);
                lstAllCols.Items.Remove(col);
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end btnAdd_Click

        /// <summary>
        /// Removes a list item from lstMyCols and adds it to lstAllCols
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                string col = lstMyCols.SelectedItem.ToString();
                lstAllCols.Items.Add(col);
                lstMyCols.Items.Remove(col);
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end btnRemove_Click

        /// <summary>
        /// Moves the selected item in lstMyCols up and sets the SelectedIndex to the moved item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if(lstMyCols.SelectedIndex != 0)
                {
                    int index = lstMyCols.SelectedIndex;
                    string temp = lstMyCols.Items[index].ToString();
                    lstMyCols.Items[index] = lstMyCols.Items[index - 1];
                    lstMyCols.Items[index - 1] = temp;
                    lstMyCols.SelectedIndex = index - 1;
                }//end if
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end btnUp_Click

        /// <summary>
        /// Moves the selected item in lstMyCols down and sets the SelectedIndex to the moved item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                int i = lstMyCols.SelectedIndex;
                if(i != lstMyCols.Items.Count - 1)
                {
                    var temp = lstMyCols.Items[i];
                    lstMyCols.Items[i] = lstMyCols.Items[i + 1];
                    lstMyCols.Items[i + 1] = temp;
                    lstMyCols.SelectedIndex = i + 1;
                }//end if
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end btnDown_Click

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstAllCols_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButtons();
        }//end lstAllCols_SelectedIndexChanged

        private void lstMyCols_SelectedIndexChanged(object sender, EventArgs e)
        {
            enableButtons();
        }//end lstMyCols_SelectedIndexChanged

        /// <summary>
        /// Enables the buttons on the from depending on which ListBox Item is selected
        /// </summary>
        private void enableButtons()
        {
            if(lstAllCols.SelectedIndex == -1)
            {
                btnAdd.Enabled = false;
            } else
            {
                btnAdd.Enabled = true;
            }

            if(lstMyCols.SelectedIndex == -1)
            {
                btnRemove.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
            } else
            {
                btnRemove.Enabled = (lstMyCols.SelectedItem.ToString() == "SYMBOL" ? false : true);
                btnUp.Enabled = (lstMyCols.SelectedIndex > 0 ? true : false);
                btnDown.Enabled = (lstMyCols.SelectedIndex < lstMyCols.Items.Count - 1 ? true : false);
            }
        }//end enableButtons

        /// <summary>
        /// Returns a list of the selected columns to display to the calling function
        /// </summary>
        /// <returns></returns>
        public List<string> getColumns()
        {
            List<string> res = new List<string>();

            foreach(var col in lstMyCols.Items)
            {
                res.Add(col.ToString());
            }

            return res;
        }
    }//end frmColumns
}
