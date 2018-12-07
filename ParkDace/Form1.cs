using System;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

namespace ParkDace
{
    public partial class Form1 : Form
    {
        private static string[] spotsId, spotLocation;
        private static int numParkingSpotsDLL=15, numParkingSpotsBOT=10;
        private static string parkId;
        private static string geoLocationBOT, geoLocationDLL;
        ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;

        public Form1()
        {
            InitializeComponent();
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

            parkId = (sheet1.Cells[1, 2] as Excel.Range).Value;

            spotsId = new string[numParkingSpotsDLL];
            spotLocation = new string[numParkingSpotsDLL];

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

        private void btnStartDataAcquisition_Click(object sender, EventArgs e)
        {
            timerBot.Enabled = true;
            timerDLL.Enabled = true;

            XmlDocument document = new XmlDocument();
            document.Load(AppDomain.CurrentDomain.BaseDirectory + "ParkingNodesConfig.xml");

            XmlNode xmlLocationnDLL = document.SelectSingleNode("parkingLocation/provider/parkInfo/geoLocationFile").LastChild;
            geoLocationDLL = xmlLocationnDLL.OuterXml;

            XmlNode xmlLocationBOT = document.SelectSingleNode("parkingLocation/provider").NextSibling.SelectSingleNode("parkInfo/geoLocationFile").LastChild;
            geoLocationBOT = xmlLocationBOT.OuterXml;
        }

        private void timerDLL_Tick(object sender, EventArgs e)
        {
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            dll.Initialize(DataFromDLL, 3000);

        }

        public void DataFromDLL(string str)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {

                string leituraDoExcell = ReadFromExcelFile(AppDomain.CurrentDomain.BaseDirectory + geoLocationDLL);
                string[] baseString = str.Split(';');


                for (int i = 0; i < numParkingSpotsDLL; i++)
                {
                    XmlDocument doc = new XmlDocument();

                    XmlElement parkingSpot = doc.CreateElement("parkingSpot");
                    doc.AppendChild(parkingSpot);

                    XmlElement idSpot = doc.CreateElement("id");
                    idSpot.InnerText = parkId;

                    XmlElement typeSpot = doc.CreateElement("type");
                    typeSpot.InnerText = "Parking spot";

                    XmlElement nameSpot = doc.CreateElement("name");
                    nameSpot.InnerText = spotsId[i];

                    XmlElement locationSpot = doc.CreateElement("location");
                    locationSpot.InnerText = spotLocation[i];

                    XmlElement statusSpot = doc.CreateElement("status");

                    XmlElement valueSpot = doc.CreateElement("value");
                    valueSpot.InnerText = Int32.Parse(baseString[3]) == 0 ? "free" : "occupied";


                    XmlElement timestamp = doc.CreateElement("timestamp");
                    timestamp.InnerText = baseString[2];

                    XmlElement batteryStatus = doc.CreateElement("batteryStatus");
                    batteryStatus.InnerText = baseString[4];


                    parkingSpot.AppendChild(idSpot);
                    parkingSpot.AppendChild(typeSpot);
                    parkingSpot.AppendChild(nameSpot);
                    parkingSpot.AppendChild(locationSpot);
                    statusSpot.AppendChild(valueSpot);
                    statusSpot.AppendChild(timestamp);
                    parkingSpot.AppendChild(statusSpot);
                    parkingSpot.AppendChild(batteryStatus);

                    richTextBoxSpotsDLL.AppendText(parkingSpot.OuterXml + "\n");


                }

            });
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
            
            string leituraDoExcell = ReadFromExcelFile(AppDomain.CurrentDomain.BaseDirectory + geoLocationBOT);

            for (int i = 0; i < numParkingSpotsBOT; i++)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(service.CreateSensorDataXML());

                XmlNode id = doc.SelectSingleNode("parkingSpot/id");
                id.InnerText = parkId;
                XmlNode name = doc.SelectSingleNode("parkingSpot/name");
                name.InnerText = spotsId[i];
                XmlNode location = doc.SelectSingleNode("parkingSpot/location");
                location.InnerText = spotLocation[i];

                richTextBoxSpotsBot.AppendText(doc.OuterXml + "\n");

            }

        }
    }
}
