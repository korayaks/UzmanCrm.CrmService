using Elasticsearch.Net;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;
using UzmanCrm.CrmService.Domain.Abstraction;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public class DenemeEntityService : IDenemeEntityService
    {
        private readonly IElasticClient _elasticClient;
        public DenemeEntityService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<string> GetMethod(string key,string value, string index)
        {
            return await ElasticClientExtensions.GetJsonAsync(_elasticClient, index, key,value);
        }//return single data from elasticsearch. 
        public async Task<List<string>> GetListMethod(string key,string value,string index)
        {
            return await ElasticClientExtensions.GetJsonListAsync(_elasticClient, index, key, value);
        }//return data list from elasticsearch.
        public async Task<string> PostMethod([FromBody] JsonElement value, string index)
        {
            return await ElasticClientExtensions.PostJsonAsync(_elasticClient, index, value);
        }//return single data from elasticsearch, that data will be given id.
        public async Task<string> PutMethod([FromBody] JsonElement value, string index, string id)
        {
            return await ElasticClientExtensions.PutJsonAsync(_elasticClient, index, id, value);
        }//return single data from elasticsearch, that data will be given id and information about put process.
    }
}
