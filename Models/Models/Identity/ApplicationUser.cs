using Microsoft.AspNetCore.Identity;


namespace Models.Identity
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
