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
<<<<<<< HEAD
=======
using Microsoft.Azure.Management.StorageSync.Models;
using System.Collections.Generic;
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{

    /// <summary>
    /// Class StorageSyncServiceConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSStorageSyncService, Microsoft.Azure.Management.StorageSync.Models.StorageSyncService}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSStorageSyncService, Microsoft.Azure.Management.StorageSync.Models.StorageSyncService}" />
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
<<<<<<< HEAD
        protected override StorageSyncModels.StorageSyncService Transform(PSStorageSyncService source) => new StorageSyncModels.StorageSyncService(source.Location, source.ResourceId, source.StorageSyncServiceName, StorageSyncConstants.StorageSyncServiceType, source.Tags);
=======
        protected override StorageSyncModels.StorageSyncService Transform(PSStorageSyncService source) => new StorageSyncModels.StorageSyncService(
            source.Location,
            source.ResourceId,
            source.StorageSyncServiceName,
            StorageSyncConstants.StorageSyncServiceType,
            source.Tags,
            source.IncomingTrafficPolicy);
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSStorageSyncService.</returns>
        protected override PSStorageSyncService Transform(StorageSyncModels.StorageSyncService source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
<<<<<<< HEAD
=======

            var psPrivateEndpointConnections = new List<PSPrivateEndpointConnection>();
            // Convert individual PrivateEndpointConnection objects
            if (source.PrivateEndpointConnections != null)
            {
                foreach(PrivateEndpointConnection privateEndpointConnection in source.PrivateEndpointConnections)
                {
                    psPrivateEndpointConnections.Add(new PrivateEndpointConnectionConverter().Convert(privateEndpointConnection));
                }
            }

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            return new PSStorageSyncService()
            {
                ResourceId = source.Id,
                StorageSyncServiceName = source.Name,
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Location = source.Location,
<<<<<<< HEAD
                Tags = source.Tags,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.StorageSyncServiceType
=======
                IncomingTrafficPolicy = source.IncomingTrafficPolicy,
                Tags = source.Tags,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.StorageSyncServiceType,
                PrivateEndpointConnections = psPrivateEndpointConnections.Count > 0 ? psPrivateEndpointConnections : null
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
            };
        }
    }
}