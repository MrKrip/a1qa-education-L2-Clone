using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Session
    {
        public Session()
        {
            Tests = new HashSet<Test>();
        }

        public long Id { get; set; }
        /// <summary>
        /// Session key of current test running
        /// </summary>
        public string SessionKey { get; set; } = null!;
        /// <summary>
        /// Test start time
        /// </summary>
        public DateTime CreatedTime { get; set; }
        /// <summary>
        /// Build number
        /// </summary>
        public long BuildNumber { get; set; }

        public virtual ICollection<Test> Tests { get; set; }
    }
}
