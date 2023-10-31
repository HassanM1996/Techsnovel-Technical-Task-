using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;
using TechsnovelTechnicalTask.Application.Services.Commands.Product;
using TechsnovelTechnicalTask.Application.Services.Queries.Product;

namespace TechsnovelTechnicalTask.Infrastructure.FacadPattern
{
    internal class ProductFacad : IProductFacad
    {
        private readonly ISqlDataBaseContext _context;
        public ProductFacad(ISqlDataBaseContext context)
        {
            _context = context;
        }

        private IAddProductService _addProductService;
        public IAddProductService AddProductService
        {
            get { return _addProductService = _addProductService ?? new AddProductService(_context); }
        }

        private IUpdateProductService _updateProductService;
        public IUpdateProductService UpdateProductService
        {
            get { return _updateProductService = _updateProductService ?? new UpdateProductService(_context); }
        }

        private IGetProductService _getProductService;
        public IGetProductService GetProductService
        {
            get { return _getProductService = _getProductService ?? new GetProductService(_context); }
        }

        private IGetAllProductService _getAllProductService;
        public IGetAllProductService GetAllProductService
        {
            get { return _getAllProductService = _getAllProductService ?? new GetAllProductService(_context); }
        }

    }
}
