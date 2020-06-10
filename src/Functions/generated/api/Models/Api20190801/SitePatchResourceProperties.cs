namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>SitePatchResource resource specific properties</summary>
    public partial class SitePatchResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourceProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AvailabilityState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? _availabilityState;

        /// <summary>Management information availability state for the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? AvailabilityState { get => this._availabilityState; }

        /// <summary>Backing field for <see cref="ClientAffinityEnabled" /> property.</summary>
        private bool? _clientAffinityEnabled;

        /// <summary>
        /// <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route
        /// client requests in the same session to the same instance. Default is <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ClientAffinityEnabled { get => this._clientAffinityEnabled; set => this._clientAffinityEnabled = value; }

        /// <summary>Backing field for <see cref="ClientCertEnabled" /> property.</summary>
        private bool? _clientCertEnabled;

        /// <summary>
        /// <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>.
        /// Default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ClientCertEnabled { get => this._clientCertEnabled; set => this._clientCertEnabled = value; }

        /// <summary>Backing field for <see cref="ClientCertExclusionPath" /> property.</summary>
        private string _clientCertExclusionPath;

        /// <summary>client certificate authentication comma-separated exclusion paths</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ClientCertExclusionPath { get => this._clientCertExclusionPath; set => this._clientCertExclusionPath = value; }

        /// <summary>Backing field for <see cref="CloningInfo" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo _cloningInfo;

        /// <summary>If specified during app creation, the app is cloned from a source app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo CloningInfo { get => (this._cloningInfo = this._cloningInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo()); set => this._cloningInfo = value; }

        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
        /// from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides CloningInfoAppSettingsOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).AppSettingsOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).AppSettingsOverride = value; }

        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoCloneCustomHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).CloneCustomHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).CloneCustomHostName = value; }

        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoCloneSourceControl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).CloneSourceControl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).CloneSourceControl = value; }

        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoConfigureLoadBalancing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).ConfigureLoadBalancing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).ConfigureLoadBalancing = value; }

        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        /// together to use the same snapshot.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoCorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).CorrelationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).CorrelationId = value; }

        /// <summary>App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoHostingEnvironment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).HostingEnvironment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).HostingEnvironment = value; }

        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoOverwrite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).Overwrite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).Overwrite = value; }

        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoSourceWebAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).SourceWebAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).SourceWebAppId = value; }

        /// <summary>Location of source app ex: West US or North Europe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoSourceWebAppLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).SourceWebAppLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).SourceWebAppLocation = value; }

        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoTrafficManagerProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).TrafficManagerProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).TrafficManagerProfileId = value; }

        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoTrafficManagerProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).TrafficManagerProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal)CloningInfo).TrafficManagerProfileName = value; }

        /// <summary>Backing field for <see cref="ContainerSize" /> property.</summary>
        private int? _containerSize;

        /// <summary>Size of the function container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ContainerSize { get => this._containerSize; set => this._containerSize = value; }

        /// <summary>Backing field for <see cref="DailyMemoryTimeQuota" /> property.</summary>
        private int? _dailyMemoryTimeQuota;

        /// <summary>Maximum allowed daily memory-time quota (applicable on dynamic apps only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? DailyMemoryTimeQuota { get => this._dailyMemoryTimeQuota; set => this._dailyMemoryTimeQuota = value; }

        /// <summary>Backing field for <see cref="DefaultHostName" /> property.</summary>
        private string _defaultHostName;

        /// <summary>Default hostname of the app. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string DefaultHostName { get => this._defaultHostName; }

        /// <summary>Backing field for <see cref="Enabled" /> property.</summary>
        private bool? _enabled;

        /// <summary>
        /// <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes
        /// the app offline).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Enabled { get => this._enabled; set => this._enabled = value; }

        /// <summary>Backing field for <see cref="EnabledHostName" /> property.</summary>
        private string[] _enabledHostName;

        /// <summary>
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] EnabledHostName { get => this._enabledHostName; }

        /// <summary>Backing field for <see cref="HostName" /> property.</summary>
        private string[] _hostName;

        /// <summary>Hostnames associated with the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] HostName { get => this._hostName; }

        /// <summary>Backing field for <see cref="HostNameSslState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState[] _hostNameSslState;

        /// <summary>Hostname SSL states are used to manage the SSL bindings for app's hostnames.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState[] HostNameSslState { get => this._hostNameSslState; set => this._hostNameSslState = value; }

        /// <summary>Backing field for <see cref="HostNamesDisabled" /> property.</summary>
        private bool? _hostNamesDisabled;

        /// <summary>
        /// <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.
        /// If <code>true</code>, the app is only accessible via API management process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HostNamesDisabled { get => this._hostNamesDisabled; set => this._hostNamesDisabled = value; }

        /// <summary>Backing field for <see cref="HostingEnvironmentProfile" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile _hostingEnvironmentProfile;

        /// <summary>App Service Environment to use for the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile HostingEnvironmentProfile { get => (this._hostingEnvironmentProfile = this._hostingEnvironmentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile()); set => this._hostingEnvironmentProfile = value; }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Id = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type; }

        /// <summary>Backing field for <see cref="HttpsOnly" /> property.</summary>
        private bool? _httpsOnly;

        /// <summary>
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        /// http requests
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HttpsOnly { get => this._httpsOnly; set => this._httpsOnly = value; }

        /// <summary>Backing field for <see cref="HyperV" /> property.</summary>
        private bool? _hyperV;

        /// <summary>Hyper-V sandbox.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? HyperV { get => this._hyperV; set => this._hyperV = value; }

        /// <summary>Backing field for <see cref="InProgressOperationId" /> property.</summary>
        private string _inProgressOperationId;

        /// <summary>Specifies an operation id if this site has a pending operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string InProgressOperationId { get => this._inProgressOperationId; }

        /// <summary>Backing field for <see cref="IsDefaultContainer" /> property.</summary>
        private bool? _isDefaultContainer;

        /// <summary>
        /// <code>true</code> if the app is a default container; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsDefaultContainer { get => this._isDefaultContainer; }

        /// <summary>Backing field for <see cref="IsXenon" /> property.</summary>
        private bool? _isXenon;

        /// <summary>Obsolete: Hyper-V sandbox.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? IsXenon { get => this._isXenon; set => this._isXenon = value; }

        /// <summary>Backing field for <see cref="LastModifiedTimeUtc" /> property.</summary>
        private global::System.DateTime? _lastModifiedTimeUtc;

        /// <summary>Last time the app was modified, in UTC. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastModifiedTimeUtc { get => this._lastModifiedTimeUtc; }

        /// <summary>Backing field for <see cref="MaxNumberOfWorker" /> property.</summary>
        private int? _maxNumberOfWorker;

        /// <summary>
        /// Maximum number of workers.
        /// This only applies to Functions container.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? MaxNumberOfWorker { get => this._maxNumberOfWorker; }

        /// <summary>Internal Acessors for AvailabilityState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.AvailabilityState { get => this._availabilityState; set { {_availabilityState = value;} } }

        /// <summary>Internal Acessors for CloningInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.CloningInfo { get => (this._cloningInfo = this._cloningInfo ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfo()); set { {_cloningInfo = value;} } }

        /// <summary>Internal Acessors for DefaultHostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.DefaultHostName { get => this._defaultHostName; set { {_defaultHostName = value;} } }

        /// <summary>Internal Acessors for EnabledHostName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.EnabledHostName { get => this._enabledHostName; set { {_enabledHostName = value;} } }

        /// <summary>Internal Acessors for HostName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.HostName { get => this._hostName; set { {_hostName = value;} } }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.HostingEnvironmentProfile { get => (this._hostingEnvironmentProfile = this._hostingEnvironmentProfile ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.HostingEnvironmentProfile()); set { {_hostingEnvironmentProfile = value;} } }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Name = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfileInternal)HostingEnvironmentProfile).Type = value; }

        /// <summary>Internal Acessors for InProgressOperationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.InProgressOperationId { get => this._inProgressOperationId; set { {_inProgressOperationId = value;} } }

        /// <summary>Internal Acessors for IsDefaultContainer</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.IsDefaultContainer { get => this._isDefaultContainer; set { {_isDefaultContainer = value;} } }

        /// <summary>Internal Acessors for LastModifiedTimeUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.LastModifiedTimeUtc { get => this._lastModifiedTimeUtc; set { {_lastModifiedTimeUtc = value;} } }

        /// <summary>Internal Acessors for MaxNumberOfWorker</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.MaxNumberOfWorker { get => this._maxNumberOfWorker; set { {_maxNumberOfWorker = value;} } }

        /// <summary>Internal Acessors for OutboundIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.OutboundIPAddress { get => this._outboundIPAddress; set { {_outboundIPAddress = value;} } }

        /// <summary>Internal Acessors for PossibleOutboundIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.PossibleOutboundIPAddress { get => this._possibleOutboundIPAddress; set { {_possibleOutboundIPAddress = value;} } }

        /// <summary>Internal Acessors for RepositorySiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.RepositorySiteName { get => this._repositorySiteName; set { {_repositorySiteName = value;} } }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.ResourceGroup { get => this._resourceGroup; set { {_resourceGroup = value;} } }

        /// <summary>Internal Acessors for SlotSwapStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatus Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.SlotSwapStatus { get => (this._slotSwapStatus = this._slotSwapStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlotSwapStatus()); set { {_slotSwapStatus = value;} } }

        /// <summary>Internal Acessors for SlotSwapStatusDestinationSlotName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.SlotSwapStatusDestinationSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).DestinationSlotName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).DestinationSlotName = value; }

        /// <summary>Internal Acessors for SlotSwapStatusSourceSlotName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.SlotSwapStatusSourceSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).SourceSlotName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).SourceSlotName = value; }

        /// <summary>Internal Acessors for SlotSwapStatusTimestampUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.SlotSwapStatusTimestampUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).TimestampUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).TimestampUtc = value; }

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.State { get => this._state; set { {_state = value;} } }

        /// <summary>Internal Acessors for SuspendedTill</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.SuspendedTill { get => this._suspendedTill; set { {_suspendedTill = value;} } }

        /// <summary>Internal Acessors for TargetSwapSlot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.TargetSwapSlot { get => this._targetSwapSlot; set { {_targetSwapSlot = value;} } }

        /// <summary>Internal Acessors for TrafficManagerHostName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.TrafficManagerHostName { get => this._trafficManagerHostName; set { {_trafficManagerHostName = value;} } }

        /// <summary>Internal Acessors for UsageState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePatchResourcePropertiesInternal.UsageState { get => this._usageState; set { {_usageState = value;} } }

        /// <summary>Backing field for <see cref="OutboundIPAddress" /> property.</summary>
        private string _outboundIPAddress;

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that
        /// site can be hosted with current settings. Read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string OutboundIPAddress { get => this._outboundIPAddress; }

        /// <summary>Backing field for <see cref="PossibleOutboundIPAddress" /> property.</summary>
        private string _possibleOutboundIPAddress;

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants
        /// except dataComponent. Read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string PossibleOutboundIPAddress { get => this._possibleOutboundIPAddress; }

        /// <summary>Backing field for <see cref="RedundancyMode" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RedundancyMode? _redundancyMode;

        /// <summary>Site redundancy mode</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RedundancyMode? RedundancyMode { get => this._redundancyMode; set => this._redundancyMode = value; }

        /// <summary>Backing field for <see cref="RepositorySiteName" /> property.</summary>
        private string _repositorySiteName;

        /// <summary>Name of the repository site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string RepositorySiteName { get => this._repositorySiteName; }

        /// <summary>Backing field for <see cref="Reserved" /> property.</summary>
        private bool? _reserved;

        /// <summary><code>true</code> if reserved; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Reserved { get => this._reserved; set => this._reserved = value; }

        /// <summary>Backing field for <see cref="ResourceGroup" /> property.</summary>
        private string _resourceGroup;

        /// <summary>Name of the resource group the app belongs to. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ResourceGroup { get => this._resourceGroup; }

        /// <summary>Backing field for <see cref="ScmSiteAlsoStopped" /> property.</summary>
        private bool? _scmSiteAlsoStopped;

        /// <summary>
        /// <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ScmSiteAlsoStopped { get => this._scmSiteAlsoStopped; set => this._scmSiteAlsoStopped = value; }

        /// <summary>Backing field for <see cref="ServerFarmId" /> property.</summary>
        private string _serverFarmId;

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ServerFarmId { get => this._serverFarmId; set => this._serverFarmId = value; }

        /// <summary>Backing field for <see cref="SiteConfig" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig _siteConfig;

        /// <summary>Configuration of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig SiteConfig { get => (this._siteConfig = this._siteConfig ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteConfig()); set => this._siteConfig = value; }

        /// <summary>Backing field for <see cref="SlotSwapStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatus _slotSwapStatus;

        /// <summary>Status of the last deployment slot swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatus SlotSwapStatus { get => (this._slotSwapStatus = this._slotSwapStatus ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SlotSwapStatus()); }

        /// <summary>The destination slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlotSwapStatusDestinationSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).DestinationSlotName; }

        /// <summary>The source slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlotSwapStatusSourceSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).SourceSlotName; }

        /// <summary>The time the last successful slot swap completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SlotSwapStatusTimestampUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatusInternal)SlotSwapStatus).TimestampUtc; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private string _state;

        /// <summary>Current state of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string State { get => this._state; }

        /// <summary>Backing field for <see cref="SuspendedTill" /> property.</summary>
        private global::System.DateTime? _suspendedTill;

        /// <summary>App suspended till in case memory-time quota is exceeded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? SuspendedTill { get => this._suspendedTill; }

        /// <summary>Backing field for <see cref="TargetSwapSlot" /> property.</summary>
        private string _targetSwapSlot;

        /// <summary>Specifies which deployment slot this app will swap into. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TargetSwapSlot { get => this._targetSwapSlot; }

        /// <summary>Backing field for <see cref="TrafficManagerHostName" /> property.</summary>
        private string[] _trafficManagerHostName;

        /// <summary>Azure Traffic Manager hostnames associated with the app. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string[] TrafficManagerHostName { get => this._trafficManagerHostName; }

        /// <summary>Backing field for <see cref="UsageState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? _usageState;

        /// <summary>State indicating whether the app has exceeded its quota usage. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? UsageState { get => this._usageState; }

        /// <summary>Creates an new <see cref="SitePatchResourceProperties" /> instance.</summary>
        public SitePatchResourceProperties()
        {

        }
    }
    /// SitePatchResource resource specific properties
    public partial interface ISitePatchResourceProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>Management information availability state for the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Management information availability state for the app.",
        SerializedName = @"availabilityState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? AvailabilityState { get;  }
        /// <summary>
        /// <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route
        /// client requests in the same session to the same instance. Default is <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route client requests in the same session to the same instance. Default is <code>true</code>.",
        SerializedName = @"clientAffinityEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ClientAffinityEnabled { get; set; }
        /// <summary>
        /// <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>.
        /// Default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>. Default is <code>false</code>.",
        SerializedName = @"clientCertEnabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ClientCertEnabled { get; set; }
        /// <summary>client certificate authentication comma-separated exclusion paths</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"client certificate authentication comma-separated exclusion paths",
        SerializedName = @"clientCertExclusionPaths",
        PossibleTypes = new [] { typeof(string) })]
        string ClientCertExclusionPath { get; set; }
        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
        /// from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Application setting overrides for cloned app. If specified, these settings override the settings cloned
        from source app. Otherwise, application settings from source app are retained.",
        SerializedName = @"appSettingsOverrides",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides CloningInfoAppSettingsOverride { get; set; }
        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.",
        SerializedName = @"cloneCustomHostNames",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CloningInfoCloneCustomHostName { get; set; }
        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to clone source control from source app; otherwise, <code>false</code>.",
        SerializedName = @"cloneSourceControl",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CloningInfoCloneSourceControl { get; set; }
        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to configure load balancing for source and destination app.",
        SerializedName = @"configureLoadBalancing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CloningInfoConfigureLoadBalancing { get; set; }
        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        /// together to use the same snapshot.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Correlation ID of cloning operation. This ID ties multiple cloning operations
        together to use the same snapshot.",
        SerializedName = @"correlationId",
        PossibleTypes = new [] { typeof(string) })]
        string CloningInfoCorrelationId { get; set; }
        /// <summary>App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service Environment.",
        SerializedName = @"hostingEnvironment",
        PossibleTypes = new [] { typeof(string) })]
        string CloningInfoHostingEnvironment { get; set; }
        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to overwrite destination app; otherwise, <code>false</code>.",
        SerializedName = @"overwrite",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CloningInfoOverwrite { get; set; }
        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ARM resource ID of the source app. App resource ID is of the form
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots and
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for other slots.",
        SerializedName = @"sourceWebAppId",
        PossibleTypes = new [] { typeof(string) })]
        string CloningInfoSourceWebAppId { get; set; }
        /// <summary>Location of source app ex: West US or North Europe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location of source app ex: West US or North Europe",
        SerializedName = @"sourceWebAppLocation",
        PossibleTypes = new [] { typeof(string) })]
        string CloningInfoSourceWebAppLocation { get; set; }
        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.",
        SerializedName = @"trafficManagerProfileId",
        PossibleTypes = new [] { typeof(string) })]
        string CloningInfoTrafficManagerProfileId { get; set; }
        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.",
        SerializedName = @"trafficManagerProfileName",
        PossibleTypes = new [] { typeof(string) })]
        string CloningInfoTrafficManagerProfileName { get; set; }
        /// <summary>Size of the function container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Size of the function container.",
        SerializedName = @"containerSize",
        PossibleTypes = new [] { typeof(int) })]
        int? ContainerSize { get; set; }
        /// <summary>Maximum allowed daily memory-time quota (applicable on dynamic apps only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Maximum allowed daily memory-time quota (applicable on dynamic apps only).",
        SerializedName = @"dailyMemoryTimeQuota",
        PossibleTypes = new [] { typeof(int) })]
        int? DailyMemoryTimeQuota { get; set; }
        /// <summary>Default hostname of the app. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Default hostname of the app. Read-only.",
        SerializedName = @"defaultHostName",
        PossibleTypes = new [] { typeof(string) })]
        string DefaultHostName { get;  }
        /// <summary>
        /// <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes
        /// the app offline).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes the app offline).",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Enabled { get; set; }
        /// <summary>
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        the app is not served on those hostnames.",
        SerializedName = @"enabledHostNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] EnabledHostName { get;  }
        /// <summary>Hostnames associated with the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Hostnames associated with the app.",
        SerializedName = @"hostNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] HostName { get;  }
        /// <summary>Hostname SSL states are used to manage the SSL bindings for app's hostnames.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hostname SSL states are used to manage the SSL bindings for app's hostnames.",
        SerializedName = @"hostNameSslStates",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState[] HostNameSslState { get; set; }
        /// <summary>
        /// <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.
        /// If <code>true</code>, the app is only accessible via API management process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.
         If <code>true</code>, the app is only accessible via API management process.",
        SerializedName = @"hostNamesDisabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HostNamesDisabled { get; set; }
        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the App Service Environment.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileId { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the App Service Environment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileName { get;  }
        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type of the App Service Environment.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironmentProfileType { get;  }
        /// <summary>
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        /// http requests
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        http requests",
        SerializedName = @"httpsOnly",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HttpsOnly { get; set; }
        /// <summary>Hyper-V sandbox.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hyper-V sandbox.",
        SerializedName = @"hyperV",
        PossibleTypes = new [] { typeof(bool) })]
        bool? HyperV { get; set; }
        /// <summary>Specifies an operation id if this site has a pending operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies an operation id if this site has a pending operation.",
        SerializedName = @"inProgressOperationId",
        PossibleTypes = new [] { typeof(string) })]
        string InProgressOperationId { get;  }
        /// <summary>
        /// <code>true</code> if the app is a default container; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"<code>true</code> if the app is a default container; otherwise, <code>false</code>.",
        SerializedName = @"isDefaultContainer",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsDefaultContainer { get;  }
        /// <summary>Obsolete: Hyper-V sandbox.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Obsolete: Hyper-V sandbox.",
        SerializedName = @"isXenon",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsXenon { get; set; }
        /// <summary>Last time the app was modified, in UTC. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Last time the app was modified, in UTC. Read-only.",
        SerializedName = @"lastModifiedTimeUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastModifiedTimeUtc { get;  }
        /// <summary>
        /// Maximum number of workers.
        /// This only applies to Functions container.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum number of workers.
        This only applies to Functions container.",
        SerializedName = @"maxNumberOfWorkers",
        PossibleTypes = new [] { typeof(int) })]
        int? MaxNumberOfWorker { get;  }
        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that
        /// site can be hosted with current settings. Read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that site can be hosted with current settings. Read-only.",
        SerializedName = @"outboundIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string OutboundIPAddress { get;  }
        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants
        /// except dataComponent. Read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants except dataComponent. Read-only.",
        SerializedName = @"possibleOutboundIpAddresses",
        PossibleTypes = new [] { typeof(string) })]
        string PossibleOutboundIPAddress { get;  }
        /// <summary>Site redundancy mode</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Site redundancy mode",
        SerializedName = @"redundancyMode",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RedundancyMode) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RedundancyMode? RedundancyMode { get; set; }
        /// <summary>Name of the repository site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the repository site.",
        SerializedName = @"repositorySiteName",
        PossibleTypes = new [] { typeof(string) })]
        string RepositorySiteName { get;  }
        /// <summary><code>true</code> if reserved; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> if reserved; otherwise, <code>false</code>.",
        SerializedName = @"reserved",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Reserved { get; set; }
        /// <summary>Name of the resource group the app belongs to. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Name of the resource group the app belongs to. Read-only.",
        SerializedName = @"resourceGroup",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGroup { get;  }
        /// <summary>
        /// <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.",
        SerializedName = @"scmSiteAlsoStopped",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ScmSiteAlsoStopped { get; set; }
        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID of the associated App Service plan, formatted as: ""/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}"".",
        SerializedName = @"serverFarmId",
        PossibleTypes = new [] { typeof(string) })]
        string ServerFarmId { get; set; }
        /// <summary>Configuration of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configuration of the app.",
        SerializedName = @"siteConfig",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig SiteConfig { get; set; }
        /// <summary>The destination slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The destination slot of the last swap operation.",
        SerializedName = @"destinationSlotName",
        PossibleTypes = new [] { typeof(string) })]
        string SlotSwapStatusDestinationSlotName { get;  }
        /// <summary>The source slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The source slot of the last swap operation.",
        SerializedName = @"sourceSlotName",
        PossibleTypes = new [] { typeof(string) })]
        string SlotSwapStatusSourceSlotName { get;  }
        /// <summary>The time the last successful slot swap completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time the last successful slot swap completed.",
        SerializedName = @"timestampUtc",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SlotSwapStatusTimestampUtc { get;  }
        /// <summary>Current state of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Current state of the app.",
        SerializedName = @"state",
        PossibleTypes = new [] { typeof(string) })]
        string State { get;  }
        /// <summary>App suspended till in case memory-time quota is exceeded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"App suspended till in case memory-time quota is exceeded.",
        SerializedName = @"suspendedTill",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? SuspendedTill { get;  }
        /// <summary>Specifies which deployment slot this app will swap into. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Specifies which deployment slot this app will swap into. Read-only.",
        SerializedName = @"targetSwapSlot",
        PossibleTypes = new [] { typeof(string) })]
        string TargetSwapSlot { get;  }
        /// <summary>Azure Traffic Manager hostnames associated with the app. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Azure Traffic Manager hostnames associated with the app. Read-only.",
        SerializedName = @"trafficManagerHostNames",
        PossibleTypes = new [] { typeof(string) })]
        string[] TrafficManagerHostName { get;  }
        /// <summary>State indicating whether the app has exceeded its quota usage. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"State indicating whether the app has exceeded its quota usage. Read-only.",
        SerializedName = @"usageState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? UsageState { get;  }

    }
    /// SitePatchResource resource specific properties
    internal partial interface ISitePatchResourcePropertiesInternal

    {
        /// <summary>Management information availability state for the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? AvailabilityState { get; set; }
        /// <summary>
        /// <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route
        /// client requests in the same session to the same instance. Default is <code>true</code>.
        /// </summary>
        bool? ClientAffinityEnabled { get; set; }
        /// <summary>
        /// <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>.
        /// Default is <code>false</code>.
        /// </summary>
        bool? ClientCertEnabled { get; set; }
        /// <summary>client certificate authentication comma-separated exclusion paths</summary>
        string ClientCertExclusionPath { get; set; }
        /// <summary>If specified during app creation, the app is cloned from a source app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo CloningInfo { get; set; }
        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
        /// from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides CloningInfoAppSettingsOverride { get; set; }
        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        bool? CloningInfoCloneCustomHostName { get; set; }
        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        bool? CloningInfoCloneSourceControl { get; set; }
        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        bool? CloningInfoConfigureLoadBalancing { get; set; }
        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        /// together to use the same snapshot.
        /// </summary>
        string CloningInfoCorrelationId { get; set; }
        /// <summary>App Service Environment.</summary>
        string CloningInfoHostingEnvironment { get; set; }
        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        bool? CloningInfoOverwrite { get; set; }
        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        string CloningInfoSourceWebAppId { get; set; }
        /// <summary>Location of source app ex: West US or North Europe</summary>
        string CloningInfoSourceWebAppLocation { get; set; }
        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        string CloningInfoTrafficManagerProfileId { get; set; }
        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        string CloningInfoTrafficManagerProfileName { get; set; }
        /// <summary>Size of the function container.</summary>
        int? ContainerSize { get; set; }
        /// <summary>Maximum allowed daily memory-time quota (applicable on dynamic apps only).</summary>
        int? DailyMemoryTimeQuota { get; set; }
        /// <summary>Default hostname of the app. Read-only.</summary>
        string DefaultHostName { get; set; }
        /// <summary>
        /// <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes
        /// the app offline).
        /// </summary>
        bool? Enabled { get; set; }
        /// <summary>
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </summary>
        string[] EnabledHostName { get; set; }
        /// <summary>Hostnames associated with the app.</summary>
        string[] HostName { get; set; }
        /// <summary>Hostname SSL states are used to manage the SSL bindings for app's hostnames.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState[] HostNameSslState { get; set; }
        /// <summary>
        /// <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.
        /// If <code>true</code>, the app is only accessible via API management process.
        /// </summary>
        bool? HostNamesDisabled { get; set; }
        /// <summary>App Service Environment to use for the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile HostingEnvironmentProfile { get; set; }
        /// <summary>Resource ID of the App Service Environment.</summary>
        string HostingEnvironmentProfileId { get; set; }
        /// <summary>Name of the App Service Environment.</summary>
        string HostingEnvironmentProfileName { get; set; }
        /// <summary>Resource type of the App Service Environment.</summary>
        string HostingEnvironmentProfileType { get; set; }
        /// <summary>
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        /// http requests
        /// </summary>
        bool? HttpsOnly { get; set; }
        /// <summary>Hyper-V sandbox.</summary>
        bool? HyperV { get; set; }
        /// <summary>Specifies an operation id if this site has a pending operation.</summary>
        string InProgressOperationId { get; set; }
        /// <summary>
        /// <code>true</code> if the app is a default container; otherwise, <code>false</code>.
        /// </summary>
        bool? IsDefaultContainer { get; set; }
        /// <summary>Obsolete: Hyper-V sandbox.</summary>
        bool? IsXenon { get; set; }
        /// <summary>Last time the app was modified, in UTC. Read-only.</summary>
        global::System.DateTime? LastModifiedTimeUtc { get; set; }
        /// <summary>
        /// Maximum number of workers.
        /// This only applies to Functions container.
        /// </summary>
        int? MaxNumberOfWorker { get; set; }
        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that
        /// site can be hosted with current settings. Read-only.
        /// </summary>
        string OutboundIPAddress { get; set; }
        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants
        /// except dataComponent. Read-only.
        /// </summary>
        string PossibleOutboundIPAddress { get; set; }
        /// <summary>Site redundancy mode</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RedundancyMode? RedundancyMode { get; set; }
        /// <summary>Name of the repository site.</summary>
        string RepositorySiteName { get; set; }
        /// <summary><code>true</code> if reserved; otherwise, <code>false</code>.</summary>
        bool? Reserved { get; set; }
        /// <summary>Name of the resource group the app belongs to. Read-only.</summary>
        string ResourceGroup { get; set; }
        /// <summary>
        /// <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
        /// </summary>
        bool? ScmSiteAlsoStopped { get; set; }
        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        string ServerFarmId { get; set; }
        /// <summary>Configuration of the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig SiteConfig { get; set; }
        /// <summary>Status of the last deployment slot swap operation.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatus SlotSwapStatus { get; set; }
        /// <summary>The destination slot of the last swap operation.</summary>
        string SlotSwapStatusDestinationSlotName { get; set; }
        /// <summary>The source slot of the last swap operation.</summary>
        string SlotSwapStatusSourceSlotName { get; set; }
        /// <summary>The time the last successful slot swap completed.</summary>
        global::System.DateTime? SlotSwapStatusTimestampUtc { get; set; }
        /// <summary>Current state of the app.</summary>
        string State { get; set; }
        /// <summary>App suspended till in case memory-time quota is exceeded.</summary>
        global::System.DateTime? SuspendedTill { get; set; }
        /// <summary>Specifies which deployment slot this app will swap into. Read-only.</summary>
        string TargetSwapSlot { get; set; }
        /// <summary>Azure Traffic Manager hostnames associated with the app. Read-only.</summary>
        string[] TrafficManagerHostName { get; set; }
        /// <summary>State indicating whether the app has exceeded its quota usage. Read-only.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? UsageState { get; set; }

    }
}