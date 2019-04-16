using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebAPIModels;

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

        private void button2_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                var content = new Dictionary<string, string>();
                content.Add("id", "1");
                content.Add("content", "123");
                content.Add("message", "aho-");
                content.Add("flag", "false");
                string queryString = $"http://192.168.3.191/WebService/api/Home/Post/Dictionary";
                var response = client.PostAsJsonAsync(queryString, content).GetAwaiter().GetResult();
            }
            using (HttpClient client = new HttpClient())
            {
                var content = new List<WebAPIClass> { new WebAPIClass(321), new WebAPIClass(654), new WebAPIClass(987) };
                string queryString = $"http://192.168.3.191/WebService/api/Home/Post/List";
                var response = client.PostAsJsonAsync(queryString, content).GetAwaiter().GetResult();
            }
            using (HttpClient client = new HttpClient())
            {
                string queryString = $"http://192.168.3.191/WebService/api/Home/List";
                var response = client.GetAsync(queryString).GetAwaiter().GetResult();
                string jsonText = response.Content.ReadAsStringAsync().Result;
                var ret = JsonConvert.DeserializeObject<List<WebAPIClassBaseModel>>(jsonText);
                MessageBox.Show($"{ret[1].StringData}");
            }
        }
        public class WebAPIClass : WebAPIClassBaseModel
        {
            public WebAPIClass(int id)
            {
                this.StringData = $"This is message from web service ({id * 2})";
                this.IntData = id;
                this.TimeData = DateTime.Now;
            }
            public WebAPIClass()
            {
                this.StringData = "This is message from web service (Get)";
                this.IntData = 777;
                this.TimeData = DateTime.Now;
            }
        }
    }
}
