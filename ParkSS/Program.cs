﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ParkSS
{

    class Program
    {
        private static string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkSS.Properties.Settings.ConnectionString"].ConnectionString;


        static void Main(string[] args)
        {

            MqttClient client = null;
            string[] topics = { "Data" };

            client = new MqttClient("127.0.0.1");
            client.Connect(Guid.NewGuid().ToString());
            if (!client.IsConnected)
            {
                Console.WriteLine("Unable to connect with the broker");
            }
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE};
            client.Subscribe(topics, qosLevels);
            
        }

        private static void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            Console.WriteLine("Deixei de subscrever os tópicos");
        }

        private static void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string data = Encoding.UTF8.GetString(e.Message);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            Console.WriteLine("Receving data");
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
                SqlCommand cmdHistory = new SqlCommand("Insert Into dbo.History_Spots (idSpot, value, timestamp) Values (@idSpot, @value, @timestamp)", conn);

                cmdHistory.Parameters.AddWithValue("@idSpot", name);
                cmdHistory.Parameters.AddWithValue("@value", value);
                cmdHistory.Parameters.AddWithValue("@timestamp", enteredDate);
                cmdHistory.ExecuteNonQuery();

                SqlCommand cmdSpots = new SqlCommand("Update dbo.Spots Set value = @value, batteryStatus=@batteryStatus, timestamp=@timestamp Where name=@name", conn);
                cmdSpots.Parameters.AddWithValue("@name", name);
                cmdSpots.Parameters.AddWithValue("@value", value);
                cmdSpots.Parameters.AddWithValue("@batteryStatus", batteryStatus);
                cmdSpots.Parameters.AddWithValue("@timestamp", enteredDate);
                cmdSpots.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

          //Caso seja preciso criar os primeiros dados na tabela de Spots
            /*SqlConnection conn2 = new SqlConnection(connectionString);

            try
            {
                conn2.Open();
                SqlCommand cmdSpots = new SqlCommand("Insert Into dbo.Spots (name, type, value, timestamp, batteryStatus,id,geoLatitude,geoLongitude) Values (@name, @type, @value, @timestamp, @batteryStatus, @id, @geoLatitude, @geoLongitude)", conn2);

                cmdSpots.Parameters.AddWithValue("@name", name);
                cmdSpots.Parameters.AddWithValue("@type", type);
                cmdSpots.Parameters.AddWithValue("@value", value);
                cmdSpots.Parameters.AddWithValue("@batteryStatus", batteryStatus);
                cmdSpots.Parameters.AddWithValue("@timestamp", enteredDate);
                cmdSpots.Parameters.AddWithValue("@geoLatitude", geoLatitude);
                cmdSpots.Parameters.AddWithValue("@geoLongitude", geoLongitude);
                cmdSpots.Parameters.AddWithValue("@id", id);
               
                cmdSpots.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                if (conn2.State == System.Data.ConnectionState.Open)
                {
                    conn2.Close();
                }
            }*/
        


        }
    }
}