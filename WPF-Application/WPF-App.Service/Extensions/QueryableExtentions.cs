using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Service.Extensions
{
    public static class QueryableExtentions
    {
      
        public static IEnumerable<T> GetPagination<T>(this IQueryable<T> query, Tuple<int, int> pagination = null)
          => pagination is not null ? query.Skip( ( pagination.Item2 - 1 ) * pagination.Item1) : query;
    
    }
}
