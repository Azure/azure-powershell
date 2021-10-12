namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The Resource model definition.</summary>
    public partial class Resource :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags _tag;

        /// <summary>The resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ResourceTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="Resource" /> instance.</summary>
        public Resource()
        {

        }
    }
    /// The Resource model definition.
    public partial interface IResource :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The resource id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>The resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags Tag { get; set; }
        /// <summary>The resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    /// The Resource model definition.
    internal partial interface IResourceInternal

    {
        /// <summary>The resource id.</summary>
        string Id { get; set; }
        /// <summary>The resource location.</summary>
        string Location { get; set; }
        /// <summary>The resource name.</summary>
        string Name { get; set; }
        /// <summary>The resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IResourceTags Tag { get; set; }
        /// <summary>The resource type.</summary>
        string Type { get; set; }

    }
}