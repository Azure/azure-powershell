namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Web app configuration ARM resource.</summary>
    public partial class SiteConfigResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResource,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource __proxyOnlyResource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ProxyOnlyResource();

        /// <summary>
        /// Minimum time the process must execute
        /// before taking the action
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ActionMinProcessExecutionTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ActionMinProcessExecutionTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ActionMinProcessExecutionTime = value; }

        /// <summary>Predefined action to be taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.AutoHealActionType? ActionType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ActionType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ActionType = value; }

        /// <summary><code>true</code> if Always On is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AlwaysOn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AlwaysOn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AlwaysOn = value; }

        /// <summary>The URL of the API definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApiDefinitionUrl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiDefinitionUrl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiDefinitionUrl = value; }

        /// <summary>APIM-Api Identifier.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ApiManagementConfigId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiManagementConfigId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiManagementConfigId = value; }

        /// <summary>App command line to launch.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AppCommandLine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AppCommandLine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AppCommandLine = value; }

        /// <summary>Application settings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.INameValuePair[] AppSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AppSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AppSetting = value; }

        /// <summary><code>true</code> if Auto Heal is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? AutoHealEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealEnabled = value; }

        /// <summary>Auto-swap slot name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string AutoSwapSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoSwapSlotName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoSwapSlotName = value; }

        /// <summary>Connection strings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IConnStringInfo[] ConnectionString { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ConnectionString; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ConnectionString = value; }

        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        /// calls (for example: http://example.com:12345). Use "*" to allow all.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] CorAllowedOrigin { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CorAllowedOrigin; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CorAllowedOrigin = value; }

        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See
        /// https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS#Requests_with_credentials
        /// for more details.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CorSupportCredentials { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CorSupportCredentials; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CorSupportCredentials = value; }

        /// <summary>Executable to be run.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionExe { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CustomActionExe; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CustomActionExe = value; }

        /// <summary>Parameters for the executable.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CustomActionParameter { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CustomActionParameter; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).CustomActionParameter = value; }

        /// <summary>Default documents.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] DefaultDocument { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DefaultDocument; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DefaultDocument = value; }

        /// <summary>
        /// <code>true</code> if detailed error logging is enabled; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? DetailedErrorLoggingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DetailedErrorLoggingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DetailedErrorLoggingEnabled = value; }

        /// <summary>Document root.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DocumentRoot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DocumentRoot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DocumentRoot = value; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration
        /// endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DynamicTagsJson { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DynamicTagsJson; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).DynamicTagsJson = value; }

        /// <summary>List of ramp-up rules.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule[] ExperimentRampUpRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ExperimentRampUpRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ExperimentRampUpRule = value; }

        /// <summary>State of FTP / FTPS service</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.FtpsState? FtpsState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).FtpsState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).FtpsState = value; }

        /// <summary>Handler mappings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHandlerMapping[] HandlerMapping { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).HandlerMapping; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).HandlerMapping = value; }

        /// <summary>Health check path</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HealthCheckPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).HealthCheckPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).HealthCheckPath = value; }

        /// <summary>Http20Enabled: configures a web site to allow clients to connect over http2.0</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Http20Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Http20Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Http20Enabled = value; }

        /// <summary><code>true</code> if HTTP logging is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HttpLoggingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).HttpLoggingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).HttpLoggingEnabled = value; }

        /// <summary>IP security restrictions for main.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] IPSecurityRestriction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).IPSecurityRestriction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).IPSecurityRestriction = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; }

        /// <summary>Gets or sets a flag indicating whether the Push endpoint is enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool IsPushEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).IsPushEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).IsPushEnabled = value; }

        /// <summary>Java container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string JavaContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).JavaContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).JavaContainer = value; }

        /// <summary>Java container version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string JavaContainerVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).JavaContainerVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).JavaContainerVersion = value; }

        /// <summary>Java version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string JavaVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).JavaVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).JavaVersion = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Kind = value; }

        /// <summary>Maximum allowed disk size usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? LimitMaxDiskSizeInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LimitMaxDiskSizeInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LimitMaxDiskSizeInMb = value; }

        /// <summary>Maximum allowed memory usage in MB.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public long? LimitMaxMemoryInMb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LimitMaxMemoryInMb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LimitMaxMemoryInMb = value; }

        /// <summary>Maximum allowed CPU usage percentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public double? LimitMaxPercentageCpu { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LimitMaxPercentageCpu; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LimitMaxPercentageCpu = value; }

        /// <summary>Linux App Framework and version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string LinuxFxVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LinuxFxVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LinuxFxVersion = value; }

        /// <summary>Site load balancing.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteLoadBalancing? LoadBalancing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LoadBalancing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LoadBalancing = value; }

        /// <summary><code>true</code> to enable local MySQL; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? LocalMySqlEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LocalMySqlEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LocalMySqlEnabled = value; }

        /// <summary>HTTP logs directory size limit.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? LogsDirectorySizeLimit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LogsDirectorySizeLimit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).LogsDirectorySizeLimit = value; }

        /// <summary>Algorithm used for decryption.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyDecryption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyDecryption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyDecryption = value; }

        /// <summary>Decryption key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyDecryptionKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyDecryptionKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyDecryptionKey = value; }

        /// <summary>MachineKey validation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyValidation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyValidation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyValidation = value; }

        /// <summary>Validation key.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string MachineKeyValidationKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyValidationKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKeyValidationKey = value; }

        /// <summary>Managed pipeline mode.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedPipelineMode? ManagedPipelineMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ManagedPipelineMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ManagedPipelineMode = value; }

        /// <summary>Managed Service Identity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ManagedServiceIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ManagedServiceIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ManagedServiceIdentityId = value; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type = value; }

        /// <summary>Internal Acessors for ActionCustomAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealCustomAction Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.ActionCustomAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ActionCustomAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ActionCustomAction = value; }

        /// <summary>Internal Acessors for ApiDefinition</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiDefinitionInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.ApiDefinition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiDefinition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiDefinition = value; }

        /// <summary>Internal Acessors for ApiManagementConfig</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IApiManagementConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.ApiManagementConfig { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiManagementConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ApiManagementConfig = value; }

        /// <summary>Internal Acessors for AutoHealRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealRules Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.AutoHealRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealRule = value; }

        /// <summary>Internal Acessors for AutoHealRuleAction</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealActions Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.AutoHealRuleAction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealRuleAction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealRuleAction = value; }

        /// <summary>Internal Acessors for AutoHealRuleTrigger</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IAutoHealTriggers Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.AutoHealRuleTrigger { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealRuleTrigger; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).AutoHealRuleTrigger = value; }

        /// <summary>Internal Acessors for Cor</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICorsSettings Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.Cor { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Cor; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Cor = value; }

        /// <summary>Internal Acessors for Experiment</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IExperiments Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.Experiment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Experiment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Experiment = value; }

        /// <summary>Internal Acessors for Limit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteLimits Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.Limit { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Limit; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Limit = value; }

        /// <summary>Internal Acessors for MachineKey</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteMachineKey Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.MachineKey { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKey; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MachineKey = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteConfig()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Push</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettings Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.Push { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Push; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Push = value; }

        /// <summary>Internal Acessors for PushId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.PushId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushId = value; }

        /// <summary>Internal Acessors for PushName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.PushName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushName = value; }

        /// <summary>Internal Acessors for PushProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IPushSettingsProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.PushProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushProperty = value; }

        /// <summary>Internal Acessors for PushType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.PushType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushType = value; }

        /// <summary>Internal Acessors for TriggerRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRequestsBasedTrigger Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.TriggerRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerRequest = value; }

        /// <summary>Internal Acessors for TriggerSlowRequest</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlowRequestsBasedTrigger Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigResourceInternal.TriggerSlowRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerSlowRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerSlowRequest = value; }

        /// <summary>MinTlsVersion: configures the minimum version of TLS required for SSL requests</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SupportedTlsVersions? MinTlsVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MinTlsVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).MinTlsVersion = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Name; }

        /// <summary>.NET Framework version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string NetFrameworkVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).NetFrameworkVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).NetFrameworkVersion = value; }

        /// <summary>Version of Node.js.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string NodeVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).NodeVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).NodeVersion = value; }

        /// <summary>Number of workers.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? NumberOfWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).NumberOfWorker; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).NumberOfWorker = value; }

        /// <summary>Version of PHP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PhpVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PhpVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PhpVersion = value; }

        /// <summary>Version of PowerShell.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PowerShellVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PowerShellVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PowerShellVersion = value; }

        /// <summary>
        /// Number of preWarmed instances.
        /// This setting only applies to the Consumption and Elastic Plans
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? PreWarmedInstanceCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PreWarmedInstanceCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PreWarmedInstanceCount = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig _property;

        /// <summary>Core resource properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteConfig()); set => this._property = value; }

        /// <summary>Publishing user name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PublishingUsername { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PublishingUsername; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PublishingUsername = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushId; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushKind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushKind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushKind = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushName; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PushType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PushType; }

        /// <summary>Version of Python.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PythonVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PythonVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).PythonVersion = value; }

        /// <summary>
        /// <code>true</code> if remote debugging is enabled; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? RemoteDebuggingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RemoteDebuggingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RemoteDebuggingEnabled = value; }

        /// <summary>Remote debugging version.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RemoteDebuggingVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RemoteDebuggingVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RemoteDebuggingVersion = value; }

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? RequestCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestCount = value; }

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RequestTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestTimeInterval = value; }

        /// <summary><code>true</code> if request tracing is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? RequestTracingEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestTracingEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestTracingEnabled = value; }

        /// <summary>Request tracing expiration time.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? RequestTracingExpirationTime { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestTracingExpirationTime; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).RequestTracingExpirationTime = value; }

        /// <summary>IP security restrictions for scm.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IIPSecurityRestriction[] ScmIPSecurityRestriction { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ScmIPSecurityRestriction; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ScmIPSecurityRestriction = value; }

        /// <summary>IP security restrictions for scm to use main.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ScmIPSecurityRestrictionsUseMain { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ScmIPSecurityRestrictionsUseMain; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ScmIPSecurityRestrictionsUseMain = value; }

        /// <summary>SCM type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ScmType? ScmType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ScmType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).ScmType = value; }

        /// <summary>Request Count.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? SlowRequestCount { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).SlowRequestCount; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).SlowRequestCount = value; }

        /// <summary>Time interval.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlowRequestTimeInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).SlowRequestTimeInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).SlowRequestTimeInterval = value; }

        /// <summary>Time taken.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlowRequestTimeTaken { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).SlowRequestTimeTaken; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).SlowRequestTimeTaken = value; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TagWhitelistJson { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TagWhitelistJson; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TagWhitelistJson = value; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration
        /// endpoint.
        /// Tags can consist of alphanumeric characters and the following:
        /// '_', '@', '#', '.', ':', '-'.
        /// Validation should be performed at the PushRequestHandler.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TagsRequiringAuth { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TagsRequiringAuth; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TagsRequiringAuth = value; }

        /// <summary>Tracing options.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TracingOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TracingOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TracingOption = value; }

        /// <summary>A rule based on private bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? TriggerPrivateBytesInKb { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerPrivateBytesInKb; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerPrivateBytesInKb = value; }

        /// <summary>A rule based on status codes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IStatusCodesBasedTrigger[] TriggerStatusCode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerStatusCode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).TriggerStatusCode = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal)__proxyOnlyResource).Type; }

        /// <summary><code>true</code> to use 32-bit worker process; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Use32BitWorkerProcess { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Use32BitWorkerProcess; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).Use32BitWorkerProcess = value; }

        /// <summary>Virtual applications.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IVirtualApplication[] VirtualApplication { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).VirtualApplication; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).VirtualApplication = value; }

        /// <summary>Virtual Network name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string VnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).VnetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).VnetName = value; }

        /// <summary><code>true</code> if WebSocket is enabled; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? WebSocketsEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).WebSocketsEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).WebSocketsEnabled = value; }

        /// <summary>Xenon App Framework and version</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string WindowsFxVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).WindowsFxVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).WindowsFxVersion = value; }

        /// <summary>Explicit Managed Service Identity Id</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? XManagedServiceIdentityId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).XManagedServiceIdentityId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfigInternal)Property).XManagedServiceIdentityId = value; }

        /// <summary>Creates an new <see cref="SiteConfigResource" /> instance.</summary>
        public SiteConfigResource()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__proxyOnlyResource), __proxyOnlyResource);
            await eventListener.AssertObjectIsValid(nameof(__proxyOnlyResource), __proxyOnlyResource);
        }
    }
    /// Web app configuration ARM resource.
    public partial interface ISiteConfigResource :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResource
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
    /// Web app configuration ARM resource.
    internal partial interface ISiteConfigResourceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IProxyOnlyResourceInternal
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
        /// <summary>Core resource properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig Property { get; set; }
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