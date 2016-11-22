using System.ComponentModel.DataAnnotations;

namespace BaseSource.Identity.Models
{
    public class SignIn
    {
        [Required]
        [Display(Name = "Username")]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
