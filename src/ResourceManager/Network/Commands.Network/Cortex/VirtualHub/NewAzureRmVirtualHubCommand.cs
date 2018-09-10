﻿// ----------------------------------------------------------------------------------
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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualHub",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualHub))]
    public class NewAzureRmVirtualHubCommand : VirtualHubBaseCmdlet
    {
        [Alias("ResourceName", "VirtualHubName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The virtual wan object this hub is linked to.")]
        public PSVirtualWan VirtualWan { get; set; }

        [Parameter(
            Mandatory = false,
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
            HelpMessage = "location.")]
        [LocationCompleter]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The hub virtual network connections associated with this Virtual Hub.")]
        public List<PSHubVirtualNetworkConnection> HubVnetConnection { get; set; }

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
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            
            string virtualWanRGName = null;
            string virtualWanName = null;

            //// Resolve the virtual wan
            if (this.VirtualWan != null)
            {
                virtualWanRGName = this.VirtualWan.ResourceGroupName;
                virtualWanName = this.VirtualWan.Name;
            }
            else if (!string.IsNullOrWhiteSpace(this.VirtualWanId))
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
                this.Name,
                () =>
                {
                    PSVirtualHub virtualHub = new PSVirtualHub
                    {
                        ResourceGroupName = this.ResourceGroupName,
                        Name = this.Name,
                        VirtualWan = new PSResourceId() { Id = resolvedVirtualWan.Id },
                        AddressPrefix = this.AddressPrefix,
                        Location = this.Location
                    };

                    virtualHub.VirtualNetworkConnections = new List<PSHubVirtualNetworkConnection>();
                    if (this.HubVnetConnection != null)
                    {
                        virtualHub.VirtualNetworkConnections.AddRange(this.HubVnetConnection);
                    }

                    virtualHub.RouteTable = this.RouteTable;

                    WriteObject(this.CreateOrUpdateVirtualHub(
                        this.ResourceGroupName,
                        this.Name,
                        virtualHub,
                        this.Tag));
                });
        }
    }
}
