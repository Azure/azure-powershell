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
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncProgressStatus, Microsoft.Azure.Management.StorageSync.Models.SyncProgressStatus}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{Microsoft.Azure.Commands.StorageSync.Models.PSSyncProgressStatus, Microsoft.Azure.Management.StorageSync.Models.SyncProgressStatus}" />
    public class SyncProgressStatusConvertor : ConverterBase<PSSyncProgressStatus, StorageSyncModels.SyncProgressStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.SyncProgressStatus.</returns>
        protected override StorageSyncModels.SyncProgressStatus Transform(PSSyncProgressStatus source) => new StorageSyncModels.SyncProgressStatus(
            source.ProgressTimestamp, source.SyncDirection, source.PerItemErrorCount, source.AppliedItemCount, source.TotalItemCount, source.AppliedBytes,source.TotalBytes);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSSyncProgressStatus.</returns>
        protected override PSSyncProgressStatus Transform(StorageSyncModels.SyncProgressStatus source)
        {
            return new PSSyncProgressStatus()
            {
                AppliedBytes = source.AppliedBytes,
                AppliedItemCount=source.AppliedItemCount,
                PerItemErrorCount=source.PerItemErrorCount,
                ProgressTimestamp = source.ProgressTimestamp,
                SyncDirection = source.SyncDirection,
                TotalBytes = source.TotalBytes,
                TotalItemCount=source.TotalItemCount
            };
        }
    }
}
