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
            Mandatory = true,
            HelpMessage = "The name of the connection monitor endpoint.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure VM endpoint switch.",
            ParameterSetName = "AzureVM")]
        public SwitchParameter AzureVM { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure Vnet endpoint switch.",
            ParameterSetName = "AzureVNet")]
        public SwitchParameter AzureVNet { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Azure Subnet endpoint switch.",
            ParameterSetName = "AzureSubnet")]
        public SwitchParameter AzureSubnet { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "External Address endpoint switch.",
            ParameterSetName = "ExternalAddress")]
        public SwitchParameter ExternalAddress { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "MMA Workspace Machine endpoint switch.",
            ParameterSetName = "MMAWorkspaceMachine")]
        public SwitchParameter MMAWorkspaceMachine { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "MMA Workspace Network endpoint switch.",
            ParameterSetName = "MMAWorkspaceNetwork")]
        public SwitchParameter MMAWorkspaceNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource ID of the connection monitor endpoint.",
             ParameterSetName = "AzureVM")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource ID of the connection monitor endpoint.",
             ParameterSetName = "AzureVNet")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource ID of the connection monitor endpoint.",
             ParameterSetName = "AzureSubnet")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource ID of the connection monitor endpoint.",
             ParameterSetName = "MMAWorkspaceMachine")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Resource ID of the connection monitor endpoint.",
             ParameterSetName = "MMAWorkspaceNetwork")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Address of the connection monitor endpoint (IP or domain name).",
             ParameterSetName = "ExternalAddress")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "Address of the connection monitor endpoint (IP or domain name).",
             ParameterSetName = "MMAWorkspaceMachine")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Address of the connection monitor endpoint (IP or domain name).",
             ParameterSetName = "AzureVM")]
        [ValidateNotNullOrEmpty]
        public string Address { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items which need to be included into endpont scope.",
             ParameterSetName = "AzureVNet")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items which need to be included into endpont scope.",
             ParameterSetName = "MMAWorkspaceMachine")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "List of items which need to be included into endpont scope.",
             ParameterSetName = "MMAWorkspaceNetwork")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorEndpointScopeItem[] IncludeItem { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items which need to be excluded from endpoint scope.",
             ParameterSetName = "AzureVNet")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items which need to be excluded from endpoint scope.",
             ParameterSetName = "AzureSubnet")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "List of items which need to be excluded from endpoint scope.",
             ParameterSetName = "MMAWorkspaceNetwork")]
        [ValidateNotNullOrEmpty]
        public PSNetworkWatcherConnectionMonitorEndpointScopeItem[] ExcludeItem { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Test coverage for the endpoint. Supported values are Default, Low, BelowAverage, Average, AboveAverage, Full.",
             ParameterSetName = "AzureVNet")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Test coverage for the endpoint. Supported values are Default, Low, BelowAverage, Average, AboveAverage, Full.",
             ParameterSetName = "AzureSubnet")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Test coverage for the endpoint. Supported values are Default, Low, BelowAverage, Average, AboveAverage, Full.",
             ParameterSetName = "MMAWorkspaceNetwork")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("Default", "Low", "BelowAverage", "Average", "AboveAverage", "Full")]
        public string CoverageLevel { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSNetworkWatcherConnectionMonitorEndpointObject endpoint = new PSNetworkWatcherConnectionMonitorEndpointObject()
            {
                Name = this.Name,
                Type = this.GetEndpointType(),
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

        private string GetEndpointType()
        {
            if (AzureVM.IsPresent)
            {
                return "AzureVM";
            }
            else if (AzureVNet.IsPresent)
            {
                return "AzureVNet";
            }
            else if (AzureSubnet.IsPresent)
            {
                return "AzureSubnet";
            }
            else if (ExternalAddress.IsPresent)
            {
                return "ExternalAddress";
            }
            else if (MMAWorkspaceMachine.IsPresent)
            {
                return "MMAWorkspaceMachine";
            }
            else if (MMAWorkspaceNetwork.IsPresent)
            {
                return "MMAWorkspaceNetwork";
            }

            return string.Empty;
        }
    }
}