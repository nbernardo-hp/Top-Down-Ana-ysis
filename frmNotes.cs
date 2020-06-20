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
        List<Note> notes = new List<Note>();
        int index = -1;
        DateTime time;
        bool saved = true;
        public frmNotes()
        {
            InitializeComponent();
        }//end default constructor

        /// <summary>
        /// Two argument constructor.  Calls the createNotes function and sets the name of the form
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="name"></param>
        public frmNotes(List<Note> notes, string name)
        {
            InitializeComponent();
            try
            {
                createNotes(notes);
                this.Text = name + " Notes";
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end 2 argument constructor

        /// <summary>
        /// Three argument constructor.  Calls the createNotes function, sets the name of the form
        /// and determines if the note is being edited or a new one is being added.
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="name"></param>
        /// <param name="i"></param>
        public frmNotes(List<Note> notes, string name, int i)
        {
            InitializeComponent();
            try
            {
                createNotes(notes);
                if(i > -1)
                {
                    index = i;
                } else if (i == -2)
                {
                    tsbAdd.PerformClick();
                }
                this.Text = name + " Notes";
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end three argument constructor

        /// <summary>
        /// Creates a new note object for the items being sent to the form to prevent the
        /// note from being overwritten or deleted without hitting the Ok button
        /// </summary>
        /// <param name="notes"></param>
        private void createNotes(List<Note> notes)
        {
            if(notes != null)
            {
                foreach (Note note in notes)
                {
                    this.notes.Add(new Note(note.getNote(), note.getDate(), note.getTime()));
                }
            }
        }//end createNotes

        /// <summary>
        /// Loads the notes into the ListBox.  If index is greater than -1 as the form loads
        /// set the selected index of lstNotes, enable Panel2 and make btnSave visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNotes_Load(object sender, EventArgs e)
        {
            try
            {
                populateListBox();
                if(index > -1)
                {
                    lstNotes.SelectedIndex = index;
                    splitContainer1.Panel2.Enabled = true;
                    btnSave.Visible = true;
                }//end if
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//end frmNotes_Load
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                lstNotes.SelectedIndex = -1;
                splitContainer1.Panel2.Enabled = true;
                time = DateTime.Now;
                lblTime.Text = time.ToShortTimeString();
                rtbNote.ResetText();
                btnSave.Visible = true;
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
                btnSave.Visible = true;
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
                notes.RemoveAt(index);
                lstNotes.Items.RemoveAt(index);
                saved = false;
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            }
        }//tsbDelete_Click

        private void lstNotes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                index = lstNotes.SelectedIndex;
                if (index > -1)
                {
                    enableButtons();
                    dtpDate.Value = notes[index].getDate();
                    lblTime.Text = notes[index].getTimeString();
                    rtbNote.Lines = notes[index].getNote();
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
            finally
            {
                splitContainer1.Panel2.Enabled = false;
                btnSave.Visible = false;
            }
        }//end lstNotes_SelectedIndexChanged

        private void btnOk_Click(object sender, EventArgs e)
        {
            saved = true;
            this.Close();
        }//end btnOk_Click

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

        /// <summary>
        /// Creates a new note if the index is -1 otherwise changes the sets the note date and
        /// strings to what is in the textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(index == -1)
                {
                    Note note = new Note(rtbNote.Lines, dtpDate.Value, time);
                    notes.Add(note);
                } else
                {
                    notes[index].setDate(dtpDate.Value);
                    notes[index].setNote(rtbNote.Lines);
                }//end if-else
            } catch (Exception ex)
            {
                frmTopDownAnalysis.errorMessage(ex);
            } finally
            {
                saved = false;
                rtbNote.ResetText();
                lblTime.Text = "";
                btnSave.Visible = false;
                splitContainer1.Panel2.Enabled = false;
                populateListBox();
            }
        }//end btnSave_Click

        private void populateListBox()
        {
            lstNotes.Items.Clear();
            if(notes != null)
            {
                foreach (Note n in notes)
                {
                    lstNotes.Items.Add(n.getDateString() + " at " + n.getTimeString() + ": " + n.getViewDisplay());
                }//end foreach
            }
        }//end populateListBox

        private void frmNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!saved)
            {
                DialogResult res = MessageBox.Show("There are unsaved changes to the notes for this stock.  Would you like to save the changes?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.OK;
                } else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }//end nested if-else
            }//end if
        }//end frmNotes_FormClosing
    }//end frmNotes
}
