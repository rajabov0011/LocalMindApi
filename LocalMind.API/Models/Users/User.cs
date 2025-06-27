using System;
using System.ComponentModel.DataAnnotations;
using LocalMind.API.Models.UserAdditionalDetails;

namespace LocalMind.API.Models.Users
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public UserAdditionalDetail UserAdditionalDetail { get; set; }
    }   
}
