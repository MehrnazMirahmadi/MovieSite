using Microsoft.AspNetCore.Identity;

namespace Security
{
    public class ApplicationRole : IdentityRole<int>
    {
        public string Description { get; set; }
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public ApplicationRole()
        {
            this.ApplicationUserRoles = new List<ApplicationUserRole>();
        }
    }
}
