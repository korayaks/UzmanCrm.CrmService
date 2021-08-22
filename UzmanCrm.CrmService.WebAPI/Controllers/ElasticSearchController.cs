using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Application.Service.Utilities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UzmanCrm.CrmService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {    
        private readonly IElasticSearchService _elasticSearchService;
        public ElasticSearchController(IElasticClient elasticClient,IElasticSearchService elasticSearchService)
        {
            _elasticSearchService=elasticSearchService;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ExampleEntityDto> Get(string id, string index)
        {          
            return await _elasticSearchService.GetMethod<ExampleEntityDto>(id, index);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] ExampleEntityDto value, string index)
        {
            return await _elasticSearchService.PostMethod<ExampleEntityDto>(value, index);
        }
    }
}
