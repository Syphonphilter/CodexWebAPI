using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class UserScores
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public int Score { get; set; }
        public DateTime DateTaken { get; set; }

        public virtual Sessions Session { get; set; }
    }
}
