using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraIssuesDataSet
{
    public class Component
    {
        public string self { get; set; }
        public string name { get; set; }
        public string project { get; set; }
        public bool archived { get; set; }
        public Lead lead { get; set; }
    }
}
