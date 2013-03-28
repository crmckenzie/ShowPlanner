using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Data.Models
{
    public class Performer
    {
        public int? PerformerId { get; set; }

        public IList<Performance> Performances { get; set; }

        [Required]
        public string Name { get; set; }

    }
}