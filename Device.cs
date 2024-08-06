using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Program
{
    public class Device
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String SerialNumber { get; set; }
        public String Reference { get; set; }
        public bool BoughtByUs { get; set; }
        public DateTime Bought { get; set; }
        public DateTime LastCheck { get; set; }
        public DateTime NextCheck { get; set; }
        public DateTime O2Sensor { get; set; }
        public virtual List<CheckUp> CheckUps { get; set; }
        public virtual Client Client { get; set; }
        public String Note { get; set; }
        public String Opmerking { get; set; }
        public String Price { get; set; }
        public virtual Sensor Sensor1 { get; set; }
        public virtual Sensor Sensor2 { get; set; }
        public virtual Sensor Sensor3 { get; set; }
        public virtual Sensor Sensor4 { get; set; }
        public virtual Sensor Sensor5 { get; set; }
        public virtual Sensor Sensor6 { get; set; }
        public virtual Sensor Sensor7 { get; set; }
        public virtual Sensor Sensor8 { get; set; }
        public String Alarm1L { get; set; }
        public String Alarm1H { get; set; }
        public String Alarm1S { get; set; }
        public String Alarm1T { get; set; }
        public String Alarm2L { get; set; }
        public String Alarm2H { get; set; }
        public String Alarm2S { get; set; }
        public String Alarm2T { get; set; }
        public String Alarm3L { get; set; }
        public String Alarm3H { get; set; }
        public String Alarm3S { get; set; }
        public String Alarm3T { get; set; }
        public String Alarm4L { get; set; }
        public String Alarm4H { get; set; }
        public String Alarm4S { get; set; }
        public String Alarm4T { get; set; }
        public String Alarm5L { get; set; }
        public String Alarm5H { get; set; }
        public String Alarm5S { get; set; }
        public String Alarm5T { get; set; }
        public String Alarm6L { get; set; }
        public String Alarm6H { get; set; }
        public String Alarm6S { get; set; }
        public String Alarm6T { get; set; }
        public String Alarm7L { get; set; }
        public String Alarm7H { get; set; }
        public String Alarm7S { get; set; }
        public String Alarm7T { get; set; }
        public String Alarm8L { get; set; }
        public String Alarm8H { get; set; }
        public String Alarm8S { get; set; }
        public String Alarm8T { get; set; }
        public bool HideAlarm1 { get; set; }
        public bool HideAlarm2 { get; set; }
        public bool HideAlarm3 { get; set; }
        public bool HideAlarm4 { get; set; }
        public bool HideAlarm5 { get; set; }
        public bool HideAlarm6 { get; set; }
        public bool HideAlarm7 { get; set; }
        public bool HideAlarm8 { get; set; }
        public bool Broken { get; set; }
        public bool Lost { get; set; }
        public bool NoS { get; set; }
        public DateTime Tdelete { get; set; }
        public bool Deleted { get; set; }
        public bool Aanwezig { get; set; }
    }
}