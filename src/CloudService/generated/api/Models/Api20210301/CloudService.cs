namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes the cloud service.</summary>
    public partial class CloudService :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudService,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal
    {

        /// <summary>
        /// (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override
        /// the role instance count and vm size specified in the .cscfg and .csdef respectively.
        /// The default value is `false`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public bool? AllowModelOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).AllowModelOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).AllowModelOverride = value ?? default(bool); }

        /// <summary>Specifies the XML service configuration (.cscfg) for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Configuration { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).Configuration; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).Configuration = value ?? null; }

        /// <summary>
        /// Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL
        /// can be Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string ConfigurationUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ConfigurationUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ConfigurationUrl = value ?? null; }

        /// <summary>Describes a cloud service extension profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile ExtensionProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ExtensionProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ExtensionProfile = value ?? null /* model class */; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Id { get => this._id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 2)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal.Id { get => this._id; set { {_id = value;} } }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal.Type { get => this._type; set { {_type = value;} } }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceInternal.UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).UniqueId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).UniqueId = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 1)]
        public string Name { get => this._name; }

        /// <summary>Network Profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile NetworkProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).NetworkProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).NetworkProfile = value ?? null /* model class */; }

        /// <summary>Describes the OS profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile OSProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).OSProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).OSProfile = value ?? null /* model class */; }

        /// <summary>
        /// Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be
        /// Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string PackageUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).PackageUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).PackageUrl = value ?? null; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties _property;

        /// <summary>Cloud service properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceProperties()); set => this._property = value; }

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 3)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Describes the role profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile RoleProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).RoleProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).RoleProfile = value ?? null /* model class */; }

        /// <summary>
        /// (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.
        /// If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff
        /// until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is
        /// poweredoff.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public bool? StartCloudService { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).StartCloudService; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).StartCloudService = value ?? default(bool); }

        /// <summary>Backing field for <see cref="Tag" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags _tag;

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags Tag { get => (this._tag = this._tag ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceTags()); set => this._tag = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Type { get => this._type; }

        /// <summary>The unique identifier for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string UniqueId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).UniqueId; }

        /// <summary>
        /// Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates
        /// can be initiated manually in each update domain or initiated automatically in all update domains.
        /// Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />
        /// If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If
        /// set to Auto, the update is automatically applied to each update domain in sequence.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode? UpgradeMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).UpgradeMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal)Property).UpgradeMode = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode)""); }

        /// <summary>Creates an new <see cref="CloudService" /> instance.</summary>
        public CloudService()
        {

        }
    }
    /// Describes the cloud service.
    public partial interface ICloudService :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override
        /// the role instance count and vm size specified in the .cscfg and .csdef respectively.
        /// The default value is `false`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"(Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.
        The default value is `false`.",
        SerializedName = @"allowModelOverride",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowModelOverride { get; set; }
        /// <summary>Specifies the XML service configuration (.cscfg) for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the XML service configuration (.cscfg) for the cloud service.",
        SerializedName = @"configuration",
        PossibleTypes = new [] { typeof(string) })]
        string Configuration { get; set; }
        /// <summary>
        /// Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL
        /// can be Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.
        This is a write-only property and is not returned in GET calls.",
        SerializedName = @"configurationUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigurationUrl { get; set; }
        /// <summary>Describes a cloud service extension profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes a cloud service extension profile.",
        SerializedName = @"extensionProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile ExtensionProfile { get; set; }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get;  }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>Network Profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Network Profile for the cloud service.",
        SerializedName = @"networkProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile NetworkProfile { get; set; }
        /// <summary>Describes the OS profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the OS profile for the cloud service.",
        SerializedName = @"osProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile OSProfile { get; set; }
        /// <summary>
        /// Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be
        /// Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.
        This is a write-only property and is not returned in GET calls.",
        SerializedName = @"packageUrl",
        PossibleTypes = new [] { typeof(string) })]
        string PackageUrl { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Describes the role profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Describes the role profile for the cloud service.",
        SerializedName = @"roleProfile",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile RoleProfile { get; set; }
        /// <summary>
        /// (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.
        /// If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff
        /// until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is
        /// poweredoff.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"(Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.
        If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.",
        SerializedName = @"startCloudService",
        PossibleTypes = new [] { typeof(bool) })]
        bool? StartCloudService { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags Tag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get;  }
        /// <summary>The unique identifier for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The unique identifier for the cloud service.",
        SerializedName = @"uniqueId",
        PossibleTypes = new [] { typeof(string) })]
        string UniqueId { get;  }
        /// <summary>
        /// Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates
        /// can be initiated manually in each update domain or initiated automatically in all update domains.
        /// Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />
        /// If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If
        /// set to Auto, the update is automatically applied to each update domain in sequence.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.
        Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />
        If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.",
        SerializedName = @"upgradeMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode? UpgradeMode { get; set; }

    }
    /// Describes the cloud service.
    internal partial interface ICloudServiceInternal

    {
        /// <summary>
        /// (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override
        /// the role instance count and vm size specified in the .cscfg and .csdef respectively.
        /// The default value is `false`.
        /// </summary>
        bool? AllowModelOverride { get; set; }
        /// <summary>Specifies the XML service configuration (.cscfg) for the cloud service.</summary>
        string Configuration { get; set; }
        /// <summary>
        /// Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL
        /// can be Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        string ConfigurationUrl { get; set; }
        /// <summary>Describes a cloud service extension profile.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile ExtensionProfile { get; set; }
        /// <summary>Resource Id.</summary>
        string Id { get; set; }
        /// <summary>Resource location.</summary>
        string Location { get; set; }
        /// <summary>Resource name.</summary>
        string Name { get; set; }
        /// <summary>Network Profile for the cloud service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile NetworkProfile { get; set; }
        /// <summary>Describes the OS profile for the cloud service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile OSProfile { get; set; }
        /// <summary>
        /// Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be
        /// Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        string PackageUrl { get; set; }
        /// <summary>Cloud service properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties Property { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        string ProvisioningState { get; set; }
        /// <summary>Describes the role profile for the cloud service.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile RoleProfile { get; set; }
        /// <summary>
        /// (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.
        /// If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff
        /// until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is
        /// poweredoff.
        /// </summary>
        bool? StartCloudService { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceTags Tag { get; set; }
        /// <summary>Resource type.</summary>
        string Type { get; set; }
        /// <summary>The unique identifier for the cloud service.</summary>
        string UniqueId { get; set; }
        /// <summary>
        /// Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates
        /// can be initiated manually in each update domain or initiated automatically in all update domains.
        /// Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />
        /// If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If
        /// set to Auto, the update is automatically applied to each update domain in sequence.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode? UpgradeMode { get; set; }

    }
}