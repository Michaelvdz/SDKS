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
    /// Interaction logic for DeletedDevices.xaml
    /// </summary>
    public partial class DeletedDevices : Window
    {

        Device selectedDevice = null;
        String Color = "Red";
        string SearchText = string.Empty;

        public DeletedDevices()
        {
            InitializeComponent();
            UpdateDevicesGrid();
        }

        public void UpdateDevicesGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                var devices = (from d in db.Devices where d.Deleted == true select d).ToList();
                DeviceGrid.Items.Clear();
                foreach (var device in devices)
                {
                    CustomDevice cdevice = new CustomDevice(device, device.Client.Company);
                    DeviceGrid.Items.Add(cdevice);
                }
            }
        }

        private void DeviceGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void DeviceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomDevice device = (CustomDevice)DeviceGrid.SelectedItem;
            if (device != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedDevice = db.Devices.Find(device.Id);
                }
            }
        }

        class CustomDevice
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String SerialNumber { get; set; }
            public DateTime LastCheck { get; set; }
            public DateTime NextCheck { get; set; }
            public String Client { get; set; }
            public string Color { get; set; }

            public CustomDevice(Device dev, String Company)
            {
                Id = dev.Id;
                Name = dev.Name;
                Client = dev.Client.Company;
                SerialNumber = dev.SerialNumber;
                LastCheck = dev.LastCheck;
                NextCheck = dev.NextCheck;
            }
        }

        private void Button_ClickDevice(object sender, RoutedEventArgs e)
        {
            if (selectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om terug te zetten.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Weet u zeker dat u toestel " + selectedDevice.Name + " met serienummer " + selectedDevice.SerialNumber + " wilt terugzetten?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new ServiceProgramContext())
                    {
                        Device dev = db.Devices.Find(selectedDevice.Id);
                        dev.Deleted = false;
                        db.SaveChanges();
                        UpdateDevicesGrid();
                        ((MainWindow)this.Owner).UpdateClientsGrid();
                    }
                }
                else
                {

                }
            }
        }
    }
}
