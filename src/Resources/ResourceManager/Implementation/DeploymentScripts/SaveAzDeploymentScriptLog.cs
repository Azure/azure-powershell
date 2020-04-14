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
    [Cmdlet(VerbsData.Save, AzureRMConstants.AzureRMPrefix + "DeploymentScriptLog", SupportsShouldProcess = true, DefaultParameterSetName = SaveAzDeploymentScriptLog.SaveDeploymentScriptLogByName), OutputType(typeof(PsDeploymentScriptLogPath))]

    public class SaveAzDeploymentScriptLog : DeploymentScriptCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string SaveDeploymentScriptLogByName = "SaveDeploymentScriptLogByName";
        internal const string SaveDeploymentScriptLogByResourceId = "SaveDeploymentScriptLogByResourceId";
        internal const string SaveDeploymentScriptLogByInputObject = "SaveDeploymentScriptLogByInputObject";

        [Parameter(Position = 0, ParameterSetName = SaveDeploymentScriptLogByName, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = SaveDeploymentScriptLogByName, Mandatory = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment script.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = SaveDeploymentScriptLogByResourceId, Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage =
                "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deploymentScripts/{deploymentScriptName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/deploymentScripts")]
        public string DeploymentScriptResourceId { get; set; }

        [Parameter(Position = 0, ParameterSetName = SaveDeploymentScriptLogByInputObject, Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The deployment script PowerShell object.")]
        [ValidateNotNullOrEmpty]
        public PsDeploymentScript DeploymentScriptInputObject { get; set; }

        [Parameter(Position = 2, ParameterSetName = SaveDeploymentScriptLogByName, Mandatory = true, HelpMessage = "The directory path to save deployment script log.")]
        [Parameter(Position = 1, ParameterSetName = SaveDeploymentScriptLogByResourceId, Mandatory = true, HelpMessage = "The directory path to save deployment script log.")]
        [Parameter(Position = 1, ParameterSetName = SaveDeploymentScriptLogByInputObject, Mandatory = true, HelpMessage = "The directory path to save deployment script log.")]
        [ValidateNotNullOrEmpty]
        public string OutputPath { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Forces the overwrite of the existing file.")]
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
                    case SaveDeploymentScriptLogByName:
                        deploymentScriptLog =
                            DeploymentScriptsSdkClient.GetDeploymentScriptLog(Name, ResourceGroupName);
                        break;
                    case SaveDeploymentScriptLogByResourceId:
                        deploymentScriptLog = DeploymentScriptsSdkClient.GetDeploymentScriptLog(
                            ResourceIdUtility.GetResourceName(this.DeploymentScriptResourceId),
                            ResourceIdUtility.GetResourceGroupName(this.DeploymentScriptResourceId));
                        break;
                    case SaveDeploymentScriptLogByInputObject:
                        deploymentScriptLog = DeploymentScriptsSdkClient.GetDeploymentScriptLog(
                            DeploymentScriptInputObject.Name,
                            ResourceIdUtility.GetResourceGroupName(DeploymentScriptInputObject.Id));
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }

                if (!string.IsNullOrEmpty(OutputPath) && !string.IsNullOrEmpty(deploymentScriptLog?.Log))
                {
                    var outputPathWithFileName = Path.Combine(GetValidatedFolderPath(OutputPath),
                        $"{deploymentScriptLog.DeploymentScriptName}.txt");

                    // if a file with the same name exists and -Force is not provided, let's ask if we can replace the file. 
                    this.ConfirmAction(
                        this.Force || !AzureSession.Instance.DataStore.FileExists(outputPathWithFileName),
                        string.Format(
                            Properties.Resources.DeploymentScriptLogFileExists, Name, OutputPath),
                        Properties.Resources.DeploymentScriptShouldProcessString,
                        OutputPath,
                        () =>
                        {
                            AzureSession.Instance.DataStore.WriteFile(outputPathWithFileName,
                                deploymentScriptLog.Log);

                            WriteObject(new PsDeploymentScriptLogPath() {Path = outputPathWithFileName});
                        });
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
