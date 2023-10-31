
namespace TechsnovelTechnicalTask.Domain.Entities
{
    public interface IAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
