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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup.Model;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup
{
    [Cmdlet(VerbsCommon.Get, "AzureNetworkSecurityGroup"), OutputType(typeof(IEnumerable<INetworkSecurityGroup>))]
    public class GetAzureNetworkSecurityGroup: NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter Detailed { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                GetNoName();
            }
            else
            {
                GetByName();
            }
        }

        private void GetByName()
        {
            INetworkSecurityGroup networkSecurityGroup = Client.GetNetworkSecurityGroup(Name, Detailed);
            WriteNetworkSecurityGroup(networkSecurityGroup);
        }

        private void GetNoName()
        {
            IEnumerable<INetworkSecurityGroup> networkSecurityGroups = Client.ListNetworkSecurityGroups(Detailed);
            WriteNetworkSecurityGroups(networkSecurityGroups);
        }

        private void WriteNetworkSecurityGroup(INetworkSecurityGroup networkSecurityGroup)
        {
            WriteObject(networkSecurityGroup, true);
        }

        private void WriteNetworkSecurityGroups(IEnumerable<INetworkSecurityGroup> networkSecurityGroups)
        {
            WriteObject(networkSecurityGroups, true);
        }
    }
}
