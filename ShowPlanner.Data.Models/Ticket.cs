namespace ShowPlanner.Data.Models
{
    public class Ticket
    {
        public int? TicketId { get; set; }

        public int? ShowId { get; set; }
        public Show Show { get; set; }

        public int? CustomerId { get; set; }
        public Customer SoldTo { get; set; }

        public bool? Sold { get; set; }

        public decimal Price { get; set; }

    }
}