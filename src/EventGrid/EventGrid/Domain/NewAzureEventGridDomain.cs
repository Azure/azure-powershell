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
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridDomain",
        SupportsShouldProcess = true,
        DefaultParameterSetName = DomainNameParameterSet),
    OutputType(typeof(PSDomain))]

    public class NewAzureEventGridDomain : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.DomainNameHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/domains", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("DomainName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.DomainLocationHelp,
            ParameterSetName = DomainNameParameterSet)]
        [LocationCompleter("Microsoft.EventGrid/domains")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = DomainNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputSchemaHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ValidateSet(EventGridModels.InputSchema.EventGridSchema, EventGridModels.InputSchema.CustomEventSchema, EventGridModels.InputSchema.CloudEventSchemaV10, IgnoreCase = true)]
        public string InputSchema { get; set; } = EventGridModels.InputSchema.EventGridSchema;

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputMappingFieldHelp,
            ParameterSetName = DomainNameParameterSet)]
        public Hashtable InputMappingField { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InputMappingDefaultValueHelp,
            ParameterSetName = DomainNameParameterSet)]
        public Hashtable InputMappingDefaultValue { get; set; }

        /// <summary>
        /// Hashtable which represents the Inbound IP Rules.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.InboundIpRuleHelp,
            ParameterSetName = DomainNameParameterSet)]
        public Hashtable InboundIpRule { get; set; }

        /// <summary>
        /// Public network access.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PublicNetworkAccessHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateSet(EventGridConstants.Enabled, EventGridConstants.Disabled, IgnoreCase = true)]
        [ValidateNotNullOrEmpty]
        public string PublicNetworkAccess { get; set; } = EventGridConstants.Enabled;

        /// <summary>
        /// DisableLocalAuth
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DisableLocalAuthHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter DisableLocalAuth { get; set; }

        /// <summary>
        /// DisableLocalAuth
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AutoCreateTopicWithFirstSubscriptionHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AutoCreateTopicWithFirstSubscription { get; set; }

        /// <summary>
        /// DisableLocalAuth
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.AutoDeleteTopicWithLastSubscriptionHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AutoDeleteTopicWithLastSubscription { get; set; }

        /// <summary>
        /// string which represents the IdentityType.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityTypeHelp,
            ParameterSetName = DomainNameParameterSet)]
        [ValidateSet("SystemAssigned", "UserAssigned", "SystemAssigned, UserAssigned", "None", IgnoreCase = true)]
        public string IdentityType { get; set; }

        /// <summary>
        /// string array of identity ids for user assigned identities
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.IdentityIdsHelp)]
        public string[] IdentityId { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Domain
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            Dictionary<string, string> inputMappingFieldsDictionary = TagsConversionHelper.CreateTagDictionary(this.InputMappingField, true);
            Dictionary<string, string> inputMappingDefaultValuesDictionary = TagsConversionHelper.CreateTagDictionary(this.InputMappingDefaultValue, true);
            Dictionary<string, string> inboundIpRuleDictionary = TagsConversionHelper.CreateTagDictionary(this.InboundIpRule, true);

            EventGridUtils.ValidateInputMappingInfo(this.InputSchema, inputMappingFieldsDictionary, inputMappingDefaultValuesDictionary);

            Dictionary<string, UserIdentityProperties> userAssignedIdentities = null;
            if (IdentityId != null && IdentityId.Length > 0)
            {
                userAssignedIdentities = new Dictionary<string, UserIdentityProperties>();
                foreach (string identityId in IdentityId)
                {
                    userAssignedIdentities.Add(identityId, new UserIdentityProperties());
                }
            }

            if (this.ShouldProcess(this.Name, $"Create a new EventGrid domain {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                Domain domain = this.Client.CreateDomain(
                    this.ResourceGroupName,
                    this.Name,
                    this.Location,
                    tagDictionary,
                    InputSchema,
                    inputMappingFieldsDictionary,
                    inputMappingDefaultValuesDictionary,
                    inboundIpRuleDictionary,
                    this.PublicNetworkAccess,
                    this.IdentityType,
                    userAssignedIdentities,
                    this.DisableLocalAuth.IsPresent,
                    this.AutoCreateTopicWithFirstSubscription.IsPresent,
                    this.AutoDeleteTopicWithLastSubscription.IsPresent);

                PSDomain psDomain = new PSDomain(domain);
                this.WriteObject(psDomain);
            }
        }
    }
}
