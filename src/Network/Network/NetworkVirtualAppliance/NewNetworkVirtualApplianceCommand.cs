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
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Remoting;
using System.Text;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkVirtualAppliance", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(PSNetworkVirtualAppliance))]
    public class NewNetworkVirtualApplianceCommand : NetworkVirtualApplianceBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";

        [Alias("ResourceName")]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceNameParameterSet,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceNameParameterSet,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceIdParameterSet,
            HelpMessage = "The resource Id.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The public IP address location.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Resource Id of the Virtual Hub.")]
        [ValidateNotNullOrEmpty]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Sku of the Virtual Appliance.")]
        public PSVirtualApplianceSkuProperties Sku{ get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The ASN number of the Virtual Appliance.")]
        [ValidateNotNullOrEmpty]
        public int VirtualApplianceAsn { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Managed identity.")]
        [ValidateNotNullOrEmpty]
        public PSManagedServiceIdentity Identity { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Bootstrap configuration blob URL.")]
        [ValidateNotNullOrEmpty]
        public string[] BootStrapConfigurationBlob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Cloudinit configuration blob storage URL.")]
        [ValidateNotNullOrEmpty]
        public string[] CloudInitConfigurationBlob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Cloudinit configuration as plain text.")]
        [ValidateNotNullOrEmpty]
        public string CloudInitConfiguration { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Additional Nic Properties of the Virtual Appliance.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualApplianceAdditionalNicProperties[] AdditionalNic { get; set; }

        [Parameter(
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The Internet Ingress IPs Properties of the Virtual Appliance.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualApplianceInternetIngressIpsProperties[] InternetIngressIp { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Network Profile of the Virtual Appliance.")]
        [ValidateNotNullOrEmpty]
        public PSVirtualApplianceNetworkProfile NetworkProfile { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                this.Name = GetResourceName(this.ResourceId, "Microsoft.Network/networkVirtualAppliances");
            }
            var present = this.IsNetworkVirtualAppliancePresent(this.ResourceGroupName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var nva = CreateNetworkVirtualAppliance();
                    if (present)
                    {
                        nva = this.GetNetworkVirtualAppliance(this.ResourceGroupName, this.Name);
                    }

                    WriteObject(nva);
                },
                () => present);
        }

        private PSNetworkVirtualAppliance CreateNetworkVirtualAppliance()
        {
            var networkVirtualAppliance = new PSNetworkVirtualAppliance();
            networkVirtualAppliance.Name = this.Name;
            networkVirtualAppliance.Location = this.Location;
            networkVirtualAppliance.VirtualHub = new PSResourceId();
            networkVirtualAppliance.VirtualHub.Id = this.VirtualHubId;
            networkVirtualAppliance.VirtualApplianceAsn = this.VirtualApplianceAsn;
            networkVirtualAppliance.NvaSku = this.Sku;
            networkVirtualAppliance.Identity = this.Identity;
            networkVirtualAppliance.BootStrapConfigurationBlobs = this.BootStrapConfigurationBlob;
            networkVirtualAppliance.CloudInitConfigurationBlobs = this.CloudInitConfigurationBlob;
            networkVirtualAppliance.CloudInitConfiguration = this.CloudInitConfiguration;
            if (AdditionalNic != null)
            {
                networkVirtualAppliance.AdditionalNics = AdditionalNic;
            }

            if (InternetIngressIp != null)
            {
                networkVirtualAppliance.InternetIngressPublicIps = InternetIngressIp;
            }

            if (NetworkProfile != null)
            {
                networkVirtualAppliance.NetworkProfile = NetworkProfile;
            }

            var networkVirtualApplianceModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkVirtualAppliance>(networkVirtualAppliance);

            networkVirtualApplianceModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.NetworkVirtualAppliancesClient.CreateOrUpdate(this.ResourceGroupName, this.Name, networkVirtualApplianceModel);
            
            var getNetworkVirtualAppliance = this.GetNetworkVirtualAppliance(this.ResourceGroupName, this.Name);
            return getNetworkVirtualAppliance;
        }
    }
}
