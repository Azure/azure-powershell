using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001
{
    public class VirtualMachineWithStatus : IVirtualMachine
    {
        public VirtualMachineWithStatus(IVirtualMachine machine, IVirtualMachineInstanceView status)
        {
            AdditionalCapabilities = machine.AdditionalCapabilities;
            AvailabilitySet = machine.AvailabilitySet;
            DiagnosticsProfile = machine.DiagnosticsProfile;
            HardwareProfile = machine.HardwareProfile;
            Identity = machine.Identity;
            InstanceView = machine.InstanceView;
            LicenseType = machine.LicenseType;
            NetworkProfile = machine.NetworkProfile;
            OsProfile = machine.OsProfile;
            Plan = machine.Plan;
            Properties = machine.Properties;
            Resources = machine.Resources;
            StorageProfile = machine.StorageProfile;
            VmId = machine.VmId;
            Zones = machine.Zones;
            Plan = machine.Plan;
            ProvisioningState = machine.ProvisioningState;

            Id = machine.Id;
            Location = machine.Location;
            Name = machine.Name;
            Tag = machine.Tag;
            Type = machine.Type;
            Status = status?.Statuses?.Select(s => s?.DisplayStatus).LastOrDefault();
        }

        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IAdditionalCapabilities AdditionalCapabilities { get; set; }
        public bool? AdditionalCapabilitiesUltraSSDEnabled { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.ISubResource AvailabilitySet { get; set; }
        public string AvailabilitySetId { get; set; }
        public bool? BootDiagnosticsEnabled { get; set; }
        public string BootDiagnosticsStorageUri { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IDiagnosticsProfile DiagnosticsProfile { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IBootDiagnostics DiagnosticsProfileBootDiagnostics { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IHardwareProfile HardwareProfile { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.VirtualMachineSizeTypes HardwareProfileVmSize { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IVirtualMachineIdentity Identity { get; set; }
        public string IdentityPrincipalId { get;  }
        public string IdentityTenantId { get;  }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ResourceIdentityType IdentityType { get; set; }
        public System.Collections.Hashtable IdentityUserAssignedIdentities { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IVirtualMachineInstanceView InstanceView { get; set; }
        public string LicenseType { get; set; }
        public bool? LinuxConfigurationDisablePasswordAuthentication { get; set; }
        public bool? LinuxConfigurationProvisionVMAgent { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.ISshConfiguration LinuxConfigurationSsh { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.ISshPublicKey[] LinuxConfigurationSshPublicKeys { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.INetworkProfile NetworkProfile { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.INetworkInterfaceReference[] NetworkProfileNetworkInterfaces { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IOSProfile OsProfile { get; set; }
        public string OsProfileAdminPassword { get; set; }
        public string OsProfileAdminUsername { get; set; }
        public bool? OsProfileAllowExtensionOperations { get; set; }
        public string OsProfileComputerName { get; set; }
        public string OsProfileCustomData { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.ILinuxConfiguration OsProfileLinuxConfiguration { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVaultSecretGroup[] OsProfileSecrets { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IWindowsConfiguration OsProfileWindowsConfiguration { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IPlan Plan { get; set; }
        public string PlanName { get; set; }
        public string PlanProduct { get; set; }
        public string PlanPromotionCode { get; set; }
        public string PlanPublisher { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IVirtualMachineProperties Properties { get; set; }
        public string ProvisioningState { get;  }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IVirtualMachineExtension[] Resources { get;  }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20181001.IStorageProfile StorageProfile { get; set; }
        public string VmId { get;  }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IWinRMListener[] WinRMListeners { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IAdditionalUnattendContent[] WindowsConfigurationAdditionalUnattendContent { get; set; }
        public bool? WindowsConfigurationEnableAutomaticUpdates { get; set; }
        public bool? WindowsConfigurationProvisionVMAgent { get; set; }
        public string WindowsConfigurationTimeZone { get; set; }
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20171201.IWinRMConfiguration WindowsConfigurationWinRM { get; set; }
        public string[] Zones { get; set; }
        public string Status {get; set;}

        public string Id {get; set;}
        public string Name {get; set;}
        public string Location {get; set;}
        public Hashtable Tag {get; set;}
        public string Type {get; set;}

        public Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonNode ToJson(Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.Json.JsonObject container, Microsoft.Azure.PowerShell.Cmdlets.Compute.Runtime.SerializationMode serializationMode)
        {
            throw new NotImplementedException();
        }

    }
}
