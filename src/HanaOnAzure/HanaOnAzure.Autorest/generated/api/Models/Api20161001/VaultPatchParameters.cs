namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Parameters for creating or updating a vault</summary>
    public partial class VaultPatchParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParameters,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersInternal
    {

        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).AccessPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).AccessPolicy = value; }

        /// <summary>
        /// The vault's create mode to indicate whether the vault need to be recovered or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? CreateMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).CreateMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).CreateMode = value; }

        /// <summary>
        /// Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is
        /// also enabled. Once activated, the property may no longer be reset to false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnablePurgeProtection { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnablePurgeProtection; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnablePurgeProtection = value; }

        /// <summary>
        /// Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault. The property may not be
        /// set to false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnableSoftDelete { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnableSoftDelete; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnableSoftDelete = value; }

        /// <summary>
        /// Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key
        /// vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnabledForDeployment { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnabledForDeployment; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnabledForDeployment = value; }

        /// <summary>
        /// Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnabledForDiskEncryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnabledForDiskEncryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnabledForDiskEncryption = value; }

        /// <summary>
        /// Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public bool? EnabledForTemplateDeployment { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnabledForTemplateDeployment; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).EnabledForTemplateDeployment = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchProperties Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultPatchProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersInternal.Sku { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).Sku; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).Sku = value; }

        /// <summary>Internal Acessors for SkuFamily</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersInternal.SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).SkuFamily; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).SkuFamily = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchProperties _property;

        /// <summary>Properties of the vault</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultPatchProperties()); set => this._property = value; }

        /// <summary>SKU family name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).SkuFamily; }

        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).SkuName; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).SkuName = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTags _tag;

        /// <summary>The tags that will be assigned to the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.VaultPatchParametersTags()); set => this._tag = value; }

        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string TenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal)Property).TenantId = value; }

        /// <summary>Creates an new <see cref="VaultPatchParameters" /> instance.</summary>
        public VaultPatchParameters()
        {

        }
    }
    /// Parameters for creating or updating a vault
    public partial interface IVaultPatchParameters :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable
    {
        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant ID as the key vault's tenant ID.",
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
        /// Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is
        /// also enabled. Once activated, the property may no longer be reset to false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is also enabled. Once activated, the property may no longer be reset to false.",
        SerializedName = @"enablePurgeProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnablePurgeProtection { get; set; }
        /// <summary>
        /// Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault. The property may not be
        /// set to false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault. The property may not be set to false.",
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
        Description = @"The tags that will be assigned to the key vault. ",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTags Tag { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string TenantId { get; set; }

    }
    /// Parameters for creating or updating a vault
    internal partial interface IVaultPatchParametersInternal

    {
        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get; set; }
        /// <summary>
        /// The vault's create mode to indicate whether the vault need to be recovered or not.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? CreateMode { get; set; }
        /// <summary>
        /// Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is
        /// also enabled. Once activated, the property may no longer be reset to false.
        /// </summary>
        bool? EnablePurgeProtection { get; set; }
        /// <summary>
        /// Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault. The property may not be
        /// set to false.
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
        /// <summary>Properties of the vault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchProperties Property { get; set; }
        /// <summary>SKU details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Sku { get; set; }
        /// <summary>SKU family name</summary>
        string SkuFamily { get; set; }
        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get; set; }
        /// <summary>The tags that will be assigned to the key vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchParametersTags Tag { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        string TenantId { get; set; }

    }
}