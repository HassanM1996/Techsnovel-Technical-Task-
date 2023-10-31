namespace TechsnovelTechnicalTask.Application.Dto.Product
{
    public class UpdateProductDto: EntityDto
    {
        public string Name { get; set; }
        public long CategoryId { get; set; }
    }
}
