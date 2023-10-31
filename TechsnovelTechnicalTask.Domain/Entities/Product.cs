using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechsnovelTechnicalTask.Domain.Entities
{
    public class Product : AuditableEntity
    {
        [MaxLength(250)]
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
