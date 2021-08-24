using Elasticsearch.Net;
using Nancy.Json;
using Nest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UzmanCrm.CrmService.Domain.Abstraction;


namespace UzmanCrm.CrmService.Application.Service.Utilities
{
    public static class ElasticClientExtensions
    {
        public static Task<ISearchResponse<T>> SearchWithMatch<T>(this IElasticClient client, Expression<Func<T, object>> field, string index, string id)
            where T : class =>
            client.SearchAsync<T>(s => s
                .Index(index)
                .Query(q => q
                    .Match(m => m
                        .Field(field)
                        .Query(id)
                    )
                )
            );
        public static async Task<string> PostJsonAsync(IElasticClient _elasticClient, string index, JsonElement value)
        {
            string jsonstring = JsonSerializer.Serialize(value);
            var id = Guid.NewGuid().ToString();
            await _elasticClient.LowLevel.IndexAsync<BytesResponse>(index, id, jsonstring);
            return id;
        }
        public static async Task<string> PutJsonAsync(IElasticClient _elasticClient, string index, string id, JsonElement value)
        {
            string jsonstring = JsonSerializer.Serialize(value);
            var result = _elasticClient.Search<dynamic>(s => s.Index(index)
            .Query(q => q.Ids(c => c.Values(id))));
            if (result.Hits.Count != 0)
            {
                await _elasticClient.LowLevel.IndexAsync<BytesResponse>(index, id, jsonstring);
                return id + " islem basarili";
            }
            return id + "islem basarisiz";
        }
        public static async Task<string> GetJsonAsync(IElasticClient _elasticClient, string index, string key,string value)
        {
            var serialized = ListOfJson(_elasticClient, index, key, value);                 
            return serialized[0];
        }
        public static async Task<List<string>> GetJsonListAsync(IElasticClient _elasticClient, string index, string key, string value)
        {
            return ListOfJson(_elasticClient, index, key, value);
        }
        public static List<string> ListOfJson(IElasticClient _elasticClient, string index, string key, string value)
        {
            var result = _elasticClient.Search<dynamic>(s => s.Index(index));
            var columns = new Dictionary<string, string>();
            var jsSerializer = new JavaScriptSerializer();
            var allSources = result.Hits;
            List<string> serialized = new List<string>();
            string serializedValue = "";
            foreach (var item in allSources)
            {
                foreach (var sources in item.Source)
                {
                    if (sources.Key.ToString() == key || sources.Value.ToString() == value)
                    {
                        foreach (var all in item.Source)
                        {
                            columns.Add(all.Key.ToString(), all.Value.ToString());
                        }
                        serializedValue = jsSerializer.Serialize(columns);
                        serialized.Add(serializedValue);
                        columns.Clear();
                        break;
                    }
                }
            }
            return serialized;
        }
    }
}
