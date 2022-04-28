using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Project
    {
        public Project()
        {
            Tests = new HashSet<Test>();
        }

        public long Id { get; set; }
        /// <summary>
        /// Project name (1000 symbols)
        /// </summary>
        public string Name { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }
    }
}
