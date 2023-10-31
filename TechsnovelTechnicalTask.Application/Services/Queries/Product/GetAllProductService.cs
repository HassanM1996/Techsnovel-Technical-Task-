using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Common.Pagination;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Product
{
    public class GetAllProductService : IGetAllProductService
    {
        private readonly ISqlDataBaseContext _context;
        public GetAllProductService(ISqlDataBaseContext context)
        {
            _context = context;
        }

        public ResultListDto<ProductDto> Execute(PaginationRequest request)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchKey))
            {
                products = products.Where(x => x.Name.ToLower().Contains(request.SearchKey.Trim().ToLower()));
            }

            int rowsCount = 0;
            var result = products.ToPaged(request, out rowsCount).Select(s => new ProductDto
            {
                Id = s.Id,
                Name = s.Name,
                CategoryId = s.CategoryId,
                CreatedDate = s.CreatedDate,
                UpdatedDate = s.UpdatedDate,

            });

            return new ResultListDto<ProductDto>
            {
                Result = result.ToList(),
                Rows = rowsCount
            };

        }
    }
}
