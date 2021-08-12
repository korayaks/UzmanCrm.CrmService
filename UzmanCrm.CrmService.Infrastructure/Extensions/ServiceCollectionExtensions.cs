using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Application;
using UzmanCrm.CrmService.Application.Service.Utilities;

namespace UzmanCrm.CrmService.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static ContainerBuilder RegisterApplicationServices(ContainerBuilder builder)
        {
            

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();

            var assemblies = allAssemblies.Where(t => t.FullName.Contains("Application")).ToArray();

            //builder.RegisterType<IApplicationService>();
            builder.RegisterType<ExampleService>().As<IExampleService>();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));


            return builder;
        }
    }
}
