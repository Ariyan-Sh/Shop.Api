using Common.Application.Validation.CustomValidation.IFormFile;
using Shop.Domain.UserAgg.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Users
{
    public class EditUserForAdminViewModel
    {
        public long UserId { get; set; }
        public IFormFile? Avatar { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
