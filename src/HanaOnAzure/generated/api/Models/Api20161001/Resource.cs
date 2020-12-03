namespace Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Extensions;

    public partial class Resource :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.Resource();

        /// <summary>The Azure Resource Manager resource ID for the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The supported Azure location where the key vault should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Type = value; }

        /// <summary>The name of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Name; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResourceTags _tag;

        /// <summary>The tags that will be assigned to the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.ResourceTags()); set => this._tag = value; }

        /// <summary>The resource type of the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Origin(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal)__resource).Type; }

        /// <summary>Creates an new <see cref="Resource" /> instance.</summary>
        public Resource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    public partial interface IResource :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResource
    {
        /// <summary>The supported Azure location where the key vault should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The supported Azure location where the key vault should be created.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The tags that will be assigned to the key vault.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The tags that will be assigned to the key vault. ",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResourceTags Tag { get; set; }

    }
    internal partial interface IResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api10.IResourceInternal
    {
        /// <summary>The supported Azure location where the key vault should be created.</summary>
        string Location { get; set; }
        /// <summary>The tags that will be assigned to the key vault.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.HanaOnAzure.Models.Api20161001.IResourceTags Tag { get; set; }

    }
}