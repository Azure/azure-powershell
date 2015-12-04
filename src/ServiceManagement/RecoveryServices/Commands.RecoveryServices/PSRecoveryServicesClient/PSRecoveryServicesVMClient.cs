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

using System;
using Microsoft.WindowsAzure.Management.SiteRecovery;
using Microsoft.WindowsAzure.Management.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices
{
    /// <summary>
    /// Recovery services convenience client.
    /// </summary>
    public partial class PSRecoveryServicesClient
    {
        /// <summary>
        /// Gets Azure Site Recovery Virtual Machines.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <returns>Virtual Machine list response</returns>
        public VirtualMachineListResponse GetAzureSiteRecoveryVirtualMachine(
            string protectionContainerId)
        {
            return this.GetSiteRecoveryClient().Vm.List(protectionContainerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Gets Azure Site Recovery Virtual Machine.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="virtualMachineId">Virtual Machine ID</param>
        /// <returns>Virtual Machine response</returns>
        public VirtualMachineResponse GetAzureSiteRecoveryVirtualMachine(
            string protectionContainerId,
            string virtualMachineId)
        {
            return this.GetSiteRecoveryClient().Vm.Get(protectionContainerId, virtualMachineId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Updates Virtual Machine properties.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="virtualMachineId">Virtual Machine ID</param>
        /// <param name="updateVmPropertiesInput">Update VM properties input</param>
        /// <returns>Job response</returns>
        public JobResponse UpdateVmProperties(
            string protectionContainerId,
            string virtualMachineId,
            UpdateVmPropertiesInput updateVmPropertiesInput)
        {
            return this.GetSiteRecoveryClient().Vm.UpdateVmProperties(
                protectionContainerId,
                virtualMachineId,
                updateVmPropertiesInput,
                this.GetRequestHeaders());
        }
    }
}