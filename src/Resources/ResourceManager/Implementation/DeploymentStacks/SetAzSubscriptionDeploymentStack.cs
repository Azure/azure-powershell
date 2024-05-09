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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.CmdletBase;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using System;
    using System.Collections;
    using System.Management.Automation;

    [Cmdlet("Set", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    public class SetAzSubscriptionDeploymentStack : DeploymentStacksCreateCmdletBase
    {
        #region Cmdlet Parameters

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deploymentStack to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack.")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the stack.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "The ResourceGroup at which the deployment will be created. If none is specified, it will default to the " +
            "subscription level scope of the deployment stack.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string DeploymentResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Action to take on resources that become unmanaged on deletion or update of the deployment stack. Possible values include: " +
            "'detachAll' (do not delete any unmanaged resources), 'deleteResources' (delete all unmanaged resources that are not RGs or MGs)," +
            " and 'deleteAll' (delete every unmanaged resource).")]
        public PSActionOnUnmanage ActionOnUnmanage { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Mode for DenySettings. Possible values include: 'denyDelete', 'denyWriteAndDelete', and 'none'.")]
        public PSDenySettingsMode DenySettingsMode { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of AAD principal IDs excluded from the lock. Up to 5 principals are permitted.")]
        public string[] DenySettingsExcludedPrincipal { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "List of role-based management operations that are excluded from " +
            "the denySettings. Up to 200 actions are permitted.")]
        public string[] DenySettingsExcludedAction { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Apply to child scopes.")]
        public SwitchParameter DenySettingsApplyToChildScopes { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The tags to put on the deployment.")]
        public Hashtable Tag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation when overwriting an existing stack.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Bypass errors for the stack being out of sync when running the operation. If the stack is out of sync and this parameter " +
            "is not set, the operation will fail. Only include this parameter if instructed to do so on a failed stack operation.")]
        public SwitchParameter BypassStackOutOfSyncError { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                var shouldDeleteResources = (ActionOnUnmanage is PSActionOnUnmanage.DeleteAll || ActionOnUnmanage is PSActionOnUnmanage.DeleteResources) ? true : false;
                var shouldDeleteResourceGroups = (ActionOnUnmanage is PSActionOnUnmanage.DeleteAll) ? true : false;
                var shouldDeleteManagementGroups = (ActionOnUnmanage is PSActionOnUnmanage.DeleteAll) ? true : false;

                // construct deploymentScope if ResourceGroup was provided
                var deploymentScope = DeploymentResourceGroupName != null ? "/subscriptions/" + DeploymentStacksSdkClient.DeploymentStacksClient.SubscriptionId
                        + "/resourceGroups/" + DeploymentResourceGroupName : null;

                var currentStack = DeploymentStacksSdkClient.GetSubscriptionDeploymentStack(Name, throwIfNotExists: false);
                if (currentStack != null && Tag == null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentStack.tags);
                }

                Action createOrUpdateAction = () =>
                {
                    var deploymentStack = DeploymentStacksSdkClient.SubscriptionCreateOrUpdateDeploymentStack(
                        deploymentStackName: Name,
                        location: Location,
                        templateFile: TemplateFile,
                        templateUri: !string.IsNullOrEmpty(protectedTemplateUri) ? protectedTemplateUri : TemplateUri,
                        templateSpec: TemplateSpecId,
                        templateObject: TemplateObject,
                        parameterUri: TemplateParameterUri,
                        parameters: GetTemplateParameterObject(),
                        description: Description,
                        resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                        resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach",
                        managementGroupsCleanupAction: shouldDeleteManagementGroups ? "delete" : "detach",
                        deploymentScope: deploymentScope,
                        denySettingsMode: DenySettingsMode.ToString(),
                        denySettingsExcludedPrincipals: DenySettingsExcludedPrincipal,
                        denySettingsExcludedActions: DenySettingsExcludedAction,
                        denySettingsApplyToChildScopes: DenySettingsApplyToChildScopes.IsPresent,
                        tags: Tag,
                        bypassStackOutOfSyncError: BypassStackOutOfSyncError.IsPresent
                    );

                    WriteObject(deploymentStack);
                };

                if (!Force.IsPresent && currentStack == null)
                {
                    string confirmationMessage =
                        $"The DeploymentStack '{Name}' you're trying to modify does not exist in the current subscription scope. Do you want to create a new stack?";

                    ConfirmAction(
                        Force.IsPresent,
                        confirmationMessage,
                        "Update",
                        $"{Name}",
                        createOrUpdateAction
                    );
                }
                else
                {
                    if (!ShouldProcess($"{Name}", "Create"))
                    {
                        return; // Don't perform the actual creation/update action
                    }

                    createOrUpdateAction();
                }

            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Message + " : " + dex.Body.Error.Code + " : " + dex.Body.Error.Message);
                else
                    WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
