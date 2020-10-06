using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraIssuesDataSet
{
    public class HistoryItem
    {
        [DataMember(Name = "field")]
        public string field { get; set; }

        [DataMember(Name = "from")]
        public string from { get; set; }

        [DataMember(Name = "fromString")]
        public string fromString { get; set; }

        [DataMember(Name = "to")]
        public string to { get; set; }

        [DataMember(Name = "toString")]
        public string toString { get; set; }
    }
}
