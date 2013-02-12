namespace Sextant.Common.Commands
{
    public class QueryResponse<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public T[] Results { get; set; }
        public int TotalRecords { get; set; }
    }
}
