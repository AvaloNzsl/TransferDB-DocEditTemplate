using StudentsTemplate.BL.AutoMapperConfiguration;
using System.Web.Mvc;
using System.Web.Routing;

namespace StudentsTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
