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
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualApplianceSite", SupportsShouldProcess = true, DefaultParameterSetName = ResourceNameParameterSet), OutputType(typeof(bool))]
    public class RemoveVirtualApplianceSiteCommand : VirtualApplianceSiteBaseCmdlet
    {
        private const string ResourceNameParameterSet = "ResourceNameParameterSet";
        private const string ResourceIdParameterSet = "ResourceIdParameterSet";
        private const string ResourceObjectParameterSet = "ResourceObjectParameterSet";

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
            HelpMessage = "The resource ID of the Network Virtual Appliance associated with this site.")]
        [ValidateNotNullOrEmpty]
        public virtual string NetworkVirtualApplianceId { get; set; }

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
            HelpMessage = "The resource id.")]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceId { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ParameterSetName = ResourceObjectParameterSet,
            HelpMessage = "The virtual appliance site object.")]
        [ValidateNotNullOrEmpty]
        public virtual PSVirtualApplianceSite VirtualApplianceSite { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            if (ParameterSetName.Equals(ResourceIdParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(this.ResourceId);
                this.NvaName = GetResourceName(this.ResourceId, "Microsoft.Network/networkVirtualAppliances", "virtualApplianceSites");
                this.Name = GetResourceName(this.ResourceId, "virtualAppliancesites");
            }
            else if (ParameterSetName.Equals(ResourceObjectParameterSet))
            {
                this.ResourceGroupName = GetResourceGroup(VirtualApplianceSite.Id);
                this.Name = VirtualApplianceSite.Name;
                this.NvaName = GetResourceName(VirtualApplianceSite.Id, "Microsoft.Network/networkVirtualAppliances", "virtualApplianceSites");
            }
            else
            {
                this.NvaName = GetResourceName(NetworkVirtualApplianceId, "Microsoft.Network/networkVirtualAppliances");
                string nvaRg = GetResourceGroup(NetworkVirtualApplianceId);
                if (!nvaRg.Equals(this.ResourceGroupName))
                {
                    throw new Exception("The resource group for Network Virtual Appliance is not same as that of site.");
                }
            }
            
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.RemovingResource, Name),
                Properties.Resources.RemoveResourceMessage,
                Name,
                () =>
                {
                    this.VirtualApplianceSitesClient.Delete(this.ResourceGroupName, this.NvaName, this.Name);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}
