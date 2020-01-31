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
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkWatcherConnectionMonitorEndpointFilterItemObject", SupportsShouldProcess = true), OutputType(typeof(PSNetworkWatcherConnectionMonitorEndpointFilterItem))]
    public class NewAzureNetworkWatcherConnectionMonitorEndpointFilterItemObjectCommand : ConnectionMonitorBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The type of item included in the filter. Currently only 'AgentAddress' is supported.")]
        [ValidateNotNullOrEmpty]
        [PSArgumentCompleter("AgentAddress")]
        public string Type { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The address of the filter item.")]
        [ValidateNotNullOrEmpty]
        public string Address;

        public override void Execute()
        {
            base.Execute();

            PSNetworkWatcherConnectionMonitorEndpointFilterItem endpointFilterItem = new PSNetworkWatcherConnectionMonitorEndpointFilterItem()
            {
                Type = Type == null ? "AgentAddress" : this.Type,
                Address = this.Address
            };

            this.ValidateEndpointFilterItem(endpointFilterItem);

            WriteObject(endpointFilterItem);
        }
    }
}