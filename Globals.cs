using System;
using System.Collections.Generic;

namespace StockTopDownAnalysis
{
    public class Globals
    {
        private string name;
        private string symbol;
        private string SMA200;
        private string SMA50;
        private string SMA20;
        private string chartPattern;
        private string unexpectedItems;
        private double individualRating;
        bool usedInCalculation;
        private Dictionary<string, double> map = new Dictionary<string, double>()
        {
            ["Up"] = 10,
            ["Up and Down"] = 5,
            ["Down"] = 0,
            ["Above"] = 10,
            ["At"] = 5,
            ["Below"] = 0,
            ["Bull Run"] = 10,
            ["Bull Consolidation"] = 7.5,
            ["Consolidation"] = 5,
            ["Bear Consolidation"] = 2.5,
            ["Bear Run"] = 0,
            ["Very Good"] = 10,
            ["Good"] = 7.5,
            ["Average"] = 5.5,
            ["Bad"] = 3.5,
            ["Very Bad"] = 1,
            ["No News"] = 5.5
        };


        /// <summary>
        /// No argument constructor.  Defaults strings to "" and double to 0.0.  Does nothing with the list
        /// </summary>
        public Globals()
        {
            name = "";
            symbol = "";
            SMA200 = "";
            SMA50 = "";
            SMA20 = "";
            chartPattern = "";
            unexpectedItems = "";
            individualRating = 0.0;
        }

        /// <summary>
        /// Eight argument constructor.  Sets the strings and double to the provided input.  Does nothing with the list
        /// </summary>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="SMA200"></param>
        /// <param name="SMA50"></param>
        /// <param name="SMA20"></param>
        /// <param name="chartPattern"></param>
        /// <param name="unexpectedItems"></param>
        /// <param name="individualRating"></param>
        public Globals(string name, string symbol, string SMA200, string SMA50, string SMA20, string chartPattern, string unexpectedItems, double individualRating)
        {
            this.name = name;
            this.symbol = symbol;
            this.SMA200 = SMA200;
            this.SMA50 = SMA50;
            this.SMA20 = SMA20;
            this.chartPattern = chartPattern;
            this.unexpectedItems = unexpectedItems;
            this.individualRating = individualRating;
        }

        //Get methods
        public string getName() { return name; }
        public string getSymbol() { return symbol; }
        public string getSMA200() { return SMA200; }
        public string getSMA50() { return SMA50; }
        public string getSMA20() { return SMA20; }
        public string getChartPattern() { return chartPattern; }
        public string getUnexpectedItems() { return unexpectedItems; }
        public double getIndividualRating() { return individualRating; }
        public double getScore(string key)
        {
            double score = 0;

            try
            {
                map.TryGetValue(key, out score);
            } catch
            {

            }

            return score;
        }
        public bool getUsedInCalculation() { return usedInCalculation; }

        //Set methods
        public void setName(string name) { this.name = name; }
        public void setSymbol(string symbol) { this.symbol = symbol; }
        public void setSMA200(string SMA200) { this.SMA200 = SMA200; }
        public void setSMA50(string SMA50) { this.SMA50 = SMA50; }
        public void setSMA20(string SMA20) { this.SMA20 = SMA20; }
        public void setChartPattern(string chartPattern) { this.chartPattern = chartPattern; }
        public void setUnexpectedItems(string unexpectedItems) { this.unexpectedItems = unexpectedItems; }
        protected void setIndividualRating(double individualRating) { this.individualRating = individualRating; }
        public void setUsedInCalculation(bool usedInCalculation) { this.usedInCalculation = usedInCalculation; }

    }//end Globals
}
