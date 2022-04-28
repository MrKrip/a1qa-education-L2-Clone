using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class ApiKey
    {
        public long Id { get; set; }
        /// <summary>
        /// API key which available for writing test info
        /// </summary>
        public string Key { get; set; } = null!;
        /// <summary>
        /// Key info (external resource name project name, whatever)
        /// </summary>
        public string KeyInfo { get; set; } = null!;
    }
}
