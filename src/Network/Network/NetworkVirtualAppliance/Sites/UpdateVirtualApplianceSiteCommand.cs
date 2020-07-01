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
using Microsoft.Azure.Management.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using MNM = Microsoft.Azure.Management.Network.Models;
namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Update", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceSite", SupportsShouldProcess = true), OutputType(typeof(PSVirtualApplianceSite))]
    public class UpdateVirtualApplianceSiteCommand : VirtualApplianceSiteBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";

        private string NvaName;

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
            HelpMessage = "Network virtual appliance that this site is attached to.")]
        [ValidateNotNullOrEmpty]
        public string NetworkVirtualApplianceId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The address prefix for the site.")]
        [ValidateNotNullOrEmpty]
        public string AddresssPrefix { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Office 365 breakout policy.")]
        [ValidateNotNullOrEmpty]
        public PSOffice365PolicyProperties O365Policy { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }


        public override void Execute()
        {
            base.Execute();
            
            this.NvaName = GetResourceName(NetworkVirtualApplianceId, "Microsoft.Network/networkVirtualAppliances");
            string nvaRg = GetResourceGroup(NetworkVirtualApplianceId);
            if (!nvaRg.Equals(this.ResourceGroupName))
            {
                throw new Exception("The resource group for Network Virtual Appliance is not same as that of site.");
            }
            if(!(this.IsVirtualApplianceSitePresent(this.ResourceGroupName, this.NvaName, this.Name)))
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var site = UpdateVirtualApplianceSite();
                    WriteObject(site);
                });
        }

        private PSVirtualApplianceSite UpdateVirtualApplianceSite()
        {
            var psSite = this.GetVirtualApplianceSite(this.ResourceGroupName, this.NvaName, this.Name);
            psSite.O365Policy = this.O365Policy??psSite.O365Policy;
            psSite.AddressPrefix = this.AddresssPrefix??psSite.AddressPrefix;

            var siteModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualApplianceSite>(psSite);
            this.VirtualApplianceSitesClient.CreateOrUpdate(this.ResourceGroupName, this.NvaName, this.Name, siteModel);

            var nvaSite = this.GetVirtualApplianceSite(this.ResourceGroupName, this.NvaName, this.Name);
            return nvaSite;
        }
    }
}
