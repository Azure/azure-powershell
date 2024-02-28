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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Sets the policy exemption.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicyExemption), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "ExemptionCategory", "ExpiresOn", "Metadata", "PolicyAssignmentId", "PolicyDefinitionReferenceIds" })]
    [Cmdlet(VerbsCommon.Set, AzureRMConstants.AzureRMPrefix + "PolicyExemption", DefaultParameterSetName = PolicyCmdletBase.NameParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsPolicyExemption))]
    public class SetAzurePolicyExemptionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy exemption name parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption scope parameter
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.NameParameterSet, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionScopeHelp)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy assignment id parameter
        /// </summary>
        [Alias("ResourceId")]
        [Parameter(ParameterSetName = PolicyCmdletBase.IdParameterSet, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionIdHelp)]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption category
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionCategoryHelp)]
        [ValidateSet(PolicyExemptionCategory.Waiver, PolicyExemptionCategory.Mitigated)]
        public string ExemptionCategory { get; set; }

        /// <summary>
        /// Gets or sets the policy definition reference ID list when the associated policy assignment is for a policy set (initiative).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionPolicyDefinitionReferenceIdHelp)]
        [ValidateNotNull]
        public string[] PolicyDefinitionReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionExpiresOnHelp)]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether to clear the expiration date and time of the policy exemption.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionClearExpirationHelp)]
        public SwitchParameter ClearExpiration { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption input object parameter.
        /// </summary>
        [Parameter(ParameterSetName = PolicyCmdletBase.InputObjectParameterSet, Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.SetPolicyExemptionInputObjectHelp)]
        public PsPolicyExemption InputObject { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.ShouldProcess(this.Name, "Update Policy Exemption"))
            {
                string resourceId = this.GetResourceId();
                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyExemptionApiVersion : this.ApiVersion;

                var operationResult = this.GetResourcesClient()
                    .PutResource(
                        resourceId: resourceId,
                        apiVersion: apiVersion,
                        resource: this.GetResource(resourceId, apiVersion),
                        cancellationToken: this.CancellationToken.Value,
                        odataQuery: null)
                    .Result;

                var managementUri = this.GetResourcesClient()
                   .GetResourceManagementRequestUri(
                       resourceId: resourceId,
                       apiVersion: apiVersion,
                       odataQuery: null);

                var activity = string.Format("PUT {0}", managementUri.PathAndQuery);
                var result = this.GetLongRunningOperationTracker(activityName: activity, isResourceCreateOrUpdate: true)
                    .WaitOnOperation(operationResult: operationResult);

                this.WriteObject(this.GetOutputPolicyExemptions(JObject.Parse(result)), enumerateCollection: true);
            }
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource(string resourceId, string apiVersion)
        {
            var resource = this.GetExistingResource(resourceId, apiVersion).Result.ToResource<PolicyExemptionProperties>();

            // get incoming object properties if present
            JObject inputMetadata = null;
            if (this.InputObject != null)
            {
                var newProperties = this.InputObject.Properties?.ToJToken();
                inputMetadata = newProperties["metadata"] as JObject;
            }

            var parameterMetadata = this.Metadata == null ? null : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata));
            var policyExemption = new PolicyExemption
            {
                Name = this.Name ?? this.InputObject?.Name ?? resource.Name,
                Properties = new PolicyExemptionProperties
                {
                    DisplayName = this.DisplayName ?? this.InputObject?.Properties?.DisplayName ?? resource.Properties.DisplayName,
                    Description = this.Description ?? this.InputObject?.Properties?.Description ?? resource.Properties.Description,
                    ExemptionCategory = this.ExemptionCategory ?? this.InputObject?.Properties?.ExemptionCategory ?? resource.Properties.ExemptionCategory,
                    PolicyAssignmentId = resource.Properties.PolicyAssignmentId,
                    PolicyDefinitionReferenceIds = this.PolicyDefinitionReferenceId ?? this.InputObject?.Properties?.PolicyDefinitionReferenceIds ?? resource.Properties.PolicyDefinitionReferenceIds,
                    ExpiresOn = this.ClearExpiration.IsPresent ? null : this.ExpiresOn?.ToUniversalTime() ?? this.InputObject?.Properties?.ExpiresOn ?? resource.Properties.ExpiresOn,
                    Metadata = parameterMetadata ?? inputMetadata ?? resource.Properties.Metadata,
                }
            };

            return policyExemption.ToJToken();
        }

        /// <summary>
        /// Gets the resource Id from the supplied PowerShell parameters.
        /// </summary>
        private string GetResourceId()
        {
            return this.Id ?? this.InputObject?.ResourceId ?? this.GetPolicyArtifactFullyQualifiedId(this.Scope, Constants.MicrosoftAuthorizationPolicyExemptionType, this.Name);
        }
    }
}
