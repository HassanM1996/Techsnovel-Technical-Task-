using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Product;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Product
{
    public interface IAddProductService
    {
        ResultDto<ProductDto> Execute(AddProductDto addProductDto);
    }
}
