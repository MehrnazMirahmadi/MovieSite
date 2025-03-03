using System.ComponentModel.DataAnnotations;

namespace MovieSite.Domain.ViewModels.SecurityViewModels
{
    public class UserAddEditModel
    {

        public int UserID { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Error Message")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }

    }
}
