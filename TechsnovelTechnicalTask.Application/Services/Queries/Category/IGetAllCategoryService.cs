using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Common.Pagination;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Category
{
    public interface IGetAllCategoryService
    {
        ResultListDto<CategoryDto> Execute(PaginationRequest request);
    }
}
