using System.ComponentModel.DataAnnotations;


namespace TechsnovelTechnicalTask.Domain.Entities
{
    public abstract class BaseEntity
    {

    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T Id { get; set; }

        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; }
    }
    public abstract class Entity : Entity<long>
    {

    }
}
