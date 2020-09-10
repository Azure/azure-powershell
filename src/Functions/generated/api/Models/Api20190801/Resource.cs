namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class Resource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.Resource();

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Kind" /> property.</summary>
        private string _kind;

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Kind { get => this._kind; set => this._kind = value; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ResourceTags()); set => this._tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Resource" /> instance.</summary>
        public Resource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    public partial interface IResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResource
    {
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string Kind { get; set; }
        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource Location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get; set; }

    }
    internal partial interface IResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api10.IResourceInternal
    {
        /// <summary>Kind of resource.</summary>
        string Kind { get; set; }
        /// <summary>Resource Location.</summary>
        string Location { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get; set; }

    }
}