using Azure.Analytics.Synapse.Artifacts.Models;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSUserProperty
    {
        public PSUserProperty(UserProperty userProperty)
        {
            this.Name = userProperty?.Name;
            this.Value = userProperty?.Value;
        }

        public string Name { get; set; }
        
        public object Value { get; set; }

        public UserProperty ToSdkObject()
        {
            return new UserProperty(this.Name, this.Value);
        }
    }
}
