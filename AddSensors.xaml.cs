using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
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
    /// Interaction logic for AddSensors.xaml
    /// </summary>
    public partial class AddSensors : Window
    {
        Sensor selectedSensor;
        Sensor selectedDeviceSensor;
        Device Device;
        List<Sensor> sensoren;

        public AddSensors()
        {
            InitializeComponent();
            DataContext = this;
            UpdateSensorGrid();
            UpdateDeviceSensorGrid();
        }

        public AddSensors(Device device)
        {
            InitializeComponent();
            DataContext = this;
            Device = device;
            UpdateSensorGrid();
            UpdateDeviceSensorGrid();
        }

        public AddSensors(List<Sensor> sensors)
        {
            InitializeComponent();
            DataContext = this;
            sensoren = new List<Sensor>(sensors);
            UpdateSensorGrid();
            UpdateDeviceSensorGrid(sensors);
        }
        public AddSensors(List<Sensor> sensors, Device device)
        {
            InitializeComponent();
            DataContext = this;
            sensoren = new List<Sensor>(sensors);
            Device = device;
            UpdateSensorGrid();
            UpdateDeviceSensorGrid(sensors);
        }

        private void SensorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sensor sensor = (Sensor)SensorGrid.SelectedItem;
            if (sensor != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedSensor = db.Sensors.Find(sensor.Id);
                }
            }
        }

        private void SensorGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        public void UpdateSensorGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                List<Sensor> sensors = db.Sensors.ToList();
                sensors.Sort((x, y) => String.Compare(x.Name, y.Name));
                SensorGrid.Items.Clear();
                foreach (var sensor in sensors)
                {
                   SensorGrid.Items.Add(sensor);
                }
            }
        }

        private void DeviceSensorGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sensor sensor = (Sensor)DeviceSensorGrid.SelectedItem;
            if (sensor != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedDeviceSensor = db.Sensors.Find(sensor.Id);
                }
            }
        }

        private void DeviceSensorGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }

        public void UpdateDeviceSensorGrid()
        {
            if (Device != null)
            {
                Console.WriteLine("False");
                using (var db = new ServiceProgramContext())
                {
                    /*
                    Device = db.Devices.Find(Device.Id);
                    List<Sensor> sensors = new List<Sensor>();
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
                    }*/
                    DeviceSensorGrid.Items.Clear();
                    foreach (var sensor in sensoren)
                    {
                        DeviceSensorGrid.Items.Add(sensor);
                    }
                }
            }
            else
            {
                DeviceSensorGrid.Items.Clear();
                foreach (var sensor in sensoren)
                {
                    DeviceSensorGrid.Items.Add(sensor);
                }
            }
        }

        public void UpdateDeviceSensorGrid(List<Sensor> sensors)
        {
            DeviceSensorGrid.Items.Clear();
            foreach (var sensor in sensors)
            {
                DeviceSensorGrid.Items.Add(sensor);
            }
        }

        private void Button_ClickAdd(object sender, RoutedEventArgs e)
        {
            if (selectedSensor == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een sensor om te toe te voegen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (Device != null)
                {
                    using (var db = new ServiceProgramContext())
                    {
                        if (Device != null) {
                            Device = db.Devices.Find(Device.Id);
                            Sensor sensor = db.Sensors.Find(selectedSensor.Id);
                            if (Device.Sensor1 == sensor || Device.Sensor2 == sensor || Device.Sensor3 == sensor || Device.Sensor4 == sensor ||
                                Device.Sensor5 == sensor || Device.Sensor6 == sensor || Device.Sensor7 == sensor || Device.Sensor8 == sensor)
                            {
                                MessageBoxResult result = MessageBox.Show("Deze sensor is reeds toegevoegd.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                            else
                            {
                                if (Device.Sensor1 == null)
                                {
                                    //Device.Sensor1 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor2 == null)
                                {
                                    //Device.Sensor2 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor3 == null)
                                {
                                    //Device.Sensor3 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor4 == null)
                                {
                                    //Device.Sensor4 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor5 == null)
                                {
                                    //Device.Sensor5 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor6 == null)
                                {
                                    //Device.Sensor6 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor7 == null)
                                {
                                    //Device.Sensor7 = sensor;
                                    sensoren.Add(sensor);
                                }
                                else if (Device.Sensor8 == null)
                                {
                                    //Device.Sensor8 = sensor;
                                    sensoren.Add(sensor);
                                }
                                db.SaveChanges();

                            }
                        }
                        UpdateDeviceSensorGrid();
                        ((UpdateDevice)this.Owner).UpdateSensorGrid(sensoren, -1);
                    }
                }
                else
                {
                    using (var db = new ServiceProgramContext())
                    {
                        Sensor sensor = db.Sensors.Find(selectedSensor.Id);
                        bool inthelist = false;
                        foreach(var sens in sensoren)
                        {
                            if(sensor.Id == sens.Id)
                            {
                                inthelist = true;
                                break;
                            }
                        }

                        if (inthelist){
                            MessageBoxResult result = MessageBox.Show("Deze sensor is reeds toegevoegd.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                        {
                            sensoren.Add(sensor);
                        }
                    }
                    UpdateDeviceSensorGrid();
                    try
                    {
                        ((NewDefaultDevice)this.Owner).Sensors = sensoren;
                        ((NewDefaultDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ((NewDevice)this.Owner).Sensors = sensoren;
                        ((NewDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ((UpdateDevice)this.Owner).sensors = sensoren;
                        ((UpdateDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ((UpdateDefaultDevice)this.Owner).sensors = sensoren;
                        ((UpdateDefaultDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            if (selectedDeviceSensor == null || (sensoren!= null && sensoren.Count() == 0))
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een sensor om te verwijderen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (Device != null)
                {
                    var index = -1;
                    using (var db = new ServiceProgramContext())
                    {
                        Device = db.Devices.Find(Device.Id);
                        Sensor sensor = db.Sensors.Find(selectedDeviceSensor.Id);
                        
                        if (Device.Sensor1 == sensor)
                        {
                            index = 1;
                            /*
                            Device.Sensor1 = null;
                            if (Device.Sensor2 != null)
                            {
                                Device.Sensor1 = Device.Sensor2;
                                Device.Alarm1H = Device.Alarm2H;
                                Device.Alarm1L = Device.Alarm2L;
                                Device.Alarm1S = Device.Alarm2S;
                                Device.Alarm1T = Device.Alarm2T;
                                Device.Alarm2H = null;
                                Device.Alarm2L = null;
                                Device.Alarm2S = null;
                                Device.Alarm2T = null;

                                Device.Sensor2 = null;
                                if (Device.Sensor3 != null)
                                {
                                    Device.Sensor2 = Device.Sensor3;
                                    Device.Alarm2H = Device.Alarm3H;
                                    Device.Alarm2L = Device.Alarm3L;
                                    Device.Alarm2S = Device.Alarm3S;
                                    Device.Alarm2T = Device.Alarm3T;
                                    Device.Alarm3H = null;
                                    Device.Alarm3L = null;
                                    Device.Alarm3S = null;
                                    Device.Alarm3T = null;
                                    Device.Sensor3 = null;
                                    if (Device.Sensor4 != null)
                                    {
                                        Device.Sensor3 = Device.Sensor4;
                                        Device.Alarm3H = Device.Alarm4H;
                                        Device.Alarm3L = Device.Alarm4L;
                                        Device.Alarm3S = Device.Alarm4S;
                                        Device.Alarm3T = Device.Alarm4T;
                                        Device.Alarm4H = null;
                                        Device.Alarm4L = null;
                                        Device.Alarm4S = null;
                                        Device.Alarm4T = null;
                                        Device.Sensor4 = null;
                                        if (Device.Sensor5 != null)
                                        {
                                            Device.Sensor4 = Device.Sensor5;
                                            Device.Alarm4H = Device.Alarm5H;
                                            Device.Alarm4L = Device.Alarm5L;
                                            Device.Alarm4S = Device.Alarm5S;
                                            Device.Alarm4T = Device.Alarm5T;
                                            Device.Alarm5H = null;
                                            Device.Alarm5L = null;
                                            Device.Alarm5S = null;
                                            Device.Alarm5T = null;
                                            Device.Sensor5 = null;
                                            if (Device.Sensor6 != null)
                                            {
                                                Device.Sensor5 = Device.Sensor6;
                                                Device.Alarm5H = Device.Alarm6H;
                                                Device.Alarm5L = Device.Alarm6L;
                                                Device.Alarm5S = Device.Alarm6S;
                                                Device.Alarm5T = Device.Alarm6T;
                                                Device.Alarm6H = null;
                                                Device.Alarm6L = null;
                                                Device.Alarm6S = null;
                                                Device.Alarm6T = null;
                                                Device.Sensor6 = null;
                                                if (Device.Sensor7 != null)
                                                {
                                                    Device.Sensor6 = Device.Sensor7;
                                                    Device.Alarm6H = Device.Alarm7H;
                                                    Device.Alarm6L = Device.Alarm7L;
                                                    Device.Alarm6S = Device.Alarm7S;
                                                    Device.Alarm6T = Device.Alarm7T;
                                                    Device.Alarm7H = null;
                                                    Device.Alarm7L = null;
                                                    Device.Alarm7S = null;
                                                    Device.Alarm7T = null;
                                                    Device.Sensor7 = null;
                                                    if (Device.Sensor8 != null)
                                                    {
                                                        Device.Sensor7 = Device.Sensor8;
                                                        Device.Alarm7H = Device.Alarm8H;
                                                        Device.Alarm7L = Device.Alarm8L;
                                                        Device.Alarm7S = Device.Alarm8S;
                                                        Device.Alarm7T = Device.Alarm8T;
                                                        Device.Alarm8H = null;
                                                        Device.Alarm8L = null;
                                                        Device.Alarm8S = null;
                                                        Device.Alarm8T = null;
                                                        Device.Sensor8 = null;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }*/
                        }
                        else if (Device.Sensor2 == sensor)
                        {
                            index = 2;
                            /*
                            Device.Sensor2 = null;
                            if (Device.Sensor3 != null)
                            {
                                Device.Sensor2 = Device.Sensor3;
                                Device.Sensor3 = null;
                                if (Device.Sensor4 != null)
                                {
                                    Device.Sensor3 = Device.Sensor4;
                                    Device.Sensor4 = null;
                                    if (Device.Sensor5 != null)
                                    {
                                        Device.Sensor4 = Device.Sensor5;
                                        Device.Sensor5 = null;
                                        if (Device.Sensor6 != null)
                                        {
                                            Device.Sensor5 = Device.Sensor6;
                                            Device.Sensor6 = null;
                                            if (Device.Sensor7 != null)
                                            {
                                                Device.Sensor6 = Device.Sensor7;
                                                Device.Sensor7 = null;
                                                if (Device.Sensor8 != null)
                                                {
                                                    Device.Sensor7 = Device.Sensor8;
                                                    Device.Sensor8 = null;
                                                }
                                            }
                                        }
                                    }
                                }
                            }*/
                        }
                        else if (Device.Sensor3 == sensor)
                        {
                            index = 3;
                           /* Device.Sensor3 = null;
                            if (Device.Sensor4 != null)
                            {
                                Device.Sensor3 = Device.Sensor4;
                                Device.Sensor4 = null;
                                if (Device.Sensor5 != null)
                                {
                                    Device.Sensor4 = Device.Sensor5;
                                    Device.Sensor5 = null;
                                    if (Device.Sensor6 != null)
                                    {
                                        Device.Sensor5 = Device.Sensor6;
                                        Device.Sensor6 = null;
                                        if (Device.Sensor7 != null)
                                        {
                                            Device.Sensor6 = Device.Sensor7;
                                            Device.Sensor7 = null;
                                            if (Device.Sensor8 != null)
                                            {
                                                Device.Sensor7 = Device.Sensor8;
                                                Device.Sensor8 = null;
                                            }
                                        }
                                    }
                                }
                            }*/

                        }
                        else if (Device.Sensor4 == sensor)
                        {
                            index = 4;
                           /* Device.Sensor4 = null;
                            if (Device.Sensor5 != null)
                            {
                                Device.Sensor4 = Device.Sensor5;
                                Device.Sensor5 = null;
                                if (Device.Sensor6 != null)
                                {
                                    Device.Sensor5 = Device.Sensor6;
                                    Device.Sensor6 = null;
                                    if (Device.Sensor7 != null)
                                    {
                                        Device.Sensor6 = Device.Sensor7;
                                        Device.Sensor7 = null;
                                        if (Device.Sensor8 != null)
                                        {
                                            Device.Sensor7 = Device.Sensor8;
                                            Device.Sensor8 = null;
                                        }
                                    }
                                }
                            }*/
                        }
                        else if (Device.Sensor5 == sensor)
                        {
                            index = 5;
                           /* Device.Sensor5 = null;
                            if (Device.Sensor6 != null)
                            {
                                Device.Sensor5 = Device.Sensor6;
                                Device.Sensor6 = null;
                                if (Device.Sensor7 != null)
                                {
                                    Device.Sensor6 = Device.Sensor7;
                                    Device.Sensor7 = null;
                                    if (Device.Sensor8 != null)
                                    {
                                        Device.Sensor7 = Device.Sensor8;
                                        Device.Sensor8 = null;
                                    }
                                }
                            }*/
                        }
                        else if (Device.Sensor6 == sensor)
                        {
                            index = 6;
                            /*Device.Sensor6 = null;
                            if (Device.Sensor7 != null)
                            {
                                Device.Sensor6 = Device.Sensor7;
                                Device.Sensor7 = null;
                                if (Device.Sensor8 != null)
                                {
                                    Device.Sensor7 = Device.Sensor8;
                                    Device.Sensor8 = null;
                                }
                            }*/
                        }
                        else if (Device.Sensor7 == sensor)
                        {
                            index = 7;
                           /* Device.Sensor7 = null;
                            if (Device.Sensor8 != null)
                            {
                                Device.Sensor7 = Device.Sensor8;
                                Device.Sensor8 = null;
                            }*/
                        }
                        else if (Device.Sensor8 == sensor)
                        {
                            index = 8;
                            /*Device.Sensor8 = null;*/
                        }
                        Console.WriteLine("Index:" + index);
                        sensoren.RemoveAt(index-1);
                        db.SaveChanges();
                    }
                    UpdateDeviceSensorGrid();
                    ((UpdateDevice)this.Owner).UpdateSensorGrid(sensoren, index);

                }
                else
                {
                    using (var db = new ServiceProgramContext())
                    {
                        Sensor sensor = db.Sensors.Find(selectedDeviceSensor.Id);
                        int index = 0;
                        for (int i = 0; i < sensoren.Count(); i++)
                        {
                            if (sensor.Id == sensoren.ElementAt(i).Id)
                            {
                                index = i;
                            }
                        }
                        sensoren.RemoveAt(index);
                    }
                    UpdateDeviceSensorGrid();
                    try
                    {
                        ((NewDefaultDevice)this.Owner).Sensors = sensoren;
                        ((NewDefaultDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ((NewDevice)this.Owner).Sensors = sensoren;
                        ((NewDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ((UpdateDevice)this.Owner).sensors = sensoren;
                        ((UpdateDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        ((UpdateDefaultDevice)this.Owner).sensors = sensoren;
                        ((UpdateDefaultDevice)this.Owner).UpdateSensorGrid();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

    }
}
