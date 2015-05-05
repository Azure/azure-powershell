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

using Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Properties;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Routes
{
    [Cmdlet(VerbsCommon.Remove, "AzureSubnetRouteTable"), OutputType(typeof(bool))]
    public class RemoveAzureSubnetRouteTable : NetworkCmdletBase
    {
        [Parameter(Position = 0, Mandatory = true, HelpMessage = "The name of the virtual network.")]
        public string VirtualNetworkName { get; set; }

        [Parameter(Position = 1, Mandatory = true, HelpMessage = "The name of the subnet that will have its route table removed.")]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemoveRouteTableFromSubnetWarning, SubnetName, VirtualNetworkName),
                Resources.RemoveRouteTableFromSubnetWarning,
                SubnetName,
                () =>
                {
                    Client.RemoveRouteTableFromSubnet(VirtualNetworkName, SubnetName);

                    WriteVerboseWithTimestamp(Resources.RemoveRouteTableFromSubnetSucceeded, VirtualNetworkName, SubnetName);
                    if (PassThru.IsPresent)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
