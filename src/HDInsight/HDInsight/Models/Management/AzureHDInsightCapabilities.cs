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

using Microsoft.Azure.Management.HDInsight.Models;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Commands.HDInsight.Models.Management
{
    public class AzureHDInsightCapabilities
    {
        public AzureHDInsightCapabilities(CapabilitiesResult capabilitiesResult)
        {
            this.Versions = capabilitiesResult?.Versions?.ToDictionary(item => item.Key, item => new AzureHDInsightVersionsCapability(item.Value));

            this.Regions = capabilitiesResult?.Regions?.ToDictionary(item => item.Key, item => new AzureHDInsightRegionsCapability(item.Value));

            this.VmSizes = capabilitiesResult?.VmSizes?.ToDictionary(item => item.Key, item => new AzureHDInsightVmSizesCapability(item.Value));

            this.VmSizeFilters = capabilitiesResult?.VmSizeFilters?.Select(val => new AzureHDInsightVmSizeCompatibilityFilter(val)).ToList();

            this.Features = capabilitiesResult?.Features;

            this.Quota = new AzureHDInsightQuotaCapability(capabilitiesResult?.Quota);
        }

        /// <summary>
        /// The available cluster component versions.
        /// </summary>
        public IDictionary<string, AzureHDInsightVersionsCapability> Versions { get; set; }

        /// <summary>
        /// The available regions.
        /// </summary>
        public IDictionary<string, AzureHDInsightRegionsCapability> Regions { get; set; }

        /// <summary>
        /// The available vm sizes.
        /// </summary>
        public IDictionary<string, AzureHDInsightVmSizesCapability> VmSizes { get; set; }

        /// <summary>
        /// The vmsize filters.
        /// </summary>
        public IList<AzureHDInsightVmSizeCompatibilityFilter> VmSizeFilters { get; set; }

        /// <summary>
        /// The supported features.
        /// </summary>
        public IList<string> Features { get; set; }

        /// <summary>
        /// The quota capability.
        /// </summary>
        public AzureHDInsightQuotaCapability Quota { get; set; }
    }
}
