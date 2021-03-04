namespace Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Extensions;

    /// <summary>Replication protected item</summary>
    public partial class ProtectableItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItem,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.Resource();

        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).CustomDetailInstanceType; }

        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string FriendlyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).FriendlyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).FriendlyName = value ?? null; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; }

        /// <summary>Resource Location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Location = value ?? null; }

        /// <summary>Internal Acessors for CustomDetail</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemInternal.CustomDetail { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).CustomDetail; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).CustomDetail = value; }

        /// <summary>Internal Acessors for CustomDetailInstanceType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemInternal.CustomDetailInstanceType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).CustomDetailInstanceType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).CustomDetailInstanceType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemProperties Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectableItemProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemProperties _property;

        /// <summary>The custom data.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.ProtectableItemProperties()); set => this._property = value; }

        /// <summary>The Current protection readiness errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] ProtectionReadinessError { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).ProtectionReadinessError; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).ProtectionReadinessError = value ?? null /* arrayOf */; }

        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ProtectionStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).ProtectionStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).ProtectionStatus = value ?? null; }

        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string RecoveryServicesProviderId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).RecoveryServicesProviderId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).RecoveryServicesProviderId = value ?? null; }

        /// <summary>The ARM resource of protected items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string ReplicationProtectedItemId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).ReplicationProtectedItemId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).ReplicationProtectedItemId = value ?? null; }

        /// <summary>The list of replication providers supported for the protectable item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inlined)]
        public string[] SupportedReplicationProvider { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).SupportedReplicationProvider; set => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemPropertiesInternal)Property).SupportedReplicationProvider = value ?? null /* arrayOf */; }

        /// <summary>Resource Type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Origin(Microsoft.Azure.PowerShell.Cmdlets.Migrate.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="ProtectableItem" /> instance.</summary>
        public ProtectableItem()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Replication protected item
    public partial interface IProtectableItem :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResource
    {
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the class type. Overridden in derived classes.",
        SerializedName = @"instanceType",
        PossibleTypes = new [] { typeof(string) })]
        string CustomDetailInstanceType { get;  }
        /// <summary>The name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name.",
        SerializedName = @"friendlyName",
        PossibleTypes = new [] { typeof(string) })]
        string FriendlyName { get; set; }
        /// <summary>The Current protection readiness errors.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Current protection readiness errors.",
        SerializedName = @"protectionReadinessErrors",
        PossibleTypes = new [] { typeof(string) })]
        string[] ProtectionReadinessError { get; set; }
        /// <summary>The protection status.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The protection status.",
        SerializedName = @"protectionStatus",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectionStatus { get; set; }
        /// <summary>The recovery provider ARM Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The recovery provider ARM Id.",
        SerializedName = @"recoveryServicesProviderId",
        PossibleTypes = new [] { typeof(string) })]
        string RecoveryServicesProviderId { get; set; }
        /// <summary>The ARM resource of protected items.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ARM resource of protected items.",
        SerializedName = @"replicationProtectedItemId",
        PossibleTypes = new [] { typeof(string) })]
        string ReplicationProtectedItemId { get; set; }
        /// <summary>The list of replication providers supported for the protectable item.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Migrate.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of replication providers supported for the protectable item.",
        SerializedName = @"supportedReplicationProviders",
        PossibleTypes = new [] { typeof(string) })]
        string[] SupportedReplicationProvider { get; set; }

    }
    /// Replication protected item
    internal partial interface IProtectableItemInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IResourceInternal
    {
        /// <summary>The Replication provider custom settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IConfigurationSettings CustomDetail { get; set; }
        /// <summary>Gets the class type. Overridden in derived classes.</summary>
        string CustomDetailInstanceType { get; set; }
        /// <summary>The name.</summary>
        string FriendlyName { get; set; }
        /// <summary>The custom data.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.IProtectableItemProperties Property { get; set; }
        /// <summary>The Current protection readiness errors.</summary>
        string[] ProtectionReadinessError { get; set; }
        /// <summary>The protection status.</summary>
        string ProtectionStatus { get; set; }
        /// <summary>The recovery provider ARM Id.</summary>
        string RecoveryServicesProviderId { get; set; }
        /// <summary>The ARM resource of protected items.</summary>
        string ReplicationProtectedItemId { get; set; }
        /// <summary>The list of replication providers supported for the protectable item.</summary>
        string[] SupportedReplicationProvider { get; set; }

    }
}