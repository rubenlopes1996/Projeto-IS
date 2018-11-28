using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace BOT_SpotSensors__SOAP_
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IServiceBot_SpotSensor
    {
        public ParkingSpot CreateSensorData(int id, string name, string location, bool value, DateTime timestamp, bool batteryStatus)
        {
            return new ParkingSpot
            {
                Id = id,
                Name = name,
                Location = location,
                Value = value,
                Timestamp = timestamp,
                BatteryStatus = batteryStatus,
            };
        }

        public string CreateSensorDataXML(string id, int numberOfSpots)
        {
            String xmlReturn = "";
            for (int i = 0; i < numberOfSpots; i++)
            {
                XmlDocument doc = new XmlDocument();
                XmlElement parkingSpot = doc.CreateElement("parkingSpot");

                XmlElement idSpot = doc.CreateElement("id");
                idSpot.InnerText = id;

                XmlElement typeSpot = doc.CreateElement("type");
                typeSpot.InnerText = "Parking spot";

                XmlElement nameSpot = doc.CreateElement("name");
                nameSpot.InnerText = "Spot" + i;

                XmlElement locationSpot = doc.CreateElement("location");
                locationSpot.InnerText = "";

                XmlElement statusSpot = doc.CreateElement("status");
                
                XmlElement valueSpot = doc.CreateElement("value");
                Random random = new Random();
                int value = random.Next(0, 2);
                valueSpot.InnerText = value == 0 ? "free" : "occupied";

                XmlElement timestamp = doc.CreateElement("timestamp");
                timestamp.InnerText = DateTime.Now.ToString();

                XmlElement batteryStatus = doc.CreateElement("batteryStatus");
                batteryStatus.InnerText = value == 0 ? "0" : "1";

                parkingSpot.AppendChild(idSpot);
                parkingSpot.AppendChild(typeSpot);
                parkingSpot.AppendChild(nameSpot);
                statusSpot.AppendChild(valueSpot);
                statusSpot.AppendChild(timestamp);
                parkingSpot.AppendChild(statusSpot);
                parkingSpot.AppendChild(batteryStatus);
                doc.AppendChild(parkingSpot);

                xmlReturn += doc.OuterXml;

            }

            return xmlReturn;
        }

      
    }
}
