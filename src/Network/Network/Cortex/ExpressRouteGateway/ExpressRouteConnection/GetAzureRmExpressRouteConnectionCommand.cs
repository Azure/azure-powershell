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

    [Cmdlet(VerbsCommon.Get,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteConnection",
        DefaultParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName),
        OutputType(typeof(PSExpressRouteConnection))]
    public class GetAzureRmExpressRouteConnectionCommand : ExpressRouteConnectionBaseCmdlet
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
            HelpMessage = "The parent resource name.")]
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
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                this.ResourceGroupName = this.ExpressRouteGatewayObject.ResourceGroupName;
                this.ExpressRouteGatewayName = this.ExpressRouteGatewayObject.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.ParentResourceId);
                this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                this.ExpressRouteGatewayName = parsedResourceId.ResourceName;
            }

            if (!string.IsNullOrWhiteSpace(this.Name) && !WildcardPattern.ContainsWildcardCharacters(Name))
            {
                WriteObject(this.GetExpressRouteConnection(this.ResourceGroupName, this.ExpressRouteGatewayName, this.Name));
            }
            else
            {
                WriteObject(SubResourceWildcardFilter(Name, this.ListExpressRouteConnections(this.ResourceGroupName, this.ExpressRouteGatewayName)), true);
            }
        }
    }
}
