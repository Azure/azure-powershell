namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Information on the configuration of flow log and traffic analytics (optional) .</summary>
    public partial class FlowLogInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformation,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal
    {

        /// <summary>Flag to enable/disable flow logging.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool Enabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).Enabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).Enabled = value; }

        /// <summary>Backing field for <see cref="FlowAnalyticsConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties _flowAnalyticsConfiguration;

        /// <summary>Parameters that define the configuration of traffic analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties FlowAnalyticsConfiguration { get => (this._flowAnalyticsConfiguration = this._flowAnalyticsConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsProperties()); set => this._flowAnalyticsConfiguration = value; }

        /// <summary>The file type of flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? FormatType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).FormatType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).FormatType = value; }

        /// <summary>The version (revision) of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? FormatVersion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).FormatVersion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).FormatVersion = value; }

        /// <summary>
        /// Internal Acessors for FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal.FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticsConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticsConfiguration = value; }

        /// <summary>Internal Acessors for FlowAnalyticsConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal.FlowAnalyticsConfiguration { get => (this._flowAnalyticsConfiguration = this._flowAnalyticsConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.TrafficAnalyticsProperties()); set { {_flowAnalyticsConfiguration = value;} } }

        /// <summary>Internal Acessors for Format</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal.Format { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).Format; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).Format = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for RetentionPolicy</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogInformationInternal.RetentionPolicy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).RetentionPolicy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).RetentionPolicy = value; }

        /// <summary>Flag to enable/disable traffic analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool NetworkWatcherFlowAnalyticConfigurationEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationEnabled = value; }

        /// <summary>
        /// The interval in minutes which would decide how frequently TA service should do flow analytics
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationTrafficAnalyticsInterval = value; }

        /// <summary>The resource guid of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkWatcherFlowAnalyticConfigurationWorkspaceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationWorkspaceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationWorkspaceId = value; }

        /// <summary>The location of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationWorkspaceRegion = value; }

        /// <summary>Resource Id of the attached workspace</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsPropertiesInternal)FlowAnalyticsConfiguration).NetworkWatcherFlowAnalyticConfigurationWorkspaceResourceId = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties _property;

        /// <summary>Properties of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.FlowLogProperties()); set => this._property = value; }

        /// <summary>Number of days to retain flow log records.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? RetentionPolicyDay { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).RetentionPolicyDay; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).RetentionPolicyDay = value; }

        /// <summary>Flag to enable/disable retention.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public bool? RetentionPolicyEnabled { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).RetentionPolicyEnabled; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).RetentionPolicyEnabled = value; }

        /// <summary>ID of the storage account which is used to store the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string StorageId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).StorageId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogPropertiesInternal)Property).StorageId = value; }

        /// <summary>Backing field for <see cref="TargetResourceId" /> property.</summary>
        private string _targetResourceId;

        /// <summary>
        /// The ID of the resource to configure for flow log and traffic analytics (optional) .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string TargetResourceId { get => this._targetResourceId; set => this._targetResourceId = value; }

        /// <summary>Creates an new <see cref="FlowLogInformation" /> instance.</summary>
        public FlowLogInformation()
        {

        }
    }
    /// Information on the configuration of flow log and traffic analytics (optional) .
    public partial interface IFlowLogInformation :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Flag to enable/disable flow logging.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Flag to enable/disable flow logging.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool Enabled { get; set; }
        /// <summary>The file type of flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The file type of flow log.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? FormatType { get; set; }
        /// <summary>The version (revision) of the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The version (revision) of the flow log.",
        SerializedName = @"version",
        PossibleTypes = new [] { typeof(int) })]
        int? FormatVersion { get; set; }
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
        /// <summary>Number of days to retain flow log records.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Number of days to retain flow log records.",
        SerializedName = @"days",
        PossibleTypes = new [] { typeof(int) })]
        int? RetentionPolicyDay { get; set; }
        /// <summary>Flag to enable/disable retention.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Flag to enable/disable retention.",
        SerializedName = @"enabled",
        PossibleTypes = new [] { typeof(bool) })]
        bool? RetentionPolicyEnabled { get; set; }
        /// <summary>ID of the storage account which is used to store the flow log.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"ID of the storage account which is used to store the flow log.",
        SerializedName = @"storageId",
        PossibleTypes = new [] { typeof(string) })]
        string StorageId { get; set; }
        /// <summary>
        /// The ID of the resource to configure for flow log and traffic analytics (optional) .
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The ID of the resource to configure for flow log and traffic analytics (optional) .",
        SerializedName = @"targetResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string TargetResourceId { get; set; }

    }
    /// Information on the configuration of flow log and traffic analytics (optional) .
    internal partial interface IFlowLogInformationInternal

    {
        /// <summary>Flag to enable/disable flow logging.</summary>
        bool Enabled { get; set; }
        /// <summary>Parameters that define the configuration of traffic analytics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsConfigurationProperties FlowAnalyticConfigurationNetworkWatcherFlowAnalyticsConfiguration { get; set; }
        /// <summary>Parameters that define the configuration of traffic analytics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ITrafficAnalyticsProperties FlowAnalyticsConfiguration { get; set; }
        /// <summary>Parameters that define the flow log format.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogFormatParameters Format { get; set; }
        /// <summary>The file type of flow log.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.FlowLogFormatType? FormatType { get; set; }
        /// <summary>The version (revision) of the flow log.</summary>
        int? FormatVersion { get; set; }
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
        /// <summary>Properties of the flow log.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFlowLogProperties Property { get; set; }
        /// <summary>Parameters that define the retention policy for flow log.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IRetentionPolicyParameters RetentionPolicy { get; set; }
        /// <summary>Number of days to retain flow log records.</summary>
        int? RetentionPolicyDay { get; set; }
        /// <summary>Flag to enable/disable retention.</summary>
        bool? RetentionPolicyEnabled { get; set; }
        /// <summary>ID of the storage account which is used to store the flow log.</summary>
        string StorageId { get; set; }
        /// <summary>
        /// The ID of the resource to configure for flow log and traffic analytics (optional) .
        /// </summary>
        string TargetResourceId { get; set; }

    }
}