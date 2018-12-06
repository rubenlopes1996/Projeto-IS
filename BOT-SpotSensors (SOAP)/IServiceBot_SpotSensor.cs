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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceBot_SpotSensor
    {
        [OperationContract]
        List<ParkingSpot> CreateSensorData(int numberOfSpots);

        [OperationContract]
        string CreateSensorDataXML();

       
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class ParkingSpot
    {
        //[DataMember]
        //public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        [DataMember]
        public int BatteryStatus { get; set; }



    }




}
