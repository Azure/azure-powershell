namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Cloud service properties</summary>
    public partial class CloudServiceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AllowModelOverride" /> property.</summary>
        private bool? _allowModelOverride;

        /// <summary>
        /// (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override
        /// the role instance count and vm size specified in the .cscfg and .csdef respectively.
        /// The default value is `false`.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public bool? AllowModelOverride { get => this._allowModelOverride; set => this._allowModelOverride = value; }

        /// <summary>Backing field for <see cref="Configuration" /> property.</summary>
        private string _configuration;

        /// <summary>Specifies the XML service configuration (.cscfg) for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Configuration { get => this._configuration; set => this._configuration = value; }

        /// <summary>Backing field for <see cref="ConfigurationUrl" /> property.</summary>
        private string _configurationUrl;

        /// <summary>
        /// Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL
        /// can be Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string ConfigurationUrl { get => this._configurationUrl; set => this._configurationUrl = value; }

        /// <summary>Backing field for <see cref="ExtensionProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile _extensionProfile;

        /// <summary>Describes a cloud service extension profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProfile ExtensionProfile { get => (this._extensionProfile = this._extensionProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProfile()); set => this._extensionProfile = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for UniqueId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServicePropertiesInternal.UniqueId { get => this._uniqueId; set { {_uniqueId = value;} } }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile _networkProfile;

        /// <summary>Network Profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceNetworkProfile NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceNetworkProfile()); set => this._networkProfile = value; }

        /// <summary>Backing field for <see cref="OSProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile _oSProfile;

        /// <summary>Describes the OS profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceOSProfile OSProfile { get => (this._oSProfile = this._oSProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceOSProfile()); set => this._oSProfile = value; }

        /// <summary>Backing field for <see cref="PackageUrl" /> property.</summary>
        private string _packageUrl;

        /// <summary>
        /// Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be
        /// Shared Access Signature (SAS) URI from any storage account.
        /// This is a write-only property and is not returned in GET calls.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string PackageUrl { get => this._packageUrl; set => this._packageUrl = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RoleProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile _roleProfile;

        /// <summary>Describes the role profile for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceRoleProfile RoleProfile { get => (this._roleProfile = this._roleProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceRoleProfile()); set => this._roleProfile = value; }

        /// <summary>Backing field for <see cref="StartCloudService" /> property.</summary>
        private bool? _startCloudService;

        /// <summary>
        /// (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.
        /// If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff
        /// until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is
        /// poweredoff.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public bool? StartCloudService { get => this._startCloudService; set => this._startCloudService = value; }

        /// <summary>Backing field for <see cref="UniqueId" /> property.</summary>
        private string _uniqueId;

        /// <summary>The unique identifier for the cloud service.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string UniqueId { get => this._uniqueId; }

        /// <summary>Backing field for <see cref="UpgradeMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode? _upgradeMode;

        /// <summary>
        /// Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates
        /// can be initiated manually in each update domain or initiated automatically in all update domains.
        /// Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />
        /// If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If
        /// set to Auto, the update is automatically applied to each update domain in sequence.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.CloudService.Support.CloudServiceUpgradeMode? UpgradeMode { get => this._upgradeMode; set => this._upgradeMode = value; }

        /// <summary>Creates an new <see cref="CloudServiceProperties" /> instance.</summary>
        public CloudServiceProperties()
        {

        }
    }
    /// Cloud service properties
    public partial interface ICloudServiceProperties :
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
    /// Cloud service properties
    internal partial interface ICloudServicePropertiesInternal

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