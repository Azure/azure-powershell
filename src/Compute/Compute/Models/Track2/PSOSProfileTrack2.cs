// PSOSProfileTrack2.cs
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSOSProfile
    {
        public string ComputerName { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string CustomData { get; set; }
        public PSWindowsConfiguration WindowsConfiguration { get; set; }
        public PSLinuxConfiguration LinuxConfiguration { get; set; }
        public IList<PSVaultSecretGroup> Secrets { get; set; }
        public bool? AllowExtensionOperations { get; set; }
        public bool? RequireGuestProvisionSignal { get; set; }
    }
    
    public class PSWindowsConfiguration
    {
        public bool? ProvisionVMAgent { get; set; }
        public bool? EnableAutomaticUpdates { get; set; }
        public string TimeZone { get; set; }
        public IList<PSAdditionalUnattendContent> AdditionalUnattendContent { get; set; }
        public PSPatchSettings PatchSettings { get; set; }
        public PSWinRMConfiguration WinRM { get; set; }
        public bool? EnableVMAgentPlatformUpdates { get; set; }
    }
    
    public class PSLinuxConfiguration
    {
        public bool? DisablePasswordAuthentication { get; set; }
        public PSSshConfiguration Ssh { get; set; }
        public bool? ProvisionVMAgent { get; set; }
        public PSPatchSettings PatchSettings { get; set; }
        public bool? EnableVMAgentPlatformUpdates { get; set; }
    }
    
    public class PSAdditionalUnattendContent
    {
        public string PassName { get; set; }
        public string ComponentName { get; set; }
        public string SettingName { get; set; }
        public string Content { get; set; }
    }
    
    public class PSPatchSettings
    {
        public string PatchMode { get; set; }
        public bool? EnableHotpatching { get; set; }
        public string AssessmentMode { get; set; }
        public PSWindowsVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get; set; }
    }
    
    public class PSWindowsVMGuestPatchAutomaticByPlatformSettings
    {
        public string RebootSetting { get; set; }
        public bool? BypassPlatformSafetyChecksOnUserSchedule { get; set; }
    }
    
    public class PSWinRMConfiguration
    {
        public IList<PSWinRMListener> Listeners { get; set; }
    }
    
    public class PSWinRMListener
    {
        public string Protocol { get; set; }
        public string CertificateUrl { get; set; }
    }
    
    public class PSSshConfiguration
    {
        public IList<PSSshPublicKey> PublicKeys { get; set; }
    }
    
    public class PSSshPublicKey
    {
        public string Path { get; set; }
        public string KeyData { get; set; }
    }
    
    public class PSVaultSecretGroup
    {
        public PSKeyVaultReference SourceVault { get; set; }
        public IList<PSVaultCertificate> VaultCertificates { get; set; }
    }
    
    public class PSKeyVaultReference
    {
        public string Id { get; set; }
    }
    
    public class PSVaultCertificate
    {
        public string CertificateUrl { get; set; }
        public string CertificateStore { get; set; }
    }
}