using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Data.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }

        public int? ShowId { get; set; }
        [Required]
        public Show Show { get; set; }

        public int? CustomerId { get; set; }
        public Customer SoldTo { get; set; }

        public bool? Sold { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}