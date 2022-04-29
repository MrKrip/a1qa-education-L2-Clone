﻿using System;

namespace DBTests.Models
{
    public class BrowserCountTestModel : IEquatable<BrowserCountTestModel?>
    {
        public int Brosers { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BrowserCountTestModel);
        }

        public bool Equals(BrowserCountTestModel? other)
        {
            return other != null &&
                   Brosers == other.Brosers;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Brosers);
        }
    }
}
