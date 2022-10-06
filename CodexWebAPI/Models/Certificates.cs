using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Certificates
    {
        public Certificates()
        {
            UserCourse = new HashSet<UserCourse>();
        }

        public Guid CertificateId { get; set; }
        public Guid Certificate { get; set; }
        public string CertificateNo { get; set; }

        public virtual ICollection<UserCourse> UserCourse { get; set; }
    }
}
