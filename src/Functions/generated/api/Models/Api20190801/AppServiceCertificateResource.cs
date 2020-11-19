namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Key Vault container ARM resource for a certificate that is purchased through Azure.
    /// </summary>
    public partial class AppServiceCertificateResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Resource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; }

        /// <summary>Key Vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).KeyVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).KeyVaultId = value; }

        /// <summary>Key Vault secret name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string KeyVaultSecretName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).KeyVaultSecretName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).KeyVaultSecretName = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind = value; }

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificate()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AppServiceCertificate()); set => this._property = value; }

        /// <summary>Status of the Key Vault secret.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificateInternal)Property).ProvisioningState; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="AppServiceCertificateResource" /> instance.</summary>
        public AppServiceCertificateResource()
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
    /// Key Vault container ARM resource for a certificate that is purchased through Azure.
    public partial interface IAppServiceCertificateResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource
    {
        /// <summary>Key Vault resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Key Vault resource Id.",
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
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? ProvisioningState { get;  }

    }
    /// Key Vault container ARM resource for a certificate that is purchased through Azure.
    internal partial interface IAppServiceCertificateResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal
    {
        /// <summary>Key Vault resource Id.</summary>
        string KeyVaultId { get; set; }
        /// <summary>Key Vault secret name.</summary>
        string KeyVaultSecretName { get; set; }
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAppServiceCertificate Property { get; set; }
        /// <summary>Status of the Key Vault secret.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.KeyVaultSecretStatus? ProvisioningState { get; set; }

    }
}