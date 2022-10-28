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
        VerbsCommon.Remove,
        ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "EventGridPartnerConfiguration",
        SupportsShouldProcess = true,
        DefaultParameterSetName = ResourceGroupNameParameterSet),
    OutputType(typeof(bool))]

    public class RemoveAzureEventGridPartnerConfiguration : AzureEventGridCmdletBase
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

        /// <summary>
        /// If present, do not ask for confirmation
        /// </summary>
        [Parameter(Mandatory = false,
           HelpMessage = EventGridConstants.ForceHelp)]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

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

            if (this.ShouldProcess(resourceGroupName, $"Remove an EventGrid partner configuration in Resource Group {resourceGroupName}"))
            {   
                this.Client.DeletePartnerConfiguration(resourceGroupName);

                if (this.PassThru)
                {
                    this.WriteObject(true);
                }
            }
        }
    }
}
