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

namespace Microsoft.Azure.Commands.Resources
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;
    using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

    /// <summary>
    /// Moves existing resources to a new resource group or subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureResource", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class MoveAzureResourceCommand : ResourcesBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the destination resource group.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group into which the resources are to be moved.")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetResourceGroup")]
        public string DestinationResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the cmdlet is pass thru
        /// </summary>
        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        /// <summary>
        /// Gets or sets the ids of the resources to move.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Ids of the resources to move.")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceId { get; set; }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            if (this.ResourceId.Any(string.IsNullOrWhiteSpace))
            {
                throw new PSArgumentException(ProjectResources.InvalidFormatOfResourceId);
            }

            var sourceResourceGroups = this.ResourcesClient.ExtractResourceGroups(this.ResourceId);

            if (sourceResourceGroups.Length != 1)
            {
                throw new PSArgumentException(ProjectResources.MovingResourcesFromDifferentSourceResourceGroupsNotAllowed);
            }

            var sourceResourceGroup = sourceResourceGroups.Single();

            var targetMessage = Environment.NewLine + string.Join(Environment.NewLine, this.ResourceId);

            AzureOperationResponse response = null;

            this.ConfirmAction(
                this.Force,
                string.Format(ProjectResources.MovingResources, targetMessage),
                ProjectResources.MoveResourcesMessage,
                targetMessage,
                () => response = this.ResourcesClient.MoveResources(sourceResourceGroup, this.DestinationResourceGroupName, this.ResourceId));

            if (PassThru)
            {
                WriteObject(response != null && response.IsSuccessfulRequest());
            }
        }
    }
}
