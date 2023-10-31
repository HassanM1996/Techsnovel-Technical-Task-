using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Category;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Category
{
    public interface IUpdateCategoryService
    {
        ResultDto<CategoryDto> Execute(UpdateCategoryDto updateCategoryDto);
    }
}
