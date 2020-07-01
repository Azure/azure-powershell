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
    using Microsoft.Azure.Management.StorageCache.Models;

    /// <summary>
    /// PSUsageModels wrapper.
    /// </summary>
    public class PSHpcCacheUsageModels
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PSHpcCacheUsageModels"/> class.
        /// PSHpcCacheUsageModels.
        /// </summary>
        /// <param name="usagemodel"> usagemodel.</param>
        public PSHpcCacheUsageModels(UsageModel usagemodel)
        {
            if (usagemodel != null)
            {
                this.Name = usagemodel.ModelName;
                this.TargetType = usagemodel.TargetType;
                this.Display = usagemodel.Display.Description;
            }
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets TargetType.
        /// </summary>
        public string TargetType { get; set; }

        /// <summary>
        /// Gets or sets Display.
        /// </summary>
        public string Display { get; set; }
    }
}