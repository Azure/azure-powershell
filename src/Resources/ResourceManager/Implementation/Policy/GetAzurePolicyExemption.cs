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
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Gets the policy exemption.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicyExemption), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "ExemptionCategory", "ExpiresOn", "Metadata", "PolicyAssignmentId", "PolicyDefinitionReferenceIds" })]
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "PolicyExemption", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PsPolicyExemption))]
    public class GetAzurePolicyExemptionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy exemption name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption scope parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionScopeHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.IncludeDescendentParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionScopeHelp)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption policy assignment id filter parameter
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionFilterHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionDoesNothingHelp)]
        [ValidateNotNullOrEmpty]
        public string PolicyAssignmentIdFilter { get; set; }

        /// <summary>
        /// Gets or sets the descendent scope switch
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.IncludeDescendentParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyExemptionIncludeDescendentsHelp)]
        public SwitchParameter IncludeDescendent { get; set; }

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
                getFirstPage: () => this.GetResources(Constants.PolicyExemptionApiVersion),
                getNextPage: nextLink => this.GetNextLink<JObject>(nextLink),
                cancellationToken: this.CancellationToken,
                action: resources => this.WriteObject(sendToPipeline: this.GetOutputPolicyExemptions(resources), enumerateCollection: true));
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource that matches the query specified.
        /// </summary>
        /// <param name="defaultApiVersion">The default api version</param>
        private async Task<ResponseWithContinuation<JObject[]>> GetResources(string defaultApiVersion)
        {
            string resourceId = this.GetResourceId();
            string filter = this.GetFilterParam(resourceId);

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? defaultApiVersion : this.ApiVersion;

            if (IsScopeLevelList(resourceId))
            {
                return await this
                    .GetResourcesClient()
                    .ListObjectColleciton<JObject>(
                        resourceCollectionId: resourceId,
                        apiVersion: apiVersion,
                        cancellationToken: this.CancellationToken.Value,
                        odataQuery: filter)
                    .ConfigureAwait(continueOnCapturedContext: false);
            }
            else if (IsResourceGet(resourceId))
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
            else
            {
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
        /// Returns true if it is scope level policy exemption list call
        /// </summary>
        private bool IsScopeLevelList(string resourceId)
        {
            return (!string.IsNullOrEmpty(this.Scope) && string.IsNullOrEmpty(this.Name))
                || (!string.IsNullOrEmpty(this.Scope) && string.IsNullOrEmpty(ResourceIdUtility.GetResourceName(resourceId)));
        }

        /// <summary>
        /// Returns true if it is a management group level policy exemption list call
        /// </summary>
        private bool IsManagementGroupScope(string resourceId)
        {
            return resourceId.StartsWith($"{Constants.ManagementGroupIdPrefix}", System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns true if it is a single policy exemption get
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
            return this.Id ?? this.GetPolicyArtifactFullyQualifiedId(this.Scope, Constants.MicrosoftAuthorizationPolicyExemptionType, this.Name);
        }

        /// <summary>
        /// Get exemption filters
        /// </summary>
        /// <param name="resourceId">The resource Id of the exemption</param>
        private string GetFilterParam(string resourceId)
        {
            var isManagementGroupScope = IsManagementGroupScope(resourceId);
            if (isManagementGroupScope && this.IncludeDescendent)
            {
                throw new PSInvalidOperationException($"The -{nameof(this.IncludeDescendent)} switch is not supported for management group scopes.");
            }

            if (!string.IsNullOrEmpty(this.PolicyAssignmentIdFilter))
            {
                return $"$filter=policyAssignmentId eq '{this.PolicyAssignmentIdFilter}'";
            }

            return this.IncludeDescendent ? null : "$filter=atScope()";
        }
    }
}
