using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Category
{
    public class GetCategoryService : IGetCategoryService
    {
        private readonly ISqlDataBaseContext _context;
        public GetCategoryService(ISqlDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<CategoryDto> Execute(long id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return new ResultDto<CategoryDto>
                {
                    Status = false,
                    Message = AlertMessages.FindFaild
                };
            }
            return new ResultDto<CategoryDto>
            {
                Status = true,
                Message = AlertMessages.FindSuccess,
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
