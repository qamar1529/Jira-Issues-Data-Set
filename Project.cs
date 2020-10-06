using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubBugReportDateSet
{
    public class Project
    {
        public Project()
        {
            projectCategory = new ProjectCategory();
        }
        public string self { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public string description { get; set; }
        public ProjectCategory projectCategory { get; set; }
    }
}
