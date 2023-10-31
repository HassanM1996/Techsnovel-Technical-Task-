
using TechsnovelTechnicalTask.Application.Dto;
using TechsnovelTechnicalTask.Application.Dto.Authentication;
using TechsnovelTechnicalTask.Application.Interfaces.Contexts;
using TechsnovelTechnicalTask.Common.Messages;
using TechsnovelTechnicalTask.Common.Utilities;
using TechsnovelTechnicalTask.Domain.Entities;

namespace TechsnovelTechnicalTask.Application.Services.Queries.Authentication
{
    public class UserSigninService : IUserSigninService
    {
        private readonly ISqlDataBaseContext _context;
        public UserSigninService(ISqlDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<UserSigninDto> Execute(SigninDto signinDto)
        {
            if (string.IsNullOrWhiteSpace(signinDto.Email) || string.IsNullOrWhiteSpace(signinDto.Password))
            {
                return new ResultDto<UserSigninDto>()
                {
                    Model = new UserSigninDto(),
                    Status = false,
                    Message = AlertMessages.LoginNotFill,
                };
            }

            UserAccount user = _context.UserAccounts.FirstOrDefault(p => p.Email.Equals(signinDto.Email));
            if (user == null)
            {
                return new ResultDto<UserSigninDto>()
                {
                    Model = new UserSigninDto(),
                    Status = false,
                    Message = AlertMessages.UserNotFound,
                };
            }
            var passwordHasher = new PasswordHasher();
            bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, signinDto.Password);


            if (resultVerifyPassword == false)
            {
                return new ResultDto<UserSigninDto>()
                {
                    Model = new UserSigninDto(),
                    Status = false,
                    Message = AlertMessages.WrongPassword,
                };
            }

            return new ResultDto<UserSigninDto>()
            {
                Model = new UserSigninDto
                {

                    UserId = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                },
                Status = true,
                Message =  AlertMessages.loginSuccess,
            };
        }

    }
}
