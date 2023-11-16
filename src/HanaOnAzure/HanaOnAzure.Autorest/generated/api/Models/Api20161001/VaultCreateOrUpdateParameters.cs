namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Parameters for creating or updating a vault</summary>
    public partial class VaultCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParameters,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal
    {

        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access
        /// policies are required.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).AccessPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).AccessPolicy = value; }

        /// <summary>
        /// The vault's create mode to indicate whether the vault need to be recovered or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? CreateMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).CreateMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).CreateMode = value; }

        /// <summary>
        /// Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates
        /// protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable
        /// deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible -
        /// that is, the property does not accept false as its value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnablePurgeProtection { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnablePurgeProtection; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnablePurgeProtection = value; }

        /// <summary>
        /// Property specifying whether recoverable deletion is enabled for this key vault. Setting this property to true activates
        /// the soft delete feature, whereby vaults or vault entities can be recovered after deletion. Enabling this functionality
        /// is irreversible - that is, the property does not accept false as its value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnableSoftDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnableSoftDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnableSoftDelete = value; }

        /// <summary>
        /// Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key
        /// vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnabledForDeployment { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnabledForDeployment; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnabledForDeployment = value; }

        /// <summary>
        /// Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnabledForDiskEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnabledForDiskEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnabledForDiskEncryption = value; }

        /// <summary>
        /// Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnabledForTemplateDeployment { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnabledForTemplateDeployment; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).EnabledForTemplateDeployment = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The supported Azure location where the key vault should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal.Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).Sku = value; }

        /// <summary>Internal Acessors for SkuFamily</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersInternal.SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).SkuFamily; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).SkuFamily = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties _property;

        /// <summary>Properties of the vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultProperties()); set => this._property = value; }

        /// <summary>SKU family name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).SkuFamily; }

        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).SkuName = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags _tag;

        /// <summary>The tags that will be assigned to the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultCreateOrUpdateParametersTags()); set => this._tag = value; }

        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).TenantId = value; }

        /// <summary>The URI of the vault for performing operations on keys and secrets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string VaultUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).VaultUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPropertiesInternal)Property).VaultUri = value; }

        /// <summary>Creates an new <see cref="VaultCreateOrUpdateParameters" /> instance.</summary>
        public VaultCreateOrUpdateParameters()
        {

        }
    }
    /// Parameters for creating or updating a vault
    public partial interface IVaultCreateOrUpdateParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access
        /// policies are required.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access policies are required.",
        SerializedName = @"accessPolicies",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get; set; }
        /// <summary>
        /// The vault's create mode to indicate whether the vault need to be recovered or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The vault's create mode to indicate whether the vault need to be recovered or not.",
        SerializedName = @"createMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? CreateMode { get; set; }
        /// <summary>
        /// Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates
        /// protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable
        /// deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible -
        /// that is, the property does not accept false as its value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible - that is, the property does not accept false as its value.",
        SerializedName = @"enablePurgeProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnablePurgeProtection { get; set; }
        /// <summary>
        /// Property specifying whether recoverable deletion is enabled for this key vault. Setting this property to true activates
        /// the soft delete feature, whereby vaults or vault entities can be recovered after deletion. Enabling this functionality
        /// is irreversible - that is, the property does not accept false as its value.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property specifying whether recoverable deletion is enabled for this key vault. Setting this property to true activates the soft delete feature, whereby vaults or vault entities can be recovered after deletion. Enabling this functionality is irreversible - that is, the property does not accept false as its value.",
        SerializedName = @"enableSoftDelete",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableSoftDelete { get; set; }
        /// <summary>
        /// Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key
        /// vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key vault.",
        SerializedName = @"enabledForDeployment",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnabledForDeployment { get; set; }
        /// <summary>
        /// Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.",
        SerializedName = @"enabledForDiskEncryption",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnabledForDiskEncryption { get; set; }
        /// <summary>
        /// Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.",
        SerializedName = @"enabledForTemplateDeployment",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnabledForTemplateDeployment { get; set; }
        /// <summary>The supported Azure location where the key vault should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The supported Azure location where the key vault should be created.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>SKU family name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = true,
        Description = @"SKU family name",
        SerializedName = @"family",
        PossibleTypes = new [] { typeof(string) })]
        string SkuFamily { get;  }
        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"SKU name to specify whether the key vault is a standard vault or a premium vault.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get; set; }
        /// <summary>The tags that will be assigned to the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tags that will be assigned to the key vault.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags Tag { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }
        /// <summary>The URI of the vault for performing operations on keys and secrets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URI of the vault for performing operations on keys and secrets.",
        SerializedName = @"vaultUri",
        PossibleTypes = new [] { typeof(string) })]
        string VaultUri { get; set; }

    }
    /// Parameters for creating or updating a vault
    internal partial interface IVaultCreateOrUpdateParametersInternal

    {
        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID. When `createMode` is set to `recover`, access policies are not required. Otherwise, access
        /// policies are required.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get; set; }
        /// <summary>
        /// The vault's create mode to indicate whether the vault need to be recovered or not.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? CreateMode { get; set; }
        /// <summary>
        /// Property specifying whether protection against purge is enabled for this vault. Setting this property to true activates
        /// protection against purge for this vault and its content - only the Key Vault service may initiate a hard, irrecoverable
        /// deletion. The setting is effective only if soft delete is also enabled. Enabling this functionality is irreversible -
        /// that is, the property does not accept false as its value.
        /// </summary>
        bool? EnablePurgeProtection { get; set; }
        /// <summary>
        /// Property specifying whether recoverable deletion is enabled for this key vault. Setting this property to true activates
        /// the soft delete feature, whereby vaults or vault entities can be recovered after deletion. Enabling this functionality
        /// is irreversible - that is, the property does not accept false as its value.
        /// </summary>
        bool? EnableSoftDelete { get; set; }
        /// <summary>
        /// Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key
        /// vault.
        /// </summary>
        bool? EnabledForDeployment { get; set; }
        /// <summary>
        /// Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        bool? EnabledForDiskEncryption { get; set; }
        /// <summary>
        /// Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
        /// </summary>
        bool? EnabledForTemplateDeployment { get; set; }
        /// <summary>The supported Azure location where the key vault should be created.</summary>
        string Location { get; set; }
        /// <summary>Properties of the vault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultProperties Property { get; set; }
        /// <summary>SKU details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Sku { get; set; }
        /// <summary>SKU family name</summary>
        string SkuFamily { get; set; }
        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get; set; }
        /// <summary>The tags that will be assigned to the key vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultCreateOrUpdateParametersTags Tag { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        string TenantId { get; set; }
        /// <summary>The URI of the vault for performing operations on keys and secrets.</summary>
        string VaultUri { get; set; }

    }
}