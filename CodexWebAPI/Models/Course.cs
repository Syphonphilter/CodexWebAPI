using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            CoursePrices = new HashSet<CoursePrices>();
            Modules = new HashSet<Modules>();
            UserCart = new HashSet<UserCart>();
            UserCourse = new HashSet<UserCourse>();
        }

        public Guid CourseId { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTitle { get; set; }
        public Guid CourseModeId { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? DeletedBy { get; set; }

        public virtual CourseModes CourseMode { get; set; }
        public virtual ICollection<CoursePrices> CoursePrices { get; set; }
        public virtual ICollection<Modules> Modules { get; set; }
        public virtual ICollection<UserCart> UserCart { get; set; }
        public virtual ICollection<UserCourse> UserCourse { get; set; }
    }
}
