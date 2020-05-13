namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>CertificatePatchResource resource specific properties</summary>
    public partial class CertificatePatchResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="CanonicalName" /> property.</summary>
        private string _canonicalName;

        /// <summary>CNAME of the certificate to be issued via free certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CanonicalName { get => this._canonicalName; set => this._canonicalName = value; }

        /// <summary>Backing field for <see cref="CerBlob" /> property.</summary>
        private byte[] _cerBlob;

        /// <summary>Raw bytes of .cer file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public byte[] CerBlob { get => this._cerBlob; }

        /// <summary>Backing field for <see cref="ExpirationDate" /> property.</summary>
        private global::System.DateTime? _expirationDate;

        /// <summary>Certificate expiration date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpirationDate { get => this._expirationDate; }

        /// <summary>Backing field for <see cref="FriendlyName" /> property.</summary>
        private string _friendlyName;

        /// <summary>Friendly name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string FriendlyName { get => this._friendlyName; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string[] _hostName;

        /// <summary>Host names the certificate applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] HostName { get => this._hostName; set => this._hostName = value; }

        /// <summary>Backing field for <see cref="HostingEnvironmentProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile _hostingEnvironmentProfile;

        /// <summary>Specification for the App Service Environment to use for the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile HostingEnvironmentProfile { get => (this._hostingEnvironmentProfile = this._hostingEnvironmentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile()); }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Id = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type; }

        /// <summary>Backing field for <see cref="IssueDate" /> property.</summary>
        private global::System.DateTime? _issueDate;

        /// <summary>Certificate issue Date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? IssueDate { get => this._issueDate; }

        /// <summary>Backing field for <see cref="Issuer" /> property.</summary>
        private string _issuer;

        /// <summary>Certificate issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Issuer { get => this._issuer; }

        /// <summary>Backing field for <see cref="KeyVaultId" /> property.</summary>
        private string _keyVaultId;

        /// <summary>Key Vault Csm resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyVaultId { get => this._keyVaultId; set => this._keyVaultId = value; }

        /// <summary>Backing field for <see cref="KeyVaultSecretName" /> property.</summary>
        private string _keyVaultSecretName;

        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string KeyVaultSecretName { get => this._keyVaultSecretName; set => this._keyVaultSecretName = value; }

        /// <summary>Backing field for <see cref="KeyVaultSecretStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? _keyVaultSecretStatus;

        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? KeyVaultSecretStatus { get => this._keyVaultSecretStatus; }

        /// <summary>Internal Acessors for CerBlob</summary>
        byte[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.CerBlob { get => this._cerBlob; set { {_cerBlob = value;} } }

        /// <summary>Internal Acessors for ExpirationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.ExpirationDate { get => this._expirationDate; set { {_expirationDate = value;} } }

        /// <summary>Internal Acessors for FriendlyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.FriendlyName { get => this._friendlyName; set { {_friendlyName = value;} } }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.HostingEnvironmentProfile { get => (this._hostingEnvironmentProfile = this._hostingEnvironmentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile()); set { {_hostingEnvironmentProfile = value;} } }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type = value; }

        /// <summary>Internal Acessors for IssueDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.IssueDate { get => this._issueDate; set { {_issueDate = value;} } }

        /// <summary>Internal Acessors for Issuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.Issuer { get => this._issuer; set { {_issuer = value;} } }

        /// <summary>Internal Acessors for KeyVaultSecretStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.KeyVaultSecretStatus { get => this._keyVaultSecretStatus; set { {_keyVaultSecretStatus = value;} } }

        /// <summary>Internal Acessors for PublicKeyHash</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.PublicKeyHash { get => this._publicKeyHash; set { {_publicKeyHash = value;} } }

        /// <summary>Internal Acessors for SelfLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.SelfLink { get => this._selfLink; set { {_selfLink = value;} } }

        /// <summary>Internal Acessors for SiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.SiteName { get => this._siteName; set { {_siteName = value;} } }

        /// <summary>Internal Acessors for SubjectName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.SubjectName { get => this._subjectName; set { {_subjectName = value;} } }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.Thumbprint { get => this._thumbprint; set { {_thumbprint = value;} } }

        /// <summary>Internal Acessors for Valid</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal.Valid { get => this._valid; set { {_valid = value;} } }

        /// <summary>Backing field for <see cref="Password" /> property.</summary>
        private string _password;

        /// <summary>Certificate password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Password { get => this._password; set => this._password = value; }

        /// <summary>Backing field for <see cref="PfxBlob" /> property.</summary>
        private byte[] _pfxBlob;

        /// <summary>Pfx blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public byte[] PfxBlob { get => this._pfxBlob; set => this._pfxBlob = value; }

        /// <summary>Backing field for <see cref="PublicKeyHash" /> property.</summary>
        private string _publicKeyHash;

        /// <summary>Public key hash.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PublicKeyHash { get => this._publicKeyHash; }

        /// <summary>Backing field for <see cref="SelfLink" /> property.</summary>
        private string _selfLink;

        /// <summary>Self link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SelfLink { get => this._selfLink; }

        /// <summary>Backing field for <see cref="ServerFarmId" /> property.</summary>
        private string _serverFarmId;

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServerFarmId { get => this._serverFarmId; set => this._serverFarmId = value; }

        /// <summary>Backing field for <see cref="SiteName" /> property.</summary>
        private string _siteName;

        /// <summary>App name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SiteName { get => this._siteName; }

        /// <summary>Backing field for <see cref="SubjectName" /> property.</summary>
        private string _subjectName;

        /// <summary>Subject name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SubjectName { get => this._subjectName; }

        /// <summary>Backing field for <see cref="Thumbprint" /> property.</summary>
        private string _thumbprint;

        /// <summary>Certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Thumbprint { get => this._thumbprint; }

        /// <summary>Backing field for <see cref="Valid" /> property.</summary>
        private bool? _valid;

        /// <summary>Is the certificate valid?.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Valid { get => this._valid; }

        /// <summary>Creates an new <see cref="CertificatePatchResourceProperties" /> instance.</summary>
        public CertificatePatchResourceProperties()
        {

        }
    }
    /// CertificatePatchResource resource specific properties
    public partial interface ICertificatePatchResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>CNAME of the certificate to be issued via free certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"CNAME of the certificate to be issued via free certificate",
        SerializedName = @"canonicalName",
        PossibleTypes = new [] { typeof(string) })]
        string CanonicalName { get; set; }
        /// <summary>Raw bytes of .cer file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Raw bytes of .cer file",
        SerializedName = @"cerBlob",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] CerBlob { get;  }
        /// <summary>Certificate expiration date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate expiration date.",
        SerializedName = @"expirationDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpirationDate { get;  }
        /// <summary>Friendly name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Friendly name of the certificate.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get;  }
        /// <summary>Host names the certificate applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Host names the certificate applies to.",
        SerializedName = @"hostNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] HostName { get; set; }
        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the App Service Environment.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileId { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the App Service Environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileName { get;  }
        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type of the App Service Environment.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileType { get;  }
        /// <summary>Certificate issue Date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate issue Date.",
        SerializedName = @"issueDate",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? IssueDate { get;  }
        /// <summary>Certificate issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate issuer.",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string Issuer { get;  }
        /// <summary>Key Vault Csm resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault Csm resource Id.",
        SerializedName = @"keyVaultId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultId { get; set; }
        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault secret name.",
        SerializedName = @"keyVaultSecretName",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultSecretName { get; set; }
        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of the Key Vault secret.",
        SerializedName = @"keyVaultSecretStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? KeyVaultSecretStatus { get;  }
        /// <summary>Certificate password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Certificate password.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string Password { get; set; }
        /// <summary>Pfx blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Pfx blob.",
        SerializedName = @"pfxBlob",
        PossibleTypes = new [] { typeof(byte[]) })]
        byte[] PfxBlob { get; set; }
        /// <summary>Public key hash.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Public key hash.",
        SerializedName = @"publicKeyHash",
        PossibleTypes = new [] { typeof(string) })]
        string PublicKeyHash { get;  }
        /// <summary>Self link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Self link.",
        SerializedName = @"selfLink",
        PossibleTypes = new [] { typeof(string) })]
        string SelfLink { get;  }
        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the associated App Service plan, formatted as: ""/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}"".",
        SerializedName = @"serverFarmId",
        PossibleTypes = new [] { typeof(string) })]
        string ServerFarmId { get; set; }
        /// <summary>App name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"App name.",
        SerializedName = @"siteName",
        PossibleTypes = new [] { typeof(string) })]
        string SiteName { get;  }
        /// <summary>Subject name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Subject name of the certificate.",
        SerializedName = @"subjectName",
        PossibleTypes = new [] { typeof(string) })]
        string SubjectName { get;  }
        /// <summary>Certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate thumbprint.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string Thumbprint { get;  }
        /// <summary>Is the certificate valid?.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Is the certificate valid?.",
        SerializedName = @"valid",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Valid { get;  }

    }
    /// CertificatePatchResource resource specific properties
    internal partial interface ICertificatePatchResourcePropertiesInternal

    {
        /// <summary>CNAME of the certificate to be issued via free certificate</summary>
        string CanonicalName { get; set; }
        /// <summary>Raw bytes of .cer file</summary>
        byte[] CerBlob { get; set; }
        /// <summary>Certificate expiration date.</summary>
        global::System.DateTime? ExpirationDate { get; set; }
        /// <summary>Friendly name of the certificate.</summary>
        string FriendlyName { get; set; }
        /// <summary>Host names the certificate applies to.</summary>
        string[] HostName { get; set; }
        /// <summary>Specification for the App Service Environment to use for the certificate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile HostingEnvironmentProfile { get; set; }
        /// <summary>Resource ID of the App Service Environment.</summary>
        string HostingEnvironmentProfileId { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        string HostingEnvironmentProfileName { get; set; }
        /// <summary>Resource type of the App Service Environment.</summary>
        string HostingEnvironmentProfileType { get; set; }
        /// <summary>Certificate issue Date.</summary>
        global::System.DateTime? IssueDate { get; set; }
        /// <summary>Certificate issuer.</summary>
        string Issuer { get; set; }
        /// <summary>Key Vault Csm resource Id.</summary>
        string KeyVaultId { get; set; }
        /// <summary>Key Vault secret name.</summary>
        string KeyVaultSecretName { get; set; }
        /// <summary>Status of the Key Vault secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? KeyVaultSecretStatus { get; set; }
        /// <summary>Certificate password.</summary>
        string Password { get; set; }
        /// <summary>Pfx blob.</summary>
        byte[] PfxBlob { get; set; }
        /// <summary>Public key hash.</summary>
        string PublicKeyHash { get; set; }
        /// <summary>Self link.</summary>
        string SelfLink { get; set; }
        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        string ServerFarmId { get; set; }
        /// <summary>App name.</summary>
        string SiteName { get; set; }
        /// <summary>Subject name of the certificate.</summary>
        string SubjectName { get; set; }
        /// <summary>Certificate thumbprint.</summary>
        string Thumbprint { get; set; }
        /// <summary>Is the certificate valid?.</summary>
        bool? Valid { get; set; }

    }
}