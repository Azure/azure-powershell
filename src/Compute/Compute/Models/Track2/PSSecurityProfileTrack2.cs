// PSSecurityProfile.cs
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSSecurityProfile
    {
        public PSUefiSettings UefiSettings { get; set; }
        public string EncryptionAtHost { get; set; }
        public string SecurityType { get; set; }
        public PSProxyAgentSettings ProxyAgentSettings { get; set; }
        public PSEncryptionIdentity EncryptionIdentity { get; set; }
    }
    
    public class PSUefiSettings
    {
        public bool? SecureBootEnabled { get; set; }
        public bool? VTpmEnabled { get; set; }
    }
    
    public class PSProxyAgentSettings
    {
        public bool? Enabled { get; set; }
        public string Mode { get; set; }
        public string KeyIncarnationId { get; set; }
    }
    
    public class PSEncryptionIdentity
    {
        public string UserAssignedIdentityResourceId { get; set; }
    }
    
    public class PSDiskEncryptionSettings
    {
        public PSDiskEncryptionSettingsElement DiskEncryptionKey { get; set; }
        public PSKeyEncryptionKey KeyEncryptionKey { get; set; }
        public bool? Enabled { get; set; }
    }
    
    public class PSDiskEncryptionSettingsElement
    {
        public PSKeyVaultSecretReference SecretUrl { get; set; }
        public PSKeyVaultReference SourceVault { get; set; }
    }
    
    public class PSKeyEncryptionKey
    {
        public string KeyUrl { get; set; }
        public PSKeyVaultReference SourceVault { get; set; }
    }
    
    public class PSKeyVaultSecretReference
    {
        public string SecretUrl { get; set; }
        public PSKeyVaultReference SourceVault { get; set; }
    }
}