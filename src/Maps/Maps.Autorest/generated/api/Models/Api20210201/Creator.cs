namespace Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Extensions;

    /// <summary>
    /// An Azure resource which represents Maps Creator product and provides ability to manage private location data.
    /// </summary>
    public partial class Creator :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreator,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResource __trackedResource = new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.TrackedResource();

        /// <summary>
        /// Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Id; }

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
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.CreatorProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties _property;

        /// <summary>The Creator resource properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.CreatorProperties()); set => this._property = value; }

        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inlined)]
        public int StorageUnit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).StorageUnit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorPropertiesInternal)Property).StorageUnit = value ; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal)__trackedResource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal)__trackedResource).Tag = value ?? null /* model class */; }

        /// <summary>
        /// The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts"
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Origin(Microsoft.Azure.PowerShell.Cmdlets.Maps.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.IResourceInternal)__trackedResource).Type; }

        /// <summary>Creates an new <see cref="Creator" /> instance.</summary>
        public Creator()
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
    /// An Azure resource which represents Maps Creator product and provides ability to manage private location data.
    public partial interface ICreator :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResource
    {
        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Maps.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The storage units to be allocated. Integer values from 1 to 100, inclusive.",
        SerializedName = @"storageUnits",
        PossibleTypes = new [] { typeof(int) })]
        int StorageUnit { get; set; }

    }
    /// An Azure resource which represents Maps Creator product and provides ability to manage private location data.
    internal partial interface ICreatorInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20.ITrackedResourceInternal
    {
        /// <summary>The Creator resource properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20210201.ICreatorProperties Property { get; set; }
        /// <summary>
        /// The state of the resource provisioning, terminal states: Succeeded, Failed, Canceled
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The storage units to be allocated. Integer values from 1 to 100, inclusive.</summary>
        int StorageUnit { get; set; }

    }
}