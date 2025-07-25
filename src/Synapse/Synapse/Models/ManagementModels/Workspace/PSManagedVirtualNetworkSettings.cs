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

using Microsoft.Azure.Management.Synapse.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    /// <summary>
    /// Managed Virtual Network Settings
    /// </summary>
    public class PSManagedVirtualNetworkSettings
    {
        public PSManagedVirtualNetworkSettings(ManagedVirtualNetworkSettings settings)
        {
            this.PreventDataExfiltration = settings?.PreventDataExfiltration;
            this.LinkedAccessCheckOnTargetResource = settings?.LinkedAccessCheckOnTargetResource;
            this.AllowedAadTenantIdsForLinking = settings?.AllowedAadTenantIdsForLinking;
        }

        /// <summary>
        /// Gets or sets prevent Data Exfiltration
        /// </summary>
        public bool? PreventDataExfiltration { get; set; }

        /// <summary>
        /// Gets or sets linked Access Check On Target Resource
        /// </summary>
        public bool? LinkedAccessCheckOnTargetResource { get; set; }

        /// <summary>
        /// Gets or sets allowed Aad Tenant Ids For Linking
        /// </summary>
        public IList<string> AllowedAadTenantIdsForLinking { get; set; }

        public ManagedVirtualNetworkSettings ToSdkObject()
        {
            return new ManagedVirtualNetworkSettings
            {
                PreventDataExfiltration = this.PreventDataExfiltration,
                AllowedAadTenantIdsForLinking = this.AllowedAadTenantIdsForLinking,
                LinkedAccessCheckOnTargetResource = this.LinkedAccessCheckOnTargetResource
            };
        }
    }
}
