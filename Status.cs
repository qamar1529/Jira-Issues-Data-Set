using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubBugReportDateSet
{
    public class Status
    {
        public Status()
        {
            statusCategory = new StatusCategory();
        }
        public string name { get; set; }
        public string description { get; set; }
        public StatusCategory statusCategory { get; set; }
    }
}
