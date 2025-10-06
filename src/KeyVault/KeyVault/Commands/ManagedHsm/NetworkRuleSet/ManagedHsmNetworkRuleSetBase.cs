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
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Commands.ManagedHsm.NetworkRuleSet
{
    /// <summary>
    /// Base class for Managed HSM network rule set cmdlets.
    /// Mirrors <see cref="Microsoft.Azure.Commands.KeyVault.KeyVaultNetworkRuleSetBase"/> but targets Managed HSMs.
    /// </summary>
    public abstract class ManagedHsmNetworkRuleSetBase : KeyVaultManagementCmdletBase
    {
        #region Parameters
        [Parameter(Mandatory = false, HelpMessage = "Specifies allowed network IP address range of network rule.")]
        public string[] IpAddressRange { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Specifies allowed virtual network resource identifier of network rule.")]
        public string[] VirtualNetworkResourceId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "This Cmdlet does not return an object by default. If this switch is specified, it returns the updated managed HSM object.")]
        public SwitchParameter PassThru { get; set; }
        #endregion

        protected bool IsIpAddressRangeSpecified => MyInvocation.BoundParameters.ContainsKey(nameof(IpAddressRange));
        protected bool IsVirtualNetworkResourceIdSpecified => MyInvocation.BoundParameters.ContainsKey(nameof(VirtualNetworkResourceId));

        protected void ValidateArrayInputs()
        {
            if (IpAddressRange != null && IpAddressRange.Length > 0 && IpAddressRange.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("The array of IpAddressRange input cannot contain null or empty strings");
            }
            if (VirtualNetworkResourceId != null && VirtualNetworkResourceId.Length > 0 && VirtualNetworkResourceId.Any(string.IsNullOrWhiteSpace))
            {
                throw new ArgumentException("The array of VirtualNetworkResourceId input cannot contain null or empty strings");
            }
        }

        protected PSManagedHsm GetCurrentManagedHsm(string name, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                resourceGroupName = GetResourceGroupName(name, isHsm: true);
            }

            var hsm = KeyVaultManagementClient.GetManagedHsm(name, resourceGroupName);
            if (hsm == null)
            {
                throw new ArgumentException(string.Format(Properties.Resources.HsmNotFound, name, resourceGroupName));
            }
            return hsm;
        }

        /// <summary>
        /// Translate PS rule set into underlying <see cref="MhsmNetworkRuleSet"/> and perform update via management client.
        /// </summary>
        protected PSManagedHsm UpdateCurrentManagedHsm(PSManagedHsm existingHsm, PSManagedHsmNetworkRuleSet updatedRuleSet)
        {
            if (existingHsm?.OriginalManagedHsm?.Properties == null)
            {
                throw new ArgumentException("Managed HSM properties cannot be null");
            }

            var properties = existingHsm.OriginalManagedHsm.Properties;
            var serviceRuleSet = new MhsmNetworkRuleSet();
            if (updatedRuleSet != null)
            {
                serviceRuleSet.DefaultAction = updatedRuleSet.DefaultAction.ToString();
                serviceRuleSet.Bypass = updatedRuleSet.Bypass.ToString();
                if (updatedRuleSet.IpAddressRanges != null)
                {
                    serviceRuleSet.IPRules = updatedRuleSet.IpAddressRanges
                        .Select(v => new MhsmipRule { Value = v })
                        .ToList();
                }
                if (updatedRuleSet.VirtualNetworkResourceIds != null)
                {
                    serviceRuleSet.VirtualNetworkRules = updatedRuleSet.VirtualNetworkResourceIds
                        .Select(id => new MhsmVirtualNetworkRule { Id = id })
                        .ToList();
                }
                // Enforce DefaultAction Deny when any rules present (service requires this under enabled public access; conservative always safe)
                if ((serviceRuleSet.IPRules != null && serviceRuleSet.IPRules.Count > 0) || (serviceRuleSet.VirtualNetworkRules != null && serviceRuleSet.VirtualNetworkRules.Count > 0))
                {
                    if (string.Equals(serviceRuleSet.DefaultAction, "Allow", StringComparison.OrdinalIgnoreCase))
                    {
                        serviceRuleSet.DefaultAction = "Deny";
                    }
                }
            }

            properties.NetworkAcls = serviceRuleSet;

            // Prepare minimal update parameters (only fields the Update API inspects + tags)
            var updateParameters = new VaultCreationOrUpdateParameters
            {
                EnablePurgeProtection = existingHsm.EnablePurgeProtection,
                PublicNetworkAccess = existingHsm.PublicNetworkAccess,
                Tags = existingHsm.Tags
            };

            return KeyVaultManagementClient.UpdateManagedHsm(existingHsm, updateParameters, GraphClient);
        }
    }
}
