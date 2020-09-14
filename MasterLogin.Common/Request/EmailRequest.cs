using System.ComponentModel.DataAnnotations;

namespace MasterLogin.Common.Request
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
