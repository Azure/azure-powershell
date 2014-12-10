

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
using System.Management.Automation;
using AutoMapper;
using Microsoft.Azure.Commands.NetworkResourceProvider.Models;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.NetworkResourceProvider
{
    [Cmdlet(VerbsCommon.New, "AzurePublicIpAddress"), OutputType(typeof(PSPublicIpAddress))]
    public class NewAzurePublicIpAddressCmdlet : PublicIpAddressBaseClient
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The public IP address allocation method.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(MNM.IpAllocationMethod.Dynamic, IgnoreCase = true)]
        public string AllocationMethod { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Domain Name label.")]
        [ValidateNotNullOrEmpty]
        public string DomainNameLabel { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.IsPublicIpAddressPresent(this.ResourceGroupName, this.Name))
            {
                throw new ArgumentException(ResourceAlreadyPresent);
            }

            var publicIp = new PSPublicIpAddress();
            publicIp.Name = this.Name;
            publicIp.Location = this.Location;
            publicIp.Properties = new PSPublicIpAddressProperties();
            publicIp.Properties.PublicIpAllocationMethod = this.AllocationMethod;
            publicIp.Properties.DnsSettings = new PSPublicIpAddressDnsSettings();
            publicIp.Properties.DnsSettings.DomainNameLabel = this.DomainNameLabel;

            var publicIpModel = Mapper.Map<MNM.PublicIpAddressCreateOrUpdateParameters>(publicIp);

            this.PublicIpAddressClient.CreateOrUpdate(this.ResourceGroupName, this.Name, publicIpModel);

            var getPublicIp = this.GetPublicIpAddress(this.ResourceGroupName, this.Name);

            WriteObject(getPublicIp);
        }
    }
}

 