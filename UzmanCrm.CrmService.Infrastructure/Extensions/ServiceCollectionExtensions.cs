using Autofac;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection AutoMapperConfigure(IServiceCollection services)
        {
            List<Assembly> myAssemblyList = new List<Assembly>();
            var allAssemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().ToArray();
            var myAssemblies = allAssemblies.Where(t => t.FullName.Contains("Service")).ToArray();            
            foreach (var assembly in myAssemblies)
            {
                myAssemblyList.Add(Assembly.Load(assembly));
            }                       
            services.AddSingleton(CreateMapper(myAssemblyList.ToArray()));
            return services;
        }
        private static IMapper CreateMapper(Assembly[] assembly)
            => new MapperConfiguration(config => config.AddMaps(assembly))
            .CreateMapper();


    }
}
