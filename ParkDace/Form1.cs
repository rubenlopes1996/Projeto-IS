using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace ParkDace
{
    public partial class Form1 : Form
    {
        private static string[] spotsId, spotLocation;
        private static int numParkingSpotsDLL=15, numParkingSpotsBOT=10;
        ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;

        public Form1()
        {
            InitializeComponent();
            

        }

        private void button_fetchSpots_Click(object sender, EventArgs e)
        {
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            dll.Initialize(SpotsPark, 800);


        }

        private void SpotsPark(string str)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                richTextBoxSpotsDLL.AppendText(str + "\n");
            });
        }

        private void button_stopFetching_Click_1(object sender, EventArgs e)
        {
            dll.Stop();

        }

        private void richTextBoxSpotsDLL_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFetchBotSpots_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            
            /*for (int i = 0; i < length; i++)
            {

                service.CreateSensorDataXML(10);
            }*/
            
            

        }

        private static string ReadFromExcelFile(string filename)
        {
            //Criar App do excell
            string result = "";
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            //Abre a folha do excel
            Excel.Workbook workbook = excelApp.Workbooks.Open(filename);
            Excel.Worksheet sheet1 = workbook.ActiveSheet;

            var parkId = (sheet1.Cells[1, 2] as Excel.Range).Value;
            var numberOfSpots = (sheet1.Cells[2, 2] as Excel.Range).Value;
            //var number2s = (sheet1.Cells[6, 1] as Excel.Range).Value;


            spotsId = new string[numParkingSpotsBOT];
            spotLocation = new string[numParkingSpotsBOT];

            for (int i = 0; i < numParkingSpotsBOT; i++)
            {
                spotsId[i] = (string)(sheet1.Cells[i+6, 1] as Excel.Range).Value;
            }

            for (int j = 0; j < numParkingSpotsBOT; j++)
            {
                spotLocation[j] = (string)(sheet1.Cells[j+6,2] as Excel.Range).Value;
            }

            //Fechar o excell
            workbook.Close();
            excelApp.Quit();

            //Limpa a memória, os objetos (como se fosse o "gestor de tarefas")
            ReleaseCOMObject(sheet1);
            ReleaseCOMObject(workbook);
            ReleaseCOMObject(excelApp);

            return result;
        }

        private static void ReleaseCOMObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {

                obj = null;
                System.Diagnostics.Debug.WriteLine("Error releasing COM object " + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            BotSpotSensor.ServiceBot_SpotSensorClient service = new BotSpotSensor.ServiceBot_SpotSensorClient();
            
            string path = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName + "\\";
            string leituraDoExcell = ReadFromExcelFile(path + "Park_GeoLocation_Template");

            XmlDocument parkWithSpots = new XmlDocument();

            for (int i = 0; i < numParkingSpotsBOT; i++)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(service.CreateSensorDataXML());
                
                XmlNode name = doc.SelectSingleNode("parkingSpot/name");
                name.InnerText = spotsId[i];
                XmlNode location = doc.SelectSingleNode("parkingSpot/location");
                location.InnerText = spotLocation[i];

                parkWithSpots.AppendChild(doc);
            }

            int x = 0;
        }
    }
}
