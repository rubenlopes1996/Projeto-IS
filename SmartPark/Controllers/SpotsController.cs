using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartPark.Controllers
{
    public class SpotsController : ApiController
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SmartPark.Properties.Settings.ConnString"].ConnectionString;

        //[Route("api/spots")]
        public IEnumerable<Spots> Get()
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
                        Id = (int)reader["Id"],
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
            return spots;
        }

        //5. List of parking spots belonging to a specific park
        //[Route("api/spots/{id:int}")]
        /*public IEnumerable<Spots> Get(int id)
        {
            Spots s = null;
            SqlConnection conn = new SqlConnection(connectionString);
            List<Spots> spots = new List<Spots>();
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("Select * From Spots s join Park_Spot ps on(ps.IdSpot=s.Id) Where ps.IdPark=@idpark");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idpark", id);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s = new Spots
                    {
                        Id = (int)reader["Id"],
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

            return spots;
        }*/

        //8. List of parking spots sensors that need to be replaced because of its critical battery level, within the overall platform
        /*[Route("api/spots/needReplace")]
        public IEnumerable<Spots> Get()
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
                        Id = (int)reader["Id"],
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
            return spots;
        }*/

        //9. List of parking spots sensors that need to be replaced for a specific park
        /*public IEnumerable<Spots> Get(int id)
        {
            Spots s = null;
            SqlConnection conn = new SqlConnection(connectionString);
            List<Spots> spots = new List<Spots>();
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("Select * From Spots s join Park_Spot ps on(ps.IdSpot=s.Id) Where ps.IdPark=@idpark and batteryStatus=1");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idpark", id);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s = new Spots
                    {
                        Id = (int)reader["Id"],
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

            return spots;
        }*/

        //10. Instant occupancy rate in a specific park
        public IHttpActionResult Get(int id)
        {
            Spots s = null;
            SqlConnection conn = new SqlConnection(connectionString);
            List<Spots> spots = new List<Spots>();
            try
            {
                conn.Open();


                SqlCommand cmd = new SqlCommand("Select * From Spots s join Park_Spot ps on(ps.IdSpot=s.Id) Where ps.IdPark=@idpark");
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@idpark", id);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    s = new Spots
                    {
                        Id = (int)reader["Id"],
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
