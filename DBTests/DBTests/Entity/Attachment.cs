using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Attachment
    {
        public long Id { get; set; }
        /// <summary>
        /// Content in base64
        /// </summary>
        public byte[] Content { get; set; } = null!;
        /// <summary>
        /// Content type (255 symbols)
        /// </summary>
        public string ContentType { get; set; } = null!;
        /// <summary>
        /// Test ID (test.id)
        /// </summary>
        public long TestId { get; set; }

        public virtual Test Test { get; set; } = null!;
    }
}
