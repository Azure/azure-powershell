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

using AutoMapper;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections.Generic;
using CNM = Microsoft.Azure.Commands.Network.Models;


namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpAddressDdosProtectionStatus"), OutputType(typeof(PSPublicIpDdosProtectionStatusResult))]
    public class GetAzurePublicIpAddressDdosProtectionStatusCommand : PublicIpAddressBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ParameterSetName = "TestByResource",
            HelpMessage = "The PublicIpAddress")]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = false,
            ParameterSetName = "TestByResourceId",
            HelpMessage = "The resource group name")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = false,
            ParameterSetName = "TestByResourceId",
            HelpMessage = "The PublicIpAddress name")]
        [ResourceNameCompleter("Microsoft.Network/publicIPAddresses", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string PublicIpAddressName { get; set; }

        public override void Execute()
        {
            base.Execute();

            PSPublicIpDdosProtectionStatusResult result = null;

            if (string.Equals(ParameterSetName, "TestByResource"))
            {
                result = this.ListDdosProtectionStatus(this.PublicIpAddress.ResourceGroupName, this.PublicIpAddress.Name);
            }
            else
            {
                result = this.ListDdosProtectionStatus(this.ResourceGroupName, this.PublicIpAddressName);
            }

            WriteObject(result, true);
        }

        public PSPublicIpDdosProtectionStatusResult ListDdosProtectionStatus(string resourceGroupName, string pipName)
        {
            var ddosProtectionSttausResult = this.NetworkClient.NetworkManagementClient.PublicIPAddresses.DdosProtectionStatus(resourceGroupName, pipName);
            var result = NetworkResourceManagerProfile.Mapper.Map<CNM.PSPublicIpDdosProtectionStatusResult>(ddosProtectionSttausResult);

            return result;
        }
    }
}
