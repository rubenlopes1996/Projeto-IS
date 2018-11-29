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
        public List<ParkingSpot> CreateSensorData(int id, int numberSpots)
        {
            List<ParkingSpot> spots = new List<ParkingSpot>();
            for (int i = 0; i < numberSpots; i++)
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
                    Id = id,
                    Name ="Spot"+i,
                    Location = "",
                    Value = valueSpot,
                    Timestamp = DateTime.Now,
                    BatteryStatus = batteryStatus,
                };

                spots.Add(spot);
            }
            return spots;

        }

        public String CreateSensorDataXML(string id, int numberOfSpots)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("Spots");
            doc.AppendChild(root);


            for (int i = 0; i < numberOfSpots; i++)
            {
                XmlElement parkingSpot = doc.CreateElement("parkingSpot");

                XmlElement idSpot = doc.CreateElement("id");
                idSpot.InnerText = id;

                XmlElement typeSpot = doc.CreateElement("type");
                typeSpot.InnerText = "Parking spot";

                XmlElement nameSpot = doc.CreateElement("name");
                nameSpot.InnerText = "B-" + i+1;

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
                root.AppendChild(parkingSpot);




            }

            return doc.OuterXml;


        }


    }
}
