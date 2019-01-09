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

using Microsoft.Azure.Management.RecoveryServices.Backup.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    public class AzureContainer : ContainerBase
    {
        /// <summary>
        /// Resource Group where the Container is present
        /// </summary>
        public string ResourceGroupName { get; set; }
        /// <summary>
        /// Friendly name of the container
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Registration Status
        /// </summary>
        public ContainerRegistrationStatus Status { get; set; }

        public AzureContainer(ProtectionContainerResource protectionContainer)
           : base(protectionContainer)
        {
            ResourceGroupName = IdUtils.GetResourceGroupName(protectionContainer.Id);
            FriendlyName = protectionContainer.Properties.FriendlyName;
            Status = EnumUtils.GetEnum<ContainerRegistrationStatus>(protectionContainer.Properties.RegistrationStatus);
        }
    }
}
