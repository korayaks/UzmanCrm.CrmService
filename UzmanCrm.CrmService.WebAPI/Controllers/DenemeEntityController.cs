using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Application.Service.Utilities;

namespace UzmanCrm.CrmService.WebAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeEntityController : Controller
    {
        private readonly IDenemeEntityService _elasticSearchService;
        public DenemeEntityController(IDenemeEntityService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<DenemeEntityDto> Get(string id, string index)
        {
            return await _elasticSearchService.GetMethod<DenemeEntityDto>(id, index);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] DenemeEntityDto value, string index)
        {
            return await _elasticSearchService.PostMethod<DenemeEntityDto>(value, index);
        }
    }
}
