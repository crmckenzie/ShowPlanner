using System.Web.Http;
using System.Web.Mvc;

namespace ShowPlanner.Web.Areas.Client
{
    public class ClientAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Client";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Client_default",
                "Client/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.Routes.MapHttpRoute(
                name: "ClientApi",
                routeTemplate: "api/Client/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
