namespace Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601
{
    using static Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Extensions;

    /// <summary>The resource model definition for a ARM tracked top level resource</summary>
    public partial class TrackedResource :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResource,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.Resource();

        /// <summary>Fully qualified resource Id for the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The Azure Region where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.TrackedResourceTags()); set => this._tag = value; }

        /// <summary>The type of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Origin(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="TrackedResource" /> instance.</summary>
        public TrackedResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// The resource model definition for a ARM tracked top level resource
    public partial interface ITrackedResource :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResource
    {
        /// <summary>The Azure Region where the resource lives</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Azure Region where the resource lives",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags Tag { get; set; }

    }
    /// The resource model definition for a ARM tracked top level resource
    internal partial interface ITrackedResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.IResourceInternal
    {
        /// <summary>The Azure Region where the resource lives</summary>
        string Location { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.WindowsIotServices.Models.Api20190601.ITrackedResourceTags Tag { get; set; }

    }
}