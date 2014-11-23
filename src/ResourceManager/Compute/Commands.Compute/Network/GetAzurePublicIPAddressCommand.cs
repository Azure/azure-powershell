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
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.WindowsAzure;
using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    /// <summary>
    /// Get a public IP address.
    /// </summary>
    [Cmdlet(
        VerbsCommon.Get,
        ProfileNouns.PublicIpAddress)]
    public class GetAzurePublicIPAddressCommand : PublicIpAddressBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address name.")]
        [ValidateNotNullOrEmpty]
        public override string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (string.IsNullOrEmpty(this.Name))
            {
                var result = this.PublicIpAddressClient.ListPublicIpAddresses(this.ResourceGroupName, null);
                var ipaddresslist = Mapper.Map<List<PublicIpAddress>>(result.PublicIpAddresses);
                WriteObject(ipaddresslist, true);
            }
            else
            {
                var result = this.PublicIpAddressClient.GetPublicIpAddress(this.ResourceGroupName, this.Name, null);
                var ipaddress = Mapper.Map<PublicIpAddress>(result.PublicIpAddress);
                WriteObject(ipaddress);
            }
        }
    }
}
