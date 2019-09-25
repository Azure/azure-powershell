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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class DeploymentCmdletBase : ResourceManagerCmdletBase
    {
        protected RuntimeDefinedParameterDictionary dynamicParameters;

        private Hashtable templateObject;

        private string templateFile;

        protected DeploymentCmdletBase()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
        }

        public abstract Hashtable TemplateParameterObject { get; set; }

        public abstract string TemplateParameterFile { get; set; }

        public abstract Hashtable TemplateObject { get; set; }

        public abstract string TemplateFile { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Skips the PowerShell dynamic parameter processing that checks if the provided template parameter contains all necessary parameters used by the template. " +
                                                    "This check would prompt the user to provide a value for the missing parameters, but providing the -SkipTemplateParameterPrompt will ignore this prompt and " +
                                                    "error out immediately if a parameter was found not to be bound in the template. For non-interactive scripts, -SkipTemplateParameterPrompt can be provided " +
                                                    "to provide a better error message in the case where not all required parameters are satisfied.")]
        public SwitchParameter SkipTemplateParameterPrompt { get; set; }

        public object GetDynamicParameters()
        {
            if (!this.IsParameterBound(c => c.SkipTemplateParameterPrompt))
            {
                var templateParameterFilePath = Uri.IsWellFormedUriString(this.TemplateParameterFile, UriKind.Absolute)
                    ? this.TemplateParameterFile
                    : this.ResolvePath(TemplateParameterFile);

                if (this.TemplateObject != null && this.TemplateObject != this.templateObject)
                {
                    this.templateObject = this.TemplateObject;

                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        this.TemplateObject,
                        this.TemplateParameterObject,
                        templateParameterFilePath,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
                else if (!string.IsNullOrEmpty(this.TemplateFile) &&
                    !this.TemplateFile.Equals(this.templateFile, StringComparison.OrdinalIgnoreCase))
                {
                    this.templateFile = this.TemplateFile;

                    var templateFilePath = Uri.IsWellFormedUriString(this.TemplateFile, UriKind.Absolute)
                        ? this.TemplateFile
                        : this.ResolvePath(TemplateFile);

                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        templateFilePath,
                        this.TemplateParameterObject,
                        templateParameterFilePath,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());

                }
            }

            RegisterDynamicParameters(dynamicParameters);

            return dynamicParameters;
        }

        protected Hashtable GetTemplateParameterObject(Hashtable templateParameterObject)
        {
            // NOTE(jogao): create a new Hashtable so that user can re-use the templateParameterObject.
            var prameterObject = new Hashtable();
            if (templateParameterObject != null)
            {
                foreach (var parameterKey in templateParameterObject.Keys)
                {
                    // Let default behavior of a value parameter if not a KeyVault reference Hashtable
                    var hashtableParameter = templateParameterObject[parameterKey] as Hashtable;
                    if (hashtableParameter != null && hashtableParameter.ContainsKey("reference"))
                    {
                        prameterObject[parameterKey] = templateParameterObject[parameterKey];
                    }
                    else
                    {
                        prameterObject[parameterKey] = new Hashtable { { "value", templateParameterObject[parameterKey] } };
                    }
                }
            }

            // Load parameters from the file
            string templateParameterFilePath = this.ResolvePath(TemplateParameterFile);
            if (templateParameterFilePath != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
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

                    prameterObject[dp.Key] = parameter;
                });
            }

            // Load dynamic parameters
            IEnumerable<RuntimeDefinedParameter> parameters = PowerShellUtilities.GetUsedDynamicParameters(this.AsJobDynamicParameters, MyInvocation);
            if (parameters.Any())
            {
                parameters.ForEach(dp => prameterObject[((ParameterAttribute)dp.Attributes[0]).HelpMessage] = new Hashtable { { "value", dp.Value } });
            }

            return prameterObject;
        }

        protected string GetDeploymentDebugLogLevel(string deploymentDebugLogLevel)
        {
            string debugSetting = string.Empty;
            if (!string.IsNullOrEmpty(deploymentDebugLogLevel))
            {
                switch (deploymentDebugLogLevel.ToLower())
                {
                    case "all":
                        debugSetting = "RequestContent,ResponseContent";
                        break;
                    case "requestcontent":
                        debugSetting = "RequestContent";
                        break;
                    case "responsecontent":
                        debugSetting = "ResponseContent";
                        break;
                    case "none":
                        debugSetting = null;
                        break;
                }
            }

            return debugSetting;
        }
    }
}
