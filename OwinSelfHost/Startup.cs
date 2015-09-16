using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web;
using System.Web.Http;
using Metrics;
using Owin;
using Swashbuckle.Application;
using WebApi.Hal;

namespace OwinSelfHost
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.Use<LoggingMiddleware>();
            appBuilder.UseWebApi(GetWebApiConfig());
        }

        private static HttpConfiguration GetWebApiConfig()
        {
            Metric.Config
                .WithHttpEndpoint("http://localhost:9999/metrics/")
                .WithAllCounters();
             

            var config = new HttpConfiguration();

            config.Formatters.Add(new JsonHalMediaTypeFormatter(BuildHypermediaConfiguration()));


            config
                .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                .EnableSwaggerUi();

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            return config;
        }


        private static IHypermediaResolver BuildHypermediaConfiguration()
        {
            var builder = Hypermedia.CreateBuilder();

            //
            // Define the self-links

            var curie = new CuriesLink("beerco", "http://api.beerco.com/docs{?rel}");

            var selfLink = curie.CreateLink<Model>("self", "~/api/value");

            var helpLink = new Link("help", "http://www.iana.org/assignments/link-relations/link-relations.xhtml");

            //
            // Register things with the container

            builder.Register(selfLink, new ModelAppender(), helpLink);

            return builder.Build();
        }
    }
}