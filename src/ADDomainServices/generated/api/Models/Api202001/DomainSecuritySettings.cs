namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Domain Security Settings</summary>
    public partial class DomainSecuritySettings :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettings,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainSecuritySettingsInternal
    {

        /// <summary>Backing field for <see cref="NtlmV1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? _ntlmV1;

        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? NtlmV1 { get => this._ntlmV1; set => this._ntlmV1 = value; }

        /// <summary>Backing field for <see cref="SyncKerberosPassword" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? _syncKerberosPassword;

        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? SyncKerberosPassword { get => this._syncKerberosPassword; set => this._syncKerberosPassword = value; }

        /// <summary>Backing field for <see cref="SyncNtlmPassword" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? _syncNtlmPassword;

        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? SyncNtlmPassword { get => this._syncNtlmPassword; set => this._syncNtlmPassword = value; }

        /// <summary>Backing field for <see cref="SyncOnPremPassword" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? _syncOnPremPassword;

        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? SyncOnPremPassword { get => this._syncOnPremPassword; set => this._syncOnPremPassword = value; }

        /// <summary>Backing field for <see cref="TlsV1" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? _tlsV1;

        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? TlsV1 { get => this._tlsV1; set => this._tlsV1 = value; }

        /// <summary>Creates an new <see cref="DomainSecuritySettings" /> instance.</summary>
        public DomainSecuritySettings()
        {

        }
    }
    /// Domain Security Settings
    public partial interface IDomainSecuritySettings :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not NtlmV1 is enabled or disabled.",
        SerializedName = @"ntlmV1",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? NtlmV1 { get; set; }
        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.",
        SerializedName = @"syncKerberosPasswords",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? SyncKerberosPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.",
        SerializedName = @"syncNtlmPasswords",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? SyncNtlmPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.",
        SerializedName = @"syncOnPremPasswords",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? SyncOnPremPassword { get; set; }
        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not TlsV1 is enabled or disabled.",
        SerializedName = @"tlsV1",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? TlsV1 { get; set; }

    }
    /// Domain Security Settings
    internal partial interface IDomainSecuritySettingsInternal

    {
        /// <summary>A flag to determine whether or not NtlmV1 is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1? NtlmV1 { get; set; }
        /// <summary>
        /// A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords? SyncKerberosPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords? SyncNtlmPassword { get; set; }
        /// <summary>A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords? SyncOnPremPassword { get; set; }
        /// <summary>A flag to determine whether or not TlsV1 is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1? TlsV1 { get; set; }

    }
}