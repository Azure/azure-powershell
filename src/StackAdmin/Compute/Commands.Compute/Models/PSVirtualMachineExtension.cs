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
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachineExtension
    {
        public string ResourceGroupName { get; set; }

        public string VMName { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Etag { get; set; }

        public string Publisher { get; set; }

        public string ExtensionType { get; set; }

        public string TypeHandlerVersion { get; set; }

        public string Id { get; set; }

        public string PublicSettings { get; set; }

        public string ProtectedSettings { get; set; }

        public string ProvisioningState { get; set; }

        public IList<InstanceViewStatus> Statuses { get; set; }

        public IList<InstanceViewStatus> SubStatuses { get; set; }

        public bool? AutoUpgradeMinorVersion { get; set; }

        public string ForceUpdateTag { get; set; }
    }

    public static class PSVirtualMachineExtensionConversions
    {
        public static PSVirtualMachineExtension ToPSVirtualMachineExtension(this AzureOperationResponse<VirtualMachineExtension> response, string rgName, string vmName)
        {
            if (response == null)
            {
                return null;
            }

            return response.Body.ToPSVirtualMachineExtension(rgName, vmName);
        }

        public static PSVirtualMachineExtension ToPSVirtualMachineExtension(this VirtualMachineExtension ext, string rgName, string vmName)
        {
            PSVirtualMachineExtension result = new PSVirtualMachineExtension
            {
                ResourceGroupName = rgName,
                VMName = vmName,
                Name = ext.Name,
                Location = ext.Location,
                Etag = JsonConvert.SerializeObject(ext.Tags),
                Publisher = ext.Publisher,
                ExtensionType = ext.VirtualMachineExtensionType,
                TypeHandlerVersion = ext.TypeHandlerVersion,
                Id = ext.Id,
                PublicSettings = ext.Settings == null ? null : ext.Settings.ToString(),
                ProtectedSettings = ext.ProtectedSettings == null ? null : ext.ProtectedSettings.ToString(),
                ProvisioningState = ext.ProvisioningState,
                Statuses = ext.InstanceView == null ? null : ext.InstanceView.Statuses,
                SubStatuses = ext.InstanceView == null ? null : ext.InstanceView.Substatuses,
                AutoUpgradeMinorVersion = ext.AutoUpgradeMinorVersion,
                ForceUpdateTag = ext.ForceUpdateTag
            };

            return result;
        }
    }
}
