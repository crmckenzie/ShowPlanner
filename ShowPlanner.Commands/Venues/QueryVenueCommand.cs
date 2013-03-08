using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isg.Specification;
using ShowPlanner.Builders;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;
using ShowPlanner.Services;

namespace ShowPlanner.Commands.Venues
{
    public class QueryVenueCommand : ICommand<QueryVenueRequest, QueryResponse<VenueDetail>>
    {
        private readonly IDatabase _database;
        private readonly IBuild _build;

        public QueryVenueCommand(IDatabase database, IBuild build)
        {
            _database = database;
            _build = build;
        }

        public QueryResponse<VenueDetail> Execute(QueryVenueRequest request)
        {
            using (var db = _database.NewRepository())
            {
                var specification = _build
                    .Create<ISpecification<Venue>>()
                    .From(request)
                    ;

                var query = db.Find<Venue>()
                    .Where(specification.IsSatisfied())
                    ;

                var queryResults = query.ToList();

                var details = _build
                    .CreateEnumerable<VenueDetail>()
                    .FromEnumerable(queryResults)
                    .ToArray()
                    ;

                var response = new QueryResponse<VenueDetail>
                                   {
                                       Page = 1,
                                       PageSize = details.Length,
                                       Results = details,
                                       TotalRecords = details.Length,
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
