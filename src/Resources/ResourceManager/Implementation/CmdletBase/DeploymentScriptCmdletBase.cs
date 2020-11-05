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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient;
using Microsoft.Azure.Commands.ResourceManager.Common;
using System;
using System.IO;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public class DeploymentScriptCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Deployment scripts client instance field
        /// </summary>
        private DeploymentScriptsSdkClient deploymentScriptsSdkClient;

        /// <summary>
        /// Gets or sets the resource manager sdk client
        /// </summary>
        public DeploymentScriptsSdkClient DeploymentScriptsSdkClient
        {
            get
            {
                if (this.deploymentScriptsSdkClient == null)
                {
                    this.deploymentScriptsSdkClient = new DeploymentScriptsSdkClient(DefaultContext);
                }

                return this.deploymentScriptsSdkClient;
            }

            set { this.deploymentScriptsSdkClient = value; }
        }

        /// <summary>
        /// Override method to extract inner errors.
        /// </summary>
        /// <param name="ex">exception</param>
        protected override void WriteExceptionError(Exception ex)
        {
            var aggEx = ex as AggregateException;

            if (aggEx != null && aggEx.InnerExceptions != null)
            {
                foreach (var e in aggEx.Flatten().InnerExceptions)
                {
                    WriteExceptionError(e);
                }

                return;
            }

            base.WriteExceptionError(ex);
        }

        /// <summary>
        /// Returns validated folder path for any given path.
        /// </summary>
        /// <param name="folderPath">string directory path to save to</param> 
        protected string GetValidatedFolderPath(string folderPath)
        {
            var path = ResolveUserPath(folderPath);

            if (!AzureSession.Instance.DataStore.DirectoryExists(path))
            {
                throw new DirectoryNotFoundException($"Cannot find path '{path}'");
            }

            return path;
        }
    }
}
