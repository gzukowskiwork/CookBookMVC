using System.ComponentModel.DataAnnotations;

namespace Models.Models.Identity
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
