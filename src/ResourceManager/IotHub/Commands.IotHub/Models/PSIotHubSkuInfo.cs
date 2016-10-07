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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using Newtonsoft.Json;

    public class PSIotHubSkuInfo
    {
        /// <summary>
        /// The name of the Sku. Possible values include: 'F1', 'S1', 'S2',
        /// 'S3'
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public PSIotHubSku Name { get; set; }

        /// <summary>
        /// The tier. Possible values include: 'Free', 'Standard'
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public PSIotHubSkuTier Tier
        {
            get
            {
                switch (Name)
                {
                    case PSIotHubSku.F1:
                        return PSIotHubSkuTier.Free;
                    case PSIotHubSku.S1:
                    case PSIotHubSku.S2:
                    case PSIotHubSku.S3:
                        return PSIotHubSkuTier.Standard;
                    default:
                        return PSIotHubSkuTier.Free;
                }
            }
        }

        /// <summary>
        /// The number of units being provisioned. Range of values [For F1:
        /// 1-1, S1: 1-200, S2: 1-200, S3: 1-10]. To go above this range,
        /// call support.
        /// </summary>
        [JsonProperty(PropertyName = "capacity")]
        public long? Capacity { get; set; }
    }
}
