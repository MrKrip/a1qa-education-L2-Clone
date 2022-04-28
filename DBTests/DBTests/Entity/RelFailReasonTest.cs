using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class RelFailReasonTest
    {
        public long Id { get; set; }
        /// <summary>
        /// Fail reason ID (fail_reason.id)
        /// </summary>
        public long FailReasonId { get; set; }
        /// <summary>
        /// Test ID (test.id)
        /// </summary>
        public long TestId { get; set; }
        /// <summary>
        /// Fail reason comment (10000 symbols)
        /// </summary>
        public string? Comment { get; set; }

        public virtual FailReason FailReason { get; set; } = null!;
        public virtual Test Test { get; set; } = null!;
    }
}
