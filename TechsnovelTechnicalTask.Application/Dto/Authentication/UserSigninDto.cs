using TechsnovelTechnicalTask.Domain.Enums;

namespace TechsnovelTechnicalTask.Application.Dto.Authentication
{
    public class UserSigninDto
    {
        public long UserId { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
    }
}
