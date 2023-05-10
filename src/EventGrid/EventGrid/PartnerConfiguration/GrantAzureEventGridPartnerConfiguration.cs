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
        "Grant",
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerConfiguration",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(PSPartnerConfiguration))]

    public class GrantAzureEventGridPartnerConfiguration : AzureEventGridCmdletBase
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.ResourceGroupNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        [Alias(AliasResourceGroup)]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerConfigurationInputObjectHelp,
            ParameterSetName = PartnerConfigurationInputObjectParameterSet)]
        public PSPartnerConfiguration InputObject { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerRegistrationImmutableIdHelp,
            ParameterSetName = PartnerConfigurationInputObjectParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerRegistrationImmutableIdHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        public Guid? PartnerRegistrationImmutableId { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerNameHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.PartnerNameHelp,
            ParameterSetName = PartnerConfigurationInputObjectParameterSet)]
        public string PartnerName { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.AuthorizationExpirationTimeHelp,
            ParameterSetName = ResourceGroupNameParameterSet)]
        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = EventGridConstants.AuthorizationExpirationTimeHelp,
            ParameterSetName = PartnerConfigurationInputObjectParameterSet)]
        public DateTime? AuthorizationExpirationTime { get; set; }

        public override void ExecuteCmdlet()
        {
            string resourceGroupName = string.Empty;

            if (this.InputObject != null)
            {
                resourceGroupName = this.InputObject.ResourceGroupName;
            }
            else
            {
                resourceGroupName = this.ResourceGroupName;
            }

            if (this.ShouldProcess(this.ResourceGroupName, $"Grant partner for EventGrid partner configuration in Resource Group {resourceGroupName}"))
            {
                PartnerConfiguration partnerConfiguration = this.Client.AuthorizePartnerConfiguration(
                    resourceGroupName,
                    this.PartnerRegistrationImmutableId,
                    this.PartnerName,
                    this.AuthorizationExpirationTime);
                PSPartnerConfiguration psPartnerConfiguration = new PSPartnerConfiguration(partnerConfiguration);
                this.WriteObject(psPartnerConfiguration);
            }
        }
    }
}
