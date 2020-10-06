using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraIssuesDataSet
{
    public class History
    {
        [DataMember(Name = "created")]
        public string created { get; set; }

        [DataMember(Name = "author")]
        public User author { get; set; }

        [DataMember(Name = "items")]
        public List<HistoryItem> items { get; set; }
    }
}
