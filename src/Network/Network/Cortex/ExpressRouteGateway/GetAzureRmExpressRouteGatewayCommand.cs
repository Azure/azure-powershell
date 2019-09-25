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
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Network.Models;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteGateway",
        DefaultParameterSetName = "ListBySubscriptionId"),
        OutputType(typeof(PSExpressRouteGateway))]
    public class GetAzureRmExpressRouteGatewayCommand : ExpressRouteGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListByResourceGroupName",
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "ExpressRouteGatewayName")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = "ListByResourceGroupName",
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public string Name { get; set; }

        [Alias("expressRouteGatewayId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the expressRouteGateway to be deleted.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/expressRouteGateways")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ShouldGetByName(ResourceGroupName, Name))
            {
                var expressRouteGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.Name);
                WriteObject(expressRouteGateway);
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
                var expressRouteGateway = this.GetExpressRouteGateway(this.ResourceGroupName, this.Name);
                WriteObject(expressRouteGateway);
            }
            else
            {
                //// ResourceName has not been specified - List all gateways
                WriteObject(TopLevelWildcardFilter(ResourceGroupName, Name, this.ListExpressRouteGateways(this.ResourceGroupName)), true);
            }
        }
    }
}
