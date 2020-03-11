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
    [Cmdlet(VerbsCommon.Get,  AzureRMConstants.AzureRMPrefix + "DeploymentScript", DefaultParameterSetName = GetAzDeploymentScript.ListDeploymentScript), OutputType(typeof(PsDeploymentScript))]
    public class GetAzDeploymentScript : DeploymentScriptCmdletBase
    {
        #region Cmdlet Parameters and Parameter Set Definitions

        internal const string GetDeploymentScriptByName = "GetDeploymentScriptByName";
        internal const string GetDeploymentScriptByResourceId = "GetDeploymentScriptByResourceId";
        internal const string ListDeploymentScript = "ListDeploymentScript";

        [Parameter(Position = 0, ParameterSetName = ListDeploymentScript, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 1, ParameterSetName = GetDeploymentScriptByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name of the deployment script")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Alias("ResourceId")]
        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptByResourceId, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/resourceGroups/{rgName}/providers/Microsoft.Resources/deploymentScripts/{deploymentScriptName}")]
        [ValidateNotNullOrEmpty]
        [ResourceIdCompleter("Microsoft.Resources/deploymentScripts")]
        public string Id { get; set; }

        #endregion

        #region Cmdlet Overrides

        public override void ExecuteCmdlet()
        {
            try
            {
                switch (ParameterSetName)
                {
                    case GetDeploymentScriptByName:
                        WriteObject(DeploymentScriptsSdkClient.GetDeploymentScript(Name, ResourceGroupName));
                        break;
                    case GetDeploymentScriptByResourceId:
                        WriteObject(DeploymentScriptsSdkClient.GetDeploymentScript(ResourceIdUtility.GetResourceName(this.Id), 
                            ResourceIdUtility.GetResourceGroupName(this.Id)));
                        break;
                    case ListDeploymentScript:
                        WriteObject(!string.IsNullOrEmpty(ResourceGroupName)
                            ? DeploymentScriptsSdkClient.ListDeploymentScriptsByResourceGroup(ResourceGroupName)
                            : DeploymentScriptsSdkClient.ListDeploymentScriptsBySubscription());
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

        #endregion Cmdlet Overrides
    }
}
