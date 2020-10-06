using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraIssuesDataSet
{
    public class Comment
    {
        [DataMember(Name = "author")]
        public User author { get; set; }

        [DataMember(Name = "body")]
        public string body { get; set; }

        [DataMember(Name = "updateAuthor")]
        public User updateAuthor { get; set; }

        [DataMember(Name = "created")]
        public string created { get; set; }

        [DataMember(Name = "updated")]
        public string updated { get; set; }
    }
}
