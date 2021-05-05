namespace Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Extensions;

    /// <summary>Describes a cloud service Extension.</summary>
    public partial class Extension :
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IExtension,
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IExtensionInternal
    {

        /// <summary>
        /// Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become
        /// available.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public bool? AutoUpgradeMinorVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).AutoUpgradeMinorVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).AutoUpgradeMinorVersion = value ?? default(bool); }

        /// <summary>
        /// Tag to force apply the provided public and protected settings.
        /// Changing the tag value allows for re-running the extension without changing any of the public or protected settings.
        /// If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.
        /// If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with
        /// the same sequence-number, and
        /// it is up to handler implementation whether to re-run it or not
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string ForceUpdateTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ForceUpdateTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ForceUpdateTag = value ?? null; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProperties Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IExtensionInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProtectedSettingFromKeyVaultSourceVault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ISubResource Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IExtensionInternal.ProtectedSettingFromKeyVaultSourceVault { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSettingFromKeyVaultSourceVault; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSettingFromKeyVaultSourceVault = value; }

        /// <summary>Internal Acessors for ProtectedSettingsFromKeyVault</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceVaultAndSecretReference Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IExtensionInternal.ProtectedSettingsFromKeyVault { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSettingsFromKeyVault; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSettingsFromKeyVault = value; }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.IExtensionInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the extension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 0)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProperties _property;

        /// <summary>Extension Properties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.CloudServiceExtensionProperties()); set => this._property = value; }

        /// <summary>
        /// Protected settings for the extension which are encrypted before sent to the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string ProtectedSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSetting = value ?? null; }

        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string ProtectedSettingFromKeyVaultSecretUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSettingFromKeyVaultSecretUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProtectedSettingFromKeyVaultSecretUrl = value ?? null; }

        /// <summary>The provisioning state, which only appears in the response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 4)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).ProvisioningState; }

        /// <summary>The name of the extension handler publisher.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 1)]
        public string Publisher { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).Publisher; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).Publisher = value ?? null; }

        /// <summary>
        /// Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied
        /// to all roles in the cloud service.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string[] RolesAppliedTo { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).RolesAppliedTo; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).RolesAppliedTo = value ?? null /* arrayOf */; }

        /// <summary>
        /// Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension
        /// (like RDP), this is the XML setting for the extension.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string Setting { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).Setting; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).Setting = value ?? null; }

        /// <summary>Resource Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.DoNotFormat]
        public string SourceVaultId { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).SourceVaultId; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).SourceVaultId = value ?? null; }

        /// <summary>Specifies the type of the extension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 2)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).Type = value ?? null; }

        /// <summary>
        /// Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an
        /// asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major
        /// version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version
        /// is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version
        /// is selected. If a version is specified, an auto-upgrade is performed on the role instance.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Origin(Microsoft.Azure.PowerShell.Cmdlets.CloudService.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.FormatTable(Index = 3)]
        public string TypeHandlerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).TypeHandlerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionPropertiesInternal)Property).TypeHandlerVersion = value ?? null; }

        /// <summary>Creates an new <see cref="Extension" /> instance.</summary>
        public Extension()
        {

        }
    }
    /// Describes a cloud service Extension.
    public partial interface IExtension :
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
        /// <summary>The name of the extension.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the extension.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
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
    /// Describes a cloud service Extension.
    internal partial interface IExtensionInternal

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
        /// <summary>The name of the extension.</summary>
        string Name { get; set; }
        /// <summary>Extension Properties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20210301.ICloudServiceExtensionProperties Property { get; set; }
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