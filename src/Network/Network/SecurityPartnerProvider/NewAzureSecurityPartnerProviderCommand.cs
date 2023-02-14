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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Monitor.Version2018_09_01.Models;
using Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SecurityPartnerProvider", SupportsShouldProcess = true), OutputType(typeof(PSSecurityPartnerProvider))]
    public class NewAzureSecurityPartnerProviderCommand : SecurityPartnerProviderBaseCmdlet
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
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "location.")]
        [ValidateNotNullOrEmpty]
        public virtual string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Security Provider name")]
        [ValidateSet(
            MNM.SecurityProviderName.ZScaler,
            MNM.SecurityProviderName.IBoss,
            MNM.SecurityProviderName.Checkpoint,
            IgnoreCase = false)]
        public string SecurityProviderName { get; set; }

        [Parameter(
               Mandatory = false,
               ValueFromPipeline = true,
               HelpMessage = "The virtual hub Id that the security partner provider is attached to")]
        public PSVirtualHub VirtualHub { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The Id of the VirtualHub this VpnGateway needs to be associated with.")]
        [ResourceIdCompleter("Microsoft.Network/virtualHubs")]
        public string VirtualHubId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The Id of the VirtualHub this VpnGateway needs to be associated with.")]
        public string VirtualHubName { get; set; }

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

        public override void Execute()
        {

            base.Execute();

            var present = NetworkBaseCmdlet.IsResourcePresent(() => GetSecurityPartnerProvider(this.ResourceGroupName, this.Name));
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () => WriteObject(this.CreateSecurityPartnerProvider()),
                () => present);
        }

        private PSSecurityPartnerProvider CreateSecurityPartnerProvider()
        {

            string virtualHubResourceGroupName = this.ResourceGroupName; // default to common RG
            var resolvedVirtualHub = new VirtualHub();
            // Resolve and Set the Virtual Hub
            if (this.VirtualHubId != null) // When Id is provided
            {
                var resourceInfo = new ResourceIdentifier(VirtualHubId);
                virtualHubResourceGroupName = resourceInfo.ResourceGroupName;
                this.VirtualHubName = resourceInfo.ResourceName;
            }
            else if (this.VirtualHub != null) // When Hub is provided
            {
                this.VirtualHubName = this.VirtualHub.Name;
                virtualHubResourceGroupName = this.VirtualHub.ResourceGroupName;
            }

            if (!string.IsNullOrWhiteSpace(this.VirtualHubName))
            {
                resolvedVirtualHub = this.VirtualHubClient.Get(virtualHubResourceGroupName, this.VirtualHubName);
            }

            var securityPartnerProvider = new PSSecurityPartnerProvider()
            {
                Name = this.Name,
                ResourceGroupName = this.ResourceGroupName,
                Location = this.Location,
                VirtualHub = resolvedVirtualHub.Id == null? null: new SubResource() { Id = resolvedVirtualHub?.Id },
                SecurityProviderName = this.SecurityProviderName
            };

            // Map to the sdk object
            var securityPartnerProviderModel = NetworkResourceManagerProfile.Mapper.Map<MNM.SecurityPartnerProvider>(securityPartnerProvider);

            securityPartnerProviderModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            // Execute the Create Security Partner Provider call
            this.SecurityPartnerProviderClient.CreateOrUpdate(this.ResourceGroupName, this.Name, securityPartnerProviderModel);

            return this.GetSecurityPartnerProvider(this.ResourceGroupName, this.Name);
        }
    }
}
