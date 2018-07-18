﻿using System.Web.Http;
using Owin;

namespace Freemium.Game.Shop.MainAttributes
{
    public class Startup
    {
       public void Configuration(IAppBuilder app)
       {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "ClientController",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional}
            );

            app.UseWebApi(config);
       }
    }
}
