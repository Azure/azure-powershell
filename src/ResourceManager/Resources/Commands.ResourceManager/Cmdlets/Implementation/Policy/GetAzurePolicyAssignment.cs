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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Newtonsoft.Json.Linq;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Gets the policy assignment.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmPolicyAssignment", DefaultParameterSetName = GetAzurePolicyAssignmentCmdlet.ParameterlessSet), OutputType(typeof(PSObject))]
    public class GetAzurePolicyAssignmentCmdlet : PolicyAssignmentCmdletBase
    {
        /// <summary>
        /// The policy Id parameter set.
        /// </summary>
        internal const string PolicyAssignmentIdParameterSet = "The policy assignment Id parameter set.";

        /// <summary>
        /// The policy name parameter set.
        /// </summary>
        internal const string PolicyAssignmentNameParameterSet = "The policy assignment name parameter set.";

        /// <summary>
        /// The list all policy parameter set.
        /// </summary>
        internal const string ParameterlessSet = "The list all policy assignments parameter set.";

        /// <summary>
        /// Gets or sets the policy assignment name parameter.
        /// </summary>
        [Parameter(ParameterSetName = GetAzurePolicyAssignmentCmdlet.PolicyAssignmentNameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy assignment name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment scope parameter.
        /// </summary>
        [Parameter(ParameterSetName = GetAzurePolicyAssignmentCmdlet.PolicyAssignmentNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The policy assignment name.")]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = GetAzurePolicyAssignmentCmdlet.PolicyAssignmentIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified policy assignment Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment policy definition id parameter
        /// </summary>
        [Parameter(ParameterSetName = GetAzurePolicyAssignmentCmdlet.PolicyAssignmentIdParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified policy assignment Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [Parameter(ParameterSetName = GetAzurePolicyAssignmentCmdlet.PolicyAssignmentNameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The fully qualified policy assignment Id, including the subscription. e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}")]
        [ValidateNotNullOrEmpty]
        public string PolicyDefinitionId { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();

            this.RunCmdlet();
        }

        /// <summary>
        /// Contains the cmdlet's execution logic.
        /// </summary>
        private void RunCmdlet()
        {
            PaginatedResponseHelper.ForEach(
                getFirstPage: () => this.GetResources(),
                getNextPage: nextLink => this.GetNextLink<JObject>(nextLink),
                cancellationToken: this.CancellationToken,
                action: resources => this.WriteObject(sendToPipeline: this.GetOutputObjects(resources), enumerateCollection: true));
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource that match the query specified.
        /// </summary>
        private async Task<ResponseWithContinuation<JObject[]>> GetResources()
        {
            string resourceId = this.Id ?? this.GetResourceId();

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyApiVersion : this.ApiVersion;

            if (IsResourceGet(resourceId))
            {
                var resource = await this
                    .GetResourcesClient()
                    .GetResource<JObject>(
                        resourceId: resourceId,
                        apiVersion: apiVersion,
                        cancellationToken: this.CancellationToken.Value,
                        odataQuery: null)
                    .ConfigureAwait(continueOnCapturedContext: false);
                ResponseWithContinuation<JObject[]> retVal;
                return resource.TryConvertTo(out retVal) && retVal.Value != null
                    ? retVal
                    : new ResponseWithContinuation<JObject[]> { Value = resource.AsArray() };
            }
            else if (IsScopeLevelList(resourceId))//If only scope is given, list assignments call
            {
                string filter = "$filter=atScope()";
                return await this
                    .GetResourcesClient()
                    .ListObjectColleciton<JObject>(
                        resourceCollectionId: resourceId,
                        apiVersion: apiVersion,
                        cancellationToken: this.CancellationToken.Value,
                        odataQuery: filter)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            else
            {
                string filter = string.IsNullOrEmpty(this.PolicyDefinitionId)
                    ? null
                    : string.Format("$filter=policydefinitionid eq '{0}'", this.PolicyDefinitionId);

                return await this
                    .GetResourcesClient()
                    .ListObjectColleciton<JObject>(
                        resourceCollectionId: resourceId,
                        apiVersion: apiVersion,
                        cancellationToken: this.CancellationToken.Value,
                        odataQuery: filter)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Returns true if it is scope level policy assignment list call
        /// </summary>
        private bool IsScopeLevelList(string resourceId)
        {
            return (!string.IsNullOrEmpty(this.Scope) && string.IsNullOrEmpty(this.Name))
                || (!string.IsNullOrEmpty(this.Scope) && string.IsNullOrEmpty(ResourceIdUtility.GetResourceName(resourceId)));
        }

        /// <summary>
        /// Returns true if it is a single policy assignment get
        /// </summary>
        /// <param name="resourceId"></param>
        private bool IsResourceGet(string resourceId)
        {
            return (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Scope))
                || !string.IsNullOrEmpty(ResourceIdUtility.GetResourceName(resourceId));
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            var subscriptionId = DefaultContext.Subscription.Id;
            if (string.IsNullOrEmpty(this.Name) && string.IsNullOrEmpty(this.Scope))
            {
                return string.Format("/subscriptions/{0}/providers/{1}",
                    subscriptionId.ToString(),
                    Constants.MicrosoftAuthorizationPolicyAssignmentType);
            }
            else if (string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Scope))
            {
                return ResourceIdUtility.GetResourceId(
                    resourceId: this.Scope,
                    extensionResourceType: Constants.MicrosoftAuthorizationPolicyAssignmentType,
                    extensionResourceName: null);
            }
            return ResourceIdUtility.GetResourceId(
                resourceId: this.Scope,
                extensionResourceType: Constants.MicrosoftAuthorizationPolicyAssignmentType,
                extensionResourceName: this.Name);
        }
    }
}