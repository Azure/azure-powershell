namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Certificate resource payload.</summary>
    public partial class CertificateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal
    {

        /// <summary>Backing field for <see cref="ActivateDate" /> property.</summary>
        private string _activateDate;

        /// <summary>The activate date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ActivateDate { get => this._activateDate; }

        /// <summary>Backing field for <see cref="CertVersion" /> property.</summary>
        private string _certVersion;

        /// <summary>The certificate version of key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string CertVersion { get => this._certVersion; set => this._certVersion = value; }

        /// <summary>Backing field for <see cref="DnsName" /> property.</summary>
        private string[] _dnsName;

        /// <summary>The domain list of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string[] DnsName { get => this._dnsName; }

        /// <summary>Backing field for <see cref="ExpirationDate" /> property.</summary>
        private string _expirationDate;

        /// <summary>The expiration date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ExpirationDate { get => this._expirationDate; }

        /// <summary>Backing field for <see cref="IssuedDate" /> property.</summary>
        private string _issuedDate;

        /// <summary>The issue date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string IssuedDate { get => this._issuedDate; }

        /// <summary>Backing field for <see cref="Issuer" /> property.</summary>
        private string _issuer;

        /// <summary>The issuer of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Issuer { get => this._issuer; }

        /// <summary>Backing field for <see cref="KeyVaultCertName" /> property.</summary>
        private string _keyVaultCertName;

        /// <summary>The certificate name of key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string KeyVaultCertName { get => this._keyVaultCertName; set => this._keyVaultCertName = value; }

        /// <summary>Internal Acessors for ActivateDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.ActivateDate { get => this._activateDate; set { {_activateDate = value;} } }

        /// <summary>Internal Acessors for DnsName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.DnsName { get => this._dnsName; set { {_dnsName = value;} } }

        /// <summary>Internal Acessors for ExpirationDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.ExpirationDate { get => this._expirationDate; set { {_expirationDate = value;} } }

        /// <summary>Internal Acessors for IssuedDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.IssuedDate { get => this._issuedDate; set { {_issuedDate = value;} } }

        /// <summary>Internal Acessors for Issuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.Issuer { get => this._issuer; set { {_issuer = value;} } }

        /// <summary>Internal Acessors for SubjectName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.SubjectName { get => this._subjectName; set { {_subjectName = value;} } }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal.Thumbprint { get => this._thumbprint; set { {_thumbprint = value;} } }

        /// <summary>Backing field for <see cref="SubjectName" /> property.</summary>
        private string _subjectName;

        /// <summary>The subject name of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string SubjectName { get => this._subjectName; }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>The thumbprint of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; }

        /// <summary>Backing field for <see cref="VaultUri" /> property.</summary>
        private string _vaultUri;

        /// <summary>The vault uri of user key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string VaultUri { get => this._vaultUri; set => this._vaultUri = value; }

        /// <summary>Creates an new <see cref="CertificateProperties" /> instance.</summary>
        public CertificateProperties()
        {

        }
    }
    /// Certificate resource payload.
    public partial interface ICertificateProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>The activate date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The activate date of certificate.",
        SerializedName = @"activateDate",
        PossibleTypes = new [] { typeof(string) })]
        string ActivateDate { get;  }
        /// <summary>The certificate version of key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The certificate version of key vault.",
        SerializedName = @"certVersion",
        PossibleTypes = new [] { typeof(string) })]
        string CertVersion { get; set; }
        /// <summary>The domain list of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The domain list of certificate.",
        SerializedName = @"dnsNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsName { get;  }
        /// <summary>The expiration date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The expiration date of certificate.",
        SerializedName = @"expirationDate",
        PossibleTypes = new [] { typeof(string) })]
        string ExpirationDate { get;  }
        /// <summary>The issue date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The issue date of certificate.",
        SerializedName = @"issuedDate",
        PossibleTypes = new [] { typeof(string) })]
        string IssuedDate { get;  }
        /// <summary>The issuer of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The issuer of certificate.",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string Issuer { get;  }
        /// <summary>The certificate name of key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The certificate name of key vault.",
        SerializedName = @"keyVaultCertName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultCertName { get; set; }
        /// <summary>The subject name of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The subject name of certificate.",
        SerializedName = @"subjectName",
        PossibleTypes = new [] { typeof(string) })]
        string SubjectName { get;  }
        /// <summary>The thumbprint of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The thumbprint of certificate.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get;  }
        /// <summary>The vault uri of user key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The vault uri of user key vault.",
        SerializedName = @"vaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string VaultUri { get; set; }

    }
    /// Certificate resource payload.
    public partial interface ICertificatePropertiesInternal

    {
        /// <summary>The activate date of certificate.</summary>
        string ActivateDate { get; set; }
        /// <summary>The certificate version of key vault.</summary>
        string CertVersion { get; set; }
        /// <summary>The domain list of certificate.</summary>
        string[] DnsName { get; set; }
        /// <summary>The expiration date of certificate.</summary>
        string ExpirationDate { get; set; }
        /// <summary>The issue date of certificate.</summary>
        string IssuedDate { get; set; }
        /// <summary>The issuer of certificate.</summary>
        string Issuer { get; set; }
        /// <summary>The certificate name of key vault.</summary>
        string KeyVaultCertName { get; set; }
        /// <summary>The subject name of certificate.</summary>
        string SubjectName { get; set; }
        /// <summary>The thumbprint of certificate.</summary>
        string Thumbprint { get; set; }
        /// <summary>The vault uri of user key vault.</summary>
        string VaultUri { get; set; }

    }
}