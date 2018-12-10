using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SmartPark.Controllers
{
    [RoutePrefix("api/spots")]
    public class SpotsController : ApiController
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SmartPark.Properties.Settings.ConnString"].ConnectionString;

        [Route("")]
        public IEnumerable<Spots> GetAll()
        {
            List<Spots> spots = new List<Spots>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                        Latitude = (string)reader["GeoLatitude"],
                        Longitude = (string)reader["GeoLongitude"]
                    };
                    spots.Add(s);
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return spots;
        }

        //2. Status of all parking spots in a specific park for a given moment
        [Route("{íd}/{timestamp}")]
        public IEnumerable<Spots> GetSpotByParkAndGivenTime(string id, string timestamp)
        {
            SqlConnection conn = null;
            List<Spots> spots = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots s Join History_Spots hs ON (s.name = hs.idSpot) Where idPark=@id And hs.timestamp=@date", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date", timestamp);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                        Latitude = (string)reader["GeoLatitude"],
                        Longitude = (string)reader["GeoLongitude"]


                    };
                    spots.Add(s);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return spots;
        }


        //5. List of parking spots belonging to a specific park
        [Route("parks/{id:int}")]
        public IEnumerable<Spots> Get(int id)
        {
           List<Spots> spots = new List<Spots>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots Where idPark=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                        Latitude = (string)reader["GeoLatitude"],
                        Longitude = (string)reader["GeoLongitude"]


                    };
                    spots.Add(s);
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return spots;
            }

        //7. Detailed information about a specific parking spot in a given moment (should also indicated if the spot is free or occupied)
        [Route("{name}/{timestamp}")]
        public IEnumerable<Spots> GetSpotByGivenTime(string name, string timestamp)
        {
            List<Spots> spots = new List<Spots>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < timestamp.Length; i++)
            {
                if(i%2 == 0)
                {
                    sb.Append('-');
                }
                sb.Append(timestamp[i]);

            }

            string date = sb.ToString();
            //DateTime formattedDate =  DateTime.ParseExact(date, "dd-mm-yy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture);

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots s Join History_Spots hs ON(s.name = hs.idSpot) where s.name=@nameSpot And hs.timestamp=@timestamp ", conn);
                //Select * From Spots s Join History_Spots hs ON(s.name = hs.idSpot) where hs.IdSpot ='A-1' AND hs.timestamp= '2018-12-10 00:00:00.000'
                cmd.Parameters.AddWithValue("@nameSpot", name);
                cmd.Parameters.AddWithValue("@timestamp", new DateTime(2018,10,12,12,59,00));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                        Latitude = (string)reader["GeoLatitude"],
                        Longitude = (string)reader["GeoLongitude"]
                    };
                    spots.Add(s);
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return spots;
        }
        

        //8. List of parking spots sensors that need to be replaced because of its critical battery level, within the overall platform
        [Route("needReplace")]
        public IEnumerable<Spots> GetSpotNeedReplace()
        {
            List<Spots> spots = new List<Spots>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots where batterystatus=1", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                        Latitude = (string)reader["GeoLatitude"],
                        Longitude = (string)reader["GeoLongitude"]
                    };
                    spots.Add(s);
                }
                reader.Close();
                conn.Close();

            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return spots;
        }

        [Route("park/{id:int}/needReplace")]
        //9. List of parking spots sensors that need to be replaced for a specific park
        public IEnumerable<Spots> GetSpotNeedReplaceByPark(int id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<Spots> spots = new List<Spots>();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select s.name, s.type,s.value,s.timestamp,s.batterystatus,s.id, s.geoLatitude, s.geoLongitude From Spots s Join Parks p on(p.Id=s.IdPark) Where s.IdPark=1 And s.batterystatus=1");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idpark", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                        Latitude = (string)reader["GeoLatitude"],
                        Longitude = (string)reader["GeoLongitude"]
                    };
                    spots.Add(s);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine(e);
                }
            }

            return spots;
        }

        [Route("park/{id:int}/occupancyRate")]
        //10. Instant occupancy rate in a specific park
        public IHttpActionResult GetOccupancyRate(int id)
        {
            Spots s = null;
            SqlConnection conn = new SqlConnection(connectionString);
            List<Spots> spots = new List<Spots>();
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("Select s.name, s.type,s.value,s.timestamp,s.batterystatus,s.id, s.geoLatitude, s.geoLongitude From Spots s join Parks p on(p.id=s.IdPark) Where s.IdPark=@idpark");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idpark", id);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s = new Spots
                    {
                        Id = (string)reader["Id"],
                        Name = (string)reader["Name"],
                        BatteryStatus = (int)reader["BatteryStatus"],
                        Type = (string)reader["Type"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"],
                    };
                    spots.Add(s);
                }
                
                reader.Close();
                conn.Close();

            }
            catch (Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            int totalSpots = spots.Count;
            int spotOcupados = 0;
            double rate = -1;
            foreach (Spots spot in spots)
            {
                if (spot.Value.Trim().ToLower().CompareTo("occupied")==0)
                {
                    spotOcupados++;
                }
            }
            try
            {
                rate = ((Double)spotOcupados / (Double)totalSpots)*100;
            }
            catch (Exception e)
            {

                throw new Exception ("Elementos invalidos");
            }
            
            return Ok(rate);
        }

    }
}
