using Exam70_486Framework.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Exam70_486Framework
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ViewEngines.Engines.Add(new CustomViewEngine());
        }

        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            if (e.Exception is NotImplementedException)
            {
                // do something special when the functionality is not implemented   
            }
        }

        public void Application_Error(Object sender, EventArgs e)
        {
            if (Server != null)
            {         //Get the context     
                HttpContext appContext = ((MvcApplication)sender).Context;
                Exception ex = Server.GetLastError().GetBaseException();
                //Log the error using the logging framework  
                Logger.Error(ex);
                //Clear the last error on the server so that custom errors are not fired  
                Server.ClearError();
                //forward the user to the error manager controller.      
                IController errorController = new ErrorManagerController();
                RouteData routeData = new RouteData();
                routeData.Values["controller"] = "ErrorManagerController";
                routeData.Values["action"] = "ServerError";
                errorController.Execute(
                    new RequestContext(new HttpContextWrapper(appContext), routeData));
            }
        }

    }
}
