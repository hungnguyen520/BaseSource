using System.ComponentModel.DataAnnotations;

namespace BaseSource.Identity.Models
{
    public class ConfirmEmail
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
