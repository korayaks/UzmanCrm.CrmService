using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Application;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Domain.Abstraction;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public interface IDenemeEntityService:IApplicationService
    {
        Task<string> PostMethod([FromBody] JsonElement value, string index);
        Task<string> GetMethod(string key, string value, string index);
        Task<List<string>> GetListMethod(string key, string value, string index);
        Task<string> PutMethod([FromBody] JsonElement value, string index, string id);
    }
}
