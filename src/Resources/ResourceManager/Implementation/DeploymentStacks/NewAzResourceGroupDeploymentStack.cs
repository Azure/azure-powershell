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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
    using System;
    using System.Collections;
    using System.IO;
    using System.Management.Automation;
    using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;

    [Cmdlet("New", Common.AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(PSDeploymentStack))]
    [CmdletPreview("The cmdlet is in preview and under development.")]
    public class NewAzResourceGroupDeploymentStack : DeploymentStacksCreateCmdletBase
    { 
        #region Cmdlet Parameters

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the DeploymentStack to create.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the ResourceGroup to be used.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Description for the stack.")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete both unmanaged Resources and ResourceGroups after updating stack.")]
        public SwitchParameter DeleteAll { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack Resources after updating stack.")]
        public SwitchParameter DeleteResources { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack ResourceGroups after updating stack.")]
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
                string parameterFilePath = "";

                if (BicepUtility.IsBicepparamFile(TemplateParameterFile) && !BicepUtility.IsBicepFile(TemplateFile))
                {
                    throw new NotSupportedException($"Bicepparam file {TemplateParameterFile} is only supported with a Bicep template file");
                }

                switch (ParameterSetName)
                {
                    case ParameterlessTemplateFileParameterSetName:
                    case ParameterUriTemplateFileParameterSetName:
                        filePath = this.TryResolvePath(TemplateFile);
                        if(!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);
                        TemplateUri = filePath;
                        break;
                    case ParameterFileTemplateSpecParameterSetName:
                    case ParameterFileTemplateUriParameterSetName:
                        parameterFilePath = this.TryResolvePath(TemplateParameterFile);
                        if (!File.Exists(parameterFilePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateParameterFile));
                        }
                        parameters = this.GetParameterObject(parameterFilePath);

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
                        filePath = this.TryResolvePath(TemplateFile);
                        if (!File.Exists(filePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateFile));
                        }
                        filePath = ResolveBicepFile(filePath);

                        parameterFilePath = this.TryResolvePath(TemplateParameterFile);
                        if (!File.Exists(parameterFilePath))
                        {
                            throw new PSInvalidOperationException(
                                string.Format(ProjectResources.InvalidFilePath, TemplateParameterFile));
                        }
                        parameters = this.GetParameterObject(ResolveBicepParameterFile(parameterFilePath));
                        TemplateUri = filePath;
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
                        templateUri: !string.IsNullOrEmpty(protectedTemplateUri) ? protectedTemplateUri : TemplateUri,
                        templateSpec: TemplateSpecId,
                        parameterUri: TemplateParameterUri,
                        parameters: parameters,
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

                if (!Force.IsPresent && currentStack != null)
                {
                    string confirmationMessage = $"The DeploymentStack '{Name}' you're trying to create already exists in ResourceGroup '{ResourceGroupName}'. " +
                        $"Do you want to overwrite it?\n" +
                        $"The following actions will be applied to any resources the are no longer managed by the deployment stack after the template is applied:" +
                        (shouldDeleteResources || shouldDeleteResourceGroups ? "\nDeleting: " : "") +
                        (shouldDeleteResources ? "resources" : "") +
                        (shouldDeleteResources && shouldDeleteResourceGroups ? ", " : "") +
                        (shouldDeleteResourceGroups ? "resourceGroups" : "") +
                        (!shouldDeleteResources || !shouldDeleteResourceGroups ? "\nDetaching: " : "") +
                        (!shouldDeleteResources ? "resources" : "") +
                        (!shouldDeleteResources && !shouldDeleteResourceGroups ? ", " : "") +
                        (!shouldDeleteResourceGroups ? "resourceGroups" : "");

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
