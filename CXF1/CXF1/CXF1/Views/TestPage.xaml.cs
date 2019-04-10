using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Newtonsoft.Json;

namespace CXF1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TestPage : ContentPage
	{
		public TestPage ()
		{
			InitializeComponent ();
            this.lblMessage1.Text = "※※※TestData①※※※";  //TestPage.GetTest();
            this.lblMessage2.Text = "※※※TestData②※※※";  //TestPage.GetTest();
            this.lblMessage3.Text = "※※※TestData③※※※";  //TestPage.GetTest();
            this.lblMessage2.Text = TestPage.GetTest();
        }
        public string DataText { get; set; }
        public static string GetTest()
        {
            string returnValue = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.3.191/WebService/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //returnValue = client.GetStringAsync("api/Home/GetData/").GetAwaiter().GetResult();

                //var response = client.GetStringAsync("api/Home/GetString/").GetAwaiter().GetResult();
                //returnValue = response.ToString();

                var response = client.GetStringAsync("api/Home").GetAwaiter().GetResult();
                //var webAPIClass = JsonConvert.DeserializeObject<WebAPIClass>(response);
                //returnValue = string.Format("{0}/{1:yyyy/MM/dd HH:mm:ss}/{2}", webAPIClass.StringData, webAPIClass.TimeData, webAPIClass.IntData);
                returnValue = response;

                //HttpResponseMessage response = client.GetAsync("api/Home/GetWebAPIClass/").Result;
                //returnValue = response.Content.ReadAsAsync<WebAPIClass>().Result;
            }
            return returnValue;
        }
        public static string GetTest1()
        {
            string returnValue = null;
            using (HttpClient client = new HttpClient())
            {
                var hostName = System.Net.Dns.GetHostName().ToUpper();
                //route = "localhost:50072";
                //client.BaseAddress = new Uri("http://bamss-w161ss17/WebService/");
                client.BaseAddress = new Uri("http://192.168.3.191/WebService/");
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //returnValue = client.GetStringAsync("api/Home/GetData/").GetAwaiter().GetResult();

                var response = client.GetStringAsync("api/Home/GetString/").GetAwaiter().GetResult();
                returnValue = response.ToString();

                //var response = await client.GetAsync("api/Home/GetString/");
                //returnValue = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result).ToString();

                //HttpResponseMessage response = client.GetAsync("api/Home/GetWebAPIClass/").Result;
                //returnValue = response.Content.ReadAsAsync<WebAPIClass>().Result;
            }
            return returnValue;
        }
    }
    public class WebAPIClass
    {
        public string StringData;
        public int IntData;
        public DateTime TimeData;
    }
}