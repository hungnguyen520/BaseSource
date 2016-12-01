using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using BaseSource.Core;
using BaseSource.Core.Contexts;
using BaseSource.Core.Repositories;
using BaseSource.Core.UnitOfWorks;
using BaseSource.Identity;
using BaseSource.Repository;
using BaseSource.Repository.Core;
using BaseSource.Repository.Repositories;
using BaseSource.Service;
using log4net;
using Microsoft.Owin;
using Owin;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartupAttribute(typeof(BaseSource.Web.Startup))]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Log4Net.config", Watch = true)]

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

            //Infrastructure
            builder.RegisterType<EntityDbContext>().As<IEntityDbContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            //Repository
            builder.RegisterType<ProductCatalogRepository>().As<IProductCatalogRepository>().InstancePerRequest();
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerRequest();

            //Service
            builder.RegisterType<ProductCatalogService>().As<IProductCatalogService>().InstancePerRequest();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();

            //Logger
            builder.Register(c => LogManager.GetLogger(typeof(Object))).As<ILog>();
            

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}