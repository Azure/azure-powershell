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

using System;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

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
        /// Parameterless constructor for mocking
        /// </summary>
        public DeploymentScriptsSdkClient()
        {

        }

        public DeploymentScriptsSdkClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<DeploymentScriptsClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
            this.azureContext = context;

        }


        public PsDeploymentScript GetDeploymentScript(string scriptName, string resourceGroupName)
        {
            var deploymentScript = DeploymentScriptsClient.DeploymentScripts.Get(resourceGroupName, scriptName);

            PsDeploymentScript DeploymentScript = null;

            switch (deploymentScript)
            {
                case AzurePowerShellScript azurePowerShellScript:
                    DeploymentScript = PsAzurePowerShellScript.ToPsAzurePowerShellScript(azurePowerShellScript);
                    break;
                case AzureCliScript azureCliScript:
                    DeploymentScript = PsAzureCliScript.ToPsAzureCliScript(azureCliScript);
                    break;
                default:
                    throw new NotSupportedException(Properties.Resources.DeploymentScriptKindNotSupported);
            }

            return DeploymentScript;
        }
    }
}
