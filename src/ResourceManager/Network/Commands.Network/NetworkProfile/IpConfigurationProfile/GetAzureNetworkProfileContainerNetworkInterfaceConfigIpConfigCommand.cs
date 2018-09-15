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
using Microsoft.Azure.Management.Network.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkProfileContainerNicConfigIpConfig"), OutputType(typeof(PSContainerNetworkInterfaceConfiguration))]
    public partial class GetAzureNetworkProfileContainerNetworkInterfaceConfigIpConfigCommand : NetworkBaseCmdlet 
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The reference of the network profile resource.",
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public PSContainerNetworkInterfaceConfiguration ContainerNetworkInterfaceConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the container network interface configuration.")]
        public string Name { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (!string.IsNullOrEmpty(this.Name))
            {
                var vIPConfigProfile =
                        this.ContainerNetworkInterfaceConfiguration.IpConfigurations.First(
                            resource =>
                                string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));
                WriteObject(vIPConfigProfile);
            }
            else
            {
                WriteObject(ContainerNetworkInterfaceConfiguration.IpConfigurations, true);
            }
        }
    }
}
