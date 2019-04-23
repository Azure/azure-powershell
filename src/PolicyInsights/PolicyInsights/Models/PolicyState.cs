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

namespace Microsoft.Azure.Commands.PolicyInsights.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Policy state record.
    /// </summary>
    public class PolicyState
    {
        /// <summary>
        /// Gets the additional properties (i.e. query time generated properties like aggregations).
        /// </summary>
        public IDictionary<string, object> AdditionalProperties { get; }

        /// <summary>
        /// Gets timestamp for the policy state record.
        /// </summary>
        public DateTime? Timestamp { get; }

        /// <summary>
        /// Gets resource ID.
        /// </summary>
        public string ResourceId { get; }

        /// <summary>
        /// Gets policy assignment ID.
        /// </summary>
        public string PolicyAssignmentId { get; }

        /// <summary>
        /// Gets policy definition ID.
        /// </summary>
        public string PolicyDefinitionId { get; }

        /// <summary>
        /// Gets effective parameters for the policy assignment.
        /// </summary>
        public string EffectiveParameters { get; }

        /// <summary>
        /// Gets flag which states whether the resource is compliant
        /// against the policy assignment it was evaluated against.
        /// </summary>
        public bool? IsCompliant { get; }

        /// <summary>
        /// Gets subscription ID.
        /// </summary>
        public string SubscriptionId { get; }

        /// <summary>
        /// Gets resource type.
        /// </summary>
        public string ResourceType { get; }

        /// <summary>
        /// Gets resource location.
        /// </summary>
        public string ResourceLocation { get; }

        /// <summary>
        /// Gets resource group name.
        /// </summary>
        public string ResourceGroup { get; }

        /// <summary>
        /// Gets list of resource tags.
        /// </summary>
        public string ResourceTags { get; }

        /// <summary>
        /// Gets policy assignment name.
        /// </summary>
        public string PolicyAssignmentName { get; }

        /// <summary>
        /// Gets policy assignment owner.
        /// </summary>
        public string PolicyAssignmentOwner { get; }

        /// <summary>
        /// Gets policy assignment parameters.
        /// </summary>
        public string PolicyAssignmentParameters { get; }

        /// <summary>
        /// Gets policy assignment scope.
        /// </summary>
        public string PolicyAssignmentScope { get; }

        /// <summary>
        /// Gets policy definition name.
        /// </summary>
        public string PolicyDefinitionName { get; }

        /// <summary>
        /// Gets policy definition action, i.e. effect.
        /// </summary>
        public string PolicyDefinitionAction { get; }

        /// <summary>
        /// Gets policy definition category.
        /// </summary>
        public string PolicyDefinitionCategory { get; }

        /// <summary>
        /// Gets policy set definition ID, if the policy assignment is
        /// for a policy set.
        /// </summary>
        public string PolicySetDefinitionId { get; }

        /// <summary>
        /// Gets policy set definition name, if the policy assignment
        /// is for a policy set.
        /// </summary>
        public string PolicySetDefinitionName { get; }

        /// <summary>
        /// Gets policy set definition owner, if the policy assignment
        /// is for a policy set.
        /// </summary>
        public string PolicySetDefinitionOwner { get; }

        /// <summary>
        /// Gets policy set definition category, if the policy
        /// assignment is for a policy set.
        /// </summary>
        public string PolicySetDefinitionCategory { get; }

        /// <summary>
        /// Gets policy set definition parameters, if the policy
        /// assignment is for a policy set.
        /// </summary>
        public string PolicySetDefinitionParameters { get; }

        /// <summary>
        /// Gets comma seperated list of management group IDs, which
        /// represent the hierarchy of the management groups the resource is
        /// under.
        /// </summary>
        public string ManagementGroupIds { get; }

        /// <summary>
        /// Gets reference ID for the policy definition inside the
        /// policy set, if the policy assignment is for a policy set.
        /// </summary>
        public string PolicyDefinitionReferenceId { get; }

        /// <summary>
        /// Gets compliance state.
        /// </summary>
        public string ComplianceState { get; }

        /// <summary>
        /// Gets policy evaluation details.
        /// </summary>
        public PolicyEvaluationDetails PolicyEvaluationDetails { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolicyState" /> class.
        /// </summary>
        /// <param name="policyState">Policy state.</param>
        public PolicyState(Management.PolicyInsights.Models.PolicyState policyState)
        {
            if (null == policyState)
            {
                return;
            }

            this.AdditionalProperties = policyState.AdditionalProperties;
            this.AdditionalProperties.Remove("@odata.id");

            this.Timestamp = policyState.Timestamp;
            this.ResourceId = policyState.ResourceId;
            this.PolicyAssignmentId = policyState.PolicyAssignmentId;
            this.PolicyDefinitionId = policyState.PolicyDefinitionId;
            this.EffectiveParameters = policyState.EffectiveParameters;
            this.IsCompliant = policyState.IsCompliant;
            this.SubscriptionId = policyState.SubscriptionId;
            this.ResourceType = policyState.ResourceType;
            this.ResourceLocation = policyState.ResourceLocation;
            this.ResourceGroup = policyState.ResourceGroup;
            this.ResourceTags = policyState.ResourceTags;
            this.PolicyAssignmentName = policyState.PolicyAssignmentName;
            this.PolicyAssignmentOwner = policyState.PolicyAssignmentOwner;
            this.PolicyAssignmentParameters = policyState.PolicyAssignmentParameters;
            this.PolicyAssignmentScope = policyState.PolicyAssignmentScope;
            this.PolicyDefinitionName = policyState.PolicyDefinitionName;
            this.PolicyDefinitionAction = policyState.PolicyDefinitionAction;
            this.PolicyDefinitionCategory = policyState.PolicyDefinitionCategory;
            this.PolicySetDefinitionId = policyState.PolicySetDefinitionId;
            this.PolicySetDefinitionName = policyState.PolicySetDefinitionName;
            this.PolicySetDefinitionOwner = policyState.PolicySetDefinitionOwner;
            this.PolicySetDefinitionCategory = policyState.PolicySetDefinitionCategory;
            this.PolicySetDefinitionParameters = policyState.PolicySetDefinitionParameters;
            this.ManagementGroupIds = policyState.ManagementGroupIds;
            this.PolicyDefinitionReferenceId = policyState.PolicyDefinitionReferenceId;
            this.ComplianceState = policyState.ComplianceState;

            if (policyState.PolicyEvaluationDetails != null)
            {
                this.PolicyEvaluationDetails = new PolicyEvaluationDetails(policyState.PolicyEvaluationDetails);
            }
        }
    }
}
