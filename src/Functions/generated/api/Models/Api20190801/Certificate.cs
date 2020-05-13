namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SSL certificate for an app.</summary>
    public partial class Certificate :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificate,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Resource();

        /// <summary>CNAME of the certificate to be issued via free certificate</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CanonicalName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).CanonicalName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).CanonicalName = value; }

        /// <summary>Raw bytes of .cer file</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public byte[] CerBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).CerBlob; }

        /// <summary>Certificate expiration date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? ExpirationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).ExpirationDate; }

        /// <summary>Friendly name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).FriendlyName; }

        /// <summary>Host names the certificate applies to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostName = value; }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileId = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileName; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileType; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Certificate issue Date.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? IssueDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).IssueDate; }

        /// <summary>Certificate issuer.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Issuer; }

        /// <summary>Key Vault Csm resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultId = value; }

        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultSecretName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultSecretName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultSecretName = value; }

        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? KeyVaultSecretStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultSecretStatus; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind = value; }

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for CerBlob</summary>
        byte[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.CerBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).CerBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).CerBlob = value; }

        /// <summary>Internal Acessors for ExpirationDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.ExpirationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).ExpirationDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).ExpirationDate = value; }

        /// <summary>Internal Acessors for FriendlyName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).FriendlyName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.HostingEnvironmentProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfile = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).HostingEnvironmentProfileType = value; }

        /// <summary>Internal Acessors for IssueDate</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.IssueDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).IssueDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).IssueDate = value; }

        /// <summary>Internal Acessors for Issuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Issuer = value; }

        /// <summary>Internal Acessors for KeyVaultSecretStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.KeyVaultSecretStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultSecretStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).KeyVaultSecretStatus = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for PublicKeyHash</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.PublicKeyHash { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).PublicKeyHash; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).PublicKeyHash = value; }

        /// <summary>Internal Acessors for SelfLink</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.SelfLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SelfLink; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SelfLink = value; }

        /// <summary>Internal Acessors for SiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.SiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SiteName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SiteName = value; }

        /// <summary>Internal Acessors for SubjectName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.SubjectName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SubjectName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SubjectName = value; }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Thumbprint = value; }

        /// <summary>Internal Acessors for Valid</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateInternal.Valid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Valid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Valid = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Certificate password.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Password { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Password; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Password = value; }

        /// <summary>Pfx blob.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public byte[] PfxBlob { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).PfxBlob; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).PfxBlob = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateProperties _property;

        /// <summary>Certificate resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CertificateProperties()); set => this._property = value; }

        /// <summary>Public key hash.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublicKeyHash { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).PublicKeyHash; }

        /// <summary>Self link.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SelfLink { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SelfLink; }

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ServerFarmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).ServerFarmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).ServerFarmId = value; }

        /// <summary>App name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SiteName; }

        /// <summary>Subject name of the certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SubjectName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).SubjectName; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag = value; }

        /// <summary>Certificate thumbprint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Thumbprint; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Is the certificate valid?.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Valid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificatePropertiesInternal)Property).Valid; }

        /// <summary>Creates an new <see cref="Certificate" /> instance.</summary>
        public Certificate()
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
    /// SSL certificate for an app.
    public partial interface ICertificate :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource
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
    /// SSL certificate for an app.
    internal partial interface ICertificateInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal
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
        /// <summary>Certificate resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICertificateProperties Property { get; set; }
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