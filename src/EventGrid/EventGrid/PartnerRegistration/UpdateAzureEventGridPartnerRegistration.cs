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
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerRegistration",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PartnerRegistrationNameParameterSet),
    OutputType(typeof(PSPartnerRegistration))]

    public class UpdateAzureEventGridPartnerRegistration : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerRegistrationNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerRegistrationInputObjectHelp,
            ParameterSetName = PartnerRegistrationInputObjectParameterSet)]
        public PSPartnerRegistration InputObject { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.PartnerRegistrationNameHelp,
            ParameterSetName = PartnerRegistrationNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerRegistrations", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerRegistrationName")]
        public string Name { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = PartnerRegistrationInputObjectParameterSet)]
        public Hashtable Tag { get; set; }

        public override void ExecuteCmdlet()
        {
            // Update an Event Grid Partner Registration
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            string resourceGroupName = string.Empty;
            string partnerRegistrationName = string.Empty;

            if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
                partnerRegistrationName = this.InputObject.PartnerRegistrationName;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
                partnerRegistrationName = this.Name;
            }

            if (this.ShouldProcess(partnerRegistrationName, $"Update EventGrid partner registration {partnerRegistrationName} in Resource Group {resourceGroupName}"))
            {
                PartnerRegistration partnerRegistration = this.Client.UpdatePartnerRegistration(
                    resourceGroupName,
                    partnerRegistrationName,
                    tagDictionary);

                PSPartnerRegistration psPartnerRegistration = new PSPartnerRegistration(partnerRegistration);
                this.WriteObject(psPartnerRegistration);
            }
        }
    }
}
