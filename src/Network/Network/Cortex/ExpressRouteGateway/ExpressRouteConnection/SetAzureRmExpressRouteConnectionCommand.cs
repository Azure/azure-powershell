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

namespace Microsoft.Azure.Commands.Network.Cortex.ExpressRouteGateway
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Set,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSExpressRouteConnection))]
    public class UpdateAzureRmExpressRouteConnectionCommand : ExpressRouteConnectionBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
            Mandatory = true,
            HelpMessage = "The parent resource name.")]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteGatewayName { get; set; }

        [Alias("ResourceName", "ExpressRouteConnectionName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ExpressRouteConnectionId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionResourceId,
            HelpMessage = "The resource id of the ExpressRouteConnection object to update.")]
        public string ResourceId { get; set; }

        [Alias("ExpressRouteConnection")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionObject,
            HelpMessage = "The ExpressRouteConnection object to update.")]
        public PSExpressRouteConnection InputObject { get; set; }

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
            HelpMessage = "Enable internet security for this connection")]
        public bool? EnableInternetSecurity { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteConnectionName, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ResourceGroupName;
                this.ExpressRouteGatewayName = this.ExpressRouteGatewayName;
                this.Name = this.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceId = this.InputObject.Id;

                this.SetResourceNames();
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteConnectionResourceId, StringComparison.OrdinalIgnoreCase))
            {
                this.SetResourceNames();
            }

            //// Get the expressRoutegateway object - this will throw not found if the object is not found
            PSExpressRouteGateway expressRouteGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.ExpressRouteGatewayName);

            if (expressRouteGateway == null || 
                expressRouteGateway.ExpressRouteConnections == null ||
                !expressRouteGateway.ExpressRouteConnections.Any(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.ExpressRouteConnectionNotFound);
            }

            var expressRouteConnectionToModify = expressRouteGateway.ExpressRouteConnections.FirstOrDefault(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
            if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteConnectionObject, StringComparison.OrdinalIgnoreCase))
            {
                expressRouteConnectionToModify = this.InputObject;
            }

            // Set the auth key, if specified
            if (!string.IsNullOrWhiteSpace(this.AuthorizationKey))
            {
                expressRouteConnectionToModify.AuthorizationKey = this.AuthorizationKey;
            }

            // Set routing weight, if specified
            if (this.RoutingWeight > 0)
            {
                expressRouteConnectionToModify.RoutingWeight = this.RoutingWeight;
            }

            if (this.EnableInternetSecurity.HasValue)
            {
                expressRouteConnectionToModify.EnableInternetSecurity = this.EnableInternetSecurity.Value;
            }

            // TODO: drop this hack after ER Gateways backend updated with all the functionality exposed
            if (expressRouteGateway.AutoScaleConfiguration.Bounds.Max < expressRouteGateway.AutoScaleConfiguration.Bounds.Min)
            {
                expressRouteGateway.AutoScaleConfiguration.Bounds.Max = expressRouteGateway.AutoScaleConfiguration.Bounds.Min;
            }

            WriteVerbose(string.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    this.CreateOrUpdateExpressRouteConnection(this.ResourceGroupName, this.ExpressRouteGatewayName, expressRouteConnectionToModify, expressRouteGateway.Tag);
                });
        }

        private void SetResourceNames()
        {
            if (string.IsNullOrWhiteSpace(this.ResourceId))
            {
                throw new PSArgumentException(Properties.Resources.ExpressRouteConnectionNotFound, this.ResourceId);
            }

            var parsedResourceId = new ResourceIdentifier(this.ResourceId);
            this.ResourceGroupName = parsedResourceId.ResourceGroupName;
            this.ExpressRouteGatewayName = parsedResourceId.ParentResource.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();
            this.Name = parsedResourceId.ResourceName;
        }
    }
}
