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
    public class PSIotHubSkuInfo
    {
        public PSIotHubSku Name { get; set; }

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

        public long Capacity { get; set; }
    }
}
