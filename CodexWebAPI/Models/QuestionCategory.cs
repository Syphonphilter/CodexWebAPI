using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class QuestionCategory
    {
        public QuestionCategory()
        {
            Questions = new HashSet<Questions>();
        }

        public Guid QuestionCategoryId { get; set; }
        public string QuesitonCategory { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
