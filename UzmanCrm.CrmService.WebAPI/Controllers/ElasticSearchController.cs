using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UzmanCrm.CrmService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElasticSearchController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        public ElasticSearchController(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ExampleEntityDto> Get(string id)
        {
            var response = await _elasticClient.SearchAsync<ExampleEntityDto>(s => s
            .Index("users")
            .Query(q => q.Match(m => m.Field(f => f.Name).Query(id))));

            return response?.Documents?.FirstOrDefault();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] ExampleEntityDto value)
        {
            var response = await _elasticClient.IndexAsync<ExampleEntityDto>(value, x => x.Index("users"));
            return response.Id;
        }
    }
}
