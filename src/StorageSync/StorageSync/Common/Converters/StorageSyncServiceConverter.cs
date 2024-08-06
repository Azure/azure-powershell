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
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Profiles.Storage.Version2019_06_01.Models;
using Microsoft.Azure.Management.StorageSync.Models;
using System.Collections.Generic;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{

    /// <summary>
    /// Class StorageSyncServiceConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSStorageSyncService, StorageSyncService}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSStorageSyncService, StorageSyncService}" />
    public class StorageSyncServiceConverter : ConverterBase<PSStorageSyncService, StorageSyncModels.StorageSyncService>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageSyncServiceConverter" /> class.
        /// </summary>
        public StorageSyncServiceConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.StorageSyncService.</returns>
        protected override StorageSyncModels.StorageSyncService Transform(PSStorageSyncService source) => new StorageSyncModels.StorageSyncService(
            source.Location,
            source.ResourceId,
            source.StorageSyncServiceName,
            StorageSyncConstants.StorageSyncServiceType,
            new SystemDataConverter().Convert(source.SystemData),
            source.Tags,
            source.Identity,
            source.IncomingTrafficPolicy);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSStorageSyncService.</returns>
        protected override PSStorageSyncService Transform(StorageSyncModels.StorageSyncService source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);

            var psPrivateEndpointConnections = new List<PSPrivateEndpointConnection>();
            // Convert individual PrivateEndpointConnection objects
            if (source.PrivateEndpointConnections != null)
            {
                foreach(StorageSyncModels.PrivateEndpointConnection privateEndpointConnection in source.PrivateEndpointConnections)
                {
                    psPrivateEndpointConnections.Add(new PrivateEndpointConnectionConverter().Convert(privateEndpointConnection));
                }
            }

            return new PSStorageSyncService()
            {
                ResourceId = source.Id,
                StorageSyncServiceName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Location = source.Location,
                IncomingTrafficPolicy = source.IncomingTrafficPolicy,
                Tags = source.Tags,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.StorageSyncServiceType,
                PrivateEndpointConnections = psPrivateEndpointConnections.Count > 0 ? psPrivateEndpointConnections : null,
                SystemData = new SystemDataConverter().Convert(source.SystemData),
                UseIdentity = source.UseIdentity,
                Identity = source.Identity
            };
        }
    }
}