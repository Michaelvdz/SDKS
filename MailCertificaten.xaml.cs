using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Service_Program.MainWindow;

namespace Service_Program
{
    /// <summary>
    /// Interaction logic for ProgressBarTaskOnUiThread.xaml
    /// </summary>
    public partial class MailCertificaten : Window
    {
        IList items;
        public MailCertificaten(IList items)
        {
            InitializeComponent();
			DataContext = this;
            this.items = items;
            
        }
        private void Window_ContentRendered(object sender, EventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worder_WorkerCompleted;

			worker.RunWorkerAsync();
		}

        private void worder_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
		{
            Device _device = new Device();
            CheckUp _check = new CheckUp();
            using (var db = new ServiceProgramContext())
            {
                List<String> certs = new List<string>();
                int hascerts = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    _device = db.Devices.Find(((CustomDevice)items[i]).Id);
                    _check = db.CheckUps.Where(s => s.Device.Id == _device.Id).OrderByDescending(t => t.Date).FirstOrDefault();
                    if (_check != null)
                    {
                        hascerts++;
                    }
                }
                Double step = Math.Round((1 / (Double)hascerts * (Double)100));
                Console.WriteLine("Step: " + step);
                Console.WriteLine("Count: " + items.Count);
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
                        (sender as BackgroundWorker).ReportProgress(Convert.ToInt32((i+1) * step));
                    }
                }
                Console.WriteLine("total after cut : " + items.Count);
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
            }
		}

		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbStatus.Value = e.ProgressPercentage;
		}
	}
}
