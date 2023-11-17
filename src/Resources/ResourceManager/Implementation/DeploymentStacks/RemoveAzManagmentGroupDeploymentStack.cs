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
    using Microsoft.Azure.Management.Resources.Models;
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using System;
    using System.Management.Automation;

    [Cmdlet("Remove", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStack",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveByNameAndManagementGroupIdParameterSetName), OutputType(typeof(bool))]
    [CmdletPreview("The cmdlet is in preview and under development.")]
    public class RemoveAzManagementGroupDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByNameAndManagementGroupIdParameterSetName = "RemoveByNameAndManagementGroupId";
        internal const string RemoveByStackObjectParameterSetName = "RemoveByStackObject";

        [Alias("StackName")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByNameAndManagementGroupIdParameterSetName,
            HelpMessage = "The name of the DeploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the DeploymentStack to delete")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = RemoveByNameAndManagementGroupIdParameterSetName, 
            HelpMessage = "The id of the ManagementGroup where the DeploymentStack is being deleted")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true, ParameterSetName = RemoveByStackObjectParameterSetName,
            HelpMessage = "The stack PS object")]
        [ValidateNotNullOrEmpty]
        public PSDeploymentStack InputObjet { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete both unmanaged Resources and ResourceGroups after updating stack.")]
        public SwitchParameter DeleteAll { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack Resources after updating stack.")]
        public SwitchParameter DeleteResources { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Signal to delete unmanaged stack ResourceGroups after updating stack.")]
        public SwitchParameter DeleteResourceGroups { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If set, a boolean will be returned with value dependent on cmdlet success.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                var shouldDeleteResources = (DeleteAll.ToBool() || DeleteResources.ToBool()) ? true : false;
                var shouldDeleteResourceGroups = (DeleteAll.ToBool() || DeleteResourceGroups.ToBool()) ? true : false;

                if (InputObjet != null)
                {
                    ResourceId = InputObjet.id;
                }

                // resolve Name and ManagementGroupId if ResourceId was provided
                ManagementGroupId = ManagementGroupId ?? ResourceIdUtility.GetManagementGroupId(ResourceId);
                Name = Name ?? ResourceIdUtility.GetDeploymentName(ResourceId);


                // failed resolving the resource id
                if (Name == null || ManagementGroupId == null)
                {
                    throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " +
                        "/providers/Microsoft.Management/managementGroups/<managementgroupid>/providers/Microsoft.Resources/deploymentStacks/<stackname>");
                }

                string confirmationMessage = $"Are you sure you want to remove ManagementGroup scoped DeploymentStack '{Name}' " +
                    $"in ManagementGroup '{ManagementGroupId}' with the following actions?" +
                    (!shouldDeleteResources || !shouldDeleteResourceGroups ? "\nDetaching: " : "") +
                    (!shouldDeleteResources ? "resources" : "") +
                    (!shouldDeleteResources && !shouldDeleteResourceGroups ? ", " : "") +
                    (!shouldDeleteResourceGroups ? "resourceGroups" : "") +
                    (shouldDeleteResources || shouldDeleteResourceGroups ? "\nDeleting: " : "") +
                    (shouldDeleteResources ? "resources" : "") +
                    (shouldDeleteResources && shouldDeleteResourceGroups ? ", " : "") +
                    (shouldDeleteResourceGroups ? "resourceGroups" : "");

                ConfirmAction(
                    Force.IsPresent,
                    confirmationMessage,
                    "Deleting Deployment Stack ...",
                    Name,
                    () =>
                    {
                        DeploymentStacksSdkClient.DeleteManagementGroupDeploymentStack(
                            Name,
                            ManagementGroupId,
                            resourcesCleanupAction: shouldDeleteResources ? "delete" : "detach",
                            resourceGroupsCleanupAction: shouldDeleteResourceGroups ? "delete" : "detach"
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
