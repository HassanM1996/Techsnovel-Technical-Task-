using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Product
{
    public class GetProductService : IGetProductService
    {
        private readonly ISqlDataBaseContext _context;
        public GetProductService(ISqlDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDto> Execute(long id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return new ResultDto<ProductDto>
                {
                    Status = false,
                    Message = AlertMessages.FindFaild
                };
            }
            return new ResultDto<ProductDto>
            {
                Status = true,
                Message = AlertMessages.FindSuccess,
                Model = new ProductDto
                {

                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    CreatedDate = product.CreatedDate,
                    UpdatedDate = product.UpdatedDate,
                }

            };
        }
    }
}
