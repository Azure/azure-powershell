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

using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    /// <summary>
    /// Represents a Template Spec Version within a Template Spec.
    /// </summary>
    public class PSTemplateSpecVersion
    {
        /// <summary>
        /// Gets the Id of the version
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets or sets the name of the version. For example: 'v1'
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the version.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets tags assigned to the version.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the linked template artifacts within the template spec version
        /// </summary>
        public IList<PSTemplateSpecTemplateArtifact> LinkedTemplates { get; set; } = 
            new List<PSTemplateSpecTemplateArtifact>();

        /// <summary>
        /// Gets or sets the Azure Resource Manager template (JSON).
        /// </summary>
        public string MainTemplate { get; set; }

        /// <summary>
        /// Gets the date/time the template spec version was created (PUT to Azure).
        /// </summary>
        public DateTime? CreationTime { get; private set; }

        /// <summary>
        /// Gets the last date/time the template spec version was modified (PUT to Azure).
        /// </summary>
        public DateTime? LastModifiedTime { get; private set; }

        /// <summary>
        /// Gets or sets the UI Form definition (if any) for the template spec version
        /// </summary>
        public string UIFormDefinition { get; set; }

        /// <summary>
        /// Converts a template spec model from the Azure SDK to the powershell
        /// exposed template spec model.
        /// </summary>
        /// <param name="templateSpecVersion">The Azure SDK template spec model</param>
        /// <returns>The converted model or null if no model was specified</returns>
        internal static PSTemplateSpecVersion FromAzureSDKTemplateSpecVersion(
            TemplateSpecVersion templateSpecVersion)
        {
            if (templateSpecVersion == null)
            {
                return null;
            }

            var psTemplateSpecVersion = new PSTemplateSpecVersion
            {
                CreationTime = templateSpecVersion.SystemData.CreatedAt,
                Id = templateSpecVersion.Id,
                LastModifiedTime = templateSpecVersion.SystemData.LastModifiedAt,
                Name = templateSpecVersion.Name,
                Description = templateSpecVersion.Description,
                Tags = templateSpecVersion.Tags == null
                    ? new Dictionary<string, string>()
                    : new Dictionary<string, string>(templateSpecVersion.Tags),
                // Note: Cast is redundant, but present for clarity reasons:
                MainTemplate = ((JToken)templateSpecVersion.MainTemplate).ToString(),
                UIFormDefinition = ((JToken)templateSpecVersion.UiFormDefinition)?.ToString()
            };

            if (templateSpecVersion.LinkedTemplates?.Any() == true) {
                foreach (LinkedTemplateArtifact artifact in templateSpecVersion.LinkedTemplates)
                {
                    psTemplateSpecVersion.LinkedTemplates.Add(
                        PSTemplateSpecTemplateArtifact.FromAzureSDKTemplateSpecTemplateArtifact(artifact));
                }
            }

            return psTemplateSpecVersion;
        }
    }
}
