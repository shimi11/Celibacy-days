using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Celibacy_days
{   
    class DatabaseSettings
    {
        private DatabaseSettings()
        {
            AllSettings.Add(new Setting_dayOfMonth_missingAfterFull(AllSettings.Count));
            AllSettings.Add(new Day31(AllSettings.Count));
            reset();
            readDatabase();
        }
        string fileNameSettings = @"Settings.txt"; 
        private static readonly DatabaseSettings instance = new DatabaseSettings();

        public static DatabaseSettings Instance
        {
            get
            {
                return instance;
            }
        }
        private List<ISetting> AllSettings = new List<ISetting>();

        private bool readDatabase()
        {
            bool r = false;
            try
            {
                string[] lista = File.ReadAllLines(fileNameSettings);

                List<string> CSList = new List<string>();
                int i = 0;
                foreach (string element in lista)
                {
                    int x = 0;
                    Int32.TryParse(element, out x);
                    AllSettings[i++].setValue(x);
                }
                r = true;
            }
            catch
            {

            }
            return r;
        }
        private bool reset(bool anyway = false)
        {
            if (anyway ||!File.Exists(fileNameSettings) ||
              File.ReadLines(fileNameSettings).Count() < AllSettings.Count)
            {
                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (File.Exists(fileNameSettings))
                    {
                        File.Delete(fileNameSettings);
                    }

                    // Create a new file     
                    using (StreamWriter sw = File.CreateText(fileNameSettings))
                    {
                        for(int i = 0; i<5;i++)
                        {
                            sw.WriteLine(AllSettings[i].defaultValue());
                        }
                    }
                }
                catch (Exception Ex)
                {
                    //Console.WriteLine(Ex.ToString());
                }
            }
            return true;
        }

        public void lineChanger(string newText, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileNameSettings);
            if(arrLine.Length < line_to_edit)
            {
                reset(true);
                lineChanger(newText, line_to_edit);
            }
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileNameSettings, arrLine);
        }

        public ISetting GetSetting(int index)
        {
            try
            {
                return AllSettings[index];
            }
            catch (Exception Ex)
            {
                return null;
                //Console.WriteLine(Ex.ToString());
            }
        }

    }

    class Database
    {
        private Database() {
        }
        private static readonly Database instance = new Database();
        readonly string fileName = @"Database.txt";

        public static Database Instance
        {
            get
            {
                return instance;
            }
        }
        public bool readDatabase() {
            bool r = false;
            try
            {
                string[] lista = File.ReadAllLines(fileName);

                foreach (string element in lista)
                {
                    Environment.Instance.addEvent(eventRecovery(element));
                }
                r = true;
            }
            catch
            {

            }
            return r;
        }
        
        public EventVision eventRecovery(string data)
        {
            int Start;
            Start = data.IndexOf(" ", 0);
            if (Start == -1)
            {
                throw new Exception("Unable to read data:" + data);
            }
            EventVision event_ = new EventVision((VisionType)Int32.Parse(data.Substring(Start))
                , Int32.Parse(data.Substring(0, Start)));
            return event_;
        }
        public string eventRecovery(Event data)
        {
            string str = data.dateEvent + " " + (int)data.getType();
            return str;
        }
        public void writeToFile(Event data)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.Write(eventRecovery(data) + "\n");
            }
            //File.WriteAllText(fileName, eventRecovery(data));
        }

        public void removAllEvents()
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            MainPanel mainPanel = MainPanel.Instance;
            mainPanel.displaDays();
        }

        public bool removEventFromFile(int dateEvent_, VisionType eventType_)
        {
            string lineToDelete = dateEvent_ + " " + (int)eventType_;
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(fileName).Where(l => l != lineToDelete);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(fileName);
            File.Move(tempFile, fileName);
            return false;
        }

    }
}
