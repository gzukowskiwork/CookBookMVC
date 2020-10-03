using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models.Identity
{
    public class UserRegistration
    {
        public string FitstName { get; set; }
        public string Surname { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
