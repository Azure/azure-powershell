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

using System.Management.Automation;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    [Cmdlet(VerbsCommon.Get,  AzureRMConstants.AzureRMPrefix + "DeploymentScript", DefaultParameterSetName = GetAzDeploymentScript.ListDeploymentScript), OutputType(typeof(PsDeploymentScript), typeof(PsDeploymentScript))]
    public class GetAzDeploymentScript : ResourceManagerCmdletBase
    {
        internal const string GetDeploymentScriptByName = "GetDeploymentScriptByName";
        internal const string GetDeploymentScriptById = "GetDeploymentScriptById";
        internal const string ListDeploymentScript = "GetDeploymentScriptList";

        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 0, ParameterSetName = ListDeploymentScript, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptByName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        public string SubscriptionId { get; set; }

        [Parameter(Position = 0, ParameterSetName = ListDeploymentScript, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [Parameter(Position = 0, ParameterSetName = GetDeploymentScriptByName, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "To-Do")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Alias("ResourceId")]
        [Parameter(ParameterSetName = GetDeploymentScriptById, Mandatory = true, ValueFromPipelineByPropertyName = true,
            HelpMessage = "The fully qualified resource Id of the deployment script. Example: /subscriptions/{subId}/providers/Microsoft.Resources/deploymentScripts/{deploymentName}")]
        [ValidateNotNullOrEmpty]
        public string Id { get; set; }

        #region Cmdlet Overrides
        public override void ExecuteCmdlet()
        {
            var subscriptionId = SubscriptionId ?? DefaultContext.Subscription.Id;

            try
            {
                switch (ParameterSetName)
                {
                    case GetAzDeploymentScript.GetDeploymentScriptByName:
                        WriteObject(DeploymentScriptsSdkClient.GetDeploymentScript(Name, ResourceGroupName));
                        break;
                    case GetDeploymentScriptById:
                        break;
                    case ListDeploymentScript:
                        if (!string.IsNullOrEmpty(ResourceGroupName))
                        {
                            //WriteObject();
                        }

                        //List DS under subscriptions
                        break;
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
