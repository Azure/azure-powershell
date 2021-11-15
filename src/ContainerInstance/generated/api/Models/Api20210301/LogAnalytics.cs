namespace Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Extensions;

    /// <summary>Container group log analytics information.</summary>
    public partial class LogAnalytics :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalytics,
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsInternal
    {

        /// <summary>Backing field for <see cref="LogType" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? _logType;

        /// <summary>The log type to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogType { get => this._logType; set => this._logType = value; }

        /// <summary>Backing field for <see cref="Metadata" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata _metadata;

        /// <summary>Metadata for log analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata Metadata { get => (this._metadata = this._metadata ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsMetadata()); set => this._metadata = value; }

        /// <summary>Backing field for <see cref="WorkspaceId" /> property.</summary>
        private string _workspaceId;

        /// <summary>The workspace id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string WorkspaceId { get => this._workspaceId; set => this._workspaceId = value; }

        /// <summary>Backing field for <see cref="WorkspaceKey" /> property.</summary>
        private string _workspaceKey;

        /// <summary>The workspace key for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public string WorkspaceKey { get => this._workspaceKey; set => this._workspaceKey = value; }

        /// <summary>Backing field for <see cref="WorkspaceResourceId" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId _workspaceResourceId;

        /// <summary>The workspace resource id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Origin(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId WorkspaceResourceId { get => (this._workspaceResourceId = this._workspaceResourceId ?? new Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.LogAnalyticsWorkspaceResourceId()); set => this._workspaceResourceId = value; }

        /// <summary>Creates an new <see cref="LogAnalytics" /> instance.</summary>
        public LogAnalytics()
        {

        }
    }
    /// Container group log analytics information.
    public partial interface ILogAnalytics :
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.IJsonSerializable
    {
        /// <summary>The log type to be used.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The log type to be used.",
        SerializedName = @"logType",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogType { get; set; }
        /// <summary>Metadata for log analytics.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Metadata for log analytics.",
        SerializedName = @"metadata",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata Metadata { get; set; }
        /// <summary>The workspace id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The workspace id for log analytics",
        SerializedName = @"workspaceId",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceId { get; set; }
        /// <summary>The workspace key for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The workspace key for log analytics",
        SerializedName = @"workspaceKey",
        PossibleTypes = new [] { typeof(string) })]
        string WorkspaceKey { get; set; }
        /// <summary>The workspace resource id for log analytics</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The workspace resource id for log analytics",
        SerializedName = @"workspaceResourceId",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId) })]
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId WorkspaceResourceId { get; set; }

    }
    /// Container group log analytics information.
    internal partial interface ILogAnalyticsInternal

    {
        /// <summary>The log type to be used.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.LogAnalyticsLogType? LogType { get; set; }
        /// <summary>Metadata for log analytics.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsMetadata Metadata { get; set; }
        /// <summary>The workspace id for log analytics</summary>
        string WorkspaceId { get; set; }
        /// <summary>The workspace key for log analytics</summary>
        string WorkspaceKey { get; set; }
        /// <summary>The workspace resource id for log analytics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ILogAnalyticsWorkspaceResourceId WorkspaceResourceId { get; set; }

    }
}