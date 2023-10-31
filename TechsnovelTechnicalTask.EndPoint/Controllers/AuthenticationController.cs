using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TechsnovelTechnicalTask.Application.Dto.Authentication;
using TechsnovelTechnicalTask.Application.Interfaces.FacadPatterns;

namespace TechsnovelTechnicalTask.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationFacad _authenticationFacad;
        public AuthenticationController(
            IConfiguration configuration,
            IAuthenticationFacad authenticationFacad
            )
        {
            _configuration = configuration;
            _authenticationFacad = authenticationFacad;
        }
        [HttpPost]
        public async Task<IActionResult> Signin([FromBody]SigninDto signin)
        {
            var signupResult = _authenticationFacad.UserSigninService.Execute(signin);
            if (signupResult.Status == true)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var expiryMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryMinutes"]);
                var expiryDate = DateTime.UtcNow.AddMinutes(expiryMinutes);
                var key = Encoding.ASCII.GetBytes
                (_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, signin.Email),
                new Claim(ClaimTypes.Name, signin.Email),
                new Claim(ClaimTypes.Role, signupResult.Model.Role.ToString()),
                new Claim(ClaimTypes.Expiration, expiryDate.ToString("s")),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                    Expires = expiryDate,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(new { token = stringToken, Expires_in = expiryDate.ToString("s") });
            }
            return Unauthorized();
        }
    }
}
