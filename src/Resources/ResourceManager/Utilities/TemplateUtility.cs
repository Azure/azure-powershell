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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using Microsoft.Azure.Management.Resources.Models;
using System.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Diagnostics;
using System.Security;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Newtonsoft.Json.Linq;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Management.Resources;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities
{
    public static class TemplateUtility
    {

        public static string ExtractTemplateContent(
            string templateFile,
            string templateUri,
            string templateSpecId,
            ITemplateSpecsClient templateSpecsClient,
            Hashtable templateObject
        )
        {
            string templateContent = null;
            if (templateObject != null)
            {
                templateContent = GetTemplateContentFromHashtable(templateObject);
            }
            else if (!string.IsNullOrEmpty(templateFile) || !string.IsNullOrEmpty(templateUri))
            {
                var file = !string.IsNullOrEmpty(templateFile) ? templateFile : templateUri;
                templateContent = GetTemplateContentFromFile(file);
            }
            else if (!string.IsNullOrEmpty(templateSpecId))
            {
                templateContent = GetTemplateContentFromTemplateSpec(templateSpecId, templateSpecsClient);
            }

            return templateContent;
        }

        public static Hashtable ExtractTemplateParameterContent(
            string templateParameterFile,
            string templateParameterUri
        )
        {
            Hashtable templateParameterContent = null;
            if (!string.IsNullOrEmpty(templateParameterFile) || !string.IsNullOrEmpty(templateParameterUri))
            {
                var file = !string.IsNullOrEmpty(templateParameterFile) ? templateParameterFile : templateParameterUri;
                templateParameterContent = GetTemplateParameterContentFromFile(file);
            }

            return templateParameterContent;
        }

        private static string GetTemplateContentFromFile(string templateFilePath)
        {
            string templateContent = null;
            if (templateFilePath != null)
            {
                if (Uri.IsWellFormedUriString(templateFilePath, UriKind.Absolute))
                {
                    templateContent = GeneralUtilities.DownloadFile(templateFilePath);
                    if (templateContent == null)
                    {
                        throw new PSArgumentException("Unable to download template file from provided uri.");
                    }
                }
                else if (FileUtilities.DataStore.FileExists(templateFilePath))
                {
                    templateContent = FileUtilities.DataStore.ReadFileAsText(templateFilePath);
                }
            }

            return templateContent;
        }

        private static string GetTemplateContentFromHashtable(Hashtable templateObject)
        {
            string templateContent = null;
            if (templateObject != null)
            {
                templateContent = JsonConvert.SerializeObject(templateObject);
            }
            
            return templateContent;
        }

        private static string GetTemplateContentFromTemplateSpec(string templateSpecId, ITemplateSpecsClient client)
        {
            ResourceIdentifier resourceIdentifier = new ResourceIdentifier(templateSpecId);
            if (!resourceIdentifier.ResourceType.Equals("Microsoft.Resources/templateSpecs/versions", StringComparison.OrdinalIgnoreCase))
            {
                throw new PSArgumentException("No version found in Resource ID");
            }

            if (!string.IsNullOrEmpty(resourceIdentifier.Subscription) &&
                client.SubscriptionId != resourceIdentifier.Subscription)
            {
                // The template spec is in a different subscription than our default
                // context. Force the client to use that subscription:
                client.SubscriptionId = resourceIdentifier.Subscription;
            }
            try
            {
                var templateSpecVersion = client.TemplateSpecVersions.Get(
                    ResourceIdUtility.GetResourceGroupName(templateSpecId),
                    ResourceIdUtility.GetResourceName(templateSpecId).Split('/')[0],
                    resourceIdentifier.ResourceName);

                if (!(templateSpecVersion.MainTemplate is JObject))
                {
                    throw new InvalidOperationException("Unexpected type."); // Sanity check
                }
                var templateObj = (JObject)templateSpecVersion.MainTemplate;
                
                return templateObj.ToString();
            }
            catch (TemplateSpecsErrorException e)
            {
                // If the templateSpec resourceID is pointing to a non existant resource
                if (!e.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    // Throw for any other error that is not due to a 404 for the template resource.
                    throw;
                }

                return null;
            }
        }

        private static Hashtable GetTemplateParameterContentFromFile(string templateParameterFilePath)
        {
            Hashtable templateParameterContent = null;

            if (templateParameterFilePath != null)
            {
                if (Uri.IsWellFormedUriString(templateParameterFilePath, UriKind.Absolute))
                {
                    var fileContent = GeneralUtilities.DownloadFile(templateParameterFilePath);
                    if (fileContent == null)
                    {
                        throw new PSArgumentException("Unable to download template parameter file from provided uri.");
                    }
                    templateParameterContent = new Hashtable(ParseTemplateParameterContent(fileContent));
                }
                else if (FileUtilities.DataStore.FileExists(templateParameterFilePath))
                {
                    templateParameterContent = new Hashtable(ParseTemplateParameterFileContents(templateParameterFilePath));
                }
            }

            return templateParameterContent;
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
                    parameters = templateParameterContent.FromJson<Dictionary<string, TemplateParameterFileParameter>>();
                }
                catch (JsonSerializationException)
                {
                    parameters = new Dictionary<string, TemplateParameterFileParameter>(
                        templateParameterContent.FromJson<TemplateParameterFile>().Parameters);
                }
            }

            return parameters;
        }

        public static RuntimeDefinedParameterDictionary GetDynamicParameters(string templateContent, Hashtable templateParameterObject, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();

            // If the template content is not null, parameters should be extracted into dynamic parameters:
            if (!string.IsNullOrEmpty(templateContent))
            {
                TemplateFile templateFile;
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
                SetDynamicParametersPassedInTemplateParameterObject(staticParameters, dynamicParameters, templateParameterObject);
            }

            return dynamicParameters;
        }

        /// <summary>
        /// Sets the dynamic parameters that are defined in the passed in template parameter object, so that the user is not prompted on execution for a value.
        /// </summary>
        private static void SetDynamicParametersPassedInTemplateParameterObject(string[] staticParameters, RuntimeDefinedParameterDictionary dynamicParameters, Hashtable templateParameterObject)
        {
            const string duplicatedParameterSuffix = "FromTemplate";

            if (templateParameterObject != null)
            {
                foreach (string paramName in templateParameterObject.Keys)
                {
                    // The template parameters that clash with static parameter names will receive a suffix on their respective dynamic parameter:
                    string dynamicParamName = staticParameters.Contains(paramName, StringComparer.OrdinalIgnoreCase)
                        ? paramName + duplicatedParameterSuffix
                        : paramName;

                    if (dynamicParameters.TryGetValue(dynamicParamName, out RuntimeDefinedParameter dynamicParameter))
                    {
                        // Param exists in the template parameter object, so set it not mandatory, so the user won't be prompted for it:
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
                
                var resolved = ResolveTypeFromPath(current.Ref, segments.Skip(2), definitions);
                // it's possible to override some of these properties: the highest-level non-null value wins
                resolved.Nullable = current.Nullable ?? resolved.Nullable;
                resolved.MinLength = current.MinLength ?? resolved.MinLength;
                resolved.MaxLength = current.MaxLength ?? resolved.MaxLength;
                resolved.AllowedValues = current.AllowedValues ?? resolved.AllowedValues;

                current = resolved;
            }

            return current;
        }

        internal static RuntimeDefinedParameter ConstructDynamicParameter(string[] staticParameters, KeyValuePair<string, TemplateFileParameter> parameterKvp, JObject definitions)
        {
            const string duplicatedParameterSuffix = "FromTemplate";
            var name = parameterKvp.Key;
            var paramDefinition = parameterKvp.Value;
            var paramType = ResolveParameterType(paramDefinition, definitions);
            var isRequired = paramDefinition.DefaultValue is null && paramType.Nullable != true;

            RuntimeDefinedParameter runtimeParameter = new RuntimeDefinedParameter()
            {
                // For duplicated template parameter names, add a suffix FromTemplate to distinguish them from the cmdlet parameter.
                Name = staticParameters.Contains(name, StringComparer.OrdinalIgnoreCase) ? name + duplicatedParameterSuffix : name,
                ParameterType = GetParameterType(paramType.Type),
                Value = paramDefinition.DefaultValue,
                // A dynamic parameter is not auto-set:
                IsSet = false
            };
            runtimeParameter.Attributes.Add(new ParameterAttribute()
            {
                Mandatory = isRequired,
                ValueFromPipelineByPropertyName = true,
                // Rely on the HelpMessage property to detect the original name for the dynamic parameter.
                HelpMessage = name
            });

            if (!string.IsNullOrEmpty(paramType.MinLength) &&
                !string.IsNullOrEmpty(paramType.MaxLength))
            {
                runtimeParameter.Attributes.Add(new ValidateLengthAttribute(int.Parse(paramType.MinLength), int.Parse(paramType.MaxLength)));
            }

            return runtimeParameter;
        }
    }
}
