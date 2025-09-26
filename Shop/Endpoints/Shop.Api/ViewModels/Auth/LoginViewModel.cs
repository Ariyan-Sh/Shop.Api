using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="شماره تلفن را وارد کنید")]
        [MinLength(11,ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="رمز عبور را وارد کنید")]
        public string Password { get; set; }
    }
}
