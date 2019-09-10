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

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveExpressRouteConnectionCommand : ExpressRouteConnectionBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
            HelpMessage = "The parent resource name.")]
        [ValidateNotNullOrEmpty]
        public string ExpressRouteGatewayName { get; set; }

        [Alias("ResourceName", "ExpressRouteConnectionName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionName,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ExpressRouteConnectionId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByExpressRouteConnectionResourceId,
            HelpMessage = "The resource id of the ExpressRouteConnection object to delete.")]
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
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        public override void Execute()
        {
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
            PSExpressRouteGateway parentGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.ExpressRouteGatewayName);

            if (parentGateway == null ||
                parentGateway.ExpressRouteConnections == null ||
                !parentGateway.ExpressRouteConnections.Any(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new PSArgumentException(Properties.Resources.ExpressRouteConnectionNotFound, this.Name);
            }

            // TODO: drop this hack after ER Gateways backend updated with all the functionality exposed
            if (parentGateway.AutoScaleConfiguration.Bounds.Max < parentGateway.AutoScaleConfiguration.Bounds.Min)
            {
                parentGateway.AutoScaleConfiguration.Bounds.Max = parentGateway.AutoScaleConfiguration.Bounds.Min;
            }

            if (parentGateway.ExpressRouteConnections.Any())
            {
                var expressRouteConnectionToRemove = parentGateway.ExpressRouteConnections.FirstOrDefault(connection => connection.Name.Equals(this.Name, StringComparison.OrdinalIgnoreCase));
                if (expressRouteConnectionToRemove != null)
                {
                    base.Execute();

                    ConfirmAction(
                        Force.IsPresent,
                        string.Format(Properties.Resources.RemovingResource, this.Name),
                        Properties.Resources.RemoveResourceMessage,
                        this.Name,
                        () =>
                        {
                            parentGateway.ExpressRouteConnections.Remove(expressRouteConnectionToRemove);
                            this.CreateOrUpdateExpressRouteGateway(this.ResourceGroupName, this.ExpressRouteGatewayName, parentGateway, parentGateway.Tag);
                        });
                }
            }

            if (PassThru)
            {
                WriteObject(true);
            }
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
