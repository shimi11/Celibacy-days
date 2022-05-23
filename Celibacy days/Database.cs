using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Celibacy_days
{

    enum EventType { erorr = -1, cycleDay, cycleNight};
    enum CelibacyType { erorr = -1, celibacyDayTheMonth_N , Day30_N, Day31_N,
        celibacyDayTheMonth_D, Day30_D, Day31_D };

    enum  TestsTypes
    {
        erorr = -1, celibacyDayTheMonth, Day30, Day31};

    class Event
    {
        public int dateEvent;
        public EventType eventType = new EventType();
       /* public static bool operator >(Event Event1, Event Event2)
        {
            if (Event1.dateEvent > Event2.dateEvent)
                return true;
            return false;
        }
        public static bool operator <(Event Event1, Event Event2)
        {
            if (Event1.dateEvent < Event2.dateEvent)
                return true;
            return false;
        }
        public static bool operator <=(Event Event1, Event Event2)
        {
            if (Event1.dateEvent <= Event2.dateEvent)
                return true;
            return false;
        }
        public static bool operator >=(Event Event1, Event Event2)
        {
            if (Event1.dateEvent >= Event2.dateEvent)
                return true;
            return false;
        }
        public static bool operator ==(Event Event1, Event Event2)
        {
            if (Event1.dateEvent == Event2.dateEvent)
                return true;
            return false;
        }
        public static bool operator !=(Event Event1, Event Event2)
        {
            if (Event1.dateEvent != Event2.dateEvent)
                return true;
            return false;
        }*/
    }
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

        /*
         public sealed class Singleton
{

    // Explicit static constructor to tell C# compiler
    // not to mark type as beforefieldinit
    static Singleton()
    {
    }

    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            return instance;
        }
    }
}

         */
        private Database() {
            hashmapEvent.Add((int)EventType.erorr, "שגיאה");
            hashmapEvent.Add((int)EventType.cycleDay, "ראית יום");
            hashmapEvent.Add((int)EventType.cycleNight, "ראית לילה");
            //hashmapEvent.Add((int)EventType.cycle, "ראיה");
            readDatabase();
                }
        //static Database()
        //{
        //}
        // private static Database instance = null;
        private static readonly Database instance = new Database();
        string fileName = @"Database.txt";
        private List<Event> AllEvents = new List<Event>();

        public Dictionary<int, string> hashmapEvent = new Dictionary<int, string>();

        public static Database Instance
        {
            get
            {
                return instance;
            }
        }
        private bool readDatabase() {
            bool r = false;
            try
            {
                string[] lista = File.ReadAllLines(fileName);

                List<string> CSList = new List<string>();
                foreach (string element in lista)
                {

                    AllEvents.Add(eventRecovery(element));
                }
                AllEvents.Sort(CompareDinosByLength);
                r = true;
            }
            catch
            {

            }
            return r;
        }
        private static int CompareDinosByLength(Event x, Event y)
        {
            if (x.dateEvent > y.dateEvent)
                return 1;
            if (x.dateEvent < y.dateEvent)
                return -1;
            return 0;
        }
        private void addEvent(Event data)
        {
            AllEvents.Add(data);

            AllEvents.Sort(CompareDinosByLength);
            if(data.eventType != EventType.erorr)
                writeToFile(data);
        }
        public void addEvent(int dateEvent_, EventType eventType_)
        {
            Event event_ = new Event();
            event_.dateEvent = dateEvent_;
            event_.eventType = eventType_;
            int aldEvent = (int)ThereIsEvent(event_.dateEvent);
            if (aldEvent == (int)EventType.erorr)
            {
                addEvent(event_);
            }
        }
        public Event eventRecovery(string data)
        {
            Event event_ = new Event();
            int Start;
            Start = data.IndexOf(" ", 0);
            if (Start == -1)
            {
                event_.dateEvent = 888;
                event_.eventType = EventType.erorr;
                return event_;
            }
            // End = strSource.IndexOf(strEnd, Start);
            event_.dateEvent = Int32.Parse(data.Substring(0,Start));
            event_.eventType = (EventType)Int32.Parse(data.Substring(Start));
            return event_;
        }
        public string eventRecovery(Event data)
        {
            string str = data.dateEvent + " " + (int)data.eventType;
            return str;
        }
        private void writeToFile(Event data)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.Write(eventRecovery(data) + "\n");
            }
            //File.WriteAllText(fileName, eventRecovery(data));
        }
        public EventType ThereIsEvent (int date)
        {
            int listLenght = AllEvents.Count;
            for (int i = 0; i< listLenght; i++)
            {
                if (AllEvents[i].dateEvent == date)
                    return AllEvents[i].eventType;
                if (AllEvents[i].dateEvent > date)
                    return EventType.erorr;
            }
            return EventType.erorr;
        }

        public void removAllEvents()
        {
            AllEvents.Clear();
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            MainPanel mainPanel = MainPanel.Instance;
            mainPanel.displaDays();
        }

        public void removEvent(int dateEvent_, EventType eventType_)
        {
            if(removEventFromList( dateEvent_,  eventType_))
            {
                MainPanel.Instance.displaDays();
                removEventFromFile(dateEvent_, eventType_);
            }
        }

        private bool removEventFromList(int dateEvent_, EventType eventType_)
        {
            int listLenght = AllEvents.Count;
            for (int i = 0; i < listLenght; i++)
            {
                if (AllEvents[i].dateEvent == dateEvent_ && AllEvents[i].eventType == eventType_)
                {
                    AllEvents.RemoveAt(i);
                    return true;
                }
                if (AllEvents[i].dateEvent > dateEvent_)
                    return false;
            }
            return false;
        }
        private bool removEventFromFile(int dateEvent_, EventType eventType_)
        {
            string lineToDelete = dateEvent_ + " " + (int)eventType_;
            var tempFile = Path.GetTempFileName();
            var linesToKeep = File.ReadLines(fileName).Where(l => l != lineToDelete);

            File.WriteAllLines(tempFile, linesToKeep);

            File.Delete(fileName);
            File.Move(tempFile, fileName);
            return false;
        }


        public List<Event> getEvents()
        {
            return AllEvents;
        }
    }
}
