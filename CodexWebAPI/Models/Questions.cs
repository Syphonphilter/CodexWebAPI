using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Option = new HashSet<Option>();
            QuestionOption = new HashSet<QuestionOption>();
        }

        public Guid QuestionId { get; set; }
        public Guid TopicId { get; set; }
        public string Question { get; set; }
        public Guid QuestionCategoryId { get; set; }

        public virtual QuestionCategory QuestionCategory { get; set; }
        public virtual Topics Topic { get; set; }
        public virtual ICollection<Option> Option { get; set; }
        public virtual ICollection<QuestionOption> QuestionOption { get; set; }
    }
}
