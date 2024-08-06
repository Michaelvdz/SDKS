using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for NewDevice.xaml
    /// </summary>
    public partial class NewDevice : Window
    {

        public String DeviceName { get; set; }
        public String SerialNumber { get; set; }
        public String Reference { get; set; }
        public DateTime? Bought { get; set; }
        public DateTime? LastCheck { get; set; }
        public DateTime? NextCheck { get; set; }
        public List<ComboData> List { get; set; }
        public List<ComboData> Presets { get; set; }
        public Client SelectedClient { get; set; }
        public String Price { get; set; }
        public bool Gekocht { get; set; }
        public bool NGekocht { get; set; }
        public String Note { get; set; }
        public Sensor SelectedSensor { get; set; }
        public String Opmerking { get; set; }
        public List<Sensor> Sensors { get; set; }
        public int SensorCount { get; set; }
        public DateTime? O2Sensor { get; set; }
        public bool o2ng { get; set; }

        public NewDevice()
        {
            InitializeComponent();
            DataContext = this;
            using (var db = new ServiceProgramContext())
            {
                List<Client> clients = db.Clients.ToList();
                List = new List<ComboData>();
                foreach (var client in clients)
                {
                    List.Add(new ComboData { Id = client.Id, Value = client.Company});
                }

                companies.ItemsSource = List;
                companies.DisplayMemberPath = "Value";
                companies.SelectedValuePath = "Id";
                companies.SelectedIndex = 0;

                List<PresetDevs> devices = db.DefaultDevices.ToList();
                Console.WriteLine("Size: " + devices.Count());
                Presets = new List<ComboData>();
                foreach (var dev in devices)
                {
                    Presets.Add(new ComboData { Id = dev.Id, Value = dev.Name });
                }

                preset.ItemsSource = Presets;
                preset.DisplayMemberPath = "Value";
                preset.SelectedValuePath = "Id";
                preset.SelectedIndex = 0;
            }
        }

        public NewDevice(Client _client)
        {
            InitializeComponent();
            DataContext = this;
            SelectedClient = _client;
            int id = _client.Id;
            Sensors = new List<Sensor>();
            using (var db = new ServiceProgramContext())
            {
                List<Client> clients = db.Clients.ToList();
                clients.Sort((x, y) => x.Company.CompareTo(y.Company));
                List = new List<ComboData>();
                foreach (var client in clients)
                {
                    List.Add(new ComboData { Id = client.Id, Value = client.Company });
                }

                companies.ItemsSource = List;
                companies.DisplayMemberPath = "Value";
                companies.SelectedValuePath = "Id";
                companies.SelectedValue = id.ToString();

                List<PresetDevs> devices = db.DefaultDevices.ToList();
                devices.Sort((x, y) => x.Name.CompareTo(y.Name));
                Console.WriteLine("Size: " + devices.Count());
                Presets = new List<ComboData>();
                foreach (var dev in devices)
                {
                    Presets.Add(new ComboData { Id = dev.Id, Value = dev.Name });
                }
                preset.ItemsSource = Presets;
                preset.DisplayMemberPath = "Value";
                preset.SelectedValuePath = "Id";
                preset.SelectedValue = id.ToString();
            }
            Bought = DateTime.Today;
            O2Sensor = DateTime.Today;
        }
        public NewDevice(Device _device, Client _client)
        {
            InitializeComponent();
            DataContext = this;
            DeviceName = _device.Name;
            SerialNumber = _device.SerialNumber;
            Bought = _device.Bought;
            LastCheck = _device.LastCheck;
            NextCheck = _device.NextCheck;
            if (_device.BoughtByUs)
            {
                Gekocht = true;
            }
            else
            {
                NGekocht = true;
            }
            Note = _device.Note;






            Price = _device.Price;
            Opmerking = _device.Opmerking;
            Reference = _device.Reference;

            SelectedClient = _client;
            int id = _client.Id;

            Sensors = new List<Sensor>();
            using (var db = new ServiceProgramContext())
            {
                List<Client> clients = db.Clients.ToList();
                clients.Sort((x, y) => x.Company.CompareTo(y.Company));
                List = new List<ComboData>();
                foreach (var client in clients)
                {
                    List.Add(new ComboData { Id = client.Id, Value = client.Company });
                }

                companies.ItemsSource = List;
                companies.DisplayMemberPath = "Value";
                companies.SelectedValuePath = "Id";
                companies.SelectedValue = id.ToString();

                List<PresetDevs> devices = db.DefaultDevices.ToList();
                devices.Sort((x, y) => x.Name.CompareTo(y.Name));
                Console.WriteLine("Size: " + devices.Count());
                Presets = new List<ComboData>();
                foreach (var dev in devices)
                {
                    Presets.Add(new ComboData { Id = dev.Id, Value = dev.Name });
                }
                preset.ItemsSource = Presets;
                preset.DisplayMemberPath = "Value";
                preset.SelectedValuePath = "Id";
                preset.SelectedValue = id.ToString();

                //Sensors
                Device device_ = db.Devices.Find(_device.Id);
                if(device_.Sensor1 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor1.Id));
                }
                if (device_.Sensor2 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor2.Id));
                }
                if (device_.Sensor3 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor3.Id));
                }
                if (device_.Sensor4 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor4.Id));
                }
                if (device_.Sensor5 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor5.Id));
                }
                if (device_.Sensor6 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor6.Id));
                }
                if (device_.Sensor7 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor7.Id));
                }
                if (device_.Sensor8 != null){
                    Sensors.Add(db.Sensors.Find(device_.Sensor8.Id));
                }
                
            }
            O2Sensor = _device.O2Sensor;
            UpdateSensorGrid();
        }

        private void Button_ApplyClick(object sender, RoutedEventArgs e)
        {
            using (var db = new ServiceProgramContext())
            {
                int index = 0;
                Int32.TryParse(preset.SelectedValue.ToString(), out index);
                PresetDevs dev = db.DefaultDevices.Find(index);
                devname.Text = dev.Name;
                devnote.Text = dev.Note;
                devopmerking.Text = dev.Opmerking;
                Sensors = new List<Sensor>();
                if(dev.Sensor1 != null)
                {
                    Sensors.Add(dev.Sensor1);
                }
                if (dev.Sensor2 != null)
                {
                    Sensors.Add(dev.Sensor2);
                }
                if (dev.Sensor3 != null)
                {
                    Sensors.Add(dev.Sensor3);
                }
                if (dev.Sensor4 != null)
                {
                    Sensors.Add(dev.Sensor4);
                }
                if (dev.Sensor5 != null)
                {
                    Sensors.Add(dev.Sensor5);
                }
                if (dev.Sensor6 != null)
                {
                    Sensors.Add(dev.Sensor6);
                }
                if (dev.Sensor7 != null)
                {
                    Sensors.Add(dev.Sensor7);
                }
                if (dev.Sensor8 != null)
                {
                    Sensors.Add(dev.Sensor8);
                }
                if (dev.Sensor9 != null)
                {
                    Sensors.Add(dev.Sensor9);
                }
                if (dev.Sensor10 != null)
                {
                    Sensors.Add(dev.Sensor10);
                }
                if (dev.Sensor11 != null)
                {
                    Sensors.Add(dev.Sensor11);
                }
                if (dev.Sensor12 != null)
                {
                    Sensors.Add(dev.Sensor12);
                }
                if (dev.Sensor13 != null)
                {
                    Sensors.Add(dev.Sensor13);
                }
                if (dev.Sensor14 != null)
                {
                    Sensors.Add(dev.Sensor14);
                }
                if (dev.Sensor15 != null)
                {
                    Sensors.Add(dev.Sensor15);
                }
                if (dev.Sensor16 != null)
                {
                    Sensors.Add(dev.Sensor16);
                }
                if (dev.Sensor17 != null)
                {
                    Sensors.Add(dev.Sensor17);
                }
                if (dev.Sensor18 != null)
                {
                    Sensors.Add(dev.Sensor18);
                }
                if (dev.Sensor19 != null)
                {
                    Sensors.Add(dev.Sensor19);
                }
                if (dev.Sensor20 != null)
                {
                    Sensors.Add(dev.Sensor20);
                }
                if (dev.Sensor21 != null)
                {
                    Sensors.Add(dev.Sensor21);
                }
                if (dev.Sensor22 != null)
                {
                    Sensors.Add(dev.Sensor22);
                }
                if (dev.Sensor23 != null)
                {
                    Sensors.Add(dev.Sensor23);
                }
                if (dev.Sensor24 != null)
                {
                    Sensors.Add(dev.Sensor24);
                }
                if (dev.Sensor25 != null)
                {
                    Sensors.Add(dev.Sensor25);
                }
                if (dev.Sensor26 != null)
                {
                    Sensors.Add(dev.Sensor26);
                }
                if (dev.Sensor27 != null)
                {
                    Sensors.Add(dev.Sensor27);
                }
                if (dev.Sensor28 != null)
                {
                    Sensors.Add(dev.Sensor28);
                }
                if (dev.Sensor29 != null)
                {
                    Sensors.Add(dev.Sensor29);
                }
                if (dev.Sensor30 != null)
                {
                    Sensors.Add(dev.Sensor30);
                }
                if (dev.Sensor31 != null)
                {
                    Sensors.Add(dev.Sensor31);
                }
                if (dev.Sensor32 != null)
                {
                    Sensors.Add(dev.Sensor32);
                }
                if (dev.Sensor33 != null)
                {
                    Sensors.Add(dev.Sensor33);
                }
                if (dev.Sensor34 != null)
                {
                    Sensors.Add(dev.Sensor34);
                }
                if (dev.Sensor35 != null)
                {
                    Sensors.Add(dev.Sensor35);
                }
                if (dev.Sensor36 != null)
                {
                    Sensors.Add(dev.Sensor36);
                }
                if (dev.Sensor37 != null)
                {
                    Sensors.Add(dev.Sensor37);
                }
                if (dev.Sensor38 != null)
                {
                    Sensors.Add(dev.Sensor38);
                }
                if (dev.Sensor39 != null)
                {
                    Sensors.Add(dev.Sensor39);
                }
                if (dev.Sensor40 != null)
                {
                    Sensors.Add(dev.Sensor40);
                }
                UpdateSensorGrid();
                CheckSensors();
            }
        }

        public void CheckSensors()
        {
            bool contains = false;
            foreach (var item in Sensors)
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
            if(Sensors.Count > 8)
            {
                MessageBoxResult result = MessageBox.Show("Er zijn maar 8 plaatsen voor sensoren op een toestel.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (!Gekocht && !NGekocht)
            {
                MessageBoxResult result = MessageBox.Show("Gelieve aan te geven of het toestel is aangekocht of niet.", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (Gekocht && Bought==DateTime.MinValue)
            {
                MessageBoxResult result = MessageBox.Show("Je moet de datum van aankoop ingeven.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                var device = new Device();
                using (var db = new ServiceProgramContext())
                {
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
                    NextCheck2 = DateTime.MinValue;
                    LastCheck2 = DateTime.MinValue;
                    int selectedIndex = companies.SelectedIndex;
                    int companyId = List[selectedIndex].Id;
                    device = new Device() { Name = devname.Text, SerialNumber = SerialNumber, Price = Price, Bought = Bought2, LastCheck = LastCheck2, NextCheck = NextCheck2, BoughtByUs = Gekocht, Client = db.Clients.Find(companyId), Note = devnote.Text, Opmerking = devopmerking.Text, Broken = false, Reference = Reference};
                    if(Sensors.Count() >= 1 && Sensors.ElementAt(0) != null)
                    {
                        device.Sensor1 = db.Sensors.Find(Sensors.ElementAt(0).Id);
                        device.Alarm1L = device.Sensor1.Laag;
                        device.Alarm1H = device.Sensor1.Hoog;
                        device.Alarm1S = device.Sensor1.Stel;
                        device.Alarm1T = device.Sensor1.Twa;
                    }
                    if (Sensors.Count() >= 2 && Sensors.ElementAt(1) != null)
                    {
                        device.Sensor2 = db.Sensors.Find(Sensors.ElementAt(1).Id);
                        device.Alarm2L = device.Sensor2.Laag;
                        device.Alarm2H = device.Sensor2.Hoog;
                        device.Alarm2S = device.Sensor2.Stel;
                        device.Alarm2T = device.Sensor2.Twa;
                    }
                    if (Sensors.Count() >= 3 && Sensors.ElementAt(2) != null)
                    {
                        device.Sensor3 = db.Sensors.Find(Sensors.ElementAt(2).Id);
                        device.Alarm3L = device.Sensor3.Laag;
                        device.Alarm3H = device.Sensor3.Hoog;
                        device.Alarm3S = device.Sensor3.Stel;
                        device.Alarm3T = device.Sensor3.Twa;
                    }
                    if (Sensors.Count() >= 4 && Sensors.ElementAt(3) != null)
                    {
                        device.Sensor4 = db.Sensors.Find(Sensors.ElementAt(3).Id);
                        device.Alarm4L = device.Sensor4.Laag;
                        device.Alarm4H = device.Sensor4.Hoog;
                        device.Alarm4S = device.Sensor4.Stel;
                        device.Alarm4T = device.Sensor4.Twa;
                    }
                    if (Sensors.Count() >= 5 && Sensors.ElementAt(4) != null)
                    {
                        device.Sensor5 = db.Sensors.Find(Sensors.ElementAt(4).Id);
                        device.Alarm5L = device.Sensor5.Laag;
                        device.Alarm5H = device.Sensor5.Hoog;
                        device.Alarm5S = device.Sensor5.Stel;
                        device.Alarm5T = device.Sensor5.Twa;
                    }
                    if (Sensors.Count() >= 6 && Sensors.ElementAt(5) != null)
                    {
                        device.Sensor6 = db.Sensors.Find(Sensors.ElementAt(5).Id);
                        device.Alarm6L = device.Sensor6.Laag;
                        device.Alarm6H = device.Sensor6.Hoog;
                        device.Alarm6S = device.Sensor6.Stel;
                        device.Alarm6T = device.Sensor6.Twa;
                    }
                    if (Sensors.Count() >= 7 && Sensors.ElementAt(6) != null)
                    {
                        device.Sensor7 = db.Sensors.Find(Sensors.ElementAt(6).Id);
                        device.Alarm7L = device.Sensor7.Laag;
                        device.Alarm7H = device.Sensor7.Hoog;
                        device.Alarm7S = device.Sensor7.Stel;
                        device.Alarm7T = device.Sensor7.Twa;
                    }
                    if (Sensors.Count() >= 8 && Sensors.ElementAt(7) != null)
                    {
                        device.Sensor8 = db.Sensors.Find(Sensors.ElementAt(7).Id);
                        device.Alarm8L = device.Sensor8.Laag;
                        device.Alarm8H = device.Sensor8.Hoog;
                        device.Alarm8S = device.Sensor8.Stel;
                        device.Alarm8T = device.Sensor8.Twa;
                    }
                    if (o2ng)
                    {
                        device.O2Sensor = DateTime.MinValue;
                    }
                    else
                    {
                        if (O2Sensor != null)
                        {
                            Console.WriteLine(O2Sensor);
                            o2sensor2 = (DateTime)O2Sensor;
                        }
                        else
                        {
                            Console.WriteLine("No Sernsor");
                            o2sensor2 = DateTime.MinValue;
                        }
                        device.O2Sensor = o2sensor2;
                    }


                    db.Devices.Add(device);
                    db.SaveChanges();

                }
                this.Close();
                this.Owner.Activate();
                //((MainWindow)this.Owner).UpdateClientsGrid();
                ((MainWindow)this.Owner).UpdateDevicesGrid(SelectedClient, device.Id);

            }
        }

        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }


        public void UpdateSensorGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                SensorCount = 0;
                SensorGrid.Items.Clear();
                foreach (var sensor in Sensors)
                {
                    SensorGrid.Items.Add(sensor);
                    SensorCount++;
                }
            }
            CheckSensors();
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
        private void CheckBox3ChangedOn(object sender, RoutedEventArgs e)
        {
            o2date.Visibility = Visibility.Collapsed;
        }
        private void CheckBox3ChangedOff(object sender, RoutedEventArgs e)
        {
            o2date.Visibility = Visibility.Visible;
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

        private void Button_ClickAddSensors(object sender, RoutedEventArgs e)
        {
            AddSensors addSensors = new AddSensors(Sensors)
            {
                Owner = this
            };
            addSensors.Show();
            CheckSensors();
        }
    }
}
