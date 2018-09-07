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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ResourceManager.Models;

    public class PsResourceProviderAlias
    {
        /// <summary>
        /// Gets or sets the namespace of this resource type
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the resource type (name) of this resource type
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the collection of locations where this resource type
        /// can be created.
        /// </summary>
        public IList<string> Locations { get; set; }

        /// <summary>
        /// Gets or sets the aliases that are supported by this resource type.
        /// </summary>
        public IList<AliasType> Aliases { get; set; }

        /// <summary>Gets or sets the API version collection.</summary>
        public IList<string> ApiVersions { get; set; }
    }
}
