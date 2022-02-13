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
    /// Class PrivateLinkServiceConnectionStateConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSPrivateLinkServiceConnectionState, Microsoft.Azure.Management.StorageSync.Models.PrivateLinkServiceConnectionState}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSPrivateLinkServiceConnectionState, Microsoft.Azure.Management.StorageSync.Models.PrivateLinkServiceConnectionState}" />
    public class PrivateLinkServiceConnectionStateConverter : ConverterBase<PSPrivateLinkServiceConnectionState, StorageSyncModels.PrivateLinkServiceConnectionState>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateLinkServiceConnectionStateConverter" /> class.
        /// </summary>
        public PrivateLinkServiceConnectionStateConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.PrivateLinkServiceConnectionState.</returns>
        protected override StorageSyncModels.PrivateLinkServiceConnectionState Transform(PSPrivateLinkServiceConnectionState source) => new StorageSyncModels.PrivateLinkServiceConnectionState(
            source.Status,
            source.Description,
            source.ActionsRequired);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSPrivateLinkServiceConnectionState.</returns>
        protected override PSPrivateLinkServiceConnectionState Transform(StorageSyncModels.PrivateLinkServiceConnectionState source)
        {
            return new PSPrivateLinkServiceConnectionState()
            {
                Status = source.Status,
                Description = source.Description,
                ActionsRequired = source.ActionsRequired,
            };
        }
    }
}
