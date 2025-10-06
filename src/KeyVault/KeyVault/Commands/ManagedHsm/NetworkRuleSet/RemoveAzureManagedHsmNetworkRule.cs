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
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.KeyVault.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

namespace Microsoft.Azure.Commands.KeyVault.Commands.ManagedHsm.NetworkRuleSet
{
    /// <summary>
    /// Remove specified network rules (IP ranges and/or virtual network resource IDs) from a Managed HSM.
    /// Mirrors Remove-AzKeyVaultNetworkRule for Managed HSM resources.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsmNetworkRule", SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSManagedHsm))]
    public class RemoveAzureManagedHsmNetworkRule : ManagedHsmNetworkRuleSetBase
    {
        private const string ByNameParameterSet = "ByName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByNameParameterSet, HelpMessage = "Name of the managed HSM.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", nameof(ResourceGroupName))]
        [Alias("HsmName")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, Position = 1, ParameterSetName = ByNameParameterSet, HelpMessage = "Resource group name.")]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByInputObjectParameterSet, ValueFromPipeline = true, HelpMessage = "Managed HSM object.")]
        public PSManagedHsm InputObject { get; set; }

        [Parameter(Mandatory = true, Position = 0, ParameterSetName = ByResourceIdParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "Managed HSM resource Id.")]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ResourceId != null)
            {
                var id = new ResourceIdentifier(ResourceId);
                Name = id.ResourceName;
                ResourceGroupName = id.ResourceGroupName;
            }

            if (ShouldProcess(Name, Properties.Resources.RemoveNetworkRule))
            {
                bool ipSpecified = IsIpAddressRangeSpecified;
                bool vnetSpecified = IsVirtualNetworkResourceIdSpecified;
                if (!ipSpecified && !vnetSpecified)
                {
                    throw new ArgumentException("At least one of IpAddressRange or VirtualNetworkResourceId must be specified.");
                }

                ValidateArrayInputs();
                var existing = GetCurrentManagedHsm(Name, ResourceGroupName);
                var current = existing.OriginalManagedHsm.Properties.NetworkAcls;

                var currentIp = current?.IPRules != null ? new List<string>(current.IPRules.Select(r => r.Value)) : new List<string>();
                var currentVnet = current?.VirtualNetworkRules != null ? new List<string>(current.VirtualNetworkRules.Select(r => r.Id)) : new List<string>();

                if (ipSpecified && IpAddressRange != null)
                {
                    foreach (var ip in IpAddressRange)
                    {
                        currentIp.RemoveAll(x => string.Equals(x, ip, StringComparison.OrdinalIgnoreCase));
                    }
                }
                if (vnetSpecified && VirtualNetworkResourceId != null)
                {
                    foreach (var idStr in VirtualNetworkResourceId)
                    {
                        currentVnet.RemoveAll(x => string.Equals(x, idStr, StringComparison.OrdinalIgnoreCase));
                    }
                }

                var updated = new PSManagedHsmNetworkRuleSet(
                    current?.DefaultAction != null && Enum.TryParse(current.DefaultAction, true, out PSManagedHsmNetworkRuleDefaultActionEnum da) ? da : PSManagedHsmNetworkRuleDefaultActionEnum.Allow,
                    current?.Bypass != null && Enum.TryParse(current.Bypass, true, out PSManagedHsmNetworkRuleBypassEnum bp) ? bp : PSManagedHsmNetworkRuleBypassEnum.AzureServices,
                    currentIp,
                    currentVnet);

                var result = UpdateCurrentManagedHsm(existing, updated);
                if (PassThru.IsPresent)
                {
                    WriteObject(result);
                }
            }
        }
    }
}
