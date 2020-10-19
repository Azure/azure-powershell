namespace Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Extensions;

    /// <summary>Dedicated HSM resource</summary>
    public partial class Resource :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResource,
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The Azure Resource Manager resource ID for the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>The supported Azure location where the dedicated HSM should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISku Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.Sku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISku _sku;

        /// <summary>SKU details</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.Sku()); set => this._sku = value; }

        /// <summary>SKU of the dedicated HSM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISkuInternal)Sku).Name = value; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags _tag;

        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ResourceTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The resource type of the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Backing field for <see cref="Zone" /> property.</summary>
        private string[] _zone;

        /// <summary>The Dedicated Hsm zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Origin(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.PropertyOrigin.Owned)]
        public string[] Zone { get => this._zone; set => this._zone = value; }

        /// <summary>Creates an new <see cref="Resource" /> instance.</summary>
        public Resource()
        {

        }
    }
    /// Dedicated HSM resource
    public partial interface IResource :
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.IJsonSerializable
    {
        /// <summary>The Azure Resource Manager resource ID for the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Azure Resource Manager resource ID for the dedicated HSM.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The supported Azure location where the dedicated HSM should be created.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The supported Azure location where the dedicated HSM should be created.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>The name of the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the dedicated HSM.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>SKU of the dedicated HSM</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SKU of the dedicated HSM",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>Resource tags</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags Tag { get; set; }
        /// <summary>The resource type of the dedicated HSM.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The resource type of the dedicated HSM.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>The Dedicated Hsm zones.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Dedicated Hsm zones.",
        SerializedName = @"zones",
        PossibleTypes = new [] { typeof(string) })]
        string[] Zone { get; set; }

    }
    /// Dedicated HSM resource
    internal partial interface IResourceInternal

    {
        /// <summary>The Azure Resource Manager resource ID for the dedicated HSM.</summary>
        string Id { get; set; }
        /// <summary>The supported Azure location where the dedicated HSM should be created.</summary>
        string Location { get; set; }
        /// <summary>The name of the dedicated HSM.</summary>
        string Name { get; set; }
        /// <summary>SKU details</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.ISku Sku { get; set; }
        /// <summary>SKU of the dedicated HSM</summary>
        string SkuName { get; set; }
        /// <summary>Resource tags</summary>
        Microsoft.Azure.PowerShell.Cmdlets.DedicatedHsm.Models.Api20181031.IResourceTags Tag { get; set; }
        /// <summary>The resource type of the dedicated HSM.</summary>
        string Type { get; set; }
        /// <summary>The Dedicated Hsm zones.</summary>
        string[] Zone { get; set; }

    }
}