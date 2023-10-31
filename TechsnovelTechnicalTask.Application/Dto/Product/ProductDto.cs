namespace TechsnovelTechnicalTask.Application.Dto.Product
{
    public class ProductDto : AuditableDto
    {
        public string Name { get; set; }
        public long  CategoryId { get; set; }

    }
}
