using System.ComponentModel.DataAnnotations;

namespace TechsnovelTechnicalTask.Application.Dto.Category
{
    public class CategoryDto : AuditableDto
    {
        [MaxLength(250)]
        [Display(Name = "Category name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Name { get; set; }

    }
}
