using Microsoft.Azure.Commands.ServerManagement.Utility;
using Microsoft.Azure.Management.ServerManagement.Models;

namespace Microsoft.Azure.Commands.ServerManagement.Model
{
    public class Gateway : GatewayResource
    {
        public Gateway(GatewayResource resource)
        {
            // copy data from API object.
            resource.CloneInto(this);

            ResourceGroupName = Id.FromResourceId("resourcegroups");
        }

        public string ResourceGroupName { get; set; }
    }
}