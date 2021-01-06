// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Network
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.Azure.Management.Network.Models;

    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkGatewayConnectionIkeSa", DefaultParameterSetName = "ByName"), OutputType(typeof(PSVirtualNetworkGatewayConnectionIkeSa))]
    public class GetAzVirtualNetworkGatewayConnectionIkeSaCommand : VirtualNetworkGatewayConnectionBaseCmdlet
    {
        [Alias("ResourceName", "ConnectionName")]
        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The virtual network gateway connection name for which IKE SAs needs to be fetched.")]
        [ResourceNameCompleter("Microsoft.Network/connections", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            ParameterSetName = "ByName",
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "ByInputObject",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual network gateway connection object for which IKE SAs needs to be fetched.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualNetworkGatewayConnection InputObject { get; set; }

        [Parameter(
            ParameterSetName = "ByResourceId",
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID of the Virtual Network Gateway Connection for which IKE SAs needs to be fetched.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals("ByInputObject"))
            {
                this.ResourceGroupName = this.InputObject.ResourceGroupName;
                this.Name = this.InputObject.Name;
            }
            else
            {
                if (ParameterSetName.Equals("ByResourceId"))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    Name = parsedResourceId.ResourceName;
                    ResourceGroupName = parsedResourceId.ResourceGroupName;
                }
            }

            base.Execute();

            if(this.IsVirtualNetworkGatewayConnectionPresent(this.ResourceGroupName, this.Name))
            {
                var result = this.GetVirtualNetworkGatewayConnectionIkeSa(this.ResourceGroupName, this.Name);
                WriteObject(result.ikesas, true);

            }
            else
            {
                throw new PSArgumentException(Properties.Resources.ResourceNotFound, this.Name);
            }
        }
    }
}
