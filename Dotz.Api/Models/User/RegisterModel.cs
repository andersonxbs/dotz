using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dotz.Api.Models.User
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
    }
}
