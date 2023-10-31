using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Pagination;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Category
{
    public class GetAllCategoryService : IGetAllCategoryService
    {

        private readonly ISqlDataBaseContext _context;
        public GetAllCategoryService(ISqlDataBaseContext context)
        {
            _context = context;
        }

        public ResultListDto<CategoryDto> Execute(PaginationRequest request)
        {
            var categories = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(request.SearchKey.Trim().ToLower()));
            }

            int rowsCount = 0;
            var result = categories.ToPaged(request, out rowsCount).Select(s => new CategoryDto
            {
                Id = s.Id,
                Name = s.Name,
                CreatedDate = s.CreatedDate,
                UpdatedDate = s.UpdatedDate,

            });

            return new ResultListDto<CategoryDto>
            {
                result = result,
                Rows = rowsCount
            };

        }
    }
}
