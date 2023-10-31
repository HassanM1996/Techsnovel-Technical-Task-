using System.ComponentModel.DataAnnotations;
using TechsnovelTechnicalTask.Domain.Enums;

namespace TechsnovelTechnicalTask.Domain.Entities
{
    public class UserAccount:AuditableEntity
    {
        [MaxLength(150)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} cannot be empty")]
        public string Email { get; set; }            

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} cannot be empty")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage = "Not a valid {0}. {0} value must contain 1 uppercase, 1 lowercase, 1 number, and 1 special character.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public Role Role { get; set; }

    }
}
