// -----------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Commands.Batch.Utils;
using System.Linq;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSVirtualMachineConfiguration
    {
        internal VirtualMachineConfiguration toMgmtVirtualMachineConfiguration()
        {
            return new VirtualMachineConfiguration
            {
                ImageReference = this.ImageReference?.toMgmtImageReference(),
                NodeAgentSkuId = this.NodeAgentSkuId,
                WindowsConfiguration = this.WindowsConfiguration?.toMgmtWindowsConfiguration(),
                DataDisks = this.DataDisks?.Select(dd => dd?.toMgmtDataDisk()).ToList(),
                LicenseType = this.LicenseType,
                ContainerConfiguration = this.ContainerConfiguration?.toMgmtContainerConfiguration(),
                DiskEncryptionConfiguration = this.DiskEncryptionConfiguration?.toMgmtDiskEncryptionConfiguration(),
                NodePlacementConfiguration = this.NodePlacementConfiguration?.toMgmtNodePlacementConfiguration(),
                Extensions = this.Extensions?.Select(ext => ext?.toMgmtVMExtension()).ToList(),
                OSDisk = this.OSDisk?.toMgmtOSDisk(),
                SecurityProfile = this.SecurityProfile?.toMgmtSecurityProfile(),
                ServiceArtifactReference = this.ServiceArtifactReference?.toMgmtServiceArtifactReference()
            };
        }

        internal static PSVirtualMachineConfiguration fromMgmtPSVirtualMachineConfiguration(VirtualMachineConfiguration virtualMachineConfiguration)
        {
            if (virtualMachineConfiguration == null)
            {
                return null;
            }
            return new PSVirtualMachineConfiguration(
                imageReference: PSImageReference.fromMgmtImageReference(virtualMachineConfiguration.ImageReference),
                nodeAgentSkuId: virtualMachineConfiguration.NodeAgentSkuId
            )
            {
                WindowsConfiguration = PSWindowsConfiguration.fromMgmtWindowsConfiguration(virtualMachineConfiguration.WindowsConfiguration),
                DataDisks = (virtualMachineConfiguration.DataDisks != null) ? virtualMachineConfiguration.DataDisks.Select(dd => PSDataDisk.fromMgmtDataDisk(dd)).ToList() : null,
                LicenseType = virtualMachineConfiguration.LicenseType,
                ContainerConfiguration = PSContainerConfiguration.fromMgmtContainerConfiguration(virtualMachineConfiguration.ContainerConfiguration),
                DiskEncryptionConfiguration = PSDiskEncryptionConfiguration.fromMgmtDiskEncryptionConfiguration(virtualMachineConfiguration.DiskEncryptionConfiguration),
                NodePlacementConfiguration = PSNodePlacementConfiguration.fromMgmtNodePlacementConfiguration(virtualMachineConfiguration.NodePlacementConfiguration),
                Extensions = (virtualMachineConfiguration.Extensions != null) ? virtualMachineConfiguration.Extensions.Select(ext => PSVMExtension.fromMgmtVMExtension(ext)).ToList() : null,
                OSDisk = PSOSDisk.fromMgmtOSDisk(virtualMachineConfiguration.OSDisk),
                SecurityProfile = PSSecurityProfile.fromMgmtSecurityProfile(virtualMachineConfiguration.SecurityProfile),
                ServiceArtifactReference = PSServiceArtifactReference.fromMgmtServiceArtifactReference(virtualMachineConfiguration.ServiceArtifactReference)
            };
        }
    }
}
