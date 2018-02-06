using EF.Diagnostics.Profiling;
using EF.Diagnostics.Profiling.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Injection;
using Unity.RegistrationByConvention;
using WebApi.Controllers;
using WebApi.Models;

namespace WebApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            //container.RegisterType<ICustService, CustService>();


            Func<string, IDbConnection> connectionFactory = name =>
            {
                var connectionText = "Data Source=PANDURINI-PC;Initial Catalog=HBSSystem;User ID=qq;Password=1234;Connection Timeout=30";

                var conn = new SqlConnection(connectionText);
                if (ProfilingSession.Current == null)
                {
                    return conn;
                }

                var dbProfiler = new DbProfiler(ProfilingSession.Current.Profiler);

                return new ProfiledDbConnection(conn, dbProfiler);
            };

            container.RegisterInstance<Func<IDbConnection>>(
                "Cust", () => connectionFactory("Cust"));


            container.RegisterType<ICustService, CustService>("CustService",
                 new InjectionProperty(nameof(CustService.Para), "aaa"),
                 new InjectionProperty(nameof(CustService.Para2), "bbb"),
                 new InjectionProperty(nameof(CustService.CustConnection), new ResolvedParameter<Func<IDbConnection>>("Cust"))
                );
            container.RegisterType<ICustService, Cust2Service>("Cust2Service");
            container.RegisterType<HomeController>(
             new InjectionConstructor(
                    new ResolvedParameter<ICustService>("CustService"),
                    new ResolvedParameter<ICustService>("Cust2Service")
             ));


            //var user = container.Resolve<ICustService>("Cust2Service");


            //new InjectionProperty(
            //            nameof(DepartmentRepository.DramaConnectionFactory),
            //            new ResolvedParameter<Func<IDbConnection>>("Drama"))


            //string aaa = user.getCust1();

            //還有非常炫砲的寫法 自動搜尋所有class跟Interface 做注入 
            //Nugut Unity;
            // container.RegisterTypes(
            // //針對所有class Service名稱後有做注入
            // AllClasses.FromLoadedAssemblies()
            ////.Where(t => t.Name.EndsWith("Service")),
            //.Where(t => t.Namespace == "WebApi.Models"),
            // //搜尋所有Interface做Mapping
            // WithMappings.FromAllInterfaces,
            // //可以定義註冊名稱
            // WithName.Default,
            // //指定註冊的生命週期 說明
            // WithLifetime.ContainerControlled
            // //WithLifetime.Custom<PreRequestLifetimeManager>
            // );


            // container.RegisterTypes(
            // //針對所有class Service名稱後有做注入
            // AllClasses.FromAssemblies(true,Assembly.Load("WebApi.Models"))
            //,
            // //搜尋所有Interface做Mapping
            // WithMappings.FromAllInterfaces,
            // //可以定義註冊名稱
            // WithName.Default,
            // //指定註冊的生命週期 說明
            // WithLifetime.ContainerControlled);


        }
    }
}