using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Moq;
using Vrooms.Domain.Abstract;
using Vrooms.Domain.Concrete;
using Vrooms.Domain.Entities;

namespace Vrooms.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
            kernel.Bind<ILanguageRepository>().To<EFLanguageRepository>();
            kernel.Bind<IBookItemRepository>().To<EFBookItemRepository>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}