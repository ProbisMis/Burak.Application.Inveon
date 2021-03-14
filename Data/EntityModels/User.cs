using Burak.Application.Inveon.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Data.EntityModels
{
    /// <summary>
    /// User DB Entity class
    /// </summary>
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }  
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
    }
}
