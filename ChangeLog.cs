﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GitHubBugReportDateSet
{
    public class ChangeLog
    {
        [DataMember(Name = "histories")]
        public List<History> histories { get; set; }
    }
}