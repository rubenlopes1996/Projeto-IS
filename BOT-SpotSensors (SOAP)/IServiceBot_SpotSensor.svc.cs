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
        public ParkingSpot CreateSensorData()
        {
                Random random = new Random();
                int value = random.Next(0, 2);
                string valueSpot = value == 0 ? "free" : "occupied";
                int rand = random.Next(0, 50);
                int batteryStatus;
                if (rand < 45)
                {
                    batteryStatus = 0;
                }

                else
                {
                    batteryStatus = 1;
                }

                 ParkingSpot spot = new ParkingSpot
                {
                    Id = "",
                    Name ="",
                    Location = "",
                    Value = valueSpot,
                    Timestamp = DateTime.Now,
                    BatteryStatus = batteryStatus,
                };

            return spot;

        }

        public String CreateSensorDataXML()
        {
            XmlDocument doc = new XmlDocument();


            
            XmlElement parkingSpot = doc.CreateElement("parkingSpot");
            doc.AppendChild(parkingSpot);
            XmlElement idSpot = doc.CreateElement("id");
            idSpot.InnerText = "";

            XmlElement typeSpot = doc.CreateElement("type");
            typeSpot.InnerText = "Parking spot";

            XmlElement nameSpot = doc.CreateElement("name");
            nameSpot.InnerText = "";

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
            int rand = random.Next(0, 50);
            if (rand < 45) 
            {
                batteryStatus.InnerText = "0";
            }
                 
            else 
            {
                batteryStatus.InnerText = "1";
            }

            parkingSpot.AppendChild(idSpot);
            parkingSpot.AppendChild(typeSpot);
            parkingSpot.AppendChild(nameSpot);
            parkingSpot.AppendChild(locationSpot);
            statusSpot.AppendChild(valueSpot);
            statusSpot.AppendChild(timestamp);
            parkingSpot.AppendChild(statusSpot);
            parkingSpot.AppendChild(batteryStatus);

            return doc.OuterXml;


        }


    }
}
