using System;
using System.ComponentModel.DataAnnotations;

namespace ShowPlanner.Data.Models
{
    public class Performance
    {
        public int? PerformanceId { get; set; }

        public int? PerformerId { get; set; }
        [Required]
        public Performer Performer { get; set; }

        public int? ShowId { get; set; }
        [Required]
        public Show Show { get; set; }

        public int? StageId { get; set; }
        [Required]
        public Stage Stage { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}