using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Product
{
    public class UpdateProductService : IUpdateProductService
    {
        private readonly ISqlDataBaseContext _context;
        public UpdateProductService(ISqlDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDto> Execute(UpdateProductDto updateCategoryDto)
        {
            if (!_context.Categories.Any(x => x.Id == updateCategoryDto.CategoryId))
            {
                return new ResultDto<ProductDto>
                {
                    Status = false,
                    Message = AlertMessages.CategoryNotFound,
                    Model = new ProductDto
                    {
                        Id = 0,
                        Name = updateCategoryDto.Name,
                        CategoryId = updateCategoryDto.CategoryId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    }
                };
            }

            var product = _context.Products.Find(updateCategoryDto.Id);

            if (product == null)
            {
                return new ResultDto<ProductDto>
                {
                    Message = AlertMessages.FindFaild,
                    Status = false,
                    Model = new ProductDto
                    {
                        Id = 0,
                        Name = updateCategoryDto.Name,
                        CategoryId = updateCategoryDto.CategoryId,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                    }
                };
            }
            else
            {
                product.Name = updateCategoryDto.Name;
                product.CategoryId = updateCategoryDto.CategoryId;
                product.UpdatedDate = DateTime.Now;

                _context.Products.Update(product);
                _context.SaveChanges();

                return new ResultDto<ProductDto>
                {
                    Message = AlertMessages.UpdateSuccess,
                    Status = true,
                    Model = new ProductDto
                    {
                        Id = product.Id,
                        Name = updateCategoryDto.Name,
                        CategoryId = product.CategoryId,
                        UpdatedDate = product.UpdatedDate,
                        CreatedDate = product.CreatedDate,
                    }
                };
            }
        }
    }
}
