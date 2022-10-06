using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Sessions = new HashSet<Sessions>();
            UserAnswers = new HashSet<UserAnswers>();
            UserCart = new HashSet<UserCart>();
            UserCourse = new HashSet<UserCourse>();
        }

        public Guid UserId { get; set; }
        public Guid AccountTypeId { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Guid SubscriptionTypeId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateDeleted { get; set; }
        public byte[] UserImage { get; set; }

        public virtual AccountTypes AccountType { get; set; }
        public virtual Subscriptions SubscriptionType { get; set; }
        public virtual ICollection<Sessions> Sessions { get; set; }
        public virtual ICollection<UserAnswers> UserAnswers { get; set; }
        public virtual ICollection<UserCart> UserCart { get; set; }
        public virtual ICollection<UserCourse> UserCourse { get; set; }
    }
}
