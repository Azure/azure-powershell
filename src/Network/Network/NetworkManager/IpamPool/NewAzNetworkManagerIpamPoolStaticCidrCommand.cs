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
using Microsoft.Azure.Commands.Network.Models.NetworkManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerIpamPoolStaticCidr", SupportsShouldProcess = true), OutputType(typeof(PSStaticCidr))]

    public class NewAzNetworkManagerIpamPoolStaticCidrCommand : IpamPoolStaticCidrBaseCmdlet
    {
        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Static Cidr allocation name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The network manager name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string NetworkManagerName { get; set; }

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
         HelpMessage = "IP Address Manager Pool resource name.")]
         [ValidateNotNullOrEmpty]
        public virtual string IpamPoolName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Number of IP addresses to allocate for a static CIDR resource. The IP addresses will be assigned based on IpamPools available space.")]
        public virtual string NumberOfIPAddressesToAllocate { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "List of IP address prefixes of the resource.")]
        public virtual List<string> AddressPrefix { get; set; }

        [Parameter(
         Mandatory = false,
         ValueFromPipelineByPropertyName = true,
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }
        public override void Execute()
        {
            base.Execute();
            var present = this.IsStaticCidrPresent(this.ResourceGroupName, this.NetworkManagerName, this.IpamPoolName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var staticCidr = this.CreateStaticCidr();
                    WriteObject(staticCidr);
                },
                () => present);
        }

        private PSStaticCidr CreateStaticCidr()
        {
            var staticCidr = new PSStaticCidr();
            staticCidr.Name = this.Name;
            staticCidr.Properties = new PSStaticCidrProperties();

            if (this.AddressPrefix != null)
            {
                staticCidr.Properties.AddressPrefixes = this.AddressPrefix;
            }

            if (!string.IsNullOrEmpty(this.NumberOfIPAddressesToAllocate))
            {
                staticCidr.Properties.NumberOfIPAddressesToAllocate = this.NumberOfIPAddressesToAllocate;
            }

            if (!string.IsNullOrEmpty(this.Description))
            {
                staticCidr.Properties.Description = this.Description;
            }
            // Map to the sdk object
            var staticCidrModel = NetworkResourceManagerProfile.Mapper.Map<MNM.StaticCidr>(staticCidr);

            // Execute the Create Network call string resourceGroupName, string networkManagerName, string IpamPoolName, string staticCidrName
            this.StaticCidrClient.Create(this.ResourceGroupName, this.NetworkManagerName, this.IpamPoolName, this.Name, staticCidrModel);
            var psStaticCidr = this.GetStaticCidr(this.ResourceGroupName, this.NetworkManagerName, this.IpamPoolName, this.Name);
            return psStaticCidr;
        }
    }
}