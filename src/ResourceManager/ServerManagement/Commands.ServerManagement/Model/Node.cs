using System.Management.Automation;
using Microsoft.Azure.Commands.ServerManagement.Utility;
using Microsoft.Azure.Management.ServerManagement.Models;

namespace Microsoft.Azure.Commands.ServerManagement.Model
{
    public class Node : NodeResource
    {
        public string ResourceGroupName { get; set; }

        public string GatewayName { get; set; }

        internal PSCredential Credential { get; set;  }

        public Node(NodeResource resource)
        {
            // copy data from API object.
            resource.CloneInto(this);

            GatewayName = GatewayId.FromResourceId("gateways");
            ResourceGroupName = Id.FromResourceId("resourcegroups");
        }
    }
}