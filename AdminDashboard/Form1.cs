using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminDashboard
{
    public partial class Form1 : Form
    {
        string baseURI = @"http://localhost:57282";
        HttpClient client;
        List<Park> parks = new List<Park>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadAPIS();
        }

        private void loadAPIS()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync($"api/parks").Result;


            if (response.IsSuccessStatusCode)
            {
                //Converter a resposta (json) para um objeto product
                string json = response.Content.ReadAsStringAsync().Result;
                parks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Park>>(json);


                richTextBox1.Clear();
                foreach (Park park in parks)
                {
                    richTextBox1.AppendText(ShowPark(park));
                    this.tabControl1.TabPages[0].Focus();
                }
            }
            else
            {
                MessageBox.Show("Service unable to process your request" + response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        private string ShowPark(Park p)
        {
            return string.Format("Name: {0} \n\tNumber of Spots: {1} \n\tNumber of Special Spots: {2} \n\tOperation Hours: {3} \n\n", p.Name, p.NumberOfSpots, p.NumberOfSpecialSpots, p.operationHours);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadAPIS();
        }
    }
}
