using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class UserAnswers
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid OptionId { get; set; }

        public virtual Option Option { get; set; }
        public virtual Users User { get; set; }
    }
}
