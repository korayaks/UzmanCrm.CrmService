using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Application.Service.Model;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient _elasticClient;
        public ElasticSearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<string> PostMethod([FromBody] ExampleEntityDto value,string index)
        {
            var response = await _elasticClient.IndexAsync<ExampleEntityDto>(value, x => x.Index(index));
            return response.Id;
        }

        public async Task<ExampleEntityDto> GetMethod(string id,string index)
        {
            //var response = await _elasticClient.SearchAsync<ExampleEntityDto>(s => s
            //.Index(index)
            //.Query(q => q.Match(m => m.Field(f => f.Name).Query(id))));
            var response = await _elasticClient.SearchWithMatch<ExampleEntityDto>(f => f.Name, index, id);
            return response?.Documents?.FirstOrDefault();
        }
        
    }
}
