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
    using System.Linq;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteGateway",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSExpressRouteGateway))]
    public class NewAzureRmExpressRouteGatewayCommand : ExpressRouteGatewayBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "ExpressRouteGatewayName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Min scale units for this ExpressRouteGateway.")]
        [ValidateRange(2, 100)]
        public uint MinScaleUnits { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Max scale units for this ExpressRouteGateway.")]
        [ValidateRange(2, 100)]
        public uint MaxScaleUnits { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The VirtualHub this ExpressRouteGateway needs to be associated with.")]
        public PSVirtualHub VirtualHub { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The Id of the VirtualHub this ExpressRouteGateway needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The Id of the VirtualHub this ExpressRouteGateway needs to be associated with.")]
        public string VirtualHubName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsExpressRouteGatewayPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            var expressRouteGateway = new PSExpressRouteGateway();
            string virtualHubResourceGroupName = this.ResourceGroupName; // default to common RG for ByVirtualHubName parameter set
            expressRouteGateway.Name = this.Name;
            expressRouteGateway.ResourceGroupName = this.ResourceGroupName;
            expressRouteGateway.VirtualHub = null;

            //// Resolve and Set the virtual hub
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                this.VirtualHubName = this.VirtualHub.Name;
                virtualHubResourceGroupName = this.VirtualHub.ResourceGroupName;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedResourceId = new ResourceIdentifier(this.VirtualHubId);
                this.VirtualHubName = parsedResourceId.ResourceName;
                virtualHubResourceGroupName = parsedResourceId.ResourceGroupName;
            }

            //// At this point, we should have the virtual hub name resolved. Fail this operation if it is not.
            if (string.IsNullOrWhiteSpace(this.VirtualHubName))
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubRequiredForExpressRouteGateway);
            }

            var resolvedVirtualHub = new VirtualHubBaseCmdlet().GetVirtualHub(virtualHubResourceGroupName, this.VirtualHubName);
            if(resolvedVirtualHub == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubRequiredForExpressRouteGateway);
            }

            expressRouteGateway.Location = resolvedVirtualHub.Location;
            expressRouteGateway.VirtualHub = new PSVirtualHubId() { Id = resolvedVirtualHub.Id };

            if (this.MaxScaleUnits > 0 && this.MinScaleUnits > this.MaxScaleUnits)
            {
                throw new PSArgumentException(string.Format(Properties.Resources.InvalidAutoScaleConfiguration, this.MinScaleUnits, this.MaxScaleUnits));
            }

            expressRouteGateway.AutoScaleConfiguration = new PSExpressRouteGatewayAutoscaleConfiguration();
            expressRouteGateway.AutoScaleConfiguration.Bounds = new PSExpressRouteGatewayPropertiesAutoScaleConfigurationBounds();
            expressRouteGateway.AutoScaleConfiguration.Bounds.Min = Convert.ToInt32(this.MinScaleUnits);
            expressRouteGateway.AutoScaleConfiguration.Bounds.Max = (this.MaxScaleUnits > 0) ? Convert.ToInt32(this.MaxScaleUnits) : Convert.ToInt32(this.MinScaleUnits);

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateOrUpdateExpressRouteGateway(this.ResourceGroupName, this.Name, expressRouteGateway, this.Tag));
                });
        }
    }
}
