using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using Service_Program.Properties;
using System.Globalization;

namespace Service_Program

{



    class ExcelCreator
    {
        string fileName = "";

        public ExcelCreator(Client client)
        {


            Excel.Application xlApp;
 
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;



            xlApp = new Excel.Application();
            //var pathToRes = System.AppDomain.CurrentDomain.BaseDirectory;
            //Console.WriteLine(Resources.template);
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //This will strip just the working path name:
            //C:\Program Files\MyApplication
            string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
               xlWorkBook = xlApp.Workbooks.Open(strWorkPath + "\\Resources\\template.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            xlWorkSheet.Cells[1, 1] = "LIJST TOESTELLEN - " + client.Company;
            //xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 4]].Merge();
            xlWorkSheet.Cells[2, 3] = DateTime.Today;

            
            using (var db = new ServiceProgramContext())
            {

                var devices = from d in db.Devices where d.Client.Id == client.Id && d.Deleted != true && d.NoS != true && d.Broken != true && d.Lost != true select d;
                String comp = client.Company;
                var i = 5;
                foreach (var device in devices)
                {
                    if (!device.Broken)
                    {
                        xlWorkSheet.Cells[i, 1] = device.Name;
                        xlWorkSheet.Cells[i, 2] = device.SerialNumber;
                        xlWorkSheet.Cells[i, 3] = device.Reference;
                        Console.WriteLine(device.Reference);
                        if (device.Bought != DateTime.MinValue)
                        {
                            //Console.WriteLine(device.Bought.Date.ToString("dd/MM/yyyy"));
                            xlWorkSheet.Cells[i, 4] = device.Bought.Date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            xlWorkSheet.Cells[i, 4] = "NVT";
                        }
                        if (device.O2Sensor != DateTime.MinValue)
                        {
                            xlWorkSheet.Cells[i, 5] = device.O2Sensor.Date.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            xlWorkSheet.Cells[i, 5] = "NVT";
                        }
                        i++;
                    }

                }
            }




            fileName = "Toestel "+ client.Company.Replace("/", "") + ".xls";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            try
            {
                xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();
           
            }
            catch (Exception e)
            {
                MessageBoxResult result = MessageBox.Show("Gelieve de huidige Excell te sluiten.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }



            Marshal.ReleaseComObject(xlWorkSheet);

            Marshal.ReleaseComObject(xlWorkBook);

            Marshal.ReleaseComObject(xlApp);



            Console.WriteLine("Excel file created");
        }

        public void OpenFile() {
            string name = fileName.Replace("/", "");
            Console.WriteLine(name);
            System.Diagnostics.Process.Start(name);
/*            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open("custom.xls", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Console.WriteLine(xlWorkSheet.get_Range("A1", "A1").Value2.ToString());*/

            //xlWorkBook.Close(true, misValue, misValue);
            //xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);

        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                Console.WriteLine("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
}



}
