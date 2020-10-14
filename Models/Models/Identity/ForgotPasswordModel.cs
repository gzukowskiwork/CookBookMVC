using System.ComponentModel.DataAnnotations;

namespace Models.Models.Identity
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
