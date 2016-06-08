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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.NetworkSecurityGroup
{
    [Cmdlet(VerbsCommon.Remove, "AzureNetworkSecurityRule"), OutputType(typeof(INetworkSecurityGroup))]
    public class RemoveAzureNetworkSecurityRule : NetworkSecurityGroupConfigurationBaseCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Name of the Network Security Rule to remove.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not confirm Network Security Group deletion")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveNetworkSecurityRuleWarning, Name, NetworkSecurityGroup.GetInstance().Name),
                Resources.RemoveNetworkSecurityRuleWarning,
                Name,
                () =>
                {
                    Client.RemoveNetworkSecurityRule(NetworkSecurityGroup.GetInstance().Name, Name);
                    WriteObject(Client.GetNetworkSecurityGroup(NetworkSecurityGroup.GetInstance().Name, true));
                });
        }
    }
}
