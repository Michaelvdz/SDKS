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
    /// Interaction logic for EditCheck.xaml
    /// </summary>
    public partial class EditCheck : Window
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
        public CheckUp Check { get; set; }
        public bool Hide { get; set; }
        public bool HideC { get; set; }

        public EditCheck()
        {
            InitializeComponent();
            DataContext = this;
        }
        public EditCheck(CheckUp check)
        {
            InitializeComponent();
            DataContext = this;
            using (var db = new ServiceProgramContext())
            {
                Check = db.CheckUps.Find(check.Id);
                Date = Check.Date;
                Next = Check.NextDate;
                Note = Check.Note;
                Explanation = Check.Details;
                Number = Check.Number;
                Reference = Check.Reference;
                Gas = Check.Gas;
                if(Check.Sens1 != null)
                {
                    Sens1 = Check.Sens1.Name;
                    Sens1C = Check.Sens1C;
                    Sens1NK = Check.Sens1NK;
                    Sens1VK = Check.Sens1VK;
                    Sens1ZK = Check.Sens1ZK;
                }
                else
                {
                    Sens1Name.Visibility = Visibility.Collapsed;
                    ESens1C.Visibility = Visibility.Collapsed;
                    ESens1VK.Visibility = Visibility.Collapsed;
                    ESens1ZK.Visibility = Visibility.Collapsed;
                    ESens1NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens2 != null)
                {
                    Sens2 = Check.Sens2.Name;
                    Sens2C = Check.Sens2C;
                    Sens2NK = Check.Sens2NK;
                    Sens2VK = Check.Sens2VK;
                    Sens2ZK = Check.Sens2ZK;
                }
                else
                {
                    Sens2Name.Visibility = Visibility.Collapsed;
                    ESens2C.Visibility = Visibility.Collapsed;
                    ESens2VK.Visibility = Visibility.Collapsed;
                    ESens2ZK.Visibility = Visibility.Collapsed;
                    ESens2NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens3 != null)
                {
                    Sens3 = Check.Sens3.Name;
                    Sens3C = Check.Sens3C;
                    Sens3NK = Check.Sens3NK;
                    Sens3VK = Check.Sens3VK;
                    Sens3ZK = Check.Sens3ZK;
                }
                else
                {
                    Sens3Name.Visibility = Visibility.Collapsed;
                    ESens3C.Visibility = Visibility.Collapsed;
                    ESens3VK.Visibility = Visibility.Collapsed;
                    ESens3ZK.Visibility = Visibility.Collapsed;
                    ESens3NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens4 != null)
                {
                    Sens4 = Check.Sens4.Name;
                    Sens4C = Check.Sens4C;
                    Sens4NK = Check.Sens4NK;
                    Sens4VK = Check.Sens4VK;
                    Sens4ZK = Check.Sens4ZK;
                }
                else
                {
                    Sens4Name.Visibility = Visibility.Collapsed;
                    ESens4C.Visibility = Visibility.Collapsed;
                    ESens4VK.Visibility = Visibility.Collapsed;
                    ESens4ZK.Visibility = Visibility.Collapsed;
                    ESens4NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens5 != null)
                {
                    Sens5 = Check.Sens5.Name;
                    Sens5C = Check.Sens5C;
                    Sens5NK = Check.Sens5NK;
                    Sens5VK = Check.Sens5VK;
                    Sens5ZK = Check.Sens5ZK;
                }
                else
                {
                    Sens5Name.Visibility = Visibility.Collapsed;
                    ESens5C.Visibility = Visibility.Collapsed;
                    ESens5VK.Visibility = Visibility.Collapsed;
                    ESens5ZK.Visibility = Visibility.Collapsed;
                    ESens5NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens6 != null)
                {
                    Sens6 = Check.Sens6.Name;
                    Sens6C = Check.Sens6C;
                    Sens6NK = Check.Sens6NK;
                    Sens6VK = Check.Sens6VK;
                    Sens6ZK = Check.Sens6ZK;
                }
                else
                {
                    Sens6Name.Visibility = Visibility.Collapsed;
                    ESens6C.Visibility = Visibility.Collapsed;
                    ESens6VK.Visibility = Visibility.Collapsed;
                    ESens6ZK.Visibility = Visibility.Collapsed;
                    ESens6NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens7 != null)
                {
                    Sens7 = Check.Sens7.Name;
                    Sens7C = Check.Sens7C;
                    Sens7NK = Check.Sens7NK;
                    Sens7VK = Check.Sens7VK;
                    Sens7ZK = Check.Sens7ZK;
                }
                else
                {
                    Sens7Name.Visibility = Visibility.Collapsed;
                    ESens7C.Visibility = Visibility.Collapsed;
                    ESens7VK.Visibility = Visibility.Collapsed;
                    ESens7ZK.Visibility = Visibility.Collapsed;
                    ESens7NK.Visibility = Visibility.Collapsed;
                }
                if (Check.Sens8 != null)
                {
                    Sens8 = Check.Sens8.Name;
                    Sens8C = Check.Sens8C;
                    Sens8NK = Check.Sens8NK;
                    Sens8VK = Check.Sens8VK;
                    Sens8ZK = Check.Sens8ZK;
                }
                else
                {
                    Sens8Name.Visibility = Visibility.Collapsed;
                    ESens8C.Visibility = Visibility.Collapsed;
                    ESens8VK.Visibility = Visibility.Collapsed;
                    ESens8ZK.Visibility = Visibility.Collapsed;
                    ESens8NK.Visibility = Visibility.Collapsed;
                }
                if(Check.HideAlarms == true)
                {
                    Hide = true;
                }
                if (Check.HideConcentrations == true)
                {
                    HideC = true;
                }
                if(Check.DateAndTime)
                {
                    Prop1.IsChecked = true;
                }
                else
                {
                    Prop1.IsChecked = false;
                }
                if (Check.FilterExtern)
                {
                    Prop2.IsChecked = true;
                }
                else
                {
                    Prop2.IsChecked = false;
                }
                if (Check.FilterIntern)
                {
                    Prop3.IsChecked = true;
                }
                else
                {
                    Prop3.IsChecked = false;
                }
                if (Check.Latch)
                {
                    Prop4.IsChecked = true;
                }
                else
                {
                    Prop4.IsChecked = false;
                }
                if (Check.Krokodillenclip)
                {
                    Prop5.IsChecked = true;
                }
                else
                {
                    Prop5.IsChecked = false;
                }
                if (Check.Pomptest)
                {
                    Prop6.IsChecked = true;
                }
                else
                {
                    Prop6.IsChecked = false;
                }/*
                if (Check.Pomprevisie)
                {
                    Prop7.IsChecked = true;
                }
                else
                {
                    Prop7.IsChecked = false;
                }
                if (Check.Lamprevisie)
                {
                    Prop8.IsChecked = true;
                }
                else
                {
                    Prop8.IsChecked = false;
                }*/
                if (Check.AutoZero)
                {
                    Prop9.IsChecked = true;
                }
                else
                {
                    Prop9.IsChecked = false;
                }
                if (Check.SensorVervangen != null && Check.SensorVervangen != "")
                {
                    Prop10.IsChecked = true;
                    Prop10Input.Text = Check.SensorVervangen;
                }
                else
                {
                    Prop10.IsChecked = false;
                }
                if (Check.ExtaOpmerkingen != null && Check.ExtaOpmerkingen != "")
                {
                    Prop11.IsChecked = true;
                    Prop11Input.Text = Check.ExtaOpmerkingen;
                }
                else
                {
                    Prop11.IsChecked = false;
                }
                if (Check.Nieuw)
                {
                    Prop12.IsChecked = true;
                }
                else
                {
                    Prop12.IsChecked = false;
                }
                if (check.Sinterfilter)
                {
                    Prop13.IsChecked = true;
                }
                else
                {
                    Prop13.IsChecked = false;
                }
                if (check.Frontcover)
                {
                    Prop14.IsChecked = true;
                }
                else
                {
                    Prop14.IsChecked = false;
                }
                if (check.A1NA)
                {
                    Prop15.IsChecked = true;
                }
                else
                {
                    Prop15.IsChecked = false;
                }
                if (check.A1A)
                {
                    Prop16.IsChecked = true;
                }
                else
                {
                    Prop16.IsChecked = false;
                }
                if (check.SwitchOffNA)
                {
                    Prop17.IsChecked = true;
                }
                else
                {
                    Prop17.IsChecked = false;
                }
                if (check.battery)
                {
                    Prop19.IsChecked = true;
                }
                else
                {
                    Prop19.IsChecked = false;
                }
                if (Check.FW != null && Check.FW != "")
                {
                    Prop18.IsChecked = true;
                    Prop18Input.Text = Check.FW;
                }
                else
                {
                    Prop18.IsChecked = false;
                }
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
                    else if ((Opmerking.Length >= 180) && !(thirdline))
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
                check.SensorVervangen = "Sensor vervangen: " + Prop10Input.Text.ToString().Replace("Sensor vervangen: ", "");
                if (Opmerking == "")
                {
                    Opmerking = "Sensor vervangen: " + Prop10Input.Text.ToString().Replace("Sensor vervangen: ", "");
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
                    Opmerking = Opmerking + " / " + "Sensor vervangen: " + Prop10Input.Text.ToString().Replace("Sensor vervangen: ", "");
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
                var checkUp = db.CheckUps.Find(Check.Id);
                checkUp.Date = Date2;
                checkUp.Details = Explanation;
                checkUp.Note = Note;
                checkUp.Sens1C = Sens1C;
                checkUp.Sens1VK = Sens1VK;
                checkUp.Sens1ZK = Sens1ZK;
                checkUp.Sens1NK = Sens1NK;
                checkUp.Sens2C = Sens2C;
                checkUp.Sens2VK = Sens2VK;
                checkUp.Sens2ZK = Sens2ZK;
                checkUp.Sens2NK = Sens2NK;
                checkUp.Sens3C = Sens3C;
                checkUp.Sens3VK = Sens3VK;
                checkUp.Sens3ZK = Sens3ZK;
                checkUp.Sens3NK = Sens3NK;
                checkUp.Sens4C = Sens4C;
                checkUp.Sens4VK = Sens4VK;
                checkUp.Sens4ZK = Sens4ZK;
                checkUp.Sens4NK = Sens4NK;
                checkUp.Sens5C = Sens5C;
                checkUp.Sens5VK = Sens5VK;
                checkUp.Sens5ZK = Sens5ZK;
                checkUp.Sens5NK = Sens5NK;
                checkUp.Sens6C = Sens6C;
                checkUp.Sens6VK = Sens6VK;
                checkUp.Sens6ZK = Sens6ZK;
                checkUp.Sens6NK = Sens6NK;
                checkUp.Sens7C = Sens7C;
                checkUp.Sens7VK = Sens7VK;
                checkUp.Sens7ZK = Sens7ZK;
                checkUp.Sens7NK = Sens7NK;
                checkUp.Sens8C = Sens8C;
                checkUp.Sens8VK = Sens8VK;
                checkUp.Sens8ZK = Sens8ZK;
                checkUp.Sens8NK = Sens8NK;
                var _device = db.Devices.Find(checkUp.Device.Id);
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
                checkUp.Gas = Gas;
                checkUp.Number = Number;
                checkUp.Reference = Reference;
                checkUp.NextDate = Next2;
                checkUp.HideAlarms = Hide;
                checkUp.HideConcentrations = HideC;
                checkUp.Details = AddOpmerkingen(checkUp);
                //db.CheckUps.Add(checkUp);
                if(_device.LastCheck < Date2)
                {
                    _device.LastCheck = Date2;

                }
                if(_device.NextCheck < Next2)
                {
                    _device.NextCheck = Next2;
                }
                db.SaveChanges();
            }
            this.Close();
            this.Owner.Activate();
            ((DeviceDetail)this.Owner).UpdateChecksGrid();
        }
        private void Button_ClickAndOpen(object sender, RoutedEventArgs e)
        {
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
                var checkUp = db.CheckUps.Find(Check.Id);
                checkUp.Date = Date2;
                checkUp.Details = Explanation;
                checkUp.Note = Note;
                checkUp.Sens1C = Sens1C;
                checkUp.Sens1VK = Sens1VK;
                checkUp.Sens1ZK = Sens1ZK;
                checkUp.Sens1NK = Sens1NK;
                checkUp.Sens2C = Sens2C;
                checkUp.Sens2VK = Sens2VK;
                checkUp.Sens2ZK = Sens2ZK;
                checkUp.Sens2NK = Sens2NK;
                checkUp.Sens3C = Sens3C;
                checkUp.Sens3VK = Sens3VK;
                checkUp.Sens3ZK = Sens3ZK;
                checkUp.Sens3NK = Sens3NK;
                checkUp.Sens4C = Sens4C;
                checkUp.Sens4VK = Sens4VK;
                checkUp.Sens4ZK = Sens4ZK;
                checkUp.Sens4NK = Sens4NK;
                checkUp.Sens5C = Sens5C;
                checkUp.Sens5VK = Sens5VK;
                checkUp.Sens5ZK = Sens5ZK;
                checkUp.Sens5NK = Sens5NK;
                checkUp.Sens6C = Sens6C;
                checkUp.Sens6VK = Sens6VK;
                checkUp.Sens6ZK = Sens6ZK;
                checkUp.Sens6NK = Sens6NK;
                checkUp.Sens7C = Sens7C;
                checkUp.Sens7VK = Sens7VK;
                checkUp.Sens7ZK = Sens7ZK;
                checkUp.Sens7NK = Sens7NK;
                checkUp.Sens8C = Sens8C;
                checkUp.Sens8VK = Sens8VK;
                checkUp.Sens8ZK = Sens8ZK;
                checkUp.Sens8NK = Sens8NK;
                var _device = db.Devices.Find(checkUp.Device.Id);
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
                checkUp.Gas = Gas;
                checkUp.Number = Number;
                checkUp.Reference = Reference;
                checkUp.NextDate = Next2;
                checkUp.HideAlarms = Hide;
                checkUp.HideConcentrations = HideC;
                checkUp.Details = AddOpmerkingen(checkUp);
                //db.CheckUps.Add(checkUp);
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
            this.Close();
            this.Owner.Activate();
            ((DeviceDetail)this.Owner).UpdateChecksGrid();
        }
    }
}
