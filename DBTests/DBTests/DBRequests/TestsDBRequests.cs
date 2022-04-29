using DBTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
