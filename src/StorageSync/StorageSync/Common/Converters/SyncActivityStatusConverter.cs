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
    /// Class SyncProgressStatusConvertor.
    /// Implements the <see cref="Converters.ConverterBase{PSSyncActivityStatus, StorageSyncModels.SyncProgressStatus}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSSyncActivityStatus, StorageSyncModels.SyncProgressStatus}" />
    public class SyncActivityStatusConverter : ConverterBase<PSSyncActivityStatus, StorageSyncModels.SyncActivityStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SyncProgressStatus.</returns>
        protected override StorageSyncModels.SyncActivityStatus Transform(PSSyncActivityStatus source) => new StorageSyncModels.SyncActivityStatus(
            source.Timestamp,
            source.PerItemErrorCount,
            source.AppliedItemCount,
            source.TotalItemCount,
            source.AppliedBytes,source.TotalBytes);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncProgressStatus.</returns>
        protected override PSSyncActivityStatus Transform(StorageSyncModels.SyncActivityStatus source)
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
