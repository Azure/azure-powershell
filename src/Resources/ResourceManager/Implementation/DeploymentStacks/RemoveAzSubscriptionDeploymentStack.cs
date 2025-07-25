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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks;
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using System;
    using System.Management.Automation;

    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveByNameParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzSubscriptionDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByNameParameterSetName = "RemoveByName";
        internal const string RemoveByStackObjectParameterSetName = "RemoveByStackObject";

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByNameParameterSetName,
            HelpMessage = "The name of the deploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the stack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ParameterSetName = RemoveByStackObjectParameterSetName,
            HelpMessage = "The stack PS object")]
        [ValidateNotNullOrEmpty]
        public PSDeploymentStack InputObjet { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Action to take on resources that become unmanaged on deletion or update of the deployment stack. Possible values include: " +
            "'detachAll' (do not delete any unmanaged resources), 'deleteResources' (delete all unmanaged resources that are not RGs or MGs)," +
            " and 'deleteAll' (delete every unmanaged resource).")]
        public PSActionOnUnmanage ActionOnUnmanage { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If set, a boolean will be returned with value dependent on cmdlet success.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

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

                if (InputObjet != null)
                {
                    ResourceId = InputObjet.id;
                }

                // resolve Name if ResourceId was provided
                Name = Name ?? ResourceIdUtility.GetDeploymentName(ResourceId);

                // failed resolving the resource id
                if (Name == null)
                {
                    throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " +
                        "/subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>");
                }

                string confirmationMessage = $"Are you sure you want to remove Subscription scoped DeploymentStack '{Name}' " +
                    $"in current Subscription with the following actions?" +
                    // Deleting
                    (shouldDeleteResources || shouldDeleteResourceGroups || shouldDeleteManagementGroups ? "\nDeleting: " : "") +
                    (shouldDeleteResources ? "resources" : "") +
                    (shouldDeleteResources && shouldDeleteResourceGroups ? ", " : "") +
                    (shouldDeleteResourceGroups ? "resourceGroups" : "") +
                    (shouldDeleteResourceGroups && shouldDeleteManagementGroups ? ", " : "") +
                    (shouldDeleteManagementGroups ? "managementGroups" : "") +
                    // Detaching
                    (!shouldDeleteResources || !shouldDeleteResourceGroups || !shouldDeleteManagementGroups ? "\nDetaching: " : "") +
                    (!shouldDeleteResources ? "resources" : "") +
                    (!shouldDeleteResources && !shouldDeleteResourceGroups ? ", " : "") +
                    (!shouldDeleteResourceGroups ? "resourceGroups" : "") +
                    (!shouldDeleteResourceGroups && !shouldDeleteManagementGroups ? ", " : "") +
                    (!shouldDeleteManagementGroups ? "managementGroups" : "");

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack ...",
                    Name,
                    () =>
                    {
                        DeploymentStacksSdkClient.DeleteSubscriptionDeploymentStack(
                            Name,
                            resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                            resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach",
                            managementGroupsCleanupAction: shouldDeleteManagementGroups ? "delete" : "detach",
                            bypassStackOutOfSyncError: BypassStackOutOfSyncError.IsPresent
                        );
                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    }
                );
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    throw new PSArgumentException(dex.Message + " : " + dex.Body.Error.Code + " : " + dex.Body.Error.Message);
                }
                else
                {
                    WriteExceptionError(ex);
                }
            }
        }

        #endregion
    }
}