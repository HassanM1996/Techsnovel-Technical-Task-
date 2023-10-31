using TechsnovelTechnicalTask.Application.Services.Commands.Category;
using TechsnovelTechnicalTask.Application.Services.Queries.Category;

namespace TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns
{
    public interface ICategoryFacad
    {
        IAddCategoryService AddCategoryService { get; }
        IUpdateCategoryService UpdateCategoryService { get; }
        IGetCategoryService GetCategoryService { get; }
        IGetAllCategoryService GetAllCategoryService { get; }
    }
}
