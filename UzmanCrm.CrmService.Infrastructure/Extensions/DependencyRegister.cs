using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Utilities;

namespace UzmanCrm.CrmService.Infrastructure.Extensions
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ExampleService>().As<IExampleService>().InstancePerLifetimeScope();
        }
    }
}
