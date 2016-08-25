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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    public abstract class ResourceWithParameterCmdletBase : ResourceManagerCmdletBase
    {
        protected const string TemplateFileParameterObjectParameterSetName = "Deployment via template file and template parameters object";
        protected const string TemplateFileParameterFileParameterSetName = "Deployment via template file and template parameters file";
        protected const string TemplateFileParameterUriParameterSetName = "Deployment via template file template parameters uri";
        protected const string TemplateUriParameterObjectParameterSetName = "Deployment via template uri and template parameters object";
        protected const string TemplateUriParameterFileParameterSetName = "Deployment via template uri and template parameters file";
        protected const string TemplateUriParameterUriParameterSetName = "Deployment via template uri and template parameters uri";
        protected const string ParameterlessTemplateFileParameterSetName = "Deployment via template file without parameters";
        protected const string ParameterlessGalleryTemplateParameterSetName = "Deployment via Gallery without parameters";
        protected const string ParameterlessTemplateUriParameterSetName = "Deployment via template uri without parameters";

        protected RuntimeDefinedParameterDictionary dynamicParameters;

        private string templateFile;

        private string templateUri;

        protected ResourceWithParameterCmdletBase()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
        }

        [Parameter(ParameterSetName = TemplateFileParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        [Parameter(ParameterSetName = TemplateUriParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A hash table which represents the parameters.")]
        public Hashtable TemplateParameterObject { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "A file that has the template parameters.")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterFile { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [Parameter(ParameterSetName = TemplateUriParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template parameter file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateParameterUri { get; set; }

        [Parameter(ParameterSetName = TemplateFileParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [Parameter(ParameterSetName = TemplateFileParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [Parameter(ParameterSetName = TemplateFileParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [Parameter(ParameterSetName = ParameterlessTemplateFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Local path to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateFile { get; set; }

        [Parameter(ParameterSetName = TemplateUriParameterObjectParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = TemplateUriParameterFileParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = TemplateUriParameterUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [Parameter(ParameterSetName = ParameterlessTemplateUriParameterSetName,
            Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Uri to the template file.")]
        [ValidateNotNullOrEmpty]
        public string TemplateUri { get; set; }

        public object GetDynamicParameters()
        {
            if (!string.IsNullOrEmpty(TemplateFile) &&
                !TemplateFile.Equals(templateFile, StringComparison.OrdinalIgnoreCase))
            {
                templateFile = TemplateFile;
                if (string.IsNullOrEmpty(TemplateParameterUri))
                {
                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        this.TryResolvePath(TemplateFile),
                        TemplateParameterObject,
                        this.TryResolvePath(TemplateParameterFile),
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
                else
                {
                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        this.TryResolvePath(TemplateFile),
                        TemplateParameterObject,
                        TemplateParameterUri,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
            }
            else if (!string.IsNullOrEmpty(TemplateUri) &&
                !TemplateUri.Equals(templateUri, StringComparison.OrdinalIgnoreCase))
            {
                templateUri = TemplateUri;
                if (string.IsNullOrEmpty(TemplateParameterUri))
                {
                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        TemplateUri,
                        TemplateParameterObject,
                        this.TryResolvePath(TemplateParameterFile),
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
                else
                {
                    dynamicParameters = TemplateUtility.GetTemplateParametersFromFile(
                        TemplateUri,
                        TemplateParameterObject,
                        TemplateParameterUri,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
            }

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
                    prameterObject[parameterKey] = new Hashtable { { "value", templateParameterObject[parameterKey] } };
                }
            }

            // Load parameters from the file
            string templateParameterFilePath = this.TryResolvePath(TemplateParameterFile);
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
            IEnumerable<RuntimeDefinedParameter> parameters = PowerShellUtilities.GetUsedDynamicParameters(dynamicParameters, MyInvocation);
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
