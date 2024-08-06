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
    public partial class UpdateDefaultDevice : Window
    {
        public String DeviceName { get; set; }
        public String SerialNumber { get; set; }
        public String Note { get; set; }
        public String Opmerking { get; set; }
        PresetDevs device;
        Sensor SelectedSensor;
        public int SensorCount { get; set; }
        public bool Aanwezig { get; set; }
        public List<Sensor> sensors;

        public UpdateDefaultDevice(PresetDevs selectedDevice)
        {
            InitializeComponent();
            DataContext = this;
            device = selectedDevice;
            DeviceName = selectedDevice.Name;
            Note = selectedDevice.Note;
            Opmerking = selectedDevice.Opmerking;
            using (var db = new ServiceProgramContext())
            {
                SensorCount = 0;
                PresetDevs Device = db.DefaultDevices.Find(device.Id);
                //sensors = new List<Sensor>();
                sensors = new List<Sensor>();
                if (Device.Sensor1 != null)
                {
                    sensors.Add(Device.Sensor1);
                }
                if (Device.Sensor2 != null)
                {
                    sensors.Add(Device.Sensor2);

                }
                if (Device.Sensor3 != null)
                {
                    sensors.Add(Device.Sensor3);

                }
                if (Device.Sensor4 != null)
                {
                    sensors.Add(Device.Sensor4);

                }
                if (Device.Sensor5 != null)
                {
                    sensors.Add(Device.Sensor5);

                }
                if (Device.Sensor6 != null)
                {
                    sensors.Add(Device.Sensor6);

                }
                if (Device.Sensor7 != null)
                {
                    sensors.Add(Device.Sensor7);

                }
                if (Device.Sensor8 != null)
                {
                    sensors.Add(Device.Sensor8);
                }
                if (Device.Sensor9 != null)
                {
                    sensors.Add(Device.Sensor9);
                }
                if (Device.Sensor10 != null)
                {
                    sensors.Add(Device.Sensor10);
                }
                if (Device.Sensor11 != null)
                {
                    sensors.Add(Device.Sensor11);
                }
                if (Device.Sensor12 != null)
                {
                    sensors.Add(Device.Sensor12);

                }
                if (Device.Sensor13 != null)
                {
                    sensors.Add(Device.Sensor13);

                }
                if (Device.Sensor14 != null)
                {
                    sensors.Add(Device.Sensor14);

                }
                if (Device.Sensor15 != null)
                {
                    sensors.Add(Device.Sensor15);

                }
                if (Device.Sensor16 != null)
                {
                    sensors.Add(Device.Sensor16);

                }
                if (Device.Sensor17 != null)
                {
                    sensors.Add(Device.Sensor17);

                }
                if (Device.Sensor18 != null)
                {
                    sensors.Add(Device.Sensor18);
                }
                if (Device.Sensor19 != null)
                {
                    sensors.Add(Device.Sensor19);
                }
                if (Device.Sensor20 != null)
                {
                    sensors.Add(Device.Sensor20);
                }
                if (Device.Sensor21 != null)
                {
                    sensors.Add(Device.Sensor21);
                }
                if (Device.Sensor22 != null)
                {
                    sensors.Add(Device.Sensor22);

                }
                if (Device.Sensor23 != null)
                {
                    sensors.Add(Device.Sensor23);

                }
                if (Device.Sensor24 != null)
                {
                    sensors.Add(Device.Sensor24);

                }
                if (Device.Sensor25 != null)
                {
                    sensors.Add(Device.Sensor25);

                }
                if (Device.Sensor26 != null)
                {
                    sensors.Add(Device.Sensor26);

                }
                if (Device.Sensor27 != null)
                {
                    sensors.Add(Device.Sensor27);

                }
                if (Device.Sensor28 != null)
                {
                    sensors.Add(Device.Sensor28);
                }
                if (Device.Sensor29 != null)
                {
                    sensors.Add(Device.Sensor29);
                }
                if (Device.Sensor30 != null)
                {
                    sensors.Add(Device.Sensor30);
                }
                if (Device.Sensor31 != null)
                {
                    sensors.Add(Device.Sensor31);
                }
                if (Device.Sensor32 != null)
                {
                    sensors.Add(Device.Sensor32);

                }
                if (Device.Sensor33 != null)
                {
                    sensors.Add(Device.Sensor33);

                }
                if (Device.Sensor34 != null)
                {
                    sensors.Add(Device.Sensor34);

                }
                if (Device.Sensor35 != null)
                {
                    sensors.Add(Device.Sensor35);

                }
                if (Device.Sensor36 != null)
                {
                    sensors.Add(Device.Sensor36);

                }
                if (Device.Sensor37 != null)
                {
                    sensors.Add(Device.Sensor37);

                }
                if (Device.Sensor38 != null)
                {
                    sensors.Add(Device.Sensor38);
                }
                if (Device.Sensor39 != null)
                {
                    sensors.Add(Device.Sensor39);
                }
                if (Device.Sensor40 != null)
                {
                    sensors.Add(Device.Sensor40);
                }
            }
            UpdateSensorGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bent u zeker dat u dit toestel wilt aanpassen?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                using (var db = new ServiceProgramContext())
                {

                    var _device = db.DefaultDevices.Find(device.Id);
                    _device.Name = DeviceName;
                    _device.Opmerking = Opmerking;
                    _device.Note = Note;

                    var sens1 = _device.Sensor1;
                    var sens2 = _device.Sensor2;
                    var sens3 = _device.Sensor3;
                    var sens4 = _device.Sensor4;
                    var sens5 = _device.Sensor5;
                    var sens6 = _device.Sensor6;
                    var sens7 = _device.Sensor7;
                    var sens8 = _device.Sensor8;
                    var sens9 = _device.Sensor9;
                    var sens10 = _device.Sensor10;
                    var sens11 = _device.Sensor11;
                    var sens12 = _device.Sensor12;
                    var sens13 = _device.Sensor13;
                    var sens14 = _device.Sensor14;
                    var sens15 = _device.Sensor15;
                    var sens16 = _device.Sensor16;
                    var sens17 = _device.Sensor17;
                    var sens18 = _device.Sensor18;
                    var sens19 = _device.Sensor19;
                    var sens20 = _device.Sensor20;
                    var sens21 = _device.Sensor21;
                    var sens22 = _device.Sensor22;
                    var sens23 = _device.Sensor23;
                    var sens24 = _device.Sensor24;
                    var sens25 = _device.Sensor25;
                    var sens26 = _device.Sensor26;
                    var sens27 = _device.Sensor27;
                    var sens28 = _device.Sensor28;
                    var sens29 = _device.Sensor29;
                    var sens30 = _device.Sensor30;
                    var sens31 = _device.Sensor31;
                    var sens32 = _device.Sensor32;
                    var sens33 = _device.Sensor33;
                    var sens34 = _device.Sensor34;
                    var sens35 = _device.Sensor35;
                    var sens36 = _device.Sensor36;
                    var sens37 = _device.Sensor37;
                    var sens38 = _device.Sensor38;
                    var sens39 = _device.Sensor39;
                    var sens40 = _device.Sensor40;
                    _device.Sensor1 = null;
                    _device.Sensor2 = null;
                    _device.Sensor3 = null;
                    _device.Sensor4 = null;
                    _device.Sensor5 = null;
                    _device.Sensor6 = null;
                    _device.Sensor7 = null;
                    _device.Sensor8 = null;
                    _device.Sensor9 = null;
                    _device.Sensor10 = null;
                    _device.Sensor11 = null;
                    _device.Sensor12 = null;
                    _device.Sensor13 = null;
                    _device.Sensor14 = null;
                    _device.Sensor15 = null;
                    _device.Sensor16 = null;
                    _device.Sensor17 = null;
                    _device.Sensor18 = null;
                    _device.Sensor19 = null;
                    _device.Sensor20 = null;
                    _device.Sensor21 = null;
                    _device.Sensor22 = null;
                    _device.Sensor23 = null;
                    _device.Sensor24 = null;
                    _device.Sensor25 = null;
                    _device.Sensor26 = null;
                    _device.Sensor27 = null;
                    _device.Sensor28 = null;
                    _device.Sensor29 = null;
                    _device.Sensor30 = null;
                    _device.Sensor31 = null;
                    _device.Sensor32 = null;
                    _device.Sensor33 = null;
                    _device.Sensor34 = null;
                    _device.Sensor35 = null;
                    _device.Sensor36 = null;
                    _device.Sensor37 = null;
                    _device.Sensor38 = null;
                    _device.Sensor39 = null;
                    _device.Sensor40 = null;
                    SensorCount = sensors.Count();
                    Console.WriteLine(SensorCount);
                    if (sensors.Count() >= 1 && sensors.ElementAt(0) != null)
                    {
                        _device.Sensor1 = db.Sensors.Find(sensors.ElementAt(0).Id);
                    }
                    if (sensors.Count() >= 2 && sensors.ElementAt(1) != null)
                    {
                        _device.Sensor2 = db.Sensors.Find(sensors.ElementAt(1).Id);
                    }
                    if (sensors.Count() >= 3 && sensors.ElementAt(2) != null)
                    {
                        _device.Sensor3 = db.Sensors.Find(sensors.ElementAt(2).Id);
                    }
                    if (sensors.Count() >= 4 && sensors.ElementAt(3) != null)
                    {
                        _device.Sensor4 = db.Sensors.Find(sensors.ElementAt(3).Id);
                    }
                    if (sensors.Count() >= 5 && sensors.ElementAt(4) != null)
                    {
                        _device.Sensor5 = db.Sensors.Find(sensors.ElementAt(4).Id);
                    }
                    if (sensors.Count() >= 6 && sensors.ElementAt(5) != null)
                    {
                        _device.Sensor6 = db.Sensors.Find(sensors.ElementAt(5).Id);
                    }
                    if (sensors.Count() >= 7 && sensors.ElementAt(6) != null)
                    {
                        _device.Sensor7 = db.Sensors.Find(sensors.ElementAt(6).Id);
                    }
                    if (sensors.Count() >= 8 && sensors.ElementAt(7) != null)
                    {
                        _device.Sensor8 = db.Sensors.Find(sensors.ElementAt(7).Id);
                    }
                    if (sensors.Count() >= 9 && sensors.ElementAt(8) != null)
                    {
                        _device.Sensor9 = db.Sensors.Find(sensors.ElementAt(8).Id);
                    }
                    if (sensors.Count() >= 10 && sensors.ElementAt(9) != null)
                    {
                        _device.Sensor10 = db.Sensors.Find(sensors.ElementAt(9).Id);
                    }
                    if (sensors.Count() >= 11 && sensors.ElementAt(10) != null)
                    {
                        _device.Sensor11 = db.Sensors.Find(sensors.ElementAt(10).Id);
                    }
                    if (sensors.Count() >= 12 && sensors.ElementAt(11) != null)
                    {
                        _device.Sensor12 = db.Sensors.Find(sensors.ElementAt(11).Id);
                    }
                    if (sensors.Count() >= 13 && sensors.ElementAt(12) != null)
                    {
                        _device.Sensor13 = db.Sensors.Find(sensors.ElementAt(12).Id);
                    }
                    if (sensors.Count() >= 14 && sensors.ElementAt(13) != null)
                    {
                        _device.Sensor14 = db.Sensors.Find(sensors.ElementAt(13).Id);
                    }
                    if (sensors.Count() >= 15 && sensors.ElementAt(14) != null)
                    {
                        _device.Sensor15 = db.Sensors.Find(sensors.ElementAt(14).Id);
                    }
                    if (sensors.Count() >= 16 && sensors.ElementAt(15) != null)
                    {
                        _device.Sensor16 = db.Sensors.Find(sensors.ElementAt(15).Id);
                    }
                    if (sensors.Count() >= 17 && sensors.ElementAt(16) != null)
                    {
                        _device.Sensor17 = db.Sensors.Find(sensors.ElementAt(16).Id);
                    }
                    if (sensors.Count() >= 18 && sensors.ElementAt(17) != null)
                    {
                        _device.Sensor18 = db.Sensors.Find(sensors.ElementAt(17).Id);
                    }
                    if (sensors.Count() >= 19 && sensors.ElementAt(18) != null)
                    {
                        _device.Sensor19 = db.Sensors.Find(sensors.ElementAt(18).Id);
                    }
                    if (sensors.Count() >= 20 && sensors.ElementAt(19) != null)
                    {
                        _device.Sensor20 = db.Sensors.Find(sensors.ElementAt(19).Id);
                    }
                    if (sensors.Count() >= 21 && sensors.ElementAt(20) != null)
                    {
                        _device.Sensor21 = db.Sensors.Find(sensors.ElementAt(20).Id);
                    }
                    if (sensors.Count() >= 22 && sensors.ElementAt(21) != null)
                    {
                        _device.Sensor22 = db.Sensors.Find(sensors.ElementAt(21).Id);
                    }
                    if (sensors.Count() >= 23 && sensors.ElementAt(22) != null)
                    {
                        _device.Sensor23 = db.Sensors.Find(sensors.ElementAt(22).Id);
                    }
                    if (sensors.Count() >= 24 && sensors.ElementAt(23) != null)
                    {
                        _device.Sensor24 = db.Sensors.Find(sensors.ElementAt(23).Id);
                    }
                    if (sensors.Count() >= 25 && sensors.ElementAt(24) != null)
                    {
                        _device.Sensor25 = db.Sensors.Find(sensors.ElementAt(24).Id);
                    }
                    if (sensors.Count() >= 26 && sensors.ElementAt(25) != null)
                    {
                        _device.Sensor26 = db.Sensors.Find(sensors.ElementAt(25).Id);
                    }
                    if (sensors.Count() >= 27 && sensors.ElementAt(26) != null)
                    {
                        _device.Sensor27 = db.Sensors.Find(sensors.ElementAt(26).Id);
                    }
                    if (sensors.Count() >= 28 && sensors.ElementAt(27) != null)
                    {
                        _device.Sensor28 = db.Sensors.Find(sensors.ElementAt(27).Id);
                    }
                    if (sensors.Count() >= 29 && sensors.ElementAt(28) != null)
                    {
                        _device.Sensor29 = db.Sensors.Find(sensors.ElementAt(28).Id);
                    }
                    if (sensors.Count() >= 30 && sensors.ElementAt(29) != null)
                    {
                        _device.Sensor30 = db.Sensors.Find(sensors.ElementAt(29).Id);
                    }
                    if (sensors.Count() >= 31 && sensors.ElementAt(30) != null)
                    {
                        _device.Sensor31 = db.Sensors.Find(sensors.ElementAt(30).Id);
                    }
                    if (sensors.Count() >= 32 && sensors.ElementAt(31) != null)
                    {
                        _device.Sensor32 = db.Sensors.Find(sensors.ElementAt(31).Id);
                    }
                    if (sensors.Count() >= 33 && sensors.ElementAt(32) != null)
                    {
                        _device.Sensor33 = db.Sensors.Find(sensors.ElementAt(32).Id);
                    }
                    if (sensors.Count() >= 34 && sensors.ElementAt(33) != null)
                    {
                        _device.Sensor34 = db.Sensors.Find(sensors.ElementAt(33).Id);
                    }
                    if (sensors.Count() >= 35 && sensors.ElementAt(34) != null)
                    {
                        _device.Sensor35 = db.Sensors.Find(sensors.ElementAt(34).Id);
                    }
                    if (sensors.Count() >= 36 && sensors.ElementAt(35) != null)
                    {
                        _device.Sensor36 = db.Sensors.Find(sensors.ElementAt(35).Id);
                    }
                    if (sensors.Count() >= 37 && sensors.ElementAt(36) != null)
                    {
                        _device.Sensor37 = db.Sensors.Find(sensors.ElementAt(36).Id);
                    }
                    if (sensors.Count() >= 38 && sensors.ElementAt(37) != null)
                    {
                        _device.Sensor38 = db.Sensors.Find(sensors.ElementAt(37).Id);
                    }
                    if (sensors.Count() >= 39 && sensors.ElementAt(38) != null)
                    {
                        _device.Sensor39 = db.Sensors.Find(sensors.ElementAt(38).Id);
                    }
                    if (sensors.Count() >= 40 && sensors.ElementAt(39) != null)
                    {
                        _device.Sensor40 = db.Sensors.Find(sensors.ElementAt(39).Id);
                    }
                    db.SaveChanges();
                    ((DefaultDevices)this.Owner).UpdateDevicesGrid();
                }
                this.Close();
                this.Owner.Activate();
            }
            else { }
        }

        public void UpdateSensorGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                SensorGrid.Items.Clear();
                foreach (var sensor in sensors)
                {
                    SensorGrid.Items.Add(sensor);
                }
                SensorCount = sensors.Count();
            }
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


        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        private void Button_ClickAddSensors(object sender, RoutedEventArgs e)
        {
            AddSensors addSensors = new AddSensors(sensors)
            {
                Owner = this
            };
            addSensors.Show();
        }
    }
}
