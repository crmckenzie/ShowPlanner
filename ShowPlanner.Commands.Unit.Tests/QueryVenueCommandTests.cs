using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using PPA.Repository;
using PPA.Repository.Specifications;
using ShowPlanner.Commands.Venues;
using ShowPlanner.Converters;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;
using ShowPlanner.Data.Orm.Specifications;

namespace ShowPlanner.Commands.Unit.Tests
{
    [TestFixture]
    public class QueryVenueCommandTests
    {
        [TestFixtureSetUp]
        public void BeforeAnyTestRuns()
        {
            this.Database = Substitute.For<IDatabase>();
            this.Repository = Substitute.For<IRepository>();
            this.BuilderApi = Substitute.For<IBuilder>();

            this.Database.NewRepository().Returns(this.Repository);

            this.Command = new QueryVenueCommand(this.Database, this.BuilderApi);
        }

        protected IBuilder BuilderApi { get; set; }

        protected IRepository Repository { get; set; }

        protected IDatabase Database { get; set; }

        protected QueryVenueCommand Command { get; set; }

        [Test]
        public void Execute()
        {
            var request = new QueryVenueRequest();
            var venues = Builder<Venue>
                .CreateListOfSize(10)
                .Build()
                .AsQueryable()
                ;

            var venueDetails = Builder<VenueDetail>
                .CreateListOfSize(10)
                .Build()
                .ToArray()
                ;

            // Arrange

            var allTrue = new AlwaysTrueSpecification<Venue>();

            this.BuilderApi.Create<ISpecification<Venue>>()
                .From(request)
                .Returns(allTrue);

            this.Repository.Find<Venue>()
                .Returns(venues)
                ;

            this.BuilderApi
                .CreateEnumerable<VenueDetail>()
                .FromEnumerable<Venue>(Arg.Any<IEnumerable<Venue>>())
                .Returns(venueDetails)
                ;

            // Act
            var response = this.Command.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Results, Is.EquivalentTo(venueDetails));
            Assert.That(response.Page, Is.EqualTo(1));
            Assert.That(response.PageSize, Is.EqualTo(venues.Count()));
            Assert.That(response.TotalRecords, Is.EqualTo(venues.Count()));
        }
    }
}
