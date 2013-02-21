using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowPlanner.Commands
{
    public class QueryResponse<T>
    {
        public T[] Results { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
    }
}
