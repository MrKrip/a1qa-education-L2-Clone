using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTests.Models
{
    public class DateConditionModel : IEquatable<DateConditionModel?>
    {
        public string Project { get; set; } = null!;
        public string Test { get; set; } = null!;
        public DateTime Date { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as DateConditionModel);
        }

        public bool Equals(DateConditionModel? other)
        {
            return other != null &&
                   Project == other.Project &&
                   Test == other.Test &&
                   Date == other.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Project, Test, Date);
        }
    }
}
