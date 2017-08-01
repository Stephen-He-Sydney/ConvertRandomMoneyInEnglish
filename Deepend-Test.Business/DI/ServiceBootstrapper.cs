using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Deepend_Test.Business.Utility;

namespace Deepend_Test.Business.DI
{
    public class ServiceBootstrapper
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            //container.RegisterType<IDataFormatConverter, DataFormatConverter>();
        }   
    }
}
