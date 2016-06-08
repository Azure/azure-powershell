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
        /// Retrieves Virtual Machine group.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <returns>Virtual Machine group list response</returns>
        public VirtualMachineGroupListResponse GetAzureSiteRecoveryVirtualMachineGroup(
            string protectionContainerId)
        {
            return this.GetSiteRecoveryClient().VmGroup.List(protectionContainerId, this.GetRequestHeaders());
        }

        /// <summary>
        /// Retrieves Virtual Machine group.
        /// </summary>
        /// <param name="protectionContainerId">Protection Container ID</param>
        /// <param name="virtualMachineGroupId">Virtual Machine group ID</param>
        /// <returns>Virtual Machine group response</returns>
        public VirtualMachineGroupResponse GetAzureSiteRecoveryVirtualMachineGroup(
            string protectionContainerId,
            string virtualMachineGroupId)
        {
            return this.GetSiteRecoveryClient().VmGroup.Get(protectionContainerId, virtualMachineGroupId, this.GetRequestHeaders());
        }
    }
}