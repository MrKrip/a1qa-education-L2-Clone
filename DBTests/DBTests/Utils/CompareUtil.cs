using Aquality.Selenium.Browsers;
using System.Collections.Generic;

namespace DBTests.Utils
{
    public static class CompareUtil
    {
        public static bool IsListsAreEqual<T>(List<T> list1,List<T> list2)
        {
            AqualityServices.Logger.Info($"Comparison of two lists {list1.GetType()}");
            if (list1.Count != list2.Count)
                return false;

            for (int i = 0; i < list1.Count; i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
