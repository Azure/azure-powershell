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

using Microsoft.Azure.Commands.StorageSync.Common.Extensions;
using Microsoft.Azure.Commands.StorageSync.Models;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class ServerEndpointProvisioningStatusConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSServerEndpointProvisioningStatus, ServerEndpointProvisioningStatus}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSServerEndpointProvisioningStatus, ServerEndpointProvisioningStatus}" />
    public class ServerEndpointProvisioningStatusConverter : ConverterBase<PSServerEndpointProvisioningStatus, StorageSyncModels.ServerEndpointProvisioningStatus>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEndpointProvisioningStatusConverter" /> class.
        /// </summary>
        public ServerEndpointProvisioningStatusConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointProvisioningStatus.</returns>
        protected override StorageSyncModels.ServerEndpointProvisioningStatus Transform(PSServerEndpointProvisioningStatus source)
        {
            // Server Endpoint Provisioning Status properties are read only.
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>PSServerEndpointProvisioningStatus.</returns>
        protected override PSServerEndpointProvisioningStatus Transform(StorageSyncModels.ServerEndpointProvisioningStatus source)
        {
            IList<PSServerEndpointProvisioningStepStatus> serverEndpointProvisioningStepStatuses = null;

            if (source.ProvisioningStepStatuses != null)
            {
                serverEndpointProvisioningStepStatuses = source.ProvisioningStepStatuses.Select(stepStatus => stepStatus != null ? new ServerEndpointProvisioningStepStatusConverter().Convert(stepStatus) : null).ToList();
            }

            return new PSServerEndpointProvisioningStatus()
            {
                ProvisioningStatus = source.ProvisioningStatus,
                ProvisioningType = source.ProvisioningType,
                ProvisioningStepStatuses = serverEndpointProvisioningStepStatuses
            };
        }
    }
}