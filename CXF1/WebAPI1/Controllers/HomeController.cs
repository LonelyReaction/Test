using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebAPI1.Controllers
{
    public class HomeController : ApiController
    {
        //public string GetString()
        //{
        //    return "This is message from web service (api/Home/GetString/)";
        //}
        //public int GetInt()
        //{
        //    return 777;
        //}
        //public string Get()
        //{
        //    return JsonConvert.SerializeObject(new WebAPIClass());
        //}
        public WebAPIClass Get()
        {
            return new WebAPIClass();
        }
    }
    public class WebAPIClass
    {
        public string StringData { get; private set;  }
        public int IntData { get; private set; }
        public DateTime TimeData { get; private set; }
        public WebAPIClass()
        {
            this.StringData = "This is message from web service (Get)";
            this.IntData = 777;
            this.TimeData = DateTime.Now;
        }
    }
}
