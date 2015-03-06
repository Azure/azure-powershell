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
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Resources.Models;
    using Microsoft.Azure.Common.Authentication.Models;
    using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

    /// <summary>
    /// Moves existing resources to a new resource group or subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureResource", SupportsShouldProcess = true, DefaultParameterSetName = MoveAzureResourceCommand.BySubscriptionId), OutputType(typeof(bool))]
    public class MoveAzureResourceCommand : ResourcesBaseCmdlet
    {
        /// <summary>
        /// The name by subscription parameter set
        /// </summary>
        public const string BySubscriptionId = "BySubscriptionId";

        /// <summary>
        /// The name by subscription parameter set
        /// </summary>
        public const string BySubscriptionName = "BySubscriptionName";

        /// <summary>
        /// Caches the current resource ids to get all resource ids in the pipeline
        /// </summary>
        private readonly ConcurrentBag<string> resourceIds = new ConcurrentBag<string>();

        /// <summary>
        /// Gets or sets the destination resource group.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group into which the resources are to be moved.")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetResourceGroup")]
        public string DestinationResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the id of the destination subscription.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The Id of the subscription to move the resources into.", ParameterSetName = MoveAzureResourceCommand.BySubscriptionId)]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "SubscriptionId")]
        public string DestinationSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the id of the destination subscription.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the subscription to move the resources into.", ParameterSetName = MoveAzureResourceCommand.BySubscriptionName)]
        [ValidateNotNullOrEmpty]
        public string DestinationSubscriptionName { get; set; }

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
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The Ids of the resources to move.")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceId { get; set; }
 
        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            var resourceIdsToUse = this.resourceIds
                .Concat(this.ResourceId)
                .Distinct(StringComparer.InvariantCultureIgnoreCase)
                .ToArray();

            if (resourceIdsToUse.Any(string.IsNullOrWhiteSpace))
            {
                throw new PSArgumentException(ProjectResources.InvalidFormatOfResourceId);
            }

            string sourceResourceGroupId, destinationResourceGroupId;
            AzureSubscription sourceSubscription, destinationSubscription;

            this.DetermineSourceSubscriptionAndResourceGrop(resourceIdsToUse, out sourceSubscription, out sourceResourceGroupId);
            this.DetermineDestinationSubscriptionAndResourceGroupId(out destinationSubscription, out destinationResourceGroupId);

            var resourcesMessage = Environment.NewLine + string.Join(Environment.NewLine, resourceIdsToUse);

            var actionMessage = destinationSubscription.Id == sourceSubscription.Id
                ? string.Format(ProjectResources.MovingResources, this.DestinationResourceGroupName, resourcesMessage)
                : string.Format(ProjectResources.MovingResourcesIntoNewSubscription, this.DestinationResourceGroupName, destinationSubscription.Name, destinationSubscription.Id, resourcesMessage);

            this.ConfirmAction(
                this.Force,
                actionMessage,
                ProjectResources.MoveResourcesMessage,
                resourcesMessage,
                () => this.ResourcesClient.MoveResources(sourceResourceGroupId, destinationResourceGroupId, resourceIdsToUse));

            if (this.PassThru)
            {
                this.WriteObject(true);
            }
        }

        /// <summary>
        /// Process all resource ids in the pipeline.
        /// </summary>
        protected override void EndProcessing()
        {
            base.ProcessRecord();
        }

        /// <summary>
        /// Caches the current resource id to process them in batch
        /// </summary>
        protected override void ProcessRecord()
        {
            foreach (var resourceId in this.ResourceId)
            {
                this.resourceIds.Add(resourceId);
            }
        }
        /// <summary>
        /// Determines the destination subscription id
        /// </summary>
        private AzureSubscription DetermineDestinationSubscription()
        {
            if (string.IsNullOrWhiteSpace(this.DestinationSubscriptionId) &&
                string.IsNullOrWhiteSpace(this.DestinationSubscriptionName))
            {
                return this.Profile.DefaultSubscription;
            }

            if (string.IsNullOrWhiteSpace(this.DestinationSubscriptionName))
            {
                var subscription = this.Profile.Subscriptions.Values
                    .FirstOrDefault(sub =>
                        string.Equals(sub.Id.ToString(), this.DestinationSubscriptionId, StringComparison.InvariantCultureIgnoreCase));

                if (subscription == null)
                {
                    throw new PSArgumentException(
                        string.Format(
                            ProjectResources.SubscriptionWithTheSpecifiedIdNotFount,
                            this.DestinationSubscriptionId));
                }

                return subscription;
            }

            var subscriptionToUse = string.Equals(this.Profile.DefaultSubscription.Name, this.DestinationSubscriptionName, StringComparison.OrdinalIgnoreCase)
                ? this.Profile.DefaultSubscription
                : this.Profile.Subscriptions.Values
                    .FirstOrDefault(subscription =>
                        string.Equals(
                            this.DestinationSubscriptionName,
                            subscription.Name,
                            StringComparison.OrdinalIgnoreCase));

            if (subscriptionToUse == null)
            {
                throw new PSArgumentException(
                    string.Format(
                        ProjectResources.SubscriptionWithTheSpecifiedNameNotFount,
                        this.DestinationSubscriptionName));
            }

            return subscriptionToUse;
        }

        /// <summary>
        /// Determines the destination subscription and resource group
        /// </summary>
        /// <param name="destinationSubscription">The destination subscription</param>
        /// <param name="destinationResourceGroupId">The destination resource group id</param>
        private void DetermineDestinationSubscriptionAndResourceGroupId(out AzureSubscription destinationSubscription, out string destinationResourceGroupId)
        {
            destinationSubscription = this.DetermineDestinationSubscription();
            destinationResourceGroupId = string.Format("/subscriptions/{0}/resourceGroups/{1}", destinationSubscription.Id, this.DestinationResourceGroupName);
        }

        /// <summary>
        /// Determines the source subscription and resource group.
        /// </summary>
        /// <param name="resourceIdsToUse">The resource Ids.</param>
        /// <param name="sourceSubscription">The source subscription</param>
        /// <param name="sourceResourceGroupId">The source resource group Id.</param>
        private void DetermineSourceSubscriptionAndResourceGrop(string[] resourceIdsToUse, out AzureSubscription sourceSubscription, out string sourceResourceGroupId)
        {
            var sourceResourceIdentifiers = this.ResourcesClient.ParseResourceIds(resourceIdsToUse);

            var sourceResourceGroups = sourceResourceIdentifiers
                .Select(resourceIdentifier => resourceIdentifier.ResourceGroupName)
                .Distinct(StringComparer.InvariantCulture)
                .ToArray();

            if (sourceResourceGroups.Length != 1)
            {
                throw new PSArgumentException(ProjectResources.MovingResourcesFromDifferentSourceResourceGroupsNotAllowed);
            }

            var sourceSubscriptions = sourceResourceIdentifiers
                .Select(resourceIdentifier => resourceIdentifier.Subscription)
                .Distinct(StringComparer.InvariantCulture)
                .ToArray();

            if (sourceSubscriptions.Length != 1)
            {
                throw new PSArgumentException(ProjectResources.MovingResourcesFromDifferentSubscriptionsIsNotAllowed);
            }

            var subId = sourceSubscriptions.Single();

            if (new Guid(subId) != this.Profile.DefaultSubscription.Id)
            {
                throw new PSArgumentException(ProjectResources.MovingResourcesFromNonDefaultSubscriptionNotAllowed);
            }

            sourceSubscription = this.Profile.DefaultSubscription;

            sourceResourceGroupId = sourceResourceGroups.Single();
        }
    }
}
