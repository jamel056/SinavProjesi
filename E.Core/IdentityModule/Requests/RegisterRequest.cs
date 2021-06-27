using System.ComponentModel.DataAnnotations;

namespace E.Core.IdentityModule.Requests
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "not match with password field")]
        public string ConfirmPassword { get; set; }
    }
}
