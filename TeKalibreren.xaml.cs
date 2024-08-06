using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
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
using Microsoft.Office.Interop.Outlook;

namespace Service_Program
{
    /// <summary>
    /// Interaction logic for TeKalibreren.xaml
    /// </summary>
    public partial class TeKalibreren : Window
    {
        public DateTime? From { get; set; }
        public DateTime? Untill { get; set; }
        public String ClientName { get; set; }
        public Device SelectedDevice { get; set; }
        public List<Device> devices { get; set; }


        public TeKalibreren()
        {
            InitializeComponent();
            DataContext = this;
            From = DateTime.Now;
            DateTime month = DateTime.Now.AddMonths(1);
            Untill = month;
            UpdateDevicesGrid();
        }

        public void UpdateDevicesGrid()
        {
            using (var db = new ServiceProgramContext())
            {
                var fromdt = (DateTime)From;
                var from = fromdt.Date;
                var untilldt = (DateTime)Untill;
                var untill = untilldt.Date;
                devices = db.Devices.Where(d => d.NextCheck > from).Where(d => d.NextCheck <= untill).ToList();
                DeviceGrid.Items.Clear();
                foreach (var device in devices)
                {
                    ClientName = device.Client.Company;
                    if(!device.Broken && !device.Lost && !device.NoS && !device.Deleted)
                    {
                        DeviceGrid.Items.Add(device);
                    }
                }
            }
        }

