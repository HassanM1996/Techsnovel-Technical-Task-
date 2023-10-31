using System.ComponentModel.DataAnnotations;

namespace TechsnovelTechnicalTask.Domain.Entities
{
    public class Category:AuditableEntity
    {
        [MaxLength(250)]
        [Display(Name = "Category name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
