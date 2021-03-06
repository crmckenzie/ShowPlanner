﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ShowPlanner.Data.Models
{
    public class Venue
    {
        public int? VenueId { get; set; }

        public IList<Stage> Stages { get; set; } 

        [Required]
        public string Name { get; set; }

        public string Owner { get; set; }

    }
}
