using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPA.Repository.Specifications;
using ShowPlanner.Converters;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;

namespace ShowPlanner.Commands
{
    public class QueryVenueCommand : ICommand<QueryVenueRequest, QueryResponse<VenueDetail>>
    {
        private readonly IDatabase _database;
        private readonly IBuilder _builder;

        public QueryVenueCommand(IDatabase database, IBuilder builder)
        {
            _database = database;
            _builder = builder;
        }

        public QueryResponse<VenueDetail> Execute(QueryVenueRequest request)
        {
            using (var repository = _database.NewRepository())
            {
                var specification = _builder.Create<ISpecification<Venue>>()
                    .From(request)
                    ;

                var query = repository.Find<Venue>()
                    .Where(specification.IsSatisfied())
                    ;

                var queryResults = query.ToList();

                var venueDetails = _builder.CreateEnumerable<VenueDetail>()
                    .FromEnumerable(queryResults)
                    .ToArray()
                    ;

                return new QueryResponse<VenueDetail>()
                           {
                               Results = venueDetails,
                               Page = 1,
                               PageSize = venueDetails.Length,
                               TotalRecords = venueDetails.Length,
                           };
            }

        }

        public void Dispose()
        {
            // do nothing
        }
    }
}
