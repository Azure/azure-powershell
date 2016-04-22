using Microsoft.Azure.Commands.ServerManagement.Utility;
using Microsoft.Azure.Management.ServerManagement.Models;

namespace Microsoft.Azure.Commands.ServerManagement.Model
{
    public class Session : SessionResource
    {
        public string ResourceGroupName { get; set; }

        public string NodeName { get; set; }

        internal string LastPowerShellSessionName { get; set; }

        public Session(SessionResource resource)
        {
            // copy data from API object.
            resource.CloneInto(this);

            ResourceGroupName = Id.FromResourceId("resourcegroups");
            
            NodeName = Id.FromResourceId("nodes");
        }
    }
}