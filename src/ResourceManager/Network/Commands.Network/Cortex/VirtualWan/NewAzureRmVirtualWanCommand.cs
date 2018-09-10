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
    using System.Linq;

    [Cmdlet(VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VirtualWan",
        SupportsShouldProcess = true),
        OutputType(typeof(PSVirtualWan))]
    public class NewAzureRmVirtualWanCommand : VirtualWanBaseCmdlet
    {
        [Alias("ResourceName", "VirtualWanName")]
        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource name.")]
        [ValidateNotNullOrEmpty]
        public virtual string Name { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "The list of PSP2SVpnServerConfigurations that are associated with this VirtualWan.")]
        public PSP2SVpnServerConfiguration[] P2SVpnServerConfiguration { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "location.")]
        [LocationCompleter]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Allow vnet to vnet traffic for VirtualWan.")]
        [PSDefaultValue(Help = "$false", Value = false)]
        public bool AllowVnetToVnetTraffic { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Allow branch to branch traffic for VirtualWan.")]
        [PSDefaultValue(Help = "$true", Value = true)]
        public bool AllowBranchToBranchTraffic { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "A hashtable which represents resource tags.")]
        public Hashtable Tag { get; set; }

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
                    WriteObject(this.CreateVirtualWan());
                });
        }

        private PSVirtualWan CreateVirtualWan()
        {
            var virtualWan = new PSVirtualWan();
            virtualWan.Name = this.Name;
            virtualWan.ResourceGroupName = this.ResourceGroupName;
            virtualWan.Location = this.Location;
            virtualWan.AllowBranchToBranchTraffic = this.AllowBranchToBranchTraffic;
            virtualWan.AllowVnetToVnetTraffic = this.AllowVnetToVnetTraffic;

            // PSP2SVpnServerConfigurations, if specified
            virtualWan.P2SVpnServerConfigurations = new List<PSP2SVpnServerConfiguration>();
            if (this.P2SVpnServerConfiguration != null && this.P2SVpnServerConfiguration.Any())
            {
                virtualWan.P2SVpnServerConfigurations.AddRange(this.P2SVpnServerConfiguration);
            }

            return this.CreateOrUpdateVirtualWan(this.ResourceGroupName, this.Name, virtualWan, this.Tag);
        }
    }
}
