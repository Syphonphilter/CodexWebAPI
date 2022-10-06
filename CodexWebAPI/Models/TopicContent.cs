﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class TopicContent
    {
        public Guid ContentId { get; set; }
        public Guid TopicId { get; set; }
        public string TopicContent1 { get; set; }
        public int TopicContentIndex { get; set; }
        public Guid? MediaId { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? DeletedBy { get; set; }

        public virtual Media Media { get; set; }
        public virtual Topics Topic { get; set; }
    }
}
