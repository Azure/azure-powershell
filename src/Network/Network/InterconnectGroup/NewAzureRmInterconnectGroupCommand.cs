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
using System.Collections;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.New, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectGroup", SupportsShouldProcess = true), OutputType(typeof(PSInterconnectGroup))]
    public partial class NewAzureRmInterconnectGroupCommand : InterconnectGroupBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name of the interconnect group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the interconnect group.")]
        [ResourceNameCompleter("Microsoft.Network/interconnectGroups", "ResourceGroupName")]
        [Alias("ResourceName", "InterconnectGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The location of the interconnect group.")]
        [LocationCompleter("Microsoft.Network/interconnectGroups")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The virtual machine size of the subgroups within the interconnect group.")]
        [ValidateNotNullOrEmpty]
        public string VMSize { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The scope of the interconnect group.")]
        [PSArgumentCompleter("None", "InfiniBand")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The scope of the subgroups within the interconnect group.")]
        [PSArgumentCompleter("None", "VerticalConnect")]
        [ValidateNotNullOrEmpty]
        public string SubgroupScope { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The number of nodes in each subgroup within the interconnect group.")]
        [ValidateRange(0, int.MaxValue)]
        public int SubgroupSize { get; set; }

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

            var present = this.IsInterconnectGroupPresent(this.ResourceGroupName, this.Name);

            ConfirmAction(
                Force.IsPresent,
                string.Format(Properties.Resources.OverwritingResource, Name),
                Properties.Resources.CreatingResourceMessage,
                Name,
                () =>
                {
                    var interconnectGroup = CreateInterconnectGroup();
                    WriteObject(interconnectGroup);
                },
                () => present);
        }

        private PSInterconnectGroup CreateInterconnectGroup()
        {
            var interconnectGroupModel = new MNM.InterconnectGroup
            {
                Location = this.Location,
                Scope = this.Scope,
                SubgroupProfile = new MNM.SubgroupProfile
                {
                    VMSize = this.VMSize,
                    Scope = this.SubgroupScope,
                    Size = this.MyInvocation.BoundParameters.ContainsKey(nameof(SubgroupSize)) ? (int?)this.SubgroupSize : null
                },
                Tags = TagsConversionHelper.CreateTagDictionary(this.Tag, validate: true)
            };

            this.InterconnectGroupClient.CreateOrUpdate(this.ResourceGroupName, this.Name, interconnectGroupModel);

            return this.GetInterconnectGroup(this.ResourceGroupName, this.Name);
        }
    }
}
