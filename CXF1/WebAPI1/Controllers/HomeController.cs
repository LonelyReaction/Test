using System;
using System.Web.Http;
using System.Collections.Generic;
using WebAPIModels;

namespace WebAPI1.Controllers
{
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
