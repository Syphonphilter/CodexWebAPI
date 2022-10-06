using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class AuditLogger
    {
        public Guid Id { get; set; }
        public string MetaData { get; set; }
        public Guid SessionId { get; set; }

        public virtual Sessions Session { get; set; }
    }
}
