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
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHub",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class NewAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualHubName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanObject,
            HelpMessage = "The virtual wan object this hub is linked to.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualWanResourceId,
            HelpMessage = "The id of virtual wan object this hub is linked to.")]
        [ResourceIdCompleter("Microsoft.Network/virtualWans")]
        public string VirtualWanId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The address space string for this virtual hub.")]
        [ValidateNotNullOrEmpty]
        public string AddressPrefix { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The location of this resource.")]
        [LocationCompleter("Microsoft.Network/virtualWans")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        public const String ChangeDesc = "HubVnetConnection parameter is deprecated. Use *VirtualHubVnetConnection* commands";
        [CmdletParameterBreakingChange("HubVnetConnection", ChangeDescription = ChangeDesc)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The hub virtual network connections associated with this Virtual Hub.")]
        public PSHubVirtualNetworkConnection[] HubVnetConnection { get; set; }

        public const String RTv1ChangeDesc = "Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.";
        [CmdletParameterBreakingChange("RouteTable", ChangeDescription = RTv1ChangeDesc)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The route table associated with this Virtual Hub.")]
        public PSVirtualHubRouteTable RouteTable { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The sku of the Virtual Hub.")]
        [PSArgumentCompleter("Basic", "Standard")]
        public string Sku { get; set; }

        public const String PreferredGWChangeDesc = "PreferredRoutingGateway parameter is deprecated. Use *HubRoutingPreference* property";
        [CmdletParameterBreakingChange("PreferredRoutingGateway", ChangeDescription = PreferredGWChangeDesc)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Preferred Routing Gateway to Route On-Prem traffic from VNET")]
        [ValidateSet(
            MNM.PreferredRoutingGateway.ExpressRoute,
            MNM.PreferredRoutingGateway.VpnGateway,
            IgnoreCase = true)]
        public string PreferredRoutingGateway { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Virtual Hub Routing Preference to route traffic")]
        [ValidateSet(
            MNM.HubRoutingPreference.ExpressRoute,
            MNM.HubRoutingPreference.VpnGateway,
            MNM.HubRoutingPreference.ASPath,
            IgnoreCase = true)]
        public string HubRoutingPreference { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            Dictionary<string, List<string>> auxAuthHeader = null;

            if (this.IsVirtualHubPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }
            
            string virtualWanRGName = null;
            string virtualWanName = null;

            //// Resolve the virtual wan
            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanObject, StringComparison.OrdinalIgnoreCase))
            {
                virtualWanRGName = this.VirtualWan.ResourceGroupName;
                virtualWanName = this.VirtualWan.Name;
            }
            else if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualWanResourceId, StringComparison.OrdinalIgnoreCase))
            {
                var parsedWanResourceId = new ResourceIdentifier(this.VirtualWanId);
                virtualWanName = parsedWanResourceId.ResourceName;
                virtualWanRGName = parsedWanResourceId.ResourceGroupName;
            }

            if (string.IsNullOrWhiteSpace(virtualWanRGName) || string.IsNullOrWhiteSpace(virtualWanName))
            {
                throw new PSArgumentException(Properties.Resources.VirtualWanReferenceNeededForVirtualHub);
            }

            PSVirtualWan resolvedVirtualWan = new VirtualWanBaseCmdlet().GetVirtualWan(virtualWanRGName, virtualWanName);

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    PSVirtualHub virtualHub = new PSVirtualHub
                    {
                        ResourceGroupName = this.ResourceGroupName,
                        Name = this.Name,
                        VirtualWan = new PSResourceId() { Id = resolvedVirtualWan.Id },
                        AddressPrefix = this.AddressPrefix,
                        Location = this.Location
                    };

                    virtualHub.RouteTable = this.RouteTable;
                    virtualHub.RouteTables = new List<PSVirtualHubRouteTable>();

                    if (this.HubVnetConnection != null)
                    {
                        virtualHub.VirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();
                        virtualHub.VirtualNetworkConnections.AddRange(this.HubVnetConnection);
                    }

                    if (string.IsNullOrWhiteSpace(this.Sku))
                    {
                        virtualHub.Sku = "Standard";
                    }

                    if (string.IsNullOrWhiteSpace(this.PreferredRoutingGateway))
                    {
                        virtualHub.PreferredRoutingGateway = "ExpressRoute";
                    }
                    else
                    {
                        virtualHub.PreferredRoutingGateway = this.PreferredRoutingGateway;
                    }

                    if (string.IsNullOrWhiteSpace(this.HubRoutingPreference))
                    {
                        virtualHub.HubRoutingPreference = "ExpressRoute";
                    }
                    else
                    {
                        virtualHub.HubRoutingPreference = this.HubRoutingPreference;
                    }

                    WriteObject(CreateOrUpdateVirtualHub(
                        this.ResourceGroupName,
                        this.Name,
                        virtualHub,
                        this.Tag,
                        auxAuthHeader));
                });
        }
    }
}
