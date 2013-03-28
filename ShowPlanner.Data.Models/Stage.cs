using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Data.Models
{
    public class Stage
    {
        public int? StageId { get; set; }

        public int? VenueId { get; set; }
        [Required]
        public Venue Venue { get; set; }

        public IList<Performance> Showings { get; set; }

        [Required]
        public string Name { get; set; }
    }
}