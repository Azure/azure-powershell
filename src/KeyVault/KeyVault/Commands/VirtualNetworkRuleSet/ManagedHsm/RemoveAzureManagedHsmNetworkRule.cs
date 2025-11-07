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
    /// Remove network rule(s) from a Managed HSM.
    /// Structured to mirror Remove-AzKeyVaultNetworkRule for consistency.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "KeyVaultManagedHsmNetworkRule", SupportsShouldProcess = true, DefaultParameterSetName = ByNameParameterSet)]
    [OutputType(typeof(PSManagedHsm))]
    public class RemoveAzureManagedHsmNetworkRule : ManagedHsmNetworkRuleSetBase
    {
        private const string ByNameParameterSet = "ByName";
        private const string ByInputObjectParameterSet = "ByInputObject";
        private const string ByResourceIdParameterSet = "ByResourceId";

        #region Parameters
        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "Specifies the name of a Managed HSM whose network rule set is being modified.")]
        [ResourceNameCompleter("Microsoft.KeyVault/managedHSMs", nameof(ResourceGroupName))]
        [Alias("HsmName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            ParameterSetName = ByNameParameterSet,
            HelpMessage = "Specifies the resource group name of the Managed HSM whose network rule set is being modified.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByInputObjectParameterSet,
            ValueFromPipeline = true,
            HelpMessage = "Managed HSM object.")]
        [ValidateNotNullOrEmpty]
        public PSManagedHsm InputObject { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            ParameterSetName = ByResourceIdParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Managed HSM resource Id.")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }
        #endregion

        public override void ExecuteCmdlet()
        {
            if (InputObject != null)
            {
                Name = InputObject.Name;
                ResourceGroupName = InputObject.ResourceGroupName;
            }
            else if (ResourceId != null)
            {
                var resourceIdentifier = new ResourceIdentifier(ResourceId);
                Name = resourceIdentifier.ResourceName;
                ResourceGroupName = resourceIdentifier.ResourceGroupName;
            }

            if (ShouldProcess(Name, Properties.Resources.RemoveNetworkRule))
            {
                bool isIpAddressRangeSpecified = IsIpAddressRangeSpecified;
                bool isVirtualNetResIdSpecified = IsVirtualNetworkResourceIdSpecified;
                if (isVirtualNetResIdSpecified)
                {
                    throw new NotSupportedException("Virtual network rules are not supported for Managed HSM.");
                }
                if (!isIpAddressRangeSpecified)
                {
                    throw new ArgumentException("IpAddressRange must be specified.");
                }

                ValidateArrayInputs(); // will also guard empty strings

                var existingHsm = GetCurrentManagedHsm(Name, ResourceGroupName);
                var existingService = existingHsm.OriginalManagedHsm.Properties.NetworkAcls;

                IList<string> ipAddressRanges = existingService?.IPRules != null
                    ? new List<string>(existingService.IPRules.Select(r => r.Value))
                    : new List<string>();
                if (isIpAddressRangeSpecified)
                {
                    ipAddressRanges = RemoveInputFromSource(IpAddressRange, ipAddressRanges);
                }

                IList<string> virtualNetworkResourceIds = existingService?.VirtualNetworkRules != null
                    ? new List<string>(existingService.VirtualNetworkRules.Select(r => r.Id))
                    : new List<string>();
                if (isVirtualNetResIdSpecified)
                {
                    virtualNetworkResourceIds = RemoveInputFromSource(VirtualNetworkResourceId, virtualNetworkResourceIds);
                }

                var defaultAction = existingService?.DefaultAction != null && Enum.TryParse(existingService.DefaultAction, true, out PSManagedHsmNetworkRuleDefaultActionEnum parsedDefault) ? parsedDefault : PSManagedHsmNetworkRuleDefaultActionEnum.Allow;
                var bypass = existingService?.Bypass != null && Enum.TryParse(existingService.Bypass, true, out PSManagedHsmNetworkRuleBypassEnum parsedBypass) ? parsedBypass : PSManagedHsmNetworkRuleBypassEnum.AzureServices;

                var updatedRuleSet = new PSManagedHsmNetworkRuleSet(defaultAction, bypass, ipAddressRanges, virtualNetworkResourceIds);

                var updatedHsm = UpdateCurrentManagedHsm(existingHsm, updatedRuleSet);
                if (PassThru.IsPresent)
                {
                    WriteObject(updatedHsm);
                }
            }
        }

        private static IList<string> RemoveInputFromSource(string[] removeTargets, IList<string> source)
        {
            if (removeTargets == null || removeTargets.Length == 0 || source == null || source.Count == 0)
            {
                return source;
            }

            var updated = new List<string>(source);
            foreach (var target in removeTargets)
            {
                int index = updated.FindIndex(x => string.Equals(x, target, StringComparison.OrdinalIgnoreCase));
                if (index != -1)
                {
                    updated.RemoveAt(index);
                }
            }
            return updated;
        }
    }
}
