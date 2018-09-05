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
using System;
using System.Linq;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkSubnetConfig"), OutputType(typeof(PSSubnet))]
    public class GetAzureVirtualNetworkSubnetConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the subnet")]
        public string Name { get; set; }

        [CmdletParameterBreakingChange("VirtualNetwork", ChangeDescription = "The EnableVMProtection property for the parameter Virtualnetwork is no longer supported. Setting this property has no impact. This property will be removed in a future release. Please remove it from your scripts")]
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (!string.IsNullOrEmpty(this.Name))
            {
                var subnet =
                    this.VirtualNetwork.Subnets.FirstOrDefault(
                        resource =>
                            string.Equals(resource.Name, this.Name, StringComparison.CurrentCultureIgnoreCase));

                if (subnet == null)
                {
                    throw new ArgumentException(string.Format(Properties.Resources.ResourceNotFound, this.Name));
                }

                WriteObject(subnet);
            }
            else
            {
                var subnets = this.VirtualNetwork.Subnets;
                WriteObject(subnets, true);
            }
        }
    }
}
