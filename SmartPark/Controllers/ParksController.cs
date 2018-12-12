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
    [RoutePrefix("api/parks")]
    public class ParksController : ApiController
    {
    
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SmartPark.Properties.Settings.ConnString"].ConnectionString;

        // GET: api/Parks
        //1. List of available parks in the platform
        [Route("")]
        public IEnumerable<Park> GetParks()
        {
            List<Park> parks = new List<Park>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Parks", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Park p = new Park
                    {
                        //Id = (int)reader["Id"],
                        Name = (string)reader["Name"]
                    };
                    parks.Add(p);
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
            return parks;
        }

        //3. List of status of all parking spots in a specific park for a given time period
        [Route("{íd}/{startDate}/{finalDate}")]
        public IEnumerable<Spots> GetSpotByParkAndGivenTime(string id, string startDate, string finalDate)
        {
            SqlConnection conn = null;
            List<Spots> spots = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots s Join History_Spots hs ON (s.name = hs.idSpot) Where idPark=@id And hs.timestamp Between @startDate And @endDate", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@startDate", startDate);
                cmd.Parameters.AddWithValue("@endDate", finalDate);

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
            catch(Exception e)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return spots;
        }

        //4. List of free parking spots from a specific park for a given moment
        [Route("free/{íd}/{timestamp}")]
        public IEnumerable<Spots> GetFreeSpotsByParkAndGivenTime(string id, string timestamp)
        {
            SqlConnection conn = null;
            List<Spots> spots = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * From Spots s Join History_Spots hs ON (s.name = hs.idSpot) Where idPark=@id And hs.timestamp = @time And hs.value = free", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@time", timestamp);

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


        //6. Detailed information about a specific park
        // GET api/parks/1
        [Route("{id:int}")]
        public IHttpActionResult GetPark(int id)
        {
            SqlConnection conn = null;
            Park p = null;
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * From Parks Where Id=@idpark";
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idpark", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    p = new Park
                    {
                        //Id = (int)reader["Id"],
                        Name = (string)reader["Name"]
                    };
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                return NotFound();
            }

            return Ok(p);
        }

        
        
    

    }
}
