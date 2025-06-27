using LocalMind.API.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalMind.API.Models.UserAdditionalDetails
{
    public class UserAdditionalDetail
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        [ForeignKey("Users")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
