﻿// ----------------------------------------------------------------------------------
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
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using System;
    using System.Collections;
    using System.Management.Automation;

    [Cmdlet("Set", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    [CmdletPreview("The cmdlet is in preview and under development.")]
    public class SetAzResourceGroupDeploymentStack : DeploymentStacksCreateCmdletBase
    {
        #region Cmdlet Parameters

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deploymentStack to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the ResourceGroup to be used.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete both unmanaged Resources and ResourceGroups after deleting stack.")]
        public SwitchParameter DeleteAll { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack Resources after deleting stack.")]
        public SwitchParameter DeleteResources { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack ResourceGroups after deleting stack.")]
        public SwitchParameter DeleteResourceGroups { get; set; }

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

        [Parameter(Mandatory = false,
        HelpMessage = "Do not ask for confirmation when overwriting an existing stack.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background.")]
        public SwitchParameter AsJob { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                var shouldDeleteResources = (DeleteAll.ToBool() || DeleteResources.ToBool()) ? true : false;
                var shouldDeleteResourceGroups = (DeleteAll.ToBool() || DeleteResourceGroups.ToBool()) ? true : false;

                var currentStack = DeploymentStacksSdkClient.GetResourceGroupDeploymentStack(ResourceGroupName, Name, throwIfNotExists: false);
                if (currentStack != null && Tag == null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentStack.Tags);
                }

                Action createOrUpdateAction = () =>
                {
                    var deploymentStack = DeploymentStacksSdkClient.ResourceGroupCreateOrUpdateDeploymentStack(
                        deploymentStackName: Name,
                        resourceGroupName: ResourceGroupName,
                        templateFile: TemplateFile,
                        templateUri: !string.IsNullOrEmpty(protectedTemplateUri) ? protectedTemplateUri : TemplateUri,
                        templateSpec: TemplateSpecId,
                        templateObject: TemplateObject,
                        parameterUri: TemplateParameterUri,
                        parameters: GetTemplateParameterObject(),
                        description: Description,
                        resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                        resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach",
                        managementGroupsCleanupAction: "detach",
                        denySettingsMode: DenySettingsMode.ToString(),
                        denySettingsExcludedPrincipals: DenySettingsExcludedPrincipal,
                        denySettingsExcludedActions: DenySettingsExcludedAction,
                        denySettingsApplyToChildScopes: DenySettingsApplyToChildScopes.IsPresent,
                        tags: Tag
                    );

                    WriteObject(deploymentStack);
                };

                if (!Force.IsPresent && currentStack == null)
                {
                    string confirmationMessage =
                        $"The DeploymentStack '{Name}' you're trying to modify does not exist in '{ResourceGroupName}'. Do you want to create a new stack?";

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
