using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class DevInfo
    {
        public long Id { get; set; }
        /// <summary>
        /// Test development time
        /// </summary>
        public double? DevTime { get; set; }
        /// <summary>
        /// Test ID (test.id)
        /// </summary>
        public long TestId { get; set; }

        public virtual Test Test { get; set; } = null!;
    }
}
