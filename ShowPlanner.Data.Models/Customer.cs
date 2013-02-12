using System.Collections.Generic;

namespace ShowPlanner.Data.Models
{
    public class Customer
    {
        public int? CustomerId { get; set; }

        public string Name { get; set; }

        public IList<Ticket> Tickets { get; set; } 
    }
}