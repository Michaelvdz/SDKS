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
    /// Interaction logic for DefaultDevices.xaml
    /// </summary>
    public partial class DefaultDevices : Window
    {
        PresetDevs selectedDevice = null;
        public DefaultDevices()
        {
            InitializeComponent();
            UpdateDevicesGrid();
        }

        public void UpdateDevicesGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                List<PresetDevs> devices = db.DefaultDevices.ToList();
                Console.WriteLine(devices.Count);
                DefaultDeviceGrid.Items.Clear();
                foreach (var device in devices)
                {
                    DefaultDeviceGrid.Items.Add(device);
                }
            }
            selectedDevice = null;
        }

        private void DefaultDeviceGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void DefaultDeviceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PresetDevs device = (PresetDevs)DefaultDeviceGrid.SelectedItem;
            if (device != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedDevice = db.DefaultDevices.Find(device.Id);
                }
            }
        }
        private void Button_ClickNewDefaultDevice(object sender, RoutedEventArgs e)
        {
            NewDefaultDevice newDefaultDevice = new NewDefaultDevice()
            {
                Owner = this
            };
            newDefaultDevice.Show();
        }

        private void Button_ClickUpdateDefaultDevice(object sender, RoutedEventArgs e)
        {
            UpdateDefaultDevice updateDefaultDevice = new UpdateDefaultDevice(selectedDevice)
            {
                Owner = this
            };
            updateDefaultDevice.Show();
        }

        private void Button_ClickDeleteDefaultDevice(object sender, RoutedEventArgs e)
        {
            if (selectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een toestel om te verwijderen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Weet u zeker dat u toestel " + selectedDevice.Name + " wilt verwijderen?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    PresetDevs device = (PresetDevs)DefaultDeviceGrid.SelectedItem;
                    if (device != null)
                    {
                        using (var db = new ServiceProgramContext())
                        {
                            selectedDevice = db.DefaultDevices.Find(device.Id);
                            db.DefaultDevices.Remove(selectedDevice);
                            db.SaveChanges();
                        }
                    }
                }
                UpdateDevicesGrid();
            }
        }
    }
}
