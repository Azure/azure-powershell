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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.Models
{
    /// <summary>
    /// Azure VM specific container class.
    /// </summary>
    public class AzureVmContainer : ContainerBase
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

        /// <summary>
        /// Constructor. Takes the service client object representing the container 
        /// and converts it in to the PS container model
        /// </summary>
        /// <param name="protectionContainer">Service client object representing the container</param>
        public AzureVmContainer(ProtectionContainerResource protectionContainer)
            : base(protectionContainer)
        {
            AzureIaaSVMProtectionContainer iaasVmProtectionContainer = (AzureIaaSVMProtectionContainer)protectionContainer.Properties;
            ResourceGroupName = IdUtils.GetResourceGroupName(protectionContainer.Id);
            FriendlyName = iaasVmProtectionContainer.FriendlyName;
            Status = EnumUtils.GetEnum<ContainerRegistrationStatus>(iaasVmProtectionContainer.RegistrationStatus);
        }
    }
}
