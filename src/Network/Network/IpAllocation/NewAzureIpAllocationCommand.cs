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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Linq;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IpAllocation", SupportsShouldProcess = true), OutputType(typeof(PSIpAllocation))]
    public class NewAzureIpAllocationCommand : IpAllocationBaseCmdlet
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
         Mandatory = true,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "location.")]
        [LocationCompleter("Microsoft.Network/ipAllocation")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The type of the IP allocation")]
        [ValidateSet("Hypernet", "Undefined", IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string IpAllocationType { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The prefix of the IP allocation")]
        public string Prefix { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
            HelpMessage = "The prefix length of the IP allocation")]
        public int? PrefixLength { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
            HelpMessage = "The prefix type of the IP allocation")]
        [ValidateSet("IPV4", "IPV6", IgnoreCase = true)]
        public string PrefixType { get; set; }

        [Parameter(
             Mandatory = false,
             ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ipam allocation ID of the IP allocation")]
        public string IpamAllocationId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The allocation tags of the IP allocation")]
        public Hashtable IpAllocationTag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to override a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = IsIpAllocationPresent(ResourceGroupName, Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var allocation = CreateIpAllocation();
                    WriteObject(allocation);
                },
                () => present);
        }

        private PSIpAllocation CreateIpAllocation()
        {
            var allocation = new PSIpAllocation
            {
                Name = Name,
                ResourceGroupName = ResourceGroupName,
                Location = Location,
                IpAllocationType = IpAllocationType,
                Prefix = Prefix,
                PrefixLength = PrefixLength,
                PrefixType = PrefixType,
                IpamAllocationId = IpamAllocationId
            };

            // Map to the sdk object
            var allocationModel = NetworkResourceManagerProfile.Mapper.Map<MNM.IpAllocation>(allocation);
            allocationModel.AllocationTags = TagsConversionHelper.CreateTagDictionary(this.IpAllocationTag, validate: true);

            allocationModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create IpALlocation call
            IpAllocationClient.CreateOrUpdate(ResourceGroupName, Name, allocationModel);

            var getIpAllocation = GetIpAllocation(ResourceGroupName, Name);

            return getIpAllocation;
        }
    }
}
