﻿using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BaseSource.Identity;
using BaseSource.Repository.Core;
using BaseSource.Service;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(BaseSource.Web.Startup))]

namespace BaseSource.Web
{
    public class Startup : ApplicationStartup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<ProductManagementService>().As<IProductManagementService>().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}