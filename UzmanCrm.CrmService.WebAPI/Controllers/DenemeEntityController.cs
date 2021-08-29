using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Application.Service.Utilities;
using UzmanCrm.CrmService.Infrastructure.Extensions;

namespace UzmanCrm.CrmService.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DenemeEntityController : Controller
    {
        private readonly IDenemeEntityService _elasticSearchService;
        private readonly IRabbitmqService _rabbitmqService;
        public DenemeEntityController(IDenemeEntityService elasticSearchService, IRabbitmqService rabbitmqService)
        {
            _elasticSearchService = elasticSearchService;
            _rabbitmqService = rabbitmqService;
        }
        // GET api/<UsersController>/5
        [HttpGet("{key}/GetMethod")]
        public async Task<string> Get(string key, string value, string index)
        {
            var lastMessage = await _elasticSearchService.GetMethod(key, value, index);
            _rabbitmqService.SendInstagram(lastMessage);
            return lastMessage;
        }
        [HttpGet("{key}/GetListMethod")]      
        public async Task<List<string>> GetList(string key, string value, string index)
        {
            var lastMessage = await _elasticSearchService.GetListMethod(key, value, index);
            foreach (var message in lastMessage)
            {
                _rabbitmqService.SendTwitter(message);
            }         
            return lastMessage;
        }
        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] JsonElement value, string index)
        {
            var lastMessage = await _elasticSearchService.PostMethod(value, index);
            _rabbitmqService.SendInstagram(lastMessage);
            return lastMessage;
        }
        [HttpPut]
        public async Task<string> Put([FromBody] JsonElement value, string index, string id)
        {
            var lastMessage = await _elasticSearchService.PutMethod(value, index, id);
            _rabbitmqService.SendTwitter(lastMessage);
            return lastMessage;
        }
    }
}
