using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Dto;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Product
{
    public interface IUpdateProductService
    {
        ResultDto<ProductDto> Execute(UpdateProductDto updateCategoryDto);
    }
}
