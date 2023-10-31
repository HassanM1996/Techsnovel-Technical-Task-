namespace TechsnovelTechnicalTask.Common.Pagination
{
    public static class Pagination
    {
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> sources, PaginationRequest paginationRequest, out int rowsCount)
        {
            rowsCount = sources.Count();
            if (paginationRequest.Pageination)
            {
                return sources.Skip((paginationRequest.Page - 1) * paginationRequest.PageSize).Take(paginationRequest.PageSize).ToList();
            }
            else
                return sources;
        }
    }
}
