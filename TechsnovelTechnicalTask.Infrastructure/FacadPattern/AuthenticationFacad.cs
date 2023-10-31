using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;
using TechsnovelTechnicalTask.Application.Services.Queries.Authentication;

namespace TechsnovelTechnicalTask.Infrastructure.FacadPattern
{
    public class AuthenticationFacad : IAuthenticationFacad
    {
        private readonly ISqlDataBaseContext _context;
        public AuthenticationFacad(ISqlDataBaseContext context)
        {
            _context = context;
        }

        private IUserSigninService _userSigninService;
        public IUserSigninService UserSigninService
        {
            get
            {
                return _userSigninService = _userSigninService ?? new UserSigninService(_context);
            }
        }
    }
}
