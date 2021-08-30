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
        //Get single data from elasticsearch with key, value and index parameters
        [HttpGet("{key}/GetMethod")]
        public async Task<string> Get(string key, string value, string index)
        {
            var lastMessage = await _elasticSearchService.GetMethod(key, value, index);//Put relevant data on lastMessage field  
            _rabbitmqService.SendInstagram(lastMessage);//Send lastMessage via Rabbitmq to Instagram Service
            return lastMessage;
        }
        //Get data list from elasticsearch with key, value and index parameters
        [HttpGet("{key}/GetListMethod")]      
        public async Task<List<string>> GetList(string key, string value, string index)
        {
            var lastMessage = await _elasticSearchService.GetListMethod(key, value, index);//Put relevant datas on lastMessage field
            foreach (var message in lastMessage)
            {
                _rabbitmqService.SendTwitter(message);//Send all messages via Rabbitmq to Twitter Service
            }         
            return lastMessage;
        }
        // Post json data to elasticsearch. Elasticsearch will save json data to given index parameter.
        [HttpPost]
        public async Task<string> Post([FromBody] JsonElement value, string index)
        {
            var lastMessage = await _elasticSearchService.PostMethod(value, index);//Put relevant data on lastMessage field
            _rabbitmqService.SendInstagram(lastMessage);//Send lastMessage via Rabbitmq to Instagram Service
            return lastMessage;
        }
        //Control the given id on elasticsearch. If elasticsearch have data with that given id in that given index,
        //change the json data to given json data
        [HttpPut]
        public async Task<string> Put([FromBody] JsonElement value, string index, string id)
        {
            var lastMessage = await _elasticSearchService.PutMethod(value, index, id);//Put relevant data on lastMessage field
            _rabbitmqService.SendTwitter(lastMessage);//Send lastMessage via Rabbitmq to Twitter Service
            return lastMessage;
        }
    }
}
