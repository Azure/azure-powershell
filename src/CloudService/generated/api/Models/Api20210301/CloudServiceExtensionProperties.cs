namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Extension Properties.</summary>
    public partial class CloudServiceExtensionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal
    {

        /// <summary>Backing field for <see cref="AutoUpgradeMinorVersion" /> property.</summary>
        private bool? _autoUpgradeMinorVersion;

        /// <summary>
        /// Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become
        /// available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public bool? AutoUpgradeMinorVersion { get => this._autoUpgradeMinorVersion; set => this._autoUpgradeMinorVersion = value; }

        /// <summary>Backing field for <see cref="ForceUpdateTag" /> property.</summary>
        private string _forceUpdateTag;

        /// <summary>
        /// Tag to force apply the provided public and protected settings.
        /// Changing the tag value allows for re-running the extension without changing any of the public or protected settings.
        /// If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.
        /// If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with
        /// the same sequence-number, and
        /// it is up to handler implementation whether to re-run it or not
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string ForceUpdateTag { get => this._forceUpdateTag; set => this._forceUpdateTag = value; }

        /// <summary>Internal Acessors for ProtectedSettingFromKeyVaultSourceVault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal.ProtectedSettingFromKeyVaultSourceVault { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReferenceInternal)ProtectedSettingsFromKeyVault).SourceVault; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReferenceInternal)ProtectedSettingsFromKeyVault).SourceVault = value; }

        /// <summary>Internal Acessors for ProtectedSettingsFromKeyVault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReference Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal.ProtectedSettingsFromKeyVault { get => (this._protectedSettingsFromKeyVault = this._protectedSettingsFromKeyVault ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceVaultAndSecretReference()); set { {_protectedSettingsFromKeyVault = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="ProtectedSetting" /> property.</summary>
        private string _protectedSetting;

        /// <summary>
        /// Protected settings for the extension which are encrypted before sent to the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string ProtectedSetting { get => this._protectedSetting; set => this._protectedSetting = value; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string ProtectedSettingFromKeyVaultSecretUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReferenceInternal)ProtectedSettingsFromKeyVault).SecretUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReferenceInternal)ProtectedSettingsFromKeyVault).SecretUrl = value ?? null; }

        /// <summary>Backing field for <see cref="ProtectedSettingsFromKeyVault" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReference _protectedSettingsFromKeyVault;

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReference ProtectedSettingsFromKeyVault { get => (this._protectedSettingsFromKeyVault = this._protectedSettingsFromKeyVault ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceVaultAndSecretReference()); set => this._protectedSettingsFromKeyVault = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Publisher" /> property.</summary>
        private string _publisher;

        /// <summary>The name of the extension handler publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Publisher { get => this._publisher; set => this._publisher = value; }

        /// <summary>Backing field for <see cref="RolesAppliedTo" /> property.</summary>
        private string[] _rolesAppliedTo;

        /// <summary>
        /// Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied
        /// to all roles in the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string[] RolesAppliedTo { get => this._rolesAppliedTo; set => this._rolesAppliedTo = value; }

        /// <summary>Backing field for <see cref="Setting" /> property.</summary>
        private string _setting;

        /// <summary>
        /// Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension
        /// (like RDP), this is the XML setting for the extension.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Setting { get => this._setting; set => this._setting = value; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        public string SourceVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReferenceInternal)ProtectedSettingsFromKeyVault).SourceVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReferenceInternal)ProtectedSettingsFromKeyVault).SourceVaultId = value ?? null; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>Specifies the type of the extension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Backing field for <see cref="TypeHandlerVersion" /> property.</summary>
        private string _typeHandlerVersion;

        /// <summary>
        /// Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an
        /// asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major
        /// version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version
        /// is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version
        /// is selected. If a version is specified, an auto-upgrade is performed on the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        public string TypeHandlerVersion { get => this._typeHandlerVersion; set => this._typeHandlerVersion = value; }

        /// <summary>Creates an new <see cref="CloudServiceExtensionProperties" /> instance.</summary>
        public CloudServiceExtensionProperties()
        {

        }
    }
    /// Extension Properties.
    public partial interface ICloudServiceExtensionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become
        /// available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.",
        SerializedName = @"autoUpgradeMinorVersion",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AutoUpgradeMinorVersion { get; set; }
        /// <summary>
        /// Tag to force apply the provided public and protected settings.
        /// Changing the tag value allows for re-running the extension without changing any of the public or protected settings.
        /// If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.
        /// If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with
        /// the same sequence-number, and
        /// it is up to handler implementation whether to re-run it or not
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tag to force apply the provided public and protected settings.
        Changing the tag value allows for re-running the extension without changing any of the public or protected settings.
        If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.
        If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and
        it is up to handler implementation whether to re-run it or not",
        SerializedName = @"forceUpdateTag",
        PossibleTypes = new [] { typeof(string) })]
        string ForceUpdateTag { get; set; }
        /// <summary>
        /// Protected settings for the extension which are encrypted before sent to the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Protected settings for the extension which are encrypted before sent to the role instance.",
        SerializedName = @"protectedSettings",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectedSetting { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"secretUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ProtectedSettingFromKeyVaultSecretUrl { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state, which only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The name of the extension handler publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the extension handler publisher.",
        SerializedName = @"publisher",
        PossibleTypes = new [] { typeof(string) })]
        string Publisher { get; set; }
        /// <summary>
        /// Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied
        /// to all roles in the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.",
        SerializedName = @"rolesAppliedTo",
        PossibleTypes = new [] { typeof(string) })]
        string[] RolesAppliedTo { get; set; }
        /// <summary>
        /// Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension
        /// (like RDP), this is the XML setting for the extension.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.",
        SerializedName = @"settings",
        PossibleTypes = new [] { typeof(string) })]
        string Setting { get; set; }
        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource Id",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SourceVaultId { get; set; }
        /// <summary>Specifies the type of the extension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the type of the extension.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }
        /// <summary>
        /// Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an
        /// asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major
        /// version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version
        /// is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version
        /// is selected. If a version is specified, an auto-upgrade is performed on the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.",
        SerializedName = @"typeHandlerVersion",
        PossibleTypes = new [] { typeof(string) })]
        string TypeHandlerVersion { get; set; }

    }
    /// Extension Properties.
    internal partial interface ICloudServiceExtensionPropertiesInternal

    {
        /// <summary>
        /// Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become
        /// available.
        /// </summary>
        bool? AutoUpgradeMinorVersion { get; set; }
        /// <summary>
        /// Tag to force apply the provided public and protected settings.
        /// Changing the tag value allows for re-running the extension without changing any of the public or protected settings.
        /// If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.
        /// If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with
        /// the same sequence-number, and
        /// it is up to handler implementation whether to re-run it or not
        /// </summary>
        string ForceUpdateTag { get; set; }
        /// <summary>
        /// Protected settings for the extension which are encrypted before sent to the role instance.
        /// </summary>
        string ProtectedSetting { get; set; }

        string ProtectedSettingFromKeyVaultSecretUrl { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource ProtectedSettingFromKeyVaultSourceVault { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReference ProtectedSettingsFromKeyVault { get; set; }
        /// <summary>The provisioning state, which only appears in the response.</summary>
        string ProvisioningState { get; set; }
        /// <summary>The name of the extension handler publisher.</summary>
        string Publisher { get; set; }
        /// <summary>
        /// Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied
        /// to all roles in the cloud service.
        /// </summary>
        string[] RolesAppliedTo { get; set; }
        /// <summary>
        /// Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension
        /// (like RDP), this is the XML setting for the extension.
        /// </summary>
        string Setting { get; set; }
        /// <summary>Resource Id</summary>
        string SourceVaultId { get; set; }
        /// <summary>Specifies the type of the extension.</summary>
        string Type { get; set; }
        /// <summary>
        /// Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an
        /// asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major
        /// version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version
        /// is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version
        /// is selected. If a version is specified, an auto-upgrade is performed on the role instance.
        /// </summary>
        string TypeHandlerVersion { get; set; }

    }
}