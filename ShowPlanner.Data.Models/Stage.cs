using System.Collections.Generic;

namespace ShowPlanner.Data.Models
{
    public class Stage
    {
        public int? StageId { get; set; }
        public string Name { get; set; }

        public int? VenueId { get; set; }
        public Venue Venue { get; set; }

        public IList<Performance> Showings { get; set; } 
    }
}