using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TelerikAngular2.Api.Controllers;
using TelerikAngular2.Core;
using TelerikAngular2.Core.Interfaces;
using TelerikAngular2.Data;
using TelerikAngular2.Data.Common;

namespace TelerikAngular2.Api.App_Start
{
    public class AutofacApiConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(AppDomain.CurrentDomain.GetAssemblies());
          

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterHttpRequestMessage(config);

            // Register services
            RegisterServices(builder);

         
            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new ApplicationDbContext())
               .As<DbContext>()
               .InstancePerRequest();

            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerRequest();

            builder.RegisterType<FileUploadService>()
                .As<IFileUploadService>()
                .InstancePerRequest();

            var servicesAssembly = Assembly.GetAssembly(typeof(UserService));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(DbRepository<>))
                .As(typeof(IDbRepository<>))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();


            builder.RegisterType<UserController>();
            //builder.RegisterType<IDbRepository<User>, AlbumRepository>(new HierarchicalLifetimeManager());
            //builder.RegisterGeneric(typeof(DbRepository<>)).As(typeof(IDbRepository<>));

            // builder.RegisterType<UserService>().As<IUserService>().InstancePerApiRequest();
        }
    }
}