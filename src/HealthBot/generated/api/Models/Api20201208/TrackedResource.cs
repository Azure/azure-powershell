namespace Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Extensions;

    /// <summary>The resource model definition for a ARM tracked top level resource</summary>
    public partial class TrackedResource :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResource,
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.Resource();

        /// <summary>Fully qualified resource Id for the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISystemData Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemData = value; }

        /// <summary>Internal Acessors for SystemDataCreatedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedAt = value; }

        /// <summary>Internal Acessors for SystemDataCreatedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedBy = value; }

        /// <summary>Internal Acessors for SystemDataCreatedByType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType? Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedByType = value; }

        /// <summary>Internal Acessors for SystemDataLastModifiedAt</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedAt = value; }

        /// <summary>Internal Acessors for SystemDataLastModifiedBy</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedBy = value; }

        /// <summary>Internal Acessors for SystemDataLastModifiedByType</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType? Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedByType = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Name; }

        /// <summary>Metadata pertaining to creation and last modification of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemData; }

        /// <summary>The timestamp of resource creation (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedAt; }

        /// <summary>The identity that created the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedBy; }

        /// <summary>The type of identity that created the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataCreatedByType; }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedAt; }

        /// <summary>The identity that last modified the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedBy; }

        /// <summary>The type of identity that last modified the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Support.IdentityType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).SystemDataLastModifiedByType; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.TrackedResourceTags()); set => this._tag = value; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Origin(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="TrackedResource" /> instance.</summary>
        public TrackedResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The resource model definition for a ARM tracked top level resource
    public partial interface ITrackedResource :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResource
    {
        /// <summary>The geo-location where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The geo-location where the resource lives",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags Tag { get; set; }

    }
    /// The resource model definition for a ARM tracked top level resource
    internal partial interface ITrackedResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.IResourceInternal
    {
        /// <summary>The geo-location where the resource lives</summary>
        string Location { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HealthBot.Models.Api20201208.ITrackedResourceTags Tag { get; set; }

    }
}