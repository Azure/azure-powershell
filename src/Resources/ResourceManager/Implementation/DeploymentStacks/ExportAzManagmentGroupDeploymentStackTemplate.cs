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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
    using System;
    using System.Management.Automation;

    [Cmdlet("Export", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStackTemplate",
        DefaultParameterSetName = ExportByNameAndManagementGroupIdParameterSetName), OutputType(typeof(PSDeploymentStackTemplateDefinition))]
    public class ExportAzManagementGroupDeploymentStackTemplate : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string ExportByResourceIdParameterSetName = "ExportByResourceId";
        internal const string ExportByNameAndManagementGroupIdParameterSetName = "ExportByNameAndManagmentGroupId";

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByResourceIdParameterSetName, 
            HelpMessage = "ResourceId of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("StackName")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByNameAndManagementGroupIdParameterSetName, 
            HelpMessage = "The name of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByNameAndManagementGroupIdParameterSetName,
            HelpMessage = "The id of the ManagementGroup where the DeploymentStack is deployed")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        #endregion

        #region Cmdlet Overrides
        protected override void OnProcessRecord()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ExportByResourceIdParameterSetName:
                        ManagementGroupId = ResourceIdUtility.GetManagementGroupId(ResourceId);
                        Name = ResourceIdUtility.GetDeploymentName(ResourceId);
                        if (ManagementGroupId == null || Name == null)
                        {
                            throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " +
                                "/providers/Microsoft.Management/managementGroups/<managementgroupid>/providers/Microsoft.Resources/deploymentStacks/<stackname>");
                        }
                        WriteObject(DeploymentStacksSdkClient.ExportManagementGroupDeploymentStack(ManagementGroupId, Name), true);
                        break;
                    case ExportByNameAndManagementGroupIdParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ExportManagementGroupDeploymentStack(ManagementGroupId, Name), true);
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }

        #endregion
    }
}
