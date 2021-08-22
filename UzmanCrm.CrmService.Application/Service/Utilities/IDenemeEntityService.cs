using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Application;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Domain.Abstraction;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public interface IDenemeEntityService:IApplicationService
    {
        Task<string> PostMethod<T>([FromBody] T value, string index) where T : class;
        //Task<string> PostMethod([FromBody] DenemeEntityDto value, string index);
        Task<T> GetMethod<T>(string id, string index) where T : class, IEntity;
    }
}
