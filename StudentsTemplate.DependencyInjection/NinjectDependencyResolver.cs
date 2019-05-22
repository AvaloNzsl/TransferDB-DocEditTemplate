using Ninject;
using StudentsTemplate.BL.AutoMapperConfiguration;
using StudentsTemplate.BL.Service;
using StudentsTemplate.DAL.Repository;
using StudentsTemplate.DAL.UnitService;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace StudentsTemplate.DependencyInjection
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

        //Bindings configuration
        private void AddBindings()
        {
            kernel.Bind<IStudentRepository>().To<StudentRepository>();
            kernel.Bind<IStudentService>().To<StudentService>();
            kernel.Bind<IStudentMapping>().To<StudentMapping>();
        }
    }
}
