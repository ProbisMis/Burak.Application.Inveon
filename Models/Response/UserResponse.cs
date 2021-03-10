using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Models.Response
{
    public class UserResponse
    {
        //public ICollection<UserItem> UserItems { get; set; }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } //TODO: Convert to Password Model (hash,password,salt,updated,userid,id), Map to Passwords
        public bool IsDeleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string Token { get; set; }
    }
}
