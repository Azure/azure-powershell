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
    /// Class PrivateEndpointConnectionsConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSPrivateEndpointConnection, PrivateEndpointConnection}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSPrivateEndpointConnection, PrivateEndpointConnection}" />
    public class PrivateEndpointConnectionConverter : ConverterBase<PSPrivateEndpointConnection, StorageSyncModels.PrivateEndpointConnection>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateEndpointConnectionConverter" /> class.
        /// </summary>
        public PrivateEndpointConnectionConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.PrivateEndpointConnection.</returns>
        protected override StorageSyncModels.PrivateEndpointConnection Transform(PSPrivateEndpointConnection source) => new StorageSyncModels.PrivateEndpointConnection(
            source.ResourceId,
            source.PrivateEndpointConnectionName,
            source.Type,
            new SystemDataConverter().Convert(source.SystemData),
            new PrivateEndpointConverter().Convert(source.PrivateEndpoint), 
            source.GroupIds,
            new PrivateLinkServiceConnectionStateConverter().Convert(source.PrivateLinkServiceConnectionState),
            source.ProvisioningState);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSPrivateEndpointConnection.</returns>
        protected override PSPrivateEndpointConnection Transform(StorageSyncModels.PrivateEndpointConnection source)
        {
            return new PSPrivateEndpointConnection()
            {
                ResourceId = source.Id,
                PrivateEndpointConnectionName = source.Name,
                PrivateEndpoint = new PrivateEndpointConverter().Convert(source.PrivateEndpoint),
                PrivateLinkServiceConnectionState = new PrivateLinkServiceConnectionStateConverter().Convert(source.PrivateLinkServiceConnectionState),
                ProvisioningState = source.ProvisioningState,
                Type = source.Type,
                SystemData = new SystemDataConverter().Convert(source.SystemData),
                GroupIds = source.GroupIds
            };
        }
    }
}