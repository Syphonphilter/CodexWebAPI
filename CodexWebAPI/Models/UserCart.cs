using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class UserCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public int Count { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateRemoved { get; set; }
        public bool IsPurchased { get; set; }

        public virtual Course Course { get; set; }
        public virtual Users User { get; set; }
    }
}
