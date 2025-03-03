using Microsoft.AspNetCore.Identity;

namespace Security
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public ApplicationUser()
        {
            this.ApplicationUserRoles = new List<ApplicationUserRole>();
        }
    }
}
