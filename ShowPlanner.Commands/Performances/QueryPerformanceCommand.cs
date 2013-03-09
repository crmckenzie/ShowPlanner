using System.Linq;
using Isg.Specification;
using ShowPlanner.Builders;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;
using ShowPlanner.Services;

namespace ShowPlanner.Commands.Performances
{
    public class QueryPerformanceCommand : ICommand<QueryPerformanceRequest, QueryResponse<PerformanceDetail>>
    {
        private readonly IDatabase _database;
        private readonly IBuild _builder;

        public QueryPerformanceCommand(IDatabase database, IBuild builder)
        {
            _database = database;
            _builder = builder;
        }

        public QueryResponse<PerformanceDetail> Execute(QueryPerformanceRequest request)
        {
            using (var repository = _database.NewRepository())
            {
                var specification = _builder
                    .Create<ISpecification<Performance>>()
                    .From(request)
                    ;

                var query = repository.Find<Performance>()
                    .Where(specification.IsSatisfied())
                    ;

                var queryResults = query.ToList();

                var details = _builder
                    .CreateEnumerable<PerformanceDetail>()
                    .FromEnumerable(queryResults)
                    .ToArray()
                    ;

                var response = new QueryResponse<PerformanceDetail>()
                                   {
                                       Page = 1,
                                       PageSize = details.Count(),
                                       Results = details,
                                       TotalRecords = details.Count(),
                                   };

                return response;
            }
        }

        public void Dispose()
        {
            // do nothing
        }
    }
}
