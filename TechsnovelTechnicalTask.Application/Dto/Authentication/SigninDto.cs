using System.ComponentModel.DataAnnotations;


namespace TechsnovelTechnicalTask.Application.Dto.Authentication
{
    public class SigninDto
    {
        [MaxLength(250)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Email { get; set; }

        [Display(Name = "Password ")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
