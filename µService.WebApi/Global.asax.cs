﻿using µService.Infrastructure.Persistence;
using µService.Infrastructure.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace µService.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            UnityOfWork.Initialize();
        }

        protected void Application_EndRequest()
        {
            UnityOfWork.Dispose();
        }
    }
}
