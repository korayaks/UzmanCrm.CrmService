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
    public class DependencyRegister : Autofac.Module
    {
        private const string ServiceEndName = "Service";
        protected override void Load(ContainerBuilder builder)
        {

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            var assembly = allAssemblies.Where(t => t.FullName.Contains(ServiceEndName)).ToArray();
                    
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.FullName.EndsWith(ServiceEndName))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
        }
    }
}
