namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>The container group properties</summary>
    public partial class ContainerGroupProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupProperties,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Container" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] _container;

        /// <summary>The containers within the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] Container { get => this._container; set => this._container = value; }

        /// <summary>Backing field for <see cref="Diagnostic" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics _diagnostic;

        /// <summary>The diagnostic information for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics Diagnostic { get => (this._diagnostic = this._diagnostic ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupDiagnostics()); set => this._diagnostic = value; }

        /// <summary>Backing field for <see cref="DnsConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration _dnsConfig;

        /// <summary>The DNS config information for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration DnsConfig { get => (this._dnsConfig = this._dnsConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.DnsConfiguration()); set => this._dnsConfig = value; }

        /// <summary>The DNS servers for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string[] DnsConfigNameServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal)DnsConfig).NameServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal)DnsConfig).NameServer = value ?? null /* arrayOf */; }

        /// <summary>The DNS options for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string DnsConfigOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal)DnsConfig).Option; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal)DnsConfig).Option = value ?? null; }

        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string DnsConfigSearchDomain { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal)DnsConfig).SearchDomain; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfigurationInternal)DnsConfig).SearchDomain = value ?? null; }

        /// <summary>Backing field for <see cref="EncryptionProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties _encryptionProperty;

        /// <summary>The encryption properties for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties EncryptionProperty { get => (this._encryptionProperty = this._encryptionProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EncryptionProperties()); set => this._encryptionProperty = value; }

        /// <summary>The encryption key name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string EncryptionPropertyKeyName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal)EncryptionProperty).KeyName; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal)EncryptionProperty).KeyName = value ?? null; }

        /// <summary>The encryption key version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string EncryptionPropertyKeyVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal)EncryptionProperty).KeyVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal)EncryptionProperty).KeyVersion = value ?? null; }

        /// <summary>The keyvault base url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string EncryptionPropertyVaultBaseUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal)EncryptionProperty).VaultBaseUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionPropertiesInternal)EncryptionProperty).VaultBaseUrl = value ?? null; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress _iPAddress;

        /// <summary>The IP address type of the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress IPAddress { get => (this._iPAddress = this._iPAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPAddress()); set => this._iPAddress = value; }

        /// <summary>The Dns name label for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IPAddressDnsNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).DnsNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).DnsNameLabel = value ?? null; }

        /// <summary>The FQDN for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IPAddressFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Fqdn; }

        /// <summary>The IP exposed to the public internet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string IPAddressIP { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).IP; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).IP = value ?? null; }

        /// <summary>The list of ports exposed on the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] IPAddressPort { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Port; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Port = value ?? null /* arrayOf */; }

        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType? IPAddressType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Type = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType)""); }

        /// <summary>Backing field for <see cref="ImageRegistryCredentials" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] _imageRegistryCredentials;

        /// <summary>The image registry credentials by which the container group is created from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] ImageRegistryCredentials { get => this._imageRegistryCredentials; set => this._imageRegistryCredentials = value; }

        /// <summary>Backing field for <see cref="InitContainer" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] _initContainer;

        /// <summary>The init containers for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] InitContainer { get => this._initContainer; set => this._initContainer = value; }

        /// <summary>Backing field for <see cref="InstanceView" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView _instanceView;

        /// <summary>The instance view of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupPropertiesInstanceView()); }

        /// <summary>The events of this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal)InstanceView).Event; }

        /// <summary>The state of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string InstanceViewState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal)InstanceView).State; }

        /// <summary>The log type to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogAnalyticLogType { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticLogType; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticLogType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType)""); }

        /// <summary>Metadata for log analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata LogAnalyticMetadata { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticMetadata; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticMetadata = value ?? null /* model class */; }

        /// <summary>The workspace id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LogAnalyticWorkspaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticWorkspaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticWorkspaceId = value ?? null; }

        /// <summary>The workspace key for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string LogAnalyticWorkspaceKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticWorkspaceKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticWorkspaceKey = value ?? null; }

        /// <summary>The workspace resource id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId LogAnalyticWorkspaceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticWorkspaceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalyticWorkspaceResourceId = value ?? null /* model class */; }

        /// <summary>Internal Acessors for Diagnostic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.Diagnostic { get => (this._diagnostic = this._diagnostic ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupDiagnostics()); set { {_diagnostic = value;} } }

        /// <summary>Internal Acessors for DiagnosticLogAnalytic</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.DiagnosticLogAnalytic { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalytic; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnosticsInternal)Diagnostic).LogAnalytic = value; }

        /// <summary>Internal Acessors for DnsConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.DnsConfig { get => (this._dnsConfig = this._dnsConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.DnsConfiguration()); set { {_dnsConfig = value;} } }

        /// <summary>Internal Acessors for EncryptionProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.EncryptionProperty { get => (this._encryptionProperty = this._encryptionProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EncryptionProperties()); set { {_encryptionProperty = value;} } }

        /// <summary>Internal Acessors for IPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.IPAddress { get => (this._iPAddress = this._iPAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPAddress()); set { {_iPAddress = value;} } }

        /// <summary>Internal Acessors for IPAddressFqdn</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.IPAddressFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddressInternal)IPAddress).Fqdn = value; }

        /// <summary>Internal Acessors for InstanceView</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.InstanceView { get => (this._instanceView = this._instanceView ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupPropertiesInstanceView()); set { {_instanceView = value;} } }

        /// <summary>Internal Acessors for InstanceViewEvent</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.InstanceViewEvent { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal)InstanceView).Event; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal)InstanceView).Event = value; }

        /// <summary>Internal Acessors for InstanceViewState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.InstanceViewState { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal)InstanceView).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceViewInternal)InstanceView).State = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupNetworkProfile()); set { {_networkProfile = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile _networkProfile;

        /// <summary>The network profile information for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ContainerGroupNetworkProfile()); set => this._networkProfile = value; }

        /// <summary>The identifier for a network profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Inlined)]
        public string NetworkProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfileInternal)NetworkProfile).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfileInternal)NetworkProfile).Id = value ?? null; }

        /// <summary>Backing field for <see cref="OSType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes _oSType;

        /// <summary>The operating system type required by the containers in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes OSType { get => this._oSType; set => this._oSType = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="RestartPolicy" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? _restartPolicy;

        /// <summary>
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? RestartPolicy { get => this._restartPolicy; set => this._restartPolicy = value; }

        /// <summary>Backing field for <see cref="Sku" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? _sku;

        /// <summary>The SKU for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? Sku { get => this._sku; set => this._sku = value; }

        /// <summary>Backing field for <see cref="Volume" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] _volume;

        /// <summary>The list of volumes that can be mounted by containers in this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] Volume { get => this._volume; set => this._volume = value; }

        /// <summary>Creates an new <see cref="ContainerGroupProperties" /> instance.</summary>
        public ContainerGroupProperties()
        {

        }
    }
    /// The container group properties
    public partial interface IContainerGroupProperties :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The containers within the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The containers within the container group.",
        SerializedName = @"containers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] Container { get; set; }
        /// <summary>The DNS servers for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS servers for the container group.",
        SerializedName = @"nameServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsConfigNameServer { get; set; }
        /// <summary>The DNS options for the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS options for the container group.",
        SerializedName = @"options",
        PossibleTypes = new [] { typeof(string) })]
        string DnsConfigOption { get; set; }
        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The DNS search domains for hostname lookup in the container group.",
        SerializedName = @"searchDomains",
        PossibleTypes = new [] { typeof(string) })]
        string DnsConfigSearchDomain { get; set; }
        /// <summary>The encryption key name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption key name.",
        SerializedName = @"keyName",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionPropertyKeyName { get; set; }
        /// <summary>The encryption key version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The encryption key version.",
        SerializedName = @"keyVersion",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionPropertyKeyVersion { get; set; }
        /// <summary>The keyvault base url.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The keyvault base url.",
        SerializedName = @"vaultBaseUrl",
        PossibleTypes = new [] { typeof(string) })]
        string EncryptionPropertyVaultBaseUrl { get; set; }
        /// <summary>The Dns name label for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Dns name label for the IP.",
        SerializedName = @"dnsNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressDnsNameLabel { get; set; }
        /// <summary>The FQDN for the IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The FQDN for the IP.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressFqdn { get;  }
        /// <summary>The IP exposed to the public internet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP exposed to the public internet.",
        SerializedName = @"ip",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddressIP { get; set; }
        /// <summary>The list of ports exposed on the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of ports exposed on the container group.",
        SerializedName = @"ports",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] IPAddressPort { get; set; }
        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies if the IP is exposed to the public internet or private VNET.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType? IPAddressType { get; set; }
        /// <summary>The image registry credentials by which the container group is created from.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The image registry credentials by which the container group is created from.",
        SerializedName = @"imageRegistryCredentials",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] ImageRegistryCredentials { get; set; }
        /// <summary>The init containers for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The init containers for a container group.",
        SerializedName = @"initContainers",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] InitContainer { get; set; }
        /// <summary>The events of this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The events of this container group.",
        SerializedName = @"events",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get;  }
        /// <summary>The state of the container group. Only valid in response.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The state of the container group. Only valid in response.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string InstanceViewState { get;  }
        /// <summary>The log type to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The log type to be used.",
        SerializedName = @"logType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogAnalyticLogType { get; set; }
        /// <summary>Metadata for log analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metadata for log analytics.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata LogAnalyticMetadata { get; set; }
        /// <summary>The workspace id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace id for log analytics",
        SerializedName = @"workspaceId",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticWorkspaceId { get; set; }
        /// <summary>The workspace key for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace key for log analytics",
        SerializedName = @"workspaceKey",
        PossibleTypes = new [] { typeof(string) })]
        string LogAnalyticWorkspaceKey { get; set; }
        /// <summary>The workspace resource id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace resource id for log analytics",
        SerializedName = @"workspaceResourceId",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId LogAnalyticWorkspaceResourceId { get; set; }
        /// <summary>The identifier for a network profile.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The identifier for a network profile.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileId { get; set; }
        /// <summary>The operating system type required by the containers in the container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The operating system type required by the containers in the container group.",
        SerializedName = @"osType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes OSType { get; set; }
        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the container group. This only appears in the response.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Restart policy for all containers within the container group.
        - `Always` Always restart
        - `OnFailure` Restart on failure
        - `Never` Never restart
        ",
        SerializedName = @"restartPolicy",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? RestartPolicy { get; set; }
        /// <summary>The SKU for a container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The SKU for a container group.",
        SerializedName = @"sku",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? Sku { get; set; }
        /// <summary>The list of volumes that can be mounted by containers in this container group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of volumes that can be mounted by containers in this container group.",
        SerializedName = @"volumes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] Volume { get; set; }

    }
    /// The container group properties
    internal partial interface IContainerGroupPropertiesInternal

    {
        /// <summary>The containers within the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainer[] Container { get; set; }
        /// <summary>The diagnostic information for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupDiagnostics Diagnostic { get; set; }
        /// <summary>Container group log analytics information.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics DiagnosticLogAnalytic { get; set; }
        /// <summary>The DNS config information for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IDnsConfiguration DnsConfig { get; set; }
        /// <summary>The DNS servers for the container group.</summary>
        string[] DnsConfigNameServer { get; set; }
        /// <summary>The DNS options for the container group.</summary>
        string DnsConfigOption { get; set; }
        /// <summary>The DNS search domains for hostname lookup in the container group.</summary>
        string DnsConfigSearchDomain { get; set; }
        /// <summary>The encryption properties for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEncryptionProperties EncryptionProperty { get; set; }
        /// <summary>The encryption key name.</summary>
        string EncryptionPropertyKeyName { get; set; }
        /// <summary>The encryption key version.</summary>
        string EncryptionPropertyKeyVersion { get; set; }
        /// <summary>The keyvault base url.</summary>
        string EncryptionPropertyVaultBaseUrl { get; set; }
        /// <summary>The IP address type of the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IIPAddress IPAddress { get; set; }
        /// <summary>The Dns name label for the IP.</summary>
        string IPAddressDnsNameLabel { get; set; }
        /// <summary>The FQDN for the IP.</summary>
        string IPAddressFqdn { get; set; }
        /// <summary>The IP exposed to the public internet.</summary>
        string IPAddressIP { get; set; }
        /// <summary>The list of ports exposed on the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IPort[] IPAddressPort { get; set; }
        /// <summary>Specifies if the IP is exposed to the public internet or private VNET.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupIPAddressType? IPAddressType { get; set; }
        /// <summary>The image registry credentials by which the container group is created from.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IImageRegistryCredential[] ImageRegistryCredentials { get; set; }
        /// <summary>The init containers for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IInitContainerDefinition[] InitContainer { get; set; }
        /// <summary>The instance view of the container group. Only valid in response.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupPropertiesInstanceView InstanceView { get; set; }
        /// <summary>The events of this container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEvent[] InstanceViewEvent { get; set; }
        /// <summary>The state of the container group. Only valid in response.</summary>
        string InstanceViewState { get; set; }
        /// <summary>The log type to be used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogAnalyticLogType { get; set; }
        /// <summary>Metadata for log analytics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata LogAnalyticMetadata { get; set; }
        /// <summary>The workspace id for log analytics</summary>
        string LogAnalyticWorkspaceId { get; set; }
        /// <summary>The workspace key for log analytics</summary>
        string LogAnalyticWorkspaceKey { get; set; }
        /// <summary>The workspace resource id for log analytics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId LogAnalyticWorkspaceResourceId { get; set; }
        /// <summary>The network profile information for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerGroupNetworkProfile NetworkProfile { get; set; }
        /// <summary>The identifier for a network profile.</summary>
        string NetworkProfileId { get; set; }
        /// <summary>The operating system type required by the containers in the container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.OperatingSystemTypes OSType { get; set; }
        /// <summary>
        /// The provisioning state of the container group. This only appears in the response.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>
        /// Restart policy for all containers within the container group.
        /// - `Always` Always restart
        /// - `OnFailure` Restart on failure
        /// - `Never` Never restart
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupRestartPolicy? RestartPolicy { get; set; }
        /// <summary>The SKU for a container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.ContainerGroupSku? Sku { get; set; }
        /// <summary>The list of volumes that can be mounted by containers in this container group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolume[] Volume { get; set; }

    }
}