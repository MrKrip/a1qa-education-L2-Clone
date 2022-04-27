using Aquality.Selenium.Browsers;
using REST_API_GET_POST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST_API_GET_POST.Utils
{
    public static class CompareUtil
    {

        public static bool IsListsOfPostsAreEqual(List<PostModel> list1, List<PostModel> list2)
        {
            AqualityServices.Logger.Info($"Comparison of two lists of posts");
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

        public static bool IsListOfPostsAreSorted(List<PostModel> list1)
        {
            AqualityServices.Logger.Info($"Checking if the list of posts is sorted");
            for (int i = 0; i < list1.Count - 1; i++)
            {
                if (list1[i].id > list1[i + 1].id)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsUserConsistInList(List<UserModel> users, UserModel user)
        {
            AqualityServices.Logger.Info($"Checking if the user is in the list");
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Equals(user))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
