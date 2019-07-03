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

using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class SyncGroupConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncGroup, Microsoft.Azure.Management.StorageSync.Models.SyncGroup}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncGroup, Microsoft.Azure.Management.StorageSync.Models.SyncGroup}" />
    public class SyncGroupConverter : ConverterBase<PSSyncGroup, StorageSyncModels.SyncGroup>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncGroupConverter" /> class.
        /// </summary>
        public SyncGroupConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SyncGroup.</returns>
        protected override StorageSyncModels.SyncGroup Transform(PSSyncGroup source) => new StorageSyncModels.SyncGroup(source.ResourceId, source.SyncGroupName, source.Type);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncGroup.</returns>
        protected override PSSyncGroup Transform(StorageSyncModels.SyncGroup source)
        {
            var resourceIdentifier = new ResourceIdentifier(source.Id);
            return new PSSyncGroup()
            {
                ResourceId = source.Id,
                SyncGroupName = source.Name,
                StorageSyncServiceName = resourceIdentifier.GetParentResourceName(StorageSyncConstants.StorageSyncServiceTypeName, 0),
                ResourceGroupName = resourceIdentifier.ResourceGroupName,
                Type = resourceIdentifier.ResourceType ?? StorageSyncConstants.SyncGroupType,
                UniqueId = source.UniqueId,
                SyncGroupStatus = source.SyncGroupStatus
            };
        }
    }
}