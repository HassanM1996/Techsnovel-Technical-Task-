using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Common.Pagination;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Product
{
    public interface IGetAllProductService
    {
        ResultListDto<ProductDto> Execute(PaginationRequest request);
    }
}
