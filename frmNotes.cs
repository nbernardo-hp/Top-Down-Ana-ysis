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
    public partial class frmNotes : Form
    {
        List<Note> notes;
        public frmNotes()
        {
            InitializeComponent();
        }//end default constructor

        public frmNotes(List<Note> notes, string name)
        {
            InitializeComponent();
            this.notes = notes;
            this.Text = name + " Notes";
        }//end 2 argument constructor

        /// <summary>
        /// Loads the notes into the ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNotes_Load(object sender, EventArgs e)
        {
            foreach(Note n in notes)
            {
                lstNotes.Items.Add(n.getDateString() + " at " + n.getTimeString() + ": " + n.getViewDisplay());
            }//end foreach
        }//end frmNotes_Load

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end tsbAdd_Click

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.Panel2.Enabled = true;
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end tsbEdit_Click

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {

            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//tsbDelete_Click

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstNotes.SelectedIndex > -1)
                {
                    int i = lstNotes.SelectedIndex;
                    enableButtons();
                    dtpDate.Value = notes[i].getDate();
                    lblTime.Text = notes[i].getTimeString();
                }
                else
                {
                    disableButtons();
                    dtpDate.Value = DateTime.Today;
                    lblTime.Text = "";
                    rtbNote.ResetText();
                }
            }
            catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end lstNotes_SelectedIndexChanged

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnSave_Click

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end btnCancel_Click

        private void enableButtons()
        {
            tsbEdit.Enabled = true;
            tsbDelete.Enabled = true;
        }//end enableButtons

        private void disableButtons()
        {
            tsbEdit.Enabled = false;
            tsbDelete.Enabled = false;
        }//end disableButtons

        public List<Note> getNotes() { return notes; }
    }//end frmNotes
}
