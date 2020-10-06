using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JiraIssuesDataSet
{
    [DataContract(Name = "response")]
    public class Response
    {
        [DataMember(Name = "issues")]
        public List<Issues> issues{ get; set; }

        [DataMember(Name = "total")]
        public int total { get; set; }
    }

    public class CommentResponse
    {
        [DataMember(Name = "comments")]
        public List<Comment> comments { get; set; }
    }
}
