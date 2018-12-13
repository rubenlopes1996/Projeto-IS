using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Excel = Microsoft.Office.Interop.Excel;


namespace ParkSS
{

    class Program
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkSS.Properties.Settings.ConnectionString"].ConnectionString;
        private static string ip;


        static void Main(string[] args)
        {
            ReadFromExcel(AppDomain.CurrentDomain.BaseDirectory + "FicheiroConfBroker.xlsx");

            MqttClient client = null;
            string[] topics = { "Data", "Parks" };

            client = new MqttClient(ip);
            client.Connect(Guid.NewGuid().ToString());
            if (!client.IsConnected)
            {
                Console.WriteLine("Unable to connect with the broker");
            }
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
            client.Subscribe(topics, qosLevels);

        }

        private static void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            Console.WriteLine("Deixei de subscrever os tópicos");
        }

        private static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            if (e.Topic == "Parks")
            {
                string data = Encoding.UTF8.GetString(e.Message);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);

                string idPark1 = doc.SelectSingleNode("parkingLocation/provider/parkInfo/id").InnerText;
                string descriptionPark1 = doc.SelectSingleNode("parkingLocation/provider/parkInfo/description").InnerText;
                string numberOfSpotsPark1 = doc.SelectSingleNode("parkingLocation/provider/parkInfo/numberOfSpots").InnerText;
                string numberOfSpecialSpotsPark1 = doc.SelectSingleNode("parkingLocation/provider/parkInfo/numberOfSpecialSpots").InnerText;
                string operatingHoursPark1 = doc.SelectSingleNode("parkingLocation/provider/parkInfo/operatingHours").InnerText;

                string idPark2 = doc.SelectSingleNode("parkingLocation/provider").NextSibling.SelectSingleNode("parkInfo/id").InnerXml;
                string descriptionPark2 = doc.SelectSingleNode("parkingLocation/provider").NextSibling.SelectSingleNode("parkInfo/description").InnerXml;
                string numberOfSpotsPark2 = doc.SelectSingleNode("parkingLocation/provider").NextSibling.SelectSingleNode("parkInfo/numberOfSpots").InnerXml;
                string numberOfSpecialSpotsPark2 = doc.SelectSingleNode("parkingLocation/provider").NextSibling.SelectSingleNode("parkInfo/numberOfSpecialSpots").InnerXml;
                string operatingHoursPark2 = doc.SelectSingleNode("parkingLocation/provider").NextSibling.SelectSingleNode("parkInfo/operatingHours").InnerXml;

                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();

                    Int32 result = (Int32)new SqlCommand("Select Count(*) From Parks", conn).ExecuteScalar();

                    if (result != 2)
                    {
                        SqlCommand cmdParksInsert = new SqlCommand("Insert Into dbo.Parks (name, description,numberOfSpots, numberOfSpecialSpots, operationHours) Values (@name, @description, @numberOfSpots, @numberOfSpecialSpots, @operationHours)", conn);
                        cmdParksInsert.Parameters.AddWithValue("@name", idPark1);
                        cmdParksInsert.Parameters.AddWithValue("@numberOfSpots", numberOfSpotsPark1);
                        cmdParksInsert.Parameters.AddWithValue("@numberOfSpecialSpots", numberOfSpecialSpotsPark1);
                        cmdParksInsert.Parameters.AddWithValue("@operationHours", operatingHoursPark1);
                        cmdParksInsert.Parameters.AddWithValue("@description", descriptionPark1);
                        cmdParksInsert.ExecuteNonQuery();

                        cmdParksInsert = new SqlCommand("Insert Into dbo.Parks (name, description,numberOfSpots, numberOfSpecialSpots, operationHours) Values (@name, @description, @numberOfSpots, @numberOfSpecialSpots, @operationHours)", conn);
                        cmdParksInsert.Parameters.AddWithValue("@name", idPark2);
                        cmdParksInsert.Parameters.AddWithValue("@numberOfSpots", numberOfSpotsPark2);
                        cmdParksInsert.Parameters.AddWithValue("@numberOfSpecialSpots", numberOfSpecialSpotsPark2);
                        cmdParksInsert.Parameters.AddWithValue("@operationHours", operatingHoursPark2);
                        cmdParksInsert.Parameters.AddWithValue("@description", descriptionPark2);
                        cmdParksInsert.ExecuteNonQuery();
                    }

                    conn.Close();

                }
                catch (Exception exception)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
            else if (e.Topic == "Data")
            {
                string data = Encoding.UTF8.GetString(e.Message);
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(data);
                Console.WriteLine("Receiving data");
                string id = doc.SelectSingleNode("parkingSpot/id").InnerText;
                string name = doc.SelectSingleNode("parkingSpot/name").InnerText;
                string type = doc.SelectSingleNode("parkingSpot/type").InnerText;
                string location = doc.SelectSingleNode("parkingSpot/location").InnerText;
                string[] locationArray = location.Split(',');
                string geoLatitude = locationArray[0];
                string geoLongitude = locationArray[1];
                string value = doc.SelectSingleNode("parkingSpot/status/value").InnerText;
                string timeStamp = doc.SelectSingleNode("parkingSpot/status/timestamp").InnerText;
                DateTime enteredDate = DateTime.Parse(timeStamp);
                string batteryStatus = doc.SelectSingleNode("parkingSpot/batteryStatus").InnerText;


                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    conn.Open();
                    Int32 result = (Int32)new SqlCommand("Select Count(*) From dbo.Spots", conn).ExecuteScalar();

                    if (result != 25)
                    {
                        SqlCommand cmdSpotsInsert = new SqlCommand("Insert Into dbo.Spots (name, type, value, timestamp, batteryStatus,id,geoLatitude,geoLongitude) Values (@name, @type, @value, @timestamp, @batteryStatus, @id, @geoLatitude, @geoLongitude)", conn);
                        cmdSpotsInsert.Parameters.AddWithValue("@name", name);
                        cmdSpotsInsert.Parameters.AddWithValue("@type", type);
                        cmdSpotsInsert.Parameters.AddWithValue("@value", value);
                        cmdSpotsInsert.Parameters.AddWithValue("@batteryStatus", batteryStatus);
                        cmdSpotsInsert.Parameters.AddWithValue("@timestamp", enteredDate);
                        cmdSpotsInsert.Parameters.AddWithValue("@geoLatitude", geoLatitude);
                        cmdSpotsInsert.Parameters.AddWithValue("@geoLongitude", geoLongitude);
                        cmdSpotsInsert.Parameters.AddWithValue("@id", id);
                        cmdSpotsInsert.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand cmdSpots = new SqlCommand("Update dbo.Spots Set value = @value, batteryStatus=@batteryStatus, timestamp=@timestamp Where name=@name", conn);
                        cmdSpots.Parameters.AddWithValue("@name", name);
                        cmdSpots.Parameters.AddWithValue("@value", value);
                        cmdSpots.Parameters.AddWithValue("@batteryStatus", batteryStatus);
                        cmdSpots.Parameters.AddWithValue("@timestamp", enteredDate);
                        cmdSpots.ExecuteNonQuery();
                    }

                    SqlCommand cmdHistory = new SqlCommand("Insert Into dbo.History_Spots (idSpot, value, timestamp) Values (@idSpot, @value, @timestamp)", conn);
                    cmdHistory.Parameters.AddWithValue("@idSpot", name);
                    cmdHistory.Parameters.AddWithValue("@value", value);
                    cmdHistory.Parameters.AddWithValue("@timestamp", enteredDate);
                    cmdHistory.ExecuteNonQuery();

                    conn.Close();

                }
                catch (Exception exception)
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }
        }

        private static void ReadFromExcel(string filename)
        {

            //Criar App do excell
            string result = "";
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = false;

            //Abre a folha do excel
            Excel.Workbook workbook = excelApp.Workbooks.Open(filename);
            Excel.Worksheet sheet1 = workbook.ActiveSheet;

            ip = (sheet1.Cells[1, 2] as Excel.Range).Value;

            //Fechar o excell
            workbook.Close();
            excelApp.Quit();

            //Limpa a memória, os objetos (como se fosse o "gestor de tarefas")
            ReleaseCOMObject(sheet1);
            ReleaseCOMObject(workbook);
            ReleaseCOMObject(excelApp);

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
    }
}
