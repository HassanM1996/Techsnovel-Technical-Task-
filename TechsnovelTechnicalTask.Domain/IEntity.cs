
namespace TechsnovelTechnicalTask.Domain.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
    }
}
