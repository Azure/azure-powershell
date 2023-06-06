﻿// ----------------------------------------------------------------------------------
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
    using System;
    using System.Management.Automation;

    [Cmdlet("Export", Common.AzureRMConstants.AzureRMPrefix + "SubscriptionDeploymentStackTemplate",
        DefaultParameterSetName = ExportByNameParameterSetName), OutputType(typeof(PSDeploymentStackTemplateDefinition))]
    public class ExportAzSubscriptionDeploymentStackTemplate : DeploymentStacksCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions
        
        internal const string ExportByResourceIdParameterSetName = "ExportByResourceId";
        internal const string ExportByNameParameterSetName = "ExportByName";

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByResourceIdParameterSetName,
            HelpMessage = "ResourceId of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("StackName")]
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ExportByNameParameterSetName,
            HelpMessage = "The name of the DeploymentStack to get")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        #endregion

        #region Cmdlet Overrides
        protected override void OnProcessRecord()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case ExportByResourceIdParameterSetName:
                        Name = ResourceIdUtility.GetDeploymentName(ResourceId);
                        if (Name == null)
                        {
                            throw new PSArgumentException($"Provided Id '{ResourceId}' is not in correct form. Should be in form " +
                                "/subscriptions/<subid>/providers/Microsoft.Resources/deploymentStacks/<stackname>");
                        }
                        WriteObject(DeploymentStacksSdkClient.ExportSubscriptionDeploymentStack(Name), true);
                        break;
                    case ExportByNameParameterSetName:
                        WriteObject(DeploymentStacksSdkClient.ExportSubscriptionDeploymentStack(Name), true);
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
