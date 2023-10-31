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
using System;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{

    /// <summary>
    /// Class SystemDataConvertor.
    /// Implements the <see cref="Converters.ConverterBase{PSSystemData, SystemData}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSSystemData, SystemData}" />
    public class SystemDataConverter : ConverterBase<PSSystemData, StorageSyncModels.SystemData>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SystemData.</returns>
        protected override StorageSyncModels.SystemData Transform(PSSystemData source)
        {
            // Sync activity properties are read-only from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSystemData.</returns>
        protected override PSSystemData Transform(StorageSyncModels.SystemData source)
        {
            return new PSSystemData()
            {
                CreatedAt = source.CreatedAt,
                CreatedBy = source.CreatedBy,
                CreatedByType = source.CreatedByType,
                LastModifiedAt = source.LastModifiedAt,
                LastModifiedBy = source.LastModifiedBy,
                LastModifiedByType = source.LastModifiedByType
            };
        }
    }
}