using System.ComponentModel.DataAnnotations;

namespace BaseSource.Identity.Models
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress(ErrorMessage = "Your email looks incorrect. Please check and try again.")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        public bool SendEmailSuccessed { get; set; }
    }
}
