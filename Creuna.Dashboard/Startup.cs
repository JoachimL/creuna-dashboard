using System.Web.Http;
using Creuna.Dashboard.DependencyResolution;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using StructureMap;

namespace Creuna.Dashboard
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseFileServer(false);
            SetUpWebApi(app);
        }

        private static void SetUpWebApi(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            var formatters = httpConfiguration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            SetUpIoc(httpConfiguration);
            app.UseWebApi(httpConfiguration);
            httpConfiguration.EnsureInitialized();
        }

        private static void SetUpIoc(HttpConfiguration config)
        {
            var container = new Container(x => x.AddRegistry<IocRegistry>());
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }
    }
}