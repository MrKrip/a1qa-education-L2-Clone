using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Log
    {
        public long Id { get; set; }
        /// <summary>
        /// Logs of current test
        /// </summary>
        public string Content { get; set; } = null!;
        /// <summary>
        /// Is current log test exception?
        /// </summary>
        public bool IsException { get; set; }
        /// <summary>
        /// Test ID (test.id)
        /// </summary>
        public long TestId { get; set; }

        public virtual Test Test { get; set; } = null!;
    }
}
