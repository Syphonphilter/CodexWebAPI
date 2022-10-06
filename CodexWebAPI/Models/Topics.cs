using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Topics
    {
        public Topics()
        {
            Questions = new HashSet<Questions>();
            Sessions = new HashSet<Sessions>();
            TopicContent = new HashSet<TopicContent>();
        }

        public Guid TopicId { get; set; }
        public Guid ModuleId { get; set; }
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public int? TopicIndex { get; set; }

        public virtual Modules Module { get; set; }
        public virtual ICollection<Questions> Questions { get; set; }
        public virtual ICollection<Sessions> Sessions { get; set; }
        public virtual ICollection<TopicContent> TopicContent { get; set; }
    }
}
