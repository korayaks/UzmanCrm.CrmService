using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        [HttpGet("{key}/GetMethod")]
        public async Task<string> Get(string key, string value, string index)
        {
            return await _elasticSearchService.GetMethod(key, value, index);
        }
        [HttpGet("{key}/GetListMethod")]      
        public async Task<List<string>> GetList(string key, string value, string index)
        {
            return await _elasticSearchService.GetListMethod(key, value, index);
        }
        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] JsonElement value, string index)
        {
            return await _elasticSearchService.PostMethod(value, index);
        }
        [HttpPut]
        public async Task<string> Put([FromBody] JsonElement value, string index, string id)
        {
            return await _elasticSearchService.PutMethod(value, index, id);
        }
    }
}
