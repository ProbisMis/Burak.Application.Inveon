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
        //public ICollection<UserItem> UserItems { get; set; }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }  
        public DateTime? CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public string? Token { get; set; }

        //[ForeignKey(nameof(TypeId))]
        //public virtual Type Type { get; set; }

        //[ForeignKey(nameof(StatusId))]
        //public virtual Status Status { get; set; }

        //[ForeignKey(nameof(SlotId))]
        //public virtual Slot Slot { get; set; }
    }
}
