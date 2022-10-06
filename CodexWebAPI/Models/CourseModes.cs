using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class CourseModes
    {
        public CourseModes()
        {
            Course = new HashSet<Course>();
        }

        public Guid CourseModeId { get; set; }
        public string CourseMode { get; set; }

        public virtual ICollection<Course> Course { get; set; }
    }
}
