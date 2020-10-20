namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SSL certificate purchase order.</summary>
    public partial class AppServiceCertificateOrder :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrder,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Resource();

        /// <summary>Reasons why App Service Certificate is not renewable at the current moment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AppServiceCertificateNotRenewableReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).AppServiceCertificateNotRenewableReason; }

        /// <summary>
        /// <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).AutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).AutoRenew = value; }

        /// <summary>State of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesCertificates Certificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Certificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Certificate = value; }

        /// <summary>Last CSR that was created for this order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Csr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Csr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Csr = value; }

        /// <summary>Certificate distinguished name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DistinguishedName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).DistinguishedName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).DistinguishedName = value; }

        /// <summary>Domain verification token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DomainVerificationToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).DomainVerificationToken; }

        /// <summary>Certificate expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ExpirationTime; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateIssuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IntermediateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateNotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IntermediateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateNotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateRawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSubject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateThumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? IntermediateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateVersion; }

        /// <summary><code>true</code> if private key is external; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsPrivateKeyExternal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IsPrivateKeyExternal; }

        /// <summary>Certificate key size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? KeySize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).KeySize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).KeySize = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind = value; }

        /// <summary>Certificate last issuance time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastCertificateIssuanceTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).LastCertificateIssuanceTime; }

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for AppServiceCertificateNotRenewableReason</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.AppServiceCertificateNotRenewableReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).AppServiceCertificateNotRenewableReason; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).AppServiceCertificateNotRenewableReason = value; }

        /// <summary>Internal Acessors for DomainVerificationToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.DomainVerificationToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).DomainVerificationToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).DomainVerificationToken = value; }

        /// <summary>Internal Acessors for ExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.ExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ExpirationTime = value; }

        /// <summary>Internal Acessors for Intermediate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.Intermediate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Intermediate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Intermediate = value; }

        /// <summary>Internal Acessors for IntermediateIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateIssuer = value; }

        /// <summary>Internal Acessors for IntermediateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateNotAfter = value; }

        /// <summary>Internal Acessors for IntermediateNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateNotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateNotBefore = value; }

        /// <summary>Internal Acessors for IntermediateRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateRawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateRawData = value; }

        /// <summary>Internal Acessors for IntermediateSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSerialNumber = value; }

        /// <summary>Internal Acessors for IntermediateSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSignatureAlgorithm = value; }

        /// <summary>Internal Acessors for IntermediateSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSubject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateSubject = value; }

        /// <summary>Internal Acessors for IntermediateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateThumbprint = value; }

        /// <summary>Internal Acessors for IntermediateVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IntermediateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IntermediateVersion = value; }

        /// <summary>Internal Acessors for IsPrivateKeyExternal</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.IsPrivateKeyExternal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IsPrivateKeyExternal; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).IsPrivateKeyExternal = value; }

        /// <summary>Internal Acessors for LastCertificateIssuanceTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.LastCertificateIssuanceTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).LastCertificateIssuanceTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).LastCertificateIssuanceTime = value; }

        /// <summary>Internal Acessors for NextAutoRenewalTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.NextAutoRenewalTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).NextAutoRenewalTimeStamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).NextAutoRenewalTimeStamp = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificateOrderProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Root</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.Root { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Root; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Root = value; }

        /// <summary>Internal Acessors for RootIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootIssuer = value; }

        /// <summary>Internal Acessors for RootNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootNotAfter = value; }

        /// <summary>Internal Acessors for RootNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootNotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootNotBefore = value; }

        /// <summary>Internal Acessors for RootRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootRawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootRawData = value; }

        /// <summary>Internal Acessors for RootSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSerialNumber = value; }

        /// <summary>Internal Acessors for RootSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSignatureAlgorithm = value; }

        /// <summary>Internal Acessors for RootSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSubject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSubject = value; }

        /// <summary>Internal Acessors for RootThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootThumbprint = value; }

        /// <summary>Internal Acessors for RootVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.RootVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootVersion = value; }

        /// <summary>Internal Acessors for SerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SerialNumber = value; }

        /// <summary>Internal Acessors for SignedCertificate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificate = value; }

        /// <summary>Internal Acessors for SignedCertificateIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateIssuer = value; }

        /// <summary>Internal Acessors for SignedCertificateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateNotAfter = value; }

        /// <summary>Internal Acessors for SignedCertificateNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateNotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateNotBefore = value; }

        /// <summary>Internal Acessors for SignedCertificateRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateRawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateRawData = value; }

        /// <summary>Internal Acessors for SignedCertificateSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSerialNumber = value; }

        /// <summary>Internal Acessors for SignedCertificateSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSignatureAlgorithm = value; }

        /// <summary>Internal Acessors for SignedCertificateSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSubject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSubject = value; }

        /// <summary>Internal Acessors for SignedCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateThumbprint = value; }

        /// <summary>Internal Acessors for SignedCertificateVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.SignedCertificateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateVersion = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; }

        /// <summary>Time stamp when the certificate would be auto renewed next</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? NextAutoRenewalTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).NextAutoRenewalTimeStamp; }

        /// <summary>Certificate product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType ProductType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ProductType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ProductType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderProperties _property;

        /// <summary>AppServiceCertificateOrder resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificateOrderProperties()); set => this._property = value; }

        /// <summary>Status of certificate order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootIssuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RootNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootNotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RootNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootNotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootRawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootSubject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootThumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? RootVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).RootVersion; }

        /// <summary>Current serial number of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SerialNumber; }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateIssuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SignedCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateNotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SignedCertificateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateNotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateRawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateSubject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateThumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SignedCertificateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).SignedCertificateVersion; }

        /// <summary>Current order status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).Status; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; }

        /// <summary>Duration in years (must be between 1 and 3).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ValidityInYear { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ValidityInYear; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPropertiesInternal)Property).ValidityInYear = value; }

        /// <summary>Creates an new <see cref="AppServiceCertificateOrder" /> instance.</summary>
        public AppServiceCertificateOrder()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// SSL certificate purchase order.
    public partial interface IAppServiceCertificateOrder :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource
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
    /// SSL certificate purchase order.
    internal partial interface IAppServiceCertificateOrderInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal
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
        /// <summary>AppServiceCertificateOrder resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderProperties Property { get; set; }
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