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

using Microsoft.Azure.Commands.Resources.Models;
using Microsoft.Azure.Commands.Utilities.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Resources
{
    public abstract class ResourceWithParameterBaseCmdlet : ResourcesBaseCmdlet
    {
        protected const string BaseParameterSetName = "Default";
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

        protected ResourceWithParameterBaseCmdlet()
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
                    dynamicParameters = GetTemplateParametersFromFile(
                        TemplateFile,
                        TemplateParameterObject,
                        TemplateParameterFile,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
                else
                {
                    dynamicParameters = GetTemplateParametersFromFile(
                        TemplateFile,
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
                    dynamicParameters = GetTemplateParametersFromFile(
                        TemplateUri,
                        TemplateParameterObject,
                        TemplateParameterFile,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
                else
                {
                    dynamicParameters = GetTemplateParametersFromFile(
                        TemplateUri,
                        TemplateParameterObject,
                        TemplateParameterUri,
                        MyInvocation.MyCommand.Parameters.Keys.ToArray());
                }
            }

            return dynamicParameters;
        }

        /// <summary>
        /// Gets the parameters for a given template file.
        /// </summary>
        /// <param name="templateFilePath">The gallery template path (local or remote)</param>
        /// <param name="templateParameterObject">Existing template parameter object</param>
        /// <param name="templateParameterFilePath">Path to the template parameter file if present</param>
        /// <param name="staticParameters">The existing PowerShell cmdlet parameters</param>
        /// <returns>The template parameters</returns>
        protected RuntimeDefinedParameterDictionary GetTemplateParametersFromFile(string templateFilePath, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();
            string templateContent = null;

            if (templateFilePath != null)
            {
                if (Uri.IsWellFormedUriString(templateFilePath, UriKind.Absolute))
                {
                    templateContent = GeneralUtilities.DownloadFile(templateFilePath);
                }
                else if (DataStore.FileExists(templateFilePath))
                {
                    templateContent = DataStore.ReadFileAsText(templateFilePath);
                }
            }

            dynamicParameters = ParseTemplateAndExtractParameters(templateContent, templateParameterObject, templateParameterFilePath, staticParameters);

            return dynamicParameters;
        }

        protected Dictionary<string, TemplateFileParameterV1> ParseTemplateParameterFileContents(string templateParameterFilePath)
        {
            Dictionary<string, TemplateFileParameterV1> parameters = new Dictionary<string, TemplateFileParameterV1>();

            if (!string.IsNullOrEmpty(templateParameterFilePath) &&
                DataStore.FileExists(templateParameterFilePath))
            {
                try
                {
                    parameters = JsonConvert.DeserializeObject<Dictionary<string, TemplateFileParameterV1>>(
                        DataStore.ReadFileAsText(templateParameterFilePath));
                }
                catch (JsonSerializationException)
                {
                    parameters = new Dictionary<string, TemplateFileParameterV1>(
                        JsonConvert.DeserializeObject<TemplateFileParameterV2>(DataStore.ReadFileAsText(templateParameterFilePath)).Parameters);
                }
            }

            return parameters;
        }

        private RuntimeDefinedParameterDictionary ParseTemplateAndExtractParameters(string templateContent, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();

            if (!string.IsNullOrEmpty(templateContent))
            {
                TemplateFile templateFile = null;

                try
                {
                    templateFile = JsonConvert.DeserializeObject<TemplateFile>(templateContent);
                    if (templateFile.Parameters == null)
                    {
                        return dynamicParameters;
                    }
                }
                catch
                {
                    // Can't parse the template file, do not generate dynamic parameters
                    return dynamicParameters;
                }

                foreach (KeyValuePair<string, TemplateFileParameterV1> parameter in templateFile.Parameters)
                {
                    RuntimeDefinedParameter dynamicParameter = ConstructDynamicParameter(staticParameters, parameter);
                    dynamicParameters.Add(dynamicParameter.Name, dynamicParameter);
                }
            }
            if (templateParameterObject != null)
            {
                UpdateParametersWithObject(dynamicParameters, templateParameterObject);
            }
            if (templateParameterFilePath != null && DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = ParseTemplateParameterFileContents(templateParameterFilePath);
                UpdateParametersWithObject(dynamicParameters, new Hashtable(parametersFromFile));
            }
            if (templateParameterFilePath != null && Uri.IsWellFormedUriString(templateParameterFilePath, UriKind.Absolute))
            {
                var parametersFromUri = ParseTemplateParameterContent(GeneralUtilities.DownloadFile(templateParameterFilePath));
                UpdateParametersWithObject(dynamicParameters, new Hashtable(parametersFromUri));
            }
            return dynamicParameters;
        }
        protected Dictionary<string, TemplateFileParameterV1> ParseTemplateParameterContent(string templateParameterContent)
        {
            Dictionary<string, TemplateFileParameterV1> parameters = new Dictionary<string, TemplateFileParameterV1>();

            if (!string.IsNullOrEmpty(templateParameterContent))
            {
                try
                {
                    parameters = JsonConvert.DeserializeObject<Dictionary<string, TemplateFileParameterV1>>(templateParameterContent);
                }
                catch (JsonSerializationException)
                {
                    parameters = new Dictionary<string, TemplateFileParameterV1>(
                        JsonConvert.DeserializeObject<TemplateFileParameterV2>(templateParameterContent).Parameters);
                }
            }

            return parameters;
        }

        private void UpdateParametersWithObject(RuntimeDefinedParameterDictionary dynamicParameters, Hashtable templateParameterObject)
        {
            if (templateParameterObject != null)
            {
                foreach (KeyValuePair<string, RuntimeDefinedParameter> dynamicParameter in dynamicParameters)
                {
                    try
                    {
                        foreach (string key in templateParameterObject.Keys)
                        {
                            if (key.Equals(dynamicParameter.Key, StringComparison.OrdinalIgnoreCase))
                            {
                                if (templateParameterObject[key] is TemplateFileParameterV1)
                                {
                                    dynamicParameter.Value.Value = (templateParameterObject[key] as TemplateFileParameterV1).Value;
                                }
                                else
                                {
                                    dynamicParameter.Value.Value = templateParameterObject[key];
                                }
                                dynamicParameter.Value.IsSet = true;
                                ((ParameterAttribute)dynamicParameter.Value.Attributes[0]).Mandatory = false;
                            }
                        }
                    }
                    catch
                    {
                        throw new ArgumentException(string.Format(Resources.Properties.Resources.FailureParsingTemplateParameterObject,
                                                                  dynamicParameter.Key,
                                                                  templateParameterObject[dynamicParameter.Key]));
                    }
                }
            }
        }

        protected RuntimeDefinedParameter ConstructDynamicParameter(string[] staticParameters, KeyValuePair<string, TemplateFileParameterV1> parameter)
        {
            const string duplicatedParameterSuffix = "FromTemplate";
            string name = parameter.Key;
            object defaultValue = parameter.Value.DefaultValue;

            RuntimeDefinedParameter runtimeParameter = new RuntimeDefinedParameter()
            {
                // For duplicated template parameter names, add a suffix FromTemplate to distinguish them from the cmdlet parameter.
                Name = staticParameters.Any(n => n.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    ? name + duplicatedParameterSuffix : name,
                ParameterType = GetParameterType(parameter.Value.Type),
                Value = defaultValue
            };
            runtimeParameter.Attributes.Add(new ParameterAttribute()
            {
                Mandatory = defaultValue == null ? true : false,
                ValueFromPipelineByPropertyName = true,
                // Rely on the HelpMessage property to detect the original name for the dynamic parameter.
                HelpMessage = name
            });

            if (parameter.Value.AllowedValues != null && parameter.Value.AllowedValues.Count > 0)
            {
                runtimeParameter.Attributes.Add(new ValidateSetAttribute(parameter.Value.AllowedValues.ToArray())
                {
                    IgnoreCase = true,
                });
            }

            if (!string.IsNullOrEmpty(parameter.Value.MinLength) &&
                !string.IsNullOrEmpty(parameter.Value.MaxLength))
            {
                runtimeParameter.Attributes.Add(new ValidateLengthAttribute(int.Parse(parameter.Value.MinLength), int.Parse(parameter.Value.MaxLength)));
            }

            return runtimeParameter;
        }

        protected Type GetParameterType(string resourceParameterType)
        {

            if(string.IsNullOrEmpty(resourceParameterType))
            {
                throw new PSArgumentException("resourceParameterType");
            }

            const string stringType = "string";
            const string intType = "int";
            const string boolType = "bool";

            Type typeObject = typeof(object);

            if (resourceParameterType.Equals(stringType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(string);
            }
            else if (resourceParameterType.Equals(intType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(int);
            }
            else if (resourceParameterType.Equals(boolType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(bool);
            }

            return typeObject;
        }

        protected Hashtable GetTemplateParameterObject(Hashtable templateParameterObject)
        {
            templateParameterObject = templateParameterObject ?? new Hashtable();

            // Load parameters from the file
            string templateParameterFilePath = TemplateParameterFile;
            if (templateParameterFilePath != null && DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = this.ParseTemplateParameterFileContents(templateParameterFilePath);
                parametersFromFile.ForEach(dp => templateParameterObject[dp.Key] = dp.Value.Value);
            }

            // Load dynamic parameters
            IEnumerable<RuntimeDefinedParameter> parameters = PowerShellUtilities.GetUsedDynamicParameters(dynamicParameters, MyInvocation);
            if (parameters.Any())
            {
                parameters.ForEach(dp => templateParameterObject[((ParameterAttribute)dp.Attributes[0]).HelpMessage] = dp.Value);
            }

            return templateParameterObject;
        }
    }
}
