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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectGroup", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSInterconnectGroup))]
    public partial class GetAzureRmInterconnectGroupCommand : InterconnectGroupBaseCmdlet
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the interconnect group.",
            ParameterSetName = ListParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the interconnect group.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the interconnect group.",
            ParameterSetName = ListParameterSet)]
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the interconnect group.",
            ParameterSetName = GetByNameParameterSet)]
        [ResourceNameCompleter("Microsoft.Network/interconnectGroups", "ResourceGroupName")]
        [Alias("ResourceName", "InterconnectGroupName")]
        [SupportsWildcards]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource id of the interconnect group.",
            ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        [Alias("InterconnectGroupId")]
        public string ResourceId { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }

            if (ShouldGetByName(this.ResourceGroupName, this.Name))
            {
                WriteObject(this.GetInterconnectGroup(this.ResourceGroupName, this.Name));
            }
            else
            {
                IEnumerable<MNM.InterconnectGroup> interconnectGroups;

                if (ShouldListByResourceGroup(this.ResourceGroupName, this.Name))
                {
                    var page = this.InterconnectGroupClient.List(this.ResourceGroupName);
                    interconnectGroups = ListNextLink<MNM.InterconnectGroup>.GetAllResourcesByPollingNextLink(page, this.InterconnectGroupClient.ListNext);
                }
                else
                {
                    var page = this.InterconnectGroupClient.ListAll();
                    interconnectGroups = ListNextLink<MNM.InterconnectGroup>.GetAllResourcesByPollingNextLink(page, this.InterconnectGroupClient.ListAllNext);
                }

                var psInterconnectGroups = interconnectGroups.Select(interconnectGroup => this.ToPsInterconnectGroup(interconnectGroup)).ToList();

                WriteObject(TopLevelWildcardFilter(this.ResourceGroupName, this.Name, psInterconnectGroups), true);
            }
        }
    }
}
