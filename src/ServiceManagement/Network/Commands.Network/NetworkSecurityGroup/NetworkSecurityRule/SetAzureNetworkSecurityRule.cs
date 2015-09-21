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

using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Utilities;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup
{
    [Cmdlet(VerbsCommon.Set, "AzureNetworkSecurityRule"), OutputType(typeof(INetworkSecurityGroup))]
    public class SetAzureNetworkSecurityRule : NetworkSecurityGroupConfigurationBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false, HelpMessage = "Name of the Network Security Rule to remove.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateSet("Inbound", "Outbound", IgnoreCase = false)]
        public string Type { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateRange(100, 4096)]
        public int Priority { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateSet("Allow", "Deny", IgnoreCase = false)]
        public string Action { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string SourceAddressPrefix { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string SourcePortRange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string DestinationAddressPrefix { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string DestinationPortRange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = false)]
        [ValidateSet("TCP", "UDP", "*", IgnoreCase = false)]
        public string Protocol { get; set; }

        public override void ExecuteCmdlet()
        {
            Client.SetNetworkSecurityRule(
                NetworkSecurityGroup.GetInstance().Name,
                Name,
                Type,
                Priority,
                Action,
                SourceAddressPrefix,
                SourcePortRange,
                DestinationAddressPrefix,
                DestinationPortRange,
                Protocol);

            WriteObject(Client.GetNetworkSecurityGroup(NetworkSecurityGroup.GetInstance().Name, true));
        }
    }
}
