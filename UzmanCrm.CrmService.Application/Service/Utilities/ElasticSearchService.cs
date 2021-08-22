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
using UzmanCrm.CrmService.Domain.Abstraction;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient _elasticClient;
        public ElasticSearchService(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        //public async Task<string> PostMethod([FromBody] ExampleEntityDto value,string index)
        //{
        //    var response = await _elasticClient.IndexAsync<ExampleEntityDto>(value, x => x.Index(index));
        //    return response.Id;
        //}

        //public async Task<ExampleEntityDto> GetMethod(string id,string index)
        //{
        //    //var response = await _elasticClient.SearchAsync<ExampleEntityDto>(s => s
        //    //.Index(index)
        //    //.Query(q => q.Match(m => m.Field(f => f.Name).Query(id))));
        //    var response = await _elasticClient.SearchWithMatch<ExampleEntityDto>(f => f.Name, index, id);
        //    return response?.Documents?.FirstOrDefault();
        //}
        public async Task<string> PostMethod<T>([FromBody] T value, string index) where T : class
        {
            var response = await _elasticClient.IndexAsync<T>(value, x => x.Index(index));
            return response.Id;
        }
        public async Task<T> GetMethod<T>(string id, string index) where T : class, IEntity
        {
            var response = await _elasticClient.SearchWithMatch<T>(f => f.Name, index, id);
            return response?.Documents?.FirstOrDefault();
        }
    }
}
