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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectGroupSubgroup", DefaultParameterSetName = GetByNameParameterSet), OutputType(typeof(PSSubgroup))]
    public partial class GetAzureRmInterconnectGroupSubgroupCommand : InterconnectGroupBaseCmdlet
    {
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the interconnect group.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the interconnect group.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/interconnectGroups", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string InterconnectGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the subgroup.",
            ParameterSetName = GetByNameParameterSet)]
        [Alias("ResourceName", "SubgroupName")]
        [SupportsWildcards]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the subgroup.",
            ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("SubgroupId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.InterconnectGroupName = resourceIdentifier.ParentResource.Split('/').Last();
                this.Name = resourceIdentifier.ResourceName;
            }

            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                var subgroup = this.SubgroupClient.Get(this.ResourceGroupName, this.InterconnectGroupName, this.Name);
                WriteObject(NetworkResourceManagerProfile.Mapper.Map<PSSubgroup>(subgroup));
            }
            else
            {
                var page = this.SubgroupClient.List(this.ResourceGroupName, this.InterconnectGroupName);
                var subgroups = ListNextLink<MNM.Subgroup>.GetAllResourcesByPollingNextLink(page, this.SubgroupClient.ListNext);

                var psSubgroups = subgroups.Select(subgroup => NetworkResourceManagerProfile.Mapper.Map<PSSubgroup>(subgroup)).ToList();

                WriteObject(SubResourceWildcardFilter(this.Name, psSubgroups), true);
            }
        }
    }
}
