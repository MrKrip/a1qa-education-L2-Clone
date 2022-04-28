using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Author
    {
        public Author()
        {
            Tests = new HashSet<Test>();
        }

        public long Id { get; set; }
        /// <summary>
        /// Author name
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Author login
        /// </summary>
        public string Login { get; set; } = null!;
        /// <summary>
        /// Author email
        /// </summary>
        public string Email { get; set; } = null!;

        public virtual ICollection<Test> Tests { get; set; }
    }
}
