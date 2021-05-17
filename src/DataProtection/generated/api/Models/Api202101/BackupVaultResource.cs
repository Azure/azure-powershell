namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Backup Vault Resource</summary>
    public partial class BackupVaultResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResource,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResource __dppTrackedResource = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.DppTrackedResource();

        /// <summary>Optional ETag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public string ETag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).ETag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).ETag = value ?? null; }

        /// <summary>Resource Id represents the complete path to the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Id; }

        /// <summary>Input Managed Identity Details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppIdentityDetails Identity { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Identity; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Identity = value ?? null /* model class */; }

        /// <summary>
        /// The object ID of the service principal object for the managed identity that is used to grant role-based access to an Azure
        /// resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityPrincipalId; }

        /// <summary>
        /// A Globally Unique Identifier (GUID) that represents the Azure AD tenant where the resource is now a member.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityTenantId; }

        /// <summary>The identityType which can be either SystemAssigned or None</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.FormatTable(Index = 3)]
        public string IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityType = value ?? null; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.FormatTable(Index = 1)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Location = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVault Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupVault()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultResourceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Id = value; }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityPrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityPrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityTenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).IdentityTenantId = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISystemData Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Type = value; }

        /// <summary>Resource name associated with the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.FormatTable(Index = 0)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVault _property;

        /// <summary>BackupVaultResource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVault Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.BackupVault()); set => this._property = value; }

        /// <summary>Provisioning state of the BackupVault resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal)Property).ProvisioningState; }

        /// <summary>Storage Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] StorageSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal)Property).StorageSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVaultInternal)Property).StorageSetting = value ; }

        /// <summary>Metadata pertaining to creation and last modification of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).SystemData; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// Resource type represents the complete path of the form Namespace/ResourceType/ResourceType/...
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.FormatTable(Index = 2)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal)__dppTrackedResource).Type; }

        /// <summary>Creates an new <see cref="BackupVaultResource" /> instance.</summary>
        public BackupVaultResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__dppTrackedResource), __dppTrackedResource);
            await eventListener.AssertObjectIsValid(nameof(__dppTrackedResource), __dppTrackedResource);
        }
    }
    /// Backup Vault Resource
    public partial interface IBackupVaultResource :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResource
    {
        /// <summary>Provisioning state of the BackupVault resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the BackupVault resource",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>Storage Settings</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Storage Settings",
        SerializedName = @"storageSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting) })]
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] StorageSetting { get; set; }

    }
    /// Backup Vault Resource
    internal partial interface IBackupVaultResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IDppTrackedResourceInternal
    {
        /// <summary>BackupVaultResource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupVault Property { get; set; }
        /// <summary>Provisioning state of the BackupVault resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>Storage Settings</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[] StorageSetting { get; set; }

    }
}