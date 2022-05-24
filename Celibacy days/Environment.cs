using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celibacy_days
{
    public enum VisionType {  cycleDay, cycleNight , error};
    public enum CelibacyType2
    {
        error = VisionType.error, celibacyDayTheMonth_N, Day30_N, Day31_N,
        celibacyDayTheMonth_D, Day30_D, Day31_D
    };

    internal class Environment
    {
        private Dictionary<int, List<Event>> events = new Dictionary<int, List<Event>>();
        public readonly Dictionary<VisionType, string> hashmapEvent = new Dictionary<VisionType, string>();
        private static readonly Environment instance = new Environment();

        private Environment()
        {
            hashmapEvent.Add(VisionType.error, "שגיאה");
            hashmapEvent.Add(VisionType.cycleDay, "ראית יום");
            hashmapEvent.Add(VisionType.cycleNight, "ראית לילה");
        }
        public static Environment Instance
        {
            get
            {
                return instance;
            }
        }

        public List<Event> getEvent(int date)
        {
            if(events.ContainsKey(date))
                return events[date];
            return null;
        }

        private void setEvent(Event event_)
        {
            if (!events.ContainsKey(event_.dateEvent))
                events.Add(event_.dateEvent, new List<Event>());
            
            events[event_.dateEvent].Add(event_);
        }

        private void addEventP(Event data)
        {
            setEvent(data);
            if (data.getType() == (int)VisionType.cycleDay ||
                data.getType() == (int)VisionType.cycleDay)
                Database.Instance.writeToFile(data);
        }
        public void addEvent(int dateEvent, VisionType eventType)
        {
            EventVision event_ = new EventVision(eventType, dateEvent);

            addEvent(event_);
        }
        public void addEvent(EventVision event_)
        {

            List<Event> list = getEvent(event_.dateEvent);
            if(list != null)
            {
                foreach(Event e in list)
                {
                    if(e.getType() == (int)event_.eventType)
                    {
                        return;
                    }

                }
            }
             addEventP(event_);
        }

        private bool removEvent(int dateEvent, int eventType)
        {
            List<Event> list = getEvent(dateEvent);

            if (list == null)
            {
                return false;
            }
            int listLenght = list.Count;
            for (int i = 0; i < listLenght; i++)
            {
                if (list[i].getType() == eventType)
                {
                    list.RemoveAt(i);
                    if (eventType < (int)VisionType.error)
                        Database.Instance.removEventFromFile(dateEvent, (VisionType)eventType);
                    if(list.Count == 0)
                    {
                        events.Remove (dateEvent);
                    }
                    return true;
                }
            }
            return false;
        }

        public void deleteAllEvents()
        {
            Database.Instance.removAllEvents();
            events.Clear();
        }
    }
}
