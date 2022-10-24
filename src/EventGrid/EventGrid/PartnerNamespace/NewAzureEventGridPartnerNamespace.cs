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
using System;

namespace Microsoft.Azure.Commands.EventGrid
{
    [Cmdlet(
        VerbsCommon.New,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerNamespace",
        SupportsShouldProcess = true,
        DefaultParameterSetName = PartnerNamespaceNameParameterSet),
    OutputType(typeof(PSPartnerNamespace))]

    public class NewAzureEventGridPartnerNamespace : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = EventGridConstants.PartnerNamespaceNameHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [ResourceNameCompleter("Microsoft.EventGrid/partnerNamespaces", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        [Alias("PartnerNamespaceName")]
        public string Name { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = EventGridConstants.PartnerNamespaceLocationHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [LocationCompleter("Microsoft.EventGrid/partnerNamespaces")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        /// <summary>
        /// Hashtable which represents resource Tags.
        /// </summary>
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.TagsHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PrivateEndpointConnectionsHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public PSPrivateEndpointConnection[] PrivateEndpointConnection { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PSInboundIpRuleHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public PSInboundIpRule[] InboundIpRule { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerRegistrationFullyQualifiedIdHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public string PartnerRegistrationFullyQualifiedId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerNamespaceEndpointHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public string Endpoint { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PublicNetworkAccessHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public string PublicNetworkAccess { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.DisableLocalAuthHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        public bool? DisableLocalAuth { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = EventGridConstants.PartnerTopicRoutingModeHelp,
            ParameterSetName = PartnerNamespaceNameParameterSet)]
        [ValidateSet("SourceEventAttribute", "ChannelNameHeader", IgnoreCase = true)]
        public string PartnerTopicRoutingMode { get; set; }

        public override void ExecuteCmdlet()
        {
            // Create a new Event Grid Partner Namespace
            Dictionary<string, string> tagDictionary = TagsConversionHelper.CreateTagDictionary(this.Tag, true);
            List<PrivateEndpointConnection> privateEndpointConnectionsList = this.Client.CreatePrivateEndpointConnectionList(this.PrivateEndpointConnection);
            List<InboundIpRule> inboundIpRulesList = this.Client.CreateInboundIpRuleList(this.InboundIpRule);

            if (this.ShouldProcess(this.ResourceGroupName, $"Create a new EventGrid partner namespace {this.Name} in Resource Group {this.ResourceGroupName}"))
            {
                PartnerNamespace partnerNamespace = this.Client.CreatePartnerNamespace(
                    this.ResourceGroupName,
                    this.Name,
                    this.Location,
                    tagDictionary,
                    privateEndpointConnectionsList,
                    inboundIpRulesList,
                    this.PartnerRegistrationFullyQualifiedId,
                    this.Endpoint,
                    this.PublicNetworkAccess,
                    this.DisableLocalAuth,
                    this.PartnerTopicRoutingMode);

                PSPartnerNamespace psPartnerNamespace = new PSPartnerNamespace(partnerNamespace);
                this.WriteObject(psPartnerNamespace);
            }
        }
    }
}
