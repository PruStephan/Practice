﻿using System.Web.Http;
using Owin;

namespace FreemiumGameShop.WebAPI
{
    public class Startup
    {
       public void Configuration(IAppBuilder app)
       {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
       }
    }
}
