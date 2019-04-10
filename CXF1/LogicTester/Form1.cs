using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace LogicTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label1.Text = this.GetTest();
        }
        public string GetTest()
        {
            string returnValue = null;
            using (HttpClient client = new HttpClient())
            {
                var hostName = System.Net.Dns.GetHostName().ToUpper();
                //route = "localhost:50072";
                client.BaseAddress = new Uri("http://bamss-w161ss17/WebService/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                //using (HttpResponseMessage response = client.GetAsync("api/Home/GetData/").Result)
                //{
                //    if (response.IsSuccessStatusCode)
                //    {
                //        returnValue = response.Content.ReadAsStringAsync().Result;  //.ReadAsAsync<string>().Result;
                //    }
                //    else
                //    {
                //        throw new Exception(response.ReasonPhrase);
                //    }
                //}
                returnValue = client.GetStringAsync("api/Home/GetTest/").GetAwaiter().GetResult();
            }
            return returnValue;
        }
    }
}
