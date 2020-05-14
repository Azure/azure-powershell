namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ARM resource for a certificate order that is purchased through Azure.</summary>
    public partial class AppServiceCertificateOrderPatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>Reasons why App Service Certificate is not renewable at the current moment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] AppServiceCertificateNotRenewableReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).AppServiceCertificateNotRenewableReason; }

        /// <summary>
        /// <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AutoRenew { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).AutoRenew; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).AutoRenew = value; }

        /// <summary>State of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesCertificates Certificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Certificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Certificate = value; }

        /// <summary>Last CSR that was created for this order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Csr { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Csr; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Csr = value; }

        /// <summary>Certificate distinguished name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DistinguishedName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).DistinguishedName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).DistinguishedName = value; }

        /// <summary>Domain verification token.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DomainVerificationToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).DomainVerificationToken; }

        /// <summary>Certificate expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ExpirationTime; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateIssuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IntermediateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateNotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IntermediateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateNotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateRawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSubject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IntermediateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateThumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? IntermediateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateVersion; }

        /// <summary><code>true</code> if private key is external; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsPrivateKeyExternal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IsPrivateKeyExternal; }

        /// <summary>Certificate key size.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? KeySize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).KeySize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).KeySize = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Certificate last issuance time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastCertificateIssuanceTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).LastCertificateIssuanceTime; }

        /// <summary>Internal Acessors for AppServiceCertificateNotRenewableReason</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.AppServiceCertificateNotRenewableReason { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).AppServiceCertificateNotRenewableReason; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).AppServiceCertificateNotRenewableReason = value; }

        /// <summary>Internal Acessors for DomainVerificationToken</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.DomainVerificationToken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).DomainVerificationToken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).DomainVerificationToken = value; }

        /// <summary>Internal Acessors for ExpirationTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.ExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ExpirationTime = value; }

        /// <summary>Internal Acessors for Intermediate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.Intermediate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Intermediate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Intermediate = value; }

        /// <summary>Internal Acessors for IntermediateIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateIssuer = value; }

        /// <summary>Internal Acessors for IntermediateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateNotAfter = value; }

        /// <summary>Internal Acessors for IntermediateNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateNotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateNotBefore = value; }

        /// <summary>Internal Acessors for IntermediateRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateRawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateRawData = value; }

        /// <summary>Internal Acessors for IntermediateSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSerialNumber = value; }

        /// <summary>Internal Acessors for IntermediateSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSignatureAlgorithm = value; }

        /// <summary>Internal Acessors for IntermediateSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSubject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateSubject = value; }

        /// <summary>Internal Acessors for IntermediateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateThumbprint = value; }

        /// <summary>Internal Acessors for IntermediateVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IntermediateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IntermediateVersion = value; }

        /// <summary>Internal Acessors for IsPrivateKeyExternal</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.IsPrivateKeyExternal { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IsPrivateKeyExternal; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).IsPrivateKeyExternal = value; }

        /// <summary>Internal Acessors for LastCertificateIssuanceTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.LastCertificateIssuanceTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).LastCertificateIssuanceTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).LastCertificateIssuanceTime = value; }

        /// <summary>Internal Acessors for NextAutoRenewalTimeStamp</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.NextAutoRenewalTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).NextAutoRenewalTimeStamp; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).NextAutoRenewalTimeStamp = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificateOrderPatchResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Root</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.Root { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Root; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Root = value; }

        /// <summary>Internal Acessors for RootIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootIssuer = value; }

        /// <summary>Internal Acessors for RootNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootNotAfter = value; }

        /// <summary>Internal Acessors for RootNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootNotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootNotBefore = value; }

        /// <summary>Internal Acessors for RootRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootRawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootRawData = value; }

        /// <summary>Internal Acessors for RootSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSerialNumber = value; }

        /// <summary>Internal Acessors for RootSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSignatureAlgorithm = value; }

        /// <summary>Internal Acessors for RootSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSubject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSubject = value; }

        /// <summary>Internal Acessors for RootThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootThumbprint = value; }

        /// <summary>Internal Acessors for RootVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.RootVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootVersion = value; }

        /// <summary>Internal Acessors for SerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SerialNumber = value; }

        /// <summary>Internal Acessors for SignedCertificate</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateDetails Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificate = value; }

        /// <summary>Internal Acessors for SignedCertificateIssuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateIssuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateIssuer = value; }

        /// <summary>Internal Acessors for SignedCertificateNotAfter</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateNotAfter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateNotAfter = value; }

        /// <summary>Internal Acessors for SignedCertificateNotBefore</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateNotBefore; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateNotBefore = value; }

        /// <summary>Internal Acessors for SignedCertificateRawData</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateRawData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateRawData = value; }

        /// <summary>Internal Acessors for SignedCertificateSerialNumber</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSerialNumber; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSerialNumber = value; }

        /// <summary>Internal Acessors for SignedCertificateSignatureAlgorithm</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSignatureAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSignatureAlgorithm = value; }

        /// <summary>Internal Acessors for SignedCertificateSubject</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSubject; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSubject = value; }

        /// <summary>Internal Acessors for SignedCertificateThumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateThumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateThumbprint = value; }

        /// <summary>Internal Acessors for SignedCertificateVersion</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.SignedCertificateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateVersion = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Time stamp when the certificate would be auto renewed next</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? NextAutoRenewalTimeStamp { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).NextAutoRenewalTimeStamp; }

        /// <summary>Certificate product type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateProductType ProductType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ProductType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ProductType = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties _property;

        /// <summary>AppServiceCertificateOrderPatchResource resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificateOrderPatchResourceProperties()); set => this._property = value; }

        /// <summary>Status of certificate order.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootIssuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RootNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootNotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RootNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootNotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootRawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootSubject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RootThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootThumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? RootVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).RootVersion; }

        /// <summary>Current serial number of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SerialNumber; }

        /// <summary>Certificate Issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateIssuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateIssuer; }

        /// <summary>Date Certificate is valid to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SignedCertificateNotAfter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateNotAfter; }

        /// <summary>Date Certificate is valid from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SignedCertificateNotBefore { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateNotBefore; }

        /// <summary>Raw certificate data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateRawData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateRawData; }

        /// <summary>Certificate Serial Number.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSerialNumber { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSerialNumber; }

        /// <summary>Certificate Signature algorithm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSignatureAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSignatureAlgorithm; }

        /// <summary>Certificate Subject.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateSubject { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateSubject; }

        /// <summary>Certificate Thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SignedCertificateThumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateThumbprint; }

        /// <summary>Certificate Version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SignedCertificateVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).SignedCertificateVersion; }

        /// <summary>Current order status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.CertificateOrderStatus? Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).Status; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Duration in years (must be between 1 and 3).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ValidityInYear { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ValidityInYear; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesInternal)Property).ValidityInYear = value; }

        /// <summary>Creates an new <see cref="AppServiceCertificateOrderPatchResource" /> instance.</summary>
        public AppServiceCertificateOrderPatchResource()
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
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// ARM resource for a certificate order that is purchased through Azure.
    public partial interface IAppServiceCertificateOrderPatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesCertificates) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesCertificates Certificate { get; set; }
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
    /// ARM resource for a certificate order that is purchased through Azure.
    internal partial interface IAppServiceCertificateOrderPatchResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
    {
        /// <summary>Reasons why App Service Certificate is not renewable at the current moment.</summary>
        string[] AppServiceCertificateNotRenewableReason { get; set; }
        /// <summary>
        /// <code>true</code> if the certificate should be automatically renewed when it expires; otherwise, <code>false</code>.
        /// </summary>
        bool? AutoRenew { get; set; }
        /// <summary>State of the Key Vault secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourcePropertiesCertificates Certificate { get; set; }
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
        /// <summary>AppServiceCertificateOrderPatchResource resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateOrderPatchResourceProperties Property { get; set; }
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