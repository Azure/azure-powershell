namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    public partial class RoleInstance :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstance,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal
    {

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Id { get => this._id; }

        /// <summary>The Fault Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public int? InstanceViewPlatformFaultDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPlatformFaultDomain; }

        /// <summary>The Update Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public int? InstanceViewPlatformUpdateDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPlatformUpdateDomain; }

        /// <summary>
        /// Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br
        /// /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string InstanceViewPrivateId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPrivateId; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] InstanceViewStatuses { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewStatuses; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 1)]
        public string Location { get => this._location; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.InstanceView { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceView; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceView = value; }

        /// <summary>Internal Acessors for InstanceViewPlatformFaultDomain</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.InstanceViewPlatformFaultDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPlatformFaultDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPlatformFaultDomain = value; }

        /// <summary>Internal Acessors for InstanceViewPlatformUpdateDomain</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.InstanceViewPlatformUpdateDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPlatformUpdateDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPlatformUpdateDomain = value; }

        /// <summary>Internal Acessors for InstanceViewPrivateId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.InstanceViewPrivateId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPrivateId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewPrivateId = value; }

        /// <summary>Internal Acessors for InstanceViewStatuses</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.InstanceViewStatuses { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewStatuses; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).InstanceViewStatuses = value; }

        /// <summary>Internal Acessors for Location</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Location { get => this._location; set { {_location = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).NetworkProfile = value; }

        /// <summary>Internal Acessors for NetworkProfileNetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).NetworkProfileNetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).NetworkProfileNetworkInterface = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Sku</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSku Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceSku()); set { {_sku = value;} } }

        /// <summary>Internal Acessors for SkuName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSkuInternal)Sku).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSkuInternal)Sku).Name = value; }

        /// <summary>Internal Acessors for SkuTier</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSkuInternal)Sku).Tier; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSkuInternal)Sku).Tier = value; }

        /// <summary>Internal Acessors for Tag</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceTags()); set { {_tag = value;} } }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 0)]
        public string Name { get => this._name; }

        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[] NetworkProfileNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstancePropertiesInternal)Property).NetworkProfileNetworkInterface; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties _property;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceProperties()); set => this._property = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSku _sku;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSku Sku { get => (this._sku = this._sku ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.InstanceSku()); set => this._sku = value; }

        /// <summary>The sku name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 2)]
        public string SkuName { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSkuInternal)Sku).Name; }

        /// <summary>The tier of the cloud service role instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 3)]
        public string SkuTier { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSkuInternal)Sku).Tier; }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.RoleInstanceTags()); }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource Type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Type { get => this._type; }

        /// <summary>Creates an new <see cref="RoleInstance" /> instance.</summary>
        public RoleInstance()
        {

        }
    }
    public partial interface IRoleInstance :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>The Fault Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Fault Domain.",
        SerializedName = @"platformFaultDomain",
        PossibleTypes = new [] { typeof(int) })]
        int? InstanceViewPlatformFaultDomain { get;  }
        /// <summary>The Update Domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The Update Domain.",
        SerializedName = @"platformUpdateDomain",
        PossibleTypes = new [] { typeof(int) })]
        int? InstanceViewPlatformUpdateDomain { get;  }
        /// <summary>
        /// Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br
        /// /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.",
        SerializedName = @"privateId",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceViewPrivateId { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"statuses",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] InstanceViewStatuses { get;  }
        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get;  }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies the list of resource Ids for the network interfaces associated with the role instance.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[] NetworkProfileNetworkInterface { get;  }
        /// <summary>The sku name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The sku name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SkuName { get;  }
        /// <summary>The tier of the cloud service role instance.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The tier of the cloud service role instance.",
        SerializedName = @"tier",
        PossibleTypes = new [] { typeof(string) })]
        string SkuTier { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags Tag { get;  }
        /// <summary>Resource Type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }

    }
    internal partial interface IRoleInstanceInternal

    {
        /// <summary>Resource Id</summary>
        string Id { get; set; }
        /// <summary>The instance view of the role instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceView InstanceView { get; set; }
        /// <summary>The Fault Domain.</summary>
        int? InstanceViewPlatformFaultDomain { get; set; }
        /// <summary>The Update Domain.</summary>
        int? InstanceViewPlatformUpdateDomain { get; set; }
        /// <summary>
        /// Specifies a unique identifier generated internally for the cloud service associated with this role instance. <br /><br
        /// /> NOTE: If you are using Azure Diagnostics extension, this property can be used as 'DeploymentId' for querying details.
        /// </summary>
        string InstanceViewPrivateId { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IResourceInstanceViewStatus[] InstanceViewStatuses { get; set; }
        /// <summary>Resource Location.</summary>
        string Location { get; set; }
        /// <summary>Resource Name.</summary>
        string Name { get; set; }
        /// <summary>Describes the network profile for the role instance.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceNetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// Specifies the list of resource Ids for the network interfaces associated with the role instance.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource[] NetworkProfileNetworkInterface { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceProperties Property { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IInstanceSku Sku { get; set; }
        /// <summary>The sku name.</summary>
        string SkuName { get; set; }
        /// <summary>The tier of the cloud service role instance.</summary>
        string SkuTier { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IRoleInstanceTags Tag { get; set; }
        /// <summary>Resource Type.</summary>
        string Type { get; set; }

    }
}