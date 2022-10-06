using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class UserCourse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public Guid? IssuesBy { get; set; }
        public Guid CourseId { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public Guid? CertificateId { get; set; }

        public virtual Certificates Certificate { get; set; }
        public virtual Course Course { get; set; }
        public virtual Users User { get; set; }
    }
}
