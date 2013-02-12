using System.Collections.Generic;

namespace ShowPlanner.Data.Models
{
    public class Show
    {
        public int? ShowId { get; set; }

        public string Title { get; set; }

        public IList<Ticket> Tickets { get; set; }
    }
}