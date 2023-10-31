using TechsnovelTechnicalTask.Application.Services.Queries.Authentication;

namespace TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns
{
    public interface IAuthenticationFacad
    {
        IUserSigninService UserSigninService { get; }
    }
}
