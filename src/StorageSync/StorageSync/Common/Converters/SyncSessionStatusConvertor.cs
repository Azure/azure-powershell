﻿// ----------------------------------------------------------------------------------
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
    /// Class ServerEndpointSyncSessionStatusConvertor.
    /// Implements the <see cref="Converters.ConverterBase{PSServerEndpointSyncSessionStatus, StorageSyncModels.ServerEndpointSyncSessionStatus}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSServerEndpointSyncSessionStatus, StorageSyncModels.ServerEndpointSyncSessionStatus}" />
    public class ServerEndpointSyncSessionStatusConvertor : ConverterBase<PSServerEndpointSyncSessionStatus, StorageSyncModels.ServerEndpointSyncSessionStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointSyncSessionStatus.</returns>
        protected override StorageSyncModels.ServerEndpointSyncSessionStatus Transform(PSServerEndpointSyncSessionStatus source) => new StorageSyncModels.ServerEndpointSyncSessionStatus(
            source.LastSyncResult, source.LastSyncTimestamp, source.LastSyncSuccessTimestamp, source.LastSyncPerItemErrorCount);

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointSyncSessionStatus.</returns>
        protected override PSServerEndpointSyncSessionStatus Transform(StorageSyncModels.ServerEndpointSyncSessionStatus source)
        {
            return new PSServerEndpointSyncSessionStatus()
            {
                LastSyncResult = source.LastSyncResult,
                LastSyncTimestamp = source.LastSyncTimestamp,
                LastSyncSuccessTimestamp = source.LastSyncSuccessTimestamp,
                LastSyncPerItemErrorCount = source.LastSyncPerItemErrorCount
            };
        }
    }

}