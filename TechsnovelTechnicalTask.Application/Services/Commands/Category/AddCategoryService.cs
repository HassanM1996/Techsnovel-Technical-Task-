using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Category
{
    public class AddCategoryService : IAddCategoryService
    {
        private readonly ISqlDataBaseContext _context;
        public AddCategoryService(ISqlDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<CategoryDto> Execute(AddCategoryDto addCategoryDto)
        {
            addCategoryDto.Name = addCategoryDto.Name.Trim().ToLower();
            
            if (_context.Categories.Any(x => x.Name == addCategoryDto.Name))
            {
                return new ResultDto<CategoryDto>
                {
                    Status = false,
                    Message = AlertMessages.CategoryDuplicate,
                    Model = new CategoryDto
                    {
                        Name = addCategoryDto.Name,
                        UpdatedDate = DateTime.Now,
                        CreatedDate = DateTime.Now,
                    }
                };

            }

            var category = new Domain.Entities.Category
            {
                Name = addCategoryDto.Name,
                UpdatedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };
            
            category = _context.Categories.Add(category).Entity;
            _context.SaveChanges();

            return new ResultDto<CategoryDto>
            {
                Message = AlertMessages.SetDataSuccessful,
                Status = true,
                Model = new CategoryDto
                {
                                        Id = category.Id,
                    Name = category.Name,
                    CreatedDate = category.CreatedDate,
                    UpdatedDate = category.UpdatedDate,
                }
            };
        }
    }
}
