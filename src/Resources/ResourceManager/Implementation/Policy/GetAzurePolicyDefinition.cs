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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.ErrorResponses;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Management.Automation;
    using System.Threading.Tasks;

    /// <summary>
    /// Gets the policy definition.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicyDefinition), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "Metadata", "Mode", "Parameters", "PolicyRule", "PolicyType" })]
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "PolicyDefinition", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet), OutputType(typeof(PsPolicyDefinition))]
    public class GetAzurePolicyDefinitionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy definition name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionNameHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy definition id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy definition management group name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.ManagementGroupNameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionManagementGroupHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.BuiltinFilterParameterSet, Mandatory = false, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionManagementGroupHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.CustomFilterParameterSet, Mandatory = false, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionManagementGroupHelp)]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupName { get; set; }

        /// <summary>
        /// Gets or sets the policy definition subscription is parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.SubscriptionIdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionSubscriptionIdHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.BuiltinFilterParameterSet, Mandatory = false, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionSubscriptionIdHelp)]
        [Parameter(ParameterSetName = PolicyCmdletBase.CustomFilterParameterSet, Mandatory = false, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionSubscriptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the builtin switch.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.BuiltinFilterParameterSet, Mandatory = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionBuiltInFilterHelp)]
        public SwitchParameter Builtin { get; set; }

        /// <summary>
        /// Gets or sets the custom switch.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.CustomFilterParameterSet, Mandatory = true, HelpMessage = PolicyHelpStrings.GetPolicyDefinitionCustomFilterHelp)]
        public SwitchParameter Custom { get; set; }

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
            var listFilter = this.GetListFilter(this.Builtin, this.Custom);
            PaginatedResponseHelper.ForEach(
                getFirstPage: () => this.GetResources(listFilter),
                getNextPage: nextLink => this.GetNextLink<JObject>(nextLink),
                cancellationToken: this.CancellationToken,
                action: resources => this.WriteObject(sendToPipeline: this.GetFilteredOutputPolicyDefinitions(listFilter, resources), enumerateCollection: true));
        }

        /// <summary>
        /// Queries the ARM cache and returns the cached resource that matches the query specified.
        /// </summary>
        /// <param name="policyTypeFilter">The policy type filter.</param>
        private async Task<ResponseWithContinuation<JObject[]>> GetResources(ListFilter policyTypeFilter)
        {
            string resourceId = this.GetResourceId();
            var odataFilter = policyTypeFilter != ListFilter.None ? string.Format(PolicyCmdletBase.PolicyTypeFilterFormat, policyTypeFilter.ToString()) : null;

            var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyDefinitionApiVersion : this.ApiVersion;

            if (!string.IsNullOrEmpty(ResourceIdUtility.GetResourceName(resourceId)))
            {
                JObject resource;
                try
                {
                    resource = await this
                        .GetResourcesClient()
                        .GetResource<JObject>(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            cancellationToken: this.CancellationToken.Value)
                        .ConfigureAwait(continueOnCapturedContext: false);
                }
                catch (ErrorResponseMessageException ex)
                {
                    if (!ex.Message.StartsWith("PolicyDefinitionNotFound", StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(this.Name))
                    {
                        throw;
                    }

                    resourceId = this.GetBuiltinResourceId();
                    resource = await this
                        .GetResourcesClient()
                        .GetResource<JObject>(
                            resourceId: resourceId,
                            apiVersion: apiVersion,
                            cancellationToken: this.CancellationToken.Value)
                        .ConfigureAwait(continueOnCapturedContext: false);
                }

                return resource.TryConvertTo(out ResponseWithContinuation<JObject[]> retVal) && retVal.Value != null
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
                    odataQuery: odataFilter)
                .ConfigureAwait(continueOnCapturedContext: false);
            }
        }

        /// <summary>
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.MakePolicyDefinitionId(this.ManagementGroupName, this.SubscriptionId, this.Name);
        }

        /// <summary>
        /// Gets the resource Id assuming the name is for a builtin
        /// </summary>
        private string GetBuiltinResourceId()
        {
            return $"/{Constants.Providers}/{Constants.MicrosoftAuthorizationPolicyDefinitionType}/{this.Name}";
        }
    }
}
