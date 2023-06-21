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
using System.Diagnostics;
using System.Security;
using Azure.Deployments.Core.Definitions;
using Azure.Deployments.Core.Definitions.Schema;
using Azure.Deployments.Core.Entities;
using Azure.Deployments.Templates.Engines;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public static RuntimeDefinedParameterDictionary GetTemplateParametersFromFile(object template, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = ParseTemplateAndExtractParameters(template.ToString(), templateParameterObject, templateParameterFilePath, staticParameters);

            return dynamicParameters;
        }

        public static RuntimeDefinedParameterDictionary GetTemplateParametersFromFile(Hashtable templateObject, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            string templateContent = null;
            if (templateObject != null)
            {
                templateContent = JsonConvert.SerializeObject(templateObject);
            }

            RuntimeDefinedParameterDictionary dynamicParameters = ParseTemplateAndExtractParameters(templateContent, templateParameterObject, templateParameterFilePath, staticParameters);

            return dynamicParameters;
        }

        public static Dictionary<string, DeploymentParameterDefinition> ParseTemplateParameterFileContents(string templateParameterFilePath)
        {
            Dictionary<string, DeploymentParameterDefinition> parameters = new Dictionary<string, DeploymentParameterDefinition>();

            if (!string.IsNullOrEmpty(templateParameterFilePath) && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                try
                {
                    // NOTE(jcotillo): We must use JsonExtensions to ensure the proper use of serialization settings.
                    // otherwise we could get invalid date time serializations.
                    parameters =
                        FileUtilities.DataStore.ReadFileAsStream(templateParameterFilePath)
                        .FromJson<Dictionary<string, DeploymentParameterDefinition>>();
                }
                catch (JsonSerializationException)
                {
                    var parametersv2 =
                        FileUtilities.DataStore.ReadFileAsStream(templateParameterFilePath)
                        .FromJson<DeploymentParametersDefinition>();
                    parameters = parametersv2.Parameters;
                }
            }

            return parameters;
        }

        public static Dictionary<string, DeploymentParameterDefinition> ParseTemplateParameterContent(string templateParameterContent)
        {
            Dictionary<string, DeploymentParameterDefinition> parameters = new Dictionary<string, DeploymentParameterDefinition>();

            if (!string.IsNullOrEmpty(templateParameterContent))
            {
                try
                {
                    parameters = JsonConvert.DeserializeObject<Dictionary<string, DeploymentParameterDefinition>>(templateParameterContent);
                }
                catch (JsonSerializationException)
                {
                    parameters = JsonConvert.DeserializeObject<DeploymentParametersDefinition>(templateParameterContent).Parameters;
                }
            }

            return parameters;
        }

        private static RuntimeDefinedParameterDictionary ParseTemplateAndExtractParameters(string templateContent, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();

            if (!string.IsNullOrEmpty(templateContent))
            {
                Template parsed = null;

                try
                {
                    parsed = TemplateEngine.ParseTemplate(templateContent);
                    if (parsed.Parameters == null)
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

                var validationContext = SchemaValidationContext.ForTemplate(parsed);
                foreach (var kvp in parsed.Parameters)
                {
                    var dynamicParameter = ConstructDynamicParameter(staticParameters, kvp, validationContext);
                    dynamicParameters.Add(dynamicParameter.Name, dynamicParameter);
                }
            }
            if (templateParameterObject != null)
            {
                UpdateParametersWithObject(staticParameters, dynamicParameters, templateParameterObject);
            }
            if (templateParameterFilePath != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = ParseTemplateParameterFileContents(templateParameterFilePath);
                UpdateParametersWithObject(staticParameters, dynamicParameters, new Hashtable(parametersFromFile));
            }
            if (templateParameterFilePath != null && Uri.IsWellFormedUriString(templateParameterFilePath, UriKind.Absolute))
            {
                var parametersFromUri = ParseTemplateParameterContent(GeneralUtilities.DownloadFile(templateParameterFilePath));
                UpdateParametersWithObject(staticParameters, dynamicParameters, new Hashtable(parametersFromUri));
            }
            return dynamicParameters;
        }

        private static void UpdateParametersWithObject(string[] staticParameters, RuntimeDefinedParameterDictionary dynamicParameters, Hashtable templateParameterObject)
        {
            const string duplicatedParameterSuffix = "FromTemplate";

            if (templateParameterObject != null)
            {
                foreach (string paramName in templateParameterObject.Keys)
                {
                    string dynamicParamName = staticParameters.Contains(paramName, StringComparer.OrdinalIgnoreCase)
                        ? paramName + duplicatedParameterSuffix
                        : paramName;

                    if (dynamicParameters.TryGetValue(dynamicParamName, out RuntimeDefinedParameter dynamicParameter))
                    {
                        dynamicParameter.Value = templateParameterObject[paramName] is DeploymentParameterDefinition deploymentParameterDefinition
                            ? deploymentParameterDefinition.Value.ToObject<object>()
                            : templateParameterObject[paramName];

                        dynamicParameter.IsSet = true;
                        ((ParameterAttribute)dynamicParameter.Attributes[0]).Mandatory = false;
                    }
                }
            }
        }

        private static Type GetParameterType(TemplateParameterType templateParameterType)
        {
            switch (templateParameterType)
            {
                case TemplateParameterType.String: return typeof(string);
                case TemplateParameterType.Int: return typeof(long);
                case TemplateParameterType.SecureString: return typeof(SecureString);
                case TemplateParameterType.Bool: return typeof(bool);
                case TemplateParameterType.Object:
                case TemplateParameterType.SecureObject: return typeof(Hashtable);
                case TemplateParameterType.Array: return typeof(object[]);
                default: return typeof(object);
            }
        }

        internal static RuntimeDefinedParameter ConstructDynamicParameter(string[] staticParameters, KeyValuePair<string, TemplateInputParameter> parameter, SchemaValidationContext schemaValidationContext)
        {
            const string duplicatedParameterSuffix = "FromTemplate";
            string name = parameter.Key;
            var withResolvedReferences = TemplateEngine.ResolveSchemaReferences(schemaValidationContext, parameter.Value);
            JToken defaultValue = parameter.Value.DefaultValue?.Value;

            RuntimeDefinedParameter runtimeParameter = new RuntimeDefinedParameter()
            {
                // For duplicated template parameter names, add a suffix FromTemplate to distinguish them from the cmdlet parameter.
                Name = staticParameters.Contains(name, StringComparer.OrdinalIgnoreCase) ? name + duplicatedParameterSuffix : name,
                ParameterType = GetParameterType(withResolvedReferences.Type.Value),
                Value = defaultValue
            };
            runtimeParameter.Attributes.Add(new ParameterAttribute()
            {
                Mandatory = defaultValue == null && withResolvedReferences.Nullable?.Value != true,
                ValueFromPipelineByPropertyName = true,
                // Rely on the HelpMessage property to detect the original name for the dynamic parameter.
                HelpMessage = name
            });

            if (withResolvedReferences.MinLength?.Value is long minLength &&
                minLength >= int.MinValue &&
                minLength <= int.MaxValue &&
                withResolvedReferences.MaxLength?.Value is long maxLength &&
                maxLength >= int.MinValue &&
                maxLength <= int.MaxValue)
            {
                runtimeParameter.Attributes.Add(new ValidateLengthAttribute((int) minLength, (int) maxLength));
            }

            return runtimeParameter;
        }
    }
}
