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
                        Id = (int)reader["Id"],
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

        //2. Status of all parking spots in a specific park for a given moment
        //GET: api/parks/1/spots
        [Route("{id:int}/spots")]
        public IEnumerable<Spots> GetStatusOfAllSpotsFromPark(int id)
        {
            List<Spots> spots = new List<Spots>();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select id,name,value,timestamp From Spots Where idPark=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Spots s = new Spots
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Value = (string)reader["Value"],
                        Timestamp = (DateTime)reader["Timestamp"]

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


        //3. List of status of all parking spots in a specific park for a given time period


        //4. List of free parking spots from a specific park for a given moment




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
                        Id = (int)reader["Id"],
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

        //7. Detailed information about a specific parking spot in a given moment (should also indicated if the spot is free or occupied)
        
        
    

    }
}
