using System;
using System.Collections.Generic;

namespace DBTests
{
    public partial class Variant
    {
        public Variant()
        {
            Tokens = new HashSet<Token>();
        }

        public int Id { get; set; }
        public bool IsDynamicVersionInFooter { get; set; }
        public bool UseAjaxForTestsPage { get; set; }
        public bool UseFrameForNewProject { get; set; }
        public bool UseNewTabForNewProject { get; set; }
        public bool UseGeolocationForNewProject { get; set; }
        public bool UseAlertForNewProject { get; set; }
        public bool GrammarMistakeOnSaveProject { get; set; }
        public bool GrammarMistakeOnSaveTest { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
    }
}
