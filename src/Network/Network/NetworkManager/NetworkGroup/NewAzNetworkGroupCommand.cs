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
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerGroup", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerGroup))]
    public class NewAzNetworkGroupCommand : NetworkGroupBaseCmdlet
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
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

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
         HelpMessage = "Description.")]
        public virtual string Description { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "Network Group member type. Valid values include 'VirtualNetwork' and 'Subnet'.")]
        [ValidateSet(
            MNM.GroupMemberType.VirtualNetwork,
            MNM.GroupMemberType.Subnet,
            IgnoreCase = true)]
        public string MemberType { get; set; }

        [Parameter(
           Mandatory = false,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "If match header.")]
        public string IfMatch { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation if you want to overwrite a resource")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();
            var present = this.IsNetworkGroupsPresent(this.ResourceGroupName, this.NetworkManagerName, this.Name);
            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var networkGroup = this.CreateNetworkGroup();
                    WriteObject(networkGroup);
                },
                () => present);
        }

        private PSNetworkManagerGroup CreateNetworkGroup()
        {
            var psNetworkGroup = new PSNetworkManagerGroup();
            psNetworkGroup.Name = this.Name;

            if (!string.IsNullOrEmpty(this.Description))
            {
                psNetworkGroup.Description = this.Description;
            }

            if (!string.IsNullOrEmpty(MemberType))
            {
                psNetworkGroup.MemberType = this.MemberType;
            }

            // Map to the sdk object
            var networkGroupModel = NetworkResourceManagerProfile.Mapper.Map<MNM.NetworkGroup>(psNetworkGroup);

            // Execute the Create NetworkGroup call
            if (string.IsNullOrEmpty(this.IfMatch))
            {
                this.IfMatch = null;
            }

            this.NetworkGroupClient.CreateOrUpdate(this.ResourceGroupName, this.NetworkManagerName, this.Name, networkGroupModel, this.IfMatch);
            var psNetworkManager = this.GetNetworkGroup(this.ResourceGroupName, this.NetworkManagerName, this.Name);

            return psNetworkManager;
        }
    }
}
