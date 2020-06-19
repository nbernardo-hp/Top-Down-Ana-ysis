using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace StockTopDownAnalysis
{
    public partial class frmTopDownAnalysis : Form
    {
        int tab = 0; //0 denotes Markets tab, 1 denotes Sectors tab
        bool[] colsLoaded = { false, false };//used to indicate if the column configuration has be loaded from a .xml file. Index 0 = Markets, 1 = Sectors
        bool saved = true; //used to determine if the save before exit dialog should appear
        double marketsRating = 0;
        double sectorsRating = 0;
        Dictionary<string, Market> markets = new Dictionary<string, Market>();
        Dictionary<string, Sector> sectors = new Dictionary<string, Sector>();

        //Used to determine which columns are used in the Market and Sectors Overall Rating calc
        List<string> marketsCalc = new List<string>();
        List<string> sectorsCalc = new List<string>();

        /// <summary>
        /// Denotes if there is any change that is applied to a specific stock to be used when saving
        /// </summary>
        //1 = edited, 2 = new, 3 = deleted
        Dictionary<string, int> changes = new Dictionary<string, int>();
        public frmTopDownAnalysis()
        {
            InitializeComponent();
        }

        private void frmTopDownAnalysis_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseAccess dbAccess = new DatabaseAccess();
                DataTable dt = dbAccess.selectAll('M');
                populateDictionary(dt, 'M');
                dt = dbAccess.selectAll('S');
                populateDictionary(dbAccess.selectAll('S'), 'S');
                configureDataGridView();
                configureDataGridView(true);
                dgvMarkets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvSectors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end frmTopDownAnalysis_Load

        /// <summary>
        /// Configures the DataGridViews.  If no column configuration is provided for the DataGridView
        /// calls the createColumns(DataGridView dgv, bool isSectors = false) function.  Else calls the
        /// createColumns(DataGridView dgv, List<string> cols) function
        /// </summary>
        private void configureDataGridView(bool isSectors = false)
        {
            try
            {
                List<string> cols = loadColumnConfiguration(isSectors);
                if(!isSectors)
                {
                    if(colsLoaded[0])
                    {
                        createColumns(dgvMarkets, cols);
                        populateDataGridView(cols, dgvMarkets);
                    } else
                    {
                        createColumns(dgvMarkets);
                        populateMarkets();
                    }//end nested if-else
                } else
                {
                    if(colsLoaded[1])
                    {
                        createColumns(dgvSectors, cols);
                        populateDataGridView(cols, dgvSectors, true);
                    } else
                    {
                        createColumns(dgvSectors, true);
                        populateSectors();
                    }//end nested if-else
                }//end if-else
            } catch (Exception ex)
            {
                errorMessage(ex);
            }//end try-catch
        }//end configureDataGridView

        private void frmTopDownAnalysis_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*Determines if the save before exit dialog should be displayed and displays it if so.
             *If the result comes back as OK save to the database and backup.  If Abort don't save and
             *exit the application.  If Cancel cancel exiting the application*/
            if (!saved)
            {
                frmSaveBeforeExit saveBeforeExit = new frmSaveBeforeExit();
                DialogResult res = saveBeforeExit.ShowDialog();
                
                if(res == DialogResult.OK)
                {
                    tsmSave.PerformClick();
                } else if(res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }//end frmTopDownAnalysis_FormClosing

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                tab = tabControl1.SelectedIndex;
                displayOverallRating();
                enableButtons();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tabControl1_SelectedIndexChanged

        /// <summary>
        /// Calls enableButtons to enable the Edit, Notes, and Delete buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSectors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enableButtons();
        }//end dgvSectors_CellClick

        /// <summary>
        /// Calls enableButtons to enable the Edit, Notes, and Delete buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMarkets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            enableButtons();
        }//end dgvMarkets_CellClick

        /// <summary>
        /// Instantiates and displays a new form for the individual stock to be added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmIndividualStock stock;
                if (tab == 0)
                {
                    stock = new frmIndividualStock("Market");
                }
                else
                {
                    stock = new frmIndividualStock("Sector");
                }
                getIndividualResult(stock);
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsbAdd_Click

        /// <summary>
        /// Instantiates and displays a new form for the individual stock to be edited.  If the DialogResult from the form is OK
        /// a new Sector or Market object will be returned and added to the appropriate dictionary.  The DataGridView will also repopulate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            
            try
            {
                frmIndividualStock stock;

                if (tab == 0)
                {
                    string s = dgvMarkets.SelectedRows[0].Cells["SYMBOL"].Value.ToString().TrimEnd();
                    stock = new frmIndividualStock("Market", markets[s].getName(), s, markets[s].getSMA200(), markets[s].getSMA50(), markets[s].getSMA20(), markets[s].getChartPattern(), markets[s].getUnexpectedItems());
                }
                else
                {
                    string s = dgvSectors.SelectedRows[0].Cells["SYMBOL"].Value.ToString().TrimEnd();
                    stock = new frmIndividualStock("Sector", sectors[s].getName(), s, sectors[s].getSMA200(), sectors[s].getSMA50(), sectors[s].getSMA20(), sectors[s].getChartPattern(), sectors[s].getUnexpectedItems(), sectors[s].getFinvizRank());
                }

                getIndividualResult(stock);
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsbEdit_Click

        private void tsbNotes_Click(object sender, EventArgs e)
        {
            string symbol = "";
            if(tab == 0)
            {
                symbol = dgvMarkets.SelectedRows[0].Cells["SYMBOL"].Value.ToString();
                frmNotes frm = new frmNotes(markets[symbol].getNotes(), markets[symbol].getName());
            } else
            {
                symbol = dgvSectors.SelectedRows[0].Cells["SYMBOL"].Value.ToString();
                frmNotes frm = new frmNotes(sectors[symbol].getNotes(), sectors[symbol].getName());
            }
        }//end tsbNotes_Click

        /// <summary>
        /// Deletes the selected row from the specific Dictionary and repopulates the current DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string symbol = "";

                if(tab == 0)
                {
                    symbol = dgvMarkets.SelectedRows[0].Cells["SYMBOL"].Value.ToString().TrimEnd();
                    markets.Remove(symbol);
                    populateMarkets();
                    enableButtons();
                } else
                {
                    symbol = dgvSectors.SelectedRows[0].Cells["SYMBOL"].Value.ToString().TrimEnd();
                    sectors.Remove(symbol);
                    populateSectors();
                    enableButtons();
                }
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsbDelete_Click

        /// <summary>
        /// Saves the changes made to the database.  Iterates through the changes dictionary to
        /// determine if the item should be inserted as a new row, updated, or deleted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //1=update, 2=insert, 3=delete
        private void tsmSave_Click(object sender, EventArgs e)
        {
            try
            {
                DatabaseAccess dbAccess = new DatabaseAccess();

                foreach (var kvp in changes)
                {
                    string key = kvp.Key;
                    int val = kvp.Value;

                    if (val == 1)
                    {
                        if (markets.ContainsKey(key))
                        {
                            dbAccess.updateRow(markets[key]);
                        }
                        else
                        {
                            dbAccess.updateRow(sectors[key], sectors[key].getFinvizRank());
                        }//end nested if-else
                    }
                    else if (val == 2)
                    {
                        if (markets.ContainsKey(key))
                        {
                            dbAccess.insertInto(markets[key]);
                        }
                        else
                        {
                            dbAccess.insertInto(sectors[key], sectors[key].getFinvizRank());
                        }//end nested if-else
                    }
                    else
                    {
                        dbAccess.deleteRow(key);
                    }//end if-elseif-else

                    saved = true;
                }//end foreach
            } catch (Exception ex)
            {
                errorMessage(ex);
            } finally
            {
                XmlData xmlData = new XmlData();
                xmlData.createBackupXml(markets, sectors);
            }
        }//end tsmSave_Click

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsmExit_Click

        /// <summary>
        /// Sends a list of all the items in dgvMarket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmMarketOverallCalc_Click(object sender, EventArgs e)
        {
            try
            {
                string[,] stocks = new string[markets.Count, 2];
                bool[] isChecked = new bool[markets.Count];

                int i = 0;
                foreach (var kvp in markets)
                {
                    stocks[i, 0] = kvp.Value.getName();
                    stocks[i, 1] = kvp.Value.getSymbol();
                    isChecked[i] = kvp.Value.getUsedInCalculation();
                    i++;
                }

                displayOverallCalcForm(stocks, isChecked);
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end tsmMarketOverallCalc_Click

        /// <summary>
        /// Instantiates and displays a form to configure the columns displayed on the provided
        /// DataGridView.If the DialogResult is OK clear the DGV, Create the new Columns and
        /// add the appropriate information to the DGV by calling the populateDataGridView function
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="table"></param>
        /// <param name="dgv"></param>
        private void showConfigureForm(List<string> cols, string table, DataGridView dgv)
        {
            List<string> attributes = new List<string>() { "NAME", "SYMBOL", "SMA200", "SMA50", "SMA20", "CHART_PATTERN", "UNEXPECTED_ITEMS", "FINVIZ_RANK", "INDIVIDUAL_RATING" };
            if(table == "Market") { attributes.Remove("FINVIZ_RANK"); }
            frmColumns displayCols = new frmColumns(table, attributes, cols);
            DialogResult res = displayCols.ShowDialog();

            if (res == DialogResult.OK)
            {
                cols = displayCols.getColumns();
                createColumns(dgv, cols);
                /*dgv.Rows.Clear();
                dgv.Columns.Clear();
                foreach (string c in cols)
                {
                    dgv.Columns.Add(c, c);
                }//end foreach*/
                populateDataGridView(cols, dgv, (table == "Market" ? false : true));
                saveColumnConfiguration(cols, (table == "Market" ? 0 : 1));
            }//end if
        }//end displayConfigureForm

        /// <summary>
        /// Calls the getColumns function to get the columns of the DataGridView.  Then calls the
        /// showCofigureForm function to get the new configuration.  Saves the preferences by
        /// calling the saveColumnConfiguration function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmMarketDisplayedCols_Click(object sender, EventArgs e)
        {
            List<string> cols = getColumns(dgvMarkets);
            showConfigureForm(cols, "Market", dgvMarkets);
        }//end tsmMarketDisplayCols_Click

        private void tsmSectorOverallCalc_Click(object sender, EventArgs e)
        {
            string[,] stocks = new string[sectors.Count, 2];
            bool[] isChecked = new bool[sectors.Count];

            int i = 0;
            foreach (var kvp in sectors)
            {
                stocks[i, 0] = kvp.Value.getName();
                stocks[i, 1] = kvp.Value.getSymbol();
                isChecked[i] = kvp.Value.getUsedInCalculation();
                i++;
            }//end foreach
            displayOverallCalcForm(stocks, isChecked, true);
        }//end tsmSectorOverallCalc_Click

        /// <summary>
        /// Calls the getColumns function to get the columns of the DataGridView.  Then calls the
        /// showCofigureForm function to get the new configuration.  Saves the preferences by
        /// calling the saveColumnConfiguration function.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmSectorsDisplayedCols_Click(object sender, EventArgs e)
        {
            List<string> cols = getColumns(dgvSectors);
            showConfigureForm(cols, "Sector", dgvSectors);
        }//end tsmSectorsDisplayCols_Click

        /// <summary>
        /// Populates a temporary dictionary with initial values for the markets and sectors dictionary's.
        /// If the type in the datatable is 'S' add the entry to the sectors dictionary otherwise adds it to the markets dictionary
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        private void populateDictionary(DataTable dt, char type)
        {
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    double individualRating;
                    double.TryParse(dr.Field<decimal>("INDIVIDUAL_RATING").ToString(), out individualRating);

                    string symbol = dr.Field<string>("SYMBOL").TrimEnd();

                    if (type == 'M')
                    {
                        if (!markets.ContainsKey(symbol))
                        {
                            markets.Add(symbol, new Market(dr.Field<string>("NAME").TrimEnd(), dr.Field<string>("SYMBOL").TrimEnd(),
                                dr.Field<string>("SMA200").TrimEnd(), dr.Field<string>("SMA50").TrimEnd(), dr.Field<string>("SMA20").TrimEnd(),
                                dr.Field<string>("CHART_PATTERN").TrimEnd(), dr.Field<string>("UNEXPECTED_ITEMS").TrimEnd(), 0.0));
                        }
                        markets[symbol].calculateIndividualRating();
                    }
                    else
                    {
                        if (!sectors.ContainsKey(symbol))
                        {
                            int finvizRank = dr.Field<int>("FINVIZ_RANK");
                            sectors.Add(symbol, new Sector(dr.Field<string>("NAME").TrimEnd(), dr.Field<string>("SYMBOL").TrimEnd(),
                                dr.Field<string>("SMA200").TrimEnd(), dr.Field<string>("SMA50").TrimEnd(), dr.Field<string>("SMA20").TrimEnd(),
                                dr.Field<string>("CHART_PATTERN").TrimEnd(), dr.Field<string>("UNEXPECTED_ITEMS").TrimEnd(), finvizRank, 0.0));
                        }
                        sectors[symbol].calculateIndividualRating();
                    }//end if-else
                }//end foreach
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }

        }//end populateDictionary

        /// <summary>
        /// Adds the returned item from the individual form to the Markets dictionary if it doesn't contain the key.
        /// Otherwise it will update the correct entry
        /// </summary>
        /// <param name="market"></param>
        private void addToMarkets(Market market)
        {
            try
            {
                string symbol = market.getSymbol();
                market.calculateIndividualRating();

                changeStatus(symbol);
                if (!markets.ContainsKey(symbol))
                {
                    markets.Add(symbol, market);
                } else
                {
                    markets[symbol] = market;
                }

                populateMarkets();
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end addToMarkets

        /// <summary>
        /// Adds the returned item from the individual form to the Sectors dictionary if it
        /// doesn't contain the key.  Otherwise it will update the correct entry
        /// </summary>
        private void addToSectors(Sector sector)
        {
            try
            {
                string symbol = sector.getSymbol();
                sector.calculateIndividualRating();

                changeStatus(symbol);
                if (!sectors.ContainsKey(symbol))
                {
                    sectors.Add(symbol, sector);
                }
                else
                {
                    sectors[symbol] = sector;
                }
                populateSectors();
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end addToMarkets

        /// <summary>
        /// Checks the Changes dictionary to determine if any changes have occurred with the
        /// object. Adds an entry with the symbol if not.  Checks to see if Markets or Sectors
        /// contains the key, returns 1 if they do or 2 if they dont.  If Changes contains the
        /// key, check to determine if the item was added or updated.  If the value at that index
        /// is no 2, keep the value the same ot
        /// </summary>
        //1 = edited and 2 = new
        private void changeStatus(string symbol)
        {
            if (!changes.ContainsKey(symbol))
            {
                int val = (markets.ContainsKey(symbol) || sectors.ContainsKey(symbol) ? 1 : 2);
                changes.Add(symbol, val);
            }
            else
            {
                int val = 0;
                changes.TryGetValue(symbol, out val);

                changes[symbol] = (val != 2 ? 1 : 2);
            }//end if-else
        }//end changeStatus
        private void createColumns(DataGridView dgv, List<string> cols)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            foreach(string c in cols)
            {
                dgv.Columns.Add(c, c);
            }//end foreach
        }//end createColumns

        /// <summary>
        /// Adds the columns to the DataGridViews
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="isSectors"></param>
        private void createColumns(DataGridView dgv, bool isSectors = false)
        {
            try
            {
                dgv.Columns.Add("NAME", "NAME");
                dgv.Columns.Add("SYMBOL", "SYMBOL");
                dgv.Columns.Add("SMA200", "SMA200");
                dgv.Columns.Add("SMA50", "SMA50");
                dgv.Columns.Add("SMA20", "SMA20");
                dgv.Columns.Add("CHART_PATTERN", "CHART_PATTERN");
                dgv.Columns.Add("UNEXPECTED_ITEMS", "UNEXPECTED_ITEMS");

                if (isSectors)
                {
                    dgv.Columns.Add("FINVIZ_RANK", "FINVIZ_RANK");
                }

                dgv.Columns.Add("INDIVIDUAL_RATING", "INDIVIDUAL_RATING");

                createToolTips(dgv);
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end createColumns

        /// <summary>
        /// Creates the ToolTips for specific columns
        /// </summary>
        /// <param name="dgv"></param>
        private void createToolTips(DataGridView dgv)
        {
            dgv.Columns["SMA50"].ToolTipText = "Is Stock Price:\n- Below 50 SMA\n- At the 50 SMA\n- Above 50 SMA (strong stock)";
            dgv.Columns["CHART_PATTERN"].ToolTipText = "Look at the Weekly chart to determine what to place here.";
            dgv.Columns["UNEXPECTED_ITEMS"].ToolTipText = "If no news, enter \"No News\", not \"Average\".";
        }//end createToolTips

        /// <summary>
        /// Populates the Markets DataGridView and calls the calculateOverallRating function
        /// </summary>
        private void populateMarkets()
        {
            try
            {
                dgvMarkets.Rows.Clear();

                foreach (var kvp in markets)
                {
                    dgvMarkets.Rows.Add(new object[] { kvp.Value.getName(), kvp.Value.getSymbol(),
                    kvp.Value.getSMA200(), kvp.Value.getSMA50(), kvp.Value.getSMA20(), kvp.Value.getChartPattern(),
                    kvp.Value.getUnexpectedItems(), String.Format("{0:0.0}", kvp.Value.getIndividualRating()) });
                }
                getCalcPreferences("Market");
                calculateOverallRating(ref marketsRating);
                displayOverallRating();
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end populateMarkets

        /// <summary>
        /// Populates the DataGridView with the information for the columns provided.  The dictionary is
        /// determined using the isSectors variable which is defaulted to false.
        /// </summary>
        /// <param name="cols"></param>
        private void populateDataGridView(List<string> cols, DataGridView dgv, bool isSectors = false)
        {
            int ri = 0;
            int rowCount = (!isSectors ? markets.Count : sectors.Count);
            dgv.Rows.Add(rowCount);
            DatabaseAccess dbAccess = new DatabaseAccess();
            if(!isSectors)
            {
                foreach (var kvp in markets)
                {
                    var row = dbAccess.selectFrom(cols, kvp.Key);
                    for (int i = 0; i < dgvMarkets.Columns.Count; i++)
                    {
                        dgvMarkets.Rows[ri].Cells[i].Value = row[i];
                    }
                    ri++;
                }//end foreach
                calculateOverallRating(ref marketsRating);
            } else
            {
                foreach(var kvp in sectors)
                {
                    var row = dbAccess.selectFrom(cols, kvp.Key);
                    for(int i = 0; i < dgvSectors.Columns.Count; i++)
                    {
                        dgvSectors.Rows[ri].Cells[i].Value = row[i];
                    }
                    ri++;
                }//end foreach
                calculateOverallRating(ref sectorsRating, true);
            }//end if-else
        }//end populateDataGridView

        /// <summary>
        /// Populates the Sectors DataGridView and calls the calculateOverallRating function
        /// </summary>
        private void populateSectors()
        {
            try
            {
                dgvSectors.Rows.Clear();

                foreach (var kvp in sectors)
                {
                    dgvSectors.Rows.Add(new object[] { kvp.Value.getName(), kvp.Value.getSymbol(),
                    kvp.Value.getSMA200(), kvp.Value.getSMA50(), kvp.Value.getSMA20(), kvp.Value.getChartPattern(),
                    kvp.Value.getUnexpectedItems(), kvp.Value.getFinvizRank(), String.Format("{0:0.0}", kvp.Value.getIndividualRating()) });
                }
                getCalcPreferences("Sector");
                calculateOverallRating(ref sectorsRating, true);
                displayOverallRating();
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end populateSectors

        /// <summary>
        ///Gets the individual rating of every item contained in the Markets or Sectors
        ///dictionary if the usedInCalculation attribute is true.  Returns a double array'
        ///containing the total, at index 0, and the total number of items included, at index 1
        /// </summary>
        private double[] getIndividualRatings(bool isSectors = false)
        {
            double[] res = new double[2] { 0, 0 };

            try
            {
                if (!isSectors)
                {
                    foreach (var kvp in markets)
                    {
                        if(kvp.Value.getUsedInCalculation() == true)
                        {
                            res[0] += kvp.Value.getIndividualRating();
                            res[1]++;
                        }
                    }//end foreach
                }
                else
                {
                    foreach (var kvp in sectors)
                    {
                        if (kvp.Value.getUsedInCalculation() == true)
                        {
                            res[0] += kvp.Value.getIndividualRating();
                            res[1]++;
                        }
                    }//end foreach
                }//end if-else
            } catch (Exception ex)
            {
                errorMessage(ex);
            }

            return res;
        }//end getIndividualRatings

        /// <summary>
        /// Calculates the overall rating of the Markets and Sectors.  Assigns the value to the appropriate variable
        /// </summary>
        /// <param name="rating"></param>
        /// <param name="isSectors"></param>
        private void calculateOverallRating(ref double rating, bool isSectors = false)
        {
            try
            {
                rating = 0;

                double[] list = getIndividualRatings(isSectors);

                rating = list[0] / list[1];
                rating = Math.Round(rating, 1);
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end calculateOverallRating

        /// <summary>
        /// Displays the overall rating for the selected tab in the ToolStripMenu
        /// </summary>
        private void displayOverallRating()
        {
            try
            {
                if (tab == 0)
                {
                    tslTab.Text = "Market Rating: ";
                    tslRating.Text = String.Format("{0:0.0}", marketsRating);
                }
                else
                {
                    tslTab.Text = "Sector Rating: ";
                    tslRating.Text = String.Format("{0:0.0}", sectorsRating);
                }
            }
            catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end displayOverallRating

        /// <summary>
        /// Enables the Edit, Notes, and Delete buttons depending on if an item is selected on the current tab
        /// </summary>
        private void enableButtons()
        {
            try
            {
                if ((tab == 0 && dgvMarkets.SelectedRows.Count > 0) || (tab == 1 && dgvSectors.SelectedRows.Count > 0))
                {
                    tsbEdit.Enabled = true;
                    tsbNotes.Enabled = true;
                    tsbDelete.Enabled = true;
                }
                else
                {
                    tsbEdit.Enabled = false;
                    tsbNotes.Enabled = false;
                    tsbDelete.Enabled = false;
                }
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end enableButtons

        /// <summary>
        /// Displays and retreives the result from the individual stock form.  Calls the function to add to the correct dictionary if the DialogResult is OK
        /// </summary>
        /// <param name="stock"></param>
        private void getIndividualResult(frmIndividualStock stock)
        {
            try
            {
                DialogResult res = stock.ShowDialog();
                if(res == DialogResult.OK)
                {
                    if(tab == 0)
                    {
                        addToMarkets(stock.getMarket());
                    } else
                    {
                        addToSectors(stock.getSector());
                    }//end nested if-else

                    saved = false;
                }//end if
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end getIndividualResult

        /// <summary>
        /// Gets the columns displayed in the DataGridView to be provided to the column configuration form
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private List<string> getColumns(DataGridView dgv) {
            List<string> res = new List<string>();

            foreach(DataGridViewColumn dc in dgv.Columns)
            {
                res.Add(dc.Name);
            }

            return res;
        }//end getColumns

        /// <summary>
        /// Displays the form that contains all the stocks in Markets or Sectors.  If the DialogResult
        /// from the form is OK, call setUsedInCalcAttribute funtion to set the attribute for in the dictionary
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="isChecked"></param>
        private void displayOverallCalcForm(string[,] stocks, bool[] isChecked, bool isSectors = false)
        {
            frmOverallCalculation calc = new frmOverallCalculation(stocks, isChecked);
            DialogResult res = calc.ShowDialog();
            if (res == DialogResult.OK)
            {
                isChecked = calc.getResult().ToArray();
                setUsedInCalcAttribute(isChecked, isSectors);
                displayOverallRating();
            }//end if
        }//end displayOverallCalcForm

        /// <summary>
        /// Sets the usedInCalc attribute for each item in the dictionary.  Calls the function
        /// calculate the overall rating for the table.  Saves the to the preferences folder
        /// by calling the XmlData.saveCalculationPreferences function
        /// </summary>
        /// <param name="isChecked"></param>
        /// <param name="isSectors"></param>
        private void setUsedInCalcAttribute(bool[] isChecked, bool isSectors = false)
        {
            int i = 0;
            if (!isSectors)
            {
                foreach (var kvp in markets)
                {
                    kvp.Value.setUsedInCalculation(isChecked[i]);
                    i++;
                }//end foreach

                calculateOverallRating(ref marketsRating);
            }
            else
            {
                foreach (var kvp in sectors)
                {
                    kvp.Value.setUsedInCalculation(isChecked[i]);
                    i++;
                }//end foreach

                calculateOverallRating(ref sectorsRating, true);
            }//end if-else

            XmlData data = new XmlData();
            data.saveCalculationPreferences(markets, sectors);
        }//end setUsedInCalcAttribute

        /// <summary>
        /// Displays the error thrown by the exception
        /// </summary>
        /// <param name="ex"></param>
        public static void errorMessage(Exception ex)
        {
            MessageBox.Show("Error! " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Instantiates a new XmlData class to return the dictionary of each item saved in the preferences
        /// If the dictionary contains the symbol, sets the value of usedInCalculation to the value in the
        /// returned dictionary.
        /// </summary>
        /// <param name="table"></param>
        private void getCalcPreferences(string table)
        {
            try
            {
                XmlData xmlData = new XmlData();
                Dictionary<string, bool> map = xmlData.loadCalcPreferences(table);
                
                foreach(var kvp in map)
                {
                    string symbol = kvp.Key;
                    if(markets.ContainsKey(symbol))
                    {
                        markets[symbol].setUsedInCalculation(kvp.Value);
                    } else if(sectors.ContainsKey(symbol))
                    {
                        sectors[symbol].setUsedInCalculation(kvp.Value);
                    }
                }
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end getCalcPreferences

        /// <summary>
        /// Saves the column configuration preferences for each DataGridView in a .xml file.
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="table"></param>
        private void saveColumnConfiguration(List<string> cols, int table)
        {
            try
            {
                XmlData xmlData = new XmlData();
                xmlData.saveColumnPreferences(cols, table);
            } catch (Exception ex)
            {
                errorMessage(ex);
            }
        }//end saveColumnConfiguration

        /// <summary>
        /// Loads the column configuration of each DataGridView if it exists.
        /// </summary>
        private List<string> loadColumnConfiguration(bool isSectors = false)
        {
            List<string> cols = new List<string>();
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\preferences\";
            if (Directory.Exists(path))
            {
                XmlData xmlData = new XmlData();

                string file = (isSectors ? "sectorCols.xml" : "marketCols.xml");
                int i = (isSectors ? 1 : 0);

                if(File.Exists(Path.Combine(path,file)))
                {
                    cols = xmlData.loadColumnPreferences(i);
                    colsLoaded[0] = true;
                }//end nested if
            }//end if

            return cols;
        }//end loadColumnConfiguration
    }//end frmTopDownAnalysis
}
