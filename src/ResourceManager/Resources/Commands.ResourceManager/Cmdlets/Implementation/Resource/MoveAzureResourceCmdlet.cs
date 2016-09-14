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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ResourceGroups;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Management.Automation;

    /// <summary>
    /// Moves existing resources to a new resource group or subscription.
    /// </summary>
    [Cmdlet(VerbsCommon.Move, "AzureRmResource", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class MoveAzureResourceCommand : ResourceManagerCmdletBase
    {
        /// <summary>
        /// Caches the current resource ids to get all resource ids in the pipeline
        /// </summary>
        private readonly ConcurrentBag<string> resourceIds = new ConcurrentBag<string>();

        /// <summary>
        /// Gets or sets the destination resource group.
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "The name of the resource group into which the resources are to be moved.")]
        [ValidateNotNullOrEmpty]
        [Alias("TargetResourceGroup")]
        public string DestinationResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the id of the destination subscription.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Id of the subscription to move the resources into.")]
        [ValidateNotNullOrEmpty]
        [Alias("Id", "SubscriptionId")]
        public Guid? DestinationSubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the ids of the resources to move.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The Ids of the resources to move.")]
        [ValidateNotNullOrEmpty]
        public string[] ResourceId { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        /// <summary>
        /// Collects subscription ids from the pipeline.
        /// </summary>
        protected override void OnProcessRecord()
        {
            foreach (var resourceId in this.ResourceId.CoalesceEnumerable())
            {
                this.resourceIds.Add(resourceId);
            }

            base.OnProcessRecord();
        }

        /// <summary>
        /// Finishes the pipeline execution and runs the cmdlet.
        /// </summary>
        protected override void OnEndProcessing()
        {
            this.ResourceId = this.resourceIds.DistinctArray();
            this.RunCmdlet();
            base.OnEndProcessing();
        }

        /// <summary>
        /// Executes the cmdlet
        /// </summary>
        private void RunCmdlet()
        {
            var resourceIdsToUse = this.resourceIds
                .Concat(this.ResourceId)
                .DistinctArray(StringComparer.InvariantCultureIgnoreCase);

            this.DestinationSubscriptionId = this.DestinationSubscriptionId ?? DefaultContext.Subscription.Id;

            var sourceResourceGroups = resourceIdsToUse
                .Select(resourceId => ResourceIdUtility.GetResourceGroupId(resourceId))
                .Where(resourceGroupId => !string.IsNullOrWhiteSpace(resourceGroupId))
                .DistinctArray(StringComparer.InvariantCultureIgnoreCase);

            var count = sourceResourceGroups.Count();
            if (count == 0)
            {
                throw new InvalidOperationException("At least one valid resource Id must be provided.");
            }
            else if (count > 1)
            {
                throw new InvalidOperationException(
                    string.Format("The resources being moved must all reside in the same resource group. The resources: {0}", resourceIdsToUse.ConcatStrings(", ")));
            }

            var sourceResourceGroup = sourceResourceGroups.Single();

            var destinationResourceGroup = ResourceIdUtility.GetResourceId(
                subscriptionId: this.DestinationSubscriptionId,
                resourceGroupName: this.DestinationResourceGroupName,
                resourceName: null,
                resourceType: null);

            this.ConfirmAction(
                this.Force,
                string.Format(
                    "Are you sure you want to move these resources to the resource group '{0}' the resources: {1}",
                    destinationResourceGroup,
                    Environment.NewLine.AsArray().Concat(resourceIdsToUse).ConcatStrings(Environment.NewLine)),
                "Moving the resources.",
                destinationResourceGroup,
                () =>
                {
                    var apiVersion = this
                        .DetermineApiVersion(
                            providerNamespace: Constants.MicrosoftResourceNamesapce,
                            resourceType: Constants.ResourceGroups)
                        .Result;

                    var parameters = new ResourceBatchMoveParameters
                    {
                        Resources = resourceIdsToUse,
                        TargetResourceGroup = destinationResourceGroup,
                    };

                    var operationResult = this.GetResourcesClient()
                        .InvokeActionOnResource<JObject>(
                            resourceId: sourceResourceGroup,
                            action: Constants.MoveResources,
                            apiVersion: apiVersion,
                            parameters: parameters.ToJToken(),
                            cancellationToken: this.CancellationToken.Value)
                        .Result;

                    var managementUri = this.GetResourcesClient()
                    .GetResourceManagementRequestUri(
                        resourceId: destinationResourceGroup,
                        apiVersion: apiVersion,
                        action: Constants.MoveResources);

                    var activity = string.Format("POST {0}", managementUri.PathAndQuery);

                    var result = this
                        .GetLongRunningOperationTracker(
                            activityName: activity,
                            isResourceCreateOrUpdate: false)
                        .WaitOnOperation(operationResult: operationResult);

                    this.TryConvertAndWriteObject(result);
                });
        }
    }
}