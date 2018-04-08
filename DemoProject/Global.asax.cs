﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using DemoProject.App_Code;

namespace DemoProject
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery.validate.unobtrusive.min.js",
                DebugPath = "~/Scripts/jquery.validate.unobtrusive.min.js"
            });
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
        }
    }
}