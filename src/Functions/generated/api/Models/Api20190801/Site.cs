namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>A web app, a mobile app backend, or an API app.</summary>
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.DoNotFormat]
    public partial class Site :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISite,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.Resource();

        /// <summary>Management information availability state for the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? AvailabilityState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).AvailabilityState; }

        /// <summary>
        /// <code>true</code> to enable client affinity; <code>false</code> to stop sending session affinity cookies, which route
        /// client requests in the same session to the same instance. Default is <code>true</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ClientAffinityEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ClientAffinityEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ClientAffinityEnabled = value; }

        /// <summary>
        /// <code>true</code> to enable client certificate authentication (TLS mutual authentication); otherwise, <code>false</code>.
        /// Default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ClientCertEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ClientCertEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ClientCertEnabled = value; }

        /// <summary>client certificate authentication comma-separated exclusion paths</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ClientCertExclusionPath { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ClientCertExclusionPath; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ClientCertExclusionPath = value; }

        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
        /// from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides CloningInfoAppSettingsOverride { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoAppSettingsOverride; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoAppSettingsOverride = value; }

        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoCloneCustomHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoCloneCustomHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoCloneCustomHostName = value; }

        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoCloneSourceControl { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoCloneSourceControl; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoCloneSourceControl = value; }

        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoConfigureLoadBalancing { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoConfigureLoadBalancing; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoConfigureLoadBalancing = value; }

        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        /// together to use the same snapshot.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoCorrelationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoCorrelationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoCorrelationId = value; }

        /// <summary>App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoHostingEnvironment { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoHostingEnvironment; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoHostingEnvironment = value; }

        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? CloningInfoOverwrite { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoOverwrite; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoOverwrite = value; }

        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoSourceWebAppId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoSourceWebAppId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoSourceWebAppId = value; }

        /// <summary>Location of source app ex: West US or North Europe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoSourceWebAppLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoSourceWebAppLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoSourceWebAppLocation = value; }

        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoTrafficManagerProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoTrafficManagerProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoTrafficManagerProfileId = value; }

        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string CloningInfoTrafficManagerProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoTrafficManagerProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfoTrafficManagerProfileName = value; }

        /// <summary>Configuration of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig Config { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SiteConfig; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SiteConfig = value; }

        /// <summary>Size of the function container.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? ContainerSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ContainerSize; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ContainerSize = value; }

        /// <summary>Maximum allowed daily memory-time quota (applicable on dynamic apps only).</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? DailyMemoryTimeQuota { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).DailyMemoryTimeQuota; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).DailyMemoryTimeQuota = value; }

        /// <summary>Default hostname of the app. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string DefaultHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).DefaultHostName; }

        /// <summary>
        /// <code>true</code> if the app is enabled; otherwise, <code>false</code>. Setting this value to false disables the app (takes
        /// the app offline).
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).Enabled = value; }

        /// <summary>
        /// Enabled hostnames for the app.Hostnames need to be assigned (see HostNames) AND enabled. Otherwise,
        /// the app is not served on those hostnames.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] EnabledHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).EnabledHostName; }

        /// <summary>Hostnames associated with the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostName; }

        /// <summary>Hostname SSL states are used to manage the SSL bindings for app's hostnames.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostNameSslState[] HostNameSslState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostNameSslState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostNameSslState = value; }

        /// <summary>
        /// <code>true</code> to disable the public hostnames of the app; otherwise, <code>false</code>.
        /// If <code>true</code>, the app is only accessible via API management process.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HostNamesDisabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostNamesDisabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostNamesDisabled = value; }

        /// <summary>Resource ID of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileId = value; }

        /// <summary>Name of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileName; }

        /// <summary>Resource type of the App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileType; }

        /// <summary>
        /// HttpsOnly: configures a web site to accept only https requests. Issues redirect for
        /// http requests
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HttpsOnly { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HttpsOnly; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HttpsOnly = value; }

        /// <summary>Hyper-V sandbox.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? HyperV { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HyperV; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HyperV = value; }

        /// <summary>Resource Id.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Identity" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity _identity;

        /// <summary>Managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentity()); set => this._identity = value; }

        /// <summary>Principal Id of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).PrincipalId; }

        /// <summary>Tenant of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).TenantId; }

        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? IdentityType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).Type = value; }

        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).UserAssignedIdentity = value; }

        /// <summary>Specifies an operation id if this site has a pending operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string InProgressOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).InProgressOperationId; }

        /// <summary>
        /// <code>true</code> if the app is a default container; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsDefaultContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).IsDefaultContainer; }

        /// <summary>Obsolete: Hyper-V sandbox.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? IsXenon { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).IsXenon; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).IsXenon = value; }

        /// <summary>Kind of resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Kind { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Kind = value; }

        /// <summary>Last time the app was modified, in UTC. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? LastModifiedTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).LastModifiedTimeUtc; }

        /// <summary>Resource Location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Location = value; }

        /// <summary>
        /// Maximum number of workers.
        /// This only applies to Functions container.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public int? MaxNumberOfWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).MaxNumberOfWorker; }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for AvailabilityState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.SiteAvailabilityState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.AvailabilityState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).AvailabilityState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).AvailabilityState = value; }

        /// <summary>Internal Acessors for CloningInfo</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.CloningInfo { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfo; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).CloningInfo = value; }

        /// <summary>Internal Acessors for DefaultHostName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.DefaultHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).DefaultHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).DefaultHostName = value; }

        /// <summary>Internal Acessors for EnabledHostName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.EnabledHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).EnabledHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).EnabledHostName = value; }

        /// <summary>Internal Acessors for HostName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.HostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfile</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IHostingEnvironmentProfile Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.HostingEnvironmentProfile { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfile; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfile = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.HostingEnvironmentProfileName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileName = value; }

        /// <summary>Internal Acessors for HostingEnvironmentProfileType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.HostingEnvironmentProfileType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).HostingEnvironmentProfileType = value; }

        /// <summary>Internal Acessors for Identity</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.Identity { get => (this._identity = this._identity ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ManagedServiceIdentity()); set { {_identity = value;} } }

        /// <summary>Internal Acessors for IdentityPrincipalId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.IdentityPrincipalId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).PrincipalId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).PrincipalId = value; }

        /// <summary>Internal Acessors for IdentityTenantId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.IdentityTenantId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).TenantId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityInternal)Identity).TenantId = value; }

        /// <summary>Internal Acessors for InProgressOperationId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.InProgressOperationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).InProgressOperationId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).InProgressOperationId = value; }

        /// <summary>Internal Acessors for IsDefaultContainer</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.IsDefaultContainer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).IsDefaultContainer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).IsDefaultContainer = value; }

        /// <summary>Internal Acessors for LastModifiedTimeUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.LastModifiedTimeUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).LastModifiedTimeUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).LastModifiedTimeUtc = value; }

        /// <summary>Internal Acessors for MaxNumberOfWorker</summary>
        int? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.MaxNumberOfWorker { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).MaxNumberOfWorker; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).MaxNumberOfWorker = value; }

        /// <summary>Internal Acessors for OutboundIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.OutboundIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).OutboundIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).OutboundIPAddress = value; }

        /// <summary>Internal Acessors for PossibleOutboundIPAddress</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.PossibleOutboundIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).PossibleOutboundIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).PossibleOutboundIPAddress = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RepositorySiteName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.RepositorySiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).RepositorySiteName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).RepositorySiteName = value; }

        /// <summary>Internal Acessors for ResourceGroup</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ResourceGroup; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ResourceGroup = value; }

        /// <summary>Internal Acessors for SlotSwapStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISlotSwapStatus Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.SlotSwapStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatus = value; }

        /// <summary>Internal Acessors for SlotSwapStatusDestinationSlotName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.SlotSwapStatusDestinationSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusDestinationSlotName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusDestinationSlotName = value; }

        /// <summary>Internal Acessors for SlotSwapStatusSourceSlotName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.SlotSwapStatusSourceSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusSourceSlotName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusSourceSlotName = value; }

        /// <summary>Internal Acessors for SlotSwapStatusTimestampUtc</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.SlotSwapStatusTimestampUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusTimestampUtc; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusTimestampUtc = value; }

        /// <summary>Internal Acessors for State</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).State; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).State = value; }

        /// <summary>Internal Acessors for SuspendedTill</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.SuspendedTill { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SuspendedTill; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SuspendedTill = value; }

        /// <summary>Internal Acessors for TargetSwapSlot</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.TargetSwapSlot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).TargetSwapSlot; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).TargetSwapSlot = value; }

        /// <summary>Internal Acessors for TrafficManagerHostName</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.TrafficManagerHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).TrafficManagerHostName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).TrafficManagerHostName = value; }

        /// <summary>Internal Acessors for UsageState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteInternal.UsageState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).UsageState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).UsageState = value; }

        /// <summary>Resource Name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Name; }

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from tenants that
        /// site can be hosted with current settings. Read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string OutboundIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).OutboundIPAddress; }

        /// <summary>
        /// List of IP addresses that the app uses for outbound connections (e.g. database access). Includes VIPs from all tenants
        /// except dataComponent. Read-only.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string PossibleOutboundIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).PossibleOutboundIPAddress; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties _property;

        /// <summary>Site resource specific properties</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.SiteProperties()); set => this._property = value; }

        /// <summary>Site redundancy mode</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.RedundancyMode? RedundancyMode { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).RedundancyMode; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).RedundancyMode = value; }

        /// <summary>Name of the repository site.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string RepositorySiteName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).RepositorySiteName; }

        /// <summary><code>true</code> if reserved; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? Reserved { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).Reserved; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).Reserved = value; }

        /// <summary>Name of the resource group the app belongs to. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ResourceGroup { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ResourceGroup; }

        /// <summary>
        /// <code>true</code> to stop SCM (KUDU) site when the app is stopped; otherwise, <code>false</code>. The default is <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public bool? ScmSiteAlsoStopped { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ScmSiteAlsoStopped; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ScmSiteAlsoStopped = value; }

        /// <summary>
        /// Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string ServerFarmId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ServerFarmId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).ServerFarmId = value; }

        /// <summary>The destination slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlotSwapStatusDestinationSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusDestinationSlotName; }

        /// <summary>The source slot of the last swap operation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string SlotSwapStatusSourceSlotName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusSourceSlotName; }

        /// <summary>The time the last successful slot swap completed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SlotSwapStatusTimestampUtc { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SlotSwapStatusTimestampUtc; }

        /// <summary>Current state of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string State { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).State; }

        /// <summary>App suspended till in case memory-time quota is exceeded.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public global::System.DateTime? SuspendedTill { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).SuspendedTill; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Tag = value; }

        /// <summary>Specifies which deployment slot this app will swap into. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string TargetSwapSlot { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).TargetSwapSlot; }

        /// <summary>Azure Traffic Manager hostnames associated with the app. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public string[] TrafficManagerHostName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).TrafficManagerHostName; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal)__resource).Type; }

        /// <summary>State indicating whether the app has exceeded its quota usage. Read-only.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.UsageState? UsageState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISitePropertiesInternal)Property).UsageState; }

        /// <summary>Creates an new <see cref="Site" /> instance.</summary>
        public Site()
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
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// A web app, a mobile app backend, or an API app.
    public partial interface ISite :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResource
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
        /// <summary>Configuration of the app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configuration of the app.",
        SerializedName = @"siteConfig",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig Config { get; set; }
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
        /// <summary>Principal Id of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Principal Id of managed service identity.",
        SerializedName = @"principalId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityPrincipalId { get;  }
        /// <summary>Tenant of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Tenant of managed service identity.",
        SerializedName = @"tenantId",
        PossibleTypes = new [] { typeof(string) })]
        string IdentityTenantId { get;  }
        /// <summary>Type of managed service identity.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Type of managed service identity.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}",
        SerializedName = @"userAssignedIdentities",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
    /// A web app, a mobile app backend, or an API app.
    internal partial interface ISiteInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IResourceInternal
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
        /// <summary>Configuration of the app.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteConfig Config { get; set; }
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
        /// <summary>Managed service identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentity Identity { get; set; }
        /// <summary>Principal Id of managed service identity.</summary>
        string IdentityPrincipalId { get; set; }
        /// <summary>Tenant of managed service identity.</summary>
        string IdentityTenantId { get; set; }
        /// <summary>Type of managed service identity.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.ManagedServiceIdentityType? IdentityType { get; set; }
        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be
        /// ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IManagedServiceIdentityUserAssignedIdentities IdentityUserAssignedIdentity { get; set; }
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
        /// <summary>Site resource specific properties</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ISiteProperties Property { get; set; }
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