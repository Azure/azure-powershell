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
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "NetworkManagerStaticMember", SupportsShouldProcess = true), OutputType(typeof(PSNetworkManagerStaticMember))]
    public class SetAzNetworkManagerStaticMember : NetworkManagerStaticMemberBaseCmdlet
    {
        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The network manager name.")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers", "ResourceGroupName")]
        [SupportsWildcards]
        public virtual string NetworkManagerName { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource group name.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [SupportsWildcards]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Group")]
        [ValidateNotNullOrEmpty]
        [ResourceNameCompleter("Microsoft.Network/networkManagers/networkGroups/staticMembers", "ResourceGroupName", "NetworkManagerName", "NetworkManagerGroupName")]
        [SupportsWildcards]
        public virtual string NetworkGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The Network Manager Static Member")]
        public PSNetworkManagerStaticMember StaticMember { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            if (this.ShouldProcess(StaticMember.Name, VerbsLifecycle.Restart))
            {
                base.Execute();

                if (!this.IsNetworkManagerStaticMemberPresent(this.ResourceGroupName, this.NetworkManagerName, this.NetworkGroupName, this.StaticMember.Name))
                {
                    throw new ArgumentException(string.Format(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound, this.StaticMember.Name));
                }

                // Map to the sdk object
                var staticMemberModel = NetworkResourceManagerProfile.Mapper.Map<MNM.StaticMember>(this.StaticMember);

                // Execute the PUT NetworkManagerGroup call
                var groupResponse = this.NetworkManagerStaticMemberClient.CreateOrUpdate(staticMemberModel, this.ResourceGroupName, this.NetworkManagerName, this.NetworkGroupName, this.StaticMember.Name);
                var psNetworGroup = this.ToPsNetworkManagerStaticMember(groupResponse);
                WriteObject(psNetworGroup);
            }
        }
    }
}
