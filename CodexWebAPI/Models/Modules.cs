using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Modules
    {
        public Modules()
        {
            Topics = new HashSet<Topics>();
        }

        public Guid ModuleId { get; set; }
        public Guid CourseId { get; set; }
        public Guid InstructorId { get; set; }
        public string ModuleTitle { get; set; }
        public Guid ModuleCategoryId { get; set; }
        public string ModuleDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public int? ModuleIndex { get; set; }

        public virtual Course Course { get; set; }
        public virtual ModuleCategories ModuleCategory { get; set; }
        public virtual ICollection<Topics> Topics { get; set; }
    }
}
