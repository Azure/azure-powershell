namespace Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Extensions;

    /// <summary>Secure LDAP Settings</summary>
    public partial class LdapsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal
    {

        /// <summary>Backing field for <see cref="CertificateNotAfter" /> property.</summary>
        private global::System.DateTime? _certificateNotAfter;

        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public global::System.DateTime? CertificateNotAfter { get => this._certificateNotAfter; }

        /// <summary>Backing field for <see cref="CertificateThumbprint" /> property.</summary>
        private string _certificateThumbprint;

        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string CertificateThumbprint { get => this._certificateThumbprint; }

        /// <summary>Backing field for <see cref="ExternalAccess" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? _externalAccess;

        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? ExternalAccess { get => this._externalAccess; set => this._externalAccess = value; }

        /// <summary>Backing field for <see cref="Ldap" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? _ldap;

        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? Ldap { get => this._ldap; set => this._ldap = value; }

        /// <summary>Internal Acessors for CertificateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal.CertificateNotAfter { get => this._certificateNotAfter; set { {_certificateNotAfter = value;} } }

        /// <summary>Internal Acessors for CertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal.CertificateThumbprint { get => this._certificateThumbprint; set { {_certificateThumbprint = value;} } }

        /// <summary>Internal Acessors for PublicCertificate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ILdapsSettingsInternal.PublicCertificate { get => this._publicCertificate; set { {_publicCertificate = value;} } }

        /// <summary>Backing field for <see cref="PfxCertificate" /> property.</summary>
        private string _pfxCertificate;

        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string PfxCertificate { get => this._pfxCertificate; set => this._pfxCertificate = value; }

        /// <summary>Backing field for <see cref="PfxCertificatePassword" /> property.</summary>
        private string _pfxCertificatePassword;

        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string PfxCertificatePassword { get => this._pfxCertificatePassword; set => this._pfxCertificatePassword = value; }

        /// <summary>Backing field for <see cref="PublicCertificate" /> property.</summary>
        private string _publicCertificate;

        /// <summary>Public certificate used to configure secure ldap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.PropertyOrigin.Owned)]
        public string PublicCertificate { get => this._publicCertificate; }

        /// <summary>Creates an new <see cref="LdapsSettings" /> instance.</summary>
        public LdapsSettings()
        {

        }
    }
    /// Secure LDAP Settings
    public partial interface ILdapsSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.IJsonSerializable
    {
        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"NotAfter DateTime of configure ldaps certificate.",
        SerializedName = @"certificateNotAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CertificateNotAfter { get;  }
        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Thumbprint of configure ldaps certificate.",
        SerializedName = @"certificateThumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string CertificateThumbprint { get;  }
        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.",
        SerializedName = @"externalAccess",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? ExternalAccess { get; set; }
        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A flag to determine whether or not Secure LDAP is enabled or disabled.",
        SerializedName = @"ldaps",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps) })]
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? Ldap { get; set; }
        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation of the certificate pfx file.",
        SerializedName = @"pfxCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string PfxCertificate { get; set; }
        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The password to decrypt the provided Secure LDAP certificate pfx file.",
        SerializedName = @"pfxCertificatePassword",
        PossibleTypes = new [] { typeof(string) })]
        string PfxCertificatePassword { get; set; }
        /// <summary>Public certificate used to configure secure ldap.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Public certificate used to configure secure ldap.",
        SerializedName = @"publicCertificate",
        PossibleTypes = new [] { typeof(string) })]
        string PublicCertificate { get;  }

    }
    /// Secure LDAP Settings
    internal partial interface ILdapsSettingsInternal

    {
        /// <summary>NotAfter DateTime of configure ldaps certificate.</summary>
        global::System.DateTime? CertificateNotAfter { get; set; }
        /// <summary>Thumbprint of configure ldaps certificate.</summary>
        string CertificateThumbprint { get; set; }
        /// <summary>
        /// A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess? ExternalAccess { get; set; }
        /// <summary>A flag to determine whether or not Secure LDAP is enabled or disabled.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps? Ldap { get; set; }
        /// <summary>
        /// The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation
        /// of the certificate pfx file.
        /// </summary>
        string PfxCertificate { get; set; }
        /// <summary>The password to decrypt the provided Secure LDAP certificate pfx file.</summary>
        string PfxCertificatePassword { get; set; }
        /// <summary>Public certificate used to configure secure ldap.</summary>
        string PublicCertificate { get; set; }

    }
}