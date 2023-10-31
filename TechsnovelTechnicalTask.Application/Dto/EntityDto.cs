namespace TechsnovelTechnicalTask.Application.Dto
{
    public class EntityDto<T>
    {
        public T Id { get; set; }
    }

    public class EntityDto : EntityDto<long>
    {

    }
}
