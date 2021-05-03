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
    /// Class ServerEndpointRecallStatusConverter.
    /// Implements the <see cref="Converters.ConverterBase{PSServerEndpointRecallStatus, StorageSyncModels.ServerEndpointRecallStatus}" />
    /// </summary>
    /// <seealso cref="Converters.ConverterBase{PSServerEndpointRecallStatus, StorageSyncModels.ServerEndpointRecallStatus}" />
    public class ServerEndpointRecallStatusConverter : ConverterBase<PSServerEndpointRecallStatus, StorageSyncModels.ServerEndpointRecallStatus>
    {
        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointRecallStatus.</returns>
        protected override StorageSyncModels.ServerEndpointRecallStatus Transform(PSServerEndpointRecallStatus source)
        {
            // Recall status properties are readonly from the RP
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointRecallStatus.</returns>
        protected override PSServerEndpointRecallStatus Transform(StorageSyncModels.ServerEndpointRecallStatus source)
        {
            var recallErrors = new List<PSServerEndpointRecallError>();

            if (source.RecallErrors != null)
            {
                foreach (var error in source.RecallErrors)
                {
                    if (error != null)
                    {
                        recallErrors.Add(new ServerEndpointRecallErrorConverter().Convert(error));
                    }
                }
            }

            return new PSServerEndpointRecallStatus()
            {
                LastUpdatedTimestamp = source.LastUpdatedTimestamp,
                TotalRecallErrorsCount = source.TotalRecallErrorsCount,
                RecallErrors = recallErrors
            };
        }
    }
}
