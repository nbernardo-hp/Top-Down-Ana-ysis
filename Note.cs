using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTopDownAnalysis
{
    public class Note
    {
        private int id;
        private string viewDisplay;
        private string[] note;
        private DateTime date;
        private DateTime time;

        public Note()
        {
            note = new string[1];
            date = DateTime.Today;
            time = DateTime.Now;
            viewDisplay = note[0];
        }//end default constructor

        public Note(string[] note)
        {
            this.note = note;
            date = DateTime.Today;
            time = DateTime.Now;
            viewDisplay = note[0];
        }//end 1 argument constructor

        public Note(string[] note, DateTime date)
        {
            this.note = note;
            this.date = date;
            time = DateTime.Now;
            viewDisplay = note[0];
        }//end 2 argument constructor

        //Get methods
        public int getId() { return id; }
        public string[] getNote() { return note; }
        public DateTime getDate() { return date; }
        public string getDateString() { return date.ToShortDateString(); }
        public DateTime getTime() { return time; }
        public string getTimeString() { return time.ToShortTimeString(); }
        public string getViewDisplay() { return viewDisplay; }
        //Set methods
        public void setId(int id) { this.id = id; }
        public void setNote(string[] note) { this.note = note; }
        public void setDate(DateTime date) { this.date = date; }
        public void setTime(DateTime time) { this.time = time; }

        private void setViewDisplay() { viewDisplay = note[0]; }

    }//end Note
}
