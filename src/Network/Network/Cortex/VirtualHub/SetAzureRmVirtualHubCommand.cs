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
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    [Cmdlet("Set",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHub",
        DefaultParameterSetName = CortexParameterSetNames.ByVirtualHubName,
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class SetAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualHubName", "HubName")]
        [Parameter(
            Mandatory = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubName,
            HelpMessage = "The resource name.")]
        [ResourceNameCompleter("Microsoft.Network/virtualHubs", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("VirtualHubId")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubResourceId,
            HelpMessage = "The resource id of the Virtual hub to be modified.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("VirtualHub")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = CortexParameterSetNames.ByVirtualHubObject,
            HelpMessage = "The Virtual hub object to be modified.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualHub InputObject { get; set; }

        public const String RTv2ChangeDesc = "Parameter is being deprecated without being replaced. Use *VHubRouteTable* commands.";
        [CmdletParameterBreakingChange("RouteTable", ChangeDescription = RTv2ChangeDesc)]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The route tables associated with this Virtual Hub.")]
        public PSVirtualHubRouteTable[] RouteTable { get; set; }

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

            if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubObject, StringComparison.OrdinalIgnoreCase))
            {
                var hub = this.InputObject;
                this.ResourceGroupName = hub.ResourceGroupName;
                this.Name = hub.Name;
            }
            else
            {
                if (ParameterSetName.Equals(CortexParameterSetNames.ByVirtualHubResourceId, StringComparison.OrdinalIgnoreCase))
                {
                    var parsedResourceId = new ResourceIdentifier(ResourceId);
                    this.Name = parsedResourceId.ResourceName;
                    this.ResourceGroupName = parsedResourceId.ResourceGroupName;
                }

            }
            PSVirtualHub virtualHubToUpdate = this.GetVirtualHub(this.ResourceGroupName, this.Name);

            if (virtualHubToUpdate == null)
            {
                throw new PSArgumentException(Properties.Resources.VirtualHubToUpdateNotFound);
            }

            //// VirtualHubRouteTable
            if(virtualHubToUpdate.RouteTables == null)
            {
                virtualHubToUpdate.RouteTables = new List<PSVirtualHubRouteTable>();
                virtualHubToUpdate.RouteTables.AddRange(this.RouteTable);
            }
            else 
            { 
                foreach (var routeTable in this.RouteTable)
                {
                    // see if routeTable with same name already exists in hub, 
                    // if it does then remove it and add the route table that we received as input
                    // if it does not exist then directly add the input 
                    var routeTableToRemove = virtualHubToUpdate.RouteTables.FirstOrDefault(rt => rt.Name.Equals(routeTable.Name, StringComparison.OrdinalIgnoreCase));
                    if (routeTableToRemove != null)
                    {
                        virtualHubToUpdate.RouteTables.Remove(routeTableToRemove);
                    }
                    virtualHubToUpdate.RouteTables.Add(routeTable);
                }
            }

            //// Update the virtual hub
            ConfirmAction(
                    Properties.Resources.SettingResourceMessage,
                    this.Name,
                    () =>
                    {
                        WriteVerbose(String.Format(Properties.Resources.UpdatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                        WriteObject(this.CreateOrUpdateVirtualHub(
                            this.ResourceGroupName,
                            this.Name,
                            virtualHubToUpdate,
                            this.Tag));
                    });
        }
    }
}
