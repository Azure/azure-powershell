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
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Diagnostics;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Newtonsoft.Json.Linq;
using System.Threading;

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
            return ParseTemplateAndExtractParameters(template.ToString(), templateParameterObject, templateParameterFilePath, staticParameters);
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

        public static Dictionary<string, TemplateParameterFileParameter> ParseTemplateParameterFileContents(string templateParameterFilePath)
        {
            if (!string.IsNullOrEmpty(templateParameterFilePath) && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                return ParseTemplateParameterJson(FileUtilities.DataStore.ReadFileAsStream(templateParameterFilePath));
            }

            return new Dictionary<string, TemplateParameterFileParameter>();
        }

        public static Dictionary<string, TemplateParameterFileParameter> ParseTemplateParameterJson(Stream stream)
        {
            using (var streamReader = new StreamReader(stream))
            {
                return ParseTemplateParameterJson(streamReader);
            }
        }

        public static Dictionary<string, TemplateParameterFileParameter> ParseTemplateParameterJson(string json)
        {
            using (var reader = new StringReader(json))
            {
                return TemplateUtility.ParseTemplateParameterJson(reader);
            }
        }

        public static Dictionary<string, TemplateParameterFileParameter> ParseTemplateParameterJson(TextReader reader)
        {
            // Read once to avoid having to rewind the stream
            var parametersJson = reader.ReadToEnd();

            try
            {
                // NOTE(jcotillo): We must use JsonExtensions to ensure the proper use of serialization settings.
                // otherwise we could get invalid date time serializations.
                return parametersJson.FromJson<Dictionary<string, TemplateParameterFileParameter>>();
            }
            catch (JsonSerializationException)
            {
                var paramsFile = parametersJson.FromJson<TemplateParameterFile>();
                return new Dictionary<string, TemplateParameterFileParameter>(paramsFile.Parameters);
            }
        }

        public static Dictionary<string, TemplateParameterFileParameter> ParseTemplateParameterContent(string templateParameterContent)
        {
            var parameters = new Dictionary<string, TemplateParameterFileParameter>();

            if (!string.IsNullOrEmpty(templateParameterContent))
            {
                try
                {
                    parameters = JsonConvert.DeserializeObject<Dictionary<string, TemplateParameterFileParameter>>(templateParameterContent);
                }
                catch (JsonSerializationException)
                {
                    parameters = new Dictionary<string, TemplateParameterFileParameter>(
                        JsonConvert.DeserializeObject<TemplateParameterFile>(templateParameterContent).Parameters);
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
                    templateFile = templateContent.FromJson<TemplateFile>();
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

                foreach (var parameter in templateFile.Parameters)
                {
                    RuntimeDefinedParameter dynamicParameter = ConstructDynamicParameter(staticParameters, parameter, templateFile.Definitions);
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
                        dynamicParameter.Value = templateParameterObject[paramName] is TemplateParameterFileParameter TemplateFileParameter
                            ? TemplateFileParameter.Value
                            : templateParameterObject[paramName];

                        dynamicParameter.IsSet = true;
                        ((ParameterAttribute)dynamicParameter.Attributes[0]).Mandatory = false;
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

        private static string Rfc6901Decode(string encoded) => Uri.UnescapeDataString(encoded.Replace("~1", "/").Replace("~0", "~"));

        private static string[] GetJsonPointerSegments(string jsonPointer) => jsonPointer.Split('/').Select(Rfc6901Decode).ToArray();

        private static TemplateFileTypeDefinition ResolveTypeFromPath(string currentRef, IEnumerable<string> segments, JObject definitions)
        {
            JToken current = definitions;
            foreach (var segment in segments)
            {
                switch (current)
                {
                    case JObject currentObj when currentObj.ContainsKey(segment):
                        current = currentObj.GetProperty(segment);
                        break;
                    case JArray currentArray when int.TryParse(segment, out var index) && index >= 0 && index < currentArray.Count:
                        current = currentArray[index];
                        break;
                    default:
                        throw new InvalidOperationException($"Failed to resolve path {currentRef}.");
                }
            }

            if (!current.TryConvertTo<TemplateFileTypeDefinition>(out var definition))
            {
                throw new InvalidOperationException($"Failed to find valid definition at path {currentRef}.");
            }

            return definition;
        }

        private static TemplateFileTypeDefinition ResolveParameterType(TemplateFileParameter parameter, JObject definitions)
        {
            TemplateFileTypeDefinition current = parameter;
            var visited = new HashSet<string>();
            while (current.Ref != null)
            {
                if (visited.Contains(current.Ref))
                {
                    throw new InvalidOperationException($"Cycle detected with processing {current.Ref}.");
                }
                visited.Add(current.Ref);

                var segments = GetJsonPointerSegments(current.Ref);
                if (segments.Length < 2 || segments[0] != "#" || segments[1] != "definitions")
                {
                    throw new InvalidOperationException($"Invalid $ref {current.Ref}.");
                }
                
                current = ResolveTypeFromPath(current.Ref, segments.Skip(2), definitions);
            }

            return current;
        }

        internal static RuntimeDefinedParameter ConstructDynamicParameter(string[] staticParameters, KeyValuePair<string, TemplateFileParameter> parameterKvp, JObject definitions)
        {
            const string duplicatedParameterSuffix = "FromTemplate";
            var name = parameterKvp.Key;
            var parameter = ResolveParameterType(parameterKvp.Value, definitions);
            var defaultValue = parameterKvp.Value.DefaultValue;

            RuntimeDefinedParameter runtimeParameter = new RuntimeDefinedParameter()
            {
                // For duplicated template parameter names, add a suffix FromTemplate to distinguish them from the cmdlet parameter.
                Name = staticParameters.Contains(name, StringComparer.OrdinalIgnoreCase) ? name + duplicatedParameterSuffix : name,
                ParameterType = GetParameterType(parameter.Type),
                Value = defaultValue
            };
            runtimeParameter.Attributes.Add(new ParameterAttribute()
            {
                Mandatory = defaultValue == null ? true : false,
                ValueFromPipelineByPropertyName = true,
                // Rely on the HelpMessage property to detect the original name for the dynamic parameter.
                HelpMessage = name
            });

            if (!string.IsNullOrEmpty(parameter.MinLength) &&
                !string.IsNullOrEmpty(parameter.MaxLength))
            {
                runtimeParameter.Attributes.Add(new ValidateLengthAttribute(int.Parse(parameter.MinLength), int.Parse(parameter.MaxLength)));
            }

            return runtimeParameter;
        }
    }
}
