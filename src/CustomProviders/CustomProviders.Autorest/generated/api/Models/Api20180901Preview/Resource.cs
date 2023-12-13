namespace Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Extensions;

    /// <summary>The resource definition.</summary>
    public partial class Resource :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.ResourceTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Origin(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="Resource" /> instance.</summary>
        public Resource()
        {

        }
    }
    /// The resource definition.
    public partial interface IResource :
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.IJsonSerializable
    {
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags Tag { get; set; }
        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The resource definition.
    internal partial interface IResourceInternal

    {
        /// <summary>Resource Id</summary>
        string Id { get; set; }
        /// <summary>Resource location</summary>
        string Location { get; set; }
        /// <summary>Resource name</summary>
        string Name { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CustomProviders.Models.Api20180901Preview.IResourceTags Tag { get; set; }
        /// <summary>Resource type</summary>
        string Type { get; set; }

    }
}