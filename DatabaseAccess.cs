using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TopDownAnalysis
{
    class DatabaseAccess
    {
        private string comm;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;

        /// <summary>
        /// Gets the connection string for dbTopDownAnalysis and returns it to the calling program
        /// </summary>
        /// <returns></returns>
        private string getConnectionString() { return Properties.Settings.Default.dbTopDownAnalysisConnectionString; }

        /// <summary>
        /// Selects all the information in STOCKS and returns it to the calling program as a DataTable
        /// </summary>
        /// <returns></returns>
        public DataTable selectAllFromStocks()
        {
            dt = new DataTable();

            conn = new SqlConnection(getConnectionString());
            comm = "SELECT * FROM STOCKS";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            return dt;
        }//end selectAllFromStocks

        /// <summary>
        /// Selects all the information in the NOTES table and returns a DataTable to the calling function
        /// </summary>
        /// <returns></returns>
        public DataTable selectAllFromNotes()
        {
            dt = new DataTable();

            conn = new SqlConnection(getConnectionString());
            comm = "SELECT * FROM NOTES";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            return dt;
        }//end selectAllFromNotes


        public void insertIntoStocks(Stock stock)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "INSERT INTO STOCKS (NAME, SYMBOL, SMA200, SMA50, SMA20, CHART_PATTERN, UNEXPECTED_ITEMS, FINVIZ_RANK, INDIVIDUAL_RATING, TYPE) VALUES (@name, @symbol,@sma200,@sma50,@sma20,@chartPattern,@unexpectedItems,@finvizRank,@individualRating,@type)";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@name", stock.getName());
            cmd.Parameters.AddWithValue("@symbol", stock.getSymbol());
            cmd.Parameters.AddWithValue("@sma200", stock.getSMA200());
            cmd.Parameters.AddWithValue("@sma50", stock.getSMA50());
            cmd.Parameters.AddWithValue("@sma20", stock.getSMA20());
            cmd.Parameters.AddWithValue("@chartPattern", stock.getChartPattern());
            cmd.Parameters.AddWithValue("@unexpectedItems", stock.getUnexpectedItems());
            cmd.Parameters.AddWithValue("@finvizRank", stock.getFinvizRank());
            cmd.Parameters.AddWithValue("@individualRating", stock.getIndividualRating());
            cmd.Parameters.AddWithValue("@type", stock.getType());
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end insertIntoStocks

        /// <summary>
        /// Inserts a new row into the NOTES table using the member functions for each note
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="lines"></param>
        public void insertIntoNotes(string symbol, string date, string time, string[] lines)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "INSERT INTO NOTES (SYMBOL, DATE, TIME, NOTE) VALUES (@symbol, @date, @time, @lines)";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@symbol", symbol);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@time", time);
            cmd.Parameters.AddWithValue("@lines", String.Join("#", lines));
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end insertIntoNotes(string, string, string, string[])

        public void insertIntoNotes(string symbol, List<Note> notes)
        {
            foreach(Note n in notes)
            {
                insertIntoNotes(symbol, n.getDateString(), n.getTimeString(), n.getLines());
            }//end foreach
        }//end insertIntoNotes(List<Note>)
        public void updateStocks(string symbol, Stock stock)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "UPDATE STOCKS SET NAME=@name, SMA200=@sma200, SMA50=@sma50, SMA20=@sma20, CHART_PATTERN=@chartPattern, UNEXPECTED_ITEMS=@unexpectedItems, FINVIZ_RANK=@finvizRank, INDIVIDUAL_RATING=@individualRating WHERE SYMBOL=@symbol";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@name", stock.getName());
            cmd.Parameters.AddWithValue("@sma200", stock.getSMA200());
            cmd.Parameters.AddWithValue("@sma50", stock.getSMA50());
            cmd.Parameters.AddWithValue("@sma20", stock.getSMA20());
            cmd.Parameters.AddWithValue("@chartPattern", stock.getChartPattern());
            cmd.Parameters.AddWithValue("@unexpectedItems", stock.getUnexpectedItems());
            cmd.Parameters.AddWithValue("@finvizRank", stock.getFinvizRank());
            cmd.Parameters.AddWithValue("@individualRating", stock.getIndividualRating());
            cmd.Parameters.AddWithValue("@symbol", stock.getSymbol());
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end updateStocks

        /// <summary>
        /// Updates the specific row in the NOTES table with the specific ID.
        /// </summary>
        /// <param name="note"></param>
        public void updateNotes(Note note)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "UPDATE NOTES SET DATE=@date, TIME=@time, NOTE=@note WHERE ID=@id";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@date", note.getDateString());
            cmd.Parameters.AddWithValue("@time", note.getTimeString());
            cmd.Parameters.AddWithValue("@note", String.Join("#", note.getLines()));
            cmd.Parameters.AddWithValue("@id", note.getId());
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end updateNotes

        public void deleteNote(string symbol, int id)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "DELETE FROM NOTES WHERE ID=@id AND SYMBOL=@symbol";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@symbol", symbol);
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end deleteNote
        public void deleteStock(string symbol)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "DELETE FROM STOCKS WHERE SYMBOL=@symbol";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@symbol", symbol);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM NOTES WHERE SYMBOL=@symbol";
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end deleteStock

        public DataTable selectAllFromOutlook()
        {
            dt = new DataTable();

            conn = new SqlConnection(getConnectionString());
            comm = "SELECT * FROM OUTLOOK ORDER BY ID DESC";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();

            return dt;
        }//end selectAllFromOutlook
        public void insertIntoOutlook(string date, string outlook)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "INSERT INTO OUTLOOK (ESTIMATED_DATE, ESTIMATED_OUTLOOK) VALUES (@date, @outlook)";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@outlook", outlook);
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end insertIntoOutlook

        public void updateOutlook(string date, string outlook)
        {
            dt = new DataTable();
            conn = new SqlConnection(getConnectionString());
            comm = "SELECT ID FROM OUTLOOK WHERE ESTIMATED_DATE=@date AND ACTUAL_DATE IS NULL AND PERFORMANCE IS NULL";
            conn.Open(); cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@date", date);
            var id = cmd.ExecuteScalar();
            if(id != null)
            {
                comm = "UPDATE OUTLOOK SET ESTIMATED_OUTLOOK=@outlook WHERE ID=@id";
                cmd = new SqlCommand(comm, conn);
                cmd.Parameters.AddWithValue("@outlook", outlook);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }//end updateOutlook
        public void updateOutlookActualPerformance(string estDate, string date, string outlook)
        {
            conn = new SqlConnection(getConnectionString());
            comm = "UPDATE OUTLOOK SET ACTUAL_DATE=@date, PERFORMANCE=@outlook WHERE ESTIMATED_DATE = @estDate";
            conn.Open();
            cmd = new SqlCommand(comm, conn);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@estDate", estDate);
            cmd.Parameters.AddWithValue("@outlook", outlook);
            cmd.ExecuteNonQuery();
            conn.Close();
        }//end updateOutlookActualPerformance
    }//end DatabaseAccess
}//end TopDownAnalysis
