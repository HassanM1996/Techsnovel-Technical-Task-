namespace TechsnovelTechnicalTask.Application.Dto
{
    public class ResultDto<T>
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public T Model { get; set; }

    }
}
