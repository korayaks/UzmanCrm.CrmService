using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Application;
using UzmanCrm.CrmService.Application.Service.Model;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public interface IExampleService : IApplicationService
    {
        Task<ExampleEntityDto> ExampleMethodAsync();

        Task<List<ExampleEntityDto>> ExapmleMethodList();
    }
}
