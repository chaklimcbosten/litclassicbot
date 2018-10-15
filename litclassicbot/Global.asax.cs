using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Optimization;
using System;
using System.Web;

namespace litclassicbot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register); // было здесь по-умолчанию
            // следующие 4 строки добавились при переделке приложения в MVC
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception exc = Server.GetLastError();

            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
                //Server.Transfer("ErrorPage.html", true);
            }
        }
    }
}
