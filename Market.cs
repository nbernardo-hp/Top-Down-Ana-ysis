using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTopDownAnalysis
{
    public class Market : Globals
    {

        /// <summary>
        /// No argument constructor.  Defaults every string to "" and double to 0.0.  Does nothing with the list
        /// </summary>
        public Market() : base() {}

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
        public Market(string name, string symbol, string SMA200, string SMA50, string SMA20, string chartPattern, string unexpectedItems, double individualRating)
            : base(name, symbol, SMA200, SMA50, SMA20, chartPattern, unexpectedItems, individualRating)
        {}

        /// <summary>
        /// Calculates the individual ranking for the market and sends the value to Globals .setIndividualRating
        /// </summary>
        public void calculateIndividualRating()
        {
            double rating = 0;

            rating = base.getScore(base.getSMA200()) + base.getScore(base.getSMA50()) + base.getScore(base.getSMA20());
            rating /= 3;
            rating += base.getScore(base.getChartPattern()) + base.getScore(base.getUnexpectedItems());

            if (base.getScore(base.getUnexpectedItems()) > 0)
            {
                rating /= 3;
            } else
            {
                rating /= 2;
            }

            base.setIndividualRating(Math.Round(rating, 1));
        }//end calculateIndividualRating
    }//end class Market
}
