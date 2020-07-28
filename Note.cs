using System;

namespace TopDownAnalysis
{
    public class Note
    {
        private int id;
        private string[] lines;
        private string displayLine;
        private DateTime dateTime;

        public Note()
        {
            setId(-1);
            setLines(new string[1]);
            setDateTime(DateTime.Now);
            setDisplayLine();
        }//end default constructor
        public Note(string[] lines, DateTime dateTime)
        {
            setId(-1);
            setLines(lines);
            setDateTime(dateTime);
            setDisplayLine();
        }//end two argument constructor

        public Note(string[] lines, string date, string time)
        {
            setId(-1);
            setLines(lines);
            setDateTime(date, time);
            setDisplayLine();
        }//end three argument constructor

        public Note(int id, string[] lines, DateTime dateTime)
        {
            setId(id);
            setLines(lines);
            setDateTime(dateTime);
            setDisplayLine();
        }//end three argument constructor

        public Note(int id, string[] lines, string date, string time)
        {
            setId(id);
            setLines(lines);
            setDateTime(date, time);
            setDisplayLine();
        }//end four argument constructor

        //Get methods
        public int getId() { return id; }
        public string[] getLines() { return lines; }
        public string getDisplayLine() { return displayLine; }
        public DateTime getDateTime() { return dateTime; }
        public string getDateString() { return dateTime.ToShortDateString(); }
        public string getTimeString() { return dateTime.ToShortTimeString(); }

        //Set methods
        public void setId(int id) { this.id = id; }
        public void setLines(string[] lines)
        {
            this.lines = lines;
            setDisplayLine();
        }//end setLines

        protected void setDisplayLine() { displayLine = lines[0]; }

        public void setDateTime(DateTime dateTime) { this.dateTime = dateTime; }

        public void setDateTime(string date, string time)
        {
            //Dates will be in the database in MM/DD/YYYY format time in AM-PM cycle
            string[] tempDate = date.Split('/');
            string[] tempTime = time.Split(':');
            int hour = 0;
            if(tempTime[1].Contains("AM") && tempTime[0] == "12")
            {
                hour = 0;
            } else if (tempTime[1].Contains("PM"))
            {
                hour = int.Parse(tempTime[0]);
                hour += (hour < 12 ? 12 : 0);
            }

            this.dateTime = new DateTime(int.Parse(tempDate[2]), int.Parse(tempDate[0]), int.Parse(tempDate[1]), hour, int.Parse(tempTime[1].Remove(2)), 0);
        }//end setDateTime(string, string)
    }//end Note
}//end TopDownAnalysis
