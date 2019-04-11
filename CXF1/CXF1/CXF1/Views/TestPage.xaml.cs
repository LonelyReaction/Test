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
                //client.BaseAddress = new Uri("http://192.168.3.191/WebService/");
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/xml"));
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //returnValue = client.GetStringAsync("api/Home/GetData/").GetAwaiter().GetResult();

                //var response = client.GetStringAsync("api/Home/GetString/").GetAwaiter().GetResult();
                //returnValue = response.ToString();

                //var response = client.GetStringAsync("api/Home/").GetAwaiter().GetResult();

                //string queryString = "http://api.thni.net/jzip/X0401/JSON/520/0863.js";
                string queryString = "http://192.168.3.191/WebService/api/Home/";
                var response = client.GetAsync(queryString).GetAwaiter().GetResult();
                string jsonText = response.Content.ReadAsStringAsync().Result;
                //jsonText = "{ \"StringData\":\"This is message from web service (Get)\", \"IntData\":777 }";
                //jsonText = "{ \"state\":\"25\", \"stateName\":\"滋賀県\", \"city\":\"大津市\", \"street\":\"千町\" }";

                //var webAPIClass = JsonConvert.DeserializeObject<WebAPIClass>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var webAPIClass = JsonConvert.DeserializeObject<WebAPIClass>(jsonText);
                returnValue = $"{webAPIClass.StringData}/{webAPIClass.TimeData:yyyy/MM/dd HH:mm:ss}/{webAPIClass.IntData}";
                //returnValue = $"{webAPIClass.StringData}/{webAPIClass.IntData}";
                //returnValue = response;

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
    // Type created for JSON at <<root>>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class WebAPIClass
    {
        [JsonProperty("StringData")]
        public string StringData;

        [JsonProperty("IntData")]
        public int IntData;

        [JsonProperty("TimeData")]
        public DateTime TimeData;
    }
}