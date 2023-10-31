using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Authentication;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Authentication
{
    public interface IUserSigninService
    {
        ResultDto<UserSigninDto> Execute(SigninDto signinDto);
    }
}
