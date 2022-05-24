using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celibacy_days
{
    public abstract class Event
    {
        private string note;
        public abstract int dateEvent
        {
            get;
        }

        public abstract int getType();
        public string getNote()
        {
            return note;
        }

    }
    public class EventVision : Event
    {
        public readonly VisionType eventType;
        public override int dateEvent  
        {
            get {
                return date;
                }
        }
        private int date;
        public EventVision(VisionType eventType_,int dateEvent_)
        {
            eventType = eventType_;
            date = dateEvent_;
        }
        public override int getType()
        {
           return (int)eventType;
        }
    }

    public class EventCelibacy : Event
    {
        public readonly CelibacyType2 eventType;

        public override int dateEvent
        {
            get
            {
                return date;
            }
        }
        private int date;

        EventCelibacy(CelibacyType2 eventType_, int dateEvent_)
        {
            eventType = eventType_;
            date = dateEvent_;
        }
        public override int getType()
        {
            return (int)eventType;
        }
    }
}


