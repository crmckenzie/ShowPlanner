using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FizzWare.NBuilder;
using NUnit.Framework;
using ShowPlanner.Data.Models;
using ShowPlanner.Data.Orm.Mappings;

namespace ShowPlanner.Data.Orm.Integration.Tests
{
    [TestFixture]
    public class VenueTests
    {
        [TestFixtureSetUp]
        public void BeforeAnyTestRuns()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ShowPlannerDbContext>());
        }

        [Test]
        public void Insert()
        {
            // Arrange
            int? venueId = null;

            // Act
            using (var db = CreateDbContext())
            {
                var venue = Builder<Venue>
                    .CreateNew()
                    .Do(row =>
                    {
                        row.VenueId = null;
                    })
                    .Build()
                    ;

                db.Set<Venue>().Add(venue);

                db.SaveChanges();

                venueId = venue.VenueId;
            }

            // Assert
            using (var db = CreateDbContext())
            {
                var venue = db.Set<Venue>().Find(venueId);
                Assert.That(venue, Is.Not.Null);
            }

        }

        private static ShowPlannerDbContext CreateDbContext()
        {
            return new ShowPlannerDbContext(new DefaultConfigurationProvider());
        }
    }
}
