using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ParkSS
{

    class Program
    {

        static void Main(string[] args)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ParkSS.Properties.Settings.ConnectionString"].ConnectionString;

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
            String data = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine(($"{e.Topic}: {data} \n"));
        }
    }
}
