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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.Policy
{
    public static class PolicyHelpStrings
    {
        /// <summary>
        /// Policy assignment cmdlet parameter help strings
        /// </summary>
        public const string GetPolicyAssignmentNameHelp = "The name of the policy assignment to get.";
        public const string GetPolicyAssignmentScopeHelp = "The scope of the policy assignment to get, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string GetPolicyAssignmentIdHelp = "The fully qualified policy assignment ID to get, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}.";
        public const string GetPolicyDefinitionFilterHelp = "Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified Id.";
        public const string GetPolicyAssignmentIncludeDescendentsHelp = "Causes the list of returned policy assignments to include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.";
        public const string GetPolicyAssignmentDoesNothingHelp = "This parameter is ignored if provided with -Name or -Id parameters.";
        public const string NewPolicyAssignmentNameHelp = "The name of the new policy assignment.";
        public const string NewPolicyAssignmentScopeHelp = "The scope of the new policy assignment, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string NewPolicyAssignmentNotScopesHelp = "The not scopes for the new policy assignment.";
        public const string NewPolicyAssignmentDisplayNameHelp = "The display name for the new policy assignment.";
        public const string NewPolicyAssignmentDescriptionHelp = "The description for the new policy assignment.";
        public const string NewPolicyAssignmentPolicyDefinitionHelp = "The policy definition object for the new policy assignment.";
        public const string NewPolicyAssignmentPolicySetDefinitionHelp = "The policy set (initiative) definition object for the new policy assignment.";
        public const string NewPolicyAssignmentPolicyParameterObjectHelp = "The policy parameters object for the new policy assignment.";
        public const string NewPolicyParameterHelp = "The policy parameters file path or string for the new policy assignment.";
        public const string NewPolicyAssignmentMetadataHelp = "The metadata for the new policy assignment. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string NewPolicyAssignmentEnforcementModeHelp = "The enforcement mode for the new policy assignment, e.g. Default, DoNotEnforce. It indicates whether a policy effect will be enforced or not during assignment creation and update. Please visit https://aka.ms/azure-policyAssignment-enforcement-mode for more information.";
        public const string NewPolicyAssignmentSkuHelp = "A hash table which specifies sku properties. This parameter is deprecated and ignored.";
        public const string RemovePolicyAssignmentNameHelp = "The name of the policy assignment to delete.";
        public const string RemovePolicyAssignmentScopeHelp = "The scope of the policy assignment to delete, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string RemovePolicyAssignmentIdHelp = "The fully qualified policy assignment ID to delete, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}.";
        public const string RemovePolicyAssignmentInputObjectHelp = "The policy assignment object to remove that was output from another cmdlet.";
        public const string SetPolicyAssignmentNameHelp = "The name of the policy assignment to update.";
        public const string SetPolicyAssignmentScopeHelp = "The scope of the policy assignment to update, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string SetPolicyAssignmentNotScopesHelp = "The not scopes of the updated policy assignment.";
        public const string SetPolicyAssignmentIdHelp = "The fully qualified ID of the policy assignment to update, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}.";
        public const string SetPolicyAssignmentDisplayNameHelp = "The display name of the updated policy assignment";
        public const string SetPolicyAssignmentDescriptionHelp = "The description of the updated policy assignment";
        public const string SetPolicyAssignmentMetadataHelp = "The updated metadata for the policy assignment. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string SetPolicyAssignmentPolicyParameterObjectHelp = "The new policy parameters object for the policy assignment.";
        public const string SetPolicyParameterHelp = "The new policy parameters file path or string for the policy assignment.";
        public const string SetPolicyAssignmentSkuHelp = "A hash table which specifies sku properties. This parameter is deprecated and ignored.";
        public const string SetPolicyAssignmentInputObjectHelp = "The policy assignment object to update that was output from another cmdlet.";
        public const string PolicyAssignmentAssignIdentityHelp = "Generate and assign a system assigned managed identity for this policy assignment. The identity will be used when executing deployments for 'deployIfNotExists' and 'modify' policies. Location is required when assigning an identity.";
        public const string PolicyAssignmentIdentityTypeHelp = "The type of managed identity to assign to this policy assignment. Can be of type 'SystemAssigned', in which case a managed identity is created for the policy, of type 'UserAssigned', in which case the IdentityId value is required or type 'None', which will remove any managed identity assigned to the policy assignment.";
        public const string PolicyAssignmentIdentityIdHelp = "The id of the user assigned managed identity  to assign to the policy. This is required when the IdentityType is 'UserAssigned'.";
        public const string PolicyAssignmentLocationHelp = "The location of the policy assignment's resource identity. This is required when the IdentityType is provided.";
        public const string PolicyAssignmentNonComplianceMessageHelp = "The non-compliance messages that describe why a resource is non-compliant with the policy.";

        /// <summary>
        /// Policy definition cmdlet parameter help strings
        /// </summary>
        public const string GetPolicyDefinitionNameHelp = "The name of the policy definition to get.";
        public const string GetPolicyDefinitionIdHelp = "The fully qualified policy definition ID to get, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}.";
        public const string GetPolicyDefinitionManagementGroupHelp = "The name of the management group of the policy definition(s) to get.";
        public const string GetPolicyDefinitionSubscriptionIdHelp = "The subscription ID of the policy definition(s) to get.";
        public const string GetPolicyDefinitionBuiltInFilterHelp = "Limits list of results to only built-in policy definitions.";
        public const string GetPolicyDefinitionCustomFilterHelp = "Limits list of results to only custom policy definitions.";
        public const string NewPolicyDefinitionNameHelp = "The name of the new policy definition.";
        public const string NewPolicyDefinitionDisplayNameHelp = "The display name for the new policy definition.";
        public const string NewPolicyDefinitionDescriptionHelp = "The description for the new policy definition.";
        public const string NewPolicyDefinitionRuleHelp = "The policy rule or definition. This can be the path to a file or uri containing the rule or definition JSON, or the rule or definition as a JSON string.";
        public const string NewPolicyDefinitionMetadataHelp = "The metadata for the new policy definition. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string NewPolicyDefinitionParameterHelp = "The parameters declaration for the new policy definition. This can either be a path to a file or uri containing the parameters JSON declaration, or the parameters declaration as a JSON string.";
        public const string NewPolicyDefinitionModeHelp = "The mode of the new policy definition, e.g. All, Indexed.";
        public const string NewPolicyDefinitionManagementGroupHelp = "The name of the management group of the new policy definition.";
        public const string NewPolicyDefinitionSubscriptionIdHelp = "The subscription ID of the new policy definition.";
        public const string RemovePolicyDefinitionNameHelp = "The name of the policy definition to delete.";
        public const string RemovePolicyDefinitionIdHelp = "The fully qualified policy definition ID to delete, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}.";
        public const string RemovePolicyDefinitionInputObjectHelp = "The policy definition object to remove that was output from another cmdlet.";
        public const string ForceFlagHelp = "Do not ask for confirmation.";
        public const string RemovePolicyDefinitionManagementGroupHelp = "The name of the management group of the policy definition to delete.";
        public const string RemovePolicyDefinitionSubscriptionIdHelp = "The subscription ID of the policy definition to delete.";
        public const string SetPolicyDefinitionNameHelp = "The name of the policy definition to update.";
        public const string SetPolicyDefinitionIdHelp = "The fully qualified policy definition ID to get, including the subscription or management group. e.g. /providers/Microsoft.Management/managementGroups/{managementGroup}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}.";
        public const string SetPolicyDefinitionDisplayNameHelp = "The display name of the updated policy definition.";
        public const string SetPolicyDefinitionDescriptionHelp = "The description of the updated policy definition.";
        public const string SetPolicyDefinitionRuleHelp = "The policy rule or definition of the update. This can be the path to a file or uri containing the rule or definition JSON, or the rule or definition as a JSON string.";
        public const string SetPolicyDefinitionMetadataHelp = "The metadata of the updated policy definition. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string SetPolicyDefinitionParameterHelp = "The parameters declaration of the updated policy definition. This can either be a path to a file or uri containing the parameters JSON declaration, or the parameters declaration as a JSON string.";
        public const string SetPolicyDefinitionManagementGroupHelp = "The name of the management group of the policy definition to update.";
        public const string SetPolicyDefinitionSubscriptionIdHelp = "The subscription ID of the policy definition to update.";
        public const string SetPolicyDefinitionInputObjectHelp = "The policy definition object to update that was output from another cmdlet.";

        /// <summary>
        /// Policy set definition cmdlet parameter help strings
        /// </summary>
        public const string GetPolicySetDefinitionNameHelp = "The name of the policy set (initiative) definition to get.";
        public const string GetPolicySetDefinitionIdHelp = "The fully qualified ID of the policy set (initiative) definition to get, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}.";
        public const string GetPolicySetDefinitionManagementGroupHelp = "The name of the management group of the policy set (initiative) definition(s) to get.";
        public const string GetPolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the policy set (initiative) definition(s) to get.";
        public const string GetPolicySetDefinitionBuiltInFilterHelp = "Limits list of results to only built-in policy set (initiative) definitions.";
        public const string GetPolicySetDefinitionCustomFilterHelp = "Limits list of results to only custom policy set (initiative) definitions.";
        public const string NewPolicySetDefinitionNameHelp = "The name of the new policy set (initiative) definition.";
        public const string NewPolicySetDefinitionDisplayNameHelp = "The display name for the new policy set (initiative) definition.";
        public const string NewPolicySetDefinitionDescriptionHelp = "The description for the new policy set (initiative) definition.";
        public const string NewPolicySetDefinitionMetadataHelp = "The metadata for the new policy set (initiative) definition. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string NewPolicySetDefinitionPolicyDefinitionHelp = "The policy definitions for the new policy set (initiative) definition. This can either be a path to a file containing the policy set (initiative) definitions JSON, or the policy set (initiative) definition as a JSON string.";
        public const string NewPolicySetDefinitionGroupDefinitionHelp = "The policy definition groups for the new policy set (initiative) definition. This can either be a path to a file containing the groups JSON, or the groups as a JSON string.";
        public const string NewPolicySetDefinitionParametersHelp = "The parameters declaration for the new policy set (initiative) definition. This can either be a path to a file or uri containing the parameters JSON declaration, or the parameters declaration as a JSON string.";
        public const string NewPolicySetDefinitionManagementGroupHelp = "The name of the management group of the new policy set (initiative) definition.";
        public const string NewPolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the new policy set (initiative) definition.";
        public const string RemovePolicySetDefinitionNameHelp = "The policy set (initiative) definition name to delete.";
        public const string RemovePolicySetDefinitionIdHelp = "The fully qualified policy set (initiative) definition ID to delete, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}.";
        public const string RemovePolicySetDefinitionInputObjectHelp = "The policy set (initiative) definition object to remove that was output from another cmdlet.";
        public const string RemovePolicySetDefinitionManagementGroupHelp = "The name of the management group of the policy set (initiative) definition to delete.";
        public const string RemovePolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the policy set (initiative) definition to delete.";
        public const string SetPolicySetDefinitionNameHelp = "The name of the policy set (initiative) definition to update.";
        public const string SetPolicySetDefinitionIdHelp = "The fully qualified policy set (initiative) definition ID to update, including the subscription or management group. e.g. /providers/Microsoft.Management/managementGroups/{managementGroup}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}.";
        public const string SetPolicySetDefinitionDisplayNameHelp = "The display name of the updated policy set (initiative) definition.";
        public const string SetPolicySetDefinitionDescriptionHelp = "The description of the updated policy set (initiative) definition.";
        public const string SetPolicySetDefinitionPolicyDefinitionHelp = "The policy definitions of the updated policy set (initiative) definition. This can either be a path to a file containing the policy set (initiative) definitions JSON, or the policy set (initiative) definitions as a JSON string.";
        public const string SetPolicySetDefinitionGroupDefinitionHelp = "The policy definition groups of the updated policy set (initiative) definition. This can either be a path to a file containing the groups JSON, or the groups as a JSON string.";
        public const string SetPolicySetDefinitionMetadataHelp = "The metadata of the updated policy set (initiative) definition. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string SetPolicySetDefinitionParameterHelp = "The parameters declaration of the updated policy set (initiative) definition. This can either be a path to a file or uri containing the parameters JSON declaration, or the parameters declaration as a JSON string.";
        public const string SetPolicySetDefinitionManagementGroupHelp = "The name of the management group of the policy set (initiative) definition to update.";
        public const string SetPolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the policy set (initiative) definition to update.";
        public const string SetPolicySetDefinitionInputObjectHelp = "The policy set (initiative) definition object to update that was output from another cmdlet.";

        /// <summary>
        /// Policy exemption cmdlet parawmeter help strings
        /// </summary>
        public const string GetPolicyExemptionNameHelp = "The name of the policy exemption to get.";
        public const string GetPolicyExemptionScopeHelp = "The scope of the policy exemption to get, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string GetPolicyExemptionIdHelp = "The fully qualified policy exemption ID to get, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyExemptions/{policyExemptionName}.";
        public const string GetPolicyExemptionFilterHelp = "Limits the list of returned policy exemptions to those assigning the policy assignment identified by this fully qualified Id.";
        public const string GetPolicyExemptionIncludeDescendentsHelp = "Causes the list of returned policy exemptions to include all exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes. This parameter doesn't work when the requested scope is a management group scope.";
        public const string GetPolicyExemptionDoesNothingHelp = "This parameter is ignored if provided with -Name or -Id parameters.";
        public const string NewPolicyExemptionNameHelp = "The name of the new policy exemption.";
        public const string NewPolicyExemptionScopeHelp = "The scope of the new policy exemption, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string NewPolicyExemptionCategoryHelp = "The policy exemption category of the new policy exemption. Possible values are Waiver and Mitigated.";
        public const string NewPolicyExemptionDisplayNameHelp = "The display name for the new policy exemption.";
        public const string NewPolicyExemptionDescriptionHelp = "The description for the new policy exemption.";
        public const string NewPolicyExemptionExpiresOnHelp = "The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the new policy exemption.";
        public const string NewPolicyExemptionPolicyAssignmentIdHelp = "The referenced policy assignment Id for the new policy exemption.";
        public const string NewPolicyExemptionPolicyDefinitionReferenceIdHelp = "The policy definition reference ID list when the associated policy assignment is for a policy set (initiative).";
        public const string NewPolicyExemptionMetadataHelp = "The metadata for the new policy exemption. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string RemovePolicyExemptionNameHelp = "The name of the policy exemption to delete.";
        public const string RemovePolicyExemptionScopeHelp = "The scope of the policy exemption to delete, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string RemovePolicyExemptionIdHelp = "The fully qualified policy exemption ID to delete, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyExemptions/{policyExemptionName}.";
        public const string RemovePolicyExemptionInputObjectHelp = "The policy exemption object to remove that was output from another cmdlet.";
        public const string SetPolicyExemptionNameHelp = "The name of the policy exemption to update.";
        public const string SetPolicyExemptionScopeHelp = "The scope of the updated policy exemption, e.g. /providers/managementGroups/{managementGroupName}, defaults to current subscription.";
        public const string SetPolicyExemptionIdHelp = "The fully qualified policy exemption Id to update, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyExemptions/{policyExemptionName}.";
        public const string SetPolicyExemptionCategoryHelp = "The policy exemption category of the updated policy exemption. Possible values are Waiver and Mitigated.";
        public const string SetPolicyExemptionDisplayNameHelp = "The display name for the updated policy exemption.";
        public const string SetPolicyExemptionDescriptionHelp = "The description for the updated policy exemption.";
        public const string SetPolicyExemptionExpiresOnHelp = "The expiration date and time (in UTC ISO 8601 format yyyy-MM-ddTHH:mm:ssZ) of the updated policy exemption.";
        public const string SetPolicyExemptionClearExpirationHelp = "If set, this switch clears the expiration date and time on the updated policy exemption.";
        public const string SetPolicyExemptionPolicyDefinitionReferenceIdHelp = "The policy definition reference ID list when the associated policy assignment is for a policy set (initiative).";
        public const string SetPolicyExemptionMetadataHelp = "The metadata for the updated policy exemption. This can either be a path to a file containing the metadata JSON, or the metadata as a JSON string.";
        public const string SetPolicyExemptionInputObjectHelp = "The policy exemption object to update that was output from another cmdlet.";
    }
}
