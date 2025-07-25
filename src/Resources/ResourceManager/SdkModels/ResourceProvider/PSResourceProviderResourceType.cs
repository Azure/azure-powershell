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

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels
{
    using System;
    using System.Collections;
    using System.Linq;

    public class PSResourceProviderResourceType
    {
        /// <summary>
        /// Gets or sets the name of the resource type.
        /// </summary>
        public string ResourceTypeName { get; set; }

        /// <summary>
        /// Gets or sets the locations this resource is available in.
        /// </summary>
        public string[] Locations { get; set; }

        /// <summary>
        /// Gets or sets the api versions that this resource is supported in.
        /// </summary>
        public string[] ApiVersions { get; set; }

        /// <summary>
        /// Gets or sets the zone mappings that this resource supports.
        /// </summary>
        public Hashtable ZoneMappings { get; set; }

        /// <summary>
        /// Gets or sets the default api version for this resource.
        /// </summary>
        public string DefaultApiVersion { get; set; }
    }
}
