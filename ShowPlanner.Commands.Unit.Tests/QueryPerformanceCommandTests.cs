using System.Collections.Generic;
using System.Linq;
using FizzWare.NBuilder;
using Isg.Specification;
using NSubstitute;
using NUnit.Framework;
using ShowPlanner.Builders;
using ShowPlanner.Commands.Performances;
using ShowPlanner.Commands.Venues;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;
using ShowPlanner.Data.Orm.Specifications;
using ShowPlanner.Services;

namespace ShowPlanner.Commands.Unit.Tests
{
    [TestFixture]
    public class QueryPerformanceCommandTests
    {
        [TestFixtureSetUp]
        public void BeforeAnyTestRuns()
        {
            this.Database = Substitute.For<IDatabase>();
            this.Repository = Substitute.For<IRepository>();
            this.BuilderApi = Substitute.For<IBuild>();

            this.Database.NewRepository().Returns(this.Repository);

            this.Command = new QueryPerformanceCommand(this.Database, this.BuilderApi);
        }

        private IBuild BuilderApi { get; set; }

        private IRepository Repository { get; set; }

        private IDatabase Database { get; set; }

        private QueryPerformanceCommand Command { get; set; }

        [Test]
        public void Execute()
        {
            var request = new QueryPerformanceRequest();
            var performances = Builder<Performance>
                .CreateListOfSize(10)
                .Build()
                .AsQueryable()
                ;

            var performanceDetails = Builder<PerformanceDetail>
                .CreateListOfSize(10)
                .Build()
                .ToArray()
                ;

            // Arrange

            var allTrue = new AlwaysTrueSpecification<Performance>();

            this.BuilderApi.Create<ISpecification<Performance>>()
                .From(request)
                .Returns(allTrue);

            this.Repository.Find<Performance>()
                .Returns(performances)
                ;

            this.BuilderApi
                .CreateEnumerable<PerformanceDetail>()
                .FromEnumerable<Performance>(Arg.Any<IEnumerable<Performance>>())
                .Returns(performanceDetails)
                ;

            // Act
            var response = this.Command.Execute(request);

            // Assert
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Results, Is.EquivalentTo(performanceDetails));
            Assert.That(response.Page, Is.EqualTo(1));
            Assert.That(response.PageSize, Is.EqualTo(performances.Count()));
            Assert.That(response.TotalRecords, Is.EqualTo(performances.Count()));
        }
    }
}