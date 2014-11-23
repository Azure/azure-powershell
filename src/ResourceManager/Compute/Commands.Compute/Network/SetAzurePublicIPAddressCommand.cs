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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.NetworkResourceProvider.Models;

namespace Microsoft.Azure.Commands.Network
{
    /// <summary>
    /// Creates a new resource.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Set,
        "AzurePublicIPAddress")]
    public class SetAzurePublicIPAddressCommand : PublicIpAddressBaseCmdlet
    {

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address allocation method.")]
        [ValidateNotNullOrEmpty]
        public string AllocationMethod { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            var publicIp = new CreatePublicIpAddress()
            {
                Location = this.Location,
                Tags = null,
                Properties = new CreatePublicIpAddressProperties(this.AllocationMethod)
            };

            this.PublicIpAddressClient.PutPublicIpAddress(this.ResourceGroupName, this.Name, null, null, null, null, null);
        }
    }
}
