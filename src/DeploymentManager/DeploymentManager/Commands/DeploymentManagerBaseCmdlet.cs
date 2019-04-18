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

namespace Microsoft.Azure.Commands.DeploymentManager.Commands
{
    using Microsoft.Azure.Commands.DeploymentManager.Client;
    using ResourceManager.Common;

    /// <summary>
    /// The base class for all the cmdlets.
    /// </summary>
    public abstract class DeploymentManagerBaseCmdlet : AzureRMCmdlet
    {
        /// <summary>
        /// The client used to communicate with Azure Deployment Manager.
        /// </summary>
        private DeploymentManagerClient deploymentManagerClient;

        /// <summary>
        /// The parameter set name to be used when individual properties are given to identify a resource.
        /// </summary>
        protected const string InteractiveParamSetName = "Interactive";

        /// <summary>
        /// The parameter set name to be used for parameter set where a resource identifier is provided.
        /// </summary>
        protected const string ResourceIdParamSetName = "ResourceId";

        /// <summary>
        /// The parameter set name to be used for parameter set where a resource object is provided.
        /// </summary>
        protected const string InputObjectParamSetName = "InputObject";

        /// <summary>
        /// Gets or sets the Azure Deployment Manager client.
        /// </summary>
        internal DeploymentManagerClient DeploymentManagerClient
        {
            get
            {
                if (this.deploymentManagerClient == null)
                {
                    this.deploymentManagerClient = new DeploymentManagerClient(DefaultProfile.DefaultContext);
                }

                this.deploymentManagerClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.deploymentManagerClient.ErrorLogger = WriteErrorWithTimestamp;
                return this.deploymentManagerClient;
            }

            set { this.deploymentManagerClient = value; }
        }
    }
}
