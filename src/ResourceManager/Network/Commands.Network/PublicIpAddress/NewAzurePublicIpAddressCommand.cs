

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
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, "AzureRmPublicIpAddress", SupportsShouldProcess = true),
        OutputType(typeof(PSPublicIpAddress))]
    public class NewAzurePublicIpAddressCommand : PublicIpAddressBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address allocation method.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IPAllocationMethod.Dynamic,
            MNM.IPAllocationMethod.Static,
            IgnoreCase = true)]
        public string AllocationMethod { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address version.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.IPVersion.IPv4,
            MNM.IPVersion.IPv6,
            IgnoreCase = true)]
        public string IpAddressVersion { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Domain Name label.")]
        public string DomainNameLabel { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Reverse FQDN.")]
        public string ReverseFqdn { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "IdleTimeoutInMinutes")]
        public int IdleTimeoutInMinutes { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        public override void Execute()
        {
            base.Execute();
            WriteWarning("The output object type of this cmdlet will be modified in a future release.");
            var present = this.IsPublicIpAddressPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var publicIp = CreatePublicIpAddress();
                    WriteObject(publicIp);
                },
                () => present);
        }

        private PSPublicIpAddress CreatePublicIpAddress()
        {
            var publicIp = new PSPublicIpAddress();
            publicIp.Name = this.Name;
            publicIp.Location = this.Location;
            publicIp.PublicIpAllocationMethod = this.AllocationMethod;
            publicIp.PublicIpAddressVersion = this.IpAddressVersion;

            if (this.IdleTimeoutInMinutes > 0)
            {
                publicIp.IdleTimeoutInMinutes = this.IdleTimeoutInMinutes;
            }

            if (!string.IsNullOrEmpty(this.DomainNameLabel))
            {
                publicIp.DnsSettings = new PSPublicIpAddressDnsSettings();
                publicIp.DnsSettings.DomainNameLabel = this.DomainNameLabel;
                publicIp.DnsSettings.ReverseFqdn = this.ReverseFqdn;
            }

            var publicIpModel = Mapper.Map<MNM.PublicIPAddress>(publicIp);

            publicIpModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.PublicIpAddressClient.CreateOrUpdate(this.ResourceGroupName, this.Name, publicIpModel);

            var getPublicIp = this.GetPublicIpAddress(this.ResourceGroupName, this.Name);

            return getPublicIp;
        }
    }
}