        private void DeviceGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Device device = (Device)DeviceGrid.SelectedItem;
            if (device != null)
            {
                using (var db = new ServiceProgramContext())
                {
                    SelectedDevice = db.Devices.Find(device.Id);
                }
            }
        }
        private void Button_ClickKalibration(object sender, RoutedEventArgs e)
        {
            if (SelectedDevice == null)
            {
                MessageBoxResult result = MessageBox.Show("Selecteer een toestel voor kalibratie.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                NewCheck newCheck = new NewCheck(SelectedDevice)
                {
                    Owner = this
                };
                newCheck.Show();
            }
        }
        private void Button_ClickExcel(object sender, RoutedEventArgs e)
        {

            
            ExcelCreatorKalibratie kalibratieexcel = new ExcelCreatorKalibratie(devices, (DateTime)From, (DateTime)Untill);
            kalibratieexcel.OpenFile();


        }
        private void Button_ZoekKalibration(object sender, RoutedEventArgs e)
        {
            UpdateDevicesGrid();
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
        private void Button_ClickMail(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
                Microsoft.Office.Interop.Outlook.MailItem mail = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);


                if (SelectedDevice == null)
                {
                    MessageBoxResult result = MessageBox.Show("Selecteer een toestel om de klant te mailen.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    Device dev;
                    using (var db = new ServiceProgramContext())
                    {
                        dev = db.Devices.Find(SelectedDevice.Id);
                        Client c = db.Clients.Find(dev.Client.Id);
                        List<Device> devs = new List<Device>();
                        foreach (Device device in DeviceGrid.Items)
                        {
                            Device _dev = db.Devices.Find(device.Id);
                            if (_dev.Client.Id == c.Id)
                            {
                                Console.WriteLine(_dev.Name);
                                devs.Add(_dev);
                            }
                        }
                        devs = db.Devices.Where(d => d.Client.Id == c.Id && d.Lost == false && d.NoS == false && d.Broken == false).ToList();
                        Console.WriteLine("Total: " + devs.Count);
                        /*String prefix = "Hallo%20...%2C%0A%20%0AOns%20automatisch%20kalibratiesysteem%20geeft%20aan%20dat%20een%20aantal%20van%20jullie%20toestel(len)%20toe%20zijn%20aan%20service%20%26%20onderhoud.%0A%20%0A";
                        String suffix = "%0A%20%0APast%20onderstaande%20datum%20om%20langs%20te%20komen%3A%0A-%09..%2F..%20omstreeks%20..u..%0A%20%0AHoor%20graag%20van%20jullie.%0A%20%0A";
                        var url = "mailto:" + dev.Client.Email + "?subject=Herkalibratie&body=" + prefix;*/
                        String devices = "";
                        int i = 0;
                        foreach (Device _device in devs)
                        {
                            //url = url + WebUtility.UrlEncode(_device.Name).Replace("+", "%20") + "(" + WebUtility.UrlEncode(_device.SerialNumber).Replace("+", "%20") + ")%09%09" + "Laatste%20kalibratie%3A%20" + WebUtility.UrlEncode(_device.LastCheck.ToString("dd/MM/yyyy")).Replace("+", "%20") + "%09%09" + "Nieuwe%20kalibratie%3A%20" + WebUtility.UrlEncode(_device.NextCheck.ToString("dd/MM/yyyy")).Replace("+", "%20") + "%0A%20%0A";
                            if ((i % 2) == 0)
                            {
                                devices = devices + "<tr style=\"height: 15.1t\"><td width=\"275\" nowrap=\"\" style=\"width: 206.0pt; border: solid #8EA9DB 1.0pt; border-bottom:solid #8EA9DB 1.0pt; border-right:none;background:#D9E1F2;padding:0cm 3.5pt 0cm 3.5pt;height:15.1pt\"><p class=\"MsoNormal\" ><span style=\"font - size:8.0pt; color: black;\"> " + _device.Name + "</span></p></td>" +
                                "<td width=\"256\" nowrap=\"\" style=\"width: 192.0pt; border: solid #8EA9DB 1.0pt; border-bottom:solid #8EA9DB 1.0pt; border-left:none;background:#D9E1F2;padding:0cm 3.5pt 0cm 3.5pt;height:15.1pt\"><p class=\"MsoNormal\"><span style=\"font - size:8.0pt; color: black;\"> " + _device.SerialNumber + "</span></p></td>" +
                                "<td width=\"147\" nowrap=\"\" style=\"width: 110.0pt; border:solid #8EA9DB 1.0pt; border-bottom:solid #8EA9DB 1.0pt; background:#D9E1F2;padding:0cm 3.5pt 0cm 3.5pt;height:15.1pt\"><p class=\"MsoNormal\"><span style=\"font - size:8.0pt; color: black; text-align: center;\">" + _device.NextCheck.ToString("dd/MM/yyyy") + "</span></p></td></tr>";
                            }
                            else
                            {
                                devices = devices + "<tr style=\"height: 15.1pt\"><td width=\"275\" nowrap=\"\" style=\"width: 206.0pt; border: solid #8EA9DB 1.0pt; border-bottom:solid #8EA9DB 1.0pt; border-right:none;padding:0cm 3.5pt 0cm 3.5pt;height:15.1pt\"><p class=\"MsoNormal\" ><span style=\"font - size:8.0pt; color: black;\"> " + _device.Name + "</span></p></td>" +
                               "<td width=\"256\" nowrap=\"\" style=\"width: 192.0pt; border: solid #8EA9DB 1.0pt; border-bottom:solid #8EA9DB 1.0pt; border-left:none;padding:0cm 3.5pt 0cm 3.5pt;height:15.1pt\"><p class=\"MsoNormal\"><span style=\"font - size:8.0pt; color: black;\"> " + _device.SerialNumber + "</span></p></td>" +
                               "<td width=\"147\" nowrap=\"\" style=\"width: 110.0pt; border:solid #8EA9DB 1.0pt; border-bottom:solid #8EA9DB 1.0pt; padding:0cm 3.5pt 0cm 3.5pt;height:15.1pt\"><p class=\"MsoNormal\"><span style=\"font - size:8.0pt; color: black; text-align: center;\">" + _device.NextCheck.ToString("dd/MM/yyyy") + "</span></p></td></tr>";
                            }
                            i++;

                        }
                        //url = url + suffix;

                        //Process.Start(url);
                        String intro = "Hallo <b>...</b><br><br>Graag komen wij op <b>... ../../....</b> langs op jullie locatie voor de 6-maandelijks kalibratieronde.<br>Je mag ons tegen <b>.u..</b> verwachten.<br><br>";
                        String tableprefix = "<style>p.MsoNormal, li.MsoNormal, div.MsoNormal{margin: 0cm;font - size:11.0pt;font - family:\"Calibri\",sans - serif;mso - fareast - language:EN - US;}a: link, span.MsoHyperlink{ mso - style - priority:99;color:#0563C1;text - decoration:underline;}</style><table class=\"MsoNormalTable\" border=\"0\" cellspacing =\"0\" cellpadding =\"0\" width =\"765\" style =\"width: 574.0pt; margin - left:-.15pt; border - collapse:collapse\" ><tbody><tr><th style=\"text-align:left\">Naam</th><th style=\"text-align:left\">Serienummer</th><th>Volgende kalibratiedatum</th></tr>";
                        String tablesuffix = "</tbody></table><br><br>";
                        String outro = "Indien verdere vragen, aarzel niet om me te contacteren op +32 476 30 17 83.<br><br>";

                        String mailbody = intro + tableprefix + devices + tablesuffix + outro;
                        mail.To = c.Email;
                        mail.Subject = "Herkalibratie";
                        //mail.HTMLBody = mailbody + ReadSignature();
                        mail.HTMLBody = mailbody + "<br><br>";
                        mail.Display(true);
                    }
                }
                mail = null;
                app = null;
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}
