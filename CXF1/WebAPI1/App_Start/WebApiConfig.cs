using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API の設定およびサービス

            // Web API ルート
            config.MapHttpAttributeRoutes();    //属性ルーティングを有効化

            config.Routes.MapHttpRoute(
                name: "route-001",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
