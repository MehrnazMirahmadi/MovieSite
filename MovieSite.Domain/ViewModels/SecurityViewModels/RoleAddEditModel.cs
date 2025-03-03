using System.ComponentModel.DataAnnotations;

namespace MovieSite.Domain.ViewModels.SecurityViewModels
{
    public class RoleAddEditModel
    {
        public int RoleID { get; set; }
        [Required(ErrorMessage = "*")]
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
