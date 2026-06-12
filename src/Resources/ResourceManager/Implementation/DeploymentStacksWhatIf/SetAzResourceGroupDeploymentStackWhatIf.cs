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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.DeploymentStacks
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Cmdlet to preview changes for updating a Resource Group Deployment Stack.
    /// </summary>
    [Cmdlet("Set", AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackWhatIfResult",
        DefaultParameterSetName = ParameterlessTemplateFileParameterSetName, SupportsShouldProcess = true)]
    [OutputType(typeof(PSDeploymentStackWhatIfResult))]
    public class SetAzResourceGroupDeploymentStackWhatIf : DeploymentStackWhatIfCmdlet
    {
        #region Cmdlet Parameters

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the WhatIf result resource.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully-qualified resource ID of the deployment stack to use as the basis for comparison.")]
        [ValidateNotNullOrEmpty]
        public string StackResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The interval to persist the WhatIf result in ISO 8601 format (e.g. P1D for 1 day).")]
        [ValidateNotNullOrEmpty]
        public string RetentionInterval { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the ResourceGroup.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the WhatIf result.")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Action to take on resources that become unmanaged. Possible values include: " +
            "'detachAll', 'deleteResources', and 'deleteAll'.")]
        public PSActionOnUnmanage ActionOnUnmanage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Mode for DenySettings. Possible values include: 'denyDelete', 'denyWriteAndDelete', and 'none'.")]
        public PSDenySettingsMode DenySettingsMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of AAD principal IDs excluded from the lock. Up to 5 principals are permitted.")]
        public string[] DenySettingsExcludedPrincipal { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of role-based management operations excluded from the denySettings. Up to 200 actions are permitted.")]
        public string[] DenySettingsExcludedAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Apply to child scopes.")]
        public SwitchParameter DenySettingsApplyToChildScopes { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Validation level. Possible values: Template, Provider, ProviderNoRbac.")]
        public string ValidationLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Debug setting detail level (e.g. RequestContent, ResponseContent).")]
        public string DebugSettingDetailLevel { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Flag to bypass stack out-of-sync error.")]
        public SwitchParameter BypassStackOutOfSyncError { get; set; }

        #endregion

        #region Cmdlet Implementation

        protected override PSDeploymentStackWhatIfParameters BuildWhatIfParameters()
        {
            var shouldDeleteResources = (ActionOnUnmanage is PSActionOnUnmanage.DeleteAll || ActionOnUnmanage is PSActionOnUnmanage.DeleteResources);
            var shouldDeleteResourceGroups = (ActionOnUnmanage is PSActionOnUnmanage.DeleteAll);
            var shouldDeleteManagementGroups = (ActionOnUnmanage is PSActionOnUnmanage.DeleteAll);

            return new PSDeploymentStackWhatIfParameters
            {
                StackName = Name,
                StackResourceId = StackResourceId,
                RetentionInterval = RetentionInterval,
                ResourceGroupName = ResourceGroupName,
                TemplateFile = TemplateFile,
                TemplateUri = !string.IsNullOrEmpty(protectedTemplateUri) ? protectedTemplateUri : TemplateUri,
                TemplateSpecId = TemplateSpecId,
                TemplateObject = TemplateObject,
                TemplateParameterUri = TemplateParameterUri,
                TemplateParameterObject = GetTemplateParameterObject(),
                Description = Description,
                ResourcesCleanupAction = shouldDeleteResources ? "delete" : "detach",
                ResourceGroupsCleanupAction = shouldDeleteResourceGroups ? "delete" : "detach",
                ManagementGroupsCleanupAction = shouldDeleteManagementGroups ? "delete" : "detach",
                DenySettingsMode = DenySettingsMode.ToString(),
                DenySettingsExcludedPrincipals = DenySettingsExcludedPrincipal,
                DenySettingsExcludedActions = DenySettingsExcludedAction,
                DenySettingsApplyToChildScopes = DenySettingsApplyToChildScopes.IsPresent,
                ValidationLevel = ValidationLevel,
                DebugSettingDetailLevel = DebugSettingDetailLevel,
                BypassStackOutOfSyncError = BypassStackOutOfSyncError.IsPresent
            };
        }

        #endregion
    }
}
