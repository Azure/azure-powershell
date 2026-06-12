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
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf;
    using Microsoft.Azure.Commands.ResourceManager.Common;

    /// <summary>
    /// Deletes an existing WhatIf result for a Management Group Deployment Stack.
    /// </summary>
    [Cmdlet("Remove", AzureRMConstants.AzureRMPrefix + "ManagementGroupDeploymentStackWhatIfResult",
        SupportsShouldProcess = true, DefaultParameterSetName = RemoveByNameAndManagementGroupIdParameterSetName), OutputType(typeof(bool))]
    public class RemoveAzManagementGroupDeploymentStackWhatIfResult : DeploymentStacksCmdletBase
    {
        internal const string RemoveByResourceIdParameterSetName = "RemoveByResourceId";
        internal const string RemoveByNameAndManagementGroupIdParameterSetName = "RemoveByNameAndManagementGroupId";
        internal const string RemoveByInputObjectParameterSetName = "RemoveByInputObject";

        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemoveByNameAndManagementGroupIdParameterSetName,
            HelpMessage = "The name of the WhatIf result to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemoveByNameAndManagementGroupIdParameterSetName,
            HelpMessage = "The ID of the management group.")]
        [ValidateNotNullOrEmpty]
        public string ManagementGroupId { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = RemoveByResourceIdParameterSetName,
            HelpMessage = "The fully-qualified resource ID of the WhatIf result to delete.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true,
            ParameterSetName = RemoveByInputObjectParameterSetName,
            HelpMessage = "The WhatIf result PS object.")]
        [ValidateNotNullOrEmpty]
        public PSDeploymentStackWhatIfResult InputObject { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "If set, a boolean will be returned with value dependent on cmdlet success.")]
        public SwitchParameter PassThru { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void OnProcessRecord()
        {
            try
            {
                if (InputObject != null)
                {
                    ResourceId = InputObject.Id;
                }

                // Resolve Name and ManagementGroupId if ResourceId was provided
                if (!string.IsNullOrEmpty(ResourceId))
                {
                    Name = Name ?? ResourceIdUtility.GetDeploymentName(ResourceId);
                    if (string.IsNullOrEmpty(ManagementGroupId))
                    {
                        // Extract management group id from: /providers/Microsoft.Management/managementGroups/{mgId}/...
                        var segments = ResourceId.Split('/');
                        var mgIndex = Array.IndexOf(segments, "managementGroups");
                        if (mgIndex >= 0 && mgIndex + 1 < segments.Length)
                        {
                            ManagementGroupId = segments[mgIndex + 1];
                        }
                    }
                }

                if (Name == null || ManagementGroupId == null)
                {
                    throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " +
                        "/providers/Microsoft.Management/managementGroups/<mgId>/providers/Microsoft.Resources/deploymentStacksWhatIfResults/<name>");
                }

                ConfirmAction(
                    Force.IsPresent,
                    $"Are you sure you want to delete WhatIf result '{Name}' in ManagementGroup '{ManagementGroupId}'?",
                    "Delete",
                    Name,
                    () =>
                    {
                        DeploymentStacksWhatIfSdkClient.DeleteManagementGroupDeploymentStackWhatIfResult(ManagementGroupId, Name);
                        if (PassThru.IsPresent)
                        {
                            WriteObject(true);
                        }
                    });
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
    }
}
