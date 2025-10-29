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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NvaInterfaceConfiguration",
        SupportsShouldProcess = true),
        OutputType(typeof(PSNetworkVirtualApplianceInterfaceConfigProperties))]
    public class NewNvaInterfaceConfigurationCommand : NvaInVnetBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The type of the network interface e.g., PublicNic, PrivateNic, AdditionalPrivateNic or AdditionalPublicNic")]
        [ValidateNotNullOrEmpty]
        public string[] NicType { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = "The name of the interface")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

		    [Parameter(
				    Mandatory = true,
				    ValueFromPipelineByPropertyName = false,
				    HelpMessage = "The subnet resource id")]
		    [ValidateNotNullOrEmpty]
		    public string SubnetId { get; set; }

		public override void ExecuteCmdlet()
        {
            var networkInterfaceConfiguration = new PSNetworkVirtualApplianceInterfaceConfigProperties
						{
                NicType = this.NicType != null ? this.NicType.ToList() : new List<string>(),
								Name = this.Name,
                Subnet = new PSResourceId
                {
                  Id = this.SubnetId,
                }
            };
            WriteObject(networkInterfaceConfiguration);
        }
    }
}