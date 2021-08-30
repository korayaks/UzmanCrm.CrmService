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
        public static async Task<string> PostJsonAsync(IElasticClient _elasticClient, string index, JsonElement value)
        {
            string jsonstring = JsonSerializer.Serialize(value);//convert json data to string.
            var id = Guid.NewGuid().ToString();//create new id for the data to will be saved in Elasticsearch.
            await _elasticClient.LowLevel.IndexAsync<BytesResponse>(index, id, jsonstring);//Post json string to given index on elasticsearch
            return id;//return created id 
        }
        public static async Task<string> PutJsonAsync(IElasticClient _elasticClient, string index, string id, JsonElement value)
        {
            string jsonstring = JsonSerializer.Serialize(value);//convert json data to string.
            var result = _elasticClient.Search<dynamic>(s => s.Index(index)
            .Query(q => q.Ids(c => c.Values(id))));//Search datas with given id on given index on the Elasticsearch
            if (result.Hits.Count != 0)
            {//if there is any data with given id 
                await _elasticClient.LowLevel.IndexAsync<BytesResponse>(index, id, jsonstring);//Post json string to given index on elasticsearch
                return id + " islem basarili";//return id and information about put process
            }
            return id + " islem basarisiz";//return id and information about put process
        }
        public static async Task<string> GetJsonAsync(IElasticClient _elasticClient, string index, string key,string value)
        {
            var serialized = ListOfJson(_elasticClient, index, key, value);//Get all datas with matching key and value pairs from to the Elasticsearch            
            return serialized.Count is 0 ? "Key and value pair do not match, or wrong index name." : serialized[0];
        }//if list is not null, return the first data of the list.
        public static async Task<List<string>> GetJsonListAsync(IElasticClient _elasticClient, string index, string key, string value)
        {
            return ListOfJson(_elasticClient, index, key, value);//return all datas with matching key and value pairs from to the Elasticsearch  
        }
        public static List<string> ListOfJson(IElasticClient _elasticClient, string index, string key, string value)
        {
            var result = _elasticClient.Search<dynamic>(s => s.Index(index));//Get all datas from Elasticsearch on given index.
            var columns = new Dictionary<string, string>();
            var jsSerializer = new JavaScriptSerializer();
            var allSources = result.Hits;
            List<string> serialized = new List<string>();
            string serializedValue = "";
            foreach (var item in allSources)//loop all nest hits object (nest object have _soucre data, in _source data we have json datas)
            {
                foreach (var sources in item.Source)//loop all json data for control
                {
                    if (sources.Key.ToString() == key && sources.Value.ToString() == value)//Control key and value pairs.
                    {//if key and value pairs equals
                        foreach (var all in item.Source)
                        {
                            columns.Add(all.Key.ToString(), all.Value.ToString());//add all key and value pairs on that json data to the colums Dictionary.
                        }
                        serializedValue = jsSerializer.Serialize(columns);//Convert Dictionary to json string.
                        serialized.Add(serializedValue);//Add json string to the string list
                        columns.Clear();//Clear Dictionary.
                        break;
                    }
                }
            }
            return serialized;//return json string list.
        }
    }
}
