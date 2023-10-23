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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections;
    using System.IO;
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    [Cmdlet("Set", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    [CmdletPreview("The cmdlet is in preview and under development.")]
    public class SetAzManagementGroupDeploymentStack : DeploymentStacksCreateCmdletBase
    {
        #region Cmdlet Parameters

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the deploymentStack to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The id of the management group that the deploymentStack will be deployed into.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The subscription Id at which the deployment should be created.")]
        public string DeploymentSubscriptionId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Location of the stack.")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Description for the stack.")]
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
                Hashtable parameters = new Hashtable();
                string filePath = "";

                switch (ParameterSetName)
                {
                    case ParameterlessTemplateFileParameterSetName:
                    case ParameterUriTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);
                        TemplateUri = filePath;
                        break;
                    case ParameterFileTemplateSpecParameterSetName:
                    case ParameterFileTemplateUriParameterSetName:
                        parameters = ResolveParameters();

                        // contruct the protected template URI if a query string was provided
                        if (!string.IsNullOrEmpty(QueryString))
                        {
                            if (QueryString.Substring(0, 1) == "?")
                                protectedTemplateUri = TemplateUri + QueryString;
                            else
                                protectedTemplateUri = TemplateUri + "?" + QueryString;
                        }
                        break;
                    case ParameterFileTemplateFileParameterSetName:
                        parameters = ResolveParameters();

                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);

                        TemplateUri = filePath;
                        break;
                    case ByParameterFileWithNoTemplateParameterSetName:
                        parameters = ResolveParameters();
                        break;
                    case ParameterObjectTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);
                        TemplateUri = filePath;
                        parameters = GetTemplateParameterObject(TemplateParameterObject);
                        break;
                    case ParameterObjectTemplateSpecParameterSetName:
                    case ParameterObjectTemplateUriParameterSetName:
                        parameters = GetTemplateParameterObject(TemplateParameterObject);

                        // contruct the protected template URI if a query string was provided
                        if (!string.IsNullOrEmpty(QueryString))
                        {
                            if (QueryString.Substring(0, 1) == "?")
                                protectedTemplateUri = TemplateUri + QueryString;
                            else
                                protectedTemplateUri = TemplateUri + "?" + QueryString;
                        }
                        break;
                    case ParameterlessTemplateUriParameterSetName:
                        // contruct the protected template URI if a query string was provided
                        if (!string.IsNullOrEmpty(QueryString))
                        {
                            if (QueryString.Substring(0, 1) == "?")
                                protectedTemplateUri = TemplateUri + QueryString;
                            else
                                protectedTemplateUri = TemplateUri + "?" + QueryString;
                        }
                        break;
                }

                var shouldDeleteResources = (DeleteAll.ToBool() || DeleteResources.ToBool()) ? true : false;
                var shouldDeleteResourceGroups = (DeleteAll.ToBool() || DeleteResourceGroups.ToBool()) ? true : false;

                string deploymentScope = null;
                if (DeploymentSubscriptionId != null)
                {
                    deploymentScope = "/subscriptions/" + DeploymentSubscriptionId;
                }

                var currentStack = DeploymentStacksSdkClient.GetManagementGroupDeploymentStack(ManagementGroupId, Name, throwIfNotExists: false);
                if (currentStack != null && Tag == null)
                {
                    Tag = TagsConversionHelper.CreateTagHashtable(currentStack.Tags);
                }

                Action createOrUpdateAction = () =>
                {
                    var deploymentStack = DeploymentStacksSdkClient.ManagementGroupCreateOrUpdateDeploymentStack(
                            deploymentStackName: Name,
                            managementGroupId: ManagementGroupId,
                            location: Location,
                            templateUri: !string.IsNullOrEmpty(protectedTemplateUri) ? protectedTemplateUri : TemplateUri,
                            templateSpec: TemplateSpecId,
                            templateJson: TemplateJson,
                            parameterUri: TemplateParameterUri,
                            parameters: parameters,
                            description: Description,
                            resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                            resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach",
                            managementGroupsCleanupAction: "detach",
                            deploymentScope: deploymentScope,
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
