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

using Microsoft.Azure.Management.Compute.Models;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachineScaleSetExtension
    {
        public string ResourceGroupName { get; set; }
        public string VmssName { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Type { get; set; }
        public string TypeHandlerVersion { get; set; }
        public string Id { get; set; }
        public object Settings { get; set; }
        public object ProtectedSettings { get; set; }
        public string ProvisioningState { get; set; }
        public bool? AutoUpgradeMinorVersion { get; set; }
        public string ForceUpdateTag { get; set; }
    }

    public static class PSVirtualMachineScaleSetExtensionConversions
    {
        public static PSVirtualMachineScaleSetExtension ToPSVirtualMachineScaleSetExtension(this VirtualMachineScaleSetExtension ext, string rgName, string vmssName)
        {
            PSVirtualMachineScaleSetExtension result = new PSVirtualMachineScaleSetExtension
            {
                ResourceGroupName = rgName,
                VmssName = vmssName,
                Name = ext.Name,
                Publisher = ext.Publisher,
                Type = ext.Type,
                TypeHandlerVersion = ext.TypeHandlerVersion,
                Id = ext.Id,
                Settings = ext.Settings == null ? null : ext.Settings.ToString(),
                ProtectedSettings = ext.ProtectedSettings == null ? null : ext.ProtectedSettings.ToString(),
                ProvisioningState = ext.ProvisioningState,
                AutoUpgradeMinorVersion = ext.AutoUpgradeMinorVersion,
                ForceUpdateTag = ext.ForceUpdateTag
            };

            return result;
        }
    }
}
