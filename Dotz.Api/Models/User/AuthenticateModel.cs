using System.ComponentModel.DataAnnotations;

namespace Dotz.Api.Models.User
{
    public class AuthenticateModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
