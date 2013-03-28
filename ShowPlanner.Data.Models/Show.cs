using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Data.Models
{
    public class Show
    {
        public int? ShowId { get; set; }

        public IList<Ticket> Tickets { get; set; }

        [Required]
        public string Title { get; set; }
    }
}