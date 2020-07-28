using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TopDownAnalysis
{
    public partial class frmTopDownAnalysis : Form
    {
        Preferences preferences = new Preferences();
        Dictionary<string, Stock> map = new Dictionary<string, Stock>();
        double[] overallRating = new double[2];
        //1 = new, 2 = edited, 3 = deleted
        Dictionary<string, int> changes = new Dictionary<string, int>();
        List<string> deletedNotes = new List<string>();
        bool changesSaved = true;
        public frmTopDownAnalysis()
        {
            InitializeComponent();
            try
            {
                preferences.loadPreferences();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end default constructor

        private void frmTopDownAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseAccess dbAccess = new DatabaseAccess();
                try
                {
                    if (preferences.getReinstalled())
                    {
                        string path = String.Format("C:\\Users\\{0}\\.topdownanalysis\\", Environment.UserName);
                        loadStockXmlData(Path.Combine(path, "topdownanalysisstocks.xml"));
                        loadOverallXmlData(path);

                        foreach (var kvp in map)
                        {
                            dbAccess.insertIntoStocks(kvp.Value);
                            dbAccess.insertIntoNotes(kvp.Key, kvp.Value.getNotes());
                        }

                        saveCalculationPreferences();
                        saveColumnPreferences();
                        savePromptPreferences();
                    } else
                    {
                        populateDictionary(dbAccess.selectAllFromStocks());
                        addNotesToDictionaryEntries(dbAccess.selectAllFromNotes());
                    }
                } catch (TimeoutException ex)
                {
                    MessageBox.Show(ex.Message + "  Application will restart.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                } catch(Exception ex)
                {
                    if(ex.Message.Length > 0)
                    {
                        errorMessage(ex);
                    } else
                    {
                        MessageBox.Show("Unable to access the database.  Please select a .xml file to load the information", "Unable to access", MessageBoxButtons.OK);
                    }//end if-else

                    loadStockXmlData();
                }//end nested try-catch

                try
                {
                    string prefPath = AppDomain.CurrentDomain.BaseDirectory + @"\preferences\";
                    if (!Directory.Exists(prefPath))
                    {
                        Directory.CreateDirectory(prefPath);
                    }

                    File.Create(Path.Combine(prefPath, "load.tda"));
                } catch (Exception ex)
                {
                    errorMessage(ex);
                }

                checkCalcPreferences('M');
                checkCalcPreferences('S');

                createColumns();
                populateDataGridView(dgvMarkets, 'M');
                populateDataGridView(dgvSectors, 'S');
                dgvMarkets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (preferences.getPreviousPrompt() != new DateTime(1) && preferences.getNextPrompt().Year > 2019 && preferences.getNextPrompt() <= DateTime.Today)
                {
                    frmActualPerformance frm = new frmActualPerformance();
                    frm.ShowDialog();
                    dbAccess.updateOutlookActualPerformance(preferences.getPreviousPrompt().ToShortDateString(), preferences.getNextPrompt().ToShortDateString(), frm.getPerformance());
                    preferences.setPreviousPrompt(DateTime.Today);
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end frmTopDownAnalysis_Load

        private void loadOverallXmlData(string path)
        {
            try
            {
                XmlData xmlData = new XmlData();
                DataTable dt = xmlData.loadOverallRating(path);
                if(preferences.getReinstalled())
                {
                    DatabaseAccess dbAccess = new DatabaseAccess();
                    foreach(DataRow dr in dt.Rows)
                    {
                        dbAccess.insertIntoOutlook(dr["ESTIMATED_DATE"].ToString().Trim(), dr["ESTIMATED_OUTLOOK"].ToString().Trim());
                        if (dr["ACTUAL_DATE"].ToString().Trim() != "")
                        {
                            dbAccess.updateOutlookActualPerformance(dr["ESTIMATED_DATE"].ToString().Trim(), dr["ACTUAL_DATE"].ToString().Trim(), dr["PERFORMANCE"].ToString().Trim());
                        }//end if
                    }//end foreach
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end loadOverallXmlData

        private void checkCalcPreferences(char type)
        {
            var calcMap = preferences.getCalculationPreferences(type);
            if(calcMap.Count < 1 || calcMap == null)
            {
                foreach(var kvp in map)
                {
                    preferences.addStockToPreferences(type, kvp.Value);
                }//end foreach
                preferences.defaultCalculationToTrue(type);
            }//end if
        }//end checkCalcPreferences

        private void tsmMarketCalc_Click(object sender, EventArgs e)
        {
            try
            {
                frmCalculationPreferences frmCalc = new frmCalculationPreferences(map, 'M', preferences.getCalculationPreferences('M'));
                if (getDialogResult(frmCalc) == DialogResult.OK)
                {
                    setCalculationPreferences(frmCalc.getCalculationPreferences(), 'M');
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsmMarketCalc_Click

        private void tsmMarketCols_Click(object sender, EventArgs e)
        {
            try
            {
                frmColumnPreferences frm = new frmColumnPreferences();
                frm.setFormInformation("Market", preferences.getColumnDictionary('M'));
                if(getDialogResult(frm) == DialogResult.OK)
                {
                    setColumnPreferences(dgvMarkets, frm.getColumns(), 'M');
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsmMarketCols_Click
        private void tsmSectorCalc_Click(object sender, EventArgs e)
        {
            try
            {
                frmCalculationPreferences frmCalc = new frmCalculationPreferences(map, 'S', preferences.getCalculationPreferences('S'));
                if (getDialogResult(frmCalc) == DialogResult.OK)
                {
                    setCalculationPreferences(frmCalc.getCalculationPreferences(), 'S');
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsmSectorCalc_Click

        private void tsmSectorCols_Click(object sender, EventArgs e)
        {
            try
            {
                frmColumnPreferences frm = new frmColumnPreferences();
                frm.setFormInformation("Sector", preferences.getColumnDictionary('S'));
                if (getDialogResult(frm) == DialogResult.OK)
                {
                    setColumnPreferences(dgvSectors, frm.getColumns(), 'S');
                }//end if
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsmSectorCols_Click

        private void setCalculationPreferences(Dictionary<string, bool> calcMap, char type)
        {
            updateCalculationPreferences(calcMap, type);
            saveCalculationPreferences();
            calculateOverallRating(type);
        }//end setCalculationPreferences
        private void setColumnPreferences(DataGridView dgv, Dictionary<string, bool> cols, char type)
        {
            preferences.setPreference("COL", type, cols);
            createColumnsConfigured(dgv, preferences.getColumnPreferences(type));
            populateDataGridView(dgv, type);
            saveColumnPreferences();
        }//end setColumnPreferences
        private DialogResult getDialogResult(Form frm)
        {
            return frm.ShowDialog();
        }//end getDialogResult

        /// <summary>
        /// Updates the calculation preferences in the map Dictionary and the Preferences class preferenceMap attribute
        /// </summary>
        /// <param name="prefMap"></param>
        private void updateCalculationPreferences(Dictionary<string, bool> calcMap, char type)
        {
            try
            {
                preferences.setPreference("CALC", type, calcMap);
                foreach(var kvp in calcMap)
                {
                    map[kvp.Key].setUsedInCalculation(kvp.Value);
                }//end foreach
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end updateCalculationPreferences

        private void saveCalculationPreferences()
        {
            XmlData xml = new XmlData();
            xml.saveCalculationPreferences(preferences.getCalculationDictionary());
            xml.saveCalculationPreferences(preferences.getCalculationDictionary(), String.Format("C:\\Users\\{0}\\.topdownanalysis", Environment.UserName));
        }//end saveCalculationPreferences

        private void saveColumnPreferences()
        {
            XmlData xml = new XmlData();
            xml.saveColumnPreferences(preferences.getColumnDictionary());
            xml.saveColumnPreferences(preferences.getColumnDictionary(), String.Format("C:\\Users\\{0}\\.topdownanalysis", Environment.UserName));
        }//end saveColumnPreferences
        private void savePromptPreferences()
        {
            preferences.savePromptDates();
            preferences.savePromptDates(String.Format("C:\\Users\\{0}\\.topdownanalysis", Environment.UserName));
        }//end savePromptPreferences

        private List<string> getColumnList(DataGridView dgv)
        {
            List<string> res = new List<string>();
            foreach(DataGridViewColumn dgc in dgv.Columns)
            {
                res.Add(dgc.Name);
            }
            return res;
        }//end getColumnList

        /// <summary>
        /// Populates the Dictionary that contains all the Stock objects.  Uses the symbol attribute
        /// as the key.
        /// </summary>
        /// <param name="dt"></param>
        private void populateDictionary(DataTable dt)
        {
            try
            {
                string symbol = "";
                double rating = 0;
                int rank = 0;
                string type = "";

                foreach(DataRow dr in dt.Rows)
                {
                    symbol = dr.Field<string>("SYMBOL").Trim();
                    if (!map.ContainsKey(symbol))
                    {
                        if(dr["FINVIZ_RANK"].GetType() == typeof(string))
                        {
                            rank = int.Parse(dr.Field<string>("FINVIZ_RANK"));
                        } else
                        {
                            rank = dr.Field<int>("FINVIZ_RANK");
                        }//end if-else

                        if(dr["INDIVIDUAL_RATING"].GetType() == typeof(string))
                        {
                            double.TryParse(dr.Field<string>("INDIVIDUAL_RATING"), out rating);
                        } else
                        {
                            double.TryParse(dr.Field<decimal>("INDIVIDUAL_RATING").ToString().Trim(), out rating);
                        }
                        
                        type = dr.Field<string>("TYPE");
                        map.Add(symbol, new Stock(dr.Field<string>("NAME").TrimEnd(), symbol, dr.Field<string>("SMA200").TrimEnd(), dr.Field<string>("SMA50").TrimEnd(), dr.Field<string>("SMA20").TrimEnd(), dr.Field<string>("CHART_PATTERN").TrimEnd(), dr.Field<string>("UNEXPECTED_ITEMS").TrimEnd(), rank, rating, type[0]));
                    }//end if
                }//end foreach
                
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end populateDictionary


        private void addNotesToDictionaryEntries(DataTable dt)
        {
            string symbol = "";
            foreach(DataRow dr in dt.Rows)
            {
                symbol = dr.Field<string>("SYMBOL").Trim();
                if(map.ContainsKey(symbol))
                {
                    string[] n = dr.Field<string>("NOTE").Split('#');
                    map[symbol].addNote(new Note(dr.Field<int>("ID"), n, dr.Field<string>("DATE"), dr.Field<string>("TIME")));
                }//end if
            }//end foreach
        }//end addNotesToDictionaryEntries

        /// <summary>
        /// Calls a function depending on whether a column list has been provided or not for the creation
        /// of the columns for each DataGridView.
        /// </summary>
        private void createColumns()
        {
            if(preferences.getPreferenceLoaded("COL", 'M'))
            {
                createColumnsConfigured(dgvMarkets, preferences.getColumnPreferences('M'));
            } else
            {
                createColumnsDefault(dgvMarkets);
            }//end if-else

            if (preferences.getPreferenceLoaded("COL", 'S'))
            {
                createColumnsConfigured(dgvSectors, preferences.getColumnPreferences('S'));
            } else
            {
                createColumnsDefault(dgvSectors);
            }//end if-else
        }//end createColumns

        /// <summary>
        /// Creates the default columns for the specified DataGridView.  Called if the columns for either
        /// are not configured
        /// </summary>
        /// <param name="dgv"></param>
        private void createColumnsDefault(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("Name", "Name");
            dgv.Columns.Add("Symbol", "Symbol");
            dgv.Columns.Add("20 & 50 SMAs", "20 & 50 SMAs");
            dgv.Columns.Add("50 SMA", "50 SMA");
            dgv.Columns.Add("20 SMA", "20 SMA");
            dgv.Columns.Add("Chart Pattern", "Chart Pattern");
            dgv.Columns.Add("Market News", "Market News");
            if(dgv.Name == "dgvSectors")
            {
                dgv.Columns.Add("Finviz Rank", "Finviz Rank");
            }//end if
            dgv.Columns.Add("Rating", "Rating");

            createColumnToolTips(dgv);
        }//end createDefaultCoulmns

        /// <summary>
        /// Creates the columns when the user has configured the information to be displayed
        /// </summary>
        /// <param name="dgv"></param>
        private void createColumnsConfigured(DataGridView dgv, List<string> cols)
        {
            dgv.Columns.Clear();
            foreach (string c in cols)
            {
                dgv.Columns.Add(c, c);
            }//end foreach
            createColumnToolTips(dgv);
        }//end createConfiguredColumns

        /// <summary>
        /// Creates the ToolTips for specific columns
        /// </summary>
        /// <param name="dgv"></param>
        private void createColumnToolTips(DataGridView dgv)
        {
            if (dgv.Columns.Contains("50 SMA") && dgv.Columns["50 SMA"].ToolTipText == "")
            {
                dgv.Columns["50 SMA"].ToolTipText = "Is Stock Price:\n- Below 50 SMA\n- At the 50 SMA\n- Above 50 SMA (strong stock)";
            }
            if (dgv.Columns.Contains("Chart Pattern") && dgv.Columns["Chart Pattern"].ToolTipText == "")
            {
                dgv.Columns["Chart Pattern"].ToolTipText = "Look at the Weekly chart to determine what to place here.";

            }
            if (dgv.Columns.Contains("Market News") && dgv.Columns["Market News"].ToolTipText == "")
            {
                dgv.Columns["Market News"].ToolTipText = "If no news, enter \"No News\", not \"Average\".";
            }
        }//end createColumnToolTips

        /// <summary>
        /// Populates the provided DataGridView depending on which columns are present in it.
        /// Iterates through the map Dictionary to determine if the specific entry belongs in
        /// the DataGridView.  Populates the DataGridView with the Stock objects information if so
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="type"></param>
        private void populateDataGridView(DataGridView dgv, char type)
        {
            dgv.Rows.Clear();
            int ri = 0;

            var values = from m in map
                         where m.Value.getType() == type
                         select m.Value;

            foreach(var v in values)
            {
                
                if(dgv.Rows.Count < values.Count())
                {
                    dgv.Rows.Add();
                }

                populateDataGridViewRow(dgv, ri, v);

                ri++;
            }
            /*foreach(var kvp in map)
            {
                if(kvp.Value.getType() == type)
                {
                    
                }//end if
            }//end foreach*/

            calculateOverallRating(type);
        }//end populateDataGridView

        /// <summary>
        /// Opens a FileOpenDialog to have the user select a .xml file to load.
        /// </summary>
        private void loadStockXmlData(string path = null)
        {
            XmlData xml = new XmlData();
            if(path == null)
            {
                if(Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + @"backup\"))
                {
                    OpenFileDialog open = new OpenFileDialog();
                    open.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + @"backup\";
                    open.DefaultExt = "Xml|.xml";
                    DialogResult res = open.ShowDialog();
                    if (res == DialogResult.OK)
                    {
                        frmBackupView view = new frmBackupView(xml.loadXml(open.FileName, "STOCK"), open.FileName);
                        view.ShowDialog();
                        //populateDictionaryFromXml(xml, open.FileName);
                    }//end if
                } else
                {
                    MessageBox.Show("No backup directory exists.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }//end nested if-else
            } else
            {
                populateDictionaryFromXml(xml, path);
            }
        }//end loadXmlData

        private void populateDictionaryFromXml(XmlData xml, string path)
        {
            if (map.Count() > 0)
            {
                map.Clear();
            }
            DataTable dt = new DataTable();
            dt = xml.loadXml(path, "STOCK");
            populateDictionary(dt);
            dt = xml.loadXml(path, "NOTE");
            addNotesToDictionaryEntries(dt);
            if (dgvMarkets.Columns.Count == 0 && dgvSectors.Columns.Count == 0)
            {
                createColumns();
            }
            populateDataGridView(dgvMarkets, 'M');
            populateDataGridView(dgvSectors, 'S');
        }
        //end populateDictionaryFromXML
        /// <summary>
        /// Function to call to display the Exception error message
        /// </summary>
        /// <param name="ex"></param>
        public static void errorMessage(Exception ex)
        {
            MessageBox.Show("Error! " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }//end errorMessage()

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmStock frm = new frmStock();
                if (getDialogResult(frm) == DialogResult.OK)
                {
                    string symbol = frm.getStock().getSymbol();
                    if (!map.ContainsKey(symbol))
                    {
                        map.Add(symbol, frm.getStock());
                        adjustChangesDictionary(symbol, 1);
                        char type = map[symbol].getType();
                        preferences.addStockToPreferences(map[symbol].getType(), map[symbol]);
                        saveCalculationPreferences();
                        populateDataGridView((type == 'M' ? dgvMarkets : dgvSectors), type);
                        changesSaved = false;
                    }
                    else
                    {
                        MessageBox.Show("A stock with that symbol is already in the database.");
                    }//end nested if-else
                    
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsbAdd_Click

        private void adjustChangesDictionary(string symbol, int i)
        {
            if (!changes.ContainsKey(symbol))
            {
                changes.Add(symbol, i);
            }
            else
            {
                int val = 0;
                changes.TryGetValue(symbol, out val);

                if (val != 1)
                {
                    changes[symbol] = i;
                    if (i == 3)
                    {
                        preferences.deleteStockFromPreferences(map[symbol].getType(), symbol);
                    }//end nested if
                }
                else if (i == 3 && val == 1)
                {
                    char type = map[symbol].getType();

                    changes.Remove(symbol);
                    map.Remove(symbol);
                    preferences.deleteStockFromPreferences(type, symbol);
                }//end if-else if
            }
        }//end adjustChangesDictionary
        private void toggleButtons()
        {
            if((tabStocks.SelectedTab == tabMarkets && dgvMarkets.SelectedRows.Count > 0) || (tabStocks.SelectedTab == tabSectors && dgvSectors.SelectedRows.Count > 0))
            {
                tsbEdit.Enabled = true;
                tsbDelete.Enabled = true;
                tsbNotes.Enabled = true;
            } else
            {
                tsbEdit.Enabled = false;
                tsbDelete.Enabled = false;
                tsbNotes.Enabled = false;
            }
        }//end toggleButtons

        private void tabStocks_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleButtons();
            displayOverallRating((tabStocks.SelectedTab == tabMarkets ? 0 : 1));
        }//end tabStocks_SelectedIndexChanged

        private void dgvMarkets_SelectionChanged(object sender, EventArgs e)
        {
            toggleButtons();
        }//end dgvMarkets_SelectionChanged

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int index = (tabStocks.SelectedTab == tabMarkets ? dgvMarkets.SelectedRows[0].Index : dgvSectors.SelectedRows[0].Index);
                individualStockFormFunction(getStockSymbol(), 0);

                populateDataGridViewRow((tabStocks.SelectedTab == tabMarkets ? dgvMarkets : dgvSectors), index, map[getStockSymbol()]);

                var sorted = (tabStocks.SelectedTab == tabMarkets ? dgvMarkets.SortedColumn : dgvSectors.SortedColumn);
                var direction = (tabStocks.SelectedTab == tabMarkets ? dgvMarkets.SortOrder : dgvSectors.SortOrder);
                if (tabStocks.SelectedTab == tabMarkets)
                {
                    dgvMarkets.Rows[index].Selected = true;
                    if(sorted != null)
                    {
                        dgvMarkets.Sort(sorted, (direction == SortOrder.Ascending ? System.ComponentModel.ListSortDirection.Ascending : System.ComponentModel.ListSortDirection.Descending));
                    }
                } else
                {
                    dgvSectors.Rows[index].Selected = true;
                    if (sorted != null)
                    {
                        dgvSectors.Sort(sorted, (direction == SortOrder.Ascending ? System.ComponentModel.ListSortDirection.Ascending : System.ComponentModel.ListSortDirection.Descending));
                    }
                }//end if-else
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsbEdit_Click

        private void tsbNotes_Click(object sender, EventArgs e)
        {
            try
            {
                individualStockFormFunction(getStockSymbol(), 1);
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsbNotes_Click

        private string getStockSymbol()
        {
            string symbol;
            if (tabStocks.SelectedTab == tabMarkets)
            {
                symbol = dgvMarkets.SelectedRows[0].Cells["Symbol"].Value.ToString().Trim();
            }
            else
            {
                symbol = dgvSectors.SelectedRows[0].Cells["Symbol"].Value.ToString().Trim();
            }//end if-else
            return symbol;
        }//end getStockSymbol

        private void individualStockFormFunction(string symbol, int i)
        {
            frmStock frm = new frmStock(map[symbol], i);
            if (getDialogResult(frm) == DialogResult.OK)
            {
                map[symbol] = frm.getStock();
                var temp = frm.getDeletedNotes();
                if(temp.Count() > 0)
                {
                    foreach(int t in temp)
                    {
                        deletedNotes.Add(symbol + "#" + t.ToString());
                    }//end foreach
                }//end if
                //populateDataGridView((tabStocks.SelectedTab == tabMarkets ? dgvMarkets : dgvSectors), (tabStocks.SelectedTab == tabMarkets ? 'M' : 'S'));
                adjustChangesDictionary(symbol, 2);
                calculateOverallRating((tabStocks.SelectedTab == tabMarkets ? 'M' : 'S'));
                changesSaved = false;
            }//end if
        }//end individualStockFormFunction

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string symbol = getStockSymbol();
                char type;
                if(tabStocks.SelectedTab == tabMarkets)
                {
                    dgvMarkets.Rows.Remove(dgvMarkets.SelectedRows[0]);
                    type = 'M';
                } else
                {
                    dgvSectors.Rows.Remove(dgvSectors.SelectedRows[0]);
                    type = 'S';
                }//end if-else
                adjustChangesDictionary(symbol, 3);
                map.Remove(symbol);
                calculateOverallRating(type);
                changesSaved = false;
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsbDelete_Click

        private void calculateOverallRating(char type)
        {
            var calc = preferences.getCalculationPreferences(type);
            var query = from m in map
                        where m.Value.getType() == type && calc.Contains(m.Key)
                        select m.Value.getIndividualRating();

            int count = 0;
            int i = (type == 'M' ? 0 : 1);
            overallRating[i] = 0;
            foreach(var q in query)
            {
                overallRating[i] += q;
                count++;
            }//end foreach

            overallRating[i] /= count;
            displayOverallRating((tabStocks.SelectedTab == tabMarkets ? 0 : 1));
        }//end calculateOverallRating

        private void displayOverallRating(int i)
        {
            tslOverallRating.Text = String.Format("{0:0.0}", overallRating[i]);
        }//end displayOverallRating

        private void dgvMarkets_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEdit.PerformClick();
        }//end dgvMarkets_CellDoubleClick

        private void dgvSectors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEdit.PerformClick();
        }//end dgvSectors_CellDoubleClick

        private void tsmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }//end tsmExit_Click

        private void tsmSave_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseAccess dbAccess = new DatabaseAccess();
                foreach(var kvp in changes)
                {
                    string symbol = kvp.Key;
                    if(kvp.Value == 1)
                    {
                        dbAccess.insertIntoStocks(map[symbol]);
                        if(map[symbol].getNotes() != null && map[symbol].getNotes().Count() > 0)
                        {
                            dbAccess.insertIntoNotes(symbol, map[symbol].getNotes());
                        }//end nested if
                    } else if (kvp.Value == 2)
                    {
                        dbAccess.updateStocks(symbol, map[symbol]);
                        if (map[symbol].getNotes() != null && map[symbol].getNotes().Count() > 0)
                        {
                            var updateNotes = from m in map[symbol].getNotes()
                                              where m.getId() > -1
                                              select m;
                            var newNotes = from m in map[symbol].getNotes()
                                           where m.getId() == -1
                                           select m;
                            foreach(Note n in updateNotes)
                            {
                                dbAccess.updateNotes(n);
                            }//end foreach

                            if(newNotes.Count() > 0)
                            {
                                dbAccess.insertIntoNotes(symbol, newNotes.ToList());
                            }
                        }//end nested if
                    } else
                    {
                        dbAccess.deleteStock(symbol);
                    }//end if-else if-else
                }//end foreach

                foreach (string d in deletedNotes)
                {
                    string[] ds = d.Split('#');
                    dbAccess.deleteNote(ds[0], int.Parse(ds[1]));
                }//end foreach

                XmlData xmlData = new XmlData();
                xmlData.createBackupXml(map);
                xmlData.createBackupXml(map, String.Format("C:\\Users\\{0}\\.topdownanalysis", Environment.UserName));

                if (preferences.getNextPrompt() == new DateTime(1) || DateTime.Today >= preferences.getNextPrompt())
                {
                    int days = (preferences.getPromptDays() >= 1 ? preferences.getPromptDays() : 7);
                    preferences.setNextPrompt(DateTime.Now.AddDays(days));
                    dbAccess.insertIntoOutlook(DateTime.Today.ToShortDateString(), preferences.getOutlookRating(overallRating[0]));
                } else if (DateTime.Today == preferences.getPreviousPrompt())
                {
                    //TODO DOESN'T UPDATE IF SAVED MULTIPLE TIMES DURING THE SAME DAY
                    dbAccess.updateOutlook(DateTime.Today.ToShortDateString(), preferences.getOutlookRating(overallRating[0]));
                }//end if-else if

                xmlData.backupOverallRating(new DatabaseAccess().selectAllFromOutlook());
                xmlData.backupOverallRating(new DatabaseAccess().selectAllFromOutlook(), String.Format("C:\\Users\\{0}\\.topdownanalysis", Environment.UserName));
                
                changesSaved = true;
                saveCalculationPreferences();
                saveColumnPreferences();
                savePromptPreferences();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsmSave_Click

        private void tsmLoadXml_Click(object sender, EventArgs e)
        {
            try
            {
                loadStockXmlData();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//ent try-catch
        }//end tsmLoadXml_Click

        private void frmTopDownAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(changesSaved == false)
            {
                frmSaveBeforeExit frm = new frmSaveBeforeExit();
                var res = getDialogResult(frm);
                if (res == DialogResult.OK)
                {
                    tsmSave.PerformClick();
                } else if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }//end nested if-else if
            }//end if
        }//end frmTopDownAnalysis_FormClosing

        private void tsmSaveExit_Click(object sender, EventArgs e)
        {
            tsmSave.PerformClick();
            this.Close();
        }//end tsmSaveExit_Click

        private void tsmViewOutlook_Click(object sender, EventArgs e)
        {
            try
            {
                frmViewOutlook frm = new frmViewOutlook(new DatabaseAccess().selectAllFromOutlook());
                frm.Show();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end tsmViewOutlook

        private void populateDataGridViewRow(DataGridView dgv, int ri, Stock stock)
        {
            int ci = 0;
            foreach (DataGridViewColumn dc in dgv.Columns)
            {
                if (dc.Name == "Name")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getName();
                }
                else if (dc.Name == "Symbol")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getSymbol();
                }
                else if (dc.Name == "20 & 50 SMAs")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getSMA200();
                }
                else if (dc.Name == "50 SMA")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getSMA50();
                }
                else if (dc.Name == "20 SMA")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getSMA20();
                }
                else if (dc.Name == "Chart Pattern")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getChartPattern();
                }
                else if (dc.Name == "Market News")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getUnexpectedItems();
                }
                else if (dc.Name == "Rating")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getIndividualRating();
                }

                if (stock.getType() == 'S' && dc.Name == "Finviz Rank")
                {
                    dgv.Rows[ri].Cells[ci].Value = stock.getFinvizRank();
                }

                ci++;
            }//end nested foreach
        }//end populateDataGridViewRow

        private void tsmActualPerformance_Click(object sender, EventArgs e)
        {
            try
            {
                frmActualPerformance frm = new frmActualPerformance(0, preferences.getPromptDays());
                if(getDialogResult(frm) == DialogResult.OK)
                {
                    preferences.setPromptDays(frm.getPromptDays());
                }//end if
                if(preferences.getNextPrompt() <= DateTime.Today)
                {
                    frm = new frmActualPerformance();
                    frm.ShowDialog();
                    DatabaseAccess dbAccess = new DatabaseAccess();
                    dbAccess.updateOutlookActualPerformance(preferences.getPreviousPrompt().ToShortDateString(), preferences.getNextPrompt().ToShortDateString(), frm.getPerformance());
                }
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsmActualPerformance_Click
    }//end frmTopDownAnalysis
}//end namespace
