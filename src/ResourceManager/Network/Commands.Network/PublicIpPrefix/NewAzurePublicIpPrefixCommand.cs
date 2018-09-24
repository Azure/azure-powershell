﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using MNM = Microsoft.Azure.Management.Network.Models;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PublicIpPrefix", SupportsShouldProcess = true), OutputType(typeof(PSPublicIpPrefix))]
    public class NewAzurePublicIpPrefixCommand : PublicIpPrefixBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP prefix location.")]
        [LocationCompleter("Microsoft.Network/publicIPPrefixes")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP Prefix Sku name.")]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            MNM.PublicIPAddressSkuName.Standard,
            IgnoreCase = true)]
        public string Sku { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The PublicIPPrefix length")]
        [ValidateNotNullOrEmpty]
        [ValidateRange((ushort)21, (ushort)31)]
        public ushort PrefixLength { get; set; }

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
            HelpMessage = "IpTag List.")]
        public List<PSPublicIpPrefixTag> IpTag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A list of availability zones denoting the IP allocated for the resource needs to come from.",
            ValueFromPipelineByPropertyName = true)]
        public List<string> Zone { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsPublicIpPrefixPresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var publicIpPrefix = CreatePublicIpPrefix();
                    if (publicIpPrefix != null)
                    {
                        WriteObject(publicIpPrefix);
                    }
                },
                () => present);
        }

        private PSPublicIpPrefix CreatePublicIpPrefix()
        {
            var publicIpPrefix = new PSPublicIpPrefix();
            publicIpPrefix.Name = this.Name;
            publicIpPrefix.Location = this.Location;
            publicIpPrefix.PublicIpAddressVersion = MNM.IPVersion.IPv4;
            if (!string.IsNullOrEmpty(this.IpAddressVersion))
            {
                publicIpPrefix.PublicIpAddressVersion = this.IpAddressVersion;
            }

            publicIpPrefix.Zones = this.Zone;
            publicIpPrefix.PrefixLength = this.PrefixLength;

            publicIpPrefix.Sku = new PSPublicIpPrefixSku();
            publicIpPrefix.Sku.Name = MNM.PublicIPAddressSkuName.Standard;
            if (!string.IsNullOrEmpty(this.Sku))
            {
                publicIpPrefix.Sku.Name = this.Sku;
            }

            if (this.IpTag != null && this.IpTag.Count > 0)
            {
                publicIpPrefix.IpTags = this.IpTag;
            }

            var theModel = NetworkResourceManagerProfile.Mapper.Map<MNM.PublicIPPrefix>(publicIpPrefix);

            theModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            if (this.ShouldProcess(this.Name, $"Creating a new PublicIpPrefix in ResourceGroup {this.ResourceGroupName} with Name {this.Name}"))
            {
                this.PublicIpPrefixClient.CreateOrUpdate(this.ResourceGroupName, this.Name, theModel);

                var getPublicIpPrefix = this.GetPublicIpPrefix(this.ResourceGroupName, this.Name);

                return getPublicIpPrefix;
            }

            return null;
        }
    }
}
