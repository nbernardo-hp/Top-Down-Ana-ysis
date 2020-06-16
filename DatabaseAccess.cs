using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace StockTopDownAnalysis
{
    class DatabaseAccess
    {
        private SqlConnection conn;
        private string comm;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;

        private string getConnectionString() { return Properties.Settings.Default.dbTopDownAnalysisConnectionString; }

        /// <summary>
        /// Select every entry in the database that has the provided type.  If the char is not for the market
        /// add an additional column to the select command.Return the datatable to the calling program
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable selectAll(char type)
        {
            dt = new DataTable();
            conn = new SqlConnection(getConnectionString());

            comm = "SELECT NAME, SYMBOL, SMA200, SMA50, SMA20, CHART_PATTERN, UNEXPECTED_ITEMS, INDIVIDUAL_RATING, ";
            if(type != 'M')
            {
                comm += "FINVIZ_RANK, ";
            }
            comm += "NOTES FROM STOCKS WHERE TYPE=@type";

            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@type", type);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            return dt;
        }//end selectAll

        /// <summary>
        /// Inserts a new entry into the STOCKS table
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="finviz"></param>
        public void insertInto(Globals stock, int finviz = -1)
        {
            conn = new SqlConnection(getConnectionString());

            comm = "INSERT INTO STOCKS (NAME, SYMBOL, SMA200, SMA50, SMA20, CHART_PATTERN, " +
                "UNEXPECTED_ITEMS, INDIVIDUAL_RATING, FINVIZ_RANK, TYPE) VALUES (@name, " +
                "@symbol, @sma200, @sma50, @sma20, @chartPattern, " +
                "@unexpectedItems, @individualRating, @finvizRank, " +
                "@type);";

            conn.Open();

            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@name", stock.getName());
            cmd.Parameters.AddWithValue("@symbol", stock.getSymbol());
            cmd.Parameters.AddWithValue("@sma200", stock.getSMA200());
            cmd.Parameters.AddWithValue("@sma50", stock.getSMA50());
            cmd.Parameters.AddWithValue("@sma20", stock.getSMA20());
            cmd.Parameters.AddWithValue("@chartPattern", stock.getChartPattern());
            cmd.Parameters.AddWithValue("@unexpectedItems", stock.getUnexpectedItems());
            cmd.Parameters.AddWithValue("@individualRating", stock.getIndividualRating());
            cmd.Parameters.AddWithValue("@finvizRank", finviz);

            if (finviz != -1)
            {
                cmd.Parameters.AddWithValue("@type", 'S');
            } else
            {
                cmd.Parameters.AddWithValue("@type", 'M');
            }

            cmd.ExecuteNonQuery();

            conn.Close();
        }//end insertInto(char)

        /// <summary>
        /// Updates the specific row in the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="finviz"></param>
        public void updateRow(Globals stock, int finviz = -1)
        {
            conn = new SqlConnection(getConnectionString());

            comm = "UPDATE STOCKS SET SMA200=@sma200, SMA50=@sma50, SMA20=@sma20, CHART_PATTERN=@chartPattern, " +
                "UNEXPECTED_ITEMS=@unexpectedItems, INDIVIDUAL_RATING=@individualRating, FINVIZ_RANK=@finvizRank " +
                "WHERE SYMBOL = @symbol";

            conn.Open();

            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@symbol", stock.getSymbol());
            cmd.Parameters.AddWithValue("@sma200", stock.getSMA200());
            cmd.Parameters.AddWithValue("@sma50", stock.getSMA50());
            cmd.Parameters.AddWithValue("@sma20", stock.getSMA20());
            cmd.Parameters.AddWithValue("@chartPattern", stock.getChartPattern());
            cmd.Parameters.AddWithValue("@unexpectedItems", stock.getUnexpectedItems());
            cmd.Parameters.AddWithValue("@individualRating", stock.getIndividualRating());
            cmd.Parameters.AddWithValue("@finvizRank", finviz);

            cmd.ExecuteNonQuery();

            conn.Close();
        }//end updateRow

        /// <summary>
        /// Deletes the row with the specified symbol from the Database
        /// </summary>
        /// <param name="symbol"></param>
        public void deleteRow(string symbol)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "DELETE FROM STOCKS WHERE SYMBOL=@symbol";

            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@symbol", symbol);
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end deleteRow

        /// <summary>
        /// Selects the specified columns from the specified table.  Uses the key from the dictionary
        /// to determine which items the user still has active in the program.
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="table"></param>
        public DataRow selectFrom(List<string> cols, string symbol)
        {
            DataSet temp = new DataSet();
            conn = new SqlConnection(getConnectionString());
            comm = "SELECT ";
            for(int i = 0; i < cols.Count; i++)
            {
                comm += cols[i];
                if(i < cols.Count - 1)
                {
                    comm += ", ";
                }
            }//end for
            comm += " FROM STOCKS WHERE SYMBOL=@symbol";

            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@symbol", symbol);
            da = new SqlDataAdapter(cmd);
            da.Fill(temp);
            conn.Close();

            return (temp.Tables.Count > 0 ? temp.Tables[0].Rows[0] : null);
        }//end selectFrom
    }//end DatabaseAccess
}
