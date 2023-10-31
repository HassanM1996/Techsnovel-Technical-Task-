namespace TechsnovelTechnicalTask.Common.Pagination
{
    public class PaginationRequest
    {
        public bool Pageination { get; set; }
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public string? SearchKey { get; set; }
    }
}
