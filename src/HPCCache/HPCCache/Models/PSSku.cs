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
namespace Microsoft.Azure.Commands.HPCCache
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// PSSKU.
    /// </summary>
    public class PSSku
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSSku"/> class.
        /// PS Sku.
        /// </summary>
        /// <param name="sku"> sku.</param>
        public PSSku(ResourceSku sku)
        {
            if (sku != null)
            {
                this.Name = sku.Name;
                this.Locations = sku.Locations;
                this.ResourceType = sku.ResourceType;
                this.Restrictions = sku.Restrictions;
                this.Capabilities = sku.Capabilities;
            }
        }

        /// <summary>
        /// Gets or sets get or sets value.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets get or sets Location.
        /// </summary>
        public IList<string> Locations { get; set; }

        /// <summary>
        /// Gets or sets get or sets ResourceType.
        /// </summary>
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets get or sets Restrictions.
        /// </summary>
        public IList<Management.StorageCache.Models.Restriction> Restrictions { get; set; }

        /// <summary>
        /// Gets or sets get or sets Capabilities.
        /// </summary>
        public IList<ResourceSkuCapabilities> Capabilities { get; set; }
    }
}