using TechsnovelTechnicalTask.Application.Services.Commands.Product;
using TechsnovelTechnicalTask.Application.Services.Queries.Product;

namespace TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns
{
    public interface IProductFacad
    {
        IAddProductService AddProductService { get; }
        IUpdateProductService UpdateProductService { get; }
        IGetProductService GetProductService { get; }
        IGetAllProductService GetAllProductService { get; }
    }
}
