using System;

namespace DBTests.Models
{
    public class NumberOfUniqueTests : IEquatable<NumberOfUniqueTests?>
    {
        public string Project { get; set; } = null!;
        public int TestsCount { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as NumberOfUniqueTests);
        }

        public bool Equals(NumberOfUniqueTests? other)
        {
            return other != null &&
                   Project == other.Project &&
                   TestsCount == other.TestsCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Project, TestsCount);
        }
    }
}
