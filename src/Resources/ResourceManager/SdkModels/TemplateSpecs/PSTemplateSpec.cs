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

using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Management.ResourceManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    /// <summary>
    /// Represents a Template Spec within Azure
    /// </summary>
    public class PSTemplateSpec
    {
        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the description of the template spec
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the optional display name for the template spec
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets the date/time the template spec was created (PUT to Azure).
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Gets the date/time the template spec was last modified (PUT to Azure).
        /// </summary>
        public DateTime? LastModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets tags assigned to the template spec.
        /// </summary>
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Represents the relevant versions in the template spec per the context of
        /// how the template spec was requested. If a single version was explicitly 
        /// requested this will contain one item, if this is a "detailed" view of a 
        /// template spec or an explicitly requested template spec it will contain all
        /// versions of the template spec. If this is a "listing view" of the template
        /// spec than Versions will be null.
        /// </summary>
        public PSTemplateSpecVersion[] Versions { get; set; }

        public PSTemplateSpec() { }

        internal PSTemplateSpec(TemplateSpec templateSpec, 
            TemplateSpecVersion[] versionModels = null)
        {
            this.Id = templateSpec.Id;
            this.Type = templateSpec.Type;
            this.Name = templateSpec.Name;
            this.Location = templateSpec.Location;
            this.CreationTime = templateSpec.SystemData.CreatedAt;
            this.LastModifiedTime = templateSpec.SystemData.LastModifiedAt;
            this.Description = templateSpec.Description;
            this.DisplayName = templateSpec.DisplayName;
            this.Tags = templateSpec.Tags == null
                ? new Dictionary<string, string>()
                : new Dictionary<string, string>(templateSpec.Tags);

            this.Versions = versionModels?
                .Select(v => PSTemplateSpecVersion.FromAzureSDKTemplateSpecVersion(v))
                .ToArray();
        }

        protected PSTemplateSpec(PSTemplateSpec toCopyFrom)
        {
            this.Id = toCopyFrom.Id;
            this.Type = toCopyFrom.Type;
            this.Name = toCopyFrom.Name;
            this.Location = toCopyFrom.Location;
            this.CreationTime = toCopyFrom.CreationTime;
            this.LastModifiedTime = toCopyFrom.LastModifiedTime;
            this.Description = toCopyFrom.Description;
            this.DisplayName = toCopyFrom.DisplayName;
            this.Versions = toCopyFrom.Versions?.ToArray(); // Shallow copy
            this.Tags = toCopyFrom.Tags == null 
                ? null
                : new Dictionary<string, string>(toCopyFrom.Tags);
        }

        internal static PSTemplateSpec FromAzureSDKTemplateSpec(TemplateSpec templateSpec)
        {
            return templateSpec != null 
                ? new PSTemplateSpec(templateSpec)
                : null;
        }

        public string ResourceGroupName => ResourceIdUtility.GetResourceGroupName(this.Id);

        public string SubscriptionId => ResourceIdUtility.GetSubscriptionId(this.Id);
    }

    /// <summary>
    /// Exclusively used for wrapping PSTempateSpecs for use with special formatting
    /// defined within our format.ps1xml file.
    /// </summary>
    public class PSTemplateSpecListItem : PSTemplateSpec
    {
        private PSTemplateSpecListItem(PSTemplateSpec templateSpec) 
            : base(templateSpec)
        {
        }

        public static PSTemplateSpecListItem FromTemplateSpec(
            PSTemplateSpec templateSpec)
        {
            if (templateSpec.GetType() != typeof(PSTemplateSpec))
            {
                throw new InvalidOperationException(
                    $"{nameof(PSTemplateSpecListItem)}s cannot be created from subclasses of {nameof(PSTemplateSpec)}"
                );
            }

            return new PSTemplateSpecListItem(templateSpec);
        }
    }
}
