using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using Moq;
using Vrooms.Domain.Abstract;
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
            // mock IBookRepository implementation
            Mock<IBookRepository> mock = new Mock<IBookRepository>();
            mock.Setup(m => m.Books).Returns(new List<Book>
            {
                new Book{ Title="The Castle", Author="Franz Kafka"},
                new Book{ Title="Diary of a Madman", Author="Nikolai Gogol"},
                new Book{ Title="The Murders in the Rue Morgue", Author="Edgar Allan Poe"}
            });

            kernel.Bind<IBookRepository>().ToConstant(mock.Object);

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