using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Category;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Category
{
    public interface IAddCategoryService
    {
        ResultDto<CategoryDto> Execute(AddCategoryDto addCategoryDto);
    }
}
