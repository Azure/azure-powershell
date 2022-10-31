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

using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.EventGrid.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.EventGrid.Models;
using Microsoft.Azure.Commands.EventGrid.Utilities;
using EventGridModels = Microsoft.Azure.Management.EventGrid.Models;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        "Update",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerTopic",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PartnerTopicNameParameterSet),
    OutputType(typeof(PSPartnerTopic))]

    public class UpdateAzureEventGridPartnerTopic : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerTopicInputObjectHelp,
            ParameterSetName = PartnerTopicInputObjectParameterSet)]
        public PSPartnerTopic InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.PartnerTopicNameHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerTopics", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerTopicName")]
        public string Name { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = PartnerTopicInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        /// <summary>
        /// string which represents the IdentityType.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = PartnerTopicInputObjectParameterSet)]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        /// <summary>
        /// string array of identity ids for user assigned identities
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = PartnerTopicNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp,
            ParameterSetName = PartnerTopicInputObjectParameterSet)]
        public string[] IdentityId { get; set; }

        public override void ExecuteCmdlet()
        {
            // Update an Event Grid Partner Topic
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            string resourceGroupName = string.Empty;
            string partnerTopicName = string.Empty;
            Dictionary<string, UserIdentityProperties> userAssignedIdentities = null;
            if (this.IdentityId != null && this.IdentityId.Length > 0)
            {
                userAssignedIdentities = new Dictionary<string, UserIdentityProperties>();
                foreach (string identityId in this.IdentityId)
                {
                    userAssignedIdentities.Add(identityId, new UserIdentityProperties());
                }
            }

            if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
                partnerTopicName = this.InputObject.Name;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                partnerTopicName = this.Name;
            }

            if (this.ShouldProcess(resourceGroupName, $"Update an EventGrid partner topic in Resource Group {resourceGroupName}"))
            {
                PartnerTopic partnerTopic = this.Client.UpdatePartnerTopic(
                    resourceGroupName,
                    partnerTopicName,
                    this.IdentityType,
                    userAssignedIdentities,
                    tagDictionary);

                PSPartnerTopic psPartnerTopic = new PSPartnerTopic(partnerTopic);
                this.WriteObject(psPartnerTopic);
            }
        }
    }
}
