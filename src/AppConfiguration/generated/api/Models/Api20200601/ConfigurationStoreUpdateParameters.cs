namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>The parameters for updating a configuration store.</summary>
    public partial class ConfigurationStoreUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal
    {

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity _identity;

        /// <summary>The managed identity information for the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentity()); set => this._identity = value; }

        /// <summary>
        /// The principal id of the identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).PrincipalId; }

        /// <summary>
        /// The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).TenantId; }

        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).Type = value; }

        /// <summary>
        /// The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).UserAssignedIdentity = value; }

        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyIdentityClientId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).KeyVaultPropertyIdentityClientId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).KeyVaultPropertyIdentityClientId = value; }

        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string KeyVaultPropertyKeyIdentifier { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyIdentifier; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).KeyVaultPropertyKeyIdentifier = value; }

        /// <summary>Internal Acessors for Encryption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.Encryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).Encryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).Encryption = value; }

        /// <summary>Internal Acessors for EncryptionKeyVaultProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.EncryptionKeyVaultProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).EncryptionKeyVaultProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParametersInternal)Property).EncryptionKeyVaultProperty = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ResourceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParameters Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStorePropertiesUpdateParameters()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISku Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.Sku()); set { {_sku = value;} } }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParameters _property;

        /// <summary>The properties for updating a configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParameters Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStorePropertiesUpdateParameters()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISku _sku;

        /// <summary>The SKU of the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.Sku()); set => this._sku = value; }

        /// <summary>The SKU name of the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISkuInternal)Sku).Name = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags _tag;

        /// <summary>The ARM resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ConfigurationStoreUpdateParametersTags()); set => this._tag = value; }

        /// <summary>Creates an new <see cref="ConfigurationStoreUpdateParameters" /> instance.</summary>
        public ConfigurationStoreUpdateParameters()
        {

        }
    }
    /// The parameters for updating a configuration store.
    public partial interface IConfigurationStoreUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The principal id of the identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principal id of the identity. This property will only be provided for a system-assigned identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>
        /// The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identities.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user-assigned identities. The type 'None' will remove any identities.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The client id of the identity which will be used to access key vault.",
        SerializedName = @"identityClientId",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyIdentityClientId { get; set; }
        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the key vault key used to encrypt data.",
        SerializedName = @"keyIdentifier",
        PossibleTypes = new [] { typeof(string) })]
        string KeyVaultPropertyKeyIdentifier { get; set; }
        /// <summary>The SKU name of the configuration store.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The SKU name of the configuration store.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>The ARM resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags Tag { get; set; }

    }
    /// The parameters for updating a configuration store.
    internal partial interface IConfigurationStoreUpdateParametersInternal

    {
        /// <summary>The encryption settings of the configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IEncryptionProperties Encryption { get; set; }
        /// <summary>Key vault properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IKeyVaultProperties EncryptionKeyVaultProperty { get; set; }
        /// <summary>The managed identity information for the configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentity Identity { get; set; }
        /// <summary>
        /// The principal id of the identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>
        /// The tenant id associated with the resource's identity. This property will only be provided for a system-assigned identity.
        /// </summary>
        string IdentityTenantId { get; set; }
        /// <summary>
        /// The type of managed identity used. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity
        /// and a set of user-assigned identities. The type 'None' will remove any identities.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Support.IdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user-assigned identities associated with the resource. The user-assigned identity dictionary keys will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IResourceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
        /// <summary>The client id of the identity which will be used to access key vault.</summary>
        string KeyVaultPropertyIdentityClientId { get; set; }
        /// <summary>The URI of the key vault key used to encrypt data.</summary>
        string KeyVaultPropertyKeyIdentifier { get; set; }
        /// <summary>The properties for updating a configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStorePropertiesUpdateParameters Property { get; set; }
        /// <summary>The SKU of the configuration store.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.ISku Sku { get; set; }
        /// <summary>The SKU name of the configuration store.</summary>
        string SkuName { get; set; }
        /// <summary>The ARM resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api20200601.IConfigurationStoreUpdateParametersTags Tag { get; set; }

    }
}