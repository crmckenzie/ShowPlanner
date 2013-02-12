using System;

namespace ShowPlanner.Data.Models
{
    public class Performance
    {
        public int? PerformanceId { get; set; }

        public int? PerformerId { get; set; }
        public Performer Performer { get; set; }

        public int? ShowId { get; set; }
        public Show Show { get; set; }

        public int? StageId { get; set; }
        public Stage Stage { get; set; }

        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}