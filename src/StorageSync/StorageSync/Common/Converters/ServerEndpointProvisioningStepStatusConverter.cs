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
using StorageSyncModels = Microsoft.Azure.Management.StorageSync.Models;

namespace Microsoft.Azure.Commands.StorageSync.Common.Converters
{
    /// <summary>
    /// Class ServerEndpointProvisioningStepStatusConverter.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSServerEndpointProvisioningStepStatus, ServerEndpointProvisioningStepStatus}" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Common.Converters.ConverterBase{PSServerEndpointProvisioningStepStatus, ServerEndpointProvisioningStepStatus}" />
    public class ServerEndpointProvisioningStepStatusConverter : ConverterBase<PSServerEndpointProvisioningStepStatus, StorageSyncModels.ServerEndpointProvisioningStepStatus>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerEndpointProvisioningStepStatusConverter" /> class.
        /// </summary>
        public ServerEndpointProvisioningStepStatusConverter()
        {
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>StorageSyncModels.ServerEndpointProvisioningStepStatus.</returns>
        protected override StorageSyncModels.ServerEndpointProvisioningStepStatus Transform(PSServerEndpointProvisioningStepStatus source)
        {
            // Server Endpoint Provisioning Step Status properties are read only.
            throw new NotSupportedException();
        }

        /// <summary>
        /// Transforms the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>ServerEndpointProvisioningStepStatus.</returns>
        protected override PSServerEndpointProvisioningStepStatus Transform(StorageSyncModels.ServerEndpointProvisioningStepStatus source)
        {
            return new PSServerEndpointProvisioningStepStatus()
            {
                Name = source.Name,
                Status = source.Status,
                StartTime = source.StartTime,
                MinutesLeft = source.MinutesLeft,
                ProgressPercentage = source.ProgressPercentage,
                EndTime = source.EndTime,
                ErrorCode = source.ErrorCode,
                AdditionalInformation = source.AdditionalInformation
            };
        }
    }
}