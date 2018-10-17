﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using opSolver.WEB.Utils;
using Ninject.Web.Mvc;

namespace opSolver.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Ninject
            NinjectModule opModule = new opModule("opDB");
            var kernel = new StandardKernel(opModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
