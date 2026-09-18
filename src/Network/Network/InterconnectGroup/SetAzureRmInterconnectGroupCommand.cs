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
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "InterconnectGroup", SupportsShouldProcess = true), OutputType(typeof(PSInterconnectGroup))]
    public partial class SetAzureRmInterconnectGroupCommand : InterconnectGroupBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The interconnect group object to update.")]
        [ValidateNotNull]
        [Alias("InputObject")]
        public PSInterconnectGroup InterconnectGroup { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            if (string.IsNullOrEmpty(this.InterconnectGroup.ResourceGroupName))
            {
                throw new ArgumentException("ResourceGroupName is required.");
            }

            if (string.IsNullOrEmpty(this.InterconnectGroup.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (!this.IsInterconnectGroupPresent(this.InterconnectGroup.ResourceGroupName, this.InterconnectGroup.Name))
            {
                throw new ArgumentException(Properties.Resources.ResourceNotFound);
            }

            var interconnectGroupModel = NetworkResourceManagerProfile.Mapper.Map<MNM.InterconnectGroup>(this.InterconnectGroup);
            interconnectGroupModel.Tags = TagsConversionHelper.CreateTagDictionary(this.InterconnectGroup.Tag, validate: true);

            ConfirmAction(
                true,
                string.Format(Properties.Resources.OverwritingResource, this.InterconnectGroup.Name),
                Properties.Resources.SettingResourceMessage,
                this.InterconnectGroup.Name,
                () =>
                {
                    this.InterconnectGroupClient.CreateOrUpdate(
                        this.InterconnectGroup.ResourceGroupName,
                        this.InterconnectGroup.Name,
                        interconnectGroupModel);

                    WriteObject(this.GetInterconnectGroup(this.InterconnectGroup.ResourceGroupName, this.InterconnectGroup.Name));
                });
        }
    }
}
