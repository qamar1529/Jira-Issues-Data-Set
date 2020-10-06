using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraIssuesDataSet
{
    [DataContract(Name = "issues")]
    public class Issues
    {

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "fields")]
        public Fields fields { get; set; }

        [DataMember(Name = "changelog")]
        public ChangeLog changelog { get; set; }
    }
}
