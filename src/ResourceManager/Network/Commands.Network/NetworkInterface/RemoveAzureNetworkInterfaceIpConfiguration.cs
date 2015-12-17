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

using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Remove, "AzureRmNetworkInterfaceIpConfiguration"), OutputType(typeof(PSNetworkInterface))]
    public class RemoveAzureNetworkInterfaceIpConfiguration : NetworkInterfaceBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "SetByResource",
            HelpMessage = "The NetworkInterface")]
        public PSNetworkInterface NetworkInterface { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The Resource Group Name")]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "SetByResourceId",
            HelpMessage = "The Network Interface Name")]
        public string NetworkInterfaceName { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (string.Equals(ParameterSetName, Microsoft.Azure.Commands.Network.Properties.Resources.SetByResourceId))
            {
                this.NetworkInterface = this.GetNetworkInterface(this.ResourceGroupName, this.NetworkInterfaceName);
            }

            if (!this.IsNetworkInterfacePresent(this.NetworkInterface.ResourceGroupName, this.NetworkInterface.Name))
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            var nicIpConfiguration =
                this.NetworkInterface.IpConfigurations.FirstOrDefault(
                    ipconfig => string.Equals(ipconfig.Name, this.Name, StringComparison.OrdinalIgnoreCase));

            if (nicIpConfiguration == null)
            {
                throw new ArgumentException(
                    string.Format("IpConfiguration with name {0} does not exist on Nic {1}",
                    this.Name,
                    this.NetworkInterfaceName));
            }

            this.NetworkInterface.IpConfigurations.Remove(nicIpConfiguration);
            WriteObject(this.NetworkInterface);
        }
    }
}
