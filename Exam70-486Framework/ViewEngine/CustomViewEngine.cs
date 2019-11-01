using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam70_486Framework.ViewEngine
{
    public class CustomViewEngine : VirtualPathProviderViewEngine
    {
        public CustomViewEngine() 
        { 
            this.ViewLocationFormats = new string[] { "~/Views/{1}/{2}.mytheme ", "~/Views/Shared/{2}.mytheme" }; 
            this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{2}.mytheme ", "~/Views/Shared/{2}. mytheme " };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return new MyCustomView(physicalpath); 
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var physicalpath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new MyCustomView(physicalpath); 
        }
    }
}