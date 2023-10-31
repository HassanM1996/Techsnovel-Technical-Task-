using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechsnovelTechnicalTask.Application.Dto.Category;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;
using TechsnovelTechnicalTask.Common.Pagination;

namespace TechsnovelTechnicalTask.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryFacad _categoryFacad;
        public CategoryController(ICategoryFacad categoryFacad)
        {
            _categoryFacad = categoryFacad;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery]PaginationRequest paginationRequest)
        {
            var result = _categoryFacad.GetAllCategoryService.Execute(paginationRequest);
            return new JsonResult(result);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] AddCategoryDto addCategoryDto)
        {
            var result = _categoryFacad.AddCategoryService.Execute(addCategoryDto);
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
        public async Task<IActionResult> Update([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var result = _categoryFacad.UpdateCategoryService.Execute(updateCategoryDto);
            if (result.Status)
            {
                return new JsonResult(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("/api/Category/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var result = _categoryFacad.GetCategoryService.Execute(id);
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
