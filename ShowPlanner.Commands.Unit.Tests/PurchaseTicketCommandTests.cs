using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FizzWare.NBuilder;
using NSubstitute;
using NUnit.Framework;
using ShowPlanner.Commands.Tickets;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;

namespace ShowPlanner.Commands.Unit.Tests
{
    [TestFixture]
    public class PurchaseTicketCommandTests
    {
        [TestFixtureSetUp]
        public void BeforeAnyTestRuns()
        {
        }

        [SetUp]
        public void BeforeEachTestRuns()
        {
            this.Database = Substitute.For<IDatabase>();
            this.Repository = Substitute.For<IRepository>();
            this.Database.NewRepository().Returns(this.Repository);
            this.Command = new PurchaseTicketCommand(this.Database);
        }

        protected IRepository Repository { get; set; }

        protected PurchaseTicketCommand Command { get; set; }

        protected IDatabase Database { get; set; }

        [Test]
        public void Execute()
        {
            // Arrange
            var customer = Builder<Customer>
                .CreateNew()
                .Build()
                ;

            var ticket = Builder<Ticket>
                .CreateNew()
                .Do(row=>
                        {
                            row.SoldTo = null;
                            row.Sold = false;
                        })
                .Build()
                ;

            this.Repository.Get<Customer>(customer.CustomerId.Value).Returns(customer);
            this.Repository.Get<Ticket>(ticket.TicketId.Value).Returns(ticket);

            var request = new PurchaseTicketRequest()
                              {
                                  CustomerId = customer.CustomerId.Value,
                                  TicketId = ticket.TicketId.Value
                              };

            // Act
            var response = this.Command.Execute(request);

            // Assert
            Assert.That(response.Success, Is.True);
            
            Assert.That(ticket.SoldTo, Is.SameAs(customer));
            Assert.That(ticket.Sold, Is.True);

            this.Repository.Received().Commit();
        }
    }
}
