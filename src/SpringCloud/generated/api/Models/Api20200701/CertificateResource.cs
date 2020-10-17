namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Certificate resource payload.</summary>
    public partial class CertificateResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResource,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.Resource();

        /// <summary>The activate date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ActivateDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).ActivateDate; }

        /// <summary>The certificate version of key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string CertVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).CertVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).CertVersion = value; }

        /// <summary>The domain list of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string[] DnsName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).DnsName; }

        /// <summary>The expiration date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ExpirationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).ExpirationDate; }

        /// <summary>Fully qualified resource Id for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Id; }

        /// <summary>The issue date of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string IssuedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).IssuedDate; }

        /// <summary>The issuer of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).Issuer; }

        /// <summary>The certificate name of key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string KeyVaultCertName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).KeyVaultCertName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).KeyVaultCertName = value; }

        /// <summary>Internal Acessors for ActivateDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.ActivateDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).ActivateDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).ActivateDate = value; }

        /// <summary>Internal Acessors for DnsName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.DnsName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).DnsName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).DnsName = value; }

        /// <summary>Internal Acessors for ExpirationDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.ExpirationDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).ExpirationDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).ExpirationDate = value; }

        /// <summary>Internal Acessors for IssuedDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.IssuedDate { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).IssuedDate; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).IssuedDate = value; }

        /// <summary>Internal Acessors for Issuer</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.Issuer { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).Issuer; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).Issuer = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.CertificateProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for SubjectName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.SubjectName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).SubjectName; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).SubjectName = value; }

        /// <summary>Internal Acessors for Thumbprint</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateResourceInternal.Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).Thumbprint; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).Thumbprint = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateProperties _property;

        /// <summary>Properties of the certificate resource payload.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.CertificateProperties()); set => this._property = value; }

        /// <summary>The subject name of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string SubjectName { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).SubjectName; }

        /// <summary>The thumbprint of certificate.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string Thumbprint { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).Thumbprint; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal)__resource).Type; }

        /// <summary>The vault uri of user key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string VaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).VaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificatePropertiesInternal)Property).VaultUri = value; }

        /// <summary>Creates an new <see cref="CertificateResource" /> instance.</summary>
        public CertificateResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Certificate resource payload.
    public partial interface ICertificateResource :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResource
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
    public partial interface ICertificateResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IResourceInternal
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
        /// <summary>Properties of the certificate resource payload.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ICertificateProperties Property { get; set; }
        /// <summary>The subject name of certificate.</summary>
        string SubjectName { get; set; }
        /// <summary>The thumbprint of certificate.</summary>
        string Thumbprint { get; set; }
        /// <summary>The vault uri of user key vault.</summary>
        string VaultUri { get; set; }

    }
}