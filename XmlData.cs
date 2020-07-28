using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace TopDownAnalysis
{
    public class XmlData
    {
        private XmlWriter writer;
        private string filePath = AppDomain.CurrentDomain.BaseDirectory + @"\preferences\";
        private string fileName;

        /// <summary>
        /// Creates the directory path if it does not exits
        /// </summary>
        /// <param name="path"></param>
        private void createPath(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }//end createPath

        /// <summary>
        /// Creates an .xml backup file of the information contained in the program when saving
        /// the changes made to the program
        /// </summary>
        public void createBackupXml(Dictionary<string, Stock> stocks, string path = null)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\backup\" : path);
            createPath(filePath);
            fileName = (path == null ? String.Format("backup({0}-{1}-{2}).xml", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year) : "topdownanalysisstocks.xml");

            using(writer = XmlWriter.Create(Path.Combine(filePath,fileName)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("STOCKS");

                foreach (var kvp in stocks)
                {
                    writer.WriteStartElement("STOCK");
                    writer.WriteAttributeString("NAME", kvp.Value.getName());
                    writer.WriteAttributeString("SYMBOL", kvp.Value.getSymbol());
                    writer.WriteAttributeString("SMA200", kvp.Value.getSMA200());
                    writer.WriteAttributeString("SMA50", kvp.Value.getSMA50());
                    writer.WriteAttributeString("SMA20", kvp.Value.getSMA20());
                    writer.WriteAttributeString("CHART_PATTERN", kvp.Value.getChartPattern());
                    writer.WriteAttributeString("UNEXPECTED_ITEMS", kvp.Value.getUnexpectedItems());
                    writer.WriteAttributeString("FINVIZ_RANK", kvp.Value.getFinvizRank().ToString());
                    writer.WriteAttributeString("INDIVIDUAL_RATING", kvp.Value.getIndividualRating().ToString());
                    writer.WriteAttributeString("TYPE", kvp.Value.getType().ToString());

                    writer.WriteStartElement("NOTES");
                        if(kvp.Value.getNotes() == null || kvp.Value.getNotes().Count() < 1)
                        {
                            writer.WriteAttributeString("NULL",null);
                        } else
                        {
                            backupNotesXml(kvp.Value.getNotes());
                        }
                    writer.WriteEndElement();
                    writer.WriteEndElement();
                }
             writer.WriteEndElement();
             writer.WriteEndDocument();

             writer.Close();
            }//end using directive
        }//end createBackupXml

        /// <summary>
        /// Function to create the Xml notes for each Market or Sector
        /// </summary>
        /// <param name="notes"></param>
        private void backupNotesXml(List<Note> notes)
        {
            foreach (Note note in notes)
            {
                writer.WriteStartElement("NOTE");
                    writer.WriteAttributeString("ID", note.getId().ToString());
                    writer.WriteAttributeString("DATE", note.getDateString());
                    writer.WriteAttributeString("TIME", note.getTimeString());

                    string[] temp = note.getLines();
                    string line = String.Join("#", temp);
                    
                    writer.WriteAttributeString("LINE", line);
                writer.WriteEndElement();
            }
        }//end backupNoteXml

        public void backupOverallRating(DataTable dt, string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\backup\" : path);
            fileName = (path == null ? "overallrating.xml" : "topdownanalysisoverallrating.xml");
            createPath(filePath);
            using(writer = XmlWriter.Create(Path.Combine(filePath, fileName)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("OVERALL_RATING");
                foreach(DataRow r in dt.Rows)
                {
                    writer.WriteStartElement("OUTLOOK");
                    writer.WriteAttributeString("ESTIMATED_DATE", r["ESTIMATED_DATE"].ToString());
                    writer.WriteAttributeString("ESTIMATED_OUTLOOK", r["ESTIMATED_OUTLOOK"].ToString());
                    writer.WriteAttributeString("ACTUAL_DATE", r["ACTUAL_DATE"].ToString());
                    writer.WriteAttributeString("PERFORMANCE", r["PERFORMANCE"].ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
        }//end backupOverallRating

        /// <summary>
        /// Loads the data from a .xml file into a DataSet.  If the table argument is STOCK returns
        /// the STOCK table to the calling function.  If not, queries the DataSet to get the NOTE information
        /// and returns a new DataTable with the information.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public DataTable loadXml(string path, string table)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            if (table == "STOCK")
            {
                return ds.Tables["STOCK"];
            } else
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[] { new DataColumn("ID", typeof(Int32)), new DataColumn("SYMBOL"), new DataColumn("DATE"), new DataColumn("TIME"), new DataColumn("NOTE") });
                
                var query = from n in ds.Tables["NOTE"].AsEnumerable()
                            from s in ds.Tables["STOCK"].AsEnumerable()
                            from no in ds.Tables["NOTES"].AsEnumerable()
                            where n.Field<int>("NOTES_Id") == no.Field<int>("NOTES_Id") && no.Field<int>("STOCK_Id") == s.Field<int>("STOCK_Id")
                            select n.Field<string>("ID") + "@" + s.Field<string>("SYMBOL") + "@" + n.Field<string>("DATE") + "@" + n.Field<string>("TIME") + "@" + n.Field<string>("LINE");

                foreach(var q in query)
                {
                    string[] temp = q.Split('@');
                    dt.Rows.Add(new object[] { int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4] });
                }//end foreach

                return dt;
            }//end if-else
        }//end loadXML

        public DataTable loadOverallRating(string path)
        {
            fileName = (path.Contains("\\backup\\") ? "overallrating.xml" : "topdownanalysisoverallrating.xml");
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] { new DataColumn("ESTIMATED_DATE", typeof(string)), new DataColumn("ESTIMATED_OUTLOOK", typeof(string)), new DataColumn("ACTUAL_DATE", typeof(string)), new DataColumn("PERFORMANCE", typeof(string)) } );
            DataSet ds = new DataSet();
            ds.ReadXml(Path.Combine(path, fileName));

            var query = from d in ds.Tables["OUTLOOK"].AsEnumerable()
                        select d.Field<string>("ESTIMATED_DATE") + "@" + d.Field<string>("ESTIMATED_OUTLOOK") + "@" + d.Field<string>("ACTUAL_DATE") + "@" + d.Field<string>("PERFORMANCE");
            foreach(var que in query)
            {
                string[] q = que.Split('@');
                dt.Rows.Add(new object[] { q[0].Trim(), q[1], q[2].Trim(), q[3] });
            }
            return dt;
        }
        /// <summary>
        /// Saves the calculation preferences to a .xml file.
        /// </summary>
        /// <param name="markets"></param>
        /// <param name="sectors"></param>
        public void saveCalculationPreferences(Dictionary<char, Dictionary<string, bool>> map, string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\preferences\" : path);
            createPath(filePath);

            fileName = (path == null ? "calcpreferences.xml" : "topdownanalysiscalcpreferences.xml");
            using (writer = XmlWriter.Create(Path.Combine(filePath, fileName)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CALC_PREFERENCES");
                foreach (var kvp in map)
                {
                    string type = (kvp.Key == 'M' ? "M" : "S");
                    foreach(var k in kvp.Value)
                    {
                        writer.WriteStartElement("STOCK");
                        writer.WriteAttributeString("SYMBOL", k.Key);
                        writer.WriteAttributeString("PREFERENCE", k.Value.ToString());
                        writer.WriteAttributeString("TYPE", type);
                        writer.WriteEndElement();
                    }
                }//end foreach
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
            
            writer.Close();
        }//end saveCalculationPreferences

        /// <summary>
        /// Loads the preferences for each the calcualtion for the individual DataGridViews.
        /// Returns a dictionary using the symbol and bool value to set the attribute in the
        /// calling program.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Dictionary<string, bool> loadCalcPreferences(char type, string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\preferences\" : path);
            Dictionary<string, bool> preferences = new Dictionary<string, bool>();

            fileName = (path == null ? "calcpreferences.xml" : "topdownanalysiscalcpreferences.xml");
            var doc = XDocument.Load(Path.Combine(filePath,fileName));

            //Query to get the symbol and calcpreference value from the .xml file
            var pref = from p in doc.Root.Descendants("STOCK")
                       where p.Attribute("TYPE").Value == type.ToString()
                       select p.Attribute("SYMBOL").Value + "#" + p.Attribute("PREFERENCE").Value;

            //splits the string and adds the dictionary entry
            foreach(string cp in pref)
            {
                string[] sp = cp.Split('#');
                if(!preferences.ContainsKey(sp[0]))
                {
                    preferences.Add(sp[0], (sp[1] == "True" ? true : false));
                } else
                {
                    preferences[sp[0]] = (sp[1] == "True" ? true : false);
                }
            }//end foreach
            return preferences;
        }//end loadCalcPreferences

        /// <summary>
        /// Saves the column preferences that the user creates when accessing Column Display
        /// ToolStripMenu item under Settings->Market and Settings->Sectors.
        /// </summary>
        /// <param name="cols"></param>
        public void saveColumnPreferences(Dictionary<char, Dictionary<string, bool>> map, string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\preferences\" : path);
            createPath(filePath);
            fileName = (path == null ? "columnPreferences.xml" : "topdownanalysiscolumnPreferences.xml");

            using (writer = XmlWriter.Create(Path.Combine(filePath,fileName)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("COLUMN_PREFERENCES");
                foreach (var kvp in map)
                {
                    string type = (kvp.Key == 'M' ? "M" : "S");
                    foreach(var col in kvp.Value)
                    {
                        string pref = (col.Value ? "True" : "False");
                        writer.WriteStartElement("COLUMN");
                            writer.WriteAttributeString("NAME", col.Key);
                            writer.WriteAttributeString("PREFERENCE", pref);
                            writer.WriteAttributeString("TYPE", type);
                        writer.WriteEndElement();
                    }
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
        }//end saveColumnPreferences

        /// <summary>
        /// Loads the column preferences saved in the .xml file associated with the provided
        /// DataGridView indicator. 'M' = Markets, 'S' = Sectors
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Dictionary<string, bool> loadColumnPreferences(char type, string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\preferences\" : path);
            Dictionary<string, bool> res = new Dictionary<string, bool>();
            fileName = (path == null ?  "columnpreferences.xml" : "topdownanalysiscolumnpreferences.xml");

            var doc = XDocument.Load(Path.Combine(filePath, fileName));

            var query = from d in doc.Root.Descendants("COLUMN")
                        where d.Attribute("TYPE").Value == type.ToString()
                        select d.Attribute("NAME").Value + "@" + d.Attribute("PREFERENCE").Value;

            foreach(string q in query)
            {
                string[] sq = q.Split('@');
                if(!res.ContainsKey(sq[0]))
                {
                    res.Add(sq[0], (sq[1] == "True" ? true : false));
                }//end if
            }//end foreach

            return res;
        }//end loadColumnPreferences
        public void savePromptPreferences(DateTime previous, DateTime next, int days, string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\preferences\" : path);
            createPath(filePath);
            fileName = (path == null ? "promptpreferences.xml" : "topdownanalysispromptpreferences.xml");

            using (writer = XmlWriter.Create(Path.Combine(filePath, fileName)))
            {
                writer.WriteStartDocument();
                    writer.WriteStartElement("PROMPT_PREFERENCES");
                        writer.WriteAttributeString("PREVIOUS", previous.ToShortDateString());
                        writer.WriteAttributeString("NEXT", next.ToShortDateString());
                        writer.WriteAttributeString("DAYS", days.ToString());
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
        }//end savePromptPreferences
        public string[] loadPromptPreferences(string path = null)
        {
            filePath = (path == null ? AppDomain.CurrentDomain.BaseDirectory + @"\preferences\" : path);
            fileName = (path == null ? "promptpreferences.xml" : "topdownanalysispromptpreferences.xml");

            var doc = XDocument.Load(Path.Combine(filePath, fileName));
            string p = doc.Element("PROMPT_PREFERENCES").Attribute("PREVIOUS").Value + "@" +
                doc.Element("PROMPT_PREFERENCES").Attribute("NEXT").Value + "@" +
                doc.Element("PROMPT_PREFERENCES").Attribute("DAYS").Value;

            return p.Split('@');
        }
    }//end XmlData
}
