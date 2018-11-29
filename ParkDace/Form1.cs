using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ParkDace
{
    public partial class Form1 : Form
    {
        ParkingSensorNodeDll.ParkingSensorNodeDll dll = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button_fetchSpots_Click(object sender, EventArgs e)
        {
            dll = new ParkingSensorNodeDll.ParkingSensorNodeDll();
            dll.Initialize(SpotsPark, 800);


        }

        private void SpotsPark(string str)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                richTextBoxSpotsDLL.AppendText(str + "\n");
            });
        }

        private void button_stopFetching_Click_1(object sender, EventArgs e)
        {
            dll.Stop();

        }

        private void richTextBoxSpotsDLL_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonFetchBotSpots_Click(object sender, EventArgs e)
        {
            BotSpotSensors.ServiceBot_SpotSensorClient service = new BotSpotSensors.ServiceBot_SpotSensorClient();
            

        }
    }
}
