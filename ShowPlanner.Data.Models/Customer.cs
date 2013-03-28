using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Data.Models
{
    public class Customer
    {
        public int? CustomerId { get; set; }

        public IList<Ticket> Tickets { get; set; }

        [Required]
        public string Name { get; set; }
    }
}