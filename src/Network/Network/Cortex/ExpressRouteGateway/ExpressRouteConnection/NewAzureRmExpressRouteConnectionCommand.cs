// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSExpressRouteConnection))]
    public class NewAzureRmExpressRouteConnectionCommand : ExpressRouteConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteGatewayName { get; set; }

        [Alias("ExpressRouteGateway")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayObject,
            HelpMessage = "The parent ExpressRouteGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteGateway ExpressRouteGatewayObject { get; set; }

        [Alias("ExpressRouteGatewayId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayResourceId,
            HelpMessage = "The resource id of the parent ExpressRouteGateway for this connection.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/expressRouteGateways")]
        public string ParentResourceId { get; set; }

        [Alias("ResourceName", "ExpressRouteConnectionName")]
        [Parameter(
        Mandatory = true,
        HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource id of the Express Route Circuit Peering to which this Express Route gateway connection is to be created to.")]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteCircuitPeeringId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The authorization key to be used to create the ExpressRoute gateway connection.")]
        [ValidateNotNullOrEmpty]
        public string AuthorizationKey { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Routing Weight for the connection.")]
        public uint RoutingWeight { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Enable internet security for this ExpressRoute Gateway connection")]
        public SwitchParameter EnableInternetSecurity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            WriteObject(this.CreateExpressRouteConnection());
        }

        private PSExpressRouteConnection CreateExpressRouteConnection()
        {
            base.Execute();
            PSExpressRouteGateway expressRouteGateway = null;

            //// Resolve the ExpressRouteGateway
            if (ParameterSetName.Contains(CortexParameterSetNames.ByExpressRouteGatewayObject))
            {
                this.ResourceGroupName = this.ExpressRouteGatewayObject.ResourceGroupName;
                this.ExpressRouteGatewayName = this.ExpressRouteGatewayObject.Name;
            }
            else if (ParameterSetName.Contains(CortexParameterSetNames.ByExpressRouteGatewayResourceId))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ExpressRouteGatewayName = parsedResourceId.ResourceName;
            }

            if (string.IsNullOrWhiteSpace(this.ResourceGroupName) || string.IsNullOrWhiteSpace(this.ExpressRouteGatewayName))
            {
                throw new PSArgumentException(Properties.Resources.ExpressRouteGatewayRequiredToCreateExpressRouteConnection);
            }

            if (this.IsExpressRouteConnectionPresent(this.ResourceGroupName, this.ExpressRouteGatewayName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ChildResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName, this.ExpressRouteGatewayName));
            }

            //// At this point, we should have the resource name and the resource group for the parent ExpressRouteGateway resolved.
            //// This will throw not found exception if the ExpressRouteGateway does not exist
            expressRouteGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.ExpressRouteGatewayName);
            if (expressRouteGateway == null)
            {
                throw new PSArgumentException(Properties.Resources.ParentExpressRouteGatewayNotFound);
            }

            var peeringResourceId = new PSExpressRouteCircuitPeeringId() { Id = this.ExpressRouteCircuitPeeringId };

            PSExpressRouteConnection expressRouteConnection = new PSExpressRouteConnection
            {
                Name = this.Name,
                ExpressRouteCircuitPeering = peeringResourceId,
                EnableInternetSecurity = this.EnableInternetSecurity.IsPresent
            };

            // Set the auth key, if specified
            if (!string.IsNullOrWhiteSpace(this.AuthorizationKey))
            {
                expressRouteConnection.AuthorizationKey = this.AuthorizationKey;
            }

            // Set routing weight, if specified
            if (this.RoutingWeight > 0)
            {
                expressRouteConnection.RoutingWeight = this.RoutingWeight;
            }

            WriteVerbose(string.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));

            PSExpressRouteConnection connectionToReturn = null;

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    this.CreateOrUpdateExpressRouteConnection(this.ResourceGroupName, this.ExpressRouteGatewayName, expressRouteConnection, expressRouteGateway.Tag);

                    var createdOrUpdatedExpressRouteGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.ExpressRouteGatewayName);
                    connectionToReturn = createdOrUpdatedExpressRouteGateway.ExpressRouteConnections.FirstOrDefault(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
                });

            return connectionToReturn;
        }
    }
}
