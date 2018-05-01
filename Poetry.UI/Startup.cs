﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using System.Web.Hosting;
using Poetry.UI.EmbeddedResourceSupport;
using Poetry.UI.MvcSupport;
using Poetry.UI.AppSupport;
using System.Reflection;

namespace Poetry.UI
{
    public static class Startup
    {
        public static void AddPoetryUI(this HttpApplication application, Action<Type, object> registerSingletonInDependencyResolver, IEnumerable<Assembly> assemblies, string basePath = "Poetry")
        {
            RouteTable.Routes.MapRoute(
                "PoetryPortal",
                basePath,
                new { controller = "PoetryPortal", action = "Index" },
                namespaces: new string[] { "Poetry.UI.Controllers" }
            );

            var basePathProvider = (IBasePathProvider)new BasePathProvider(basePath);

            registerSingletonInDependencyResolver(typeof(IBasePathProvider), basePathProvider);
            registerSingletonInDependencyResolver(typeof(IAppRepository), new AppRepository(new AppCreator().Create(assemblies)));

            var vpp = new EmbeddedResourceVirtualPathProvider(basePathProvider);

            registerSingletonInDependencyResolver(typeof(EmbeddedResourceVirtualPathProvider), vpp);

            RouteTable.Routes.Add(new EmbeddedResourceRoute(vpp));
            RouteTable.Routes.RouteExistingFiles = true;

            HostingEnvironment.RegisterVirtualPathProvider(vpp);
        }
    }
}
