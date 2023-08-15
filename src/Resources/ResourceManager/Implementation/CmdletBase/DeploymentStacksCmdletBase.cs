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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class DeploymentStacksCmdletBase : ResourceManagerCmdletBase
    {

        /// <summary>
        /// Deployment stacks client instance field
        /// </summary>
        private DeploymentStacksSdkClient deploymentStacksSdkClient;

        /// <summary>
        /// Gets or sets the deployment stacks sdk client
        /// </summary>
        public DeploymentStacksSdkClient DeploymentStacksSdkClient
        {
            get
            {
                if (this.deploymentStacksSdkClient == null)
                {
                    this.deploymentStacksSdkClient = new DeploymentStacksSdkClient(DefaultContext);
                }

                this.deploymentStacksSdkClient.VerboseLogger = WriteVerboseWithTimestamp;
                this.deploymentStacksSdkClient.ErrorLogger = WriteErrorWithTimestamp;
                this.deploymentStacksSdkClient.WarningLogger = WriteWarningWithTimestamp;

                return this.deploymentStacksSdkClient;
            }

            set
            {
                this.deploymentStacksSdkClient = value;
            }
        }

        protected string ResolveBicepFile(string TemplateFile)
        {
            if (BicepUtility.IsBicepFile(TemplateFile))
            {
                return BicepUtility.BuildFile(this.ResolvePath(TemplateFile), this.WriteVerbose, this.WriteWarning);
            }
            else
                return TemplateFile;
            
        }

        protected string ResolveBicepParameterFile(string TemplateParameterFile)
        {
            if (BicepUtility.IsBicepparamFile(TemplateParameterFile))
            {
                return BicepUtility.BuildParamFile(this.ResolvePath(TemplateParameterFile), this.WriteVerbose, this.WriteWarning);
            }
            else
                return TemplateParameterFile;
        }

        protected Hashtable GetParameterObject(string parameterFile)
        {
            var parameters = new Hashtable();
            string templateParameterFilePath = this.ResolvePath(parameterFile);
            if (parameterFile != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = TemplateUtility.ParseTemplateParameterFileContents(templateParameterFilePath);
                parametersFromFile.ForEach(dp =>
                {
                    var parameter = new Hashtable();
                    if (dp.Value.Value != null)
                    {
                        parameter.Add("value", dp.Value.Value);
                    }
                    if (dp.Value.Reference != null)
                    {
                        parameter.Add("reference", dp.Value.Reference);
                    }

                    parameters[dp.Key] = parameter;
                });
            }
            return parameters;
        }

        protected Hashtable GetTemplateParameterObject(Hashtable templateParameterObject)
        {
            //create a new Hashtable so that user can re-use the templateParameterObject.
            var parameterObject = new Hashtable();
            foreach (var parameterKey in templateParameterObject.Keys)
            {
                // Let default behavior of a value parameter if not a KeyVault reference Hashtable
                var hashtableParameter = templateParameterObject[parameterKey] as Hashtable;
                if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                {
                    parameterObject[parameterKey] = templateParameterObject[parameterKey];
                }
                else
                {
                    parameterObject[parameterKey] = new Hashtable { { "value", templateParameterObject[parameterKey] } };
                }
            }
            return parameterObject;
        }
    }
}
