using System.ComponentModel.DataAnnotations.Schema;

namespace TechsnovelTechnicalTask.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public string Name { get; set; }

        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
