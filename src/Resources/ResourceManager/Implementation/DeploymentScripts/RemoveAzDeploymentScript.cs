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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.DeploymentScripts
{
    [Cmdlet(VerbsCommon.Remove, AzureRMConstants.AzureRMPrefix + "DeploymentScript", SupportsShouldProcess = true, DefaultParameterSetName = RemoveAzDeploymentScript.RemoveDeploymentScriptByName), OutputType(typeof(PsDeploymentScript))]
    public class RemoveAzDeploymentScript : DeploymentScriptCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string RemoveDeploymentScriptByName = "RemoveDeploymentScriptLogByName";
        internal const string RemoveDeploymentScriptByResourceId = "RemoveDeploymentScriptLogByResourceId";
        internal const string RemoveDeploymentScriptByInputObject = "RemoveDeploymentScriptLogByInputObject";

        [Parameter(Position = 0, ParameterSetName = RemoveDeploymentScriptByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = RemoveDeploymentScriptByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ResourceId")]
        [Parameter(Position = 0, ParameterSetName = RemoveDeploymentScriptByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deploymentScripts/{deploymentScriptName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/deploymentScripts")]
        public string Id { get; set; }

        [Parameter(Position = 0, ParameterSetName = RemoveDeploymentScriptByInputObject, Mandatory = true, ValueFromPipeline = true, HelpMessage = "The deployment script PowerShell object.")]
        [ValidateNotNullOrEmpty]
        public PsDeploymentScript InputObject { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                string scriptName = "";

                switch (ParameterSetName)
                {
                    case RemoveDeploymentScriptByName:
                        scriptName = Name;
                        if (ShouldProcess(scriptName, "Remove Deployment Script"))
                        {
                            DeploymentScriptsSdkClient.DeleteDeploymentScript(scriptName, ResourceGroupName);
                        }
                        break;
                    case RemoveDeploymentScriptByResourceId:
                        scriptName = ResourceIdUtility.GetResourceName(this.Id);
                        if (ShouldProcess(scriptName, "Remove Deployment Script"))
                        {
                            DeploymentScriptsSdkClient.DeleteDeploymentScript(scriptName,
                                ResourceIdUtility.GetResourceGroupName(this.Id));
                        }
                        break;
                    case RemoveDeploymentScriptByInputObject:
                        scriptName = InputObject.Name;
                        if (ShouldProcess(scriptName, "Remove Deployment Script"))
                        {
                            DeploymentScriptsSdkClient.DeleteDeploymentScript(scriptName, 
                                ResourceIdUtility.GetResourceGroupName(InputObject.Id));
                        }
                        break;
                    default:
                        throw new PSInvalidOperationException();
                }

                if (PassThru.IsPresent)
                {
                    WriteObject(true);
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
