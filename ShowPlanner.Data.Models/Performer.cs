using System.Collections.Generic;

namespace ShowPlanner.Data.Models
{
    public class Performer
    {
        public int? PerformerId { get; set; }
        public string Name { get; set; }

        public IList<Performance> Performances { get; set; }
    }
}