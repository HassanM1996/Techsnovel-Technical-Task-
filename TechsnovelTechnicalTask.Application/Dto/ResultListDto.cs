namespace TechsnovelTechnicalTask.Application.Dto
{
    public class ResultListDto<T>
    {
        public IEnumerable<T> result;
        public int Rows { get; set; }
    }
}

