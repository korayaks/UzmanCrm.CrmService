using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UzmanCrm.CrmService.Application.Service.Utilities
{
	public static class ElasticClientExtensions
	{
		public static Task<ISearchResponse<T>> SearchWithMatch<T>(this IElasticClient client, Expression<Func<T, object>> field, string index,string id)
			where T : class =>
			client.SearchAsync<T>(s => s
				.From(0)
				.Size(10)
				.Index(index)
				.Query(q => q
					.Match(m => m
						.Field(field)
						.Query(id)
					)
				)
			);
	}

}
