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

namespace Microsoft.Azure.Commands.PolicyInsights.Models
{
    /// <summary>
    /// Policy metadata record
    /// </summary>
    public class PSPolicyMetadata
    {
        /// <summary>
        /// Gets the policy metadata identifier.
        /// </summary>
        public string MetadataId { get; private set; }

        /// <summary>
        /// Gets the category of the policy metadata.
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// Gets the title of the policy metadata.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the owner of the policy metadata.
        /// </summary>
        public string Owner { get; private set; }

        /// <summary>
        /// Gets url for getting additional content about the resource
        /// metadata.
        /// </summary>
        public string AdditionalContentUrl { get; private set; }

        /// <summary>
        /// Gets additional metadata.
        /// </summary>
        public object Metadata { get; private set; }

        /// <summary>
        /// Gets the description of the policy metadata.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the requirements of the policy metadata.
        /// </summary>
        public string Requirements { get; private set; }

        /// <summary>
        /// Gets the ID of the policy metadata.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the type of the policy metadata.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the name of the policy metadata.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPolicyMetadata" /> class.
        /// </summary>
        /// <param name="policyMetadata">policy metadata</param>
        public PSPolicyMetadata(Management.PolicyInsights.Models.PolicyMetadata policyMetadata)
        {
            MetadataId = policyMetadata.MetadataId;
            Category = policyMetadata.Category;
            Title = policyMetadata.Title;
            Owner = policyMetadata.Owner;
            AdditionalContentUrl = policyMetadata.AdditionalContentUrl;
            Metadata = policyMetadata.Metadata;
            Description = policyMetadata.Description;
            Requirements = policyMetadata.Requirements;
            Id = policyMetadata.Id;
            Type = policyMetadata.Type;
            Name = policyMetadata.Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSPolicyMetadata" /> class.
        /// </summary>
        /// <param name="policyMetadata">slim policy metadata</param>
        public PSPolicyMetadata(Management.PolicyInsights.Models.SlimPolicyMetadata policyMetadata)
        {
            MetadataId = policyMetadata.MetadataId;
            Category = policyMetadata.Category;
            Title = policyMetadata.Title;
            Owner = policyMetadata.Owner;
            AdditionalContentUrl = policyMetadata.AdditionalContentUrl;
            Metadata = policyMetadata.Metadata;
            Description = null;
            Requirements = null;
            Id = policyMetadata.Id;
            Type = policyMetadata.Type;
            Name = policyMetadata.Name;
        }
    }
}
