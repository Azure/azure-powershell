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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks;
    using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
    using Microsoft.Azure.Management.Resources.Models;
    using System;
    using System.Management.Automation;

    [Cmdlet("Test", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = ParameterlessTemplateFileParameterSetName), OutputType(typeof(bool))]
    public class TestAzSubscriptionDeploymentStack : NewAzSubscriptionDeploymentStack
    {

        [Parameter(Mandatory = false, HelpMessage = "If set, a boolean will be returned with value dependent on cmdlet success.")]
        public SwitchParameter PassThru { get; set; }

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

                DeploymentStacksSdkClient.SubscriptionValidateDeploymentStack(
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

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
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
    }
}
