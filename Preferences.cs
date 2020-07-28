using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TopDownAnalysis
{
    public class Preferences
    {
        //preferenceLoaded[0,*] = calc, preferenceLoaded[1,*] = cols; preferenceLoaded[*,0] = Markets, preferenceLoaded[*,1] = Sectors
        bool[,] preferenceLoaded = new bool[2, 2];
        /// <summary>
        /// Holds the calculation and column preferences for each stock type
        /// </summary>
        private Dictionary<string, Dictionary<char, Dictionary<string, bool>>> preferencesMap = new Dictionary<string, Dictionary<char, Dictionary<string, bool>>>()
        {
            ["CALC"] = new Dictionary<char, Dictionary<string, bool>>()
            {
                ['M'] = new Dictionary<string, bool>(),
                ['S'] = new Dictionary<string, bool>()
            },
            ["COL"] = new Dictionary<char, Dictionary<string, bool>>()
            {
                ['M'] = new Dictionary<string, bool>() {
                    ["Name"] = true,
                    ["Symbol"] = true,
                    ["20 & 50 SMAs"] = true,
                    ["50 SMA"] = true,
                    ["20 SMA"] = true,
                    ["Chart Pattern"] = true,
                    ["Market News"] = true,
                    ["Rating"] = true
                },
                ['S'] = new Dictionary<string, bool>()
                {
                    ["Name"] = true,
                    ["Symbol"] = true,
                    ["20 & 50 SMAs"] = true,
                    ["50 SMA"] = true,
                    ["20 SMA"] = true,
                    ["Chart Pattern"] = true,
                    ["Market News"] = true,
                    ["Rating"] = true
                }
            }//end nested Dictionary<char,Dictionary<string,bool>>
        };//end preferencesMap

        private Dictionary<string, Dictionary<string, double>> scoreMap = new Dictionary<string, Dictionary<string, double>>()
        {
            ["SMA200"] = new Dictionary<string, double>() {
                ["Up"] = 10,
                ["Up and Down"] = 5,
                ["Down"] = 0 },
            ["SMA50/20"] = new Dictionary<string, double>() {
                ["Above"] = 10,
                ["At"] = 5,
                ["Below"] = 0 },
            ["CHART_PATTERN"] = new Dictionary<string, double>() {
                ["Bull Run"] = 10,
                ["Bull Consolidation"] = 7.5,
                ["Consolidation"] = 5,
                ["Bear Consolidation"] = 2.5,
                ["Bear Run"] = 0 },
            ["UNEXPECTED_ITEMS"] = new Dictionary<string, double>() {
                ["Very Good"] = 10,
                ["Good"] = 7.5,
                ["Average"] = 5.5,
                ["Bad"] = 3.5,
                ["Very Bad"] = 1,
                ["No News"] = 5.5 }
        };//end scoreMap

        private bool reinstalled;
        private int promptDays;
        private DateTime nextPrompt = new DateTime(1);
        private DateTime previousPrompt = new DateTime(1);
        
        /// <summary>
        /// Returns the symbol of each stock that has been selected to be used in the overall calculation.  Returns a List to the
        /// calling function. 'M' == Markets   'S' == Sectors
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> getCalculationPreferences(char type)
        {
            var calc = from p in preferencesMap["CALC"][type]
                       where p.Value == true
                       select p.Key;
            return calc.ToList();
        }//end getCalculationPreferences

        //Get methods
        public Dictionary<char, Dictionary<string, bool>> getCalculationDictionary() { return preferencesMap["CALC"]; }
        public Dictionary<char, Dictionary<string, bool>> getColumnDictionary() { return preferencesMap["COL"]; }
        public Dictionary<string, bool> getColumnDictionary(char type) { return preferencesMap["COL"][type]; }

        /// <summary>
        /// Returns the symbol of each column that is configured to display.  Returns a List to the calling function.
        /// 'M' == Markets    'S' == Sectors
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> getColumnPreferences(char type)
        {
            var cols = from c in preferencesMap["COL"][type]
                       where c.Value == true
                       select c.Key;
            return cols.ToList();
        }//end getColumnPreferences

        public DateTime getNextPrompt() { return nextPrompt; }
        public DateTime getPreviousPrompt() { return previousPrompt; }

        /// <summary>
        /// Returns the score of the specific Stock attribute to the calling function
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double getScore(string attribute, string value)
        {
            double score = 0;

            scoreMap[attribute].TryGetValue(value, out score);

            return score;
        }//end getScore

        /// <summary>
        /// Returns the bool value for the specific preference.  If loaded returns true else false.
        /// map is either "COL" or "CALC",  type is eeither 'M' or 'S'
        /// </summary>
        /// <param name="map"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool getPreferenceLoaded(string map, char type)
        {
            int i = (map == "CALC" ? 0 : 1);
            int j = (type == 'M' ? 0 : 1);
            return preferenceLoaded[i, j];
        }//end getPreferenceLoaded
        
        /// <summary>
        /// Returns the projected outlook rating to the calling program.
        /// </summary>
        /// <param name="rating"></param>
        /// <returns></returns>
        public string getOutlookRating(double rating)
        {
            if(rating >= 7.8)
            {
                return "+3";
            } else if(rating >= 6.3)
            {
                return "+2";
            } else if(rating >= 5.2)
            {
                return "+1";
            } else if(rating >= 4.6)
            {
                return "0";
            } else if(rating >= 2.7)
            {
                return "-1";
            } else if(rating >= 1.8)
            {
                return "-2";
            } else
            {
                return "-3";
            }
        }//end getOutlookRating

        public int getPromptDays() { return promptDays; }

        public bool getReinstalled() { return reinstalled; }
        //Set methods
        /// <summary>
        /// Sets the preferences in the preferencesMap Dictionary.  map is "CALC" or "COLS" to indicate the
        /// main entry point.  type is either 'M' or 'S' and the list provided will be associated with the
        /// either the DataGridView columns or Stock objects selected for calculation.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="type"></param>
        /// <param name="dict"></param>
        public void setPreference(string map, char type, Dictionary<string, bool> dict)
        {
            if (dict != null || dict.Count > 0)
            {
                preferencesMap[map][type] = dict;
            }
        }//end setPreferences

        public void setNextPrompt(DateTime nextPrompt)
        {
            this.nextPrompt = nextPrompt;
            savePromptDates();
        }
        public void setPreviousPrompt(DateTime previousPrompt)
        {
            this.previousPrompt = previousPrompt;
            savePromptDates();
        }
        public void setPromptDays(int promptDays)
        {
            this.promptDays = promptDays;
            nextPrompt = previousPrompt.AddDays(promptDays);
            savePromptDates();
        }
        public void defaultCalculationToTrue(char type)
        {
            var temp = preferencesMap["CALC"][type].Keys.ToList();
            foreach (string key in temp)
            {
                preferencesMap["CALC"][type][key] = true;
            }//end foreach
        }//end defaultCalculationToTrue

        /// <summary>
        /// Adds the provided symbol to the preferenceMap Dictionary if it is not present.  If it is, calls setPreference
        /// and edits the preference for the provided item
        /// </summary>
        /// /// <param name="type"></param>
        /// /// <param name="stock"></param>
        public void addStockToPreferences(char type, Stock stock)
        {
            if(!preferencesMap["CALC"][type].ContainsKey(stock.getSymbol()))
            {
                preferencesMap["CALC"][type].Add(stock.getSymbol(), stock.getUsedInCalculation());
            } else
            {
                preferencesMap["CALC"][type][stock.getSymbol()] = stock.getUsedInCalculation();
            }//end if-else
        }//end addToPreferences

        public void deleteStockFromPreferences(char type, string symbol)
        {
            if(preferencesMap["CALC"][type].ContainsKey(symbol))
            {
                preferencesMap["CALC"][type].Remove(symbol);
            }//end if
        }//end deleteStockFromPreferences

        /// <summary>
        /// Gets the number of columns that are displayed in the DataGridViews using the bool value in preferencesMap.
        /// Returns the integer value to the calling function
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private int checkDisplayedColCount(char type)
        {
            return (from c in preferencesMap["COL"][type]
                       where c.Value == true
                       select c.Key).Count();
        }//end getDisplayedColAmount

        /// <summary>
        /// If all the columns of the display are set to false, defaults the bool value to true to prevent errors
        /// </summary>
        /// <param name="type"></param>
        private void defaultAllColsToTrue(char type)
        {
            var temp = preferencesMap["COL"][type].Keys.ToList();
            foreach(string key in temp)
            {
                preferencesMap["COL"][type][key] = true;
            }//end foreach
        }//end defaultAllColsToTrue
        private void checkReinstalled()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"preferences\";
            if(Directory.Exists(path) && File.Exists(Path.Combine(path, "load.tda")))
            {
                reinstalled = false;
            } else
            {
                path = String.Format("C:\\Users\\{0}\\.topdownanalysis", Environment.UserName);
                if (Directory.Exists(path))
                {
                    reinstalled = true;
                } else
                {
                    reinstalled = false;
                }
            }
        }//end checkreinstalled
        public void loadPreferences()
        {
            checkReinstalled();
            string path = (!reinstalled ? AppDomain.CurrentDomain.BaseDirectory + @"preferences\" : "C:\\Users\\" + Environment.UserName + "\\.topdownanalysis\\");
            XmlData xmlData = new XmlData();
            if(Directory.Exists(path))
            {
                if(File.Exists(Path.Combine(path, (!reinstalled ? "calcpreferences.xml" : "topdownanalysiscalcpreferences.xml"))))
                {
                    loadCalculationPreferences(xmlData, 'M', (!reinstalled ? null : path));
                    loadCalculationPreferences(xmlData, 'S', (!reinstalled ? null : path));
                }//end nested if

                if(File.Exists(Path.Combine(path, (!reinstalled ? "columnpreferences.xml" : "topdownanalysiscolumnpreferences.xml"))))
                {
                    loadColumnPreferences(xmlData, 'M', (!reinstalled ? null : path));
                    if (checkDisplayedColCount('M') < 1)
                    {
                        defaultAllColsToTrue('M');
                    }//end if

                    loadColumnPreferences(xmlData, 'S', (!reinstalled ? null : path));
                    if (checkDisplayedColCount('S') < 1)
                    {
                        defaultAllColsToTrue('S');
                    }//end if
                }//end nested if

                if(File.Exists(Path.Combine(path, (!reinstalled ? "promptpreferences.xml" : "topdownanalysispromptpreferences.xml"))))
                {
                    loadNextPromptDate(xmlData, (!reinstalled ? null : path));
                } else
                {
                    previousPrompt = DateTime.Today;
                    promptDays = 7;
                }
            } else
            {
                previousPrompt = DateTime.Today;
                promptDays = 7;
            }//end if-else
        }//end loadPreferences

        /// <summary>
        /// Calls the load
        /// </summary>
        /// /// <param name="xmlData"></param>
        /// /// <param name="type"></param>
        private void loadCalculationPreferences(XmlData xmlData, char type, string path = null)
        {
            preferencesMap["CALC"][type] = xmlData.loadCalcPreferences(type, path);
            preferenceLoaded[0, (type == 'M' ? 0 : 1)] = true;
        }//end loadCalculationPreferences

        /// <summary>
        /// Calls the XmlData loadloadColumnPreferences.  Loads the column preferences for the Markets and Sectors DataGridViews
        /// </summary>
        /// <param name="xmlData"></param>
        /// <param name="type"></param>
        private void loadColumnPreferences(XmlData xmlData, char type, string path = null)
        {
            var cols = xmlData.loadColumnPreferences(type, path);
            setPreference("COL", type, cols);

            var colCount = checkDisplayedColCount(type);

            preferenceLoaded[1, (type == 'M' ? 0 : 1)] = (colCount > 0 && colCount <= preferencesMap["COL"][type].Count() ? true : false);
        }//end loadColumnPreferences

        private void createPath(string path)
        {
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }//end createPath
        private void loadNextPromptDate(XmlData xmlData, string path = null)
        {
            var dates = xmlData.loadPromptPreferences(path);
            string[] temp;
            if(dates[0] == "")
            {
                previousPrompt = DateTime.Today;
            } else
            {
                temp = dates[0].Split('/');
                previousPrompt = new DateTime(int.Parse(temp[2]), int.Parse(temp[0]), int.Parse(temp[1]));
            }//end if-else

            if (dates[1] == "")
            {
                nextPrompt = DateTime.Today.AddDays(7);
            }
            else
            {
                temp = dates[1].Split('/');
                nextPrompt = new DateTime(int.Parse(temp[2]), int.Parse(temp[0]), int.Parse(temp[1]));
            }//end if-else

            if(dates[2] == "")
            {
                promptDays = 7;
            } else
            {
                promptDays = int.Parse(dates[2]);
            }

            /*string path = AppDomain.CurrentDomain.BaseDirectory + @"\preferences\";
            createPath(path);
            if (File.Exists(Path.Combine(path, "nextprompt.txt")))
            {
                string prompt = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\preferences\", "nextprompt.txt"));
                if (prompt == null || prompt == "") { return; }
                string[] temp = prompt.Split('/');
                nextPrompt = new DateTime(int.Parse(temp[2]), int.Parse(temp[0]), int.Parse(temp[1]));

                if(temp.Length == 4)
                {
                    promptDays = int.Parse(temp[3]);
                } else
                {
                    promptDays = (nextPrompt - DateTime.Today).Days;
                }//end if-else
            }*/
        }//end loadNextPromptDate

        public void savePromptDates(string path = null)
        {
            XmlData xmlData = new XmlData();
            if(path == null)
            {
                xmlData.savePromptPreferences(previousPrompt, nextPrompt, promptDays);
            } else
            {
                xmlData.savePromptPreferences(previousPrompt, nextPrompt, promptDays, path);
            }
            /*string path = AppDomain.CurrentDomain.BaseDirectory + @"\preferences\";
            createPath(path);

            File.WriteAllText(Path.Combine(path, "nextprompt.txt"), (nextPrompt.ToShortDateString() + "/" + promptDays.ToString()));*/
        }//end saveNextPromptDate

    }//end Preferences
}//end TopDownAnalysis
