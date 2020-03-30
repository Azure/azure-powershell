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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(VerbsCommon.Get, AzureRMConstants.AzureRMPrefix + "DeploymentScriptLog", DefaultParameterSetName = GetAzDeploymentScriptLog.GetDeploymentScriptLogByName), OutputType(typeof(PsDeploymentScriptLog))]
    public class GetAzDeploymentScriptLog : DeploymentScriptCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string GetDeploymentScriptLogByName = "GetDeploymentScriptLogByName";
        internal const string GetDeploymentScriptLogByResourceId = "GetDeploymentScriptLogByResourceId";
        internal const string GetDeploymentScriptLogByInputObject = "GetDeploymentScriptLogByInputObject";

        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptLogByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetDeploymentScriptLogByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment script.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptLogByResourceId, Mandatory = true, HelpMessage = "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deploymentScripts/{deploymentScriptName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/deploymentScripts")]
        public string DeploymentScriptResourceId { get; set; }

        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptLogByInputObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The deployment script PowerShell object.")]
        [ValidateNotNullOrEmpty]
        public PsDeploymentScript DeploymentScriptInputObject { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            PsDeploymentScriptLog deploymentScriptLog;
            try
            {
                switch (ParameterSetName)
                {
                    case GetDeploymentScriptLogByName:
                        deploymentScriptLog =
                            DeploymentScriptsSdkClient.GetDeploymentScriptLog(Name, ResourceGroupName);
                        break;
                    case GetDeploymentScriptLogByResourceId:
                        deploymentScriptLog = DeploymentScriptsSdkClient.GetDeploymentScriptLog(
                            ResourceIdUtility.GetResourceName(this.DeploymentScriptResourceId),
                            ResourceIdUtility.GetResourceGroupName(this.DeploymentScriptResourceId));
                        break;
                    case GetDeploymentScriptLogByInputObject:
                        deploymentScriptLog = DeploymentScriptsSdkClient.GetDeploymentScriptLog(DeploymentScriptInputObject.Name, 
                            ResourceIdUtility.GetResourceGroupName(DeploymentScriptInputObject.Id));
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }

                WriteObject(deploymentScriptLog);
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        #endregion Cmdlet Overrides
    }
}
