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
    using System;
    using System.Management.Automation;

    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

    using Newtonsoft.Json.Linq;
    using Policy;

    /// <summary>
    /// Creates a policy exemption.
    /// </summary>
    [CmdletOutputBreakingChangeWithVersion(
        typeof(PsPolicyExemption), deprecateByAzVersion: "11.0.0", deprecateByVersion: "7.0.0", DeprecatedOutputProperties = new[] { "Properties" },
        NewOutputProperties = new[] { "Description", "DisplayName", "ExemptionCategory", "ExpiresOn", "Metadata", "PolicyAssignmentId", "PolicyDefinitionReferenceIds" })]
    [Cmdlet(VerbsCommon.New, AzureRMConstants.AzureRMPrefix + "PolicyExemption", DefaultParameterSetName = PolicyCmdletBase.DefaultParameterSet, SupportsShouldProcess = true), OutputType(typeof(PsPolicyExemption))]
    public class NewAzurePolicyExemptionCmdlet : PolicyCmdletBase
    {
        /// <summary>
        /// Gets or sets the policy exemption name parameter.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionNameHelp)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption scope parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionScopeHelp)]
        [ValidateNotNullOrEmpty]
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption display name parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionDisplayNameHelp)]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption description parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionDescriptionHelp)]
        [ValidateNotNullOrEmpty]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption category
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionCategoryHelp)]
        [ValidateSet(PolicyExemptionCategory.Waiver, PolicyExemptionCategory.Mitigated)]
        public string ExemptionCategory { get; set; }

        /// <summary>
        /// Gets or sets the policy exemption policy assignment Id.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionPolicyAssignmentIdHelp)]
        public PsPolicyAssignment PolicyAssignment { get; set; }

        /// <summary>
        /// Gets or sets the policy definition reference ID list when the associated policy assignment is for a policy set (initiative).
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionPolicyDefinitionReferenceIdHelp)]
        [ValidateNotNullOrEmpty]
        public string[] PolicyDefinitionReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the policy exemption.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionExpiresOnHelp)]
        public DateTime? ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the new policy exemption metadata parameter
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = PolicyHelpStrings.NewPolicyExemptionMetadataHelp)]
        [ValidateNotNullOrEmpty]
        public string Metadata { get; set; }

        /// <summary>
        /// Executes the cmdlet.
        /// </summary>
        protected override void OnProcessRecord()
        {
            base.OnProcessRecord();
            if (this.PolicyAssignment != null && this.PolicyAssignment.PolicyAssignmentId == null)
            {
                throw new PSInvalidOperationException("The supplied PolicyAssignment must have a valid resource ID.");
            }

            if (string.IsNullOrEmpty(this.ExemptionCategory))
            {
                throw new PSInvalidOperationException("The supplied ExemptionCategory is invalid.");
            }

            if (this.ShouldProcess(this.Name, "Create Policy Exemption"))
            {
                string resourceId = GetResourceId();

                var apiVersion = string.IsNullOrWhiteSpace(this.ApiVersion) ? Constants.PolicyExemptionApiVersion : this.ApiVersion;

                var operationResult = this.GetResourcesClient()
                    .PutResource(
                        resourceId: resourceId,
                        apiVersion: apiVersion,
                        resource: this.GetResource(),
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
        /// Gets the resource Id
        /// </summary>
        private string GetResourceId()
        {
            return this.GetPolicyArtifactFullyQualifiedId(this.Scope, Constants.MicrosoftAuthorizationPolicyExemptionType, this.Name);
        }

        /// <summary>
        /// Constructs the resource
        /// </summary>
        private JToken GetResource()
        {
            var policyExemption = new PolicyExemption
            {
                Name = this.Name,
                Properties = new PolicyExemptionProperties
                {
                    DisplayName = this.DisplayName ?? null,
                    Description = this.Description ?? null,
                    ExemptionCategory = this.ExemptionCategory,
                    PolicyAssignmentId = this.PolicyAssignment.PolicyAssignmentId,
                    PolicyDefinitionReferenceIds = this.PolicyDefinitionReferenceId,
                    ExpiresOn = this.ExpiresOn?.ToUniversalTime(),
                    Metadata = this.Metadata == null ? null : this.GetObjectFromParameter(this.Metadata, nameof(this.Metadata)),
                }
            };

            return policyExemption.ToJToken();
        }
    }
}
