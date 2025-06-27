using System.ComponentModel.DataAnnotations;

namespace LocalMind.API.Models.UserCredentials
{
    public class UserCredential
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
