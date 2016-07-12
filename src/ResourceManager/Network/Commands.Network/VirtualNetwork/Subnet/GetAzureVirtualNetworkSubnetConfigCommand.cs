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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmVirtualNetworkSubnetConfig"), OutputType(typeof(PSSubnet))]
    public class GetAzureVirtualNetworkSubnetConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the subnet")]
        public string Name { get; set; }

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
                    this.VirtualNetwork.Subnets.First(
                        resource =>
                            string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

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
