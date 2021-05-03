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

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    using Microsoft.Azure.Commands.StorageSync.Models;
    using System;
    using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

    /// <summary>
    /// Class BackgroundDataDownloadActivityConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSBackgroundDataDownloadActivity, StorageSyncModels.ServerEndpointBackgroundDataDownloadActivity}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSBackgroundDataDownloadActivity, StorageSyncModels.ServerEndpointBackgroundDataDownloadActivity}" />
    public class BackgroundDataDownloadActivityConverter : ConverterBase<PSBackgroundDataDownloadActivity, StorageSyncModels.ServerEndpointBackgroundDataDownloadActivity>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointBackgroundDataDownloadActivity.</returns>
        protected override StorageSyncModels.ServerEndpointBackgroundDataDownloadActivity Transform(PSBackgroundDataDownloadActivity source)
        {
            // Background data download properties are read-only from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSBackgroundDataDownloadActivity.</returns>
        protected override PSBackgroundDataDownloadActivity Transform(StorageSyncModels.ServerEndpointBackgroundDataDownloadActivity source)
        {
            return new PSBackgroundDataDownloadActivity()
            {
                Timestamp = source.Timestamp,
                StartedTimestamp = source.StartedTimestamp,
                DownloadedBytes = source.DownloadedBytes,
                PercentProgress = source.PercentProgress
            };
        }
    }
}
