namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>Information needed for cloning operation.</summary>
    public partial class CloningInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfo,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoInternal
    {

        /// <summary>Backing field for <see cref="AppSettingsOverride" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides _appSettingsOverride;

        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
        /// from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides AppSettingsOverride { get => (this._appSettingsOverride = this._appSettingsOverride ?? new Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.CloningInfoAppSettingsOverrides()); set => this._appSettingsOverride = value; }

        /// <summary>Backing field for <see cref="CloneCustomHostName" /> property.</summary>
        private bool? _cloneCustomHostName;

        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? CloneCustomHostName { get => this._cloneCustomHostName; set => this._cloneCustomHostName = value; }

        /// <summary>Backing field for <see cref="CloneSourceControl" /> property.</summary>
        private bool? _cloneSourceControl;

        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? CloneSourceControl { get => this._cloneSourceControl; set => this._cloneSourceControl = value; }

        /// <summary>Backing field for <see cref="ConfigureLoadBalancing" /> property.</summary>
        private bool? _configureLoadBalancing;

        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? ConfigureLoadBalancing { get => this._configureLoadBalancing; set => this._configureLoadBalancing = value; }

        /// <summary>Backing field for <see cref="CorrelationId" /> property.</summary>
        private string _correlationId;

        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        /// together to use the same snapshot.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string CorrelationId { get => this._correlationId; set => this._correlationId = value; }

        /// <summary>Backing field for <see cref="HostingEnvironment" /> property.</summary>
        private string _hostingEnvironment;

        /// <summary>App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string HostingEnvironment { get => this._hostingEnvironment; set => this._hostingEnvironment = value; }

        /// <summary>Backing field for <see cref="Overwrite" /> property.</summary>
        private bool? _overwrite;

        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? Overwrite { get => this._overwrite; set => this._overwrite = value; }

        /// <summary>Backing field for <see cref="SourceWebAppId" /> property.</summary>
        private string _sourceWebAppId;

        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SourceWebAppId { get => this._sourceWebAppId; set => this._sourceWebAppId = value; }

        /// <summary>Backing field for <see cref="SourceWebAppLocation" /> property.</summary>
        private string _sourceWebAppLocation;

        /// <summary>Location of source app ex: West US or North Europe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string SourceWebAppLocation { get => this._sourceWebAppLocation; set => this._sourceWebAppLocation = value; }

        /// <summary>Backing field for <see cref="TrafficManagerProfileId" /> property.</summary>
        private string _trafficManagerProfileId;

        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TrafficManagerProfileId { get => this._trafficManagerProfileId; set => this._trafficManagerProfileId = value; }

        /// <summary>Backing field for <see cref="TrafficManagerProfileName" /> property.</summary>
        private string _trafficManagerProfileName;

        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string TrafficManagerProfileName { get => this._trafficManagerProfileName; set => this._trafficManagerProfileName = value; }

        /// <summary>Creates an new <see cref="CloningInfo" /> instance.</summary>
        public CloningInfo()
        {

        }
    }
    /// Information needed for cloning operation.
    public partial interface ICloningInfo :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
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
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides AppSettingsOverride { get; set; }
        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.",
        SerializedName = @"cloneCustomHostNames",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CloneCustomHostName { get; set; }
        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to clone source control from source app; otherwise, <code>false</code>.",
        SerializedName = @"cloneSourceControl",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CloneSourceControl { get; set; }
        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to configure load balancing for source and destination app.",
        SerializedName = @"configureLoadBalancing",
        PossibleTypes = new [] { typeof(bool) })]
        bool? ConfigureLoadBalancing { get; set; }
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
        string CorrelationId { get; set; }
        /// <summary>App Service Environment.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"App Service Environment.",
        SerializedName = @"hostingEnvironment",
        PossibleTypes = new [] { typeof(string) })]
        string HostingEnvironment { get; set; }
        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"<code>true</code> to overwrite destination app; otherwise, <code>false</code>.",
        SerializedName = @"overwrite",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Overwrite { get; set; }
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
        string SourceWebAppId { get; set; }
        /// <summary>Location of source app ex: West US or North Europe</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Location of source app ex: West US or North Europe",
        SerializedName = @"sourceWebAppLocation",
        PossibleTypes = new [] { typeof(string) })]
        string SourceWebAppLocation { get; set; }
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
        string TrafficManagerProfileId { get; set; }
        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.",
        SerializedName = @"trafficManagerProfileName",
        PossibleTypes = new [] { typeof(string) })]
        string TrafficManagerProfileName { get; set; }

    }
    /// Information needed for cloning operation.
    internal partial interface ICloningInfoInternal

    {
        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned
        /// from source app. Otherwise, application settings from source app are retained.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.ICloningInfoAppSettingsOverrides AppSettingsOverride { get; set; }
        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        bool? CloneCustomHostName { get; set; }
        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        bool? CloneSourceControl { get; set; }
        /// <summary><code>true</code> to configure load balancing for source and destination app.</summary>
        bool? ConfigureLoadBalancing { get; set; }
        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        /// together to use the same snapshot.
        /// </summary>
        string CorrelationId { get; set; }
        /// <summary>App Service Environment.</summary>
        string HostingEnvironment { get; set; }
        /// <summary><code>true</code> to overwrite destination app; otherwise, <code>false</code>.</summary>
        bool? Overwrite { get; set; }
        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName} for production slots
        /// and
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{siteName}/slots/{slotName} for
        /// other slots.
        /// </summary>
        string SourceWebAppId { get; set; }
        /// <summary>Location of source app ex: West US or North Europe</summary>
        string SourceWebAppLocation { get; set; }
        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form
        /// /subscriptions/{subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/trafficManagerProfiles/{profileName}.
        /// </summary>
        string TrafficManagerProfileId { get; set; }
        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        string TrafficManagerProfileName { get; set; }

    }
}