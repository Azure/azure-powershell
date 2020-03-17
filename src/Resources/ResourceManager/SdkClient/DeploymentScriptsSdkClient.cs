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
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class DeploymentScriptsSdkClient
    {
        public IDeploymentScriptsClient DeploymentScriptsClient { get; set; }

        private IAzureContext azureContext;

        public DeploymentScriptsSdkClient(IDeploymentScriptsClient deploymentScriptsClient)
        {
            this.DeploymentScriptsClient = deploymentScriptsClient;
        }

        /// <summary>
        /// Parameter-less constructor for mocking
        /// </summary>
        public DeploymentScriptsSdkClient()
        {
        }

        public DeploymentScriptsSdkClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<DeploymentScriptsClient>(context,
                    AzureEnvironment.Endpoint.ResourceManager))
        {
            this.azureContext = context;
        }

        public PsDeploymentScript GetDeploymentScript(string scriptName, string resourceGroupName)
        {
            var deploymentScript = DeploymentScriptsClient.DeploymentScripts.Get(resourceGroupName, scriptName);

            PsDeploymentScript psDeploymentScriptObject;

            switch (deploymentScript)
            {
                case AzurePowerShellScript azurePowerShellScript:
                    psDeploymentScriptObject = PsAzurePowerShellScript.ToPsAzurePowerShellScript(azurePowerShellScript);
                    break;
                case AzureCliScript azureCliScript:
                    psDeploymentScriptObject = PsAzureCliScript.ToPsAzureCliScript(azureCliScript);
                    break;
                default:
                    throw new NotSupportedException(Properties.Resources.DeploymentScriptKindNotSupported);
            }

            return psDeploymentScriptObject;
        }

        public virtual PsDeploymentScriptLog GetDeploymentScriptLog(string scriptName, string resourceGroupName)
        {
            var deploymentScriptLog =
                DeploymentScriptsClient.DeploymentScripts.GetLogsDefault(resourceGroupName, scriptName);

            return PsDeploymentScriptLog.ToPsDeploymentScriptLog(deploymentScriptLog);
        }

        public IEnumerable<PsDeploymentScript> ListDeploymentScriptsBySubscription()
        {
            var list = new List<PsDeploymentScript>();

            var deploymentScripts = DeploymentScriptsClient.DeploymentScripts.ListBySubscription();

            list.AddRange(deploymentScripts.Select(TypeCastDeploymentScript));

            while (deploymentScripts.NextPageLink != null)
            {
                deploymentScripts =
                    DeploymentScriptsClient.DeploymentScripts.ListBySubscriptionNext(deploymentScripts.NextPageLink);

                list.AddRange(deploymentScripts.Select(TypeCastDeploymentScript));
            }

            return list;
        }

        public IEnumerable<PsDeploymentScript> ListDeploymentScriptsByResourceGroup(string resourceGroupName)
        {
            var list = new List<PsDeploymentScript>();

            var deploymentScripts = DeploymentScriptsClient.DeploymentScripts.ListByResourceGroup(resourceGroupName);

            list.AddRange(deploymentScripts.Select(TypeCastDeploymentScript));

            while (deploymentScripts.NextPageLink != null)
            {
                deploymentScripts =
                    DeploymentScriptsClient.DeploymentScripts.ListByResourceGroupNext(deploymentScripts.NextPageLink);
                list.AddRange(deploymentScripts.Select(TypeCastDeploymentScript));
            }

            return list;
        }

        public bool DeleteDeploymentScript(string name, string resourceGroupName)
        {
            var response = DeploymentScriptsClient.DeploymentScripts.DeleteWithHttpMessagesAsync(resourceGroupName,name).GetAwaiter().GetResult();

            // response can be 200(deleted) or 204 (no content). 204 is set for Not Found response.
            // Based on the PowerShell guidance, throw exception when service returns 204.
            // -------------------------------------------------------------------------------------

            if (response.Response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new ArgumentException(string.Format(Properties.Resources.DeploymentScriptDoesntExist, name, resourceGroupName));
            }

            return true;
        }

        private PsDeploymentScript TypeCastDeploymentScript(DeploymentScript deploymentScript)
        {
            switch (deploymentScript)
            {
                case AzurePowerShellScript azurePowerShellScript:
                    return PsAzurePowerShellScript.ToPsAzurePowerShellScript(azurePowerShellScript);
                case AzureCliScript azureCliScript:
                    return PsAzureCliScript.ToPsAzureCliScript(azureCliScript);
                default:
                    throw new NotSupportedException(Properties.Resources.DeploymentScriptKindNotSupported);
            }
        }
    }
}
