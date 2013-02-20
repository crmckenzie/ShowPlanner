using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShowPlanner.Data.Models
{
    public class Venue
    {
        public int? VenueId { get; set; }

        public string Name { get; set; }

        public string Owner { get; set; }

        public IList<Stage> Stages { get; set; } 
    }
}
