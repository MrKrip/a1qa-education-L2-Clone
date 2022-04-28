using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class FailReason
    {
        public FailReason()
        {
            RelFailReasonTests = new HashSet<RelFailReasonTest>();
        }

        public long Id { get; set; }
        /// <summary>
        /// Fail reason name (1000 symbols)
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Is current reason global for all projects?
        /// </summary>
        public bool IsGlobal { get; set; }
        /// <summary>
        /// Is current reason cant be deleted?
        /// </summary>
        public bool IsUnremovable { get; set; }
        /// <summary>
        /// Is current reason cant be changed to other reason?
        /// </summary>
        public bool IsUnchangeable { get; set; }
        /// <summary>
        /// Is current reason will be ignored in statistic count?
        /// </summary>
        public bool IsStatsIgnored { get; set; }
        /// <summary>
        /// Is current reason available for session?
        /// </summary>
        public bool IsSession { get; set; }
        /// <summary>
        /// Is current reason available for test?
        /// </summary>
        public bool IsTest { get; set; }

        public virtual ICollection<RelFailReasonTest> RelFailReasonTests { get; set; }
    }
}
