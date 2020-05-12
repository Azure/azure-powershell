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

namespace Microsoft.Azure.Commands.Network
{
    using AutoMapper;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Security;
    using Microsoft.Azure.Commands.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Network;
    using Microsoft.WindowsAzure.Commands.Common;
    using MNM = Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWan",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualWan))]
    public class NewAzureRmVirtualWanCommand : VirtualWanBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Location for this resource.")]
        [LocationCompleter("Microsoft.Network/virtualWans")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Allow vnet to vnet traffic for VirtualWan.")]
        public SwitchParameter AllowVnetToVnetTraffic { get; set; }

        [Parameter(
           Mandatory = false,
           HelpMessage = "Allow branch to branch traffic for VirtualWan.")]
        public SwitchParameter AllowBranchToBranchTraffic { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The type of the Virtual Wan.")]
        [PSArgumentCompleter("Basic", "Standard")]
        public string VirtualWANType { get; set; }

        [Parameter(
            Mandatory = false, 
            HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            ConfirmAction(
                Properties.Resources.CreatingResourceMessage,
                this.Name,
                () =>
                {
                    WriteVerbose(String.Format(Properties.Resources.CreatingLongRunningOperationMessage, this.ResourceGroupName, this.Name));
                    WriteObject(this.CreateVirtualWan());
                });
        }

        private PSVirtualWan CreateVirtualWan()
        {
            if (this.IsVirtualWanPresent(this.ResourceGroupName, this.Name))
            {
                throw new PSArgumentException(string.Format(Properties.Resources.ResourceAlreadyPresentInResourceGroup, this.Name, this.ResourceGroupName));
            }

            var virtualWan = new PSVirtualWan();
            virtualWan.Name = this.Name;
            virtualWan.ResourceGroupName = this.ResourceGroupName;
            virtualWan.Location = this.Location;
            virtualWan.AllowBranchToBranchTraffic = this.AllowBranchToBranchTraffic.IsPresent;
            virtualWan.AllowVnetToVnetTraffic = true;

            if(string.IsNullOrWhiteSpace(this.VirtualWANType))
            {
                virtualWan.VirtualWANType = "Standard";
            }

            var virtualWanModel = NetworkResourceManagerProfile.Mapper.Map<MNM.VirtualWAN>(virtualWan);
            virtualWanModel.Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true);

            this.VirtualWanClient.CreateOrUpdate(this.ResourceGroupName, this.Name, virtualWanModel);

            return this.GetVirtualWan(this.ResourceGroupName, this.Name);
        }
    }
}
