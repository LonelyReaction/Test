using System;
using System.Web.Http;
using System.Collections.Generic;
using WebAPIModels;
using System.Diagnostics;
using System.IO;

namespace WebAPI1.Controllers
{
    [Route("api/Home")]
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/Home")]
        public WebAPIClass Get()
        {
            return new WebAPIClass();
        }
        [HttpGet]
        [Route("api/Home/{id}")]
        public WebAPIClass GetWithID(int id)
        {
            return new WebAPIClass(id);
        }
        [HttpGet]
        [Route("api/Home/List")]
        public List<WebAPIClass> GetList()
        {
            return new List<WebAPIClass> { new WebAPIClass(123), new WebAPIClass(456), new WebAPIClass(789) };
        }
        [HttpPost]
        [Route("api/Home/Post/Dictionary")]
        public System.Net.Http.HttpResponseMessage PostDictionary([FromBody]Dictionary<string, string> list)
        {
            if (ModelState.IsValid)
            {
                string data = "";
                foreach (var item in list)
                {
                    data += $"Key={item.Key}/Value={item.Value}\r\n";
                }
                File.WriteAllText($@"C:\Temp\WebAPITester\{DateTime.Now:yyyyMMddHHmmssfff}_PostDictionary.txt", data);
                return new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            return new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }
        [HttpPost]
        [Route("api/Home/Post/List")]
        public System.Net.Http.HttpResponseMessage PostList([FromBody]List<WebAPIClass> list)
        {
            if (ModelState.IsValid)
            {
                string data = "";
                foreach (var item in list)
                {
                    data += $"IntData={item.IntData}/StringData={item.StringData}/TimeData={item.TimeData}\r\n";
                }
                File.WriteAllText($@"C:\Temp\WebAPITester\{DateTime.Now:yyyyMMddHHmmssfff}_PostList.txt", data);
                return new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            return new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
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
