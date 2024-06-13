// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes a virtual machine scale set virtual machine profile.
    /// </summary>
    public partial class VirtualMachineScaleSetUpdateVMProfile
    {
        public VirtualMachineScaleSetUpdateVMProfile(VirtualMachineScaleSetUpdateOSProfile osProfile, VirtualMachineScaleSetUpdateStorageProfile storageProfile, VirtualMachineScaleSetUpdateNetworkProfile networkProfile, SecurityProfile securityProfile, DiagnosticsProfile diagnosticsProfile = default(DiagnosticsProfile), VirtualMachineScaleSetExtensionProfile extensionProfile = default(VirtualMachineScaleSetExtensionProfile), string licenseType = default(string), BillingProfile billingProfile = default(BillingProfile), ScheduledEventsProfile scheduledEventsProfile = default(ScheduledEventsProfile), string userData = default(string), VirtualMachineScaleSetHardwareProfile hardwareProfile = default(VirtualMachineScaleSetHardwareProfile))
        {
            OsProfile = osProfile;
            StorageProfile = storageProfile;
            NetworkProfile = networkProfile;
            SecurityProfile = securityProfile;
            DiagnosticsProfile = diagnosticsProfile;
            ExtensionProfile = extensionProfile;
            LicenseType = licenseType;
            BillingProfile = billingProfile;
            ScheduledEventsProfile = scheduledEventsProfile;
            UserData = userData;
            HardwareProfile = hardwareProfile;
            CustomInit();
        }
    }
}