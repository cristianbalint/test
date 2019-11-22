using Infrastructure.DI;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AssetManagement
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            var config = new Infrastructure.Models.WebConfig()
            {
                BlobConnectionString = ConfigurationManager.AppSettings["BlobConnectionString"],
                BlobContainerName = ConfigurationManager.AppSettings["BlobContainerName"],

                AzCognitiveVisionEndpoint = ConfigurationManager.AppSettings["AzCognitiveVisionEndpoint"],
                AzCognitiveVisionKey = ConfigurationManager.AppSettings["AzCognitiveVisionKey"],
            };

            // Register your types, for instance using the scoped lifestyle:
            foreach (var map in DiMappings.GetTypeDependencies(config))
            {
                container.Register(map.Key, map.Value);
            }

            foreach (var map in DiMappings.GetCreatedDependencies(config))
            {
                container.Register(map.Key, () => { return map.Value; }, Lifestyle.Scoped);
            }

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
