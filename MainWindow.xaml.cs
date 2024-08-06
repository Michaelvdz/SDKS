using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Service_Program
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Device selectedDevice = null;
        Client selectedClient = null;
        String Color = "Red";
        string SearchText = string.Empty;
        int verhuurId = 0;
        int newestCheckId = -1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Certificate cert = new Certificate();
            /*
            using (var db = new ServiceProgramContext())
            {
                List<Device> devices = db.Devices.ToList();
                foreach (var device in devices)
                {
                    List<CheckUp> checks = db.CheckUps.Where(x => x.Device.Id == device.Id).ToList();
                    CheckUp lcheck = new CheckUp();
                    foreach (var check in checks)
                    {
                        if(check.Date > lcheck.Date)
                        {
                            lcheck = check;
                        }
                    }
                    device.LastCheck = lcheck.Date;
                    device.NextCheck = lcheck.NextDate;
                }
                db.SaveChanges();
            }
            */
            UpdateClientsGrid();
        }

        //Upgrades Clients grid with clients in database
        public void UpdateClientsGrid()
        {
            using (var db = new ServiceProgramContext())
            {

                
                var query = from s in db.Settings
                            where s.Key == "Verhuur"
                            select s.Value;
                var currentNumber = query.First();
                verhuurId = Convert.ToInt32(currentNumber);


                List<Client> clients = db.Clients.ToList();
                clients.Sort((x, y) => String.Compare(x.Company, y.Company));
                ClientGrid.Items.Clear();
                /*foreach (var client in clients)
                {
                    ClientGrid.Items.Add(client);
                }*/
                foreach (var client in clients)
                {
                    if (DateTime.Compare((DateTime)client.KalibratieMaand, DateTime.MinValue) != 0)
                    {
                        Console.WriteLine("test");
                        if ((DateTime.Today - (DateTime)client.KalibratieMaand).TotalDays > 7)
                        {
                            client.KalibratieMaand = DateTime.MinValue;
                        }
                    }
                    CustomClient cclient = new CustomClient(client);
                    ClientGrid.Items.Add(cclient);
                }
                db.SaveChanges();
            }
            selectedDevice = null;
        }

        //Upgrades Devices grid with devices in the database for a given client
        public void UpdateDevicesGrid(CustomClient client)
        {
            if(client != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    var devices = from d in db.Devices where d.Client.Id == client.Id && d.Deleted !=true select d;
                    String comp = client.Company;
                    DeviceGrid.Items.Clear();
                    foreach (var device in devices)
                    {
                        CustomDevice cdevice = new CustomDevice(device, client.Id, verhuurId, comp);
                        DeviceGrid.Items.Add(cdevice);
                    }
                }
            }
            else
            {
                DeviceGrid.Items.Clear();
            }
        }
        public void UpdateDevicesGrid(Client client)
        {
            if (client != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    var devices = from d in db.Devices where d.Client.Id == client.Id && d.Deleted != true select d;
                    String comp = client.Company;
                    DeviceGrid.Items.Clear();
                    foreach (var device in devices)
                    {
                        CustomDevice cdevice = new CustomDevice(device, client.Id, verhuurId, comp);
                        DeviceGrid.Items.Add(cdevice);
                    }
                }
            }
            else
            {
                DeviceGrid.Items.Clear();
            }
        }
        //Upgrades Devices grid with devices in the database for a given client
        public void UpdateDevicesGrid(CustomClient client , int dev)
        {
            int i = 0;
            int j = 0;
            if (client != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    var devices = from d in db.Devices where d.Client.Id == client.Id && d.Deleted != true select d;
                    String comp = client.Company;
                    DeviceGrid.Items.Clear();
                    foreach (var device in devices)
                    {
                        CustomDevice cdevice = new CustomDevice(device, client.Id, verhuurId, comp);
                        DeviceGrid.Items.Add(cdevice);
                        if(cdevice.Id == dev)
                        {
                            selectedDevice = device;
                            j = i;
                        }
                        i++;
                    }
                }
            }
            else
            {
                DeviceGrid.Items.Clear();
            }
            DeviceGrid.SelectedItem = DeviceGrid.Items[j];
            DeviceGrid.ScrollIntoView(DeviceGrid.Items[j]);
            DeviceGrid.UpdateLayout();
            DeviceGrid.ScrollIntoView(DeviceGrid.Items[j]);
        }
        public void UpdateDevicesGrid(Client client, int dev)
        {
            int i = 0;
            int j = 0;
            if (client != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    var devices = from d in db.Devices where d.Client.Id == client.Id && d.Deleted != true select d;
                    String comp = client.Company;
                    DeviceGrid.Items.Clear();
                    foreach (var device in devices)
                    {
                        CustomDevice cdevice = new CustomDevice(device, client.Id, verhuurId, comp);
                        DeviceGrid.Items.Add(cdevice);
                        if (cdevice.Id == dev)
                        {
                            selectedDevice = device;
                            j = i;
                        }
                        i++;
                    }
                }
            }
            else
            {
                DeviceGrid.Items.Clear();
            }
            DeviceGrid.SelectedItem = DeviceGrid.Items[j];
            DeviceGrid.ScrollIntoView(DeviceGrid.Items[j]);
            DeviceGrid.UpdateLayout();
            DeviceGrid.ScrollIntoView(DeviceGrid.Items[j]);
        }

        private void ClientGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomClient client = (CustomClient)ClientGrid.SelectedItem;
            if(client != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedClient = db.Clients.Find(client.Id);
                    selectedDevice = null;
                }
                Console.WriteLine(verhuurId);
                Console.WriteLine(selectedClient.Id);
                if (verhuurId == selectedClient.Id)
                {
                    AanwezigHeader.Visibility = Visibility.Visible;
                }
                else
                {
                    AanwezigHeader.Visibility = Visibility.Collapsed;
                }
            }
            UpdateDevicesGrid(client);
        }

        private void ClientGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()+1).ToString();
        }
        private void DeviceGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void DeviceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomDevice device = (CustomDevice)DeviceGrid.SelectedItem;
            if(device != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    selectedDevice = db.Devices.Find(device.Id);
                    /*Device _dev = db.Devices.Find(device.Id);
                    Client _cli = db.Clients.Find(_dev.Client.Id);

                    for (int i = 0; i < ClientGrid.Items.Count; i++)
                    {
                        DataGridRow row = (DataGridRow)ClientGrid.ItemContainerGenerator.ContainerFromIndex(i);
                        Client item = (Client)ClientGrid.Items[i];
                        if (item.Id == _cli.Id)
                        {
                            ClientGrid.SelectedItem = (object)item;
                            ClientGrid.ScrollIntoView((object)item);
                        }
                    }*/
                    
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewClient newClient = new NewClient
            {
                Owner = this
            };
            newClient.Show();
        }

        private void Button_ClickDevice(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om een toestel toe te voegen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {

                NewDevice newDevice = new NewDevice(selectedClient)
                {
                    Owner = this
                };
                newDevice.Show();
            }
        }

        private void Button_ClickKalibration(object sender, RoutedEventArgs e)
        {
            if(selectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een toestel voor kalibratie.","", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                NewCheck newCheck = new NewCheck(selectedDevice)
                {
                    Owner = this
                };
                newCheck.Show();
            }
        }
        private void Button_ClickEditDevice(object sender, RoutedEventArgs e)
        {
            if (selectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een toestel om te bewerken.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                using (var db = new ServiceProgramContext())
                {
                    int id = selectedDevice.Id;
                    Device _device = db.Devices.Find(id);
                    UpdateDevice updateDevice = new UpdateDevice(_device, DeviceGrid.SelectedIndex)
                    {
                        Owner = this
                    };
                    updateDevice.Show();
                }
            }
        }
        private void Button_ClickEditClient(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om te bewerken.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                UpdateClient updateClient = new UpdateClient(selectedClient)
                {
                    Owner = this
                };
                updateClient.Show();
            }
        }
        private void Button_ClickCopyDevice(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om een toestel van te kopiëren.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (selectedDevice == null)
                {
                    MessageBoxResult result = MessageBox.Show("Selecteer een toestel om te kopiëren.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                }
                else
                {
                    NewDevice newDevice = new NewDevice(selectedDevice, selectedClient)
                    {
                        Owner = this
                    };
                    newDevice.Show();
                }
            }

        }
        private void Button_ClickDeleteDevice(object sender, RoutedEventArgs e)
        {
            if (selectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een toestel om te verwijderen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Weet u zeker dat u toestel " + selectedDevice.Name + " met serienummer " + selectedDevice.SerialNumber + " wilt verwijderen?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new ServiceProgramContext())
                    {
                        int id = selectedDevice.Id;
                        Device _device = db.Devices.Find(id);
                        //DeleteCheckups(_device);
                        //db.Devices.Remove(_device);
                        _device.Deleted = true;
                        _device.Tdelete = DateTime.Now;
                        db.SaveChanges();
                        UpdateDevicesGrid(selectedClient);
                        selectedDevice = null;
                    }
                }
                else
                { }
            }
        }
        private void Button_ClickDeleteClient(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om te verwijderen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Weet u zeker dat u klant "+selectedClient.Company+" en eventueel bijhorende toestellen wilt verwijderen?", "", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new ServiceProgramContext())
                    {
                        var devices = from d in db.Devices where d.Client.Id == selectedClient.Id select d;
                        foreach (var device in devices)
                        {
                            DeleteCheckups(device);
                            db.Devices.Remove(device);
                        }
                        Client _client = new Client() { Id = selectedClient.Id };
                        db.Clients.Attach(_client);
                        db.Clients.Remove(_client);
                        db.SaveChanges();
                        UpdateClientsGrid();
                    }
                }
                else
                { }
            }
        }
        private void Button_ClickDeviceDetails(object sender, RoutedEventArgs e)
        {
            if (selectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een toestel om te in detail te bekijken.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DeviceDetail deviceDetail = new DeviceDetail(selectedDevice)
                {
                    Owner = this
                };
                deviceDetail.Show();
            }
        }

        private void Button_ClickTeKalibreren(object sender, RoutedEventArgs e)
        {
            TeKalibreren teKalibreren = new TeKalibreren()
            {
                Owner = this
            };
            teKalibreren.Show();
        }

        private void Button_ClickTeKalibrerenKlanten(object sender, RoutedEventArgs e)
        {
            TeKalibrerenKlanten teKalibrerenklanten = new TeKalibrerenKlanten()
            {
                Owner = this
            };
            teKalibrerenklanten.Show();
        }

        private void SearchClients(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            SearchText = t.Text.ToString();
            using (var db = new ServiceProgramContext())
            {
                List<Client> clients = db.Clients.ToList();
                ClientGrid.Items.Clear();
                foreach (var client in clients)
                {
                    String id = client.Id.ToString();
                    if(id.ToLower().StartsWith(SearchText.ToLower()) || (client.Company != null && client.Company.ToLower().Contains(SearchText.ToLower())) || (client.Contact != null && client.Contact.ToLower().Contains(SearchText.ToLower())) || (client.Email != null && client.Email.ToLower().StartsWith(SearchText.ToLower())) ||
                        (client.Phone != null && client.Phone.ToLower().StartsWith(SearchText.ToLower())) || (client.MobilePhone != null && client.MobilePhone.ToLower().StartsWith(SearchText.ToLower())) || (client.Address1 != null && client.Address1.ToLower().StartsWith(SearchText.ToLower())) || (client.Address2 != null && client.Address2.ToLower().StartsWith(SearchText.ToLower())))
                    {
                        CustomClient client2 = new CustomClient(client);
                        ClientGrid.Items.Add(client2);
                    }
                }
                List<Device> devices = db.Devices.ToList();
                DeviceGrid.Items.Clear();
                foreach (var device in devices)
                {
                    if (!device.Deleted)
                    {
                        if ( (device.SerialNumber != null && device.SerialNumber.ToLower().Contains(SearchText.ToLower())) || (device.Name != null && device.Name.ToLower().Contains(SearchText.ToLower())))
                        {
                            CustomDevice cdevice = new CustomDevice(device, device.Client.Id, verhuurId, device.Client.Company);
                            DeviceGrid.Items.Add(cdevice);
                            var match = ClientGrid.Items.Contains(device.Client);
                            if (!match)
                            {
                                CustomClient client2 = new CustomClient(device.Client);
                                ClientGrid.Items.Add(client2);

                            }
                        }
                    }
                }
            }
            selectedClient = null;
            selectedDevice = null;
        }

        private void DeleteCheckups(Device device)
        {
            using (var db = new ServiceProgramContext())
            {
                var _checks = from c in db.CheckUps where c.Device.Id == device.Id select c;
                foreach (var check in _checks)
                {
                    db.CheckUps.Remove(check);
                }
                db.SaveChanges();
            }
        }

        private void Button_ClickSensoren(object sender, RoutedEventArgs e)
        {
            Sensoren sensoren = new Sensoren()
            {
                Owner = this
            };
            sensoren.Show();
        }

        private void Button_ClickSettings(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings()
            {
                Owner = this
            };
            settings.Show();
        }

        private void Button_ClickDefaultDevices(object sender, RoutedEventArgs e)
        {
            DefaultDevices DefaultDevices = new DefaultDevices()
            {
                Owner = this
            };
            DefaultDevices.Show();
        }

        private void Button_ClickDeletedDevices(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om toestellen op te lijsten.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                DeletedDevices deletedDevices = new DeletedDevices()
                {
                    Owner = this
                };
                deletedDevices.Show();
            }
        }

        private void Button_AlleToestellen(object sender, RoutedEventArgs e)
        {
            if (selectedClient == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een klant om toestellen op te lijsten.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                ExcelCreator creator = new ExcelCreator(selectedClient);
                creator.OpenFile();
            }
        }
        private void Button_MassaKalibratie(object sender, RoutedEventArgs e)
        {
            if (DeviceGrid.SelectedItems == null || DeviceGrid.SelectedItems.Count == 0)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een of meerdere toestelen om de klant te mailen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                IList items = DeviceGrid.SelectedItems;
                Device _device = new Device();
                _device.Id = ((CustomDevice)items[0]).Id;
                NewCheck newCheck = new NewCheck(_device, true)
                {
                    Owner = this
                };
                newCheck.ShowDialog();
                Console.WriteLine("Saved cert id: " + newestCheckId);
                using (var db = new ServiceProgramContext())
                {
                    for (int i = 1; i < items.Count; i++)
                    {
                        int Knummer;
                        String KCNummer;
                        Setting setting = db.Settings.Where(s => s.Key == "KalibratieNummer").First();
                        CheckUp Check = db.CheckUps.Find(newestCheckId);
                        Console.WriteLine("Check number:" + Check.Number);
                        _device = db.Devices.Find(((CustomDevice)items[i]).Id);
                        var query = from s in db.Settings
                                    where s.Key == "KalibratieNummer"
                                    select s.Value;
                        var currentNumber = query.First();
                        Knummer = Convert.ToInt32(currentNumber);
                        DateTime Date = DateTime.Today;
                        KCNummer = Date.Year.ToString();
                        KCNummer = KCNummer + "_" + Knummer.ToString();
                        String Number = KCNummer;
                        var checkUp = new CheckUp()
                        {
                            Date = Check.Date,
                            NextDate = Check.NextDate,
                            Device = _device,
                            Note = Check.Note,
                            Sens1 = _device.Sensor1,
                            Sens1C = Check.Sens1C,
                            Sens1VK = Check.Sens1VK,
                            Sens1ZK = Check.Sens1ZK,
                            Sens1NK = Check.Sens1NK,
                            Sens2 = _device.Sensor2,
                            Sens2C = Check.Sens2C,
                            Sens2VK = Check.Sens2VK,
                            Sens2ZK = Check.Sens2ZK,
                            Sens2NK = Check.Sens2NK,
                            Sens3 = _device.Sensor3,
                            Sens3C = Check.Sens3C,
                            Sens3VK = Check.Sens3VK,
                            Sens3ZK = Check.Sens3ZK,
                            Sens3NK = Check.Sens3NK,
                            Sens4 = _device.Sensor4,
                            Sens4C = Check.Sens4C,
                            Sens4VK = Check.Sens4VK,
                            Sens4ZK = Check.Sens4ZK,
                            Sens4NK = Check.Sens4NK,
                            Sens5 = _device.Sensor5,
                            Sens5C = Check.Sens5C,
                            Sens5VK = Check.Sens5VK,
                            Sens5ZK = Check.Sens5ZK,
                            Sens5NK = Check.Sens5NK,
                            Sens6 = _device.Sensor6,
                            Sens6C = Check.Sens6C,
                            Sens6VK = Check.Sens6VK,
                            Sens6ZK = Check.Sens6ZK,
                            Sens6NK = Check.Sens6NK,
                            Sens7 = _device.Sensor7,
                            Sens7C = Check.Sens7C,
                            Sens7VK = Check.Sens7VK,
                            Sens7ZK = Check.Sens7ZK,
                            Sens7NK = Check.Sens7NK,
                            Sens8 = _device.Sensor8,
                            Sens8C = Check.Sens8C,
                            Sens8VK = Check.Sens8VK,
                            Sens8ZK = Check.Sens8ZK,
                            Sens8NK = Check.Sens8NK,
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
                            Gas = Check.Gas,
                            Number = Number,
                            Reference = Check.Reference,
                            HideAlarms = Check.HideAlarms,
                            HideConcentrations = Check.HideConcentrations,
                            Nieuw = Check.Nieuw,
                            DateAndTime = Check.DateAndTime,
                            FilterExtern = Check.FilterExtern,
                            FilterIntern = Check.FilterIntern,
                            Latch = Check.Latch,
                            Krokodillenclip = Check.Krokodillenclip,
                            Pomptest = Check.Pomptest,
                            Pomprevisie = Check.Pomprevisie,
                            Lamprevisie = Check.Lamprevisie,
                            AutoZero = Check.AutoZero,
                            Sinterfilter = Check.Sinterfilter,
                            Frontcover = Check.Frontcover,
                            A1NA = Check.A1NA,
                            A1A = Check.A1A,
                            SwitchOffNA = Check.SwitchOffNA,
                            SensorVervangen = Check.SensorVervangen,
                            ExtaOpmerkingen = Check.ExtaOpmerkingen,
                            FW = Check.FW,
                            Details = Check.Details,
                        };
                        db.CheckUps.Add(checkUp);
                        DateTime Date2, Next2;
                        DateTime sixmonths = DateTime.Today.AddMonths(6);
                        DateTime? Next = sixmonths;
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
                        /*if (_device.LastCheck < Date2)
                        {
                            _device.LastCheck = Date2;
                        }
                        if (_device.NextCheck < Next2)
                        {
                            _device.NextCheck = Next2;
                        }*/
                        _device.LastCheck = Check.Device.LastCheck;
                        _device.NextCheck = Check.Device.NextCheck;
                        setting.Value = (Knummer + 1).ToString();
                        db.SaveChanges();
                    }
                }
                UpdateDevicesGrid(selectedClient);
            }
        }
        private void Button_MailCertificaten(object sender, RoutedEventArgs e)
        {

            if (DeviceGrid.SelectedItems == null || DeviceGrid.SelectedItems.Count == 0)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een of meerdere toestelen om de klant te mailen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                IList items = DeviceGrid.SelectedItems;
                MailCertificaten mailCertificaten = new MailCertificaten(items)
                {
                    Owner = this
                };
                mailCertificaten.Show();
                /*IList items = DeviceGrid.SelectedItems;
                Device _device = new Device();
                CheckUp _check = new CheckUp();
                using (var db = new ServiceProgramContext())
                {
                    List<String> certs = new List<string>();
                    for (int i = 0; i < items.Count; i++)
                    {
                        _device = db.Devices.Find(((CustomDevice)items[i]).Id);
                        _check = db.CheckUps.Where(s => s.Device.Id == _device.Id).OrderByDescending(t => t.Date).FirstOrDefault();
                        if (_check != null)
                        {
                            String _check2;
                            if (_check.Number.Contains("/"))
                            {
                                _check2 = _check.Number.Replace("/", "_");
                            }
                            else
                            {
                                _check2 = _check.Number;
                            }
                            certs.Add(_check2 + "_" + _device.Client.Company + ".pdf");
                            Console.WriteLine("Cert " + _check2 + " date " + _check.Date + " from device " + _device.SerialNumber);
                            Certificate cert = new Certificate(_check, false);
                        }
                    }
                    try
                    {
                        Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                        Microsoft.Office.Interop.Outlook.MailItem mail = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                        String intro = "Hallo <b>...</b><br><br>Hierbij onze certificaten van de service op <b>...</b><br><br>";
                        String outro = "Indien verdere vragen, aarzel niet om me te contacteren op +32 476 30 17 83.<br><br>";

                        String mailbody = intro  + outro;
                        mail.To = _device.Client.Email;
                        mail.Subject = "Kalibratiecertificaten";
                        //mail.HTMLBody = mailbody + ReadSignature();
                        mail.HTMLBody = mailbody + "<br><br>";
                        String dir = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                        Console.WriteLine(dir);
                        for (int i = 0; i < certs.Count; i++)
                        {
                            Console.WriteLine(certs.ElementAt(i));
                            mail.Attachments.Add((dir + "\\" + (certs.ElementAt(i))), Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, Type.Missing, Type.Missing);
                        }
                        mail.HTMLBody = mailbody + "<br><br>";
                        mail.Display(true);

                        mail = null;
                        app = null;
                    }
                    catch (System.Exception ex)
                    {
                    }
                }*/
            }

        }





        private string ReadSignature()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Signatures";
            string signature = string.Empty;
            DirectoryInfo diInfo = new DirectoryInfo(appDataDir);

            if (diInfo.Exists)
            {
                FileInfo[] fiSignature = diInfo.GetFiles("*.htm");

                if (fiSignature.Length > 0)
                {
                    StreamReader sr = new StreamReader(fiSignature[0].FullName, Encoding.Default);
                    signature = sr.ReadToEnd();

                    if (!string.IsNullOrEmpty(signature))
                    {
                        string fileName = fiSignature[0].Name.Replace(fiSignature[0].Extension, string.Empty);
                        signature = signature.Replace(fileName + "_files/", appDataDir + "/" + fileName + "_files/");
                    }
                }
            }
            return signature;
        }


        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            using (var db = new ServiceProgramContext())
            {
                if (selectedDevice == null)
                {
                   
                }
                else
                {
                    int id = selectedDevice.Id;
                    Device _device = db.Devices.Find(id);
                    _device.Aanwezig = true;
                    db.SaveChanges();
                }
            }
        }
        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            using (var db = new ServiceProgramContext())
            {
                if (selectedDevice == null)
                {
                   
                }
                else
                {
                    int id = selectedDevice.Id;
                    Device _device = db.Devices.Find(id);
                    _device.Aanwezig = false;
                    db.SaveChanges();
                }
            }
        }

        public void setCheckId(int id)
        {
            this.newestCheckId = id;
        }
        public class CustomDevice
        {
            public int Id { get; set; }
            public String Name { get; set; }
            public String SerialNumber { get; set; }
            public DateTime LastCheck { get; set; }
            public DateTime NextCheck { get; set; }
            public string Color { get; set; }
            public string Reference { get; set; }
            public bool aanwezig { get; set; }
            public String ClientName { get; set; }
            public String Bought { get; set; }
            public String O2Sensor { get; set; }

            public CustomDevice(Device dev, int clientId, int verhuurId, String comp)
            {
                Id = dev.Id;
                Name = dev.Name;
                SerialNumber = dev.SerialNumber;
                LastCheck = dev.LastCheck;
                NextCheck = dev.NextCheck;
                ClientName = comp;
                Reference = dev.Reference;
                if((dev.BoughtByUs) && dev.Bought != DateTime.MinValue)
                {
                    Bought = (dev.Bought.Date).ToString("dd/M/yyyy");
                }
                else
                {
                    Bought = "";
                }
                if (dev.O2Sensor != DateTime.MinValue)
                {
                    O2Sensor = (dev.O2Sensor.Date).ToString("dd/M/yyyy");
                }
                else
                {
                    O2Sensor = "";
                }
                if (clientId == verhuurId)
                {
                    if (dev.Aanwezig)
                    {
                        //Color = "Blue";
                        aanwezig = true;
                    }
                    else
                    {
                        //Color = "Pink";
                        aanwezig = false;
                    }

                }
                if (dev.NoS && (clientId != verhuurId))
                {
                    Color = "Orange";
                }
                if (dev.Lost)
                {
                    Color = "Green";
                }
                if (dev.Broken)
                {
                    Color = "Red";
                }
            }
        }

        public class CustomClient
        {
            public int Id { get; set; }
            public String Company { get; set; }
            public String Contact { get; set; }
            public String Address1 { get; set; }
            public String Address2 { get; set; }
            public String Phone { get; set; }
            public string Color { get; set; }
            public String MobilePhone { get; set; }
            public String Email { get; set; }
            public String Note { get; set; }
            public Boolean geenOp { get; set; }
            public String KalibratieMaand { get; set; }

            public CustomClient(Client client)
            {
                Id = client.Id;
                Company = client.Company;
                Contact = client.Contact;
                Address1 = client.Address1;
                Address2 = client.Address2;
                Phone = client.Phone;
                MobilePhone = client.MobilePhone;
                Email = client.Email;
                Note = client.Note;
                geenOp = client.GeenOproep;
                DateTime Maand1 = (DateTime)client.KalibratieMaand;
                Console.WriteLine(Maand1);
                Console.WriteLine(DateTime.MinValue);
                Console.WriteLine(DateTime.Compare(Maand1, DateTime.MinValue));

                if (Maand1.Month == 1)
                {
                    KalibratieMaand = "Januari";
                }
                if (Maand1.Month == 2)
                {
                    KalibratieMaand = "Februari";
                }
                if (Maand1.Month == 3)
                {
                    KalibratieMaand = "Maart";
                }
                if (Maand1.Month == 4)
                {
                    KalibratieMaand = "April";
                }
                if (Maand1.Month == 5)
                {
                    KalibratieMaand = "Mei";
                }
                if (Maand1.Month == 6)
                {
                    KalibratieMaand = "Juni";
                }
                if (Maand1.Month == 7)
                {
                    KalibratieMaand = "Juli";
                }
                if (Maand1.Month == 8)
                {
                    KalibratieMaand = "Augustus";
                }
                if (Maand1.Month == 9)
                {
                    KalibratieMaand = "September";
                }
                if (Maand1.Month == 10)
                {
                    KalibratieMaand = "Oktober";
                }
                if (Maand1.Month == 11)
                {
                    KalibratieMaand = "November";
                }
                if (Maand1.Month == 12)
                {
                    KalibratieMaand = "December";
                }
                if (DateTime.Compare(Maand1, DateTime.MinValue) == 0)
                {
                    KalibratieMaand = "";
                }
                if (geenOp)
                {
                    Color = "Orange";
                }
            }
        }
    }
}
