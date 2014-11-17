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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.Azure.Gallery;
using Microsoft.Azure.Gallery.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Common.OData;
using Newtonsoft.Json;
using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public class GalleryTemplatesClient
    {
        public IGalleryClient GalleryClient { get; set; }

        public GalleryTemplatesClient(AzureContext context)
            : this(AzureSession.ClientFactory.CreateClient<GalleryClient>(context, AzureEnvironment.Endpoint.Gallery))
        {

        }

        public GalleryTemplatesClient(IGalleryClient galleryClient)
        {
            GalleryClient = galleryClient;
        }

        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public GalleryTemplatesClient()
        {

        }

        /// <summary>
        /// Gets the uri of the specified template name.
        /// </summary>
        /// <param name="templateIdentity">The fully qualified template name</param>
        /// <returns>The template uri</returns>
        public virtual string GetGalleryTemplateFile(string templateIdentity)
        {
            try
            {
                DefinitionTemplates definitionTemplates = GalleryClient.Items.Get(templateIdentity).Item.DefinitionTemplates;
                return definitionTemplates.DeploymentTemplateFileUrls[definitionTemplates.DefaultDeploymentTemplateId];
            }
            catch (CloudException)
            {
                throw new ArgumentException(string.Format(ProjectResources.InvalidTemplateIdentity, templateIdentity));
            }
        }

        /// <summary>
        /// Filters gallery templates based on the passed options.
        /// </summary>
        /// <param name="options">The filter options</param>
        /// <returns>The filtered list</returns>
        public virtual List<PSGalleryItem> FilterGalleryTemplates(FilterGalleryTemplatesOptions options)
        {
            List<string> filterStrings = new List<string>();
            ItemListParameters parameters = null;
            List<GalleryItem> result = new List<GalleryItem>();

            if (!string.IsNullOrEmpty(options.Identity))
            {
                result.Add(GalleryClient.Items.Get(options.Identity).Item);
            }
            else
            {
                result.AddRange(QueryGalleryTemplates(options, filterStrings, parameters));
            }

            if (!options.AllVersions && result.Count > 1)
            {
                if (!string.IsNullOrEmpty(options.Publisher) && string.IsNullOrEmpty(options.ApplicationName) && string.IsNullOrEmpty(options.Identity))
                {
                    // we return a list of the most recent templates, for each name.
                    List<GalleryItem> latest = new List<GalleryItem>();
                    IEnumerable<string> distinctNames = result.Select(g => g.Name).Distinct();
                    foreach (var name in distinctNames)
                    {
                        List<GalleryItem> galleryItems = result.Where(x => x.Name.Equals(name)).ToList();
                        GalleryItem recentTemplate = this.MostRecentTemplate(galleryItems);
                        if (recentTemplate != null)
                        {
                            latest.Add(recentTemplate);
                        }
                    }

                    return latest.Select(i => i.ToPSGalleryItem()).ToList();
                }

                // Take only the most recent version
                GalleryItem mostRecentTemplate = MostRecentTemplate(result);
                if (mostRecentTemplate != null)
                {
                    return new List<PSGalleryItem>() { mostRecentTemplate.ToPSGalleryItem() };
                }
            }

            return result.Select(i => i.ToPSGalleryItem()).ToList();
        }

        private GalleryItem MostRecentTemplate(List<GalleryItem> galleryItems)
        {
            if (galleryItems == null || galleryItems.Count == 0)
            {
                return null;
            }

            if (galleryItems.Count == 1)
            {
                return galleryItems[0];
            }

            GalleryItem mostRecent = galleryItems[0];
            foreach (var galleryItem in galleryItems)
            {
                // if CompareTo is greater then the present galleryItem is a higher version
                string galleryItemVersion = galleryItem.Version == null ? "0.0.0.0" : galleryItem.Version.Replace("-preview", string.Empty);
                string mostRecentVersion = mostRecent.Version == null ? "0.0.0.0" : mostRecent.Version.Replace("-preview", string.Empty);
                galleryItemVersion = galleryItemVersion.Replace("-placeholder", string.Empty);
                mostRecentVersion = mostRecentVersion.Replace("-placeholder", string.Empty);
                if ((new Version(galleryItemVersion)).CompareTo(new Version(mostRecentVersion)) > 0)
                {
                    mostRecent = galleryItem;
                }
            }

            return mostRecent;
        }

        /// <summary>
        /// Downloads a gallery template file into specific directory.
        /// </summary>
        /// <param name="identity">The gallery template file identity</param>
        /// <param name="outputPath">The file output path</param>
        /// <param name="overwrite">Overrides existing file</param>
        /// <param name="confirmAction">The confirmation action</param>
        /// <returns>The file path</returns>
        public virtual string DownloadGalleryTemplateFile(string identity, string outputPath, bool overwrite, Action<bool, string, string, string, Action> confirmAction)
        {
            string fileUri = GetGalleryTemplateFile(identity);
            StringBuilder finalOutputPath = new StringBuilder();
            string contents = GeneralUtilities.DownloadFile(fileUri);

            if (!FileUtilities.IsValidDirectoryPath(outputPath))
            {
                // Try create the directory if it does not exist.
                FileUtilities.DataStore.CreateDirectory(Path.GetDirectoryName(outputPath));
            }

            if (FileUtilities.IsValidDirectoryPath(outputPath))
            {
                finalOutputPath.Append(Path.Combine(outputPath, identity + ".json"));
            }
            else
            {
                finalOutputPath.Append(outputPath);
                if (!outputPath.EndsWith(".json"))
                {
                    finalOutputPath.Append(".json");
                }
            }

            Action saveFile = () => FileUtilities.DataStore.WriteFile(finalOutputPath.ToString(), contents);

            if (FileUtilities.DataStore.FileExists(finalOutputPath.ToString()) && confirmAction != null)
            {
                confirmAction(
                    overwrite,
                    string.Format(ProjectResources.FileAlreadyExists, finalOutputPath.ToString()),
                    ProjectResources.OverrdingFile,
                    finalOutputPath.ToString(),
                    saveFile);
            }
            else
            {
                saveFile();
            }

            return finalOutputPath.ToString();
        }

        /// <summary>
        /// Gets the parameters for a given gallery template.
        /// </summary>
        /// <param name="templateIdentity">The gallery template name</param>
        /// <param name="templateParameterObject">Existing template parameter object</param>
        /// <param name="templateParameterFilePath">Path to the template parameter file if present</param>
        /// <param name="staticParameters">The existing PowerShell cmdlet parameters</param>
        /// <returns>The template parameters</returns>
        public virtual RuntimeDefinedParameterDictionary GetTemplateParametersFromGallery(string templateIdentity, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();
            string templateContent = null;

            templateContent = GeneralUtilities.DownloadFile(GetGalleryTemplateFile(templateIdentity));

            dynamicParameters = ParseTemplateAndExtractParameters(templateContent, templateParameterObject, templateParameterFilePath, staticParameters);
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
        public virtual RuntimeDefinedParameterDictionary GetTemplateParametersFromFile(string templateFilePath, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();
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

            dynamicParameters = ParseTemplateAndExtractParameters(templateContent, templateParameterObject, templateParameterFilePath, staticParameters);

            return dynamicParameters;
        }

        public Dictionary<string, TemplateFileParameterV1> ParseTemplateParameterFileContents(string templateParameterFilePath)
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

        private RuntimeDefinedParameterDictionary ParseTemplateAndExtractParameters(string templateContent, Hashtable templateParameterObject, string templateParameterFilePath, string[] staticParameters)
        {
            RuntimeDefinedParameterDictionary dynamicParameters = new RuntimeDefinedParameterDictionary();

            if (!string.IsNullOrEmpty(templateContent))
            {
                TemplateFile templateFile = null;

                try
                {
                    templateFile = JsonConvert.DeserializeObject<TemplateFile>(templateContent);
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
            if (templateParameterFilePath != null && FileUtilities.DataStore.FileExists(templateParameterFilePath))
            {
                var parametersFromFile = ParseTemplateParameterFileContents(templateParameterFilePath);
                UpdateParametersWithObject(dynamicParameters, new Hashtable(parametersFromFile));
            }
            return dynamicParameters;
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

        private Type GetParameterType(string resourceParameterType)
        {
            Debug.Assert(!string.IsNullOrEmpty(resourceParameterType));
            const string stringType = "string";
            const string intType = "int";
            const string boolType = "bool";
            const string secureStringType = "SecureString";
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

            return typeObject;
        }

        internal RuntimeDefinedParameter ConstructDynamicParameter(string[] staticParameters, KeyValuePair<string, TemplateFileParameterV1> parameter)
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

        private List<GalleryItem> QueryGalleryTemplates(FilterGalleryTemplatesOptions options, List<string> filterStrings, ItemListParameters parameters)
        {
            if (!string.IsNullOrEmpty(options.Publisher))
            {
                filterStrings.Add(FilterString.Generate<ItemListFilter>(f => f.Publisher == options.Publisher));
            }

            if (!string.IsNullOrEmpty(options.Category))
            {
                filterStrings.Add(FilterString.Generate<ItemListFilter>(f => f.CategoryIds.Contains(options.Category)));
            }

            if (filterStrings.Count > 0)
            {
                parameters = new ItemListParameters() { Filter = string.Join(" and ", filterStrings) };
            }

            List<GalleryItem> galleryItems = GalleryClient.Items.List(parameters).Items.ToList();
            if (!string.IsNullOrEmpty(options.ApplicationName))
            {
                List<GalleryItem> result = new List<GalleryItem>();
                string wildcardApplicationName = Regex.Escape(options.ApplicationName).Replace(@"\*", ".*").Replace(@"\?", ".");
                Regex regex = new Regex(wildcardApplicationName, RegexOptions.IgnoreCase);
                foreach (var galleryItem in galleryItems)
                {
                    if (regex.IsMatch(galleryItem.Name))
                    {
                        result.Add(galleryItem);
                    }
                }

                return result;
            }

            return galleryItems;
        }
    }
}