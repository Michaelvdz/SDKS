using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Program
{
    public class Client
    {
        public int Id { get; set; }
        public String Company { get; set; }
        public String Contact { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String Phone { get; set; }
        public String MobilePhone { get; set; }
        public String Email { get; set; }
        public String Note { get; set; }
        public bool GeenOproep { get; set; }
        public DateTime? KalibratieMaand { get; set; }
        public virtual List<Device> Devices { get; set; }
    }
}
