using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
