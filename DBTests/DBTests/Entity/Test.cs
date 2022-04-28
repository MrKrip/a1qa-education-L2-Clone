using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Test
    {
        public Test()
        {
            Attachments = new HashSet<Attachment>();
            DevInfos = new HashSet<DevInfo>();
            Logs = new HashSet<Log>();
            RelFailReasonTests = new HashSet<RelFailReasonTest>();
        }

        public long Id { get; set; }
        /// <summary>
        /// Test name (10000 symbols)
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Test execution status (status.id)
        /// </summary>
        public int? StatusId { get; set; }
        /// <summary>
        /// Test method name (10000 symbols)
        /// </summary>
        public string MethodName { get; set; } = null!;
        /// <summary>
        /// Project ID (project.id)
        /// </summary>
        public long ProjectId { get; set; }
        /// <summary>
        /// ID of current test execution session (session.id)
        /// </summary>
        public long SessionId { get; set; }
        /// <summary>
        /// Test start time
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Test end time
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// Node name where tests are executed (255 symbols)
        /// </summary>
        public string Env { get; set; } = null!;
        /// <summary>
        /// Browser used for tests execution (255 symbols)
        /// </summary>
        public string? Browser { get; set; }
        /// <summary>
        /// Author info ID (author.id)
        /// </summary>
        public long? AuthorId { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Project Project { get; set; } = null!;
        public virtual Session Session { get; set; } = null!;
        public virtual Status? Status { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public virtual ICollection<DevInfo> DevInfos { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<RelFailReasonTest> RelFailReasonTests { get; set; }
    }
}
