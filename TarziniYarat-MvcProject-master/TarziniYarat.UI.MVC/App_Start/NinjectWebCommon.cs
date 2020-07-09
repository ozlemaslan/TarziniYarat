[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TarziniYarat.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TarziniYarat.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace TarziniYarat.UI.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using TarziniYarat.BusinessLogic;
    using TarziniYarat.BusinessLogic.Abstract;
    using TarziniYarat.BusinessLogic.Concrete;

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
            kernel.Load<NinjectModuleDAL>();

            kernel.Bind<IBrandService>().To<BrandService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICombineService>().To<CombineService>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<ILikeService>().To<LikeService>();
            kernel.Bind<IOrderDetailsService>().To<OrderDetailsService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IPersonDetailsService>().To<PersonDetailsService>();
            kernel.Bind<IPersonService>().To<PersonService>();
            kernel.Bind<IProductService>().To<ProductService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IShipperService>().To<ShipperService>();
        }        
    }
}
