using System.ComponentModel.DataAnnotations;

namespace TechsnovelTechnicalTask.Application.Dto.Product
{
    public class ProductDto : AuditableDto
    {
        [MaxLength(250)]
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Name { get; set; }
        public long  CategoryId { get; set; }

    }
}
