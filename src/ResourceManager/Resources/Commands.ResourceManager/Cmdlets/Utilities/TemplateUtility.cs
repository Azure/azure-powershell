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
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Diagnostics;
using System.Security;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    public static class TemplateUtility
    {
        /// <summary>
        /// Gets the parameters for a given template file.
        /// </summary>
        /// <param name="templateFilePath">The gallery template path (local or remote)</param>
        /// <param name="templateParameterObject">Existing template parameter object</param>
        /// <param name="templateParameterFilePath">Path to the template parameter file if present</param>
        /// <param name="staticParameters">The existing PowerShell cmdlet parameters</param>
        /// <returns>The template parameters</returns>
        public static RuntimeDefinedParameterDictionary GetTemplateParametersFromFile(string templateFilePath, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            string templateContent = null;

            if (templateFilePath != null)
            {
                if (Uri.IsWellFormedUriString(templateFilePath, UriKind.Absolute))
                {
                    templateContent = GeneralUtilities.DownloadFile(templateFilePath);
                }
                else if (FileUtilities.DataStore.FileExists(templateFilePath))
                {
                    templateContent = FileUtilities.DataStore.ReadFileAsText(templateFilePath);
                }
            }

            RuntimeDefinedParameterDictionary dynamicParameters = ParseTemplateAndExtractParameters(templateContent, templateParameterObject, templateParameterFilePath, staticParameters);

            return dynamicParameters;
        }

        public static Dictionary<string, TemplateFileParameterV1> ParseTemplateParameterFileContents(string templateParameterFilePath)
        {
            Dictionary<string, TemplateFileParameterV1> parameters = new Dictionary<string, TemplateFileParameterV1>();

            if (!string.IsNullOrEmpty(templateParameterFilePath) && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                try
                {
                    parameters = JsonConvert.DeserializeObject<Dictionary<string, TemplateFileParameterV1>>(FileUtilities.DataStore.ReadFileAsText(templateParameterFilePath));
                }
                catch (JsonSerializationException)
                {
                    parameters = new Dictionary<string, TemplateFileParameterV1>(
                        JsonConvert.DeserializeObject<TemplateFileParameterV2>(FileUtilities.DataStore.ReadFileAsText(templateParameterFilePath)).Parameters);
                }
            }

            return parameters;
        }

        public static Dictionary<string, TemplateFileParameterV1> ParseTemplateParameterContent(string templateParameterContent)
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

        private static RuntimeDefinedParameterDictionary ParseTemplateAndExtractParameters(string templateContent, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
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
                catch(Exception e)
                {
                    // Can't parse the template file, do not generate dynamic parameters
                    Debug.WriteLine("Unable to parse template file. The exception received was: " + e.Message);
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
            if (templateParameterFilePath != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
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

        private static void UpdateParametersWithObject(RuntimeDefinedParameterDictionary dynamicParameters, Hashtable templateParameterObject)
        {
            if (templateParameterObject != null)
            {
                foreach (KeyValuePair<string, RuntimeDefinedParameter> dynamicParameter in dynamicParameters)
                {
                    try
                    {
                        foreach (string key in templateParameterObject.Keys)
                        {
                            if (key.Equals(dynamicParameter.Key, StringComparison.InvariantCultureIgnoreCase))
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
                        throw new ArgumentException(string.Format(ProjectResources.FailureParsingTemplateParameterObject,
                                                                  dynamicParameter.Key,
                                                                  templateParameterObject[dynamicParameter.Key]));
                    }
                }
            }
        }

        private static Type GetParameterType(string resourceParameterType)
        {
            if(string.IsNullOrEmpty(resourceParameterType))
            {
                throw new ArgumentException(ProjectResources.GetParameterTypeError);
            }

            const string stringType = "string";
            const string intType = "int";
            const string boolType = "bool";
            const string secureStringType = "SecureString";
            const string objectType = "object";
            const string secureObjectType = "secureObject";
            const string arrayType = "array";
            Type typeObject = typeof(object);

            if (resourceParameterType.Equals(stringType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(string);
            }
            else if (resourceParameterType.Equals(intType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(int);
            }
            else if (resourceParameterType.Equals(secureStringType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(SecureString);
            }
            else if (resourceParameterType.Equals(boolType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(bool);
            }
            else if (resourceParameterType.Equals(objectType, StringComparison.OrdinalIgnoreCase)
                || resourceParameterType.Equals(secureObjectType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(Hashtable);
            }
            else if (resourceParameterType.Equals(arrayType, StringComparison.OrdinalIgnoreCase))
            {
                typeObject = typeof(object[]);
            }

            return typeObject;

        }

        internal static RuntimeDefinedParameter ConstructDynamicParameter(string[] staticParameters, KeyValuePair<string, TemplateFileParameterV1> parameter)
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

            if (!string.IsNullOrEmpty(parameter.Value.MinLength) &&
                !string.IsNullOrEmpty(parameter.Value.MaxLength))
            {
                runtimeParameter.Attributes.Add(new ValidateLengthAttribute(int.Parse(parameter.Value.MinLength), int.Parse(parameter.Value.MaxLength)));
            }

            return runtimeParameter;
        }
    }
}
