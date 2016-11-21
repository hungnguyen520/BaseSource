﻿using Autofac;
using Autofac.Integration.Mvc;
using BaseSource.Data;
using BaseSource.Identity;
using BaseSource.Data.Infrastructure;
using BaseSource.Data.Repositories;
using BaseSource.Service;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using Autofac.Integration.WebApi;

[assembly: OwinStartupAttribute(typeof(BaseSource.Web.Startup))]

namespace BaseSource.Web
{
    public partial class Startup : IdentityStartup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        public void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<BaseSourceDbContext>().As<IBaseSourceDbContext>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(ProductCatalogRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(ProductCatalogService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //Set the WebApi DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); 
            
        }
    }
}