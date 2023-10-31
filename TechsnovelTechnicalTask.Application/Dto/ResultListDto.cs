namespace TechsnovelTechnicalTask.Application.Dto
{
    public class ResultListDto<T>
    {
        public List<T> Result { get; set; }
        public int Rows { get; set; }
    }
}

