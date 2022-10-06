using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class QuestionOption
    {
        public Guid QuesitonOptionId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid OptionId { get; set; }

        public virtual Option Option { get; set; }
        public virtual Questions Question { get; set; }
    }
}
