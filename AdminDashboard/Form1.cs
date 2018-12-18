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
        List<Spots> spotsSpecificParkPerData = new List<Spots>();
        List<Spots> spotsPerData = new List<Spots>();
        List<Spots> listSpotsBelongingPark = new List<Spots>();
        List<Spots> freeSpotsSpecificPark = new List<Spots>();
        Park parkInfoSpecificPark = new Park();
        List<Spots> listSpotsNeedReplace = new List<Spots>();
        List<Spots> listSpotsNeedReplaceSpecificPark = new List<Spots>();
        List<Spots> allSpots = new List<Spots>();
        String occupancyRate = null;
        Spots infoSpecificSpot = new Spots();


        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri(baseURI);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }

        /*
         * int api
         *  0 - Parks
         *  1 - Spots por tempo e data
         *  2 - Parks por tempo e data
         *  3 - Free spots of specific park
         *  4 - List Spots of specific park
         *  5 - Information Specific park
         *  6 - Info specific spot
         *  7 - Needs Replace
         *  8 - Spots need replace within a specific park
         *  9 - OccupacyRate
         *  10 - Get all spots
         */

        private void loadAPIS(int api, string apiAppend)
        {
            HttpResponseMessage response = client.GetAsync($""+ apiAppend).Result;

            if (response.IsSuccessStatusCode)
            {
                //Converter a resposta (json) para um objeto product
                string json = response.Content.ReadAsStringAsync().Result;

                switch (api)
                {
                    case 0:
                        parks = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Park>>(json);
                        break;
                    case 1:
                        spotsPerData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    case 2: 
                        spotsSpecificParkPerData = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    case 3: 
                        freeSpotsSpecificPark = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    case 4:
                        listSpotsBelongingPark = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    case 5: 
                        parkInfoSpecificPark = Newtonsoft.Json.JsonConvert.DeserializeObject<Park>(json);
                        break;
                    case 6:
                        infoSpecificSpot = Newtonsoft.Json.JsonConvert.DeserializeObject<Spots>(json);
                        break;
                    case 7:
                        listSpotsNeedReplace = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    case 8:
                        listSpotsNeedReplaceSpecificPark = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    case 9:
                        occupancyRate = Newtonsoft.Json.JsonConvert.DeserializeObject<String>(json);
                        break;
                    case 10: 
                        allSpots = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Spots>>(json);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Service unable to process your request" + response.StatusCode + " " + response.ReasonPhrase);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parks.Clear();
            spotsSpecificParkPerData.Clear();
            spotsPerData.Clear(); 
            listSpotsBelongingPark.Clear();
            freeSpotsSpecificPark.Clear();
            parkInfoSpecificPark = null;
            listSpotsNeedReplace.Clear();
            listSpotsNeedReplaceSpecificPark.Clear();
            allSpots.Clear();
            occupancyRate = null;
            infoSpecificSpot = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string apiAppendParks = "api/parks";
            string apiAppendSpots = "api/spots";

            loadAPIS(0, apiAppendParks);
            loadAPIS(10, apiAppendSpots);

            richTextBox1.Clear();
            foreach (Park park in parks)
            {
                richTextBox1.AppendText(ShowPark(park));
                this.tabControl1.TabPages[0].Focus();
                comboBox2.Items.Add(park.Name);
                parkSpecificParkData.Items.Add(park.Name);
                comboBoxSpotsSpecificPark.Items.Add(park.Name);
                comboBoxFreeParks.Items.Add(park.Name);
                comboBoxInfoSpecificPark.Items.Add(park.Name);
                comboBoxSpotsReplacePark.Items.Add(park.Name);
                comboBoxOccupancyRate.Items.Add(park.Name);
            }

            foreach (Spots spot in allSpots)
            {
                comboBoxInfoSpecificSpot.Items.Add(spot.Name);
            }

            //Predefinição de um valor
            comboBox2.SelectedIndex = 0;
            parkSpecificParkData.SelectedIndex = 0;
            comboBoxSpotsSpecificPark.SelectedIndex = 0;
            comboBoxFreeParks.SelectedIndex = 0;
            comboBoxInfoSpecificPark.SelectedIndex = 0;
            comboBoxSpotsReplacePark.SelectedIndex = 0;
            comboBoxOccupancyRate.SelectedIndex = 0;
            comboBoxInfoSpecificSpot.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = dateTimePicker3.Value.ToString("yyyy-M-d");
            string time = dateTimePicker1.Value.ToString("HH:mm:ss");
            string park = comboBox2.SelectedItem.ToString();
            string toAppendAPI = "api/spots/" + park + "/date/" + data + "T" + time;

            if (spotsPerData.Count() == 0)
            {
                loadAPIS(1, toAppendAPI);
            }
            
            richTextBox2.Clear();

            foreach (Spots spot in spotsPerData)
            {
                richTextBox2.AppendText(ShowSpot(spot));
                this.tabControl1.TabPages[0].Focus();
            }

            spotsPerData.Clear();
            MessageBox.Show(spotsPerData.Count().ToString());
        }

        private string ShowSpot(Spots s)
        {
            return string.Format("Id: {0} \n\tName: {1} \n\tType: {2} \n\tLatitude: {3} " +
                "\n\tLongitude: {4} \n\tValue: {5} \n\tDate Time: {6} \n\tBattery Status: {7} \n\n",
                s.Id, s.Name, s.Type, s.Latitude, s.Longitude, s.Value, s.Timestamp, s.BatteryStatus);
        }

        private string ShowPark(Park p)
        {
            return string.Format("Name: {0} \n\tNumber of Spots: {1} \n\tNumber of Special Spots: {2} \n\tOperation Hours: {3} \n\n",
                p.Name, p.NumberOfSpots, p.NumberOfSpecialSpots, p.operationHours);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string startData = startDateSpecificPark.Value.ToString("yyyy-M-d");
            string endData = endDateSpecificPark.Value.ToString("yyyy-M-d");
            string startTime = startTimeParks.Value.ToString("HH:mm:ss");
            string endTime = endTimeSpecificPark.Value.ToString("HH:mm:ss");
            string park = parkSpecificParkData.SelectedItem.ToString();
            string toAppendAPI = "api/parks/" + park + "/startdate/" + startData + "T" + startTime + "/finaldate/" + endData + "T" + endTime;

            if(spotsSpecificParkPerData.Count() == 0)
            {
                loadAPIS(2, toAppendAPI);
            }

            spotsSpecificParkData.Clear();

            foreach (Spots spot in spotsSpecificParkPerData)
            {
                spotsSpecificParkData.AppendText(ShowSpot(spot));
                this.tabControl1.TabPages[0].Focus();
            }
        }

        private void buttonListBelongingPark_Click(object sender, EventArgs e)
        {
            string park = comboBoxSpotsSpecificPark.SelectedItem.ToString();
            string toAppendAPI = "api/spots/park/" + park;

            if (listSpotsBelongingPark.Count() == 0)
            {
                loadAPIS(4, toAppendAPI);
            }
            

            richTextBoxListBelongingPark.Clear();

            foreach (Spots spot in listSpotsBelongingPark)
            {
                richTextBoxListBelongingPark.AppendText(ShowSpot(spot));
                this.tabControl1.TabPages[0].Focus();
            }
        }

        private void buttonFreeParkingSpots_Click(object sender, EventArgs e)
        {
            string data = datePickerFreeParkingSpots.Value.ToString("yyyy-M-d");
            string time = timePickerFreeParkingSpots.Value.ToString("HH:mm:ss");
            string park = comboBoxFreeParks.SelectedItem.ToString();
            string toAppendAPI = "api/parks/free/" + park + "/date/" + data + "T" + time;

            if (freeSpotsSpecificPark.Count() == 0)
            {
                loadAPIS(3, toAppendAPI);
            }

            richTextBox2.Clear();

            foreach (Spots spot in freeSpotsSpecificPark)
            {
                richTextBoxFreeParkingSpot.AppendText(ShowSpot(spot));
                this.tabControl1.TabPages[0].Focus();
            }
        }

        private void buttonSpecificPark_Click(object sender, EventArgs e)
        {
            string park = comboBoxInfoSpecificPark.SelectedItem.ToString();
            string toAppendAPI = "api/parks/" + park;

            if(parkInfoSpecificPark == null)
            {
                loadAPIS(5, toAppendAPI);
            }

            richTextBoxInfoSpecificPark.Clear();

           richTextBoxInfoSpecificPark.AppendText(ShowPark(parkInfoSpecificPark));
        }

        private void buttonSpotsNeedReplace_Click(object sender, EventArgs e)
        {
            string toAppendAPI = "api/spots/needReplace";

            if (listSpotsNeedReplace.Count() == 0)
            {
                loadAPIS(7, toAppendAPI);
            }
           
            richTextBoxSpotsNeedReplace.Clear();

            foreach (Spots spot in listSpotsNeedReplace)
            {
                richTextBoxSpotsNeedReplace.AppendText(ShowSpot(spot));
                this.tabControl1.TabPages[0].Focus();
            }
        }

        private void buttonSpotsReplacePark_Click(object sender, EventArgs e)
        {
            string park = comboBoxSpotsReplacePark.SelectedItem.ToString();
            string toAppendAPI = "api/spots/park/" + park + "/needReplace";

            if(listSpotsNeedReplaceSpecificPark.Count() == 0)
            {
                loadAPIS(8, toAppendAPI);
            }

            richTextBoxNeedReplacePark.Clear();

            foreach (Spots spot in listSpotsNeedReplaceSpecificPark)
            {
                richTextBoxNeedReplacePark.AppendText(ShowSpot(spot));
                this.tabControl1.TabPages[0].Focus();
            }
        }

        private void buttonOccupancyRate_Click(object sender, EventArgs e)
        {
            string park = comboBoxOccupancyRate.SelectedItem.ToString();
            string toAppendAPI = "api/spots/park/" + park + "/occupancyRate";

            if (occupancyRate == null)
            {
                loadAPIS(9, toAppendAPI);
            }

            richTextBoxOccupancyRate.Clear();

            richTextBoxOccupancyRate.AppendText(occupancyRate);

            
        }

        private void buttonInfoSpecificSpot_Click(object sender, EventArgs e)
        {
            string spot = comboBoxInfoSpecificSpot.SelectedItem.ToString();
            string data = datePickerSpotSpecificTime.Value.ToString("yyyy-M-d");
            string time = TimePickerSpotSpecificTime.Value.ToString("HH:mm:ss");
               
            if(infoSpecificSpot == null)
            {
                string toAppendAPI = "api/spots/" + spot + "/" + data + "T" + time;
                loadAPIS(6, toAppendAPI);
            }

            richTextBoxInfoSpecificSpot.Clear();


            if (infoSpecificSpot.ToString() == null)
            {
                
                richTextBoxInfoSpecificSpot.AppendText(ShowSpot(infoSpecificSpot));
            }
            else
            {
                richTextBoxInfoSpecificSpot.AppendText("Nao foi encontrado nenhum lugar nessa data e hora");
            }
            
        }
    }
}
