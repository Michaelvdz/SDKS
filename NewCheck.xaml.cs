using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Service_Program
{
    /// <summary>
    /// Interaction logic for NewCheck.xaml
    /// </summary>
    public partial class NewCheck : Window
    {
        public String Explanation { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? Next { get; set; }
        public Device Device { get; set; }
        public Client Client { get; set; }
        public String Note { get; set; }
        public String Sens1 { get; set; }
        public String Sens1C { get; set; }
        public String Sens1VK { get; set; }
        public String Sens1ZK { get; set; }
        public String Sens1NK { get; set; }
        public String Sens2 { get; set; }
        public String Sens2C { get; set; }
        public String Sens2VK { get; set; }
        public String Sens2ZK { get; set; }
        public String Sens2NK { get; set; }
        public String Sens3 { get; set; }
        public String Sens3C { get; set; }
        public String Sens3VK { get; set; }
        public String Sens3ZK { get; set; }
        public String Sens3NK { get; set; }
        public String Sens4 { get; set; }
        public String Sens4C { get; set; }
        public String Sens4VK { get; set; }
        public String Sens4ZK { get; set; }
        public String Sens4NK { get; set; }
        public String Sens5 { get; set; }
        public String Sens5C { get; set; }
        public String Sens5VK { get; set; }
        public String Sens5ZK { get; set; }
        public String Sens5NK { get; set; }
        public String Sens6 { get; set; }
        public String Sens6C { get; set; }
        public String Sens6VK { get; set; }
        public String Sens6ZK { get; set; }
        public String Sens6NK { get; set; }
        public String Sens7 { get; set; }
        public String Sens7C { get; set; }
        public String Sens7VK { get; set; }
        public String Sens7ZK { get; set; }
        public String Sens7NK { get; set; }
        public String Sens8 { get; set; }
        public String Sens8C { get; set; }
        public String Sens8VK { get; set; }
        public String Sens8ZK { get; set; }
        public String Sens8NK { get; set; }
        public String Number { get; set; }
        public String Reference { get; set; }
        public String Gas { get; set; }
        public bool Hide { get; set; }
        public bool HideC { get; set; }
        int Knummer;
        String KCNummer;
        public bool Edit { get; set; }
        public int CheckUpId { get; set; }
        public bool multiple { get; set; }
        public int newestId { get; set; }
        public NewCheck()
        {
            InitializeComponent();
            DataContext = this;
        }
        public NewCheck(Device paramDevice)
        {
            InitializeComponent();
            DataContext = this;
            Edit = false;
            multiple = false;
            using (var db = new ServiceProgramContext())
            {
                Device = db.Devices.Find(paramDevice.Id);
                Client = Device.Client;
                if (Device.Sensor1 != null && !Device.HideAlarm1)
                {
                    Sensor temp = Device.Sensor1;
                    Sens1 = temp.Name;
                    Sens1C = temp.Conc.ToString();
                    if (temp.Name == "O2")
                    {
                        Sens1ZK = "20,9";
                    }
                    else
                    {
                        Sens1ZK = "0";
                    }
                    FillComboBox(Sens1Box, Sens1);
                }
                else
                {
                    //Sensor1.Visibility = Visibility.Collapsed;
                    Sens1Name.Visibility = Visibility.Collapsed;
                    Sens1Box.Visibility = Visibility.Collapsed;
                    ESens1C.Visibility = Visibility.Collapsed;
                    ESens1VK.Visibility = Visibility.Collapsed;
                    ESens1ZK.Visibility = Visibility.Collapsed;
                    ESens1NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor2 != null && !Device.HideAlarm2)
                {
                    Sensor temp = Device.Sensor2;
                    Sens2 = temp.Name;
                    Sens2C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens2ZK = "20,9";
                    }
                    else
                    {
                        Sens2ZK = "0";
                    }
                    FillComboBox(Sens2Box, Sens2);
                }
                else
                {
                    //Sensor2.Visibility = Visibility.Collapsed;
                    Sens2Name.Visibility = Visibility.Collapsed;
                    Sens2Box.Visibility = Visibility.Collapsed;
                    ESens2C.Visibility = Visibility.Collapsed;
                    ESens2VK.Visibility = Visibility.Collapsed;
                    ESens2ZK.Visibility = Visibility.Collapsed;
                    ESens2NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor3 != null && !Device.HideAlarm3)
                {
                    Sensor temp = Device.Sensor3;
                    Sens3 = temp.Name;
                    Sens3C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens3ZK = "20,9";
                    }
                    else
                    {
                        Sens3ZK = "0";
                    }
                    FillComboBox(Sens3Box, Sens3);
                }
                else
                {
                    //Sensor3.Visibility = Visibility.Collapsed;
                    Sens3Name.Visibility = Visibility.Collapsed;
                    Sens3Box.Visibility = Visibility.Collapsed;
                    ESens3C.Visibility = Visibility.Collapsed;
                    ESens3VK.Visibility = Visibility.Collapsed;
                    ESens3ZK.Visibility = Visibility.Collapsed;
                    ESens3NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor4 != null && !Device.HideAlarm4)
                {
                    Sensor temp = Device.Sensor4;
                    Sens4 = temp.Name;
                    Sens4C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens4ZK = "20,9";
                    }
                    else
                    {
                        Sens4ZK = "0";
                    }
                    FillComboBox(Sens4Box, Sens4);
                }
                else
                {
                    //Sensor4.Visibility = Visibility.Collapsed;
                    Sens4Name.Visibility = Visibility.Collapsed;
                    Sens4Box.Visibility = Visibility.Collapsed;
                    ESens4C.Visibility = Visibility.Collapsed;
                    ESens4VK.Visibility = Visibility.Collapsed;
                    ESens4ZK.Visibility = Visibility.Collapsed;
                    ESens4NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor5 != null && !Device.HideAlarm5)
                {
                    Sensor temp = Device.Sensor5;
                    Sens5 = temp.Name;
                    Sens5C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens5ZK = "20,9";
                    }
                    else
                    {
                        Sens5ZK = "0";
                    }
                    FillComboBox(Sens5Box, Sens5);
                }
                else
                {
                    //Sensor5.Visibility = Visibility.Collapsed;
                    Sens5Name.Visibility = Visibility.Collapsed;
                    Sens5Box.Visibility = Visibility.Collapsed;
                    ESens5C.Visibility = Visibility.Collapsed;
                    ESens5VK.Visibility = Visibility.Collapsed;
                    ESens5ZK.Visibility = Visibility.Collapsed;
                    ESens5NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor6 != null && !Device.HideAlarm6)
                {
                    Sensor temp = Device.Sensor6;
                    Sens6 = temp.Name;
                    Sens6C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens6ZK = "20,9";
                    }
                    else
                    {
                        Sens6ZK = "0";
                    }
                    FillComboBox(Sens6Box, Sens6);
                }
                else
                {
                    //Sensor6.Visibility = Visibility.Collapsed;
                    Sens6Name.Visibility = Visibility.Collapsed;
                    Sens6Box.Visibility = Visibility.Collapsed;
                    ESens6C.Visibility = Visibility.Collapsed;
                    ESens6VK.Visibility = Visibility.Collapsed;
                    ESens6ZK.Visibility = Visibility.Collapsed;
                    ESens6NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor7 != null && !Device.HideAlarm7)
                {
                    Sensor temp = Device.Sensor7;
                    Sens7 = temp.Name;
                    Sens7C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens7ZK = "20,9";
                    }
                    else
                    {
                        Sens7ZK = "0";
                    }
                    FillComboBox(Sens7Box, Sens7);
                }
                else
                {
                    //Sensor7.Visibility = Visibility.Collapsed;
                    Sens7Name.Visibility = Visibility.Collapsed;
                    Sens7Box.Visibility = Visibility.Collapsed;
                    ESens7C.Visibility = Visibility.Collapsed;
                    ESens7VK.Visibility = Visibility.Collapsed;
                    ESens7ZK.Visibility = Visibility.Collapsed;
                    ESens7NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor8 != null && !Device.HideAlarm8)
                {
                    Sensor temp = Device.Sensor8;
                    Sens8 = temp.Name;
                    Sens8C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens8ZK = "20,9";
                    }
                    else
                    {
                        Sens8ZK = "0";
                    }
                    FillComboBox(Sens8Box, Sens8);
                }
                else
                {
                    //Sensor8.Visibility = Visibility.Collapsed;
                    Sens8Name.Visibility = Visibility.Collapsed;
                    Sens8Box.Visibility = Visibility.Collapsed;
                    ESens8C.Visibility = Visibility.Collapsed;
                    ESens8VK.Visibility = Visibility.Collapsed;
                    ESens8ZK.Visibility = Visibility.Collapsed;
                    ESens8NK.Visibility = Visibility.Collapsed;
                }
                var query = from s in db.Settings
                            where s.Key == "KalibratieNummer"
                            select s.Value;
                var currentNumber = query.First();
                Knummer = Convert.ToInt32(currentNumber);
                DateTime Date = DateTime.Today;
                KCNummer = Date.Year.ToString();
                KCNummer = KCNummer + "_" + Knummer.ToString();
                Number = KCNummer;
                DateTime sixmonths = DateTime.Today.AddMonths(6);
                Next = sixmonths;
                if (Sens1 == null)
                {
                    Hide = true;
                    HideC = true;
                }

            }
        }
        public NewCheck(Device paramDevice, bool multiple)
        {
            InitializeComponent();
            DataContext = this;
            Edit = false;
            this.multiple = multiple;
            using (var db = new ServiceProgramContext())
            {
                Device = db.Devices.Find(paramDevice.Id);
                Client = Device.Client;
                if (Device.Sensor1 != null && !Device.HideAlarm1)
                {
                    Sensor temp = Device.Sensor1;
                    Sens1 = temp.Name;
                    Sens1C = temp.Conc.ToString();
                    if (temp.Name == "O2")
                    {
                        Sens1ZK = "20,9";
                    }
                    else
                    {
                        Sens1ZK = "0";
                    }
                    FillComboBox(Sens1Box, Sens1);
                }
                else
                {
                    //Sensor1.Visibility = Visibility.Collapsed;
                    Sens1Name.Visibility = Visibility.Collapsed;
                    Sens1Box.Visibility = Visibility.Collapsed;
                    ESens1C.Visibility = Visibility.Collapsed;
                    ESens1VK.Visibility = Visibility.Collapsed;
                    ESens1ZK.Visibility = Visibility.Collapsed;
                    ESens1NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor2 != null && !Device.HideAlarm2)
                {
                    Sensor temp = Device.Sensor2;
                    Sens2 = temp.Name;
                    Sens2C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens2ZK = "20,9";
                    }
                    else
                    {
                        Sens2ZK = "0";
                    }
                    FillComboBox(Sens2Box, Sens2);
                }
                else
                {
                    //Sensor2.Visibility = Visibility.Collapsed;
                    Sens2Name.Visibility = Visibility.Collapsed;
                    Sens2Box.Visibility = Visibility.Collapsed;
                    ESens2C.Visibility = Visibility.Collapsed;
                    ESens2VK.Visibility = Visibility.Collapsed;
                    ESens2ZK.Visibility = Visibility.Collapsed;
                    ESens2NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor3 != null && !Device.HideAlarm3)
                {
                    Sensor temp = Device.Sensor3;
                    Sens3 = temp.Name;
                    Sens3C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens3ZK = "20,9";
                    }
                    else
                    {
                        Sens3ZK = "0";
                    }
                    FillComboBox(Sens3Box, Sens3);
                }
                else
                {
                    //Sensor3.Visibility = Visibility.Collapsed;
                    Sens3Name.Visibility = Visibility.Collapsed;
                    Sens3Box.Visibility = Visibility.Collapsed;
                    ESens3C.Visibility = Visibility.Collapsed;
                    ESens3VK.Visibility = Visibility.Collapsed;
                    ESens3ZK.Visibility = Visibility.Collapsed;
                    ESens3NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor4 != null && !Device.HideAlarm4)
                {
                    Sensor temp = Device.Sensor4;
                    Sens4 = temp.Name;
                    Sens4C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens4ZK = "20,9";
                    }
                    else
                    {
                        Sens4ZK = "0";
                    }
                    FillComboBox(Sens4Box, Sens4);
                }
                else
                {
                    //Sensor4.Visibility = Visibility.Collapsed;
                    Sens4Name.Visibility = Visibility.Collapsed;
                    Sens4Box.Visibility = Visibility.Collapsed;
                    ESens4C.Visibility = Visibility.Collapsed;
                    ESens4VK.Visibility = Visibility.Collapsed;
                    ESens4ZK.Visibility = Visibility.Collapsed;
                    ESens4NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor5 != null && !Device.HideAlarm5)
                {
                    Sensor temp = Device.Sensor5;
                    Sens5 = temp.Name;
                    Sens5C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens5ZK = "20,9";
                    }
                    else
                    {
                        Sens5ZK = "0";
                    }
                    FillComboBox(Sens5Box, Sens5);
                }
                else
                {
                    //Sensor5.Visibility = Visibility.Collapsed;
                    Sens5Name.Visibility = Visibility.Collapsed;
                    Sens5Box.Visibility = Visibility.Collapsed;
                    ESens5C.Visibility = Visibility.Collapsed;
                    ESens5VK.Visibility = Visibility.Collapsed;
                    ESens5ZK.Visibility = Visibility.Collapsed;
                    ESens5NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor6 != null && !Device.HideAlarm6)
                {
                    Sensor temp = Device.Sensor6;
                    Sens6 = temp.Name;
                    Sens6C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens6ZK = "20,9";
                    }
                    else
                    {
                        Sens6ZK = "0";
                    }
                    FillComboBox(Sens6Box, Sens6);
                }
                else
                {
                    //Sensor6.Visibility = Visibility.Collapsed;
                    Sens6Name.Visibility = Visibility.Collapsed;
                    Sens6Box.Visibility = Visibility.Collapsed;
                    ESens6C.Visibility = Visibility.Collapsed;
                    ESens6VK.Visibility = Visibility.Collapsed;
                    ESens6ZK.Visibility = Visibility.Collapsed;
                    ESens6NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor7 != null && !Device.HideAlarm7)
                {
                    Sensor temp = Device.Sensor7;
                    Sens7 = temp.Name;
                    Sens7C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens7ZK = "20,9";
                    }
                    else
                    {
                        Sens7ZK = "0";
                    }
                    FillComboBox(Sens7Box, Sens7);
                }
                else
                {
                    //Sensor7.Visibility = Visibility.Collapsed;
                    Sens7Name.Visibility = Visibility.Collapsed;
                    Sens7Box.Visibility = Visibility.Collapsed;
                    ESens7C.Visibility = Visibility.Collapsed;
                    ESens7VK.Visibility = Visibility.Collapsed;
                    ESens7ZK.Visibility = Visibility.Collapsed;
                    ESens7NK.Visibility = Visibility.Collapsed;
                }
                if (Device.Sensor8 != null && !Device.HideAlarm8)
                {
                    Sensor temp = Device.Sensor8;
                    Sens8 = temp.Name;
                    Sens8C = temp.Conc;
                    if (temp.Name == "O2")
                    {
                        Sens8ZK = "20,9";
                    }
                    else
                    {
                        Sens8ZK = "0";
                    }
                    FillComboBox(Sens8Box, Sens8);
                }
                else
                {
                    //Sensor8.Visibility = Visibility.Collapsed;
                    Sens8Name.Visibility = Visibility.Collapsed;
                    Sens8Box.Visibility = Visibility.Collapsed;
                    ESens8C.Visibility = Visibility.Collapsed;
                    ESens8VK.Visibility = Visibility.Collapsed;
                    ESens8ZK.Visibility = Visibility.Collapsed;
                    ESens8NK.Visibility = Visibility.Collapsed;
                }
                var query = from s in db.Settings
                            where s.Key == "KalibratieNummer"
                            select s.Value;
                var currentNumber = query.First();
                Knummer = Convert.ToInt32(currentNumber);
                DateTime Date = DateTime.Today;
                KCNummer = Date.Year.ToString();
                KCNummer = KCNummer + "_" + Knummer.ToString();
                Number = KCNummer;
                DateTime sixmonths = DateTime.Today.AddMonths(6);
                Next = sixmonths;
                if (Sens1 == null)
                {
                    Hide = true;
                    HideC = true;
                }

            }
        }

        private void FillComboBox(ComboBox Box, string sens)
        {
            Console.WriteLine(sens.ToLower());
            if (sens.ToLower() == "CO".ToLower())
            {
                Box.Items.Add("50 ppm CO");
                Box.Items.Add("100 ppm CO");
            }
            if (sens.ToLower() == "H2S".ToLower())
            {
                Box.Items.Add("10 ppm H2S");
                Box.Items.Add("25 ppm H2S");
            }
            if (sens.ToLower() == "LEL IR".ToLower())
            {
                Box.Items.Add("50% LEL (2,2vol% CH4)");
            }
            if (sens.ToLower() == "LEL KAT".ToLower())
            {
                Box.Items.Add("50% LEL (2,2vol% CH4)");
                Box.Items.Add("50% LEL (0,7vol% Pent)");
                Box.Items.Add("50% LEL (1,35vol% C2H4)");
                Box.Items.Add("50% LEL (2 vol% H2)");
                Box.Items.Add("50% LEL (2,5vol% CH4)");
                Box.Items.Add("25% LEL (1,1vol% CH4)");
                Box.Items.Add("50% LEL (0,85vol% Prop)");
                Box.Items.Add("30% LEL (1,5vol% CH4)");
            }
            if (sens.ToLower() == "O2".ToLower())
            {
                Box.Items.Add("18 vol% O2");
                Box.Items.Add("15 vol% O2");
                Box.Items.Add("20,9 vol% O2");
            }
            if (sens.ToLower() == "NH3".ToLower())
            {
                Box.Items.Add("50 ppm NH3");
            }
            if (sens.ToLower() == "Etox".ToLower())
            {
                Box.Items.Add("20 ppm ETOX (50 ppm CO)");
                Box.Items.Add("6 ppm ETOX (15 ppm CO)");
                Box.Items.Add("10 ppm ETOX");
            }
            if (sens.ToLower() == "CL2".ToLower())
            {
                Box.Items.Add("10 ppm Cl2");
            }
            if (sens.ToLower() == "CO2".ToLower())
            {
                Box.Items.Add("5000 ppm CO2 (0,5 vol%)");
                Box.Items.Add("2 vol% CO2 (20.000 ppm)");
            }
            if (sens.ToLower() == "CO2 IR".ToLower())
            {
                Box.Items.Add("5000 ppm CO2 (0,5 vol%)");
                Box.Items.Add("2 vol% CO2 (20.000 ppm)");
            }
            if (sens.ToLower() == "CO2 - IR".ToLower())
            {
                Box.Items.Add("5000 ppm CO2 (0,5 vol%)");
                Box.Items.Add("2 vol% CO2 (20.000 ppm)");
            }
            if (sens.ToLower() == "CO2 EC".ToLower())
            {
                Box.Items.Add("5000 ppm CO2 (0,5 vol%)");
                Box.Items.Add("2 vol% CO2 (20.000 ppm)");
            }
            if (sens.ToLower() == "CO2 - EC".ToLower())
            {
                Box.Items.Add("5000 ppm CO2 (0,5 vol%)");
                Box.Items.Add("2 vol% CO2 (20.000 ppm)");
            }
            if (sens.ToLower() == "H2".ToLower())
            {
                Box.Items.Add("2 vol% H2 (50% LEL)");
                Box.Items.Add("0,1 vol% H2 (1000 ppm)");
            }
            if (sens.ToLower() == "H2 HC".ToLower())
            {
                Box.Items.Add("2 vol% H2 (50% LEL)");
                Box.Items.Add("0,1 vol% H2 (1000 ppm)");
            }
            if (sens.ToLower() == "PID".ToLower())
            {
                Box.Items.Add("100 ppm ISOBUT");
                Box.Items.Add("10 ppm ISOBUT");
                Box.Items.Add("1000 ppm ISOBUT");
            }
            if (sens.ToLower() == "SO2".ToLower())
            {
                Box.Items.Add("10 ppm SO2");
                Box.Items.Add("20 ppm SO2");
            }
            Box.SelectedIndex = 0;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {

            this.Close();
            this.Owner.Activate();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Device _device = new Device();
            /*            for (int i = 0; i < comboOpmerkingen.Items.Count; i++)
                        {
                            CheckBox item = (CheckBox)comboOpmerkingen.Items[i];
                        }*/
            using (var db = new ServiceProgramContext())
            {
                DateTime Date2, Next2;
                if (Date != null)
                {
                    Date2 = (DateTime)Date;
                }
                else
                {
                    Date2 = DateTime.Now;
                }
                if (Next != null)
                {
                    Next2 = (DateTime)Next;
                }
                else
                {
                    Next2 = DateTime.Now;
                }
                int id = Device.Id;
                _device = db.Devices.Find(id);
                if (!Edit)
                {
                    var checkUp = new CheckUp()
                    {
                        Date = Date2,
                        NextDate = Next2,
                        Device = _device,
                        Note = Note,
                        Sens1 = _device.Sensor1,
                        Sens1C = Sens1C,
                        Sens1VK = Sens1VK,
                        Sens1ZK = Sens1ZK,
                        Sens1NK = Sens1NK,
                        Sens2 = _device.Sensor2,
                        Sens2C = Sens2C,
                        Sens2VK = Sens2VK,
                        Sens2ZK = Sens2ZK,
                        Sens2NK = Sens2NK,
                        Sens3 = _device.Sensor3,
                        Sens3C = Sens3C,
                        Sens3VK = Sens3VK,
                        Sens3ZK = Sens3ZK,
                        Sens3NK = Sens3NK,
                        Sens4 = _device.Sensor4,
                        Sens4C = Sens4C,
                        Sens4VK = Sens4VK,
                        Sens4ZK = Sens4ZK,
                        Sens4NK = Sens4NK,
                        Sens5 = _device.Sensor5,
                        Sens5C = Sens5C,
                        Sens5VK = Sens5VK,
                        Sens5ZK = Sens5ZK,
                        Sens5NK = Sens5NK,
                        Sens6 = _device.Sensor6,
                        Sens6C = Sens6C,
                        Sens6VK = Sens6VK,
                        Sens6ZK = Sens6ZK,
                        Sens6NK = Sens6NK,
                        Sens7 = _device.Sensor7,
                        Sens7C = Sens7C,
                        Sens7VK = Sens7VK,
                        Sens7ZK = Sens7ZK,
                        Sens7NK = Sens7NK,
                        Sens8 = _device.Sensor8,
                        Sens8C = Sens8C,
                        Sens8VK = Sens8VK,
                        Sens8ZK = Sens8ZK,
                        Sens8NK = Sens8NK,
                        Alarm1L = _device.Alarm1L,
                        Alarm1H = _device.Alarm1H,
                        Alarm1S = _device.Alarm1S,
                        Alarm1T = _device.Alarm1T,
                        Alarm2L = _device.Alarm2L,
                        Alarm2H = _device.Alarm2H,
                        Alarm2S = _device.Alarm2S,
                        Alarm2T = _device.Alarm2T,
                        Alarm3L = _device.Alarm3L,
                        Alarm3H = _device.Alarm3H,
                        Alarm3S = _device.Alarm3S,
                        Alarm3T = _device.Alarm3T,
                        Alarm4L = _device.Alarm4L,
                        Alarm4H = _device.Alarm4H,
                        Alarm4S = _device.Alarm4S,
                        Alarm4T = _device.Alarm4T,
                        Alarm5L = _device.Alarm5L,
                        Alarm5H = _device.Alarm5H,
                        Alarm5S = _device.Alarm5S,
                        Alarm5T = _device.Alarm5T,
                        Alarm6L = _device.Alarm6L,
                        Alarm6H = _device.Alarm6H,
                        Alarm6S = _device.Alarm6S,
                        Alarm6T = _device.Alarm6T,
                        Alarm7L = _device.Alarm7L,
                        Alarm7H = _device.Alarm7H,
                        Alarm7S = _device.Alarm7S,
                        Alarm7T = _device.Alarm7T,
                        Alarm8L = _device.Alarm8L,
                        Alarm8H = _device.Alarm8H,
                        Alarm8S = _device.Alarm8S,
                        Alarm8T = _device.Alarm8T,
                        HideAlarm1 = _device.HideAlarm1,
                        HideAlarm2 = _device.HideAlarm2,
                        HideAlarm3 = _device.HideAlarm3,
                        HideAlarm4 = _device.HideAlarm4,
                        HideAlarm5 = _device.HideAlarm5,
                        HideAlarm6 = _device.HideAlarm6,
                        HideAlarm7 = _device.HideAlarm7,
                        HideAlarm8 = _device.HideAlarm8,
                        Gas = Gas,
                        Number = Number,
                        Reference = Reference,
                        HideAlarms = Hide,
                        HideConcentrations = HideC
                    };
                    checkUp.Details = AddOpmerkingen(checkUp);
                    db.CheckUps.Add(checkUp);
                    if (_device.LastCheck < Date2)
                    {
                        _device.LastCheck = Date2;
                    }
                    if (_device.NextCheck < Next2)
                    {
                        _device.NextCheck = Next2;
                    }
                    Setting setting = db.Settings.Where(s => s.Key == "KalibratieNummer").First();
                    setting.Value = (Knummer + 1).ToString();
                    db.SaveChanges();
                    CheckUpId = checkUp.Id;
                    Edit = true;
                    ((MainWindow)this.Owner).setCheckId(CheckUpId);
                }
                else
                {
                    var checkUp = db.CheckUps.Find(CheckUpId);
                    checkUp.Date = Date2;
                    checkUp.NextDate = Next2;
                    checkUp.Device = _device;
                    checkUp.Note = Note;
                    checkUp.Sens1 = _device.Sensor1;
                    checkUp.Sens1C = Sens1C;
                    checkUp.Sens1VK = Sens1VK;
                    checkUp.Sens1ZK = Sens1ZK;
                    checkUp.Sens1NK = Sens1NK;
                    checkUp.Sens2 = _device.Sensor2;
                    checkUp.Sens2C = Sens2C;
                    checkUp.Sens2VK = Sens2VK;
                    checkUp.Sens2ZK = Sens2ZK;
                    checkUp.Sens2NK = Sens2NK;
                    checkUp.Sens3 = _device.Sensor3;
                    checkUp.Sens3C = Sens3C;
                    checkUp.Sens3VK = Sens3VK;
                    checkUp.Sens3ZK = Sens3ZK;
                    checkUp.Sens3NK = Sens3NK;
                    checkUp.Sens4 = _device.Sensor4;
                    checkUp.Sens4C = Sens4C;
                    checkUp.Sens4VK = Sens4VK;
                    checkUp.Sens4ZK = Sens4ZK;
                    checkUp.Sens4NK = Sens4NK;
                    checkUp.Sens5 = _device.Sensor5;
                    checkUp.Sens5C = Sens5C;
                    checkUp.Sens5VK = Sens5VK;
                    checkUp.Sens5ZK = Sens5ZK;
                    checkUp.Sens5NK = Sens5NK;
                    checkUp.Sens6 = _device.Sensor6;
                    checkUp.Sens6C = Sens6C;
                    checkUp.Sens6VK = Sens6VK;
                    checkUp.Sens6ZK = Sens6ZK;
                    checkUp.Sens6NK = Sens6NK;
                    checkUp.Sens7 = _device.Sensor7;
                    checkUp.Sens7C = Sens7C;
                    checkUp.Sens7VK = Sens7VK;
                    checkUp.Sens7ZK = Sens7ZK;
                    checkUp.Sens7NK = Sens7NK;
                    checkUp.Sens8 = _device.Sensor8;
                    checkUp.Sens8C = Sens8C;
                    checkUp.Sens8VK = Sens8VK;
                    checkUp.Sens8ZK = Sens8ZK;
                    checkUp.Sens8NK = Sens8NK;
                    checkUp.Alarm1L = _device.Alarm1L;
                    checkUp.Alarm1H = _device.Alarm1H;
                    checkUp.Alarm1S = _device.Alarm1S;
                    checkUp.Alarm1T = _device.Alarm1T;
                    checkUp.Alarm2L = _device.Alarm2L;
                    checkUp.Alarm2H = _device.Alarm2H;
                    checkUp.Alarm2S = _device.Alarm2S;
                    checkUp.Alarm2T = _device.Alarm2T;
                    checkUp.Alarm3L = _device.Alarm3L;
                    checkUp.Alarm3H = _device.Alarm3H;
                    checkUp.Alarm3S = _device.Alarm3S;
                    checkUp.Alarm3T = _device.Alarm3T;
                    checkUp.Alarm4L = _device.Alarm4L;
                    checkUp.Alarm4H = _device.Alarm4H;
                    checkUp.Alarm4S = _device.Alarm4S;
                    checkUp.Alarm4T = _device.Alarm4T;
                    checkUp.Alarm5L = _device.Alarm5L;
                    checkUp.Alarm5H = _device.Alarm5H;
                    checkUp.Alarm5S = _device.Alarm5S;
                    checkUp.Alarm5T = _device.Alarm5T;
                    checkUp.Alarm6L = _device.Alarm6L;
                    checkUp.Alarm6H = _device.Alarm6H;
                    checkUp.Alarm6S = _device.Alarm6S;
                    checkUp.Alarm6T = _device.Alarm6T;
                    checkUp.Alarm7L = _device.Alarm7L;
                    checkUp.Alarm7H = _device.Alarm7H;
                    checkUp.Alarm7S = _device.Alarm7S;
                    checkUp.Alarm7T = _device.Alarm7T;
                    checkUp.Alarm8L = _device.Alarm8L;
                    checkUp.Alarm8H = _device.Alarm8H;
                    checkUp.Alarm8S = _device.Alarm8S;
                    checkUp.Alarm8T = _device.Alarm8T;
                    checkUp.HideAlarm1 = _device.HideAlarm1;
                    checkUp.HideAlarm2 = _device.HideAlarm2;
                    checkUp.HideAlarm3 = _device.HideAlarm3;
                    checkUp.HideAlarm4 = _device.HideAlarm4;
                    checkUp.HideAlarm5 = _device.HideAlarm5;
                    checkUp.HideAlarm6 = _device.HideAlarm6;
                    checkUp.HideAlarm7 = _device.HideAlarm7;
                    checkUp.HideAlarm8 = _device.HideAlarm8;
                    checkUp.Gas = Gas;
                    checkUp.Number = Number;
                    checkUp.Reference = Reference;
                    checkUp.HideAlarms = Hide;
                    checkUp.HideConcentrations = HideC;
                    checkUp.Details = AddOpmerkingen(checkUp);

                    if (_device.LastCheck < Date2)
                    {
                        _device.LastCheck = Date2;
                    }
                    if (_device.NextCheck < Next2)
                    {
                        _device.NextCheck = Next2;
                    }
                    db.SaveChanges();
                }
                
            }
            CloseButton.Visibility = Visibility.Visible;
            //this.Close();
            if (!this.multiple)
            {
                ((MainWindow)this.Owner).UpdateClientsGrid();
                ((MainWindow)this.Owner).UpdateDevicesGrid(Client, _device.Id);
            }

        }
        private void Button_ClickAndOpen(object sender, RoutedEventArgs e)
        {

            Device _device = new Device();
            /*            for (int i = 0; i < comboOpmerkingen.Items.Count; i++)
                        {
                            CheckBox item = (CheckBox)comboOpmerkingen.Items[i];
                        }*/
            using (var db = new ServiceProgramContext())
            {
                DateTime Date2, Next2;
                if (Date != null)
                {
                    Date2 = (DateTime)Date;
                }
                else
                {
                    Date2 = DateTime.Now;
                }
                if (Next != null)
                {
                    Next2 = (DateTime)Next;
                }
                else
                {
                    Next2 = DateTime.Now;
                }
                int id = Device.Id;
                _device = db.Devices.Find(id);
                if (!Edit)
                {
                    var checkUp = new CheckUp()
                    {
                        Date = Date2,
                        NextDate = Next2,
                        Device = _device,
                        Note = Note,
                        Sens1 = _device.Sensor1,
                        Sens1C = Sens1C,
                        Sens1VK = Sens1VK,
                        Sens1ZK = Sens1ZK,
                        Sens1NK = Sens1NK,
                        Sens2 = _device.Sensor2,
                        Sens2C = Sens2C,
                        Sens2VK = Sens2VK,
                        Sens2ZK = Sens2ZK,
                        Sens2NK = Sens2NK,
                        Sens3 = _device.Sensor3,
                        Sens3C = Sens3C,
                        Sens3VK = Sens3VK,
                        Sens3ZK = Sens3ZK,
                        Sens3NK = Sens3NK,
                        Sens4 = _device.Sensor4,
                        Sens4C = Sens4C,
                        Sens4VK = Sens4VK,
                        Sens4ZK = Sens4ZK,
                        Sens4NK = Sens4NK,
                        Sens5 = _device.Sensor5,
                        Sens5C = Sens5C,
                        Sens5VK = Sens5VK,
                        Sens5ZK = Sens5ZK,
                        Sens5NK = Sens5NK,
                        Sens6 = _device.Sensor6,
                        Sens6C = Sens6C,
                        Sens6VK = Sens6VK,
                        Sens6ZK = Sens6ZK,
                        Sens6NK = Sens6NK,
                        Sens7 = _device.Sensor7,
                        Sens7C = Sens7C,
                        Sens7VK = Sens7VK,
                        Sens7ZK = Sens7ZK,
                        Sens7NK = Sens7NK,
                        Sens8 = _device.Sensor8,
                        Sens8C = Sens8C,
                        Sens8VK = Sens8VK,
                        Sens8ZK = Sens8ZK,
                        Sens8NK = Sens8NK,
                        Alarm1L = _device.Alarm1L,
                        Alarm1H = _device.Alarm1H,
                        Alarm1S = _device.Alarm1S,
                        Alarm1T = _device.Alarm1T,
                        Alarm2L = _device.Alarm2L,
                        Alarm2H = _device.Alarm2H,
                        Alarm2S = _device.Alarm2S,
                        Alarm2T = _device.Alarm2T,
                        Alarm3L = _device.Alarm3L,
                        Alarm3H = _device.Alarm3H,
                        Alarm3S = _device.Alarm3S,
                        Alarm3T = _device.Alarm3T,
                        Alarm4L = _device.Alarm4L,
                        Alarm4H = _device.Alarm4H,
                        Alarm4S = _device.Alarm4S,
                        Alarm4T = _device.Alarm4T,
                        Alarm5L = _device.Alarm5L,
                        Alarm5H = _device.Alarm5H,
                        Alarm5S = _device.Alarm5S,
                        Alarm5T = _device.Alarm5T,
                        Alarm6L = _device.Alarm6L,
                        Alarm6H = _device.Alarm6H,
                        Alarm6S = _device.Alarm6S,
                        Alarm6T = _device.Alarm6T,
                        Alarm7L = _device.Alarm7L,
                        Alarm7H = _device.Alarm7H,
                        Alarm7S = _device.Alarm7S,
                        Alarm7T = _device.Alarm7T,
                        Alarm8L = _device.Alarm8L,
                        Alarm8H = _device.Alarm8H,
                        Alarm8S = _device.Alarm8S,
                        Alarm8T = _device.Alarm8T,
                        HideAlarm1 = _device.HideAlarm1,
                        HideAlarm2 = _device.HideAlarm2,
                        HideAlarm3 = _device.HideAlarm3,
                        HideAlarm4 = _device.HideAlarm4,
                        HideAlarm5 = _device.HideAlarm5,
                        HideAlarm6 = _device.HideAlarm6,
                        HideAlarm7 = _device.HideAlarm7,
                        HideAlarm8 = _device.HideAlarm8,
                        Gas = Gas,
                        Number = Number,
                        Reference = Reference,
                        HideAlarms = Hide,
                        HideConcentrations = HideC
                    };
                    checkUp.Details = AddOpmerkingen(checkUp);
                    db.CheckUps.Add(checkUp);
                    if (_device.LastCheck < Date2)
                    {
                        _device.LastCheck = Date2;
                    }
                    if (_device.NextCheck < Next2)
                    {
                        _device.NextCheck = Next2;
                    }
                    Setting setting = db.Settings.Where(s => s.Key == "KalibratieNummer").First();
                    setting.Value = (Knummer + 1).ToString();
                    db.SaveChanges();
                    CheckUpId = checkUp.Id;
                    Edit = true;
                    ((MainWindow)this.Owner).setCheckId(CheckUpId);
                    Certificate cert = new Certificate(checkUp);
                }
                else
                {
                    var checkUp = db.CheckUps.Find(CheckUpId);
                    checkUp.Date = Date2;
                    checkUp.NextDate = Next2;
                    checkUp.Device = _device;
                    checkUp.Note = Note;
                    checkUp.Sens1 = _device.Sensor1;
                    checkUp.Sens1C = Sens1C;
                    checkUp.Sens1VK = Sens1VK;
                    checkUp.Sens1ZK = Sens1ZK;
                    checkUp.Sens1NK = Sens1NK;
                    checkUp.Sens2 = _device.Sensor2;
                    checkUp.Sens2C = Sens2C;
                    checkUp.Sens2VK = Sens2VK;
                    checkUp.Sens2ZK = Sens2ZK;
                    checkUp.Sens2NK = Sens2NK;
                    checkUp.Sens3 = _device.Sensor3;
                    checkUp.Sens3C = Sens3C;
                    checkUp.Sens3VK = Sens3VK;
                    checkUp.Sens3ZK = Sens3ZK;
                    checkUp.Sens3NK = Sens3NK;
                    checkUp.Sens4 = _device.Sensor4;
                    checkUp.Sens4C = Sens4C;
                    checkUp.Sens4VK = Sens4VK;
                    checkUp.Sens4ZK = Sens4ZK;
                    checkUp.Sens4NK = Sens4NK;
                    checkUp.Sens5 = _device.Sensor5;
                    checkUp.Sens5C = Sens5C;
                    checkUp.Sens5VK = Sens5VK;
                    checkUp.Sens5ZK = Sens5ZK;
                    checkUp.Sens5NK = Sens5NK;
                    checkUp.Sens6 = _device.Sensor6;
                    checkUp.Sens6C = Sens6C;
                    checkUp.Sens6VK = Sens6VK;
                    checkUp.Sens6ZK = Sens6ZK;
                    checkUp.Sens6NK = Sens6NK;
                    checkUp.Sens7 = _device.Sensor7;
                    checkUp.Sens7C = Sens7C;
                    checkUp.Sens7VK = Sens7VK;
                    checkUp.Sens7ZK = Sens7ZK;
                    checkUp.Sens7NK = Sens7NK;
                    checkUp.Sens8 = _device.Sensor8;
                    checkUp.Sens8C = Sens8C;
                    checkUp.Sens8VK = Sens8VK;
                    checkUp.Sens8ZK = Sens8ZK;
                    checkUp.Sens8NK = Sens8NK;
                    checkUp.Alarm1L = _device.Alarm1L;
                    checkUp.Alarm1H = _device.Alarm1H;
                    checkUp.Alarm1S = _device.Alarm1S;
                    checkUp.Alarm1T = _device.Alarm1T;
                    checkUp.Alarm2L = _device.Alarm2L;
                    checkUp.Alarm2H = _device.Alarm2H;
                    checkUp.Alarm2S = _device.Alarm2S;
                    checkUp.Alarm2T = _device.Alarm2T;
                    checkUp.Alarm3L = _device.Alarm3L;
                    checkUp.Alarm3H = _device.Alarm3H;
                    checkUp.Alarm3S = _device.Alarm3S;
                    checkUp.Alarm3T = _device.Alarm3T;
                    checkUp.Alarm4L = _device.Alarm4L;
                    checkUp.Alarm4H = _device.Alarm4H;
                    checkUp.Alarm4S = _device.Alarm4S;
                    checkUp.Alarm4T = _device.Alarm4T;
                    checkUp.Alarm5L = _device.Alarm5L;
                    checkUp.Alarm5H = _device.Alarm5H;
                    checkUp.Alarm5S = _device.Alarm5S;
                    checkUp.Alarm5T = _device.Alarm5T;
                    checkUp.Alarm6L = _device.Alarm6L;
                    checkUp.Alarm6H = _device.Alarm6H;
                    checkUp.Alarm6S = _device.Alarm6S;
                    checkUp.Alarm6T = _device.Alarm6T;
                    checkUp.Alarm7L = _device.Alarm7L;
                    checkUp.Alarm7H = _device.Alarm7H;
                    checkUp.Alarm7S = _device.Alarm7S;
                    checkUp.Alarm7T = _device.Alarm7T;
                    checkUp.Alarm8L = _device.Alarm8L;
                    checkUp.Alarm8H = _device.Alarm8H;
                    checkUp.Alarm8S = _device.Alarm8S;
                    checkUp.Alarm8T = _device.Alarm8T;
                    checkUp.HideAlarm1 = _device.HideAlarm1;
                    checkUp.HideAlarm2 = _device.HideAlarm2;
                    checkUp.HideAlarm3 = _device.HideAlarm3;
                    checkUp.HideAlarm4 = _device.HideAlarm4;
                    checkUp.HideAlarm5 = _device.HideAlarm5;
                    checkUp.HideAlarm6 = _device.HideAlarm6;
                    checkUp.HideAlarm7 = _device.HideAlarm7;
                    checkUp.HideAlarm8 = _device.HideAlarm8;
                    checkUp.Gas = Gas;
                    checkUp.Number = Number;
                    checkUp.Reference = Reference;
                    checkUp.HideAlarms = Hide;
                    checkUp.HideConcentrations = HideC;
                    checkUp.Details = AddOpmerkingen(checkUp);

                    if (_device.LastCheck < Date2)
                    {
                        _device.LastCheck = Date2;
                    }
                    if (_device.NextCheck < Next2)
                    {
                        _device.NextCheck = Next2;
                    }
                    db.SaveChanges();
                    Certificate cert = new Certificate(checkUp);
                }

            }
            CloseButton.Visibility = Visibility.Visible;
            //this.Close();
            if (!this.multiple)
            {
                ((MainWindow)this.Owner).UpdateClientsGrid();
                ((MainWindow)this.Owner).UpdateDevicesGrid(Client, _device.Id);
            }

        }
        private string AddOpmerkingen(CheckUp check)
        {
            String Opmerking = "";
            bool secondline = false;
            bool thirdline = false;
            if (Prop12.IsChecked == true)
            {
                check.Nieuw = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop12.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop12.Content.ToString();
                }
            }
            else
            {
                check.Nieuw = false;
            }
            if (Prop1.IsChecked == true)
            {
                check.DateAndTime = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop1.Content.ToString();
                }
                else
                {
                    if (Opmerking.Length >= 90)
                    {
                        Opmerking = Opmerking + "\r";
                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop1.Content.ToString();
                }
            }
            else
            {
                check.DateAndTime = false;
            }
            if (Prop2.IsChecked == true)
            {
                check.FilterExtern = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop2.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop2.Content.ToString();
                }
            }
            else
            {
                check.FilterExtern = false;
            }
            if (Prop3.IsChecked == true)
            {
                check.FilterIntern = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop3.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop3.Content.ToString();
                }
            }
            else
            {
                check.FilterIntern = false;
            }
            if (Prop4.IsChecked == true)
            {
                check.Latch = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop4.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop4.Content.ToString();
                }
            }
            else
            {
                check.Latch = false;
            }
            if (Prop5.IsChecked == true)
            {
                check.Krokodillenclip = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop5.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop5.Content.ToString();
                }
            }
            else
            {
                check.Krokodillenclip = false;
            }
            if (Prop6.IsChecked == true)
            {
                check.Pomptest = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop6.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop6.Content.ToString();
                }
            }
            else
            {
                check.Pomptest = false;
            }
            check.Pomprevisie = false;
            check.Lamprevisie = false;
            if (Prop9.IsChecked == true)
            {
                check.AutoZero = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop9.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop9.Content.ToString();
                }
            }
            else
            {
                check.AutoZero = false;
            }
            if (Prop13.IsChecked == true)
            {
                check.Sinterfilter = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop13.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop13.Content.ToString();
                }
            }
            else
            {
                check.Sinterfilter = false;
            }
            if (Prop14.IsChecked == true)
            {
                check.Frontcover = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop14.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop14.Content.ToString();
                }
            }
            else
            {
                check.Frontcover = false;
            }
            if (Prop15.IsChecked == true)
            {
                check.A1NA = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop15.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop15.Content.ToString();
                }
            }
            else
            {
                check.A1NA = false;
            }
            if (Prop16.IsChecked == true)
            {
                check.A1A = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop16.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop16.Content.ToString();
                }
            }
            else
            {
                check.A1A = false;
            }
            if (Prop17.IsChecked == true)
            {
                check.SwitchOffNA = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop17.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop17.Content.ToString();
                }
            }
            else
            {
                check.SwitchOffNA = false;
            }
            if (Prop19.IsChecked == true)
            {
                check.battery = true;
                if (Opmerking == "")
                {
                    Opmerking = Prop19.Content.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop19.Content.ToString();
                }
            }
            else
            {
                check.battery = false;
            }
            if (Prop10.IsChecked == true)
            {
                check.SensorVervangen = "Sensor vervangen: " + Prop10Input.Text.ToString();
                if (Opmerking == "")
                {
                    Opmerking = "Sensor vervangen: " + Prop10Input.Text.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + "Sensor vervangen: " + Prop10Input.Text.ToString();
                }
            }
            else
            {
                check.SensorVervangen = "";
            }
            if (Prop11.IsChecked == true)
            {
                check.ExtaOpmerkingen = Prop11Input.Text.ToString();
                if (Opmerking == "")
                {
                    Opmerking = Prop11Input.Text.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + Prop11Input.Text.ToString();
                }
            }
            else
            {
                check.ExtaOpmerkingen = "";
            }
            if (Prop18.IsChecked == true)
            {
                check.FW = Prop18Input.Text.ToString();
                if (Opmerking == "")
                {
                    Opmerking = Prop18Input.Text.ToString();
                }
                else
                {
                    if ((Opmerking.Length >= 90) && !(secondline))
                    {
                        Opmerking = Opmerking + "\r";
                        secondline = true;

                    }
                    else if ((Opmerking.Length >= 180) && !(thirdline))
                    {
                        Opmerking = Opmerking + "\r";
                        thirdline = true;
                    }
                    Opmerking = Opmerking + " / " + "FW: " + Prop18Input.Text.ToString();
                }
            }
            else
            {
                check.FW = "";
            }
            return Opmerking;
        }

        private void Sens1Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens1Box.SelectedItem;

            Sens1C = selected;
            ESens1C.Text = selected;
        }
        private void Sens2Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens2Box.SelectedItem;

            Sens2C = selected;
            ESens2C.Text = selected;
        }
        private void Sens3Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens3Box.SelectedItem;

            Sens3C = selected;
            ESens3C.Text = selected;
        }
        private void Sens4Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens4Box.SelectedItem;

            Sens4C = selected;
            ESens4C.Text = selected;
        }
        private void Sens5Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens5Box.SelectedItem;
            
            Sens5C = selected;
            ESens5C.Text = selected;
        }
        private void Sens6Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens6Box.SelectedItem;

            Sens6C = selected;
            ESens6C.Text = selected;
        }
        private void Sens7Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens7Box.SelectedItem;

            Sens7C = selected;
            ESens7C.Text = selected;
        }
        private void Sens8Box_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)Sens8Box.SelectedItem;

            Sens8C = selected;
            ESens8C.Text = selected;
        }

    }
}
