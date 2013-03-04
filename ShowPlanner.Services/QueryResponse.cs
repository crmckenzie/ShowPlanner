namespace ShowPlanner.Services
{
    public class QueryResponse<T>
    {
        public T[] Results { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }
    }
}
