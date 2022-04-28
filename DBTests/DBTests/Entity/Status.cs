using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Status
    {
        public Status()
        {
            Tests = new HashSet<Test>();
        }

        public int Id { get; set; }
        /// <summary>
        /// Status name (255 symbols)
        /// </summary>
        public string Name { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }
    }
}
