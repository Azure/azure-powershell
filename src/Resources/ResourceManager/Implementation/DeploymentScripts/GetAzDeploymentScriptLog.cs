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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System;
using System.IO;
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

        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptLogByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deploymentScripts/{deploymentScriptName}")]
        [ValidateNotNullOrEmpty]
        public string DeploymentScriptResourceId { get; set; }

        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptLogByInputObject, Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The deployment script PowerShell object.")]
        [ValidateNotNullOrEmpty]
        public PsDeploymentScript DeploymentScriptInputObject { get; set; }

        [Parameter(Position = 2, ParameterSetName = GetDeploymentScriptLogByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The directory path to save deployment script log.")]
        [Parameter(Position = 1, ParameterSetName = GetDeploymentScriptLogByResourceId, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The directory path to save deployment script log.")]
        [Parameter(Position = 1, ParameterSetName = GetDeploymentScriptLogByInputObject, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The directory path to save deployment script log.")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "When set to true, execution will not ask for a confirmation for the operation.")]
        public SwitchParameter Force { get; set; }

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

                if (!string.IsNullOrEmpty(OutputPath) && !string.IsNullOrEmpty(deploymentScriptLog?.Log))
                {
                    var outputPathWithFileName = Path.Combine(GetValidatedFolderPath(OutputPath), $"{deploymentScriptLog.DeploymentScriptName}.txt");

                    // if a file with the same name exists, let's ask if we can replace it. If it doesn't exist, we'll create it right away.
                    this.ConfirmAction(
                        this.Force || !AzureSession.Instance.DataStore.FileExists(outputPathWithFileName),
                        string.Format(
                            "A file with the name {0} already exists in directory {1}. This operation will replace the existing file. Would you like to continue?",
                            Name, OutputPath),
                        "Replace the file in the destination.",
                        OutputPath,
                        () => AzureSession.Instance.DataStore.WriteFile(outputPathWithFileName, deploymentScriptLog.Log)
                    );
                }
                else
                {
                    WriteObject(deploymentScriptLog);
                }
            }
            catch (Exception ex)
            {
                WriteExceptionError(ex);
            }
        }
        #endregion Cmdlet Overrides
    }
}
