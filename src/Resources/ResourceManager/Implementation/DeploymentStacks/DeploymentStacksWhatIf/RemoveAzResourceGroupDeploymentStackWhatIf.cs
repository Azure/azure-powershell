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
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Deletes an existing WhatIf result for a Resource Group Deployment Stack.
    /// </summary>
    [Cmdlet("Remove", AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackWhatIf",
        SupportsShouldProcess = true)]
    public class RemoveAzResourceGroupDeploymentStackWhatIf : DeploymentStacksCmdletBase
    {
        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the DeploymentStack WhatIf result to delete.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The name of the ResourceGroup.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void OnProcessRecord()
        {
            try
            {
                ConfirmAction(
                    Force.IsPresent,
                    $"Are you sure you want to delete WhatIf result '{Name}' in ResourceGroup '{ResourceGroupName}'?",
                    "Delete",
                    Name,
                    () => DeploymentStacksSdkClient.DeleteResourceGroupDeploymentStackWhatIfResult(ResourceGroupName, Name));
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
    }
}
