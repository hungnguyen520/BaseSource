using System.ComponentModel.DataAnnotations;

namespace BaseSource.Identity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must enter username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}