using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Service_Program.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Service_Program
{
    class Certificate
    {
        public PdfDocument Document { get; set; }
        public PdfPage page { get; set; }
        public XGraphics gfx { get; set; }
        XBrush Blue = new XSolidBrush(new XColor { R = 19, G = 149, B = 208 });
        XFont fontBI = new XFont("Calibri", 10, XFontStyle.BoldItalic);
        XFont fontU = new XFont("Calibri", 10, XFontStyle.Underline);
        XFont font = new XFont("Calibri", 10, XFontStyle.Regular);


        public Certificate(CheckUp checkup, bool open = true)
        {
            Document = new PdfDocument();
            page = Document.AddPage();
            gfx = XGraphics.FromPdfPage(page);

            //First section
            string path = "logo.png";
            try
            {
                XImage image2 = XImage.FromBitmapSource(Convert(Resources.logo));
               // XImage image = XImage.FromFile(path);
                gfx.DrawImage(image2, 75, 75, 35, 49);
            }
            catch (Exception ex)
            {
                string filePath = "Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

            }

            XFont fontBI = new XFont("Calibri", 10, XFontStyle.BoldItalic);
            XFont fontU = new XFont("Calibri", 10, XFontStyle.Underline);
            XFont font = new XFont("Calibri", 10, XFontStyle.Regular);
            gfx.DrawString("Je Partner in Gasdetectie!", fontBI, Blue, new XRect(50, 140, 93, 0), XStringFormats.Default);
            gfx.DrawString("KALIBRATIE CERTIFICAAT:", font, XBrushes.Black, new XRect((page.Width/2)-50, 80, 100, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if(check.Number != null)
                {
                    gfx.DrawString(check.Number, font, XBrushes.Black, new XRect((page.Width / 2) + 80, 80, 100, 0), XStringFormats.Default);
                }
            }
            gfx.DrawString("Afgegeven aan:", fontU, XBrushes.Black, new XRect((page.Width / 2)-50, 100, 100, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                gfx.DrawString(check.Device.Client.Company, font, XBrushes.Black, new XRect((page.Width / 2)+20, 100, 100, 0), XStringFormats.Default);
            }
            gfx.DrawString("Tav:", fontU, XBrushes.Black, new XRect((page.Width / 2)-50, 115, 100, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if (check.Device.Client.Contact != null)
                {
                    gfx.DrawString(check.Device.Client.Contact, font, XBrushes.Black, new XRect((page.Width / 2) - 20, 115, 100, 0), XStringFormats.Default);
                }
            }
            gfx.DrawLine(XPens.Black, 50, 150, page.Width-50, 150);

            //Second section
            gfx.DrawString("PRODUCT", fontBI, XBrushes.Black, new XRect(50, 160, 0, 0), XStringFormats.Default);
            gfx.DrawString("Toestel:", font, XBrushes.Black, new XRect(50, 180, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                String sens1 ="", sens2="", sens3="", sens4="", sens5="", sens6="", sens7="", sens8="";
                if(check.Sens1 != null)
                {
                    sens1 = check.Sens1.Name;
                }
                if (check.Sens2 != null)
                {
                    sens2 = "/"+check.Sens2.Name;
                }
                if (check.Sens3 != null)
                {
                    sens3 = "/"+check.Sens3.Name;
                }
                if (check.Sens4 != null)
                {
                    sens4 = "/"+check.Sens4.Name;
                }
                if (check.Sens5 != null)
                {
                    sens5 = "/"+check.Sens5.Name;
                }
                if (check.Sens6 != null)
                {
                    sens6 = "/"+check.Sens6.Name;
                }
                if (check.Sens7 != null)
                {
                    sens7 = "/"+check.Sens7.Name;
                }
                if (check.Sens8 != null)
                {
                    sens8 = "/"+check.Sens8.Name;
                }
                gfx.DrawString(check.Device.Name, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 180, 0, 0), XStringFormats.Default);
                //gfx.DrawString(check.Device.Name+" met "+ sens1+ sens2 + sens3 + sens4 +  sens5 + sens6 +  sens7 + sens8+ " sensoren", font, XBrushes.Black, new XRect((page.Width / 2) - 50, 180, 0, 0), XStringFormats.Default);
                if (check.Device.Note != null)
                {
                    gfx.DrawString(check.Device.Note, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 200, 0, 0), XStringFormats.Default);
                }
            }
            gfx.DrawString("Serienummer", font, XBrushes.Black, new XRect(50, 220, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if((check.Device.SerialNumber != null) && (check.Device.SerialNumber != "")){ 
                    gfx.DrawString(check.Device.SerialNumber, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 220, 0, 0), XStringFormats.Default);
                }
            }
            gfx.DrawString("Kalibratiedatum", font, XBrushes.Black, new XRect(50, 235, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                gfx.DrawString(check.Date.Date.ToString("dd/MM/yyyy"), font, XBrushes.Black, new XRect((page.Width / 2) - 50, 235, 0, 0), XStringFormats.Default);
            }
            gfx.DrawString("Uw referentie", font, XBrushes.Black, new XRect(50, 250, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if(check.Device.Reference != null)
                {
                    gfx.DrawString(check.Device.Reference, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 250, 0, 0), XStringFormats.Default);
                }
            }
            gfx.DrawLine(XPens.Black, 50, 260, page.Width - 50, 260);


            //Third section
            gfx.DrawString("SPECIFICATIES van het gekalibreerde toestel", fontBI, XBrushes.Black, new XRect(50, 275, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                font = new XFont("Calibri", 8, XFontStyle.Regular);
                CheckUp check = db.CheckUps.Find(checkup.Id);
                String sens1 = "", sens2 = "", sens3 = "", sens4 = "", sens5 = "", sens6 = "", sens7 = "", sens8 = "";
                String range1 = "", range2 = "", range3 = "", range4 = "", range5 = "", range6 = "", range7 = "", range8 = "";
                String resolution1 = "", resolution2 = "", resolution3 = "", resolution4 = "", resolution5 = "", resolution6 = "", resolution7 = "", resolution8 = "";
                if (check.Sens1 != null && !check.HideAlarm1)
                {
                    sens1 = check.Sens1.Name + ": range: ";
                    range1 = check.Sens1.Range + " / resolutie:";
                    resolution1 = check.Sens1.Resolution;
                }
                if (check.Sens2 != null && !check.HideAlarm2)
                {
                    sens2 = check.Sens2.Name + ": range ";
                    range2 = check.Sens2.Range + " / resolutie:";
                    resolution2 = check.Sens2.Resolution;
                }
                if (check.Sens3 != null && !check.HideAlarm3)
                {
                    sens3 = check.Sens3.Name + ": range ";
                    range3 = check.Sens3.Range + " / resolutie:";
                    resolution3 = check.Sens3.Resolution;
                }
                if (check.Sens4 != null && !check.HideAlarm4)
                {
                    sens4 = check.Sens4.Name + ": range ";
                    range4 = check.Sens4.Range + " / resolutie:";
                    resolution4 = check.Sens4.Resolution;
                }
                if (check.Sens5 != null && !check.HideAlarm5)
                {
                    sens5 = check.Sens5.Name + ": range ";
                    range5 = check.Sens5.Range + " / resolutie:";
                    resolution5 = check.Sens5.Resolution;
                }
                if (check.Sens6 != null && !check.HideAlarm6)
                {
                    sens6 = check.Sens6.Name + ": range ";
                    range6 = check.Sens6.Range + " / resolutie:";
                    resolution6 = check.Sens6.Resolution;
                }
                if (check.Sens7 != null && !check.HideAlarm7)
                {
                    sens7 = check.Sens7.Name + ": range ";
                    range7 = check.Sens7.Range + " / resolutie:";
                    resolution7 = check.Sens7.Resolution;
                }
                if (check.Sens8 != null && !check.HideAlarm8)
                {
                    sens8 = check.Sens8.Name + ": range ";
                    range8 = check.Sens8.Range + " / resolutie:";
                    resolution8 = check.Sens8.Resolution;
                }

                gfx.DrawString(sens1+ range1 + resolution1, font, XBrushes.Black, new XRect(50, 290, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens2+ range2 + resolution2, font, XBrushes.Black, new XRect(50, 305, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens3+ range3 + resolution3, font, XBrushes.Black, new XRect(50, 320, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens4+ range4 + resolution4, font, XBrushes.Black, new XRect(50, 335, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens5+ range5 + resolution5, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 290, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens6+ range6 + resolution6, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 305, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens7+ range7 + resolution7, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 320, 0, 0), XStringFormats.Default);
                gfx.DrawString(sens8+ range8 + resolution8, font, XBrushes.Black, new XRect((page.Width / 2) - 50, 335, 0, 0), XStringFormats.Default);

            }
            gfx.DrawLine(XPens.Black, 50, 340, page.Width - 50, 340);

            //Fourth section
            XFont temp = new XFont("Calibri", 8, XFontStyle.BoldItalic);
            XPen line = new XPen(XColors.Black, 0.2);
            int sensors = 0;
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if (!check.HideConcentrations)
                {

                    String sens1C = "", sens2C = "", sens3C = "", sens4C = "", sens5C = "", sens6C = "", sens7C = "", sens8C = "";
                    String sens1VK = "", sens2VK = "", sens3VK = "", sens4VK = "", sens5VK = "", sens6VK = "", sens7VK = "", sens8VK = "";
                    String sens1ZK = "", sens2ZK = "", sens3ZK = "", sens4ZK = "", sens5ZK = "", sens6ZK = "", sens7ZK = "", sens8ZK = "";
                    String sens1NK = "", sens2NK = "", sens3NK = "", sens4NK = "", sens5NK = "", sens6NK = "", sens7NK = "", sens8NK = "";
                    font = new XFont("Calibri", 8, XFontStyle.Regular);
                    gfx.DrawRectangle(line, XBrushes.Yellow, 50, 353, 110, 15);
                    gfx.DrawLine(line, 50, 353, 50, 413);
                    gfx.DrawLine(line, 50, 353, 160, 353);
                    gfx.DrawString("Concentratie Kalibratiegas", temp, XBrushes.Blue, new XRect(50, 360, 110, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 50, 368, 160, 368);
                    gfx.DrawString("Bump VOOR Kalibratie", temp, XBrushes.Blue, new XRect(50, 375, 110, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 50, 383, 160, 383);
                    gfx.DrawString("Zero Kalibratie", temp, XBrushes.Blue, new XRect(50, 390, 110, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 50, 398, 160, 398);
                    gfx.DrawString("Bump NA Kalibratie", temp, XBrushes.Blue, new XRect(50, 405, 110, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 50, 413, 160, 413);
                    gfx.DrawLine(line, 160, 353, 160, 413);
                    if (check.Sens1 != null && !check.HideAlarm1)
                    {
                        sens1C = check.Sens1C;
                        sens1VK = check.Sens1VK;
                        sens1ZK = check.Sens1ZK;
                        sens1NK = check.Sens1NK;

                        gfx.DrawRectangle(line, XBrushes.Yellow, 160, 353, 90, 15);
                        gfx.DrawLine(line, 160, 353, 250, 353);
                        gfx.DrawLine(line, 160, 368, 250, 368);
                        gfx.DrawLine(line, 160, 383, 250, 383);
                        gfx.DrawLine(line, 160, 398, 250, 398);
                        gfx.DrawLine(line, 160, 413, 250, 413);
                        gfx.DrawLine(line, 250, 353, 250, 413);
                        if (sens1C != null && sens1VK != null && sens1ZK != null && sens1NK != null)
                        {
                            gfx.DrawString(sens1C, temp, XBrushes.Blue, new XRect(160, 360, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens1VK, temp, XBrushes.Black, new XRect(160, 375, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens1ZK, temp, XBrushes.Black, new XRect(160, 390, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens1NK, temp, XBrushes.Black, new XRect(160, 405, 90, 0), XStringFormats.Center);
                        }
                        sensors++;
                    }
                    if (check.Sens2 != null && !check.HideAlarm2)
                    {
                        sens2C = check.Sens2C;
                        sens2VK = check.Sens2VK;
                        sens2ZK = check.Sens2ZK;
                        sens2NK = check.Sens2NK;
                        gfx.DrawRectangle(line, XBrushes.Yellow, 160+(sensors*90), 353, 90, 15);
                        gfx.DrawLine(line, 160 + (sensors * 90), 353, 160+((sensors+1) * 90), 353);
                        gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                        gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                        gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                        gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                        gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                        if (sens2C != null && sens2VK != null && sens2ZK != null && sens2NK != null)
                        {
                            gfx.DrawString(sens2C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens2VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens2ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens2NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                        }
                        sensors++;
                    }
                    if (check.Sens3 != null && !check.HideAlarm3)
                    {
                        sens3C = check.Sens3C;
                        sens3VK = check.Sens3VK;
                        sens3ZK = check.Sens3ZK;
                        sens3NK = check.Sens3NK;
                        gfx.DrawRectangle(line, XBrushes.Yellow, 160 + (sensors * 90), 353, 90, 15);
                        gfx.DrawLine(line, 160 + (sensors * 90), 353, 160 + ((sensors + 1) * 90), 353);
                        gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                        gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                        gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                        gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                        gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                        if (sens3C != null && sens3VK != null && sens3ZK != null && sens3NK != null)
                        {
                            gfx.DrawString(sens3C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens3VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens3ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens3NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                        }
                        sensors++;
                    }
                    if (check.Sens4 != null && !check.HideAlarm4)
                    {
                        sens4C = check.Sens4C;
                        sens4VK = check.Sens4VK;
                        sens4ZK = check.Sens4ZK;
                        sens4NK = check.Sens4NK;
                        gfx.DrawRectangle(line, XBrushes.Yellow, 160 + (sensors * 90), 353, 90, 15);
                        gfx.DrawLine(line, 160 + (sensors * 90), 353, 160 + ((sensors + 1) * 90), 353);
                        gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                        gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                        gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                        gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                        gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                        if (sens4C != null && sens4VK != null && sens4ZK != null && sens4NK != null)
                        {
                            gfx.DrawString(sens4C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens4VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens4ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                            gfx.DrawString(sens4NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                        }
                        sensors++;
                    }
                    if (check.Sens5 != null && !check.HideAlarm5)
                    {
                        if(sensors == 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 50, 428, 110, 15);
                            gfx.DrawLine(line, 50, 428, 50, 488);
                            gfx.DrawLine(line, 50, 428, 160, 428);
                            gfx.DrawString("Concentratie Kalibratiegas", temp, XBrushes.Blue, new XRect(50, 435, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 443, 160, 443);
                            gfx.DrawString("Bump VOOR Kalibratie", temp, XBrushes.Blue, new XRect(50, 450, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 458, 160, 458);
                            gfx.DrawString("Zero Kalibratie", temp, XBrushes.Blue, new XRect(50, 465, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 473, 160, 473);
                            gfx.DrawString("Bump NA Kalibratie", temp, XBrushes.Blue, new XRect(50, 480, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 488, 160, 488);
                            gfx.DrawLine(line, 160, 428, 160, 488);
                        }
                        sens5C = check.Sens5C;
                        sens5VK = check.Sens5VK;
                        sens5ZK = check.Sens5ZK;
                        sens5NK = check.Sens5NK;
                        if(sensors < 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + (sensors * 90), 353, 90, 15);
                            gfx.DrawLine(line, 160 + (sensors * 90), 353, 160 + ((sensors + 1) * 90), 353);
                            gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                            gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                            gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                            gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                            gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                            if (sens5C != null && sens5VK != null && sens5ZK != null && sens5NK != null)
                            {
                                gfx.DrawString(sens5C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens5VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens5ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens5NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                            }
                        }
                        else
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160, 428, 90, 15);
                            gfx.DrawLine(line, 160, 428, 250, 428);
                            gfx.DrawLine(line, 160, 443, 250, 443);
                            gfx.DrawLine(line, 160, 458, 250, 458);
                            gfx.DrawLine(line, 160, 473, 250, 473);
                            gfx.DrawLine(line, 160, 488, 250, 488);
                            gfx.DrawLine(line, 250, 428, 250, 488);
                            if (sens5C != null && sens5VK != null && sens5ZK != null && sens5NK != null)
                            {
                                gfx.DrawString(sens5C, temp, XBrushes.Blue, new XRect(160, 435, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens5VK, temp, XBrushes.Black, new XRect(160, 450, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens5ZK, temp, XBrushes.Black, new XRect(160, 465, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens5NK, temp, XBrushes.Black, new XRect(160, 480, 90, 0), XStringFormats.Center);
                            }
                        }

                        sensors++;
                    }
                    if (check.Sens6 != null && !check.HideAlarm6)
                    {
                        if (sensors == 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 50, 428, 110, 15);
                            gfx.DrawLine(line, 50, 428, 50, 488);
                            gfx.DrawLine(line, 50, 428, 160, 428);
                            gfx.DrawString("Concentratie Kalibratiegas", temp, XBrushes.Blue, new XRect(50, 435, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 443, 160, 443);
                            gfx.DrawString("Bump VOOR Kalibratie", temp, XBrushes.Blue, new XRect(50, 450, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 458, 160, 458);
                            gfx.DrawString("Zero Kalibratie", temp, XBrushes.Blue, new XRect(50, 465, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 473, 160, 473);
                            gfx.DrawString("Bump NA Kalibratie", temp, XBrushes.Blue, new XRect(50, 480, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 488, 160, 488);
                            gfx.DrawLine(line, 160, 428, 160, 488);
                        }
                        sens6C = check.Sens6C;
                        sens6VK = check.Sens6VK;
                        sens6ZK = check.Sens6ZK;
                        sens6NK = check.Sens6NK;
                        if (sensors < 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + (sensors * 90), 353, 90, 15);
                            gfx.DrawLine(line, 160 + (sensors * 90), 353, 160 + ((sensors + 1) * 90), 353);
                            gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                            gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                            gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                            gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                            gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                            if (sens6C != null && sens6VK != null && sens6ZK != null && sens6NK != null)
                            {
                                gfx.DrawString(sens6C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens6VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens6ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens6NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                            }
                        }
                        else
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + ((sensors - 4) * 90), 428, 90, 15);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 428, 160 + ((sensors - 3) * 90), 428);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 443, 160 + ((sensors - 3) * 90), 443);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 458, 160 + ((sensors - 3) * 90), 458);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 473, 160 + ((sensors - 3) * 90), 473);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 488, 160 + ((sensors - 3) * 90), 488);
                            gfx.DrawLine(line, 160 + ((sensors - 3) * 90), 428, 160 + ((sensors - 3) * 90), 488);
                            if (sens6C != null && sens6VK != null && sens6ZK != null && sens6NK != null)
                            {
                                gfx.DrawString(sens6C, temp, XBrushes.Blue, new XRect(160 + ((sensors - 4) * 90), 435, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens6VK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 450, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens6ZK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 465, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens6NK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 480, 90, 0), XStringFormats.Center);
                            }
                        }
                        sensors++;
                    }
                    if (check.Sens7 != null && !check.HideAlarm7)
                    {
                        if (sensors == 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 50, 428, 110, 15);
                            gfx.DrawLine(line, 50, 428, 50, 488);
                            gfx.DrawLine(line, 50, 428, 160, 428);
                            gfx.DrawString("Concentratie Kalibratiegas", temp, XBrushes.Blue, new XRect(50, 435, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 443, 160, 443);
                            gfx.DrawString("Bump VOOR Kalibratie", temp, XBrushes.Blue, new XRect(50, 450, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 458, 160, 458);
                            gfx.DrawString("Zero Kalibratie", temp, XBrushes.Blue, new XRect(50, 465, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 473, 160, 473);
                            gfx.DrawString("Bump NA Kalibratie", temp, XBrushes.Blue, new XRect(50, 480, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 488, 160, 488);
                            gfx.DrawLine(line, 160, 428, 160, 488);
                        }
                        sens7C = check.Sens7C;
                        sens7VK = check.Sens7VK;
                        sens7ZK = check.Sens7ZK;
                        sens7NK = check.Sens7NK;
                        if (sensors < 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + (sensors * 90), 353, 90, 15);
                            gfx.DrawLine(line, 160 + (sensors * 90), 353, 160 + ((sensors + 1) * 90), 353);
                            gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                            gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                            gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                            gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                            gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                            if (sens7C != null && sens7VK != null && sens7ZK != null && sens7NK != null)
                            {
                                gfx.DrawString(sens7C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens7VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens7ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens7NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                            }
                        }
                        else
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + ((sensors - 4) * 90), 428, 90, 15);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 428, 160 + ((sensors - 3) * 90), 428);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 443, 160 + ((sensors - 3) * 90), 443);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 458, 160 + ((sensors - 3) * 90), 458);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 473, 160 + ((sensors - 3) * 90), 473);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 488, 160 + ((sensors - 3) * 90), 488);
                            gfx.DrawLine(line, 160 + ((sensors - 3) * 90), 428, 160 + ((sensors - 3) * 90), 488);
                            if (sens7C != null && sens7VK != null && sens7ZK != null && sens7NK != null)
                            {
                                gfx.DrawString(sens7C, temp, XBrushes.Blue, new XRect(160 + ((sensors - 4) * 90), 435, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens7VK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 450, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens7ZK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 465, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens7NK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 480, 90, 0), XStringFormats.Center);
                            }
                        }
                        sensors++;
                    }
                    if (check.Sens8 != null && !check.HideAlarm8)
                    {
                        if (sensors == 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 50, 428, 110, 15);
                            gfx.DrawLine(line, 50, 428, 50, 488);
                            gfx.DrawLine(line, 50, 428, 160, 428);
                            gfx.DrawString("Concentratie Kalibratiegas", temp, XBrushes.Blue, new XRect(50, 435, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 443, 160, 443);
                            gfx.DrawString("Bump VOOR Kalibratie", temp, XBrushes.Blue, new XRect(50, 450, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 458, 160, 458);
                            gfx.DrawString("Zero Kalibratie", temp, XBrushes.Blue, new XRect(50, 465, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 473, 160, 473);
                            gfx.DrawString("Bump NA Kalibratie", temp, XBrushes.Blue, new XRect(50, 480, 110, 0), XStringFormats.Center);
                            gfx.DrawLine(line, 50, 488, 160, 488);
                            gfx.DrawLine(line, 160, 428, 160, 488);
                        }
                        sens8C = check.Sens8C;
                        sens8VK = check.Sens8VK;
                        sens8ZK = check.Sens8ZK;
                        sens8NK = check.Sens8NK;
                        if (sensors < 4)
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + (sensors * 90), 353, 90, 15);
                            gfx.DrawLine(line, 160 + (sensors * 90), 353, 160 + ((sensors + 1) * 90), 353);
                            gfx.DrawLine(line, 160 + (sensors * 90), 368, 160 + ((sensors + 1) * 90), 368);
                            gfx.DrawLine(line, 160 + (sensors * 90), 383, 160 + ((sensors + 1) * 90), 383);
                            gfx.DrawLine(line, 160 + (sensors * 90), 398, 160 + ((sensors + 1) * 90), 398);
                            gfx.DrawLine(line, 160 + (sensors * 90), 413, 160 + ((sensors + 1) * 90), 413);
                            gfx.DrawLine(line, 160 + ((sensors + 1) * 90), 353, 160 + ((sensors + 1) * 90), 413);
                            if (sens8C != null && sens8VK != null && sens8ZK != null && sens8NK != null)
                            {
                                gfx.DrawString(sens8C, temp, XBrushes.Blue, new XRect(160 + (sensors * 90), 360, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens8VK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 375, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens8ZK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 390, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens8NK, temp, XBrushes.Black, new XRect(160 + (sensors * 90), 405, 90, 0), XStringFormats.Center);
                            }
                        }
                        else
                        {
                            gfx.DrawRectangle(line, XBrushes.Yellow, 160 + ((sensors - 4) * 90), 428, 90, 15);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 428, 160 + ((sensors - 3) * 90), 428);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 443, 160 + ((sensors - 3) * 90), 443);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 458, 160 + ((sensors - 3) * 90), 458);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 473, 160 + ((sensors - 3) * 90), 473);
                            gfx.DrawLine(line, 160 + ((sensors - 4) * 90), 488, 160 + ((sensors - 3) * 90), 488);
                            gfx.DrawLine(line, 160 + ((sensors - 3) * 90), 428, 160 + ((sensors - 3) * 90), 488);
                            if (sens8C != null && sens8VK != null && sens8ZK != null && sens8NK != null)
                            {
                                gfx.DrawString(sens8C, temp, XBrushes.Blue, new XRect(160 + ((sensors - 4) * 90), 435, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens8VK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 450, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens8ZK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 465, 90, 0), XStringFormats.Center);
                                gfx.DrawString(sens8NK, temp, XBrushes.Black, new XRect(160 + ((sensors - 4) * 90), 480, 90, 0), XStringFormats.Center);
                            }
                        }
                        sensors++;
                    }
                }
                else
                {
                    if (check.Sens1 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens2 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens3 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens4 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens5 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens6 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens7 != null)
                    {
                        sensors++;
                    }
                    if (check.Sens8 != null)
                    {
                        sensors++;
                    }
                }

            }
            int start;
            if(sensors < 5)
            {
                start = 428;
            }
            else
            {
                start = 495;
            }
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if (!check.HideAlarms)
                {
                    gfx.DrawRectangle(line, XBrushes.Yellow, 50, start, 110, 15);
                    gfx.DrawRectangle(line, XBrushes.Yellow, 160, start, 90, 15);
                    gfx.DrawRectangle(line, XBrushes.Yellow, 250, start, 90, 15);
                    gfx.DrawRectangle(line, XBrushes.Yellow, 340, start, 90, 15);
                    gfx.DrawRectangle(line, XBrushes.Yellow, 430, start, 90, 15);
                    int height = (sensors + 1) * 15;
                    gfx.DrawLine(line, 50, start, 50, start + height);
                    gfx.DrawLine(line, 160, start, 160, start + height);
                    gfx.DrawLine(line, 50, start, 160, start);
                    gfx.DrawString("Alarmen Sensor", temp, XBrushes.Blue, new XRect(50, start + 7, 110, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 50, start + 15, 160, start + 15);

                    gfx.DrawLine(line, 160, start, 250, start);
                    gfx.DrawString("Laag", temp, XBrushes.Blue, new XRect(160, start + 7, 90, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 160, start + 15, 250, start + 15);
                    gfx.DrawLine(line, 250, start, 250, start + height);

                    gfx.DrawLine(line, 250, start, 340, start);
                    gfx.DrawString("Hoog", temp, XBrushes.Blue, new XRect(250, start + 7, 90, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 250, start + 15, 340, start + 15);
                    gfx.DrawLine(line, 340, start, 340, start + height);

                    gfx.DrawLine(line, 340, start, 430, start);
                    gfx.DrawString("STEL", temp, XBrushes.Blue, new XRect(340, start + 7, 90, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 340, start + 15, 430, start + 15);
                    gfx.DrawLine(line, 430, start, 430, start + height);

                    gfx.DrawLine(line, 430, start, 520, start);
                    gfx.DrawString("TWA", temp, XBrushes.Blue, new XRect(430, start + 7, 90, 0), XStringFormats.Center);
                    gfx.DrawLine(line, 430, start + 15, 520, start + 15);
                    gfx.DrawLine(line, 520, start, 520, start + height);

                    //CheckUp check = db.CheckUps.Find(checkup.Id);
                    List<String> checks = new List<string>();
                    if(check.Sens1 != null && !check.HideAlarm1)
                    {
                        checks.Add(check.Sens1.Name);
                    }
                    if (check.Sens2 != null && !check.HideAlarm2)
                    {
                        checks.Add(check.Sens2.Name);
                    }
                    if (check.Sens3 != null && !check.HideAlarm3)
                    {
                        checks.Add(check.Sens3.Name);
                    }
                    if (check.Sens4 != null && !check.HideAlarm4)
                    {
                        checks.Add(check.Sens4.Name);
                    }
                    if (check.Sens5 != null && !check.HideAlarm5)
                    {
                        checks.Add(check.Sens5.Name);
                    }
                    if (check.Sens6 != null && !check.HideAlarm6)
                    {
                        checks.Add(check.Sens6.Name);
                    }
                    if (check.Sens7 != null && !check.HideAlarm7)
                    {
                        checks.Add(check.Sens7.Name);
                    }
                    if (check.Sens8 != null && !check.HideAlarm8)
                    {
                        checks.Add(check.Sens8.Name);
                    }
                    for (int i = 0; i < sensors; i++)
                    {
                        int varheight = ((i + 1) * 15);
                        gfx.DrawString(checks.ElementAt(i), temp, XBrushes.Blue, new XRect(50, start + varheight + 7, 110, 0), XStringFormats.Center);
                        gfx.DrawLine(line, 50, start + varheight + 15, 160, start + varheight + 15);
                            if(check.Sens1 !=null && (checks.ElementAt(i) == check.Sens1.Name) && check.Alarm1L != null && check.Alarm1H != null && check.Alarm1S != null && check.Alarm1T != null)
                            {
                                gfx.DrawString(check.Alarm1L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm1H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm1S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm1T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens2 != null && (checks.ElementAt(i) == check.Sens2.Name) && check.Alarm2L != null && check.Alarm2H != null && check.Alarm2S != null && check.Alarm2T != null)
                            {
                                gfx.DrawString(check.Alarm2L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm2H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm2S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm2T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens3 != null && (checks.ElementAt(i) == check.Sens3.Name) && check.Alarm3L != null && check.Alarm3H != null && check.Alarm3S != null && check.Alarm3T != null)
                            {
                                gfx.DrawString(check.Alarm3L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm3H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm3S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm3T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens4 != null && (checks.ElementAt(i) == check.Sens4.Name) && check.Alarm4L != null && check.Alarm4H != null && check.Alarm4S != null && check.Alarm4T != null)
                            {
                                gfx.DrawString(check.Alarm4L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm4H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm4S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm4T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens5 != null && (checks.ElementAt(i) == check.Sens5.Name) && check.Alarm5L != null && check.Alarm5H != null && check.Alarm5S != null && check.Alarm5T != null)
                            {
                                gfx.DrawString(check.Alarm5L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm5H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm5S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm5T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens6 != null && (checks.ElementAt(i) == check.Sens6.Name) && check.Alarm6L != null && check.Alarm6H != null && check.Alarm6S != null && check.Alarm6T != null)
                            {
                                gfx.DrawString(check.Alarm6L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm6H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm6S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm6T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens7 != null && (checks.ElementAt(i) == check.Sens7.Name) && check.Alarm7L != null && check.Alarm7H != null && check.Alarm7S != null && check.Alarm7T != null)
                            {
                                gfx.DrawString(check.Alarm7L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm7H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm7S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm7T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }
                            if (check.Sens8 != null && (checks.ElementAt(i) == check.Sens8.Name) && check.Alarm8L != null && check.Alarm8H != null && check.Alarm8S != null && check.Alarm8T != null)
                            {
                                gfx.DrawString(check.Alarm8L, temp, XBrushes.Blue, new XRect(160, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 160, start + varheight + 15, 250, start + varheight + 15);
                                gfx.DrawString(check.Alarm8H, temp, XBrushes.Blue, new XRect(250, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 250, start + varheight + 15, 340, start + varheight + 15);
                                gfx.DrawString(check.Alarm8S, temp, XBrushes.Blue, new XRect(340, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 340, start + varheight + 15, 430, start + varheight + 15);
                                gfx.DrawString(check.Alarm8T, temp, XBrushes.Blue, new XRect(430, start + varheight + 7, 90, 0), XStringFormats.Center);
                                gfx.DrawLine(line, 430, start + varheight + 15, 520, start + varheight + 15);
                            }

                    }

                }
            }

  



            gfx.DrawString("Analyse certificaat nummers van de gebruikte gascylinders:", temp, XBrushes.Black, new XRect(50, 640, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if (check.Gas != null)
                {
                    gfx.DrawString(check.Gas, font, XBrushes.Black, new XRect((page.Width / 2) + 20, 640, 0, 0), XStringFormats.Default);
                }
            }
            //gfx.DrawLine(XPens.Black, 50, 640, page.Width - 50, 640);

            //Fifth section
            font = new XFont("Calibri", 10, XFontStyle.Regular);
            gfx.DrawString("Herkalibratiedatum:", font, XBrushes.Black, new XRect(50, 655, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                gfx.DrawString(check.Device.NextCheck.ToString("dd/MM/yyyy"), font, XBrushes.Black, new XRect(150, 655, 0, 0), XStringFormats.Default);
            }
            gfx.DrawLine(XPens.Black, 50, 670, page.Width - 50, 670);

            //Sixth section
            gfx.DrawString("Opmerkingen:", fontBI, XBrushes.Black, new XRect(50, 685, 0, 0), XStringFormats.Default);
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if (check.Details != null)
                {
                    String details = check.Details;
                    String part1, part2, part3;
                    if (details.Contains("\r"))
                    {
                        var parts = details.Split('\r');
                        part1 = parts[0];
                        part2 = parts[1];
                        gfx.DrawString(part1, font, XBrushes.Black, new XRect(50, 700, 0, 0), XStringFormats.Default);
                        gfx.DrawString(part2, font, XBrushes.Black, new XRect(50, 715, 0, 0), XStringFormats.Default);
                        Console.WriteLine("Parts: " + parts.Count());
                        if (parts.Count()>2)
                        {
                            part3 = parts[2];
                            gfx.DrawString(part3, font, XBrushes.Black, new XRect(50, 730, 0, 0), XStringFormats.Default);
                        }
                    }
                    else
                    {
                        gfx.DrawString(details, font, XBrushes.Black, new XRect(50, 700, 0, 0), XStringFormats.Default);
                    }
                }
            }
            gfx.DrawLine(XPens.Black, 50, 745, page.Width - 50, 745);

            //Seventh section
            gfx.DrawString("Kalibratie uitgevoerd door: i.o.v. ing. Ine Van Hofstraeten:", fontBI, XBrushes.DarkGray, new XRect(50, page.Height - 80, 0, 0), XStringFormats.Default);
            try
            {
                string path2 = "./sig.png";
                XImage image2 = XImage.FromBitmapSource(Convert(Resources.sig));
                gfx.DrawImage(image2, (page.Width / 2), page.Height - 95, 45, 35);
            }
            catch (Exception ex)
            {
                string filePath = "Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

            }


            //Eight section
            gfx.DrawString("S & D bvba * Vogelkerslaan 36 * 2960 Brecht * T: +32 468 12 50 58", fontBI, XBrushes.DarkGray, new XRect(0, page.Height - 50, page.Width, 0), XStringFormats.Center);
            gfx.DrawString("BE 0643.992.106 * Crelan IBAN: BE44 1030 4089 2945 * BIC: NICABEBB  /  ine@safetydetection.be", fontBI, XBrushes.DarkGray, new XRect(0, page.Height - 35, page.Width, 0), XStringFormats.Center);

            String name = "certificate";
            using (var db = new ServiceProgramContext())
            {
                CheckUp check = db.CheckUps.Find(checkup.Id);
                if(check != null)
                {
                    name = check.Number + "_" + check.Device.Client.Company;
                }
                else
                {
                    name = check.Device.Name;
                }
            }
            string filename = name + ".pdf";
            filename = filename.Replace("/", "_");
            Console.WriteLine(filename);
            try
            {
                System.IO.File.Delete(filename);
                Document.Save(filename);
                if (open)
                {
                    Process.Start(filename);
                }
                else
                {
                    Console.WriteLine("Don't open certificate!");
                }

            }

            catch (Exception ex)
            {
                string filePath = "Error.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }

                MessageBoxResult result = MessageBox.Show("Het certificaat moet gesloten worden voor er een nieuwe kan gemaakt worden.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }
        public BitmapSource Convert(System.Drawing.Bitmap bitmap)
        {
            var bitmapData = bitmap.LockBits(
                new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);

            var bitmapSource = BitmapSource.Create(
                bitmapData.Width, bitmapData.Height,
                bitmap.HorizontalResolution, bitmap.VerticalResolution,
                PixelFormats.Bgr24, null,
                bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride);

            bitmap.UnlockBits(bitmapData);
            return bitmapSource;
        }
    }

}
