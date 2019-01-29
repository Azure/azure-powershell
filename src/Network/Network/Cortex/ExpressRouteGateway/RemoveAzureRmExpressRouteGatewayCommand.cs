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
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
        SupportsShouldProcess = true),
        OutputType(typeof(bool))]
    public class RemoveAzureRmExpressRouteGatewayCommand : ExpressRouteGatewayBaseCmdlet
    {
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "ExpressRouteGatewayName")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayName,
            Mandatory = true,
            HelpMessage = "The expressRouteGateway name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ExpressRouteGateway")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayObject,
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The expressRouteGateway object to be deleted.")]
        [ValidateNotNullOrEmpty]
        public PSExpressRouteGateway InputObject { get; set; }

        [Alias("expressRouteGatewayId")]
        [Parameter(
            ParameterSetName = CortexParameterSetNames.ByExpressRouteGatewayResourceId,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Azure resource ID for the expressRouteGateway to be deleted.")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Network/expressRouteGateways")]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Returns an object representing the item on which this operation is being performed.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayObject, StringComparison.OrdinalIgnoreCase))
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByExpressRouteGatewayResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(ResourceId);
                Name = parsedResourceId.ResourceName;
                ResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            base.Execute();
            
            ConfirmAction(
                    this.Force.IsPresent,
                    string.Format(Properties.Resources.RemovingExpressRouteGatewayWarning, this.Name),
                    Properties.Resources.RemoveResourceMessage,
                    this.Name,
                    () =>
                    {
                        this.ExpressRouteGatewayClient.Delete(this.ResourceGroupName, this.Name);

                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
        }
    }
}
