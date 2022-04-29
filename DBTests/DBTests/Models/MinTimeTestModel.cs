using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTests.Models
{
    public class MinTimeTestModel : IEquatable<MinTimeTestModel?>
    {
        public string? Project { get; set; }
        public string Test { get; set; } = null!;
        public TimeSpan MinTime { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as MinTimeTestModel);
        }

        public bool Equals(MinTimeTestModel? other)
        {
            return other != null &&
                   Project == other.Project &&
                   Test == other.Test &&
                   MinTime.Equals(other.MinTime);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Project, Test, MinTime);
        }
    }
}
