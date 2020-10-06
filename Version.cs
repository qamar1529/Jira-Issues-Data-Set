using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubBugReportDateSet
{
    public class Version
    {
        public string self { get; set; }
        public string name { get; set; }
        public bool archived { get; set; }
        public bool released { get; set; }
        public string releaseDate { get; set; }
        public string userReleaseDate { get; set; }

    }
}
