namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Configuration of an App Service app.</summary>
    public partial class SiteConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal
    {

        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActionMinProcessExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).ActionMinProcessExecutionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).ActionMinProcessExecutionTime = value; }

        /// <summary>Predefined action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).ActionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).ActionType = value; }

        /// <summary>Backing field for <see cref="AlwaysOn" /> property.</summary>
        private bool? _alwaysOn;

        /// <summary><code>true</code> if Always On is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AlwaysOn { get => this._alwaysOn; set => this._alwaysOn = value; }

        /// <summary>Backing field for <see cref="ApiDefinition" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfo _apiDefinition;

        /// <summary>Information about the formal API definition for the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfo ApiDefinition { get => (this._apiDefinition = this._apiDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApiDefinitionInfo()); set => this._apiDefinition = value; }

        /// <summary>The URL of the API definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApiDefinitionUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfoInternal)ApiDefinition).Url; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfoInternal)ApiDefinition).Url = value; }

        /// <summary>Backing field for <see cref="ApiManagementConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfig _apiManagementConfig;

        /// <summary>Azure API management settings linked to the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfig ApiManagementConfig { get => (this._apiManagementConfig = this._apiManagementConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApiManagementConfig()); set => this._apiManagementConfig = value; }

        /// <summary>APIM-Api Identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApiManagementConfigId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfigInternal)ApiManagementConfig).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfigInternal)ApiManagementConfig).Id = value; }

        /// <summary>Backing field for <see cref="AppCommandLine" /> property.</summary>
        private string _appCommandLine;

        /// <summary>App command line to launch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AppCommandLine { get => this._appCommandLine; set => this._appCommandLine = value; }

        /// <summary>Backing field for <see cref="AppSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] _appSetting;

        /// <summary>Application settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] AppSetting { get => this._appSetting; set => this._appSetting = value; }

        /// <summary>Backing field for <see cref="AutoHealEnabled" /> property.</summary>
        private bool? _autoHealEnabled;

        /// <summary><code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? AutoHealEnabled { get => this._autoHealEnabled; set => this._autoHealEnabled = value; }

        /// <summary>Backing field for <see cref="AutoHealRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules _autoHealRule;

        /// <summary>Auto Heal rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules AutoHealRule { get => (this._autoHealRule = this._autoHealRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules()); set => this._autoHealRule = value; }

        /// <summary>Backing field for <see cref="AutoSwapSlotName" /> property.</summary>
        private string _autoSwapSlotName;

        /// <summary>Auto-swap slot name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string AutoSwapSlotName { get => this._autoSwapSlotName; set => this._autoSwapSlotName = value; }

        /// <summary>Backing field for <see cref="ConnectionString" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[] _connectionString;

        /// <summary>Connection strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[] ConnectionString { get => this._connectionString; set => this._connectionString = value; }

        /// <summary>Backing field for <see cref="Cor" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettings _cor;

        /// <summary>Cross-Origin Resource Sharing (CORS) settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettings Cor { get => (this._cor = this._cor ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CorsSettings()); set => this._cor = value; }

        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] CorAllowedOrigin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettingsInternal)Cor).AllowedOrigin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettingsInternal)Cor).AllowedOrigin = value; }

        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CorSupportCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettingsInternal)Cor).SupportCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettingsInternal)Cor).SupportCredentials = value; }

        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionExe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).CustomActionExe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).CustomActionExe = value; }

        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).CustomActionParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).CustomActionParameter = value; }

        /// <summary>Backing field for <see cref="DefaultDocument" /> property.</summary>
        private string[] _defaultDocument;

        /// <summary>Default documents.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] DefaultDocument { get => this._defaultDocument; set => this._defaultDocument = value; }

        /// <summary>Backing field for <see cref="DetailedErrorLoggingEnabled" /> property.</summary>
        private bool? _detailedErrorLoggingEnabled;

        /// <summary>
        /// <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? DetailedErrorLoggingEnabled { get => this._detailedErrorLoggingEnabled; set => this._detailedErrorLoggingEnabled = value; }

        /// <summary>Backing field for <see cref="DocumentRoot" /> property.</summary>
        private string _documentRoot;

        /// <summary>Document root.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DocumentRoot { get => this._documentRoot; set => this._documentRoot = value; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DynamicTagsJson { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).DynamicTagsJson; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).DynamicTagsJson = value; }

        /// <summary>Backing field for <see cref="Experiment" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperiments _experiment;

        /// <summary>This is work around for polymorphic types.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperiments Experiment { get => (this._experiment = this._experiment ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Experiments()); set => this._experiment = value; }

        /// <summary>List of ramp-up rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] ExperimentRampUpRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperimentsInternal)Experiment).RampUpRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperimentsInternal)Experiment).RampUpRule = value; }

        /// <summary>Backing field for <see cref="FtpsState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState? _ftpsState;

        /// <summary>State of FTP / FTPS service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState? FtpsState { get => this._ftpsState; set => this._ftpsState = value; }

        /// <summary>Backing field for <see cref="HandlerMapping" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[] _handlerMapping;

        /// <summary>Handler mappings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[] HandlerMapping { get => this._handlerMapping; set => this._handlerMapping = value; }

        /// <summary>Backing field for <see cref="HealthCheckPath" /> property.</summary>
        private string _healthCheckPath;

        /// <summary>Health check path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HealthCheckPath { get => this._healthCheckPath; set => this._healthCheckPath = value; }

        /// <summary>Backing field for <see cref="Http20Enabled" /> property.</summary>
        private bool? _http20Enabled;

        /// <summary>Http20Enabled: configures a web site to allow clients to connect over http2.0</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Http20Enabled { get => this._http20Enabled; set => this._http20Enabled = value; }

        /// <summary>Backing field for <see cref="HttpLoggingEnabled" /> property.</summary>
        private bool? _httpLoggingEnabled;

        /// <summary><code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HttpLoggingEnabled { get => this._httpLoggingEnabled; set => this._httpLoggingEnabled = value; }

        /// <summary>Backing field for <see cref="IPSecurityRestriction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] _iPSecurityRestriction;

        /// <summary>IP security restrictions for main.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] IPSecurityRestriction { get => this._iPSecurityRestriction; set => this._iPSecurityRestriction = value; }

        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool IsPushEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).IsPushEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).IsPushEnabled = value; }

        /// <summary>Backing field for <see cref="JavaContainer" /> property.</summary>
        private string _javaContainer;

        /// <summary>Java container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string JavaContainer { get => this._javaContainer; set => this._javaContainer = value; }

        /// <summary>Backing field for <see cref="JavaContainerVersion" /> property.</summary>
        private string _javaContainerVersion;

        /// <summary>Java container version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string JavaContainerVersion { get => this._javaContainerVersion; set => this._javaContainerVersion = value; }

        /// <summary>Backing field for <see cref="JavaVersion" /> property.</summary>
        private string _javaVersion;

        /// <summary>Java version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string JavaVersion { get => this._javaVersion; set => this._javaVersion = value; }

        /// <summary>Backing field for <see cref="Limit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimits _limit;

        /// <summary>Site limits.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimits Limit { get => (this._limit = this._limit ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLimits()); set => this._limit = value; }

        /// <summary>Maximum allowed disk size usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? LimitMaxDiskSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal)Limit).MaxDiskSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal)Limit).MaxDiskSizeInMb = value; }

        /// <summary>Maximum allowed memory usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? LimitMaxMemoryInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal)Limit).MaxMemoryInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal)Limit).MaxMemoryInMb = value; }

        /// <summary>Maximum allowed CPU usage percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? LimitMaxPercentageCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal)Limit).MaxPercentageCpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimitsInternal)Limit).MaxPercentageCpu = value; }

        /// <summary>Backing field for <see cref="LinuxFxVersion" /> property.</summary>
        private string _linuxFxVersion;

        /// <summary>Linux App Framework and version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string LinuxFxVersion { get => this._linuxFxVersion; set => this._linuxFxVersion = value; }

        /// <summary>Backing field for <see cref="LoadBalancing" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing? _loadBalancing;

        /// <summary>Site load balancing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing? LoadBalancing { get => this._loadBalancing; set => this._loadBalancing = value; }

        /// <summary>Backing field for <see cref="LocalMySqlEnabled" /> property.</summary>
        private bool? _localMySqlEnabled;

        /// <summary><code>true</code> to enable local MySQL; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? LocalMySqlEnabled { get => this._localMySqlEnabled; set => this._localMySqlEnabled = value; }

        /// <summary>Backing field for <see cref="LogsDirectorySizeLimit" /> property.</summary>
        private int? _logsDirectorySizeLimit;

        /// <summary>HTTP logs directory size limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? LogsDirectorySizeLimit { get => this._logsDirectorySizeLimit; set => this._logsDirectorySizeLimit = value; }

        /// <summary>Backing field for <see cref="MachineKey" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKey _machineKey;

        /// <summary>Site MachineKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKey MachineKey { get => (this._machineKey = this._machineKey ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteMachineKey()); }

        /// <summary>Algorithm used for decryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyDecryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).Decryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).Decryption = value; }

        /// <summary>Decryption key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyDecryptionKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).DecryptionKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).DecryptionKey = value; }

        /// <summary>MachineKey validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).Validation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).Validation = value; }

        /// <summary>Validation key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyValidationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).ValidationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKeyInternal)MachineKey).ValidationKey = value; }

        /// <summary>Backing field for <see cref="ManagedPipelineMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode? _managedPipelineMode;

        /// <summary>Managed pipeline mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode? ManagedPipelineMode { get => this._managedPipelineMode; set => this._managedPipelineMode = value; }

        /// <summary>Backing field for <see cref="ManagedServiceIdentityId" /> property.</summary>
        private int? _managedServiceIdentityId;

        /// <summary>Managed Service Identity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ManagedServiceIdentityId { get => this._managedServiceIdentityId; set => this._managedServiceIdentityId = value; }

        /// <summary>Internal Acessors for ActionCustomAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.ActionCustomAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).ActionCustomAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).ActionCustomAction = value; }

        /// <summary>Internal Acessors for ApiDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.ApiDefinition { get => (this._apiDefinition = this._apiDefinition ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApiDefinitionInfo()); set { {_apiDefinition = value;} } }

        /// <summary>Internal Acessors for ApiManagementConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.ApiManagementConfig { get => (this._apiManagementConfig = this._apiManagementConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ApiManagementConfig()); set { {_apiManagementConfig = value;} } }

        /// <summary>Internal Acessors for AutoHealRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.AutoHealRule { get => (this._autoHealRule = this._autoHealRule ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.AutoHealRules()); set { {_autoHealRule = value;} } }

        /// <summary>Internal Acessors for AutoHealRuleAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.AutoHealRuleAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).Action; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).Action = value; }

        /// <summary>Internal Acessors for AutoHealRuleTrigger</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.AutoHealRuleTrigger { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).Trigger; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).Trigger = value; }

        /// <summary>Internal Acessors for Cor</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettings Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.Cor { get => (this._cor = this._cor ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CorsSettings()); set { {_cor = value;} } }

        /// <summary>Internal Acessors for Experiment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperiments Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.Experiment { get => (this._experiment = this._experiment ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Experiments()); set { {_experiment = value;} } }

        /// <summary>Internal Acessors for Limit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimits Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.Limit { get => (this._limit = this._limit ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteLimits()); set { {_limit = value;} } }

        /// <summary>Internal Acessors for MachineKey</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKey Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.MachineKey { get => (this._machineKey = this._machineKey ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteMachineKey()); set { {_machineKey = value;} } }

        /// <summary>Internal Acessors for Push</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettings Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.Push { get => (this._push = this._push ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PushSettings()); set { {_push = value;} } }

        /// <summary>Internal Acessors for PushId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.PushId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Id = value; }

        /// <summary>Internal Acessors for PushName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.PushName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Name = value; }

        /// <summary>Internal Acessors for PushProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.PushProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).Property = value; }

        /// <summary>Internal Acessors for PushType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.PushType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Type = value; }

        /// <summary>Internal Acessors for TriggerRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.TriggerRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerRequest = value; }

        /// <summary>Internal Acessors for TriggerSlowRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal.TriggerSlowRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerSlowRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerSlowRequest = value; }

        /// <summary>Backing field for <see cref="MinTlsVersion" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions? _minTlsVersion;

        /// <summary>MinTlsVersion: configures the minimum version of TLS required for SSL requests</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions? MinTlsVersion { get => this._minTlsVersion; set => this._minTlsVersion = value; }

        /// <summary>Backing field for <see cref="NetFrameworkVersion" /> property.</summary>
        private string _netFrameworkVersion;

        /// <summary>.NET Framework version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NetFrameworkVersion { get => this._netFrameworkVersion; set => this._netFrameworkVersion = value; }

        /// <summary>Backing field for <see cref="NodeVersion" /> property.</summary>
        private string _nodeVersion;

        /// <summary>Version of Node.js.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string NodeVersion { get => this._nodeVersion; set => this._nodeVersion = value; }

        /// <summary>Backing field for <see cref="NumberOfWorker" /> property.</summary>
        private int? _numberOfWorker;

        /// <summary>Number of workers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? NumberOfWorker { get => this._numberOfWorker; set => this._numberOfWorker = value; }

        /// <summary>Backing field for <see cref="PhpVersion" /> property.</summary>
        private string _phpVersion;

        /// <summary>Version of PHP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PhpVersion { get => this._phpVersion; set => this._phpVersion = value; }

        /// <summary>Backing field for <see cref="PowerShellVersion" /> property.</summary>
        private string _powerShellVersion;

        /// <summary>Version of PowerShell.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PowerShellVersion { get => this._powerShellVersion; set => this._powerShellVersion = value; }

        /// <summary>Backing field for <see cref="PreWarmedInstanceCount" /> property.</summary>
        private int? _preWarmedInstanceCount;

        /// <summary>
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? PreWarmedInstanceCount { get => this._preWarmedInstanceCount; set => this._preWarmedInstanceCount = value; }

        /// <summary>Backing field for <see cref="PublishingUsername" /> property.</summary>
        private string _publishingUsername;

        /// <summary>Publishing user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PublishingUsername { get => this._publishingUsername; set => this._publishingUsername = value; }

        /// <summary>Backing field for <see cref="Push" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettings _push;

        /// <summary>Push endpoint settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettings Push { get => (this._push = this._push ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.PushSettings()); set => this._push = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Id; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Kind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Name; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)Push).Type; }

        /// <summary>Backing field for <see cref="PythonVersion" /> property.</summary>
        private string _pythonVersion;

        /// <summary>Version of Python.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PythonVersion { get => this._pythonVersion; set => this._pythonVersion = value; }

        /// <summary>Backing field for <see cref="RemoteDebuggingEnabled" /> property.</summary>
        private bool? _remoteDebuggingEnabled;

        /// <summary>
        /// <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? RemoteDebuggingEnabled { get => this._remoteDebuggingEnabled; set => this._remoteDebuggingEnabled = value; }

        /// <summary>Backing field for <see cref="RemoteDebuggingVersion" /> property.</summary>
        private string _remoteDebuggingVersion;

        /// <summary>Remote debugging version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RemoteDebuggingVersion { get => this._remoteDebuggingVersion; set => this._remoteDebuggingVersion = value; }

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? RequestCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).RequestCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).RequestCount = value; }

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RequestTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).RequestTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).RequestTimeInterval = value; }

        /// <summary>Backing field for <see cref="RequestTracingEnabled" /> property.</summary>
        private bool? _requestTracingEnabled;

        /// <summary><code>true</code> if request tracing is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? RequestTracingEnabled { get => this._requestTracingEnabled; set => this._requestTracingEnabled = value; }

        /// <summary>Backing field for <see cref="RequestTracingExpirationTime" /> property.</summary>
        private global::System.DateTime? _requestTracingExpirationTime;

        /// <summary>Request tracing expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? RequestTracingExpirationTime { get => this._requestTracingExpirationTime; set => this._requestTracingExpirationTime = value; }

        /// <summary>Backing field for <see cref="ScmIPSecurityRestriction" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] _scmIPSecurityRestriction;

        /// <summary>IP security restrictions for scm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] ScmIPSecurityRestriction { get => this._scmIPSecurityRestriction; set => this._scmIPSecurityRestriction = value; }

        /// <summary>Backing field for <see cref="ScmIPSecurityRestrictionsUseMain" /> property.</summary>
        private bool? _scmIPSecurityRestrictionsUseMain;

        /// <summary>IP security restrictions for scm to use main.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ScmIPSecurityRestrictionsUseMain { get => this._scmIPSecurityRestrictionsUseMain; set => this._scmIPSecurityRestrictionsUseMain = value; }

        /// <summary>Backing field for <see cref="ScmType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType? _scmType;

        /// <summary>SCM type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType? ScmType { get => this._scmType; set => this._scmType = value; }

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SlowRequestCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).SlowRequestCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).SlowRequestCount = value; }

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlowRequestTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).SlowRequestTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).SlowRequestTimeInterval = value; }

        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlowRequestTimeTaken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).SlowRequestTimeTaken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).SlowRequestTimeTaken = value; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TagWhitelistJson { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).TagWhitelistJson; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).TagWhitelistJson = value; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TagsRequiringAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).TagsRequiringAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsInternal)Push).TagsRequiringAuth = value; }

        /// <summary>Backing field for <see cref="TracingOption" /> property.</summary>
        private string _tracingOption;

        /// <summary>Tracing options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TracingOption { get => this._tracingOption; set => this._tracingOption = value; }

        /// <summary>A rule based on private bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? TriggerPrivateBytesInKb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerPrivateBytesInKb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerPrivateBytesInKb = value; }

        /// <summary>A rule based on status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerStatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRulesInternal)AutoHealRule).TriggerStatusCode = value; }

        /// <summary>Backing field for <see cref="Use32BitWorkerProcess" /> property.</summary>
        private bool? _use32BitWorkerProcess;

        /// <summary><code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Use32BitWorkerProcess { get => this._use32BitWorkerProcess; set => this._use32BitWorkerProcess = value; }

        /// <summary>Backing field for <see cref="VirtualApplication" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[] _virtualApplication;

        /// <summary>Virtual applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[] VirtualApplication { get => this._virtualApplication; set => this._virtualApplication = value; }

        /// <summary>Backing field for <see cref="VnetName" /> property.</summary>
        private string _vnetName;

        /// <summary>Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string VnetName { get => this._vnetName; set => this._vnetName = value; }

        /// <summary>Backing field for <see cref="WebSocketsEnabled" /> property.</summary>
        private bool? _webSocketsEnabled;

        /// <summary><code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? WebSocketsEnabled { get => this._webSocketsEnabled; set => this._webSocketsEnabled = value; }

        /// <summary>Backing field for <see cref="WindowsFxVersion" /> property.</summary>
        private string _windowsFxVersion;

        /// <summary>Xenon App Framework and version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string WindowsFxVersion { get => this._windowsFxVersion; set => this._windowsFxVersion = value; }

        /// <summary>Backing field for <see cref="XManagedServiceIdentityId" /> property.</summary>
        private int? _xManagedServiceIdentityId;

        /// <summary>Explicit Managed Service Identity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? XManagedServiceIdentityId { get => this._xManagedServiceIdentityId; set => this._xManagedServiceIdentityId = value; }

        /// <summary>Creates an new <see cref="SiteConfig" /> instance.</summary>
        public SiteConfig()
        {

        }
    }
    /// Configuration of an App Service app.
    public partial interface ISiteConfig :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Minimum time the process must execute
        before taking the action",
        SerializedName = @"minProcessExecutionTime",
        PossibleTypes = new [] { typeof(string) })]
        string ActionMinProcessExecutionTime { get; set; }
        /// <summary>Predefined action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Predefined action to be taken.",
        SerializedName = @"actionType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get; set; }
        /// <summary><code>true</code> if Always On is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if Always On is enabled; otherwise, <code>false</code>.",
        SerializedName = @"alwaysOn",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AlwaysOn { get; set; }
        /// <summary>The URL of the API definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The URL of the API definition.",
        SerializedName = @"url",
        PossibleTypes = new [] { typeof(string) })]
        string ApiDefinitionUrl { get; set; }
        /// <summary>APIM-Api Identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"APIM-Api Identifier.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string ApiManagementConfigId { get; set; }
        /// <summary>App command line to launch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App command line to launch.",
        SerializedName = @"appCommandLine",
        PossibleTypes = new [] { typeof(string) })]
        string AppCommandLine { get; set; }
        /// <summary>Application settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application settings.",
        SerializedName = @"appSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] AppSetting { get; set; }
        /// <summary><code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.",
        SerializedName = @"autoHealEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AutoHealEnabled { get; set; }
        /// <summary>Auto-swap slot name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Auto-swap slot name.",
        SerializedName = @"autoSwapSlotName",
        PossibleTypes = new [] { typeof(string) })]
        string AutoSwapSlotName { get; set; }
        /// <summary>Connection strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Connection strings.",
        SerializedName = @"connectionStrings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[] ConnectionString { get; set; }
        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the list of origins that should be allowed to make cross-origin
        calls (for example: http://example.com:12345). Use ""*"" to allow all.",
        SerializedName = @"allowedOrigins",
        PossibleTypes = new [] { typeof(string) })]
        string[] CorAllowedOrigin { get; set; }
        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets whether CORS requests with credentials are allowed. See
        https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        for more details.",
        SerializedName = @"supportCredentials",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CorSupportCredentials { get; set; }
        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Executable to be run.",
        SerializedName = @"exe",
        PossibleTypes = new [] { typeof(string) })]
        string CustomActionExe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Parameters for the executable.",
        SerializedName = @"parameters",
        PossibleTypes = new [] { typeof(string) })]
        string CustomActionParameter { get; set; }
        /// <summary>Default documents.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Default documents.",
        SerializedName = @"defaultDocuments",
        PossibleTypes = new [] { typeof(string) })]
        string[] DefaultDocument { get; set; }
        /// <summary>
        /// <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.",
        SerializedName = @"detailedErrorLoggingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? DetailedErrorLoggingEnabled { get; set; }
        /// <summary>Document root.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Document root.",
        SerializedName = @"documentRoot",
        PossibleTypes = new [] { typeof(string) })]
        string DocumentRoot { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.",
        SerializedName = @"dynamicTagsJson",
        PossibleTypes = new [] { typeof(string) })]
        string DynamicTagsJson { get; set; }
        /// <summary>List of ramp-up rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of ramp-up rules.",
        SerializedName = @"rampUpRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] ExperimentRampUpRule { get; set; }
        /// <summary>State of FTP / FTPS service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"State of FTP / FTPS service",
        SerializedName = @"ftpsState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState? FtpsState { get; set; }
        /// <summary>Handler mappings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Handler mappings.",
        SerializedName = @"handlerMappings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[] HandlerMapping { get; set; }
        /// <summary>Health check path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Health check path",
        SerializedName = @"healthCheckPath",
        PossibleTypes = new [] { typeof(string) })]
        string HealthCheckPath { get; set; }
        /// <summary>Http20Enabled: configures a web site to allow clients to connect over http2.0</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Http20Enabled: configures a web site to allow clients to connect over http2.0",
        SerializedName = @"http20Enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Http20Enabled { get; set; }
        /// <summary><code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.",
        SerializedName = @"httpLoggingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HttpLoggingEnabled { get; set; }
        /// <summary>IP security restrictions for main.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP security restrictions for main.",
        SerializedName = @"ipSecurityRestrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] IPSecurityRestriction { get; set; }
        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets or sets a flag indicating whether the Push endpoint is enabled.",
        SerializedName = @"isPushEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool IsPushEnabled { get; set; }
        /// <summary>Java container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Java container.",
        SerializedName = @"javaContainer",
        PossibleTypes = new [] { typeof(string) })]
        string JavaContainer { get; set; }
        /// <summary>Java container version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Java container version.",
        SerializedName = @"javaContainerVersion",
        PossibleTypes = new [] { typeof(string) })]
        string JavaContainerVersion { get; set; }
        /// <summary>Java version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Java version.",
        SerializedName = @"javaVersion",
        PossibleTypes = new [] { typeof(string) })]
        string JavaVersion { get; set; }
        /// <summary>Maximum allowed disk size usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed disk size usage in MB.",
        SerializedName = @"maxDiskSizeInMb",
        PossibleTypes = new [] { typeof(long) })]
        long? LimitMaxDiskSizeInMb { get; set; }
        /// <summary>Maximum allowed memory usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed memory usage in MB.",
        SerializedName = @"maxMemoryInMb",
        PossibleTypes = new [] { typeof(long) })]
        long? LimitMaxMemoryInMb { get; set; }
        /// <summary>Maximum allowed CPU usage percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed CPU usage percentage.",
        SerializedName = @"maxPercentageCpu",
        PossibleTypes = new [] { typeof(double) })]
        double? LimitMaxPercentageCpu { get; set; }
        /// <summary>Linux App Framework and version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Linux App Framework and version",
        SerializedName = @"linuxFxVersion",
        PossibleTypes = new [] { typeof(string) })]
        string LinuxFxVersion { get; set; }
        /// <summary>Site load balancing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Site load balancing.",
        SerializedName = @"loadBalancing",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing? LoadBalancing { get; set; }
        /// <summary><code>true</code> to enable local MySQL; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to enable local MySQL; otherwise, <code>false</code>.",
        SerializedName = @"localMySqlEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? LocalMySqlEnabled { get; set; }
        /// <summary>HTTP logs directory size limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HTTP logs directory size limit.",
        SerializedName = @"logsDirectorySizeLimit",
        PossibleTypes = new [] { typeof(int) })]
        int? LogsDirectorySizeLimit { get; set; }
        /// <summary>Algorithm used for decryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Algorithm used for decryption.",
        SerializedName = @"decryption",
        PossibleTypes = new [] { typeof(string) })]
        string MachineKeyDecryption { get; set; }
        /// <summary>Decryption key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Decryption key.",
        SerializedName = @"decryptionKey",
        PossibleTypes = new [] { typeof(string) })]
        string MachineKeyDecryptionKey { get; set; }
        /// <summary>MachineKey validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MachineKey validation.",
        SerializedName = @"validation",
        PossibleTypes = new [] { typeof(string) })]
        string MachineKeyValidation { get; set; }
        /// <summary>Validation key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Validation key.",
        SerializedName = @"validationKey",
        PossibleTypes = new [] { typeof(string) })]
        string MachineKeyValidationKey { get; set; }
        /// <summary>Managed pipeline mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Managed pipeline mode.",
        SerializedName = @"managedPipelineMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode? ManagedPipelineMode { get; set; }
        /// <summary>Managed Service Identity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Managed Service Identity Id",
        SerializedName = @"managedServiceIdentityId",
        PossibleTypes = new [] { typeof(int) })]
        int? ManagedServiceIdentityId { get; set; }
        /// <summary>MinTlsVersion: configures the minimum version of TLS required for SSL requests</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"MinTlsVersion: configures the minimum version of TLS required for SSL requests",
        SerializedName = @"minTlsVersion",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions? MinTlsVersion { get; set; }
        /// <summary>.NET Framework version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @".NET Framework version.",
        SerializedName = @"netFrameworkVersion",
        PossibleTypes = new [] { typeof(string) })]
        string NetFrameworkVersion { get; set; }
        /// <summary>Version of Node.js.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of Node.js.",
        SerializedName = @"nodeVersion",
        PossibleTypes = new [] { typeof(string) })]
        string NodeVersion { get; set; }
        /// <summary>Number of workers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of workers.",
        SerializedName = @"numberOfWorkers",
        PossibleTypes = new [] { typeof(int) })]
        int? NumberOfWorker { get; set; }
        /// <summary>Version of PHP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of PHP.",
        SerializedName = @"phpVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PhpVersion { get; set; }
        /// <summary>Version of PowerShell.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of PowerShell.",
        SerializedName = @"powerShellVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PowerShellVersion { get; set; }
        /// <summary>
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of preWarmed instances.
        This setting only applies to the Consumption and Elastic Plans",
        SerializedName = @"preWarmedInstanceCount",
        PossibleTypes = new [] { typeof(int) })]
        int? PreWarmedInstanceCount { get; set; }
        /// <summary>Publishing user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Publishing user name.",
        SerializedName = @"publishingUsername",
        PossibleTypes = new [] { typeof(string) })]
        string PublishingUsername { get; set; }
        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Id.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PushId { get;  }
        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Kind of resource.",
        SerializedName = @"kind",
        PossibleTypes = new [] { typeof(string) })]
        string PushKind { get; set; }
        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource Name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string PushName { get;  }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string PushType { get;  }
        /// <summary>Version of Python.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Version of Python.",
        SerializedName = @"pythonVersion",
        PossibleTypes = new [] { typeof(string) })]
        string PythonVersion { get; set; }
        /// <summary>
        /// <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.",
        SerializedName = @"remoteDebuggingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RemoteDebuggingEnabled { get; set; }
        /// <summary>Remote debugging version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Remote debugging version.",
        SerializedName = @"remoteDebuggingVersion",
        PossibleTypes = new [] { typeof(string) })]
        string RemoteDebuggingVersion { get; set; }
        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? RequestCount { get; set; }
        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time interval.",
        SerializedName = @"timeInterval",
        PossibleTypes = new [] { typeof(string) })]
        string RequestTimeInterval { get; set; }
        /// <summary><code>true</code> if request tracing is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if request tracing is enabled; otherwise, <code>false</code>.",
        SerializedName = @"requestTracingEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RequestTracingEnabled { get; set; }
        /// <summary>Request tracing expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request tracing expiration time.",
        SerializedName = @"requestTracingExpirationTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? RequestTracingExpirationTime { get; set; }
        /// <summary>IP security restrictions for scm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP security restrictions for scm.",
        SerializedName = @"scmIpSecurityRestrictions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] ScmIPSecurityRestriction { get; set; }
        /// <summary>IP security restrictions for scm to use main.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"IP security restrictions for scm to use main.",
        SerializedName = @"scmIpSecurityRestrictionsUseMain",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ScmIPSecurityRestrictionsUseMain { get; set; }
        /// <summary>SCM type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"SCM type.",
        SerializedName = @"scmType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType? ScmType { get; set; }
        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Request Count.",
        SerializedName = @"count",
        PossibleTypes = new [] { typeof(int) })]
        int? SlowRequestCount { get; set; }
        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time interval.",
        SerializedName = @"timeInterval",
        PossibleTypes = new [] { typeof(string) })]
        string SlowRequestTimeInterval { get; set; }
        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Time taken.",
        SerializedName = @"timeTaken",
        PossibleTypes = new [] { typeof(string) })]
        string SlowRequestTimeTaken { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.",
        SerializedName = @"tagWhitelistJson",
        PossibleTypes = new [] { typeof(string) })]
        string TagWhitelistJson { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.
        Tags can consist of alphanumeric characters and the following:
        '_', '@', '#', '.', ':', '-'.
        Validation should be performed at the PushRequestHandler.",
        SerializedName = @"tagsRequiringAuth",
        PossibleTypes = new [] { typeof(string) })]
        string TagsRequiringAuth { get; set; }
        /// <summary>Tracing options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Tracing options.",
        SerializedName = @"tracingOptions",
        PossibleTypes = new [] { typeof(string) })]
        string TracingOption { get; set; }
        /// <summary>A rule based on private bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A rule based on private bytes.",
        SerializedName = @"privateBytesInKB",
        PossibleTypes = new [] { typeof(int) })]
        int? TriggerPrivateBytesInKb { get; set; }
        /// <summary>A rule based on status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A rule based on status codes.",
        SerializedName = @"statusCodes",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get; set; }
        /// <summary><code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.",
        SerializedName = @"use32BitWorkerProcess",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Use32BitWorkerProcess { get; set; }
        /// <summary>Virtual applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual applications.",
        SerializedName = @"virtualApplications",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[] VirtualApplication { get; set; }
        /// <summary>Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Virtual Network name.",
        SerializedName = @"vnetName",
        PossibleTypes = new [] { typeof(string) })]
        string VnetName { get; set; }
        /// <summary><code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.",
        SerializedName = @"webSocketsEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? WebSocketsEnabled { get; set; }
        /// <summary>Xenon App Framework and version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Xenon App Framework and version",
        SerializedName = @"windowsFxVersion",
        PossibleTypes = new [] { typeof(string) })]
        string WindowsFxVersion { get; set; }
        /// <summary>Explicit Managed Service Identity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Explicit Managed Service Identity Id",
        SerializedName = @"xManagedServiceIdentityId",
        PossibleTypes = new [] { typeof(int) })]
        int? XManagedServiceIdentityId { get; set; }

    }
    /// Configuration of an App Service app.
    internal partial interface ISiteConfigInternal

    {
        /// <summary>Custom action to be taken.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction ActionCustomAction { get; set; }
        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        string ActionMinProcessExecutionTime { get; set; }
        /// <summary>Predefined action to be taken.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get; set; }
        /// <summary><code>true</code> if Always On is enabled; otherwise, <code>false</code>.</summary>
        bool? AlwaysOn { get; set; }
        /// <summary>Information about the formal API definition for the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfo ApiDefinition { get; set; }
        /// <summary>The URL of the API definition.</summary>
        string ApiDefinitionUrl { get; set; }
        /// <summary>Azure API management settings linked to the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfig ApiManagementConfig { get; set; }
        /// <summary>APIM-Api Identifier.</summary>
        string ApiManagementConfigId { get; set; }
        /// <summary>App command line to launch.</summary>
        string AppCommandLine { get; set; }
        /// <summary>Application settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] AppSetting { get; set; }
        /// <summary><code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.</summary>
        bool? AutoHealEnabled { get; set; }
        /// <summary>Auto Heal rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules AutoHealRule { get; set; }
        /// <summary>Actions to be executed when a rule is triggered.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions AutoHealRuleAction { get; set; }
        /// <summary>Conditions that describe when to execute the auto-heal actions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers AutoHealRuleTrigger { get; set; }
        /// <summary>Auto-swap slot name.</summary>
        string AutoSwapSlotName { get; set; }
        /// <summary>Connection strings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[] ConnectionString { get; set; }
        /// <summary>Cross-Origin Resource Sharing (CORS) settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettings Cor { get; set; }
        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        string[] CorAllowedOrigin { get; set; }
        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        bool? CorSupportCredentials { get; set; }
        /// <summary>Executable to be run.</summary>
        string CustomActionExe { get; set; }
        /// <summary>Parameters for the executable.</summary>
        string CustomActionParameter { get; set; }
        /// <summary>Default documents.</summary>
        string[] DefaultDocument { get; set; }
        /// <summary>
        /// <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
        /// </summary>
        bool? DetailedErrorLoggingEnabled { get; set; }
        /// <summary>Document root.</summary>
        string DocumentRoot { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        string DynamicTagsJson { get; set; }
        /// <summary>This is work around for polymorphic types.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperiments Experiment { get; set; }
        /// <summary>List of ramp-up rules.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] ExperimentRampUpRule { get; set; }
        /// <summary>State of FTP / FTPS service</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState? FtpsState { get; set; }
        /// <summary>Handler mappings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[] HandlerMapping { get; set; }
        /// <summary>Health check path</summary>
        string HealthCheckPath { get; set; }
        /// <summary>Http20Enabled: configures a web site to allow clients to connect over http2.0</summary>
        bool? Http20Enabled { get; set; }
        /// <summary><code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.</summary>
        bool? HttpLoggingEnabled { get; set; }
        /// <summary>IP security restrictions for main.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] IPSecurityRestriction { get; set; }
        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        bool IsPushEnabled { get; set; }
        /// <summary>Java container.</summary>
        string JavaContainer { get; set; }
        /// <summary>Java container version.</summary>
        string JavaContainerVersion { get; set; }
        /// <summary>Java version.</summary>
        string JavaVersion { get; set; }
        /// <summary>Site limits.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimits Limit { get; set; }
        /// <summary>Maximum allowed disk size usage in MB.</summary>
        long? LimitMaxDiskSizeInMb { get; set; }
        /// <summary>Maximum allowed memory usage in MB.</summary>
        long? LimitMaxMemoryInMb { get; set; }
        /// <summary>Maximum allowed CPU usage percentage.</summary>
        double? LimitMaxPercentageCpu { get; set; }
        /// <summary>Linux App Framework and version</summary>
        string LinuxFxVersion { get; set; }
        /// <summary>Site load balancing.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing? LoadBalancing { get; set; }
        /// <summary><code>true</code> to enable local MySQL; otherwise, <code>false</code>.</summary>
        bool? LocalMySqlEnabled { get; set; }
        /// <summary>HTTP logs directory size limit.</summary>
        int? LogsDirectorySizeLimit { get; set; }
        /// <summary>Site MachineKey.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKey MachineKey { get; set; }
        /// <summary>Algorithm used for decryption.</summary>
        string MachineKeyDecryption { get; set; }
        /// <summary>Decryption key.</summary>
        string MachineKeyDecryptionKey { get; set; }
        /// <summary>MachineKey validation.</summary>
        string MachineKeyValidation { get; set; }
        /// <summary>Validation key.</summary>
        string MachineKeyValidationKey { get; set; }
        /// <summary>Managed pipeline mode.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode? ManagedPipelineMode { get; set; }
        /// <summary>Managed Service Identity Id</summary>
        int? ManagedServiceIdentityId { get; set; }
        /// <summary>MinTlsVersion: configures the minimum version of TLS required for SSL requests</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions? MinTlsVersion { get; set; }
        /// <summary>.NET Framework version.</summary>
        string NetFrameworkVersion { get; set; }
        /// <summary>Version of Node.js.</summary>
        string NodeVersion { get; set; }
        /// <summary>Number of workers.</summary>
        int? NumberOfWorker { get; set; }
        /// <summary>Version of PHP.</summary>
        string PhpVersion { get; set; }
        /// <summary>Version of PowerShell.</summary>
        string PowerShellVersion { get; set; }
        /// <summary>
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </summary>
        int? PreWarmedInstanceCount { get; set; }
        /// <summary>Publishing user name.</summary>
        string PublishingUsername { get; set; }
        /// <summary>Push endpoint settings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettings Push { get; set; }
        /// <summary>Resource Id.</summary>
        string PushId { get; set; }
        /// <summary>Kind of resource.</summary>
        string PushKind { get; set; }
        /// <summary>Resource Name.</summary>
        string PushName { get; set; }
        /// <summary>PushSettings resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsProperties PushProperty { get; set; }
        /// <summary>Resource type.</summary>
        string PushType { get; set; }
        /// <summary>Version of Python.</summary>
        string PythonVersion { get; set; }
        /// <summary>
        /// <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
        /// </summary>
        bool? RemoteDebuggingEnabled { get; set; }
        /// <summary>Remote debugging version.</summary>
        string RemoteDebuggingVersion { get; set; }
        /// <summary>Request Count.</summary>
        int? RequestCount { get; set; }
        /// <summary>Time interval.</summary>
        string RequestTimeInterval { get; set; }
        /// <summary><code>true</code> if request tracing is enabled; otherwise, <code>false</code>.</summary>
        bool? RequestTracingEnabled { get; set; }
        /// <summary>Request tracing expiration time.</summary>
        global::System.DateTime? RequestTracingExpirationTime { get; set; }
        /// <summary>IP security restrictions for scm.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] ScmIPSecurityRestriction { get; set; }
        /// <summary>IP security restrictions for scm to use main.</summary>
        bool? ScmIPSecurityRestrictionsUseMain { get; set; }
        /// <summary>SCM type.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType? ScmType { get; set; }
        /// <summary>Request Count.</summary>
        int? SlowRequestCount { get; set; }
        /// <summary>Time interval.</summary>
        string SlowRequestTimeInterval { get; set; }
        /// <summary>Time taken.</summary>
        string SlowRequestTimeTaken { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        string TagWhitelistJson { get; set; }
        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        string TagsRequiringAuth { get; set; }
        /// <summary>Tracing options.</summary>
        string TracingOption { get; set; }
        /// <summary>A rule based on private bytes.</summary>
        int? TriggerPrivateBytesInKb { get; set; }
        /// <summary>A rule based on total requests.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger TriggerRequest { get; set; }
        /// <summary>A rule based on request execution time.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger TriggerSlowRequest { get; set; }
        /// <summary>A rule based on status codes.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get; set; }
        /// <summary><code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.</summary>
        bool? Use32BitWorkerProcess { get; set; }
        /// <summary>Virtual applications.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[] VirtualApplication { get; set; }
        /// <summary>Virtual Network name.</summary>
        string VnetName { get; set; }
        /// <summary><code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.</summary>
        bool? WebSocketsEnabled { get; set; }
        /// <summary>Xenon App Framework and version</summary>
        string WindowsFxVersion { get; set; }
        /// <summary>Explicit Managed Service Identity Id</summary>
        int? XManagedServiceIdentityId { get; set; }

    }
}