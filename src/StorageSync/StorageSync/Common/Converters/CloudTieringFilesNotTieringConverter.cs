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
    using System.Collections.Generic;
    using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

    /// <summary>
    /// Class CloudTieringFilesNotTieringConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSCloudTieringFilesNotTiering, StorageSyncModels.CloudTieringFilesNotTiering}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSCloudTieringFilesNotTiering, StorageSyncModels.CloudTieringFilesNotTiering}" />
    public class CloudTieringFilesNotTieringConverter : ConverterBase<PSCloudTieringFilesNotTiering, StorageSyncModels.CloudTieringFilesNotTiering>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.CloudTieringFilesNotTiering.</returns>
        protected override StorageSyncModels.CloudTieringFilesNotTiering Transform(PSCloudTieringFilesNotTiering source)
        {
            // Cloud tiering status properties are readonly from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSCloudTieringFilesNotTiering.</returns>
        protected override PSCloudTieringFilesNotTiering Transform(StorageSyncModels.CloudTieringFilesNotTiering source)
        {
            var errors = new List<PSFilesNotTieringError>();

            if (source.Errors != null)
            {
                foreach (var error in source.Errors)
                {
                    if (error != null)
                    {
                        errors.Add(new FilesNotTieringErrorConverter().Convert(error));
                    }
                }
            }

            return new PSCloudTieringFilesNotTiering()
            {
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                TotalFileCount = source.TotalFileCount,
                Errors = errors
            };
        }
    }
}
