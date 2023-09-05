namespace Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Extensions;

    /// <summary>The storage container resource definition.</summary>
    public partial class StorageContainers :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainers,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainersInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.TrackedResource();

        /// <summary>Backing field for <see cref="ExtendedLocation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation _extendedLocation;

        /// <summary>The extendedLocation of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation ExtendedLocation { get => (this._extendedLocation = this._extendedLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ExtendedLocation()); set => this._extendedLocation = value; }

        /// <summary>The name of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ExtendedLocationName { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Name = value ?? null; }

        /// <summary>The type of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes? ExtendedLocationType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocationInternal)ExtendedLocation).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes)""); }

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Id; }

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Location = value; }

        /// <summary>Internal Acessors for ExtendedLocation</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainersInternal.ExtendedLocation { get => (this._extendedLocation = this._extendedLocation ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.ExtendedLocation()); set { {_extendedLocation = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerProperties Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainersInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageContainerProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainersInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainersInternal.Status { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).Status; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).Status = value; }

        /// <summary>Internal Acessors for StatusProvisioningStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerStatusProvisioningStatus Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainersInternal.StatusProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusProvisioningStatus = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ISystemData Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Name; }

        /// <summary>Path of the storage container on the disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string Path { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).Path; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).Path = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerProperties _property;

        /// <summary>Properties under the storage container resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.StorageContainerProperties()); set => this._property = value; }

        /// <summary>Provisioning state of the storage container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningState; }

        /// <summary>
        /// The status of the operation performed on the storage container [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningStatus = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status)""); }

        /// <summary>The ID of the operation performed on the storage container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string ProvisioningStatusOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningStatusOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).ProvisioningStatusOperationId = value ?? null; }

        /// <summary>Amount of space available on the disk in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? StatusAvailableSizeMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusAvailableSizeMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusAvailableSizeMb = value ?? default(long); }

        /// <summary>Total size of the disk in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public long? StatusContainerSizeMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusContainerSizeMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusContainerSizeMb = value ?? default(long); }

        /// <summary>StorageContainer provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusErrorCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusErrorCode = value ?? null; }

        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inlined)]
        public string StatusErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusErrorMessage; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerPropertiesInternal)Property).StatusErrorMessage = value ?? null; }

        /// <summary>
        /// Azure Resource Manager metadata containing createdBy and modifiedBy information.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemData; }

        /// <summary>The timestamp of resource creation (UTC).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedAt = value; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedBy = value; }

        /// <summary>The type of identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataCreatedByType = value; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedAt = value; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedBy = value; }

        /// <summary>The type of identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).SystemDataLastModifiedByType = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal)__trackedResource).Tag = value; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Origin(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="StorageContainers" /> instance.</summary>
        public StorageContainers()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__trackedResource), __trackedResource);
            await eventListener.AssertObjectIsValid(nameof(__trackedResource), __trackedResource);
        }
    }
    /// The storage container resource definition.
    public partial interface IStorageContainers :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResource
    {
        /// <summary>The name of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the extended location.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string ExtendedLocationName { get; set; }
        /// <summary>The type of the extended location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the extended location.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes? ExtendedLocationType { get; set; }
        /// <summary>Path of the storage container on the disk</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Path of the storage container on the disk",
        SerializedName = @"path",
        PossibleTypes = new [] { typeof(string) })]
        string Path { get; set; }
        /// <summary>Provisioning state of the storage container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the storage container.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get;  }
        /// <summary>
        /// The status of the operation performed on the storage container [Succeeded, Failed, InProgress]
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the operation performed on the storage container [Succeeded, Failed, InProgress]",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status) })]
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the storage container</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the operation performed on the storage container",
        SerializedName = @"operationId",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>Amount of space available on the disk in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Amount of space available on the disk in MB",
        SerializedName = @"availableSizeMB",
        PossibleTypes = new [] { typeof(long) })]
        long? StatusAvailableSizeMb { get; set; }
        /// <summary>Total size of the disk in MB</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Total size of the disk in MB",
        SerializedName = @"containerSizeMB",
        PossibleTypes = new [] { typeof(long) })]
        long? StatusContainerSizeMb { get; set; }
        /// <summary>StorageContainer provisioning error code</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"StorageContainer provisioning error code",
        SerializedName = @"errorCode",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Descriptive error message",
        SerializedName = @"errorMessage",
        PossibleTypes = new [] { typeof(string) })]
        string StatusErrorMessage { get; set; }

    }
    /// The storage container resource definition.
    internal partial interface IStorageContainersInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api30.ITrackedResourceInternal
    {
        /// <summary>The extendedLocation of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IExtendedLocation ExtendedLocation { get; set; }
        /// <summary>The name of the extended location.</summary>
        string ExtendedLocationName { get; set; }
        /// <summary>The type of the extended location.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ExtendedLocationTypes? ExtendedLocationType { get; set; }
        /// <summary>Path of the storage container on the disk</summary>
        string Path { get; set; }
        /// <summary>Properties under the storage container resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerProperties Property { get; set; }
        /// <summary>Provisioning state of the storage container.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ProvisioningStateEnum? ProvisioningState { get; set; }
        /// <summary>
        /// The status of the operation performed on the storage container [Succeeded, Failed, InProgress]
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.Status? ProvisioningStatus { get; set; }
        /// <summary>The ID of the operation performed on the storage container</summary>
        string ProvisioningStatusOperationId { get; set; }
        /// <summary>The observed state of storage containers</summary>
        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerStatus Status { get; set; }
        /// <summary>Amount of space available on the disk in MB</summary>
        long? StatusAvailableSizeMb { get; set; }
        /// <summary>Total size of the disk in MB</summary>
        long? StatusContainerSizeMb { get; set; }
        /// <summary>StorageContainer provisioning error code</summary>
        string StatusErrorCode { get; set; }
        /// <summary>Descriptive error message</summary>
        string StatusErrorMessage { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20221215Preview.IStorageContainerStatusProvisioningStatus StatusProvisioningStatus { get; set; }

    }
}