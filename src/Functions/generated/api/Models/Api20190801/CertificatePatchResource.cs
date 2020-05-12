namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>ARM resource for a certificate.</summary>
    public partial class CertificatePatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>CNAME of the certificate to be issued via free certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CanonicalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).CanonicalName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).CanonicalName = value; }

        /// <summary>Raw bytes of .cer file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public byte[] CerBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).CerBlob; }

        /// <summary>Certificate expiration date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ExpirationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).ExpirationDate; }

        /// <summary>Friendly name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).FriendlyName; }

        /// <summary>Host names the certificate applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostName = value; }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileId = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileName; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileType; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Certificate issue Date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IssueDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).IssueDate; }

        /// <summary>Certificate issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Issuer; }

        /// <summary>Key Vault Csm resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultId = value; }

        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultSecretName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultSecretName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultSecretName = value; }

        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? KeyVaultSecretStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultSecretStatus; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Internal Acessors for CerBlob</summary>
        byte[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.CerBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).CerBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).CerBlob = value; }

        /// <summary>Internal Acessors for ExpirationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.ExpirationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).ExpirationDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).ExpirationDate = value; }

        /// <summary>Internal Acessors for FriendlyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).FriendlyName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.HostingEnvironmentProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfile = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).HostingEnvironmentProfileType = value; }

        /// <summary>Internal Acessors for IssueDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.IssueDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).IssueDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).IssueDate = value; }

        /// <summary>Internal Acessors for Issuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Issuer = value; }

        /// <summary>Internal Acessors for KeyVaultSecretStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.KeyVaultSecretStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultSecretStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).KeyVaultSecretStatus = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificatePatchResourceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PublicKeyHash</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.PublicKeyHash { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).PublicKeyHash; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).PublicKeyHash = value; }

        /// <summary>Internal Acessors for SelfLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.SelfLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SelfLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SelfLink = value; }

        /// <summary>Internal Acessors for SiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.SiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SiteName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SiteName = value; }

        /// <summary>Internal Acessors for SubjectName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.SubjectName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SubjectName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SubjectName = value; }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Thumbprint = value; }

        /// <summary>Internal Acessors for Valid</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceInternal.Valid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Valid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Valid = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>Certificate password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Password = value; }

        /// <summary>Pfx blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public byte[] PfxBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).PfxBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).PfxBlob = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceProperties _property;

        /// <summary>CertificatePatchResource resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificatePatchResourceProperties()); set => this._property = value; }

        /// <summary>Public key hash.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublicKeyHash { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).PublicKeyHash; }

        /// <summary>Self link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SelfLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SelfLink; }

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ServerFarmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).ServerFarmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).ServerFarmId = value; }

        /// <summary>App name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SiteName; }

        /// <summary>Subject name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SubjectName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).SubjectName; }

        /// <summary>Certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Thumbprint; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary>Is the certificate valid?.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Valid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourcePropertiesInternal)Property).Valid; }

        /// <summary>Creates an new <see cref="CertificatePatchResource" /> instance.</summary>
        public CertificatePatchResource()
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
    /// ARM resource for a certificate.
    public partial interface ICertificatePatchResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// ARM resource for a certificate.
    internal partial interface ICertificatePatchResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>CertificatePatchResource resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePatchResourceProperties Property { get; set; }
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