using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Application.Dto;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Category
{
    public interface IGetCategoryService
    {
        ResultDto<CategoryDto> Execute(long id);
    }
}
