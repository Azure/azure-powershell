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
    /// Class SyncActivityStatusConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSSyncActivityStatus, StorageSyncModels.SyncProgressStatus}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSSyncActivityStatus, StorageSyncModels.SyncProgressStatus}" />
    public class SyncActivityStatusConverter : ConverterBase<PSSyncActivityStatus, StorageSyncModels.ServerEndpointSyncActivityStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointSyncActivityStatus.</returns>
        protected override StorageSyncModels.ServerEndpointSyncActivityStatus Transform(PSSyncActivityStatus source)
        {
            // Sync activity properties are read-only from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncActivityStatus.</returns>
        protected override PSSyncActivityStatus Transform(StorageSyncModels.ServerEndpointSyncActivityStatus source)
        {
            return new PSSyncActivityStatus()
            {
                Timestamp = source.Timestamp,
                AppliedBytes = source.AppliedBytes,
                AppliedItemCount=source.AppliedItemCount,
                PerItemErrorCount=source.PerItemErrorCount,
                TotalBytes = source.TotalBytes,
                TotalItemCount=source.TotalItemCount
            };
        }
    }
}
