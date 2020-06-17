using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace StockTopDownAnalysis
{
    class XmlData
    {
        private XmlDocument doc;
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
        public void createBackupXml(Dictionary<string, Market> markets, Dictionary<string, Sector> sectors)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            filePath = AppDomain.CurrentDomain.BaseDirectory + @"\backup\save\";
            createPath(filePath);
            fileName = String.Format("backup({0}-{1}-{2}).xml", DateTime.Today.Month, DateTime.Today.Day, DateTime.Today.Year);

            using(writer = XmlWriter.Create(Path.Combine(filePath,fileName)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("STOCKS");

                foreach(var kvp in markets)
                {
                    writer.WriteStartElement("MARKET");
                    writer.WriteAttributeString("NAME", kvp.Value.getName());
                    writer.WriteAttributeString("SYMBOL", kvp.Value.getSymbol());
                    writer.WriteAttributeString("SMA200", kvp.Value.getSMA200());
                    writer.WriteAttributeString("SMA50", kvp.Value.getSMA50());
                    writer.WriteAttributeString("SMA20", kvp.Value.getSMA20());
                    writer.WriteAttributeString("CHART_PATTERN", kvp.Value.getChartPattern());
                    writer.WriteAttributeString("UNEXPECTED_ITEMS", kvp.Value.getUnexpectedItems());
                    writer.WriteAttributeString("FINVIZ_RANK", null);
                    writer.WriteAttributeString("INDIVIDUAL_RATING", kvp.Value.getIndividualRating().ToString());
                    writer.WriteEndElement();
                }

                foreach(var kvp in sectors)
                {
                    writer.WriteStartElement("SECTOR");
                    writer.WriteAttributeString("NAME", kvp.Value.getName());
                    writer.WriteAttributeString("SYMBOL", kvp.Value.getSymbol());
                    writer.WriteAttributeString("SMA200", kvp.Value.getSMA200());
                    writer.WriteAttributeString("SMA50", kvp.Value.getSMA50());
                    writer.WriteAttributeString("SMA20", kvp.Value.getSMA20());
                    writer.WriteAttributeString("CHART_PATTERN", kvp.Value.getChartPattern());
                    writer.WriteAttributeString("UNEXPECTED_ITEMS", kvp.Value.getUnexpectedItems());
                    writer.WriteAttributeString("FINVIZ_RANK", kvp.Value.getFinvizRank().ToString());
                    writer.WriteAttributeString("INDIVIDUAL_RATING", kvp.Value.getIndividualRating().ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();

                writer.Close();
            }
        }//end createBackupXml

        /// <summary>
        /// Saves the calculation preferences to a .xml file.
        /// </summary>
        /// <param name="markets"></param>
        /// <param name="sectors"></param>
        public void saveCalculationPreferences(Dictionary<string, Market> markets, Dictionary<string, Sector> sectors)
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + @"\preferences\";
            createPath(filePath);

            fileName = "calcpreferences.xml";
            using (writer = XmlWriter.Create(filePath + fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("CalcPreferences");
                foreach (var kvp in markets)
                {
                    writer.WriteStartElement("Market");
                    writer.WriteElementString("Symbol", kvp.Value.getSymbol());
                    writer.WriteElementString("CalcPreference", kvp.Value.getUsedInCalculation().ToString());
                    writer.WriteEndElement();
                }//end foreach
                foreach (var kvp in sectors)
                {
                    writer.WriteStartElement("Market");
                    writer.WriteElementString("Symbol", kvp.Value.getSymbol());
                    writer.WriteElementString("CalcPreference", kvp.Value.getUsedInCalculation().ToString());
                    writer.WriteEndElement();
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
        public Dictionary<string, bool> loadCalcPreferences(string table)
        {
            Dictionary<string, bool> preferences = new Dictionary<string, bool>();

            fileName = "calcpreferences.xml";
            var doc = XDocument.Load(Path.Combine(filePath,fileName));

            //Query to get the symbol and calcpreference value from the .xml file
            var pref = from p in doc.Root.Descendants(table)
                          select p.Element("Symbol").Value + ":" + p.Element("CalcPreference").Value;

            //splits the string and adds the dictionary entry
            foreach(string cp in pref)
            {
                string[] sp = cp.Split(':');
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
        /// Saves the column preferences that the user creates when accessing Displayed Columns
        /// ToolStripMenu item under Settings->Market and Settings->Sectors.
        /// table: 0 = Market, 1 = Sectors
        /// </summary>
        /// <param name="cols"></param>
        public void saveColumnPreferences(List<string> cols, int table)
        {
            createPath(filePath);
            fileName = (table == 0 ? "marketCols.xml" : "sectorsCols.xml");

            int i = 0;
            using(writer = XmlWriter.Create(Path.Combine(filePath,fileName)))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ColumnPreferences");
                foreach (string c in cols)
                {
                    writer.WriteElementString("Col", c);
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }//end using
        }//end saveColumnPreferences

        public List<string> loadColumnPreferences(int table)
        {
            List<string> res = new List<string>();
            fileName = (table == 0 ? "marketCols.xml" : "sectorsCols.xml");

            doc = new XmlDocument();
            doc.Load(Path.Combine(filePath, fileName));

            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                res.Add(node.InnerText);
            }

            return res;
        }//end loadColumnPreferences
    }//end XmlData
}
