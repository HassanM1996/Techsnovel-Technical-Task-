namespace TechsnovelTechnicalTask.Common.Pagination
{
    public class PaginationRequest
    {
        public bool Pageination { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
    }
}
