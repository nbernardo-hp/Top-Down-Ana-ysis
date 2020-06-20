using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace StockTopDownAnalysis
{
    public partial class frmIndividualStock : Form
    {
        //Used to determine if there is an error when attempting to Save.
        bool error = false;
        bool market = false;

        List<Note> notes = new List<Note>();

        /// <summary>
        /// One argument constructor.  Sets the form name and calls populateFields function
        /// Disables the Name and Symbol TextBoxes and hides finviz Label and TextBox if
        /// the table is sectors
        /// </summary>
        /// <param name="table"></param>
        public frmIndividualStock(string table)
        {
            InitializeComponent();
            this.Text = "New " + table;
            populateFields();
            if (table == "Market")
            {
                lblFinvizRank.Visible = false;
                txtFinvizRank.Visible = false;
                market = true;
            }
        }//end one argument constructor

        /// <summary>
        /// 9 argument constructor.  Sets the form name and calls populateFields function
        /// Disables the Name and Symbol TextBoxes and hides finviz Label and TextBox if
        /// the table is sectors
        /// </summary>
        /// <param name="table"></param>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="sma200"></param>
        /// <param name="sma50"></param>
        /// <param name="sma20"></param>
        /// <param name="chart"></param>
        /// <param name="items"></param>
        /// <param name="notes"></param>
        /// <param name="finviz"></param>
        public frmIndividualStock(string table, string name, string symbol, string sma200, string sma50, string sma20, string chart, string items, List<Note> notes, int finviz = -1)
        {
            InitializeComponent();
            try
            {
                this.Text = String.Format("Edit {0}({1})", name, symbol);
                populateFields(name, symbol, sma200, sma50, sma20, chart, items, finviz);
                if (table == "Market")
                {
                    lblFinvizRank.Visible = false;
                    txtFinvizRank.Visible = false;
                    market = true;
                }

                txtName.Enabled = false;
                txtSymbol.Enabled = false;
                this.notes = notes;
                populateListBox();
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end 9 argument constructor

        //Clears and populates lstNotes with the notes for the stock
        private void populateListBox()
        {
            try
            {
                lstNotes.Items.Clear();
                if(notes != null)
                {
                    foreach (Note n in notes)
                    {
                        lstNotes.Items.Add(n.getDateString() + " at " + n.getTimeString() + ": " + n.getViewDisplay());
                    }//end foreach
                }
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end populateListBox

        /// <summary>
        /// Resets the error flag to false to allow the form to close since the action has been cancelled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            error = false;
            this.Close();
        }//end btnCancel_Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            determineErrors();
            this.Close();
        }//end btnSave_Click

        //If there is an error with the form prevent the form from closing and reset the flag
        private void frmIndividualStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(error)
            {
                e.Cancel = true;
                error = false;
            }
        }//end frmIndividualStock_FormClosing

        /// <summary>
        /// Populates the fields on the form.  Each item can be defaulted.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="sma200"></param>
        /// <param name="sma50"></param>
        /// <param name="sma20"></param>
        /// <param name="chart"></param>
        /// <param name="items"></param>
        /// <param name="finviz"></param>
        private void populateFields(string name = "", string symbol = "", string sma200 = "Up", string sma50 = "Above", string sma20 = "Above", string chart = "Bull Run", string items = "No News", int finviz = -1)
        {
            txtName.Text = name;
            txtSymbol.Text = symbol;
            txtFinvizRank.Text = (finviz != -1 ? finviz.ToString() : "");

            cmbSMA200.SelectedItem = sma200;
            cmbSMA50.SelectedItem = sma50;
            cmbSMA20.SelectedItem = sma20;
            cmbChartPattern.SelectedItem = chart;
            cmbUnexpectedItems.SelectedItem = items;
        }//end populateFields

        //Determines if there are errors with the form and sets the flag to true if so
        private void determineErrors()
        {
            try
            {
                //txtName and txtSymbol cannot be left blank if Save is clicked
                //txtFinvizRank can not be anything other than a number and must be less than 12
                txtName.Text.Trim();
                txtSymbol.Text.Trim();
                int finviz = 0;
                bool symbolError = false;
                int symbolLen = txtSymbol.Text.Length;

                for (int i = 0; i < symbolLen; i++)
                {
                    if(txtSymbol.Text[i] < 'A' || txtSymbol.Text[i] > 'Z')
                    {
                        symbolError = true;
                        i = symbolLen;
                    }
                }

                if (!market)
                {
                    int.TryParse(txtFinvizRank.Text.Trim(), out finviz);
                }
                error = (txtName.Text == "" || txtSymbol.Text == "" || symbolError || (!market && (finviz < 1 || finviz > 11)) ? true : false);
                if (txtName.Text == "") { txtName.BackColor = Color.Red; } else { txtName.BackColor = Color.White; }
                if (txtSymbol.Text == "" || symbolError) { txtSymbol.BackColor = Color.Red; } else { txtSymbol.BackColor = Color.White; }
                if (finviz < 1 || finviz > 12) { txtFinvizRank.BackColor = Color.Red; }
                
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
                error = true;
            }
        }//end determineErrors

        /// <summary>
        /// Returns a new Market object to the calling program
        /// </summary>
        /// <returns></returns>
        public Market getMarket()
        {
            try
            {
                Market res = new Market(txtName.Text, txtSymbol.Text, cmbSMA200.SelectedItem.ToString(),
                cmbSMA50.SelectedItem.ToString(), cmbSMA20.SelectedItem.ToString(), cmbChartPattern.SelectedItem.ToString(),
                cmbUnexpectedItems.SelectedItem.ToString(), notes, 0.0);
                res.calculateIndividualRating();
                return res;
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }

            return null;
        }//end getMarket();

        /// <summary>
        /// Returns a new Sector object to the calling program
        /// </summary>
        /// <returns></returns>
        public Sector getSector()
        {
            try
            {
                int finviz = int.Parse(txtFinvizRank.Text);
                Sector res = new Sector(txtName.Text, txtSymbol.Text, cmbSMA200.SelectedItem.ToString(), cmbSMA50.SelectedItem.ToString(), cmbSMA20.SelectedItem.ToString(), cmbChartPattern.SelectedItem.ToString(), cmbUnexpectedItems.SelectedItem.ToString(), notes, finviz, 0.0);
                return res;
            } catch(Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }

            return null;
        }//end getSector();

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstNotes.SelectedIndex > -1)
                {
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
                else
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                }//end if-else
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end lstNotes_SelectedIndexChanged

        private void btnAdd_Click(object sender, EventArgs e)
        {
            displayNotes(txtName.Text);
        }//end btnAdd_Click

        private void btnEdit_Click(object sender, EventArgs e)
        {
            displayNotes(txtName.Text, lstNotes.SelectedIndex);
        }//end btnEdit_Click

        private void displayNotes(string title, int i = -1)
        {
            frmNotes frm = new frmNotes(notes, title, i);
            DialogResult res = frm.ShowDialog();

            if(res == DialogResult.OK)
            {
                notes = frm.getNotes();
                populateListBox();
            }//end if

        }//end displayIndividualNote

        //Deletes a note from the ListBox and object
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int i = lstNotes.SelectedIndex;
                notes.RemoveAt(i);
                lstNotes.Items.RemoveAt(i);
                populateListBox();
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end btnDelete_Click
    }//end frmIndividualStock
}
