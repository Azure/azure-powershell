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

using Microsoft.Azure.Management.NetApp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSRegionInfo
    {
        /// <summary>
        /// Gets or sets storage to Network Proximity
        /// </summary>
        /// <remarks>
        /// Provides storage to network proximity information in the region.
        /// Possible values include: 'Default', 'T1', 'T2', 'AcrossT2',
        /// 'T1AndT2', 'T1AndAcrossT2', 'T2AndAcrossT2', 'T1AndT2AndAcrossT2'
        /// </remarks>        
        public string StorageToNetworkProximity { get; set; }

        /// <summary>
        /// Gets or sets logical availability zone mappings.
        /// </summary>
        /// <remarks>
        /// Provides logical availability zone mappings for the subscription
        /// for a region.
        /// </remarks>        
        public IList<RegionInfoAvailabilityZoneMappingsItem> AvailabilityZoneMappings { get; set; }
    }
}
