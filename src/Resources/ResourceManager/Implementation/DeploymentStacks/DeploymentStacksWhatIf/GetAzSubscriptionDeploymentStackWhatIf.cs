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
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
    using Microsoft.Azure.Commands.ResourceManager.Common;

    /// <summary>
    /// Gets or lists existing WhatIf results for a Subscription Deployment Stack.
    /// </summary>
    [Cmdlet("Get", AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStackWhatIf",
        DefaultParameterSetName = ListParameterSetName)]
    [OutputType(typeof(PSDeploymentStackWhatIfResult))]
    public class GetAzSubscriptionDeploymentStackWhatIf : DeploymentStacksCmdletBase
    {
        internal const string GetByNameParameterSetName = "GetByName";
        internal const string ListParameterSetName = "List";

        [Alias("StackName")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
            ParameterSetName = GetByNameParameterSetName,
            HelpMessage = "The name of the DeploymentStack WhatIf result to get.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "If specified, calls the WhatIf POST endpoint to retrieve the result with property changes populated.")]
        public SwitchParameter WithPropertyChanges { get; set; }

        protected override void OnProcessRecord()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetByNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.GetSubscriptionDeploymentStackWhatIfResult(Name, WithPropertyChanges.IsPresent));
                        break;
                    case ListParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ListSubscriptionDeploymentStackWhatIfResults(), true);
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
