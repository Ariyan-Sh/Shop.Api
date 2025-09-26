using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "شماره تلفن را وارد کنید")]
        [MinLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        [MaxLength(11, ErrorMessage = ValidationMessages.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [MinLength(6,ErrorMessage ="کلمه عبور باید بیشتر از 6 کاراکتر باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "رمز عبور را دوباره وارد کنید")]
        [MinLength(6, ErrorMessage = "کلمه عبور باید بیشتر از 6 کاراکتر باشد")]
        [Compare(nameof(Password),ErrorMessage ="کلمه های عبور یکسان نیستند")]
        public string ConfirmPassword { get; set; }
    }
}
