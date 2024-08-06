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
    /// Interaction logic for UpdateDevice.xaml
    /// </summary>
    public partial class UpdateDevice : Window
    {
        public String DeviceName { get; set; }
        public String SerialNumber { get; set; }
        public DateTime? Bought { get; set; }
        public DateTime? LastCheck { get; set; }
        public DateTime? NextCheck { get; set; }
        public List<ComboData> List { get; set; }
        public String Price { get; set; }
        public String Note { get; set; }
        public String Opmerking { get; set; }
        public bool Gekocht { get; set; }
        public bool NGekocht { get; set; }
        public Boolean Broken { get; set; }
        public Boolean Lost { get; set; }
        public Boolean GeenOp { get; set; }
        public String Reference { get; set; }
        Device device;
        Sensor SelectedSensor;
        public int SensorCount { get; set; }
        public String Alarm1 { get; set; }
        public String Alarm1L { get; set; }
        public String Alarm1H { get; set; }
        public String Alarm1S { get; set; }
        public String Alarm1T { get; set; }
        public String Alarm2 { get; set; }
        public String Alarm2L { get; set; }
        public String Alarm2H { get; set; }
        public String Alarm2S { get; set; }
        public String Alarm2T { get; set; }
        public String Alarm3 { get; set; }
        public String Alarm3L { get; set; }
        public String Alarm3H { get; set; }
        public String Alarm3S { get; set; }
        public String Alarm3T { get; set; }
        public String Alarm4 { get; set; }
        public String Alarm4L { get; set; }
        public String Alarm4H { get; set; }
        public String Alarm4S { get; set; }
        public String Alarm4T { get; set; }
        public String Alarm5 { get; set; }
        public String Alarm5L { get; set; }
        public String Alarm5H { get; set; }
        public String Alarm5S { get; set; }
        public String Alarm5T { get; set; }
        public String Alarm6 { get; set; }
        public String Alarm6L { get; set; }
        public String Alarm6H { get; set; }
        public String Alarm6S { get; set; }
        public String Alarm6T { get; set; }
        public String Alarm7 { get; set; }
        public String Alarm7L { get; set; }
        public String Alarm7H { get; set; }
        public String Alarm7S { get; set; }
        public String Alarm7T { get; set; }
        public String Alarm8 { get; set; }
        public String Alarm8L { get; set; }
        public String Alarm8H { get; set; }
        public String Alarm8S { get; set; }
        public String Alarm8T { get; set; }
        public String Alarm1Name { get; set; }
        public String Alarm2Name { get; set; }
        public String Alarm3Name { get; set; }
        public String Alarm4Name { get; set; }
        public String Alarm5Name { get; set; }
        public String Alarm6Name { get; set; }
        public String Alarm7Name { get; set; }
        public String Alarm8Name { get; set; }
        public DateTime? O2Sensor { get; set; }

        public bool Sensor1Value { get; set; }
        public bool Sensor2Value { get; set; }
        public bool Sensor3Value { get; set; }
        public bool Sensor4Value { get; set; }
        public bool Sensor5Value { get; set; }
        public bool Sensor6Value { get; set; }
        public bool Sensor7Value { get; set; }
        public bool Sensor8Value { get; set; }
        public bool sensedit { get; set; }

        public bool Aanwezig { get; set; }
        public List<Sensor> sensors;
        public int rowId { get; set; }

        public UpdateDevice(Device selectedDevice, int rowNr)
        {
            InitializeComponent();
            DataContext = this;
            rowId = rowNr;
            device = selectedDevice;
            DeviceName = selectedDevice.Name;
            SerialNumber = selectedDevice.SerialNumber;
            Price = selectedDevice.Price;
            Bought = selectedDevice.Bought;
            LastCheck = selectedDevice.LastCheck;
            NextCheck = selectedDevice.NextCheck;
            O2Sensor = selectedDevice.O2Sensor;
            Note = selectedDevice.Note;
            Opmerking = selectedDevice.Opmerking;
            int id = selectedDevice.Client.Id;
            bool service = selectedDevice.BoughtByUs;
            sensedit = false;

            if (service)
            {
                Gekocht = true;
                VGekocht.Visibility = Visibility.Visible;
                VNGekocht.Visibility = Visibility.Collapsed;
                gekochtWrap.Visibility = Visibility.Visible;
            }
            else
            {
                Gekocht = false;
                NGekocht = true;
                VGekocht.Visibility = Visibility.Collapsed;
                gekochtWrap.Visibility = Visibility.Collapsed;
                VNGekocht.Visibility = Visibility.Visible;
            }
            if(O2Sensor != DateTime.MinValue)
            {
                o2sensorWrap.Visibility = Visibility.Visible;
            }
            bool kapot = selectedDevice.Broken;
            Broken = kapot;
            bool nos = selectedDevice.NoS;
            GeenOp = nos;
            bool present = selectedDevice.Aanwezig;
            Aanwezig = present;

            Sensor1Value = selectedDevice.HideAlarm1;
            Sensor2Value = selectedDevice.HideAlarm2;
            Sensor3Value = selectedDevice.HideAlarm3;
            Sensor4Value = selectedDevice.HideAlarm4;
            Sensor5Value = selectedDevice.HideAlarm5;
            Sensor6Value = selectedDevice.HideAlarm6;
            Sensor7Value = selectedDevice.HideAlarm7;
            Sensor8Value = selectedDevice.HideAlarm8;


            Reference = selectedDevice.Reference;
            /*Alarm1L = selectedDevice.Alarm1L;
            Alarm1H = selectedDevice.Alarm1H;
            Alarm1S = selectedDevice.Alarm1S;
            Alarm1T = selectedDevice.Alarm1T;
            Alarm2L = selectedDevice.Alarm2L;
            Alarm2H = selectedDevice.Alarm2H;
            Alarm2S = selectedDevice.Alarm2S;
            Alarm2T = selectedDevice.Alarm2T;
            Alarm3L = selectedDevice.Alarm3L;
            Alarm3H = selectedDevice.Alarm3H;
            Alarm3S = selectedDevice.Alarm3S;
            Alarm3T = selectedDevice.Alarm3T;
            Alarm4L = selectedDevice.Alarm4L;
            Alarm4H = selectedDevice.Alarm4H;
            Alarm4S = selectedDevice.Alarm4S;
            Alarm4T = selectedDevice.Alarm4T;
            Alarm5L = selectedDevice.Alarm5L;
            Alarm5H = selectedDevice.Alarm5H;
            Alarm5S = selectedDevice.Alarm5S;
            Alarm5T = selectedDevice.Alarm5T;
            Alarm6L = selectedDevice.Alarm6L;
            Alarm6H = selectedDevice.Alarm6H;
            Alarm6S = selectedDevice.Alarm6S;
            Alarm6T = selectedDevice.Alarm6T;
            Alarm7L = selectedDevice.Alarm7L;
            Alarm7H = selectedDevice.Alarm7H;
            Alarm7S = selectedDevice.Alarm7S;
            Alarm7T = selectedDevice.Alarm7T;
            Alarm8L = selectedDevice.Alarm8L;
            Alarm8H = selectedDevice.Alarm8H;
            Alarm8S = selectedDevice.Alarm8S;
            Alarm8T = selectedDevice.Alarm8T;*/
            Lost = selectedDevice.Lost;
            using (var db = new ServiceProgramContext())
            {
                List<Client> clients = db.Clients.ToList();
                clients.Sort((x, y) => x.Company.CompareTo(y.Company));
                List = new List<ComboData>();
                ComboData sel = new ComboData();
                foreach (var client in clients)
                {
                    ComboData temp = new ComboData { Id = client.Id, Value = client.Company };
                    List.Add(temp);
                    if(temp.Id == id)
                    {
                        sel = temp;
                    }
                }
                companies.ItemsSource = List;
                companies.DisplayMemberPath = "Value";
                companies.SelectedValuePath = "Id";
                companies.SelectedValue = id.ToString();

                var query = from s in db.Settings
                            where s.Key == "Verhuur"
                            select s.Value;
                var currentNumber = query.First();
                int verhuurId = Convert.ToInt32(currentNumber);

                if(id == verhuurId)
                {
                    aanwezig.Visibility = Visibility.Visible;
                }
                
                SensorCount = 0;
                Device Device = db.Devices.Find(device.Id);
                //sensors = new List<Sensor>();
                sensors = new List<Sensor>();
                if (Device.Sensor1 != null)
                {
                    sensors.Add(Device.Sensor1);
                    Alarm1L = Device.Sensor1.Laag;
                    Alarm1H = Device.Sensor1.Hoog;
                    Alarm1S = Device.Sensor1.Stel;
                    Alarm1T = Device.Sensor1.Twa;
                }
                if (Device.Sensor2 != null)
                {
                    sensors.Add(Device.Sensor2);
                    Alarm2L = Device.Sensor2.Laag;
                    Alarm2H = Device.Sensor2.Hoog;
                    Alarm2S = Device.Sensor2.Stel;
                    Alarm2T = Device.Sensor2.Twa;
                }
                if (Device.Sensor3 != null)
                {
                    sensors.Add(Device.Sensor3);
                    Alarm3L = Device.Sensor3.Laag;
                    Alarm3H = Device.Sensor3.Hoog;
                    Alarm3S = Device.Sensor3.Stel;
                    Alarm3T = Device.Sensor3.Twa;
                }
                if (Device.Sensor4 != null)
                {
                    sensors.Add(Device.Sensor4);
                    Alarm4L = Device.Sensor4.Laag;
                    Alarm4H = Device.Sensor4.Hoog;
                    Alarm4S = Device.Sensor4.Stel;
                    Alarm4T = Device.Sensor4.Twa;
                }
                if (Device.Sensor5 != null)
                {
                    sensors.Add(Device.Sensor5);
                    Alarm5L = Device.Sensor5.Laag;
                    Alarm5H = Device.Sensor5.Hoog;
                    Alarm5S = Device.Sensor5.Stel;
                    Alarm5T = Device.Sensor5.Twa;
                }
                if (Device.Sensor6 != null)
                {
                    sensors.Add(Device.Sensor6);
                    Alarm6L = Device.Sensor6.Laag;
                    Alarm6H = Device.Sensor6.Hoog;
                    Alarm6S = Device.Sensor6.Stel;
                    Alarm6T = Device.Sensor6.Twa;
                }
                if (Device.Sensor7 != null)
                {
                    sensors.Add(Device.Sensor7);
                    Alarm7L = Device.Sensor7.Laag;
                    Alarm7H = Device.Sensor7.Hoog;
                    Alarm7S = Device.Sensor7.Stel;
                    Alarm7T = Device.Sensor7.Twa;
                }
                if (Device.Sensor8 != null)
                {
                    sensors.Add(Device.Sensor8);
                    Alarm8L = Device.Sensor8.Laag;
                    Alarm8H = Device.Sensor8.Hoog;
                    Alarm8S = Device.Sensor8.Stel;
                    Alarm8T = Device.Sensor8.Twa;
                }
            }
            if (!sensedit)
            {
                Alarm1L = selectedDevice.Alarm1L;
                Alarm1H = selectedDevice.Alarm1H;
                Alarm1S = selectedDevice.Alarm1S;
                Alarm1T = selectedDevice.Alarm1T;
                Alarm2L = selectedDevice.Alarm2L;
                Alarm2H = selectedDevice.Alarm2H;
                Alarm2S = selectedDevice.Alarm2S;
                Alarm2T = selectedDevice.Alarm2T;
                Alarm3L = selectedDevice.Alarm3L;
                Alarm3H = selectedDevice.Alarm3H;
                Alarm3S = selectedDevice.Alarm3S;
                Alarm3T = selectedDevice.Alarm3T;
                Alarm4L = selectedDevice.Alarm4L;
                Alarm4H = selectedDevice.Alarm4H;
                Alarm4S = selectedDevice.Alarm4S;
                Alarm4T = selectedDevice.Alarm4T;
                Alarm5L = selectedDevice.Alarm5L;
                Alarm5H = selectedDevice.Alarm5H;
                Alarm5S = selectedDevice.Alarm5S;
                Alarm5T = selectedDevice.Alarm5T;
                Alarm6L = selectedDevice.Alarm6L;
                Alarm6H = selectedDevice.Alarm6H;
                Alarm6S = selectedDevice.Alarm6S;
                Alarm6T = selectedDevice.Alarm6T;
                Alarm7L = selectedDevice.Alarm7L;
                Alarm7H = selectedDevice.Alarm7H;
                Alarm7S = selectedDevice.Alarm7S;
                Alarm7T = selectedDevice.Alarm7T;
                Alarm8L = selectedDevice.Alarm8L;
                Alarm8H = selectedDevice.Alarm8H;
                Alarm8S = selectedDevice.Alarm8S;
                Alarm8T = selectedDevice.Alarm8T;
            }
            UpdateSensorGrid();
            if(SensorCount > 0)
            {
                Alarm1Name = sensors.ElementAt(0).Name;
                Alarm1Group.Visibility = Visibility.Visible;
                AlarmTitle.Visibility = Visibility.Visible;
                Sensor1V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 1)
            {
                Alarm2Name = sensors.ElementAt(1).Name;
                Alarm2Group.Visibility = Visibility.Visible;
                Sensor2V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 2)
            {
                Alarm3Name = sensors.ElementAt(2).Name;
                Alarm3Group.Visibility = Visibility.Visible;
                Sensor3V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 3)
            {
                Alarm4Name = sensors.ElementAt(3).Name;
                Alarm4Group.Visibility = Visibility.Visible;
                Sensor4V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 4)
            {
                Alarm5Name = sensors.ElementAt(4).Name;
                Alarm5Group.Visibility = Visibility.Visible;
                Sensor5V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 5)
            {
                Alarm6Name = sensors.ElementAt(5).Name;
                Alarm6Group.Visibility = Visibility.Visible;
                Sensor6V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 6)
            {
                Alarm7Name = sensors.ElementAt(6).Name;
                Alarm7Group.Visibility = Visibility.Visible;
                Sensor7V.Visibility = Visibility.Visible;
            }
            if (SensorCount > 7)
            {
                Alarm8Name = sensors.ElementAt(7).Name;
                Alarm8Group.Visibility = Visibility.Visible;
                Sensor8V.Visibility = Visibility.Visible;
            }

            CheckSensors();

        }

        public void CheckSensors()
        {
            bool contains = false;
            foreach (var item in sensors)
            {
                if (!contains)
                {
                    if (item.Name.Equals("O2"))
                    {
                        contains = true;
                        o2sensorWrap.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        o2sensorWrap.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!Gekocht && !NGekocht)
            {
                MessageBoxResult result = MessageBox.Show("Gelieve aan te geven of het toestel is aangekocht of niet.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Bent u zeker dat u dit toestel wilt aanpassen?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
             
                    using (var db = new ServiceProgramContext())
                    {
                        var _device = db.Devices.Find(device.Id);
                        DateTime Bought2;
                        DateTime LastCheck2;
                        DateTime NextCheck2;
                        DateTime o2sensor2;
                        if (Bought != null)
                        {
                            Bought2 = (DateTime)Bought;
                        }
                        else
                        {
                            Bought2 = DateTime.Now;
                        }
                        if (LastCheck != null)
                        {
                            LastCheck2 = (DateTime)LastCheck;
                        }
                        else
                        {
                            LastCheck2 = DateTime.Now;
                        }
                        if (NextCheck != null)
                        {
                            NextCheck2 = (DateTime)NextCheck;
                        }
                        else
                        {
                            NextCheck2 = DateTime.Now;
                        }
                        int selectedIndex = companies.SelectedIndex;
                        int companyId = List[selectedIndex].Id;

                        _device.Name = DeviceName;
                        _device.SerialNumber = SerialNumber;
                        _device.Bought = Bought2;
                        _device.Price = Price;
                        _device.LastCheck = LastCheck2;
                        _device.NextCheck = NextCheck2;
                        _device.Client = db.Clients.Find(companyId);
                        _device.Opmerking = Opmerking;
                        _device.Note = Note;
                        _device.BoughtByUs = Gekocht;
                        _device.Broken = Broken;
                        _device.Lost = Lost;
                        _device.NoS = GeenOp;
                        _device.Reference = Reference;
                        _device.Alarm1L = Alarm1L;
                        _device.Alarm1H = Alarm1H;
                        _device.Alarm1S = Alarm1S;
                        _device.Alarm1T = Alarm1T;
                        _device.Alarm2L = Alarm2L;
                        _device.Alarm2H = Alarm2H;
                        _device.Alarm2S = Alarm2S;
                        _device.Alarm2T = Alarm2T;
                        _device.Alarm3L = Alarm3L;
                        _device.Alarm3H = Alarm3H;
                        _device.Alarm3S = Alarm3S;
                        _device.Alarm3T = Alarm3T;
                        _device.Alarm4L = Alarm4L;
                        _device.Alarm4H = Alarm4H;
                        _device.Alarm4S = Alarm4S;
                        _device.Alarm4T = Alarm4T;
                        _device.Alarm5L = Alarm5L;
                        _device.Alarm5H = Alarm5H;
                        _device.Alarm5S = Alarm5S;
                        _device.Alarm5T = Alarm5T;
                        _device.Alarm6L = Alarm6L;
                        _device.Alarm6H = Alarm6H;
                        _device.Alarm6S = Alarm6S;
                        _device.Alarm6T = Alarm6T;
                        _device.Alarm7L = Alarm7L;
                        _device.Alarm7H = Alarm7H;
                        _device.Alarm7S = Alarm7S;
                        _device.Alarm7T = Alarm7T;
                        _device.Alarm8L = Alarm8L;
                        _device.Alarm8H = Alarm8H;
                        _device.Alarm8S = Alarm8S;
                        _device.Alarm8T = Alarm8T;
                        Console.WriteLine("Sens1");
                        Console.WriteLine(Alarm1L);
                        Console.WriteLine(Alarm1H);
                        Console.WriteLine(Alarm1S);
                        Console.WriteLine(Alarm1T);

                        Console.WriteLine("Sens2");
                        Console.WriteLine(Alarm2L);
                        Console.WriteLine(Alarm2H);
                        Console.WriteLine(Alarm2S);
                        Console.WriteLine(Alarm2T);

                        Console.WriteLine("Sens3");
                        Console.WriteLine(Alarm3L);
                        Console.WriteLine(Alarm3H);
                        Console.WriteLine(Alarm3S);
                        Console.WriteLine(Alarm3T);

                        Console.WriteLine("Sens4");
                        Console.WriteLine(Alarm4L);
                        Console.WriteLine(Alarm4H);
                        Console.WriteLine(Alarm4S);
                        Console.WriteLine(Alarm4T);

                        Console.WriteLine("Sens5");
                        Console.WriteLine(Alarm5L);
                        Console.WriteLine(Alarm5H);
                        Console.WriteLine(Alarm5S);
                        Console.WriteLine(Alarm5T);

                        Console.WriteLine("Sens6");
                        Console.WriteLine(Alarm6L);
                        Console.WriteLine(Alarm6H);
                        Console.WriteLine(Alarm6S);
                        Console.WriteLine(Alarm6T);

                        Console.WriteLine("Sens7");
                        Console.WriteLine(Alarm7L);
                        Console.WriteLine(Alarm7H);
                        Console.WriteLine(Alarm7S);
                        Console.WriteLine(Alarm7T);

                        Console.WriteLine("Sens8");
                        Console.WriteLine(Alarm8L);
                        Console.WriteLine(Alarm8H);
                        Console.WriteLine(Alarm8S);
                        Console.WriteLine(Alarm8T);
                        var sens1 = _device.Sensor1;
                        var sens2 = _device.Sensor2;
                        var sens3 = _device.Sensor3;
                        var sens4 = _device.Sensor4;
                        var sens5 = _device.Sensor5;
                        var sens6 = _device.Sensor6;
                        var sens7 = _device.Sensor7;
                        var sens8 = _device.Sensor8;
                        _device.Sensor1 = null;
                        _device.Sensor2 = null;
                        _device.Sensor3 = null;
                        _device.Sensor4 = null;
                        _device.Sensor5 = null;
                        _device.Sensor6 = null;
                        _device.Sensor7 = null;
                        _device.Sensor8 = null;


                        _device.Aanwezig = Aanwezig;
                        SensorCount = sensors.Count();
                        Console.WriteLine(SensorCount);
                        if (SensorCount > 0)
                        {
                            _device.Sensor1 = db.Sensors.Find(sensors.ElementAt(0).Id);
                        }
                        if (SensorCount > 1)
                        {
                            _device.Sensor2 = db.Sensors.Find(sensors.ElementAt(1).Id);
                        }
                        if (SensorCount > 2)
                        {
                            _device.Sensor3 = db.Sensors.Find(sensors.ElementAt(2).Id);
                        }
                        if (SensorCount > 3)
                        {
                            _device.Sensor4 = db.Sensors.Find(sensors.ElementAt(3).Id);
                        }
                        if (SensorCount > 4)
                        {
                            _device.Sensor5 = db.Sensors.Find(sensors.ElementAt(4).Id);
                        }
                        if (SensorCount > 5)
                        {
                            _device.Sensor6 = db.Sensors.Find(sensors.ElementAt(5).Id);
                        }
                        if (SensorCount > 6)
                        {
                            _device.Sensor7 = db.Sensors.Find(sensors.ElementAt(6).Id);
                        }
                        if (SensorCount > 7)
                        {
                            _device.Sensor8 = db.Sensors.Find(sensors.ElementAt(7).Id);
                        }
                        _device.HideAlarm1 = Sensor1Value;
                        _device.HideAlarm2 = Sensor2Value;
                        _device.HideAlarm3 = Sensor3Value;
                        _device.HideAlarm4 = Sensor4Value;
                        _device.HideAlarm5 = Sensor5Value;
                        _device.HideAlarm6 = Sensor6Value;
                        _device.HideAlarm7 = Sensor7Value;
                        _device.HideAlarm8 = Sensor8Value;
                        if (O2Sensor != null)
                        {
                            o2sensor2 = (DateTime)O2Sensor;
                        }
                        else
                        {
                            o2sensor2 = DateTime.MinValue;
                        }
                        _device.O2Sensor = o2sensor2;
                        db.SaveChanges();
                        ((MainWindow)this.Owner).UpdateDevicesGrid(_device.Client);
                        DataGridRow row = (DataGridRow)(((MainWindow)this.Owner).DeviceGrid).ItemContainerGenerator.ContainerFromIndex(rowId);
                        object item = ((MainWindow)this.Owner).DeviceGrid.Items[rowId];
                        ((MainWindow)this.Owner).DeviceGrid.SelectedItem = item;
                        ((MainWindow)this.Owner).DeviceGrid.ScrollIntoView(item);
                        Owner.Activate();
                        Activate();
                    }
                    this.Close();
                    this.Owner.Activate();
                }
                else { }
            }
        }

        public void UpdateSensorGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                //ResetAlarmen();
                SensorGrid.Items.Clear();
                Console.WriteLine(sensors.Count);
                foreach (var sensor in sensors)
                {
                    SensorGrid.Items.Add(sensor);
                }
                sensors.Clear();
                if (device.Sensor1 != null)
                {
                    sensors.Add(device.Sensor1);
                }
                if (device.Sensor2 != null)
                {
                    sensors.Add(device.Sensor2);
                }
                if (device.Sensor3 != null)
                {
                    sensors.Add(device.Sensor3);
                }
                if (device.Sensor4 != null)
                {
                    sensors.Add(device.Sensor4);
                }
                if (device.Sensor5 != null)
                {
                    sensors.Add(device.Sensor5);
                }
                if (device.Sensor6 != null)
                {
                    sensors.Add(device.Sensor6);
                }
                if (device.Sensor7 != null)
                {
                    sensors.Add(device.Sensor7);
                }
                if (device.Sensor8 != null)
                {
                    sensors.Add(device.Sensor8);
                }


                SensorCount = sensors.Count();
                if (SensorCount > 0)
                {
                    alarm1L.Text = Alarm1L;
                    alarm1H.Text = Alarm1H;
                    alarm1S.Text = Alarm1S;
                    alarm1T.Text = Alarm1T;
                }
                if (SensorCount > 1)
                {
                    alarm2L.Text = Alarm2L;
                    alarm2H.Text = Alarm2H;
                    alarm2S.Text = Alarm2S;
                    alarm2T.Text = Alarm2T;
                }
                if (SensorCount > 2)
                {
                    alarm3L.Text = Alarm3L;
                    alarm3H.Text = Alarm3H;
                    alarm3S.Text = Alarm3S;
                    alarm3T.Text = Alarm3T;
                }
                if (SensorCount > 3)
                {
                    alarm4L.Text = Alarm4L;
                    alarm4H.Text = Alarm4H;
                    alarm4S.Text = Alarm4S;
                    alarm4T.Text = Alarm4T;
                }
                if (SensorCount > 4)
                {
                    alarm5L.Text = Alarm5L;
                    alarm5H.Text = Alarm5H;
                    alarm5S.Text = Alarm5S;
                    alarm5T.Text = Alarm5T;
                }
                if (SensorCount > 5)
                {
                    alarm6L.Text = Alarm6L;
                    alarm6H.Text = Alarm6H;
                    alarm6S.Text = Alarm6S;
                    alarm6T.Text = Alarm6T;
                }
                if (SensorCount > 6)
                {
                    alarm7L.Text = Alarm7L;
                    alarm7H.Text = Alarm7H;
                    alarm7S.Text = Alarm7S;
                    alarm7T.Text = Alarm7T;
                }
                if (SensorCount > 7)
                {
                    alarm8L.Text = Alarm8L;
                    alarm8H.Text = Alarm8H;
                    alarm8S.Text = Alarm8S;
                    alarm8T.Text = Alarm8T;
                }
                if (SensorCount > 0)
                {
                    Alarm1Name = sensors.ElementAt(0).Name;
                    Alarm1Group.Visibility = Visibility.Visible;
                    AlarmTitle.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm1Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 1)
                {
                    Alarm2Name = sensors.ElementAt(1).Name;
                    Alarm2Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm2Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 2)
                {
                    Alarm3Name = sensors.ElementAt(2).Name;
                    Alarm3Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm3Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 3)
                {
                    Alarm4Name = sensors.ElementAt(3).Name;
                    Alarm4Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm4Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 4)
                {
                    Alarm5Name = sensors.ElementAt(4).Name;
                    Alarm5Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm5Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 5)
                {
                    Alarm6Name = sensors.ElementAt(5).Name;
                    Alarm6Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm6Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 6)
                {
                    Alarm7Name = sensors.ElementAt(6).Name;
                    Alarm7Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm7Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 7)
                {
                    Alarm8Name = sensors.ElementAt(7).Name;
                    Alarm8Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm8Group.Visibility = Visibility.Collapsed;
                }
                foreach (var item in sensors)
                {
                    if (item.Name.Equals("O2"))
                    {
                        o2sensorWrap.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        o2sensorWrap.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
        public void UpdateSensorGrid(List<Sensor> sensorslist, int index)
        {
            using (var db = new ServiceProgramContext())
            {
                sensors = sensorslist;
                //ResetAlarmen();
                SensorGrid.Items.Clear();
                Console.WriteLine(sensors.Count);
                foreach (var sensor in sensors)
                {
                    SensorGrid.Items.Add(sensor);
                }
                SensorCount = sensors.Count();
                if (SensorCount > 0)
                {
                    alarm1L.Text = Alarm1L;
                    alarm1H.Text = Alarm1H;
                    alarm1S.Text = Alarm1S;
                    alarm1T.Text = Alarm1T;
                }
                if (SensorCount > 1)
                {
                    alarm2L.Text = Alarm2L;
                    alarm2H.Text = Alarm2H;
                    alarm2S.Text = Alarm2S;
                    alarm2T.Text = Alarm2T;
                }
                if (SensorCount > 2)
                {
                    alarm3L.Text = Alarm3L;
                    alarm3H.Text = Alarm3H;
                    alarm3S.Text = Alarm3S;
                    alarm3T.Text = Alarm3T;
                }
                if (SensorCount > 3)
                {
                    alarm4L.Text = Alarm4L;
                    alarm4H.Text = Alarm4H;
                    alarm4S.Text = Alarm4S;
                    alarm4T.Text = Alarm4T;
                }
                if (SensorCount > 4)
                {
                    alarm5L.Text = Alarm5L;
                    alarm5H.Text = Alarm5H;
                    alarm5S.Text = Alarm5S;
                    alarm5T.Text = Alarm5T;
                }
                if (SensorCount > 5)
                {
                    alarm6L.Text = Alarm6L;
                    alarm6H.Text = Alarm6H;
                    alarm6S.Text = Alarm6S;
                    alarm6T.Text = Alarm6T;
                }
                if (SensorCount > 6)
                {
                    alarm7L.Text = Alarm7L;
                    alarm7H.Text = Alarm7H;
                    alarm7S.Text = Alarm7S;
                    alarm7T.Text = Alarm7T;
                }
                if (SensorCount > 7)
                {
                    alarm8L.Text = Alarm8L;
                    alarm8H.Text = Alarm8H;
                    alarm8S.Text = Alarm8S;
                    alarm8T.Text = Alarm8T;
                }

                foreach (var item in sensors)
                {
                    if (item.Name.Equals("O2"))
                    {
                        o2sensorWrap.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        o2sensorWrap.Visibility = Visibility.Collapsed;
                    }
                }
                if (index == 1)
                {
                    Alarm1Name = Alarm2Name;
                    Sensor1O.Text = Alarm1Name;
                    Alarm1L = Alarm2L;
                    Alarm1H = Alarm2H;
                    Alarm1S = Alarm2S;
                    Alarm1T = Alarm2T;
                    alarm1L.Text = Alarm2L;
                    alarm1H.Text = Alarm2H;
                    alarm1S.Text = Alarm2S;
                    alarm1T.Text = Alarm2T;

                    Alarm2Name = Alarm3Name;
                    Sensor2O.Text = Alarm2Name;
                    Alarm2L = Alarm3L;
                    Alarm2H = Alarm3H;
                    Alarm2S = Alarm3S;
                    Alarm2T = Alarm3T;
                    alarm2L.Text = Alarm3L;
                    alarm2H.Text = Alarm3H;
                    alarm2S.Text = Alarm3S;
                    alarm2T.Text = Alarm3T;

                    Alarm3Name = Alarm4Name;
                    Sensor3O.Text = Alarm4Name;
                    Alarm3L = Alarm4L;
                    Alarm3H = Alarm4H;
                    Alarm3S = Alarm4S;
                    Alarm3T = Alarm4T;
                    alarm3L.Text = Alarm4L;
                    alarm3H.Text = Alarm4H;
                    alarm3S.Text = Alarm4S;
                    alarm3T.Text = Alarm4T;



                    Alarm4Name = Alarm5Name;
                    Sensor4O.Text = Alarm5Name;
                    Alarm4L = Alarm5L;
                    Alarm4H = Alarm5H;
                    Alarm4S = Alarm5S;
                    Alarm4T = Alarm5T;
                    alarm4L.Text = Alarm5L;
                    alarm4H.Text = Alarm5H;
                    alarm4S.Text = Alarm5S;
                    alarm4T.Text = Alarm5T;

                    Alarm5Name = Alarm6Name;
                    Sensor5O.Text = Alarm6Name;
                    Alarm5L = Alarm6L;
                    Alarm5H = Alarm6H;
                    Alarm5S = Alarm6S;
                    Alarm5T = Alarm6T;
                    alarm5L.Text = Alarm6L;
                    alarm5H.Text = Alarm6H;
                    alarm5S.Text = Alarm6S;
                    alarm5T.Text = Alarm6T;

                    Alarm6Name = Alarm7Name;
                    Sensor6O.Text = Alarm7Name;
                    Alarm6L = Alarm7L;
                    Alarm6H = Alarm7H;
                    Alarm6S = Alarm7S;
                    Alarm6T = Alarm7T;
                    alarm6L.Text = Alarm7L;
                    alarm6H.Text = Alarm7H;
                    alarm6S.Text = Alarm7S;
                    alarm6T.Text = Alarm7T;

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;














                }
                if (index == 2)
                {

                    Alarm2Name = Alarm3Name;
                    Sensor2O.Text = Alarm2Name;
                    Alarm2L = Alarm3L;
                    Alarm2H = Alarm3H;
                    Alarm2S = Alarm3S;
                    Alarm2T = Alarm3T;
                    alarm2L.Text = Alarm3L;
                    alarm2H.Text = Alarm3H;
                    alarm2S.Text = Alarm3S;
                    alarm2T.Text = Alarm3T;

                    Alarm3Name = Alarm4Name;
                    Sensor3O.Text = Alarm4Name;
                    Alarm3L = Alarm4L;
                    Alarm3H = Alarm4H;
                    Alarm3S = Alarm4S;
                    Alarm3T = Alarm4T;
                    alarm3L.Text = Alarm4L;
                    alarm3H.Text = Alarm4H;
                    alarm3S.Text = Alarm4S;
                    alarm3T.Text = Alarm4T;



                    Alarm4Name = Alarm5Name;
                    Sensor4O.Text = Alarm5Name;
                    Alarm4L = Alarm5L;
                    Alarm4H = Alarm5H;
                    Alarm4S = Alarm5S;
                    Alarm4T = Alarm5T;
                    alarm4L.Text = Alarm5L;
                    alarm4H.Text = Alarm5H;
                    alarm4S.Text = Alarm5S;
                    alarm4T.Text = Alarm5T;

                    Alarm5Name = Alarm6Name;
                    Sensor5O.Text = Alarm6Name;
                    Alarm5L = Alarm6L;
                    Alarm5H = Alarm6H;
                    Alarm5S = Alarm6S;
                    Alarm5T = Alarm6T;
                    alarm5L.Text = Alarm6L;
                    alarm5H.Text = Alarm6H;
                    alarm5S.Text = Alarm6S;
                    alarm5T.Text = Alarm6T;

                    Alarm6Name = Alarm7Name;
                    Sensor6O.Text = Alarm7Name;
                    Alarm6L = Alarm7L;
                    Alarm6H = Alarm7H;
                    Alarm6S = Alarm7S;
                    Alarm6T = Alarm7T;
                    alarm6L.Text = Alarm7L;
                    alarm6H.Text = Alarm7H;
                    alarm6S.Text = Alarm7S;
                    alarm6T.Text = Alarm7T;

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;
                }
                if (index == 3)
                {


                    Alarm3Name = Alarm4Name;
                    Sensor3O.Text = Alarm4Name;
                    Alarm3L = Alarm4L;
                    Alarm3H = Alarm4H;
                    Alarm3S = Alarm4S;
                    Alarm3T = Alarm4T;
                    alarm3L.Text = Alarm4L;
                    alarm3H.Text = Alarm4H;
                    alarm3S.Text = Alarm4S;
                    alarm3T.Text = Alarm4T;



                    Alarm4Name = Alarm5Name;
                    Sensor4O.Text = Alarm5Name;
                    Alarm4L = Alarm5L;
                    Alarm4H = Alarm5H;
                    Alarm4S = Alarm5S;
                    Alarm4T = Alarm5T;
                    alarm4L.Text = Alarm5L;
                    alarm4H.Text = Alarm5H;
                    alarm4S.Text = Alarm5S;
                    alarm4T.Text = Alarm5T;

                    Alarm5Name = Alarm6Name;
                    Sensor5O.Text = Alarm6Name;
                    Alarm5L = Alarm6L;
                    Alarm5H = Alarm6H;
                    Alarm5S = Alarm6S;
                    Alarm5T = Alarm6T;
                    alarm5L.Text = Alarm6L;
                    alarm5H.Text = Alarm6H;
                    alarm5S.Text = Alarm6S;
                    alarm5T.Text = Alarm6T;

                    Alarm6Name = Alarm7Name;
                    Sensor6O.Text = Alarm7Name;
                    Alarm6L = Alarm7L;
                    Alarm6H = Alarm7H;
                    Alarm6S = Alarm7S;
                    Alarm6T = Alarm7T;
                    alarm6L.Text = Alarm7L;
                    alarm6H.Text = Alarm7H;
                    alarm6S.Text = Alarm7S;
                    alarm6T.Text = Alarm7T;

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;

                }

                if (index == 4)
                {


                    Alarm4Name = Alarm5Name;
                    Sensor4O.Text = Alarm5Name;
                    Alarm4L = Alarm5L;
                    Alarm4H = Alarm5H;
                    Alarm4S = Alarm5S;
                    Alarm4T = Alarm5T;
                    alarm4L.Text = Alarm5L;
                    alarm4H.Text = Alarm5H;
                    alarm4S.Text = Alarm5S;
                    alarm4T.Text = Alarm5T;

                    Alarm5Name = Alarm6Name;
                    Sensor5O.Text = Alarm6Name;
                    Alarm5L = Alarm6L;
                    Alarm5H = Alarm6H;
                    Alarm5S = Alarm6S;
                    Alarm5T = Alarm6T;
                    alarm5L.Text = Alarm6L;
                    alarm5H.Text = Alarm6H;
                    alarm5S.Text = Alarm6S;
                    alarm5T.Text = Alarm6T;

                    Alarm6Name = Alarm7Name;
                    Sensor6O.Text = Alarm7Name;
                    Alarm6L = Alarm7L;
                    Alarm6H = Alarm7H;
                    Alarm6S = Alarm7S;
                    Alarm6T = Alarm7T;
                    alarm6L.Text = Alarm7L;
                    alarm6H.Text = Alarm7H;
                    alarm6S.Text = Alarm7S;
                    alarm6T.Text = Alarm7T;

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;

                }
                if (index == 5)
                {

                    Alarm5Name = Alarm6Name;
                    Sensor5O.Text = Alarm6Name;
                    Alarm5L = Alarm6L;
                    Alarm5H = Alarm6H;
                    Alarm5S = Alarm6S;
                    Alarm5T = Alarm6T;
                    alarm5L.Text = Alarm6L;
                    alarm5H.Text = Alarm6H;
                    alarm5S.Text = Alarm6S;
                    alarm5T.Text = Alarm6T;

                    Alarm6Name = Alarm7Name;
                    Sensor6O.Text = Alarm7Name;
                    Alarm6L = Alarm7L;
                    Alarm6H = Alarm7H;
                    Alarm6S = Alarm7S;
                    Alarm6T = Alarm7T;
                    alarm6L.Text = Alarm7L;
                    alarm6H.Text = Alarm7H;
                    alarm6S.Text = Alarm7S;
                    alarm6T.Text = Alarm7T;

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;

                }
                if (index == 6)
                {


                    Alarm6Name = Alarm7Name;
                    Sensor6O.Text = Alarm7Name;
                    Alarm6L = Alarm7L;
                    Alarm6H = Alarm7H;
                    Alarm6S = Alarm7S;
                    Alarm6T = Alarm7T;
                    alarm6L.Text = Alarm7L;
                    alarm6H.Text = Alarm7H;
                    alarm6S.Text = Alarm7S;
                    alarm6T.Text = Alarm7T;

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;

                }
                if (index == 7)
                {

                    Alarm7Name = Alarm8Name;
                    Sensor7O.Text = Alarm8Name;
                    Alarm7L = Alarm8L;
                    Alarm7H = Alarm8H;
                    Alarm7S = Alarm8S;
                    Alarm7T = Alarm8T;
                    alarm7L.Text = Alarm8L;
                    alarm7H.Text = Alarm8H;
                    alarm7S.Text = Alarm8S;
                    alarm7T.Text = Alarm8T;

                }
                if (SensorCount > 0)
                {
                    //Alarm1Name = sensors.ElementAt(0).Name;
                    Alarm1Group.Visibility = Visibility.Visible;
                    AlarmTitle.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm1Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 1)
                {
                    //Alarm2Name = sensors.ElementAt(1).Name;
                    Alarm2Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm2Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 2)
                {
                    //Alarm3Name = sensors.ElementAt(2).Name;
                    Alarm3Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm3Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 3)
                {
                    //Alarm4Name = sensors.ElementAt(3).Name;
                    Alarm4Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm4Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 4)
                {
                    //Alarm5Name = sensors.ElementAt(4).Name;
                    Alarm5Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm5Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 5)
                {
                    //Alarm6Name = sensors.ElementAt(5).Name;
                    Alarm6Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm6Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 6)
                {
                    //Alarm7Name = sensors.ElementAt(6).Name;
                    Alarm7Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm7Group.Visibility = Visibility.Collapsed;
                }
                if (SensorCount > 7)
                {
                    //Alarm8Name = sensors.ElementAt(7).Name;
                    Alarm8Group.Visibility = Visibility.Visible;
                }
                else
                {
                    Alarm8Group.Visibility = Visibility.Collapsed;
                }
            }
            Console.WriteLine(Alarm1Name);
            Console.WriteLine(Alarm2Name);
            Console.WriteLine(Alarm3Name);
            Console.WriteLine(Alarm4Name);
            Console.WriteLine(Alarm5Name);
            Console.WriteLine(Alarm6Name);
            Console.WriteLine(Alarm7Name);
            Console.WriteLine(Alarm8Name);
        }
        public void ResetAlarmen()
        {
            Alarm1L = null;
            Alarm1H = null;
            Alarm1S = null;
            Alarm1T = null;
            Alarm2L = null;
            Alarm2H = null;
            Alarm2S = null;
            Alarm2T = null;
            Alarm3L = null;
            Alarm3H = null;
            Alarm3S = null;
            Alarm3T = null;
            Alarm4L = null;
            Alarm4H = null;
            Alarm4S = null;
            Alarm4T = null;
            Alarm5L = null;
            Alarm5H = null;
            Alarm5S = null;
            Alarm5T = null;
            Alarm6L = null;
            Alarm6H = null;
            Alarm6S = null;
            Alarm6T = null;
            Alarm7L = null;
            Alarm7H = null;
            Alarm7S = null;
            Alarm7T = null;
            Alarm8L = null;
            Alarm8H = null;
            Alarm8S = null;
            Alarm8T = null;
        }

        private void SensorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sensor sensor = (Sensor)SensorGrid.SelectedItem;
            if (sensor != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    SelectedSensor = db.Sensors.Find(sensor.Id);
                }
            }
        }

        private void SensorGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        private void CheckBoxChangedOn(object sender, RoutedEventArgs e)
        {
            gekochtWrap.Visibility = Visibility.Visible;
            VNGekocht.Visibility = Visibility.Collapsed;
        }

        private void CheckBoxChangedOff(object sender, RoutedEventArgs e)
        {
            gekochtWrap.Visibility = Visibility.Collapsed;
            VNGekocht.Visibility = Visibility.Visible;
        }

        private void CheckBox2ChangedOn(object sender, RoutedEventArgs e)
        {
            VGekocht.Visibility = Visibility.Collapsed;
            gekochtWrap.Visibility = Visibility.Collapsed;
        }

        private void CheckBox2ChangedOff(object sender, RoutedEventArgs e)
        {
            VGekocht.Visibility = Visibility.Visible;
        }

        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        private void Button_ClickAddSensors(object sender, RoutedEventArgs e)
        {
            sensedit = true;
            AddSensors addSensors = new AddSensors(sensors, device)
            {
                Owner = this
            };
            addSensors.Show();
        }
    }
}
