// PSVirtualMachineExtensionTrack2.cs
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSVirtualMachineExtension
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public IDictionary<string, string> Tags { get; set; }
        
        public string ForceUpdateTag { get; set; }
        public string Publisher { get; set; }
        public string VirtualMachineExtensionType { get; set; }
        public string TypeHandlerVersion { get; set; }
        public bool? AutoUpgradeMinorVersion { get; set; }
        public bool? EnableAutomaticUpgrade { get; set; }
        public object Settings { get; set; }
        public object ProtectedSettings { get; set; }
        public string ProvisioningState { get; set; }
        public PSVirtualMachineExtensionInstanceView InstanceView { get; set; }
        public bool? SuppressFailures { get; set; }
        public PSKeyVaultSecretReference ProtectedSettingsFromKeyVault { get; set; }
    }
}