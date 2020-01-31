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

using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndpointObject", SupportsShouldProcess = true), 
        OutputType(typeof(PSNetworkWatcherConnectionMonitorEndpointObject))]
    public class NewAzureNetworkWatcherConnectionMonitorEndpointObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the connection monitor endpoint.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource ID of the connection monitor endpoint.",
            ParameterSetName = "SetByResourceId")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Address of the connection monitor endpoint (IP or domain name).",
            ParameterSetName = "SetByAddress")]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The behavior of the endpoint filter. Currently only 'Include' is supported.",
            ParameterSetName = "SetByResourceId")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Include")]
        public string FilterType { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items in the filter.",
            ParameterSetName = "SetByResourceId")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorEndpointFilterItem[] FilterItem { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.IsNullOrEmpty(this.Name))
            {
                if (!string.IsNullOrEmpty(this.ResourceId))
                {
                    string[] SplittedName = ResourceId.Split('/');
                    // Name is in the form resourceName(ResourceGroupName)
                    this.Name = SplittedName[8] + "(" + SplittedName[4] + ")";
                }
                else if (!string.IsNullOrEmpty(this.Address))
                {
                    this.Name = this.Address;
                }
            }

            PSNetworkWatcherConnectionMonitorEndpointObject endpoint = new PSNetworkWatcherConnectionMonitorEndpointObject()
            {
                Name = this.Name,
                ResourceId = this.ResourceId,
                Address = this.Address,
            };

            if (this.FilterItem != null)
            {
                endpoint.Filter = new PSNetworkWatcherConnectionMonitorEndpointFilter()
                {
                    Type = FilterType == null ? "Include" : this.FilterType
                };

                foreach (PSNetworkWatcherConnectionMonitorEndpointFilterItem Item in this.FilterItem)
                {
                    if (endpoint.Filter.Items == null)
                    {
                        endpoint.Filter.Items = new List<PSNetworkWatcherConnectionMonitorEndpointFilterItem>();
                    }

                    endpoint.Filter.Items.Add(new PSNetworkWatcherConnectionMonitorEndpointFilterItem()
                    {
                        Type = string.IsNullOrEmpty(Item.Type) ? "AgentAddress" : Item.Type,
                        Address = Item.Address
                    });
                }
            }

            this.ValidateEndpoint(endpoint);

            WriteObject(endpoint);
        }
    }
}