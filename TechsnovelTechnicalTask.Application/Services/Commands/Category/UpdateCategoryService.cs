using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;

namespace TechsnovelTechnicalTask.Application.Services.Commands.Category
{
    public class UpdateCategoryService : IUpdateCategoryService
    {
        private readonly ISqlDataBaseContext _context;
        public UpdateCategoryService(ISqlDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<CategoryDto> Execute(UpdateCategoryDto updateCategoryDto)
        {
            var category = _context.Categories.Find(updateCategoryDto.Id);
            if (category == null)
            {
                return new ResultDto<CategoryDto>
                {
                    Message = AlertMessages.FindFaild,
                    Status = false,
                    Model = new CategoryDto
                    {
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Id = 0,
                        Name = updateCategoryDto.Name
                    }
                };
            }
            else
            {
                category.Name = updateCategoryDto.Name;
                category.UpdatedDate = DateTime.Now;
                _context.Categories.Update(category);
                _context.SaveChanges();
                return new ResultDto<CategoryDto>
                {
                    Message = AlertMessages.UpdateSuccess,
                    Status = true,
                    Model = new CategoryDto
                    {
                        CreatedDate = category.CreatedDate,
                        UpdatedDate = category.UpdatedDate,
                        Id = category.Id,
                        Name = updateCategoryDto.Name
                    }
                };
            }

        }
    }
}
