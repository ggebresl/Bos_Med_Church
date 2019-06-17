[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EOTC.Boston.MedhaneAlem.WebUI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EOTC.Boston.MedhaneAlem.WebUI.App_Start.NinjectWebCommon), "Stop")]

namespace EOTC.Boston.MedhaneAlem.WebUI.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using EOTC.Boston.MedhaneAlem.BuisnessLogic.Interfaces;
    using Moq;
    //using EOTC.Boston.MedhaneAlem.BuisnessLogic.Entities;
    using System.Collections.Generic;
    using EOTC.Boston.MedhaneAlem.BuisnessLogic.Repositories;

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

            kernel.Bind<IMemberRepository>().To<EFMemberRepository>();
            kernel.Bind<IAuthentication>().To<FormsAuthenticationProvider>();

            //    Mock<IMemberRepository> mock = new Mock<IMemberRepository>();
            //    mock.Setup(m => m.Members).Returns(new List<Member>
            //    {
            //        new Member {FirstName="Gerawork",LastName="Gebreslassie", Address1= "5 Tayer Circle",City="Wakefield",State="MA"},
            //        new Member {FirstName="Abeba",LastName="Gile", Address1= "5 Tayer Circle",City="Wakefield",State="MA"},
            //        new Member {FirstName="Aron",LastName="GebreMeskel", Address1= "5 Tayer Circle",City="Wakefield",State="MA"},
            //        new Member {FirstName="Noli",LastName="Gerawork", Address1= "5 Tayer Circle",City="Wakefield",State="MA"},
            //        new Member {FirstName="Nathan",LastName="Gebreslassie", Address1= "5 Tayer Circle",City="Wakefield",State="MA"}
            //    });
            //    kernel.Bind<IMemberRepository>().ToConstant(mock.Object);
            //}        
        }
    }
}
