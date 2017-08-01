using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Deepend_Test.Web.Controllers;
using Deepend_Test.Business;
using Deepend_Test.Business.DI;

namespace Deepend_Test.Web.DI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            // if you still use the beta version - change above line to:
            //GlobalConfiguration.Configuration.ServiceResolver.SetResolver(new Unity.WebApi.UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            ServiceBootstrapper.RegisterTypes(container);

            container.RegisterType<IChequeService, ChequeService>();            
            container.RegisterType<ChequeApiController>();

            return container;
        }
    }
}