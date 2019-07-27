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
using Microsoft.Azure.Commands.Network.Common;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualNetworkSubnetConfig",DefaultParameterSetName = "GetByVirtualNetwork"), OutputType(typeof(PSSubnet))]
    public class GetAzureVirtualNetworkSubnetConfigCommand : VirtualNetworkBaseCmdlet
  {
        [Parameter(
            Mandatory = false,
            ParameterSetName = "GetByVirtualNetwork",
            HelpMessage = "The name of the subnet")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "GetByVirtualNetwork",
            HelpMessage = "The virtualNetwork")]
        public PSVirtualNetwork VirtualNetwork { get; set; }

        [Parameter(
            Mandatory = true,
            ParameterSetName = "GetByResourceId",
            HelpMessage = "Resource Id to the subnet"
        )]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (ParameterSetName == "GetByResourceId") {
              string resourceGroupName = null;
              string virtualNetworkName = null;
              string subnetName = null;

              if (ResourceIdHelper.TryParseSubnetMetadataFromResourceId(this.ResourceId, out resourceGroupName, out virtualNetworkName, out subnetName)) {
                this.Name = subnetName;
                this.VirtualNetwork = this.GetVirtualNetwork(resourceGroupName, virtualNetworkName);
              }
            }

            if (this.VirtualNetwork != null) {
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
}
