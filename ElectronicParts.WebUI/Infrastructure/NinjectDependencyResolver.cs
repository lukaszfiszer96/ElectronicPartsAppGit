using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using ElectronicParts.Domain.Entities;
using ElectronicParts.Domain.Abstract;
using ElectronicParts.Domain.Concrete;
using ElectronicParts.WebUI.Infrastructure.Abstract;
using ElectronicParts.WebUI.Infrastructure.Concrete;

namespace ElectronicParts.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IElectronicPartRepository>().To<EFElectronicPartRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            

        }
    }
}