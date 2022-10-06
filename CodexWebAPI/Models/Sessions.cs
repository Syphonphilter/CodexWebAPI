using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Sessions
    {
        public Sessions()
        {
            AuditLogger = new HashSet<AuditLogger>();
            UserScores = new HashSet<UserScores>();
        }

        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public Guid CurrentTopicId { get; set; }
        public DateTime SessionStartTime { get; set; }

        public virtual Topics CurrentTopic { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<AuditLogger> AuditLogger { get; set; }
        public virtual ICollection<UserScores> UserScores { get; set; }
    }
}
