using DBTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBTests.DBRequests
{
    public class TestsDBRequests
    {
        public List<MinTimeTestModel> GetMinWorkingTime()
        {
            using (union_reportingContext db = new union_reportingContext())
            {

                var MinTime = db.Tests.ToList().SkipWhile(T => T.EndTime == null || T.StartTime == null)
                    .Join(db.Projects.ToList()
                    , T => T.ProjectId
                    , P => P.Id
                    , (T, P) => new MinTimeTestModel
                    {
                        Project = P.Name,
                        Test = T.Name,
                        MinTime = T.EndTime.GetValueOrDefault().Subtract(T.StartTime.GetValueOrDefault())
                    }
                    )
                    .GroupBy(M => new { Test = M.Test, Project = M.Project })
                    .Select(M => new MinTimeTestModel { Project = M.Key.Project, Test = M.Key.Test, MinTime = M.Min(t => t.MinTime) })
                    .OrderBy(M => M.Project)
                    .ThenBy(M => M.Test).ToList();
                return MinTime;
            }
        }

        public List<NumberOfUniqueTests> GetNumberOfUniqueTests()
        {
            using (union_reportingContext db = new union_reportingContext())
            {
                var TestsCount = db.Tests.ToList()
                    .GroupBy(T => new { Test = T.Name, Project = T.ProjectId })
                    .Select(X => X.FirstOrDefault())
                    .Join(db.Projects.ToList()
                    , T => T.ProjectId
                    , P => P.Id
                    , (T, P) => new { Project = P.Name, TestName = T.Name })
                    .GroupBy(P => P.Project)
                    .Select(TC => new NumberOfUniqueTests { Project = TC.Key, TestsCount = TC.Count() });
                return TestsCount.ToList();
            }
        }

        public List<DateConditionModel> GetDateConditionTests()
        {
            using (union_reportingContext db = new union_reportingContext())
            {
                var DateCondTests = db.Tests.ToList()
                    .Where(T => T.StartTime > new DateTime(2015, 11, 7))
                    .Join(db.Projects.ToList()
                    , T => T.ProjectId
                    , P => P.Id
                    , (T, P) => new DateConditionModel { Project = P.Name, Test = T.Name, Date = T.StartTime.GetValueOrDefault() })
                    .OrderBy(D => D.Project)
                    .ThenBy(D => D.Test);
                return DateCondTests.ToList();
            }
        }

        public List<BrowserCountTestModel> GetBrowserCountTests()
        {
            using (union_reportingContext db = new union_reportingContext())
            {
                var BrowserCountTests = db.Tests.ToList()
                    .Select(T => new BrowserCountTestModel
                    {
                        Brosers = db.Tests.ToList()
                    .Where(T => T.Browser == "chrome").Count()
                    })
                    .Union(db.Tests.ToList()
                    .Select(T => new BrowserCountTestModel
                    {
                        Brosers = db.Tests.ToList()
                    .Where(T => T.Browser == "firefox").Count()
                    }));
                return BrowserCountTests.ToList();
            }
        }
    }
}
