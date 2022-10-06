using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CodexWebAPI.Models
{
    public partial class ModuleCategories
    {
        public ModuleCategories()
        {
            Modules = new HashSet<Modules>();
        }

        public Guid ModuleCategoryId { get; set; }
        public string ModuleCategory { get; set; }

        public virtual ICollection<Modules> Modules { get; set; }
    }
}
