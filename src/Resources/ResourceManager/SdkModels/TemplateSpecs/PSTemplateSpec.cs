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

        public PSTemplateSpec() { }

        internal PSTemplateSpec(TemplateSpec templateSpec)
        {
            this.Id = templateSpec.Id;
            this.Type = templateSpec.Type;
            this.Name = templateSpec.Name;
            this.Location = templateSpec.Location;
            this.CreationTime = templateSpec.SystemData.CreatedAt;
            this.LastModifiedTime = templateSpec.SystemData.LastModifiedAt;
            this.Description = templateSpec.Description;
            this.DisplayName = templateSpec.DisplayName;
            this.Tags = templateSpec.Tags;
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
    /// Represents a Template Spec and a single version
    /// </summary>
    public class PSTemplateSpecSingleVersion : PSTemplateSpec
    {
        public PSTemplateSpecVersion Version { get; set; }

        internal PSTemplateSpecSingleVersion(TemplateSpec templateSpecModel, 
            TemplateSpecVersion versionModel) : base(templateSpecModel)
        {
            // TODO: Validate version belongs to templateSpecModel
            this.Version = PSTemplateSpecVersion.FromAzureSDKTemplateSpecVersion(versionModel);
        }
    }

    /// <summary>
    /// Represents a Template Spec and all of its versions
    /// </summary>
    public class PSTemplateSpecMultiVersion : PSTemplateSpec
    {
        public PSTemplateSpecVersion[] Versions { get; set; }

        internal PSTemplateSpecMultiVersion(TemplateSpec templateSpecModel,
            TemplateSpecVersion[] versionModels) : base(templateSpecModel)
        {
            if (versionModels == null)
            {
                this.Versions = new PSTemplateSpecVersion[0];
                return;
            }

            // TODO: Validate version belongs to templateSpecModel
            this.Versions = versionModels
                .Select(v=>PSTemplateSpecVersion.FromAzureSDKTemplateSpecVersion(v))
                .ToArray();
        }
    }
}
