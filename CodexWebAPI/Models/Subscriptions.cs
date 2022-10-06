using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Subscriptions
    {
        public Subscriptions()
        {
            Users = new HashSet<Users>();
        }

        public Guid SubscriptionTypeId { get; set; }
        public string SubscriptionPlan { get; set; }
        public decimal SubscriptionPrice { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
