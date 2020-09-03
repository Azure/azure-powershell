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
            HelpMessage = "The type of the connection monitor endpoint. Supported types are AzureVM, AzureVNet, AzureSubnet, ExternalAddress, MMAWorkspaceMachine, MMAWorkspaceNetwork.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("AzureVM", "AzureVNet", "AzureSubnet", "ExternalAddress", "MMAWorkspaceMachine", "MMAWorkspaceNetwork")]
        public string Type { get; set; }

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
            HelpMessage = "List of items which need to be included into endpont scope.",
            ParameterSetName = "SetByResourceId")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorEndpointScopeItem[] IncludeItem { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items which need to be excluded from endpoint scope.",
            ParameterSetName = "SetByResourceId")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorEndpointScopeItem[] ExcludeItem { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Test coverage for the endpoint. Supported values are Default, Low, BelowAverage, Average, AboveAvergae, Full.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Default", "Low", "BelowAverage", "Average", "AboveAverage", "Full")]
        public string CoverageLevel { get; set; }

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
                Type = this.Type,
                ResourceId = this.ResourceId,
                Address = this.Address,
                CoverageLevel = this.CoverageLevel
            };

            if (this.IncludeItem != null || this.ExcludeItem != null)
            {
                endpoint.Scope = new PSNetworkWatcherConnectionMonitorEndpointScope();

                if (this.IncludeItem != null)
                {
                    endpoint.Scope.Include = new List<PSNetworkWatcherConnectionMonitorEndpointScopeItem>();
                    foreach (PSNetworkWatcherConnectionMonitorEndpointScopeItem item in this.IncludeItem)
                    {
                        endpoint.Scope.Include.Add(new PSNetworkWatcherConnectionMonitorEndpointScopeItem()
                        {
                            Address = item.Address
                        });
                    }
                }

                if (this.ExcludeItem != null)
                {
                    endpoint.Scope.Exclude = new List<PSNetworkWatcherConnectionMonitorEndpointScopeItem>();
                    foreach (PSNetworkWatcherConnectionMonitorEndpointScopeItem item in this.ExcludeItem)
                    {
                        endpoint.Scope.Exclude.Add(new PSNetworkWatcherConnectionMonitorEndpointScopeItem()
                        {
                            Address = item.Address
                        });
                    }
                }
            }

            this.ValidateEndpoint(endpoint);

            WriteObject(endpoint);
        }
    }
}