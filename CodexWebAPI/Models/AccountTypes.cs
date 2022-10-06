using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class AccountTypes
    {
        public AccountTypes()
        {
            Users = new HashSet<Users>();
        }

        public Guid AccountTypeId { get; set; }
        public string AccountType { get; set; }
        public DateTime? DateCreated { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
