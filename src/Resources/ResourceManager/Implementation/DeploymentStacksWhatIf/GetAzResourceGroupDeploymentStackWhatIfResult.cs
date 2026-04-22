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
    using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

    /// <summary>
    /// Gets or lists existing WhatIf results for a Resource Group Deployment Stack.
    /// </summary>
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "ResourceGroupDeploymentStackWhatIfResult",
        DefaultParameterSetName = ListParameterSetName)]
    [OutputType(typeof(PSDeploymentStackWhatIfResult))]
    public class GetAzResourceGroupDeploymentStackWhatIfResult : DeploymentStacksCmdletBase
    {
        internal const string GetByNameParameterSetName = "GetByName";
        internal const string GetByResourceIdParameterSetName = "GetByResourceId";
        internal const string ListParameterSetName = "List";

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByNameParameterSetName,
            HelpMessage = "The name of the WhatIf result to get.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByNameParameterSetName,
            HelpMessage = "The name of the ResourceGroup.")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = ListParameterSetName,
            HelpMessage = "The name of the ResourceGroup.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByResourceIdParameterSetName,
            HelpMessage = "The fully-qualified resource ID of the WhatIf result to get.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = GetByNameParameterSetName,
            HelpMessage = "If set, returns the WhatIf result with resource property changes (delta) populated.")]
        [Parameter(Mandatory = false, ParameterSetName = GetByResourceIdParameterSetName,
            HelpMessage = "If set, returns the WhatIf result with resource property changes (delta) populated.")]
        public SwitchParameter WithPropertyChanges { get; set; }

        protected override void OnProcessRecord()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetByResourceIdParameterSetName:
                        // Validate and parse the ResourceId
                        var rg = ResourceIdUtility.GetResourceGroupName(ResourceId);
                        var name = ResourceIdUtility.GetDeploymentName(ResourceId);
                        if (string.IsNullOrEmpty(rg) || string.IsNullOrEmpty(name))
                        {
                            throw new PSArgumentException($"Provided ResourceId '{ResourceId}' is not in correct form. Should be in form " +
                                "/subscriptions/<subid>/resourceGroups/<rgname>/providers/Microsoft.Resources/deploymentStacksWhatIfResults/<name>");
                        }
                        WriteObject(WithPropertyChanges.IsPresent
                            ? DeploymentStacksWhatIfSdkClient.GetResourceGroupDeploymentStackWhatIfResultWithPropertyChanges(rg, name)
                            : DeploymentStacksWhatIfSdkClient.GetResourceGroupDeploymentStackWhatIfResult(rg, name));
                        break;
                    case GetByNameParameterSetName:
                        WriteObject(WithPropertyChanges.IsPresent
                            ? DeploymentStacksWhatIfSdkClient.GetResourceGroupDeploymentStackWhatIfResultWithPropertyChanges(ResourceGroupName, Name)
                            : DeploymentStacksWhatIfSdkClient.GetResourceGroupDeploymentStackWhatIfResult(ResourceGroupName, Name));
                        break;
                    case ListParameterSetName:
                        WriteObject(DeploymentStacksWhatIfSdkClient.ListResourceGroupDeploymentStackWhatIfResults(ResourceGroupName), true);
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
    }
}
