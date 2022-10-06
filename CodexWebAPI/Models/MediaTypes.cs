using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class MediaTypes
    {
        public MediaTypes()
        {
            Media = new HashSet<Media>();
        }

        public Guid MediaTypeId { get; set; }
        public string MediaType { get; set; }

        public virtual ICollection<Media> Media { get; set; }
    }
}
