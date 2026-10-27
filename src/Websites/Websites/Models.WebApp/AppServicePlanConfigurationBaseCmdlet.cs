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

using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.WebApps
{
    public abstract class AppServicePlanConfigurationBaseCmdlet : AppServicePlanBaseCmdlet
    {
        [Parameter(HelpMessage = "Enable or disable the system-assigned managed identity on the App Service plan.")]
        public bool AssignIdentity { get; set; }

        [Parameter(HelpMessage = "Resource IDs of the user-assigned managed identities to associate with the plan. Replaces the existing list; pass an empty array to remove all user-assigned identities.")]
        [AllowEmptyCollection]
        [ValidateNotNull]
        public string[] UserAssignedIdentityId { get; set; }

        [Parameter(HelpMessage = "The default identity for plan integrations. Use '[system]' for the system-assigned identity, a user-assigned identity resource ID, or an empty string to clear the default.")]
        [AllowEmptyString]
        [ValidateNotNull]
        public string DefaultIdentity { get; set; }

        [Parameter(HelpMessage = "Enable or disable Remote Desktop Protocol (RDP) access to the Managed Instance plan.")]
        public bool RdpEnabled { get; set; }

        [Parameter(HelpMessage = "Resource ID of the subnet for plan-level virtual network integration. Pass an empty string to disconnect the plan.")]
        [AllowEmptyString]
        [ValidateNotNull]
        public string VirtualNetworkSubnetId { get; set; }

        [Parameter(HelpMessage = "Installation scripts for the Managed Instance plan. Replaces the existing collection; pass an empty array to remove all scripts.")]
        [AllowEmptyCollection]
        [ValidateNotNull]
        public InstallScript[] InstallScript { get; set; }

        [Parameter(HelpMessage = "Storage mounts for the Managed Instance plan. Replaces the existing collection; pass an empty array to remove all mounts.")]
        [AllowEmptyCollection]
        [ValidateNotNull]
        public StorageMount[] StorageMount { get; set; }

        [Parameter(HelpMessage = "Registry adapters for the Managed Instance plan. Replaces the existing collection; pass an empty array to remove all adapters.")]
        [AllowEmptyCollection]
        [ValidateNotNull]
        public RegistryAdapter[] RegistryAdapter { get; set; }

        protected void ApplyManagedInstanceConfiguration(AppServicePlan plan)
        {
            var parameters = MyInvocation.BoundParameters;
            if (parameters.ContainsKey(nameof(AssignIdentity)) || parameters.ContainsKey(nameof(UserAssignedIdentityId)))
            {
                bool systemAssigned = parameters.ContainsKey(nameof(AssignIdentity))
                    ? AssignIdentity
                    : plan.Identity?.Type == ManagedServiceIdentityType.SystemAssigned ||
                      plan.Identity?.Type == ManagedServiceIdentityType.SystemAssignedUserAssigned;
                var identities = new Dictionary<string, UserAssignedIdentity>(StringComparer.OrdinalIgnoreCase);
                IEnumerable<string> identityIds = parameters.ContainsKey(nameof(UserAssignedIdentityId))
                    ? UserAssignedIdentityId
                    : plan.Identity?.UserAssignedIdentities?.Keys;
                if (identityIds != null)
                {
                    foreach (string identityId in identityIds)
                    {
                        if (string.IsNullOrWhiteSpace(identityId))
                        {
                            throw new ArgumentException("User-assigned identity resource IDs cannot be empty.", nameof(UserAssignedIdentityId));
                        }

                        identities[identityId] = new UserAssignedIdentity();
                    }
                }

                var identityType = systemAssigned
                    ? identities.Count > 0 ? ManagedServiceIdentityType.SystemAssignedUserAssigned : ManagedServiceIdentityType.SystemAssigned
                    : identities.Count > 0 ? ManagedServiceIdentityType.UserAssigned : ManagedServiceIdentityType.None;
                plan.Identity = new ManagedServiceIdentity(identityType, userAssignedIdentities: identities.Count > 0 ? identities : null);
            }

            if (parameters.ContainsKey(nameof(DefaultIdentity)))
            {
                plan.PlanDefaultIdentity = string.IsNullOrEmpty(DefaultIdentity)
                    ? new DefaultIdentity(ManagedServiceIdentityType.None)
                    : string.Equals(DefaultIdentity, "[system]", StringComparison.OrdinalIgnoreCase)
                        ? new DefaultIdentity(ManagedServiceIdentityType.SystemAssigned)
                        : new DefaultIdentity(ManagedServiceIdentityType.UserAssigned, DefaultIdentity);
            }

            if (parameters.ContainsKey(nameof(RdpEnabled)))
            {
                plan.RdpEnabled = RdpEnabled;
            }

            if (parameters.ContainsKey(nameof(VirtualNetworkSubnetId)))
            {
                plan.Network = plan.Network ?? new ServerFarmNetworkSettings();
                plan.Network.VirtualNetworkSubnetId = VirtualNetworkSubnetId;
            }

            if (parameters.ContainsKey(nameof(InstallScript)))
            {
                plan.InstallScripts = InstallScript;
            }

            if (parameters.ContainsKey(nameof(StorageMount)))
            {
                plan.StorageMounts = StorageMount;
            }

            if (parameters.ContainsKey(nameof(RegistryAdapter)))
            {
                plan.RegistryAdapters = RegistryAdapter;
            }
        }
    }
}
