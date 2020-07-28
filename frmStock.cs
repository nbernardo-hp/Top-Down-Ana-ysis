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
    public partial class frmStock : Form
    {
        int addOrEdit;
        int noteAddOrEdit = -1;
        //0 = SMA200, 1 = SMA50, 2 = SMA20, 3 = Chart Pattern, 4 = Unexpected Items
        bool[] cmbSelected = new bool[5];
        Stock stock;
        bool errors = false;
        List<int> noteDeleted = new List<int>();
        public frmStock()
        {
            InitializeComponent();
            stock = new Stock();
            stock.setUsedInCalculation(true);
            this.Text = "New Stock";
            addOrEdit = 0;
        }

        public frmStock(Stock stock, int tab)
        {
            InitializeComponent();
            this.stock = new Stock(stock.getName(), stock.getSymbol(), stock.getSMA200(), stock.getSMA50(), stock.getSMA20(),
                stock.getChartPattern(), stock.getUnexpectedItems(), stock.getFinvizRank(), stock.getIndividualRating(),
                stock.getType());
            this.stock.setUsedInCalculation(true);
            if(stock.getNotes().Count() > 0) { pnlNoNotes.Visible = false; }
            foreach(Note n in stock.getNotes())
            {
                this.stock.addNote(new Note(n.getId(), n.getLines(), n.getDateTime()));
            }
            this.Text = String.Format("{0} ({1})", stock.getName(), stock.getSymbol());
            txtName.Text = this.stock.getName();
            txtName.Enabled = false;
            txtSymbol.Text = this.stock.getSymbol();
            txtSymbol.Enabled = false;
            cmbSMA200.SelectedItem = this.stock.getSMA200();
            cmbSMA50.SelectedItem = this.stock.getSMA50();
            cmbSMA20.SelectedItem = this.stock.getSMA20();
            cmbChartPattern.SelectedItem = this.stock.getChartPattern();
            cmbUnexpectedItems.SelectedItem = this.stock.getUnexpectedItems();
            cmbFinvizRank.SelectedItem = this.stock.getFinvizRank().ToString();
            tabControl1.SelectedTab = (tab == 0 ? tabStock : tabNotes);
            addOrEdit = 1;
        }//two argument constructor

        private void frmStock_Load(object sender, EventArgs e)
        {
            lblFinvizRank.Visible = (stock.getType() == 'S' || this.Text.Contains("New") ? true : false);
            cmbFinvizRank.Visible = (stock.getType() == 'S' || this.Text.Contains("New") ? true : false);
            cmbFinvizRank.Enabled = (stock.getType() == 'S' ? true : false);
            if (addOrEdit == 0)
            {
                stock.setType('M');
                chkSector.Visible = true;
            }//end if
            populateNotesView();
        }//end frmStock_Load

        private void cmbSMA200_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                changeSelectedFlag(cmbSMA200, 0);
                picSMA200Error.Visible = false;
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end cmbSMA200
        private void cmbSMA50_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                changeSelectedFlag(cmbSMA50, 1);
                picSMA50Error.Visible = false;
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end cmbSMA50

        private void cmbSMA20_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                changeSelectedFlag(cmbSMA20, 2);
                picSMA20Error.Visible = false;
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end cmbSMA20

        private void cmbChartPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                changeSelectedFlag(cmbChartPattern, 3);
                picChartPatternError.Visible = false;
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end cmbChartPattern

        private void cmbUnexpectedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                changeSelectedFlag(cmbUnexpectedItems, 4);
                picUnexpectedItemsError.Visible = false;
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end cmbUnexpectedItems

        private void populateNotesView()
        {
            lstNotes.Items.Clear();
            foreach (Note n in stock.getNotes())
            {
                lstNotes.Items.Add(String.Format("{0} at {1} - {2}", n.getDateString(), n.getTimeString(), n.getDisplayLine()));
            }//end foreach

            pnlNoNotes.Visible = (stock.getNotes().Count() > 0 ? false : true);
        }//end populateNotesView
        private void changeSelectedFlag(ComboBox cmb, int index)
        {
            if(cmb.SelectedIndex > -1)
            {
                cmbSelected[index] = true;
                setStockAttribute(index, cmb.SelectedItem.ToString());
            } else
            {
                cmbSelected[index] = false;
            }//end if-else
            checkAllSelected();
        }//end changeSelectedFlag

        private void checkAllSelected()
        {
            bool[] temp = Array.FindAll(cmbSelected, x => x == true);
            if (temp.Length == cmbSelected.Length)
            {
                stock.calculateIndividualRating();
                lblIndividualRating.Text = String.Format("{0:0.0}", stock.getIndividualRating());
            }//end if
        }//end checkAllSelected

        private void setStockAttribute(int index, string value)
        {
            switch(index)
            {
                case 0:
                    stock.setSMA200(value);
                    break;
                case 1:
                    stock.setSMA50(value);
                    break;
                case 2:
                    stock.setSMA20(value);
                    break;
                case 3:
                    stock.setChartPattern(value);
                    break;
                case 4:
                    stock.setUnexpectedItems(value);
                    break;
            }//end switch
        }//end setStockAttribute

        private void toggleNoteButtons()
        {
            if(lstNotes.SelectedIndex > -1)
            {
                tsbEdit.Enabled = true;
                tsbDelete.Enabled = true;
            } else
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
            }//end if-else
        }//end toggleNoteButtons

        private void toggleNoteFields()
        {
            if(noteAddOrEdit > -1)
            {
                btnSaveNote.Visible = true;
                rtbNote.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            } else
            {
                btnSaveNote.Visible = false;
                rtbNote.Enabled = false;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }//end toggleNoteFields

        public Stock getStock() { return stock; }
        public List<int> getDeletedNotes() { return noteDeleted; }
        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleNoteButtons();
            if(lstNotes.SelectedIndex > -1)
            {
                int i = lstNotes.SelectedIndex;
                rtbNote.Lines = stock.getNoteLines(i);
                lblDate.Text = stock.getNoteDateString(i);
                lblTime.Text = stock.getNoteTimeString(i);
                btnSave.Enabled = true;
                btnSaveNote.Visible = false;
                rtbNote.Enabled = false;
            } else
            {
                rtbNote.Clear();
                lblDate.Text = "";
                lblTime.Text = "";
            }//end if-else
        }//end lstNotes_SelectedIndexChanged

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            noteAddOrEdit = 0;
            lstNotes.SelectedIndex = -1;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToShortTimeString();
            rtbNote.Focus();
            toggleNoteFields();
        }//end tsbAdd_Click

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            noteAddOrEdit = 1;
            rtbNote.Focus();
            toggleNoteFields();
        }//end tsbEdit_Click

        private void btnSaveNote_Click(object sender, EventArgs e)
        {
            try
            {
                bool empty = false;
                for(int i = 0; i < rtbNote.Lines.Length; i++)
                {
                    if(rtbNote.Lines[i].Trim() == "")
                    {
                        empty = true;
                        i = rtbNote.Lines.Length;
                    }//end if
                }//end for

                if(rtbNote.Lines.Length > 0 && !empty)
                {
                    if (noteAddOrEdit == 1)
                    {
                        int i = lstNotes.SelectedIndex;
                        stock.setNoteLines(rtbNote.Lines, i);
                        noteAddOrEdit = -1;
                        toggleNoteFields();
                    }
                    else
                    {
                        stock.addNote(new Note(rtbNote.Lines, lblDate.Text, lblTime.Text));
                        noteAddOrEdit = -1;
                        lstNotes.SelectedIndex = -1;
                        rtbNote.Clear();
                        toggleNoteFields();
                    }//end if-else
                    populateNotesView();
                } else
                {
                    MessageBox.Show("The note can't be left blank", "Error");
                }//end if-else
                
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end btnSaveNote_Click

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            int i = lstNotes.SelectedIndex;
            lstNotes.Items.RemoveAt(i);
            if(stock.getNoteAtIndex(i).getId() != -1)
            {
                noteDeleted.Add(stock.getNoteAtIndex(i).getId());
            }//end if
            stock.deleteNote(i);
            populateNotesView();
            noteAddOrEdit = -1;
            toggleNoteFields();
        }//end btnDelete_Click

        private void cmbFinvizRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(cmbFinvizRank.SelectedIndex > -1)
                {
                    int val = int.Parse(cmbFinvizRank.SelectedItem.ToString());
                    stock.setFinvizRank(val);
                    checkAllSelected();
                }//end if
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }//end try-catch
        }//end cmbFinvizRank_SelectedIndexChanged

        private void btnSave_Click(object sender, EventArgs e)
        {
            string errorString = checkErrors();
            if(errorString != "")
            {
                MessageBox.Show("The form has the following errors:\n" + errorString, "Error List", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end if
        }//end btnSave_Click

        private string checkErrors()
        {
            string errorList = "";
            if(txtName.Enabled == true && txtSymbol.Enabled == true)
            {
                if (txtName.Text.Trim() == "")
                {
                    errors = true;
                    picNameError.Visible = true;
                    errorList += "Name can't be left blank.\n";
                }//end if

                string symbolError = "";
                if (txtSymbol.Text.Trim() == "")
                {
                    errors = true;
                    picSymbolError.Visible = true;
                    symbolError += "Symbol can't be left blank.\n";
                    errorList += "Symbol can't be left blank.\n";
                }//end if

                foreach (var s in txtSymbol.Text)
                {
                    if (s < 'A' || s > 'Z')
                    {
                        errors = true;
                        picSymbolError.Visible = true;
                        symbolError += "Symbol must only contain characters from A to Z.";
                        errorList += "Symbol must only contain characters from A to Z.\n";
                        break;
                    }//end if
                }//end foreach
                toolTip1.SetToolTip(picSymbolError, symbolError);
            }//end if

            if (cmbSMA200.SelectedIndex < 0)
            {
                errors = true;
                picSMA200Error.Visible = true;
                errorList += "You must select a value for SMA200.\n";
            }//end if

            if (cmbSMA50.SelectedIndex < 0)
            {
                errors = true;
                picSMA50Error.Visible = true;
                errorList += "You must select a value for SMA50.\n";
            }//end if

            if (cmbSMA20.SelectedIndex < 0)
            {
                errors = true;
                picSMA20Error.Visible = true;
                errorList += "You must select a value for SMA20.\n";
            }//end if

            if (cmbChartPattern.SelectedIndex < 0)
            {
                errors = true;
                picChartPatternError.Visible = true;
                errorList += "You must select a value for Chart Pattern.\n";
            }//end if

            if (cmbUnexpectedItems.SelectedIndex < 0)
            {
                errors = true;
                picUnexpectedItemsError.Visible = true;
                errorList += "You must select a value for Unexpected Items.\n";
            }//end if

            if (stock.getType() == 'S' && cmbFinvizRank.SelectedIndex < 0)
            {
                errors = true;
                picFinvizRankError.Visible = true;
                errorList += "You must select a value for Finviz Rank.";
            }//end if

            return errorList;
        }//end checkErrors

        private void chkSector_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSector.Checked == false)
            {
                cmbFinvizRank.Enabled = false;
                stock.setType('M');
            }
            else
            {
                cmbFinvizRank.Enabled = true;
                stock.setType('S');
            }

            checkAllSelected();
        }

        private void frmStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(errors)
            {
                e.Cancel = true;
                errors = false;
            } else
            {
                stock.setName(txtName.Text.Trim());
                stock.setSymbol(txtSymbol.Text.Trim());
            }//end if-else
        }//end frmStock_FormClosing

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            picNameError.Visible = false;
        }

        private void txtSymbol_TextChanged(object sender, EventArgs e)
        {
            picSymbolError.Visible = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSaveNote.Visible = false;
            rtbNote.Enabled = false;
        }

        private void lstNotes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lstNotes.SelectedIndex > -1)
            {
                tsbEdit.PerformClick();
            }
        }//end lstNotes_MouseDoubleClick
    }//end frmStock
}
