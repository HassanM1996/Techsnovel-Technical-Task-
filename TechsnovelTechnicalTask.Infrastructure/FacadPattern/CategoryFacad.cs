using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;
using TechsnovelTechnicalTask.Application.Services.Commands.Category;
using TechsnovelTechnicalTask.Application.Services.Queries.Category;

namespace TechsnovelTechnicalTask.Infrastructure.FacadPattern
{
    public class CategoryFacad : ICategoryFacad
    {
        private readonly ISqlDataBaseContext _context;
        public CategoryFacad(ISqlDataBaseContext context)
        {
            _context = context;
        }

        private IAddCategoryService _addCategoryService;
        public IAddCategoryService AddCategoryService
        {
            get { return _addCategoryService = _addCategoryService ?? new AddCategoryService(_context); }
        }
        
        private IUpdateCategoryService _updateCategoryService;
        public IUpdateCategoryService UpdateCategoryService
        {
            get { return _updateCategoryService = _updateCategoryService ?? new UpdateCategoryService(_context); }
        }
        
        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService
        {
            get { return _getCategoryService = _getCategoryService ?? new GetCategoryService(_context); }
        }
        
        private IGetAllCategoryService _getAllCategoryService;
        public IGetAllCategoryService GetAllCategoryService
        {
            get { return _getAllCategoryService = _getAllCategoryService ?? new GetAllCategoryService(_context); }
        }

    }
}
