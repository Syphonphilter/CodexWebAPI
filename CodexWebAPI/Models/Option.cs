using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class Option
    {
        public Option()
        {
            QuestionOption = new HashSet<QuestionOption>();
            UserAnswers = new HashSet<UserAnswers>();
        }

        public Guid OptionId { get; set; }
        public Guid QuesitonId { get; set; }
        public string Option1 { get; set; }

        public virtual Questions Quesiton { get; set; }
        public virtual ICollection<QuestionOption> QuestionOption { get; set; }
        public virtual ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
