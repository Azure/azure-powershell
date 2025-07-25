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
    using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
    using System;
    using System.Management.Automation;

    [Cmdlet("Get", Common.AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStack",
        DefaultParameterSetName = ListByManagementGroupIdParameterSetName), OutputType(typeof(PSDeploymentStack))]
    public class GetAzManagementGroupDeploymentStack : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string GetByResourceIdParameterSetName = "GetByResourceId";
        internal const string GetByManagementGroupIdAndNameParameterSetName = "GetByManagementGroupIdAndName";
        internal const string ListByManagementGroupIdParameterSetName = "ListByManagmentGroupId";

        [Alias("StackName")]
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByManagementGroupIdAndNameParameterSetName, 
            HelpMessage = "The name of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ListByManagementGroupIdParameterSetName,
             HelpMessage = "The id of the ManagementGroup where the DeploymentStack is deployed")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByManagementGroupIdAndNameParameterSetName,
            HelpMessage = "The id of the ManagementGroup where the DeploymentStack is deployed")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        #endregion

        #region Cmdlet Overrides

        protected override void OnProcessRecord()
        {
            try
            {
                this.GetResourcesClient();
                switch (ParameterSetName)
                {
                    case GetByResourceIdParameterSetName:
                        ManagementGroupId = ResourceIdUtility.GetManagementGroupId(ResourceId);
                        Name = ResourceIdUtility.GetDeploymentName(ResourceId);
                        if (ManagementGroupId == null || Name == null)
                        {
                            throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " +
                                "/providers/Microsoft.Management/managementGroups/<managementgroupid>/providers/Microsoft.Resources/deploymentStacks/<stackname>");
                        }
                        WriteObject(DeploymentStacksSdkClient.GetManagementGroupDeploymentStack(ManagementGroupId, Name), true);
                        break;
                    case GetByManagementGroupIdAndNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.GetManagementGroupDeploymentStack(ManagementGroupId, Name, true));
                        break;
                    case ListByManagementGroupIdParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ListManagementGroupDeploymentStack(ManagementGroupId), true);
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
