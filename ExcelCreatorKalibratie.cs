using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using Service_Program.Properties;

namespace Service_Program

{



    class ExcelCreatorKalibratie
    {
        string fileName = "";

        public ExcelCreatorKalibratie(List<Device> devices, DateTime From, DateTime Untill)
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
            xlWorkBook = xlApp.Workbooks.Open(strWorkPath + "\\Resources\\template-kalibratie.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);



            /*xlWorkSheet.Cells[1, 1] = "TE KALIBREREN TOESTELLEN";
            xlWorkSheet.Cells[2, 1] = "Van " + From.ToString() + " tot " + Untill.ToString() + ".";
            //xlWorkSheet.Range[xlWorkSheet.Cells[1, 1], xlWorkSheet.Cells[1, 4]].Merge();
            //xlWorkSheet.Cells[2, 3] = DateTime.Today;
            xlWorkSheet.Cells[4, 1] = "Naam";
            xlWorkSheet.Cells[4, 2] = "Serienummer";
            xlWorkSheet.Cells[4, 3] = "Aankoopdatum";
            xlWorkSheet.Cells[4, 4] = "Laatste Kalibratie";
            xlWorkSheet.Cells[4, 5] = "Volgende Kalibratie";
            xlWorkSheet.Cells[4, 6] = "Bedrijf";*/

            using (var db = new ServiceProgramContext())
            {
                var i = 6;
                foreach (var device in devices)
                {
                    if (!device.Broken && !device.Lost && !device.NoS && !device.Deleted)
                    {
                        xlWorkSheet.Cells[i, 2] = device.Name;
                        xlWorkSheet.Cells[i, 3] = device.SerialNumber;
                        xlWorkSheet.Cells[i, 4] = device.Bought.Date.ToString();
                        xlWorkSheet.Cells[i, 5] = device.LastCheck.Date;
                        xlWorkSheet.Cells[i, 6] = device.NextCheck.Date;
                        xlWorkSheet.Cells[i, 7] = device.Client.Company;
                        i++;
                    }
                }
            }
            Excel.Range aRange = xlWorkSheet.get_Range("A1", "E100");
            aRange.Columns.AutoFit();



            fileName = "Kalibratie"+".xls";
            string path = Path.Combine(Environment.CurrentDirectory, fileName);
            try
            {
                xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();
           
            }
            catch (Exception e)
            {
                //MessageBoxResult result = MessageBox.Show("Gelieve de huidige Excell te sluiten.", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }



            Marshal.ReleaseComObject(xlWorkSheet);

            Marshal.ReleaseComObject(xlWorkBook);

            Marshal.ReleaseComObject(xlApp);



            Console.WriteLine("Excel file created");
        }

        public void OpenFile() {
            System.Diagnostics.Process.Start(fileName);
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
