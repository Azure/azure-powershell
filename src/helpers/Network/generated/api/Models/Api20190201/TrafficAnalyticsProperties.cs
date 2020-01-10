namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Parameters that define the configuration of traffic analytics.</summary>
    public partial class TrafficAnalyticsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal
    {

        /// <summary>Internal Acessors for NetworkWatcherFlowAnalyticsConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal.NetworkWatcherFlowAnalyticsConfiguration { get => (this._networkWatcherFlowAnalyticsConfiguration = this._networkWatcherFlowAnalyticsConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsConfigurationProperties()); set { {_networkWatcherFlowAnalyticsConfiguration = value;} } }

        /// <summary>Flag to enable/disable traffic analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool NetworkWatcherFlowAnalyticConfigurationEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).Enabled = value; }

        /// <summary>
        /// The interval in minutes which would decide how frequently TA service should do flow analytics
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).TrafficAnalyticsInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).TrafficAnalyticsInterval = value; }

        /// <summary>The resource guid of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkWatcherFlowAnalyticConfigurationWorkspaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).WorkspaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).WorkspaceId = value; }

        /// <summary>The location of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).WorkspaceRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).WorkspaceRegion = value; }

        /// <summary>Resource Id of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).WorkspaceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationPropertiesInternal)NetworkWatcherFlowAnalyticsConfiguration).WorkspaceResourceId = value; }

        /// <summary>
        /// Backing field for <see cref="NetworkWatcherFlowAnalyticsConfiguration" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties _networkWatcherFlowAnalyticsConfiguration;

        /// <summary>Parameters that define the configuration of traffic analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties NetworkWatcherFlowAnalyticsConfiguration { get => (this._networkWatcherFlowAnalyticsConfiguration = this._networkWatcherFlowAnalyticsConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsConfigurationProperties()); set => this._networkWatcherFlowAnalyticsConfiguration = value; }

        /// <summary>Creates an new <see cref="TrafficAnalyticsProperties" /> instance.</summary>
        public TrafficAnalyticsProperties()
        {

        }
    }
    /// Parameters that define the configuration of traffic analytics.
    public partial interface ITrafficAnalyticsProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Flag to enable/disable traffic analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Flag to enable/disable traffic analytics.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool NetworkWatcherFlowAnalyticConfigurationEnabled { get; set; }
        /// <summary>
        /// The interval in minutes which would decide how frequently TA service should do flow analytics
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The interval in minutes which would decide how frequently TA service should do flow analytics",
        SerializedName = @"trafficAnalyticsInterval",
        PossibleTypes = new [] { typeof(int) })]
        int? NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval { get; set; }
        /// <summary>The resource guid of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The resource guid of the attached workspace",
        SerializedName = @"workspaceId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkWatcherFlowAnalyticConfigurationWorkspaceId { get; set; }
        /// <summary>The location of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The location of the attached workspace",
        SerializedName = @"workspaceRegion",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion { get; set; }
        /// <summary>Resource Id of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Resource Id of the attached workspace ",
        SerializedName = @"workspaceResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId { get; set; }

    }
    /// Parameters that define the configuration of traffic analytics.
    internal partial interface ITrafficAnalyticsPropertiesInternal

    {
        /// <summary>Flag to enable/disable traffic analytics.</summary>
        bool NetworkWatcherFlowAnalyticConfigurationEnabled { get; set; }
        /// <summary>
        /// The interval in minutes which would decide how frequently TA service should do flow analytics
        /// </summary>
        int? NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval { get; set; }
        /// <summary>The resource guid of the attached workspace</summary>
        string NetworkWatcherFlowAnalyticConfigurationWorkspaceId { get; set; }
        /// <summary>The location of the attached workspace</summary>
        string NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion { get; set; }
        /// <summary>Resource Id of the attached workspace</summary>
        string NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId { get; set; }
        /// <summary>Parameters that define the configuration of traffic analytics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties NetworkWatcherFlowAnalyticsConfiguration { get; set; }

    }
}