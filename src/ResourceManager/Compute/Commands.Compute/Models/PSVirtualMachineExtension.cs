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

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSVirtualMachineExtension
    {
        public string ResourceGroupName { get; set; }

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
    }

    public static class PSVirtualMachineExtensionConversions
    {
        public static PSVirtualMachineExtension ToPSVirtualMachineExtension(this VirtualMachineExtensionGetResponse response, string rgName = null)
        {
            if (response == null)
            {
                return null;
            }

            return response.VirtualMachineExtension.ToPSVirtualMachineExtension(rgName);
        }

        public static PSVirtualMachineExtension ToPSVirtualMachineExtension(this VirtualMachineExtension ext, string rgName = null)
        {
            PSVirtualMachineExtension result = new PSVirtualMachineExtension
            {
                ResourceGroupName = rgName,
                Name = ext.Name,
                Location = ext.Location,
                Etag = null, // TODO: Update CRP library for this field
                Publisher = ext == null ? null : ext.Publisher,
                ExtensionType = ext == null ? null : ext.ExtensionType,
                TypeHandlerVersion = ext == null ? null : ext.TypeHandlerVersion,
                Id = ext.Id,
                PublicSettings = ext == null ? null : ext.Settings,
                ProtectedSettings = ext == null ? null : ext.ProtectedSettings,
                ProvisioningState = ext == null ? null : ext.ProvisioningState,
                Statuses = ext == null || ext.InstanceView == null ? null : ext.InstanceView.Statuses
            };

            return result;
        }
    }
}
