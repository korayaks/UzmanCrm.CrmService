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

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();//Get all Assemblies
            var assembly = allAssemblies.Where(t => t.FullName.Contains(ServiceEndName)).ToArray();//Get Assemblies where assembly's name contains "Service"
                    
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.FullName.EndsWith(ServiceEndName))//Register assemblies where assembly name ends with "Service" as a "I"+ same assembly name.
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));//"RabbitmqService" => "IRabbitmqService"
        }
    }
}
