using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Program
{
    public class CheckUp
    {
        public int Id { get; set;}
        public DateTime Date { get; set; }
        public DateTime NextDate { get; set; }
        public String Details { get; set; }
        public String Note { get; set; }
        public virtual Device Device { get; set; }
        public String Number { get; set; }
        public String Gas { get; set; }
        public String Reference { get; set; }
        public virtual Sensor Sens1 { get; set; }
        public String Sens1C { get; set; }
        public String Sens1VK { get; set; }
        public String Sens1ZK { get; set; }
        public String Sens1NK { get; set; }
        public virtual Sensor Sens2 { get; set; }
        public String Sens2C { get; set; }
        public String Sens2VK { get; set; }
        public String Sens2ZK { get; set; }
        public String Sens2NK { get; set; }
        public virtual Sensor Sens3 { get; set; }
        public String Sens3C { get; set; }
        public String Sens3VK { get; set; }
        public String Sens3ZK { get; set; }
        public String Sens3NK { get; set; }
        public virtual Sensor Sens4 { get; set; }
        public String Sens4C { get; set; }
        public String Sens4VK { get; set; }
        public String Sens4ZK { get; set; }
        public String Sens4NK { get; set; }
        public virtual Sensor Sens5 { get; set; }
        public String Sens5C { get; set; }
        public String Sens5VK { get; set; }
        public String Sens5ZK { get; set; }
        public String Sens5NK { get; set; }
        public virtual Sensor Sens6 { get; set; }
        public String Sens6C { get; set; }
        public String Sens6VK { get; set; }
        public String Sens6ZK { get; set; }
        public String Sens6NK { get; set; }
        public virtual Sensor Sens7 { get; set; }
        public String Sens7C { get; set; }
        public String Sens7VK { get; set; }
        public String Sens7ZK { get; set; }
        public String Sens7NK { get; set; }
        public virtual Sensor Sens8 { get; set; }
        public String Sens8C { get; set; }
        public String Sens8VK { get; set; }
        public String Sens8ZK { get; set; }
        public String Sens8NK { get; set; }
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
        public Boolean HideAlarms { get; set; }
        public Boolean HideConcentrations { get; set; }
        public bool HideAlarm1 { get; set; }
        public bool HideAlarm2 { get; set; }
        public bool HideAlarm3 { get; set; }
        public bool HideAlarm4 { get; set; }
        public bool HideAlarm5 { get; set; }
        public bool HideAlarm6 { get; set; }
        public bool HideAlarm7 { get; set; }
        public bool HideAlarm8 { get; set; }

        public bool DateAndTime { get; set; }
        public bool FilterExtern { get; set; }
        public bool FilterIntern { get; set; }
        public bool Latch { get; set; }
        public bool Krokodillenclip { get; set; }
        public bool Pomptest { get; set; }
        public bool Pomprevisie { get; set; }
        public bool Lamprevisie { get; set; }
        public bool AutoZero { get; set; }
        public bool Nieuw { get; set; }
        public bool Sinterfilter { get; set; }
        public bool Frontcover { get; set; }
        public bool A1NA { get; set; }
        public bool A1A { get; set; }
        public bool SwitchOffNA { get; set; }
        public bool battery { get; set; }
        public String FW { get; set; }
        public String SensorVervangen { get; set; }
        public String ExtaOpmerkingen { get; set; }
    }
}