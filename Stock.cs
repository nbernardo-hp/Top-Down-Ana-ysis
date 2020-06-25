using System;
using System.Collections.Generic;

namespace TopDownAnalysis
{
    public class Stock
    {
        private string name;
        private string symbol;
        private string SMA200;
        private string SMA50;
        private string SMA20;
        private string chartPattern;
        private string unexpectedItems;
        private int finvizRank;
        private double individualRating;
        bool usedInCalculation;
        char type;
        private List<Note> notes;
        


        /// <summary>
        /// No argument constructor.  Defaults strings to "" and double to 0.0.  Does nothing with the list
        /// </summary>
        public Stock()
        {
            setName("");
            setSymbol("");
            setSMA200("");
            setSMA50("");
            setSMA20("");
            setChartPattern("");
            setUnexpectedItems("");
            setFinvizRank(-1);
            setIndividualRating(0.0);
            setType('M');
            notes = new List<Note>();
        }

        /// <summary>
        /// Ten argument constructor.  Sets the strings, char, and double to the provided input.  Does nothing with the list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="SMA200"></param>
        /// <param name="SMA50"></param>
        /// <param name="SMA20"></param>
        /// <param name="chartPattern"></param>
        /// <param name="unexpectedItems"></param>
        /// <param name="finvizRank"></param>
        /// <param name="individualRating"></param>
        /// <param name="type"></param>
        public Stock(string name, string symbol, string SMA200, string SMA50, string SMA20, string chartPattern, string unexpectedItems, int finvizRank, double individualRating, char type)
        {
            setName(name);
            setSymbol(symbol);
            setSMA200(SMA200);
            setSMA50(SMA50);
            setSMA20(SMA20);
            setChartPattern(chartPattern);
            setUnexpectedItems(unexpectedItems);
            setType(type);
            setFinvizRank(finvizRank);
            setIndividualRating(individualRating);
            notes = new List<Note>();
        }//end Nine argument constructor

        /// <summary>
        /// Ten argument constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="SMA200"></param>
        /// <param name="SMA50"></param>
        /// <param name="SMA20"></param>
        /// <param name="chartPattern"></param>
        /// <param name="unexpectedItems"></param>
        /// <param name="finvizRank"></param>
        /// <param name="individualRating"></param>
        /// <param name="notes"></param>
        public Stock(string name, string symbol, string SMA200, string SMA50, string SMA20, string chartPattern, string unexpectedItems, int finvizRank, double individualRating, List<Note> notes)
        {
            setName(name);
            setSymbol(symbol);
            setSMA200(SMA200);
            setSMA50(SMA50);
            setSMA20(SMA20);
            setChartPattern(chartPattern);
            setUnexpectedItems(unexpectedItems);
            setType(type);
            setFinvizRank(finvizRank);
            setIndividualRating(individualRating);
            setNotes(notes);
        }//end Ten argument constructor

        //Get methods
        public string getName() { return name; }
        public string getSymbol() { return symbol; }
        public string getSMA200() { return SMA200; }
        public string getSMA50() { return SMA50; }
        public string getSMA20() { return SMA20; }
        public string getChartPattern() { return chartPattern; }
        public string getUnexpectedItems() { return unexpectedItems; }
        public int getFinvizRank() { return finvizRank; }
        public double getIndividualRating() { return individualRating; }
        public bool getUsedInCalculation() { return usedInCalculation; }
        public char getType() { return type; }
        public List<Note> getNotes() { return notes; }

        //Set methods
        public void setName(string name) { this.name = name; }
        public void setSymbol(string symbol) { this.symbol = symbol; }
        public void setSMA200(string SMA200)
        {
            if(SMA200 == "Up" || SMA200 == "Up and Down" || SMA200 == "Down")
            {
                this.SMA200 = SMA200;
            } else
            {
                this.SMA200 = "Down";
            }
        }//end setSMA200
        public void setSMA50(string SMA50)
        {
            if(SMA50 == "Above" || SMA50 == "At" || SMA50 == "Below")
            {
                this.SMA50 = SMA50;
            } else
            {
                this.SMA50 = "Below";
            }
        }//end setSMA50
        public void setSMA20(string SMA20)
        {
            if (SMA20 == "Above" || SMA20 == "At" || SMA20 == "Below")
            {
                this.SMA20 = SMA20;
            }
            else
            {
                this.SMA20 = "Below";
            }
        }//end setSMA20
        public void setChartPattern(string chartPattern)
        {
            if(chartPattern == "Bull Run" || chartPattern == "Bull Consolidation" || chartPattern == "Consolidation"  || chartPattern == "Bear Run" || chartPattern == "Bear Consolidation") {
                this.chartPattern = chartPattern;
            } else
            {
                this.chartPattern = "Bear Consolidation";
            }
        }//end setChartPattern
        public void setUnexpectedItems(string unexpectedItems)
        {
            if(unexpectedItems == "Good" || unexpectedItems == "Average" || unexpectedItems == "Bad" || unexpectedItems == "Very Bad" || unexpectedItems == "No News")
            {
                this.unexpectedItems = unexpectedItems;
            } else
            {
                this.unexpectedItems = "No News";
            }
        }//end setUnexpectedItems
        public void setFinvizRank(int finvizRank)
        {
            this.finvizRank = (12 >= finvizRank && finvizRank >= 1 && type == 'S' ? finvizRank : -1);
        }//end setFinvizRank
        protected void setIndividualRating(double individualRating)
        {
            if(individualRating > 0)
            {
                this.individualRating = individualRating;
            } else
            {
                calculateIndividualRating();
            }
        }//end setIndividualRating
        public void setUsedInCalculation(bool usedInCalculation) { this.usedInCalculation = usedInCalculation; }
        
        //Only sets the type attribute if it is one of three characters
        public void setType(char type)
        {
            if(type == 'M' || type == 'S' || type == 'C')
            {
                this.type = type;
            }//end if
        }//end setType

        public void setNotes(List<Note> notes) { this.notes = notes; }
        public void addNote(Note note)
        {
            notes.Add(note);
            notes.Sort((a, b) => a.getDateTime().CompareTo(b.getDateTime()));
        }
        public void deleteNote(int i) { notes.RemoveAt(i); }

        /// <summary>
        /// Calculates the individual rating of the stock.  Adjusts which items are used in the calculation
        /// and what to divide by at the end.  Calls setIndividualRating to set the rating for the Stock
        /// </summary>
        public void calculateIndividualRating()
        {
            Preferences pref = new Preferences();
            int[] divideBy = { (type == 'M' ? 3 : 4), (type == 'M' ? 2 : 3) };

            double rating = (pref.getScore("SMA200", SMA200) + pref.getScore("SMA50/20", SMA50) + pref.getScore("SMA50/20", SMA20)) / 3;
            rating += pref.getScore("CHART_PATTERN", chartPattern) + pref.getScore("UNEXPECTED_ITEMS", unexpectedItems);
            rating += (finvizRank > -1 ? (11 - finvizRank) : 0);

            if(pref.getScore("UNEXPECTED_ITEMS", unexpectedItems) > 0)
            {
                rating /= divideBy[0];
            } else
            {
                rating /= divideBy[1];
            }//end if-else

            setIndividualRating(Math.Round(rating, 1));
        }//end calculateIndividualRating
    }//end Stock
}
