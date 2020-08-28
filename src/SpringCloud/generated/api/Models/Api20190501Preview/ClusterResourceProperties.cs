namespace Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Extensions;

    /// <summary>Service properties payload</summary>
    public partial class ClusterResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal
    {

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ConfigServerPropertiesErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).Code = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string ConfigServerPropertiesErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).Message = value; }

        /// <summary>Backing field for <see cref="ConfigServerProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties _configServerProperty;

        /// <summary>Config server git properties of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties ConfigServerProperty { get => (this._configServerProperty = this._configServerProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerProperties()); set => this._configServerProperty = value; }

        /// <summary>State of the config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? ConfigServerPropertyState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).State; }

        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyHostKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyHostKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyHostKey = value; }

        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyHostKeyAlgorithm { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyHostKeyAlgorithm; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyHostKeyAlgorithm = value; }

        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyLabel = value; }

        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyPassword { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyPassword; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyPassword = value; }

        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyPrivateKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyPrivateKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyPrivateKey = value; }

        /// <summary>Repositories of git.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyRepository; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyRepository = value; }

        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string[] GitPropertySearchPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertySearchPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertySearchPath = value; }

        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? GitPropertyStrictHostKeyChecking { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyStrictHostKeyChecking; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyStrictHostKeyChecking = value; }

        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyUri { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyUri; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyUri = value; }

        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string GitPropertyUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).GitPropertyUsername = value; }

        /// <summary>Internal Acessors for ConfigServerGitProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ConfigServerGitProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).ConfigServerGitProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).ConfigServerGitProperty = value; }

        /// <summary>Internal Acessors for ConfigServerProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ConfigServerProperty { get => (this._configServerProperty = this._configServerProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ConfigServerProperties()); set { {_configServerProperty = value;} } }

        /// <summary>Internal Acessors for ConfigServerPropertyConfigServer</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ConfigServerPropertyConfigServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).ConfigServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).ConfigServer = value; }

        /// <summary>Internal Acessors for ConfigServerPropertyError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ConfigServerPropertyError { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).Error = value; }

        /// <summary>Internal Acessors for ConfigServerPropertyState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ConfigServerPropertyState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerPropertiesInternal)ConfigServerProperty).State = value; }

        /// <summary>Internal Acessors for NetworkProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.NetworkProfile()); set { {_networkProfile = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for ServiceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.ServiceId { get => this._serviceId; set { {_serviceId = value;} } }

        /// <summary>Internal Acessors for Trace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.Trace { get => (this._trace = this._trace ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TraceProperties()); set { {_trace = value;} } }

        /// <summary>Internal Acessors for TraceError</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.TraceError { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Error; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Error = value; }

        /// <summary>Internal Acessors for TraceState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.TraceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).State = value; }

        /// <summary>Internal Acessors for Version</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IClusterResourcePropertiesInternal.Version { get => this._version; set { {_version = value;} } }

        /// <summary>Backing field for <see cref="NetworkProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile _networkProfile;

        /// <summary>Network profile of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile NetworkProfile { get => (this._networkProfile = this._networkProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.NetworkProfile()); set => this._networkProfile = value; }

        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Apps
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileAppNetworkResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).AppNetworkResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).AppNetworkResourceGroup = value; }

        /// <summary>Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileAppSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).AppSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).AppSubnetId = value; }

        /// <summary>Azure Spring Cloud service reserved CIDR</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceCidr { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).ServiceCidr; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).ServiceCidr = value; }

        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceRuntimeNetworkResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).ServiceRuntimeNetworkResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).ServiceRuntimeNetworkResourceGroup = value; }

        /// <summary>
        /// Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string NetworkProfileServiceRuntimeSubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).ServiceRuntimeSubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfileInternal)NetworkProfile).ServiceRuntimeSubnetId = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? _provisioningState;

        /// <summary>Provisioning state of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ServiceId" /> property.</summary>
        private string _serviceId;

        /// <summary>ServiceInstanceEntity GUID which uniquely identifies a created resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public string ServiceId { get => this._serviceId; }

        /// <summary>Backing field for <see cref="Trace" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties _trace;

        /// <summary>Trace properties of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties Trace { get => (this._trace = this._trace ?? new Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.TraceProperties()); set => this._trace = value; }

        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TraceAppInsightInstrumentationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).AppInsightInstrumentationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).AppInsightInstrumentationKey = value; }

        /// <summary>Indicates whether enable the tracing functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public bool? TraceEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Enabled = value; }

        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TraceErrorCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Code; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Code = value; }

        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public string TraceErrorMessage { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Message; set => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).Message = value; }

        /// <summary>State of the trace proxy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? TraceState { get => ((Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITracePropertiesInternal)Trace).State; }

        /// <summary>Backing field for <see cref="Version" /> property.</summary>
        private int? _version;

        /// <summary>Version of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Origin(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.PropertyOrigin.Owned)]
        public int? Version { get => this._version; }

        /// <summary>Creates an new <see cref="ClusterResourceProperties" /> instance.</summary>
        public ClusterResourceProperties()
        {

        }
    }
    /// Service properties payload
    public partial interface IClusterResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.IJsonSerializable
    {
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigServerPropertiesErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string ConfigServerPropertiesErrorMessage { get; set; }
        /// <summary>State of the config server.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the config server.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? ConfigServerPropertyState { get;  }
        /// <summary>Public sshKey of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Public sshKey of git repository.",
        SerializedName = @"hostKey",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyHostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SshKey algorithm of git repository.",
        SerializedName = @"hostKeyAlgorithm",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyHostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Label of the repository",
        SerializedName = @"label",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyLabel { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Password of git repository basic auth.",
        SerializedName = @"password",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyPassword { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Private sshKey algorithm of git repository.",
        SerializedName = @"privateKey",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyPrivateKey { get; set; }
        /// <summary>Repositories of git.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Repositories of git.",
        SerializedName = @"repositories",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get; set; }
        /// <summary>Searching path of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Searching path of the repository",
        SerializedName = @"searchPaths",
        PossibleTypes = new [] { typeof(string) })]
        string[] GitPropertySearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Strict host key checking or not.",
        SerializedName = @"strictHostKeyChecking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? GitPropertyStrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"URI of the repository",
        SerializedName = @"uri",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyUri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Username of git repository basic auth.",
        SerializedName = @"username",
        PossibleTypes = new [] { typeof(string) })]
        string GitPropertyUsername { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Apps
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource group containing network resources of Azure Spring Cloud Apps",
        SerializedName = @"appNetworkResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileAppNetworkResourceGroup { get; set; }
        /// <summary>Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps",
        SerializedName = @"appSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileAppSubnetId { get; set; }
        /// <summary>Azure Spring Cloud service reserved CIDR</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Azure Spring Cloud service reserved CIDR",
        SerializedName = @"serviceCidr",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceCidr { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the resource group containing network resources of Azure Spring Cloud Service Runtime",
        SerializedName = @"serviceRuntimeNetworkResourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceRuntimeNetworkResourceGroup { get; set; }
        /// <summary>
        /// Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime",
        SerializedName = @"serviceRuntimeSubnetId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkProfileServiceRuntimeSubnetId { get; set; }
        /// <summary>Provisioning state of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning state of the Service",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>ServiceInstanceEntity GUID which uniquely identifies a created resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ServiceInstanceEntity GUID which uniquely identifies a created resource",
        SerializedName = @"serviceId",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceId { get;  }
        /// <summary>Target application insight instrumentation key</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Target application insight instrumentation key",
        SerializedName = @"appInsightInstrumentationKey",
        PossibleTypes = new [] { typeof(string) })]
        string TraceAppInsightInstrumentationKey { get; set; }
        /// <summary>Indicates whether enable the tracing functionality</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether enable the tracing functionality",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? TraceEnabled { get; set; }
        /// <summary>The code of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The code of error.",
        SerializedName = @"code",
        PossibleTypes = new [] { typeof(string) })]
        string TraceErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The message of error.",
        SerializedName = @"message",
        PossibleTypes = new [] { typeof(string) })]
        string TraceErrorMessage { get; set; }
        /// <summary>State of the trace proxy.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State of the trace proxy.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState) })]
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? TraceState { get;  }
        /// <summary>Version of the Service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Version of the Service",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? Version { get;  }

    }
    /// Service properties payload
    public partial interface IClusterResourcePropertiesInternal

    {
        /// <summary>Property of git environment.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerGitProperty ConfigServerGitProperty { get; set; }
        /// <summary>The code of error.</summary>
        string ConfigServerPropertiesErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        string ConfigServerPropertiesErrorMessage { get; set; }
        /// <summary>Config server git properties of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerProperties ConfigServerProperty { get; set; }
        /// <summary>Settings of config server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IConfigServerSettings ConfigServerPropertyConfigServer { get; set; }
        /// <summary>Error when apply config server settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError ConfigServerPropertyError { get; set; }
        /// <summary>State of the config server.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ConfigServerState? ConfigServerPropertyState { get; set; }
        /// <summary>Public sshKey of git repository.</summary>
        string GitPropertyHostKey { get; set; }
        /// <summary>SshKey algorithm of git repository.</summary>
        string GitPropertyHostKeyAlgorithm { get; set; }
        /// <summary>Label of the repository</summary>
        string GitPropertyLabel { get; set; }
        /// <summary>Password of git repository basic auth.</summary>
        string GitPropertyPassword { get; set; }
        /// <summary>Private sshKey algorithm of git repository.</summary>
        string GitPropertyPrivateKey { get; set; }
        /// <summary>Repositories of git.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IGitPatternRepository[] GitPropertyRepository { get; set; }
        /// <summary>Searching path of the repository</summary>
        string[] GitPropertySearchPath { get; set; }
        /// <summary>Strict host key checking or not.</summary>
        bool? GitPropertyStrictHostKeyChecking { get; set; }
        /// <summary>URI of the repository</summary>
        string GitPropertyUri { get; set; }
        /// <summary>Username of git repository basic auth.</summary>
        string GitPropertyUsername { get; set; }
        /// <summary>Network profile of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.INetworkProfile NetworkProfile { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Apps
        /// </summary>
        string NetworkProfileAppNetworkResourceGroup { get; set; }
        /// <summary>Fully qualified resource Id of the subnet to host Azure Spring Cloud Apps</summary>
        string NetworkProfileAppSubnetId { get; set; }
        /// <summary>Azure Spring Cloud service reserved CIDR</summary>
        string NetworkProfileServiceCidr { get; set; }
        /// <summary>
        /// Name of the resource group containing network resources of Azure Spring Cloud Service Runtime
        /// </summary>
        string NetworkProfileServiceRuntimeNetworkResourceGroup { get; set; }
        /// <summary>
        /// Fully qualified resource Id of the subnet to host Azure Spring Cloud Service Runtime
        /// </summary>
        string NetworkProfileServiceRuntimeSubnetId { get; set; }
        /// <summary>Provisioning state of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>ServiceInstanceEntity GUID which uniquely identifies a created resource</summary>
        string ServiceId { get; set; }
        /// <summary>Trace properties of the Service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.ITraceProperties Trace { get; set; }
        /// <summary>Target application insight instrumentation key</summary>
        string TraceAppInsightInstrumentationKey { get; set; }
        /// <summary>Indicates whether enable the tracing functionality</summary>
        bool? TraceEnabled { get; set; }
        /// <summary>Error when apply trace proxy changes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IError TraceError { get; set; }
        /// <summary>The code of error.</summary>
        string TraceErrorCode { get; set; }
        /// <summary>The message of error.</summary>
        string TraceErrorMessage { get; set; }
        /// <summary>State of the trace proxy.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.TraceProxyState? TraceState { get; set; }
        /// <summary>Version of the Service</summary>
        int? Version { get; set; }

    }
}