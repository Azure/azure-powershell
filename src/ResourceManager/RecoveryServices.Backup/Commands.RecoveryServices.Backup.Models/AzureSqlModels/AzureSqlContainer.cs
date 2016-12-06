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

using ServiceClientModel = Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure Sql specific container class.
    /// </summary>
    public class AzureSqlContainer : ContainerBase
    {
        /// <summary>
        /// Registration Status
        /// </summary>
        public ContainerRegistrationStatus Status { get; set; }

        // <summary>
        /// Constructor. Takes the service client object representing the container 
        /// and converts it in to the PS container model
        /// </summary>
        /// <param name="protectionContainer">Service client object representing the container</param>
        public AzureSqlContainer(
            ServiceClientModel.ProtectionContainerResource protectionContainer)
            : base(protectionContainer)
        {
            ServiceClientModel.AzureSqlContainer sqlProtectionContainer =
                (ServiceClientModel.AzureSqlContainer)protectionContainer.Properties;
            Status = EnumUtils.GetEnum<ContainerRegistrationStatus>(
                sqlProtectionContainer.RegistrationStatus);
        }
    }
}
