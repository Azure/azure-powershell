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
        public const string GetPolicyAssignmentScopeHelp = "The scope of the policy assignment to get, e.g. /providers/managementGroups/{managementGroupName}.";
        public const string GetPolicyAssignmentIdHelp = "The fully qualified policy assignment ID to get, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}.";
        public const string GetPolicyDefinitionFilterHelp = "Limits the list of returned policy assignments to those assigning the policy definition identified by this fully qualified Id.";
        public const string GetPolicyAssignmentIncludeDescendentsHelp = "Causes the list of returned policy assignments to include all assignments related to the given scope, including those from ancestor scopes and those from descendent scopes.";
        public const string GetPolicyAssignmentDoesNothingHelp = "This parameter is ignored if provided with -Name or -Id parameters.";
        public const string NewPolicyAssignmentNameHelp = "The name of the new policy assignment.";
        public const string NewPolicyAssignmentScopeHelp = "The scope of the new policy assignment, e.g. /providers/managementGroups/{managementGroupName}.";
        public const string NewPolicyAssignmentNotScopesHelp = "The not scopes for the new policy assignment.";
        public const string NewPolicyAssignmentDisplayNameHelp = "The display name for the new policy assignment.";
        public const string NewPolicyAssignmentDescriptionHelp = "The description for the new policy assignment.";
        public const string NewPolicyAssignmentPolicyDefinitionHelp = "The policy definition object for the new policy assignment.";
        public const string NewPolicyAssignmentPolicySetDefinitionHelp = "The policy set definition object for the new policy assignment.";
        public const string NewPolicyAssignmentPolicyParameterObjectHelp = "The policy parameters object for the new policy assignment.";
        public const string NewPolicyParameterHelp = "The policy parameters file path or string for the new policy assignment.";
        public const string NewPolicyAssignmentMetadataHelp = "The metadata for the new policy assignment. This can either be a path to a file name containing the metadata, or the metadata as a string.";
        public const string NewPolicyAssignmentSkuHelp = "A hash table which specifies sku properties. This parameter is deprecated and ignored.";
        public const string RemovePolicyAssignmentNameHelp = "The name of the policy assignment to delete.";
        public const string RemovePolicyAssignmentScopeHelp = "The scope of the policy assignment to delete, e.g. /providers/managementGroups/{managementGroupName}.";
        public const string RemovePolicyAssignmentIdHelp = "The fully qualified policy assignment ID to delete, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}.";
        public const string SetPolicyAssignmentNameHelp = "The name of the policy assignment to update.";
        public const string SetPolicyAssignmentScopeHelp = "The scope of the policy assignment to update, e.g. /providers/managementGroups/{managementGroupName}.";
        public const string SetPolicyAssignmentNotScopesHelp = "The not scopes of the updated policy assignment.";
        public const string SetPolicyAssignmentIdHelp = "The fully qualified ID of the policy assignment to update, including the scope, e.g. /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}.";
        public const string SetPolicyAssignmentDisplayNameHelp = "The display name of the updated policy assignment";
        public const string SetPolicyAssignmentDescriptionHelp = "The description of the updated policy assignment";
        public const string SetPolicyAssignmentMetadataHelp = "The updated metadata for the policy assignment. This can either be a path to a file name containing the metadata, or the metadata as a string.";
        public const string SetPolicyAssignmentPolicyParameterObjectHelp = "The new policy parameters object for the policy assignment.";
        public const string SetPolicyParameterHelp = "The new policy parameters file path or string for the policy assignment.";
        public const string SetPolicyAssignmentSkuHelp = "A hash table which specifies sku properties. This parameter is deprecated and ignored.";
        public const string PolicyAssignmentAssignIdentityHelp = "Generate and assign an Azure Active Directory Identity for this policy assignment. The identity will be used when executing deployments for 'deployIfNotExists' policies. Location is required when assigning an identity.";
        public const string PolicyAssignmentLocationHelp = "The location of the policy assignment's resource identity. This is required when the -AssignIdentity switch is used.";

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
        public const string NewPolicyDefinitionRuleHelp = "The policy rule for the new policy definition. This can either be a path to a file name or uri containing the rule, or the rule as a string.";
        public const string NewPolicyDefinitionMetadataHelp = "The metadata for the new policy definition. This can either be a path to a file name containing the metadata, or the metadata as a string.";
        public const string NewPolicyDefinitionParameterHelp = "The parameters declaration for the new policy definition. This can either be a path to a file name or uri containing the parameters declaration, or the parameters declaration as a string.";
        public const string NewPolicyDefinitionModeHelp = "The mode of the new policy definition.";
        public const string NewPolicyDefinitionManagementGroupHelp = "The name of the management group of the new policy definition.";
        public const string NewPolicyDefinitionSubscriptionIdHelp = "The subscription ID of the new policy definition.";
        public const string RemovePolicyDefinitionNameHelp = "The name of the policy definition to delete.";
        public const string RemovePolicyDefinitionIdHelp = "The fully qualified policy definition ID to delete, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}.";
        public const string ForceFlagHelp = "Do not ask for confirmation.";
        public const string RemovePolicyDefinitionManagementGroupHelp = "The name of the management group of the policy definition to delete.";
        public const string RemovePolicyDefinitionSubscriptionIdHelp = "The subscription ID of the policy definition to delete.";
        public const string SetPolicyDefinitionNameHelp = "The name of the policy definition to update.";
        public const string SetPolicyDefinitionIdHelp = "The fully qualified policy definition ID to get, including the subscription or management group. e.g. /providers/Microsoft.Management/managementGroups/{managementGroup}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}.";
        public const string SetPolicyDefinitionDisplayNameHelp = "The display name of the updated policy definition.";
        public const string SetPolicyDefinitionDescriptionHelp = "The description of the updated policy definition.";
        public const string SetPolicyDefinitionRuleHelp = "The policy rule of the updated policy definition. This can either be a path to a file name or uri containing the rule, or the rule as a string.";
        public const string SetPolicyDefinitionMetadataHelp = "The metadata of the updated policy definition. This can either be a path to a file name containing the metadata, or the metadata as a string.";
        public const string SetPolicyDefinitionParameterHelp = "The parameters declaration of the updated policy definition. This can either be a path to a file name or uri containing the parameters declaration, or the parameters declaration as a string.";
        public const string SetPolicyDefinitionManagementGroupHelp = "The name of the management group of the policy definition to update.";
        public const string SetPolicyDefinitionSubscriptionIdHelp = "The subscription ID of the policy definition to update.";

        /// <summary>
        /// Policy set definition cmdlet parameter help strings
        /// </summary>
        public const string GetPolicySetDefinitionNameHelp = "The name of the policy set definition to get.";
        public const string GetPolicySetDefinitionIdHelp = "The fully qualified ID of the policy set definition to get, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}.";
        public const string GetPolicySetDefinitionManagementGroupHelp = "The name of the management group of the policy set definition(s) to get.";
        public const string GetPolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the policy set definition(s) to get.";
        public const string GetPolicySetDefinitionBuiltInFilterHelp = "Limits list of results to only built-in policy set definitions.";
        public const string GetPolicySetDefinitionCustomFilterHelp = "Limits list of results to only custom policy set definitions.";
        public const string NewPolicySetDefinitionNameHelp = "The name of the new policy set definition.";
        public const string NewPolicySetDefinitionDisplayNameHelp = "The display name for the new policy set definition.";
        public const string NewPolicySetDefinitionDescriptionHelp = "The description for the new policy set definition.";
        public const string NewPolicySetDefinitionMetadataHelp = "The metadata for the new policy set definition. This can either be a path to a file name containing the metadata, or the metadata as a string.";
        public const string NewPolicySetDefinitionPolicyDefinitionHelp = "The policy definition for the new policy set definition. This can either be a path to a file name containing the policy definitions, or the policy set definition as a string.";
        public const string NewPolicySetDefinitionParametersHelp = "The parameters declaration for the new policy set definition. This can either be a path to a file name or uri containing the parameters declaration, or the parameters declaration as a string.";
        public const string NewPolicySetDefinitionManagementGroupHelp = "The name of the management group of the new policy set definition.";
        public const string NewPolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the new policy set definition.";
        public const string RemovePolicySetDefinitionNameHelp = "The policy set definition name to delete.";
        public const string RemovePolicySetDefinitionIdHelp = "The fully qualified policy set definition ID to delete, including the subscription or management group. e.g. /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}.";
        public const string RemovePolicySetDefinitionManagementGroupHelp = "The name of the management group of the policy set definition to delete.";
        public const string RemovePolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the policy set definition to delete.";
        public const string SetPolicySetDefinitionNameHelp = "The name of the policy set definition to update.";
        public const string SetPolicySetDefinitionIdHelp = "The fully qualified policy set definition ID to get, including the subscription or management group. e.g. /providers/Microsoft.Management/managementGroups/{managementGroup}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}.";
        public const string SetPolicySetDefinitionDisplayNameHelp = "The display name of the updated policy set definition.";
        public const string SetPolicySetDefinitionDescriptionHelp = "The description of the updated policy set definition.";
        public const string SetPolicySetDefinitionPolicyDefinitionHelp = "The policy definitions of the updated policy set definition. This can either be a path to a file name containing the policy definitions, or the policy definitions as a string.";
        public const string SetPolicySetDefinitionMetadataHelp = "The metadata of the updated policy set definition. This can either be a path to a file name containing the metadata, or the metadata as a string.";
        public const string SetPolicySetDefinitionParameterHelp = "The parameters declaration of the updated policy set definition. This can either be a path to a file name or uri containing the parameters declaration, or the parameters declaration as a string.";
        public const string SetPolicySetDefinitionManagementGroupHelp = "The name of the management group of the policy set definition to update.";
        public const string SetPolicySetDefinitionSubscriptionIdHelp = "The subscription ID of the policy set definition to update.";
    }
}
