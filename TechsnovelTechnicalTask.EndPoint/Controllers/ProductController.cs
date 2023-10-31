using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechsnovelTechnicalTask.Application.Dto.Product;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;
using TechsnovelTechnicalTask.Common.Pagination;

namespace TechsnovelTechnicalTask.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _ProductFacad;
        public ProductController(IProductFacad ProductFacad)
        {
            _ProductFacad = ProductFacad;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] PaginationRequest paginationRequest)
        {
            var result = _ProductFacad.GetAllProductService.Execute(paginationRequest);
            return new JsonResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddProductDto addProductDto)
        {
            var result = _ProductFacad.AddProductService.Execute(addProductDto);
            if (result.Status)
            {
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
        {
            var result = _ProductFacad.UpdateProductService.Execute(updateProductDto);
            if (result.Status)
            {
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("/api/Product/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var result = _ProductFacad.GetProductService.Execute(id);
            if (result.Status)
            {
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
