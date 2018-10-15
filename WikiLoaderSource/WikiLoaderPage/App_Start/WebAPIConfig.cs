using System.Web.Http;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                         name: "ProviderViewSettings",
                         routeTemplate: "{workspaceID}/api/ProviderAPI/GetViewFields",
                         defaults: new { controller = "ProviderAPI", action = "GetViewFields" }
                     );
        }
    }
}
