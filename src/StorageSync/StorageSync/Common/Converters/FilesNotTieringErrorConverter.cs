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
    /// Class CloudTieringCachePerformanceConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSFilesNotTieringError, StorageSyncModels.FilesNotTieringError}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSFilesNotTieringError, StorageSyncModels.FilesNotTieringError}" />
    public class FilesNotTieringErrorConverter : ConverterBase<PSFilesNotTieringError, StorageSyncModels.FilesNotTieringError>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointHealth.</returns>
        protected override StorageSyncModels.FilesNotTieringError Transform(PSFilesNotTieringError source)
        {
            // Cloud tiering status properties are readonly from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointHealth.</returns>
        protected override PSFilesNotTieringError Transform(StorageSyncModels.FilesNotTieringError source)
        {
            return new PSFilesNotTieringError()
            {
                FileCount = source.FileCount,
                ErrorCode = source.ErrorCode
            };
        }
    }
}
