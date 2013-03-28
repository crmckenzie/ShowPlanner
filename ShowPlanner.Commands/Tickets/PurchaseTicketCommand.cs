using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowPlanner.Data;
using ShowPlanner.Data.Models;

namespace ShowPlanner.Commands.Tickets
{

    public class PurchaseTicketRequest
    {
        public int TicketId { get; set; }

        public int CustomerId { get; set; }
    }

    public class PurchaseTicketResponse
    {
        public bool Success { get; set; }
    }

    public class PurchaseTicketCommand: ICommand<PurchaseTicketRequest, PurchaseTicketResponse>
    {
        private readonly IDatabase _database;

        public PurchaseTicketCommand(IDatabase database)
        {
            _database = database;
        }

        public PurchaseTicketResponse Execute(PurchaseTicketRequest request)
        {
            using (var repository = _database.NewRepository())
            {
                var ticket = repository.Get<Ticket>(request.TicketId);
                var customer = repository.Get<Customer>(request.CustomerId);
                ticket.SoldTo = customer;
                ticket.Sold = true;
                repository.Commit();
            
                return new PurchaseTicketResponse()
                           {
                               Success = true, 
                           };
            }
        }

        public void Dispose()
        {
        }
    }


}
