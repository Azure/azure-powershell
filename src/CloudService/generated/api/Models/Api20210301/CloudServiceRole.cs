namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes a role of the cloud service.</summary>
    public partial class CloudServiceRole :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRole,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProperties Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSku Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleInternal.UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRolePropertiesInternal)Property).UniqueId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRolePropertiesInternal)Property).UniqueId = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSku _sku;

        /// <summary>Describes the cloud service role sku.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleSku()); set => this._sku = value; }

        /// <summary>Specifies the number of role instances in the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public long? SkuCapacity { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal)Sku).Capacity; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal)Sku).Capacity = value ?? default(long); }

        /// <summary>
        /// The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete
        /// and recreate the cloud service or move back to the old sku.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal)Sku).Name = value ?? null; }

        /// <summary>
        /// Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSkuInternal)Sku).Tier = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Type { get => this._type; }

        /// <summary>Specifies the ID which uniquely identifies a cloud service role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRolePropertiesInternal)Property).UniqueId; }

        /// <summary>Creates an new <see cref="CloudServiceRole" /> instance.</summary>
        public CloudServiceRole()
        {

        }
    }
    /// Describes a role of the cloud service.
    public partial interface ICloudServiceRole :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Resource id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Resource location</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource location",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>Resource name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Specifies the number of role instances in the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the number of role instances in the cloud service.",
        SerializedName = @"capacity",
        PossibleTypes = new [] { typeof(long) })]
        long? SkuCapacity { get; set; }
        /// <summary>
        /// The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete
        /// and recreate the cloud service or move back to the old sku.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get; set; }
        /// <summary>
        /// Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get; set; }
        /// <summary>Resource type</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>Specifies the ID which uniquely identifies a cloud service role.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the ID which uniquely identifies a cloud service role.",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }

    }
    /// Describes a role of the cloud service.
    internal partial interface ICloudServiceRoleInternal

    {
        /// <summary>Resource id</summary>
        string Id { get; set; }
        /// <summary>Resource location</summary>
        string Location { get; set; }
        /// <summary>Resource name</summary>
        string Name { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProperties Property { get; set; }
        /// <summary>Describes the cloud service role sku.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleSku Sku { get; set; }
        /// <summary>Specifies the number of role instances in the cloud service.</summary>
        long? SkuCapacity { get; set; }
        /// <summary>
        /// The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete
        /// and recreate the cloud service or move back to the old sku.
        /// </summary>
        string SkuName { get; set; }
        /// <summary>
        /// Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
        /// </summary>
        string SkuTier { get; set; }
        /// <summary>Resource type</summary>
        string Type { get; set; }
        /// <summary>Specifies the ID which uniquely identifies a cloud service role.</summary>
        string UniqueId { get; set; }

    }
}