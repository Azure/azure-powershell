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

using Microsoft.Azure.Commands.StorageSync.Models;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class PrivateEndpointConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSPrivateEndpoint, PrivateEndpoint}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSPrivateEndpoint, PrivateEndpoint}" />
    public class PrivateEndpointConverter : ConverterBase<PSPrivateEndpoint, StorageSyncModels.PrivateEndpoint>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateEndpointConverter" /> class.
        /// </summary>
        public PrivateEndpointConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.PrivateEndpoint.</returns>
        protected override StorageSyncModels.PrivateEndpoint Transform(PSPrivateEndpoint source) => new StorageSyncModels.PrivateEndpoint(source.ResourceId);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSPrivateEndpoint.</returns>
        protected override PSPrivateEndpoint Transform(StorageSyncModels.PrivateEndpoint source)
        {
            return new PSPrivateEndpoint()
            {
                ResourceId = source.Id
            };
        }
    }
}
