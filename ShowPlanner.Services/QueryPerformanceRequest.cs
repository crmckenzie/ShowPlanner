namespace ShowPlanner.Services
{
    public class QueryPerformanceRequest
    {
        public int[] PerformanceIds { get; set; }
        public string[] Artists { get; set; }
        public string[] Venues { get; set; }
        public bool? Upcoming { get; set; }
    }
}