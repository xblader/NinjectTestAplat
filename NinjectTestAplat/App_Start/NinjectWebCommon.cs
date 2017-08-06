[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectTestAplat.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectTestAplat.App_Start.NinjectWebCommon), "Stop")]

namespace NinjectTestAplat.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using log4net;
    using Attributes;
    using System.Web.Http.Filters;
    using log4net.Core;
    using System.Linq;
    using AplatServices;
    using global::Ninject;
    using global::Ninject.Activation;
    using global::Ninject.Web.Mvc.Filter;
    using global::Ninject.Extensions.Factory;
    using global::Ninject.Web.WebApi.FilterBindingSyntax;
    using global::Ninject.Web.Common;
    using Ninject;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ILog>().ToMethod(GetLogger);
            kernel.BindHttpFilter<LogFilter>(FilterScope.Controller)
                .WithConstructorArgument("logLevel", Level.Info);
            kernel.Bind<IPermissaoService>().To<PermissaoService>();
            kernel.Bind<IControleAcessoFactory>().ToFactory();
            kernel.Bind<IControleAcesso>().ToProvider<CustomStrategyProvider>();
        }

        private static ILog GetLogger(IContext ctx)
        {
            var filterContext = ctx.Request.ParentRequest.Parameters
                          .OfType<FilterContextParameter>().SingleOrDefault();
            return LogManager.GetLogger(filterContext == null ?
                ctx.Request.Target.Member.DeclaringType :
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerType);
        }
    }
}
