using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Product
{
    public class AddProductService : IAddProductService
    {
        private readonly ISqlDataBaseContext _context;
        public AddProductService(ISqlDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDto> Execute(AddProductDto addCategoryDto)
        {
            if (!_context.Categories.Any(x => x.Id == addCategoryDto.CategoryId))
            {
                return new ResultDto<ProductDto>
                {
                    Status = false,
                    Message = AlertMessages.CategoryNotFound,
                    Model = new ProductDto
                    {
                        Id = 0,
                        Name = addCategoryDto.Name,
                        CategoryId = addCategoryDto.CategoryId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    }
                };
            }

            var product = new Domain.Entities.Product
            {
                Name = addCategoryDto.Name,
                CategoryId = addCategoryDto.CategoryId,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };

            product = _context.Products.Add(product).Entity;

            _context.SaveChanges();

            return new ResultDto<ProductDto>
            {
                Message = AlertMessages.SetDataSuccessful,
                Status = true,
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
