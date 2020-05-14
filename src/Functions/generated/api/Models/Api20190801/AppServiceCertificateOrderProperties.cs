namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>AppServiceCertificateOrder resource specific properties</summary>
    public partial class AppServiceCertificateOrderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal
    {

        /// <summary>
        /// Backing field for <see cref="AppServiceCertificateNotRenewableReason" /> property.
        /// </summary>
        private string[] _appServiceCertificateNotRenewableReason;

        /// <summary>Reasons why App Service Certificate is not renewable at the current moment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] AppServiceCertificateNotRenewableReason { get => this._appServiceCertificateNotRenewableReason; }

        /// <summary>Backing field for <see cref="AutoRenew" /> property.</summary>
        private bool? _autoRenew;

        /// <summary>
        /// <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AutoRenew { get => this._autoRenew; set => this._autoRenew = value; }

        /// <summary>Backing field for <see cref="Certificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates _certificate;

        /// <summary>State of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates Certificate { get => (this._certificate = this._certificate ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificateOrderPropertiesCertificates()); set => this._certificate = value; }

        /// <summary>Backing field for <see cref="Csr" /> property.</summary>
        private string _csr;

        /// <summary>Last CSR that was created for this order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Csr { get => this._csr; set => this._csr = value; }

        /// <summary>Backing field for <see cref="DistinguishedName" /> property.</summary>
        private string _distinguishedName;

        /// <summary>Certificate distinguished name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DistinguishedName { get => this._distinguishedName; set => this._distinguishedName = value; }

        /// <summary>Backing field for <see cref="DomainVerificationToken" /> property.</summary>
        private string _domainVerificationToken;

        /// <summary>Domain verification token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DomainVerificationToken { get => this._domainVerificationToken; }

        /// <summary>Backing field for <see cref="ExpirationTime" /> property.</summary>
        private global::System.DateTime? _expirationTime;

        /// <summary>Certificate expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? ExpirationTime { get => this._expirationTime; }

        /// <summary>Backing field for <see cref="Intermediate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails _intermediate;

        /// <summary>Intermediate certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Intermediate { get => (this._intermediate = this._intermediate ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails()); }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Issuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IntermediateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).NotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IntermediateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).NotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).RawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).SerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).SignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Subject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Thumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? IntermediateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Version; }

        /// <summary>Backing field for <see cref="IsPrivateKeyExternal" /> property.</summary>
        private bool? _isPrivateKeyExternal;

        /// <summary><code>true</code> if private key is external; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsPrivateKeyExternal { get => this._isPrivateKeyExternal; }

        /// <summary>Backing field for <see cref="KeySize" /> property.</summary>
        private int? _keySize;

        /// <summary>Certificate key size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? KeySize { get => this._keySize; set => this._keySize = value; }

        /// <summary>Backing field for <see cref="LastCertificateIssuanceTime" /> property.</summary>
        private global::System.DateTime? _lastCertificateIssuanceTime;

        /// <summary>Certificate last issuance time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastCertificateIssuanceTime { get => this._lastCertificateIssuanceTime; }

        /// <summary>Internal Acessors for AppServiceCertificateNotRenewableReason</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.AppServiceCertificateNotRenewableReason { get => this._appServiceCertificateNotRenewableReason; set { {_appServiceCertificateNotRenewableReason = value;} } }

        /// <summary>Internal Acessors for DomainVerificationToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.DomainVerificationToken { get => this._domainVerificationToken; set { {_domainVerificationToken = value;} } }

        /// <summary>Internal Acessors for ExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.ExpirationTime { get => this._expirationTime; set { {_expirationTime = value;} } }

        /// <summary>Internal Acessors for Intermediate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.Intermediate { get => (this._intermediate = this._intermediate ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails()); set { {_intermediate = value;} } }

        /// <summary>Internal Acessors for IntermediateIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Issuer = value; }

        /// <summary>Internal Acessors for IntermediateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).NotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).NotAfter = value; }

        /// <summary>Internal Acessors for IntermediateNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).NotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).NotBefore = value; }

        /// <summary>Internal Acessors for IntermediateRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).RawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).RawData = value; }

        /// <summary>Internal Acessors for IntermediateSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).SerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).SerialNumber = value; }

        /// <summary>Internal Acessors for IntermediateSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).SignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).SignatureAlgorithm = value; }

        /// <summary>Internal Acessors for IntermediateSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Subject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Subject = value; }

        /// <summary>Internal Acessors for IntermediateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Thumbprint = value; }

        /// <summary>Internal Acessors for IntermediateVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IntermediateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Intermediate).Version = value; }

        /// <summary>Internal Acessors for IsPrivateKeyExternal</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.IsPrivateKeyExternal { get => this._isPrivateKeyExternal; set { {_isPrivateKeyExternal = value;} } }

        /// <summary>Internal Acessors for LastCertificateIssuanceTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.LastCertificateIssuanceTime { get => this._lastCertificateIssuanceTime; set { {_lastCertificateIssuanceTime = value;} } }

        /// <summary>Internal Acessors for NextAutoRenewalTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.NextAutoRenewalTimeStamp { get => this._nextAutoRenewalTimeStamp; set { {_nextAutoRenewalTimeStamp = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Root</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.Root { get => (this._root = this._root ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails()); set { {_root = value;} } }

        /// <summary>Internal Acessors for RootIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Issuer = value; }

        /// <summary>Internal Acessors for RootNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).NotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).NotAfter = value; }

        /// <summary>Internal Acessors for RootNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).NotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).NotBefore = value; }

        /// <summary>Internal Acessors for RootRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).RawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).RawData = value; }

        /// <summary>Internal Acessors for RootSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).SerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).SerialNumber = value; }

        /// <summary>Internal Acessors for RootSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).SignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).SignatureAlgorithm = value; }

        /// <summary>Internal Acessors for RootSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Subject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Subject = value; }

        /// <summary>Internal Acessors for RootThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Thumbprint = value; }

        /// <summary>Internal Acessors for RootVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.RootVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Version = value; }

        /// <summary>Internal Acessors for SerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SerialNumber { get => this._serialNumber; set { {_serialNumber = value;} } }

        /// <summary>Internal Acessors for SignedCertificate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificate { get => (this._signedCertificate = this._signedCertificate ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails()); set { {_signedCertificate = value;} } }

        /// <summary>Internal Acessors for SignedCertificateIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Issuer = value; }

        /// <summary>Internal Acessors for SignedCertificateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).NotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).NotAfter = value; }

        /// <summary>Internal Acessors for SignedCertificateNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).NotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).NotBefore = value; }

        /// <summary>Internal Acessors for SignedCertificateRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).RawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).RawData = value; }

        /// <summary>Internal Acessors for SignedCertificateSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).SerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).SerialNumber = value; }

        /// <summary>Internal Acessors for SignedCertificateSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).SignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).SignatureAlgorithm = value; }

        /// <summary>Internal Acessors for SignedCertificateSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Subject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Subject = value; }

        /// <summary>Internal Acessors for SignedCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Thumbprint = value; }

        /// <summary>Internal Acessors for SignedCertificateVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.SignedCertificateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Version; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Version = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="NextAutoRenewalTimeStamp" /> property.</summary>
        private global::System.DateTime? _nextAutoRenewalTimeStamp;

        /// <summary>Time stamp when the certificate would be auto renewed next</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? NextAutoRenewalTimeStamp { get => this._nextAutoRenewalTimeStamp; }

        /// <summary>Backing field for <see cref="ProductType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType _productType;

        /// <summary>Certificate product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType ProductType { get => this._productType; set => this._productType = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? _provisioningState;

        /// <summary>Status of certificate order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Root" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails _root;

        /// <summary>Root certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Root { get => (this._root = this._root ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails()); }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Issuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RootNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).NotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RootNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).NotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).RawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).SerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).SignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Subject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Thumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? RootVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)Root).Version; }

        /// <summary>Backing field for <see cref="SerialNumber" /> property.</summary>
        private string _serialNumber;

        /// <summary>Current serial number of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SerialNumber { get => this._serialNumber; }

        /// <summary>Backing field for <see cref="SignedCertificate" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails _signedCertificate;

        /// <summary>Signed certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails SignedCertificate { get => (this._signedCertificate = this._signedCertificate ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateDetails()); }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Issuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SignedCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).NotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SignedCertificateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).NotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).RawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).SerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).SignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Subject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Thumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SignedCertificateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetailsInternal)SignedCertificate).Version; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? _status;

        /// <summary>Current order status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Status { get => this._status; }

        /// <summary>Backing field for <see cref="ValidityInYear" /> property.</summary>
        private int? _validityInYear;

        /// <summary>Duration in years (must be between 1 and 3).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ValidityInYear { get => this._validityInYear; set => this._validityInYear = value; }

        /// <summary>Creates an new <see cref="AppServiceCertificateOrderProperties" /> instance.</summary>
        public AppServiceCertificateOrderProperties()
        {

        }
    }
    /// AppServiceCertificateOrder resource specific properties
    public partial interface IAppServiceCertificateOrderProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Reasons why App Service Certificate is not renewable at the current moment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Reasons why App Service Certificate is not renewable at the current moment.",
        SerializedName = @"appServiceCertificateNotRenewableReasons",
        PossibleTypes = new [] { typeof(string) })]
        string[] AppServiceCertificateNotRenewableReason { get;  }
        /// <summary>
        /// <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.",
        SerializedName = @"autoRenew",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AutoRenew { get; set; }
        /// <summary>State of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State of the Key Vault secret.",
        SerializedName = @"certificates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates Certificate { get; set; }
        /// <summary>Last CSR that was created for this order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Last CSR that was created for this order.",
        SerializedName = @"csr",
        PossibleTypes = new [] { typeof(string) })]
        string Csr { get; set; }
        /// <summary>Certificate distinguished name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Certificate distinguished name.",
        SerializedName = @"distinguishedName",
        PossibleTypes = new [] { typeof(string) })]
        string DistinguishedName { get; set; }
        /// <summary>Domain verification token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Domain verification token.",
        SerializedName = @"domainVerificationToken",
        PossibleTypes = new [] { typeof(string) })]
        string DomainVerificationToken { get;  }
        /// <summary>Certificate expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate expiration time.",
        SerializedName = @"expirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? ExpirationTime { get;  }
        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Issuer.",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string IntermediateIssuer { get;  }
        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid to.",
        SerializedName = @"notAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? IntermediateNotAfter { get;  }
        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid from.",
        SerializedName = @"notBefore",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? IntermediateNotBefore { get;  }
        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Raw certificate data.",
        SerializedName = @"rawData",
        PossibleTypes = new [] { typeof(string) })]
        string IntermediateRawData { get;  }
        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Serial Number.",
        SerializedName = @"serialNumber",
        PossibleTypes = new [] { typeof(string) })]
        string IntermediateSerialNumber { get;  }
        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Signature algorithm.",
        SerializedName = @"signatureAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string IntermediateSignatureAlgorithm { get;  }
        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Subject.",
        SerializedName = @"subject",
        PossibleTypes = new [] { typeof(string) })]
        string IntermediateSubject { get;  }
        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Thumbprint.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string IntermediateThumbprint { get;  }
        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? IntermediateVersion { get;  }
        /// <summary><code>true</code> if private key is external; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if private key is external; otherwise, <code>false</code>.",
        SerializedName = @"isPrivateKeyExternal",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsPrivateKeyExternal { get;  }
        /// <summary>Certificate key size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Certificate key size.",
        SerializedName = @"keySize",
        PossibleTypes = new [] { typeof(int) })]
        int? KeySize { get; set; }
        /// <summary>Certificate last issuance time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate last issuance time.",
        SerializedName = @"lastCertificateIssuanceTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastCertificateIssuanceTime { get;  }
        /// <summary>Time stamp when the certificate would be auto renewed next</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Time stamp when the certificate would be auto renewed next",
        SerializedName = @"nextAutoRenewalTimeStamp",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? NextAutoRenewalTimeStamp { get;  }
        /// <summary>Certificate product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Certificate product type.",
        SerializedName = @"productType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType ProductType { get; set; }
        /// <summary>Status of certificate order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Status of certificate order.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Issuer.",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string RootIssuer { get;  }
        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid to.",
        SerializedName = @"notAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RootNotAfter { get;  }
        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid from.",
        SerializedName = @"notBefore",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RootNotBefore { get;  }
        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Raw certificate data.",
        SerializedName = @"rawData",
        PossibleTypes = new [] { typeof(string) })]
        string RootRawData { get;  }
        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Serial Number.",
        SerializedName = @"serialNumber",
        PossibleTypes = new [] { typeof(string) })]
        string RootSerialNumber { get;  }
        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Signature algorithm.",
        SerializedName = @"signatureAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string RootSignatureAlgorithm { get;  }
        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Subject.",
        SerializedName = @"subject",
        PossibleTypes = new [] { typeof(string) })]
        string RootSubject { get;  }
        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Thumbprint.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string RootThumbprint { get;  }
        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? RootVersion { get;  }
        /// <summary>Current serial number of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current serial number of the certificate.",
        SerializedName = @"serialNumber",
        PossibleTypes = new [] { typeof(string) })]
        string SerialNumber { get;  }
        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Issuer.",
        SerializedName = @"issuer",
        PossibleTypes = new [] { typeof(string) })]
        string SignedCertificateIssuer { get;  }
        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid to.",
        SerializedName = @"notAfter",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SignedCertificateNotAfter { get;  }
        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date Certificate is valid from.",
        SerializedName = @"notBefore",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SignedCertificateNotBefore { get;  }
        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Raw certificate data.",
        SerializedName = @"rawData",
        PossibleTypes = new [] { typeof(string) })]
        string SignedCertificateRawData { get;  }
        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Serial Number.",
        SerializedName = @"serialNumber",
        PossibleTypes = new [] { typeof(string) })]
        string SignedCertificateSerialNumber { get;  }
        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Signature algorithm.",
        SerializedName = @"signatureAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string SignedCertificateSignatureAlgorithm { get;  }
        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Subject.",
        SerializedName = @"subject",
        PossibleTypes = new [] { typeof(string) })]
        string SignedCertificateSubject { get;  }
        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Thumbprint.",
        SerializedName = @"thumbprint",
        PossibleTypes = new [] { typeof(string) })]
        string SignedCertificateThumbprint { get;  }
        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Certificate Version.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? SignedCertificateVersion { get;  }
        /// <summary>Current order status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current order status.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Status { get;  }
        /// <summary>Duration in years (must be between 1 and 3).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Duration in years (must be between 1 and 3).",
        SerializedName = @"validityInYears",
        PossibleTypes = new [] { typeof(int) })]
        int? ValidityInYear { get; set; }

    }
    /// AppServiceCertificateOrder resource specific properties
    internal partial interface IAppServiceCertificateOrderPropertiesInternal

    {
        /// <summary>Reasons why App Service Certificate is not renewable at the current moment.</summary>
        string[] AppServiceCertificateNotRenewableReason { get; set; }
        /// <summary>
        /// <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
        /// </summary>
        bool? AutoRenew { get; set; }
        /// <summary>State of the Key Vault secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates Certificate { get; set; }
        /// <summary>Last CSR that was created for this order.</summary>
        string Csr { get; set; }
        /// <summary>Certificate distinguished name.</summary>
        string DistinguishedName { get; set; }
        /// <summary>Domain verification token.</summary>
        string DomainVerificationToken { get; set; }
        /// <summary>Certificate expiration time.</summary>
        global::System.DateTime? ExpirationTime { get; set; }
        /// <summary>Intermediate certificate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Intermediate { get; set; }
        /// <summary>Certificate Issuer.</summary>
        string IntermediateIssuer { get; set; }
        /// <summary>Date Certificate is valid to.</summary>
        global::System.DateTime? IntermediateNotAfter { get; set; }
        /// <summary>Date Certificate is valid from.</summary>
        global::System.DateTime? IntermediateNotBefore { get; set; }
        /// <summary>Raw certificate data.</summary>
        string IntermediateRawData { get; set; }
        /// <summary>Certificate Serial Number.</summary>
        string IntermediateSerialNumber { get; set; }
        /// <summary>Certificate Signature algorithm.</summary>
        string IntermediateSignatureAlgorithm { get; set; }
        /// <summary>Certificate Subject.</summary>
        string IntermediateSubject { get; set; }
        /// <summary>Certificate Thumbprint.</summary>
        string IntermediateThumbprint { get; set; }
        /// <summary>Certificate Version.</summary>
        int? IntermediateVersion { get; set; }
        /// <summary><code>true</code> if private key is external; otherwise, <code>false</code>.</summary>
        bool? IsPrivateKeyExternal { get; set; }
        /// <summary>Certificate key size.</summary>
        int? KeySize { get; set; }
        /// <summary>Certificate last issuance time.</summary>
        global::System.DateTime? LastCertificateIssuanceTime { get; set; }
        /// <summary>Time stamp when the certificate would be auto renewed next</summary>
        global::System.DateTime? NextAutoRenewalTimeStamp { get; set; }
        /// <summary>Certificate product type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType ProductType { get; set; }
        /// <summary>Status of certificate order.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Root certificate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Root { get; set; }
        /// <summary>Certificate Issuer.</summary>
        string RootIssuer { get; set; }
        /// <summary>Date Certificate is valid to.</summary>
        global::System.DateTime? RootNotAfter { get; set; }
        /// <summary>Date Certificate is valid from.</summary>
        global::System.DateTime? RootNotBefore { get; set; }
        /// <summary>Raw certificate data.</summary>
        string RootRawData { get; set; }
        /// <summary>Certificate Serial Number.</summary>
        string RootSerialNumber { get; set; }
        /// <summary>Certificate Signature algorithm.</summary>
        string RootSignatureAlgorithm { get; set; }
        /// <summary>Certificate Subject.</summary>
        string RootSubject { get; set; }
        /// <summary>Certificate Thumbprint.</summary>
        string RootThumbprint { get; set; }
        /// <summary>Certificate Version.</summary>
        int? RootVersion { get; set; }
        /// <summary>Current serial number of the certificate.</summary>
        string SerialNumber { get; set; }
        /// <summary>Signed certificate.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails SignedCertificate { get; set; }
        /// <summary>Certificate Issuer.</summary>
        string SignedCertificateIssuer { get; set; }
        /// <summary>Date Certificate is valid to.</summary>
        global::System.DateTime? SignedCertificateNotAfter { get; set; }
        /// <summary>Date Certificate is valid from.</summary>
        global::System.DateTime? SignedCertificateNotBefore { get; set; }
        /// <summary>Raw certificate data.</summary>
        string SignedCertificateRawData { get; set; }
        /// <summary>Certificate Serial Number.</summary>
        string SignedCertificateSerialNumber { get; set; }
        /// <summary>Certificate Signature algorithm.</summary>
        string SignedCertificateSignatureAlgorithm { get; set; }
        /// <summary>Certificate Subject.</summary>
        string SignedCertificateSubject { get; set; }
        /// <summary>Certificate Thumbprint.</summary>
        string SignedCertificateThumbprint { get; set; }
        /// <summary>Certificate Version.</summary>
        int? SignedCertificateVersion { get; set; }
        /// <summary>Current order status.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Status { get; set; }
        /// <summary>Duration in years (must be between 1 and 3).</summary>
        int? ValidityInYear { get; set; }

    }
}