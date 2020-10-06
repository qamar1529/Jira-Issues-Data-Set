using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GitHubBugReportDateSet
{
    [DataContract(Name = "fields")]
    public class Fields
    {
        public Fields()
        {
            assignee = new User();
            resolution = new Resolution();
            status = new Status();
            versions = new List<Version>();
            fixVersions = new List<Version>();
            components = new List<Component>();
            issueType = new IssueType();
            project = new Project();
        }

        [DataMember(Name = "assignee")]
        public User assignee { get; set; }

        [DataMember(Name = "reporter")]
        public User reporter { get; set; }

        [DataMember(Name = "creator")]
        public User creator { get; set; }

        [DataMember(Name = "resolution")]
        public Resolution resolution { get; set; }

        [DataMember(Name = "labels")]
        public List<string> labels { get; set; }

        [DataMember(Name = "priority")]
        public Priority priority { get; set; }

        [DataMember(Name = "created")]
        public string created { get; set; }

        [DataMember(Name = "updated")]
        public string updated { get; set; }

        [DataMember(Name = "status")]
        public Status status { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "duedate")]
        public string duedate { get; set; }

        [DataMember(Name = "versions")]
        public List<Version> versions { get; set; }

        [DataMember(Name = "fixVersions")]
        public List<Version> fixVersions { get; set; }

        [DataMember(Name = "components")]
        public List<Component> components { get; set; }

        [DataMember(Name = "summary")]
        public string summary { get; set; }

        [DataMember(Name = "environment")]
        public string environment { get; set; }

        [DataMember(Name = "issueType")]
        public IssueType issueType { get; set; }

        [DataMember(Name = "project")]
        public Project project { get; set; }

        [DataMember(Name = "resolutiondate")]
        public string resolutiondate { get; set; }

        private List<string> _participants;
        [DataMember(Name = "customfield_10150")]
        public List<string> customfield_10150
        {
            get
            {
                return _participants;
            }
            set
            {
                _participants = value;
                participants = value;
            }
        }

        [DataMember(Name = "participants")]
        public List<string> participants { get; set; }

        [DataMember(Name = "commentResponse")]
        public CommentResponse commentResponse { get; set; }

        [DataMember(Name = "comments")]
        public List<Comment> comments { get; set; }
    }
}
