using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Dto;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Product
{
    public interface IGetProductService
    {
        ResultDto<ProductDto> Execute(long id);
    }
}
