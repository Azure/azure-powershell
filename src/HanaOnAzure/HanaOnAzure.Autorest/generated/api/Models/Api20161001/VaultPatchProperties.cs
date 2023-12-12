namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    /// <summary>Properties of the vault</summary>
    public partial class VaultPatchProperties :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchProperties,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AccessPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] _accessPolicy;

        /// <summary>
        /// An array of 0 to 16 identities that have access to the key vault. All identities in the array must use the same tenant
        /// ID as the key vault's tenant ID.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IAccessPolicyEntry[] AccessPolicy { get => this._accessPolicy; set => this._accessPolicy = value; }

        /// <summary>Backing field for <see cref="CreateMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? _createMode;

        /// <summary>
        /// The vault's create mode to indicate whether the vault need to be recovered or not.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.CreateMode? CreateMode { get => this._createMode; set => this._createMode = value; }

        /// <summary>Backing field for <see cref="EnablePurgeProtection" /> property.</summary>
        private bool? _enablePurgeProtection;

        /// <summary>
        /// Property specifying whether protection against purge is enabled for this vault; it is only effective if soft delete is
        /// also enabled. Once activated, the property may no longer be reset to false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? EnablePurgeProtection { get => this._enablePurgeProtection; set => this._enablePurgeProtection = value; }

        /// <summary>Backing field for <see cref="EnableSoftDelete" /> property.</summary>
        private bool? _enableSoftDelete;

        /// <summary>
        /// Property specifying whether recoverable deletion ('soft' delete) is enabled for this key vault. The property may not be
        /// set to false.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? EnableSoftDelete { get => this._enableSoftDelete; set => this._enableSoftDelete = value; }

        /// <summary>Backing field for <see cref="EnabledForDeployment" /> property.</summary>
        private bool? _enabledForDeployment;

        /// <summary>
        /// Property to specify whether Azure Virtual Machines are permitted to retrieve certificates stored as secrets from the key
        /// vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? EnabledForDeployment { get => this._enabledForDeployment; set => this._enabledForDeployment = value; }

        /// <summary>Backing field for <see cref="EnabledForDiskEncryption" /> property.</summary>
        private bool? _enabledForDiskEncryption;

        /// <summary>
        /// Property to specify whether Azure Disk Encryption is permitted to retrieve secrets from the vault and unwrap keys.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? EnabledForDiskEncryption { get => this._enabledForDiskEncryption; set => this._enabledForDiskEncryption = value; }

        /// <summary>Backing field for <see cref="EnabledForTemplateDeployment" /> property.</summary>
        private bool? _enabledForTemplateDeployment;

        /// <summary>
        /// Property to specify whether Azure Resource Manager is permitted to retrieve secrets from the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public bool? EnabledForTemplateDeployment { get => this._enabledForTemplateDeployment; set => this._enabledForTemplateDeployment = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuFamily</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IVaultPatchPropertiesInternal.SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal)Sku).Family; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal)Sku).Family = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku _sku;

        /// <summary>SKU details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.Sku()); set => this._sku = value; }

        /// <summary>SKU family name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public string SkuFamily { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal)Sku).Family; }

        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISkuInternal)Sku).Name = value; }

        /// <summary>Backing field for <see cref="TenantId" /> property.</summary>
        private string _tenantId;

        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string TenantId { get => this._tenantId; set => this._tenantId = value; }

        /// <summary>Creates an new <see cref="VaultPatchProperties" /> instance.</summary>
        public VaultPatchProperties()
        {

        }
    }
    /// Properties of the vault
    public partial interface IVaultPatchProperties :
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
    /// Properties of the vault
    internal partial interface IVaultPatchPropertiesInternal

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
        /// <summary>SKU details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ISku Sku { get; set; }
        /// <summary>SKU family name</summary>
        string SkuFamily { get; set; }
        /// <summary>
        /// SKU name to specify whether the key vault is a standard vault or a premium vault.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Support.SkuName SkuName { get; set; }
        /// <summary>
        /// The Azure Active Directory tenant ID that should be used for authenticating requests to the key vault.
        /// </summary>
        string TenantId { get; set; }

    }
}