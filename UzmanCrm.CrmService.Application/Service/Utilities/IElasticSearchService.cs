using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Application;
using UzmanCrm.CrmService.Application.Service.Model;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public interface IElasticSearchService : IApplicationService
    {
        Task<ExampleEntityDto> GetMethod(string id, string index);
        Task<string> PostMethod([FromBody] ExampleEntityDto value, string index);
    }
}
