using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.WebApps.Models
{
    public class PSAccessRestriction
    {
        public string RuleName { get; set; }

        public string Description { get; set; }

        public string Action { get; set; }

        public int Priority { get; set; }

        public string IpAddress { get; set; }

        public string SubnetId { get; set; }

        public string Tag { get; set; }

        public Hashtable HttpHeader { get; set; }
    }
}
