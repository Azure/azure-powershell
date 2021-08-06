namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>An Azure resource which represents access to a suite of Maps REST APIs.</summary>
    public partial class MapsAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccount,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.TrackedResource();

        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public bool? DisableLocalAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).DisableLocalAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).DisableLocalAuth = value ?? default(bool); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Id; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? _kind;

        /// <summary>Get or Set Kind property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? Kind { get => this._kind; set => this._kind = value; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal)__trackedResource).Location = value ; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Tier = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal.SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.SystemData()); set { {_systemData = value;} } }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountInternal.UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).UniqueId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).UniqueId = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties _property;

        /// <summary>The map account properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.MapsAccountProperties()); set => this._property = value; }

        /// <summary>the state of the provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).ProvisioningState; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku _sku;

        /// <summary>The SKU of this account.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.Sku()); set => this._sku = value; }

        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Name = value ; }

        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISkuInternal)Sku).Tier; }

        /// <summary>Backing field for <see cref="SystemData" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemData _systemData;

        /// <summary>The system meta data relating to this resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemData SystemData { get => (this._systemData = this._systemData ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.SystemData()); }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).CreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).CreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).CreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).CreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).CreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).CreatedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType)""); }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).LastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).LastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemDataInternal)SystemData).LastModifiedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType)""); }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Type; }

        /// <summary>A unique identifier for the maps account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountPropertiesInternal)Property).UniqueId; }

        /// <summary>Creates an new <see cref="MapsAccount" /> instance.</summary>
        public MapsAccount()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// An Azure resource which represents access to a suite of Maps REST APIs.
    public partial interface IMapsAccount :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResource
    {
        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared Keys authentication from any usage.",
        SerializedName = @"disableLocalAuth",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DisableLocalAuth { get; set; }
        /// <summary>Get or Set Kind property.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Get or Set Kind property.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? Kind { get; set; }
        /// <summary>the state of the provisioning.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"the state of the provisioning.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The name of the SKU, in standard format (such as S0).",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name SkuName { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets the sku tier. This is based on the SKU name.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get;  }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource creation (UTC).",
        SerializedName = @"createdAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that created the resource.",
        SerializedName = @"createdBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that created the resource.",
        SerializedName = @"createdByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timestamp of resource last modification (UTC)",
        SerializedName = @"lastModifiedAt",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identity that last modified the resource.",
        SerializedName = @"lastModifiedBy",
        PossibleTypes = new [] { typeof(string) })]
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of identity that last modified the resource.",
        SerializedName = @"lastModifiedByType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>A unique identifier for the maps account</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A unique identifier for the maps account",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }

    }
    /// An Azure resource which represents access to a suite of Maps REST APIs.
    internal partial interface IMapsAccountInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal
    {
        /// <summary>
        /// Allows toggle functionality on Azure Policy to disable Azure Maps local authentication support. This will disable Shared
        /// Keys authentication from any usage.
        /// </summary>
        bool? DisableLocalAuth { get; set; }
        /// <summary>Get or Set Kind property.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Kind? Kind { get; set; }
        /// <summary>The map account properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.IMapsAccountProperties Property { get; set; }
        /// <summary>the state of the provisioning.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The SKU of this account.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ISku Sku { get; set; }
        /// <summary>The name of the SKU, in standard format (such as S0).</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.Name SkuName { get; set; }
        /// <summary>Gets the sku tier. This is based on the SKU name.</summary>
        string SkuTier { get; set; }
        /// <summary>The system meta data relating to this resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ISystemData SystemData { get; set; }
        /// <summary>The timestamp of resource creation (UTC).</summary>
        global::System.DateTime? SystemDataCreatedAt { get; set; }
        /// <summary>The identity that created the resource.</summary>
        string SystemDataCreatedBy { get; set; }
        /// <summary>The type of identity that created the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType? SystemDataCreatedByType { get; set; }
        /// <summary>The timestamp of resource last modification (UTC)</summary>
        global::System.DateTime? SystemDataLastModifiedAt { get; set; }
        /// <summary>The identity that last modified the resource.</summary>
        string SystemDataLastModifiedBy { get; set; }
        /// <summary>The type of identity that last modified the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.CreatedByType? SystemDataLastModifiedByType { get; set; }
        /// <summary>A unique identifier for the maps account</summary>
        string UniqueId { get; set; }

    }
}