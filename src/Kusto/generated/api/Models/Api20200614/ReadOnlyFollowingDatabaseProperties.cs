namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto database properties.</summary>
    public partial class ReadOnlyFollowingDatabaseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabaseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal
    {

        /// <summary>Backing field for <see cref="AttachedDatabaseConfigurationName" /> property.</summary>
        private string _attachedDatabaseConfigurationName;

        /// <summary>The name of the attached database configuration cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string AttachedDatabaseConfigurationName { get => this._attachedDatabaseConfigurationName; }

        /// <summary>Backing field for <see cref="HotCachePeriod" /> property.</summary>
        private global::System.TimeSpan? _hotCachePeriod;

        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public global::System.TimeSpan? HotCachePeriod { get => this._hotCachePeriod; set => this._hotCachePeriod = value; }

        /// <summary>Backing field for <see cref="LeaderClusterResourceId" /> property.</summary>
        private string _leaderClusterResourceId;

        /// <summary>The name of the leader cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public string LeaderClusterResourceId { get => this._leaderClusterResourceId; }

        /// <summary>Internal Acessors for AttachedDatabaseConfigurationName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal.AttachedDatabaseConfigurationName { get => this._attachedDatabaseConfigurationName; set { {_attachedDatabaseConfigurationName = value;} } }

        /// <summary>Internal Acessors for LeaderClusterResourceId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal.LeaderClusterResourceId { get => this._leaderClusterResourceId; set { {_leaderClusterResourceId = value;} } }

        /// <summary>Internal Acessors for PrincipalsModificationKind</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal.PrincipalsModificationKind { get => this._principalsModificationKind; set { {_principalsModificationKind = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for SoftDeletePeriod</summary>
        global::System.TimeSpan? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal.SoftDeletePeriod { get => this._softDeletePeriod; set { {_softDeletePeriod = value;} } }

        /// <summary>Internal Acessors for Statistics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadOnlyFollowingDatabasePropertiesInternal.Statistics { get => (this._statistics = this._statistics ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DatabaseStatistics()); set { {_statistics = value;} } }

        /// <summary>Backing field for <see cref="PrincipalsModificationKind" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? _principalsModificationKind;

        /// <summary>The principals modification kind of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? PrincipalsModificationKind { get => this._principalsModificationKind; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? _provisioningState;

        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="SoftDeletePeriod" /> property.</summary>
        private global::System.TimeSpan? _softDeletePeriod;

        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public global::System.TimeSpan? SoftDeletePeriod { get => this._softDeletePeriod; }

        /// <summary>Backing field for <see cref="Statistics" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics _statistics;

        /// <summary>The statistics of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Statistics { get => (this._statistics = this._statistics ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DatabaseStatistics()); }

        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public float? StatisticsSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatisticsInternal)Statistics).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatisticsInternal)Statistics).Size = value; }

        /// <summary>Creates an new <see cref="ReadOnlyFollowingDatabaseProperties" /> instance.</summary>
        public ReadOnlyFollowingDatabaseProperties()
        {

        }
    }
    /// Class representing the Kusto database properties.
    public partial interface IReadOnlyFollowingDatabaseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The name of the attached database configuration cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the attached database configuration cluster",
        SerializedName = @"attachedDatabaseConfigurationName",
        PossibleTypes = new [] { typeof(string) })]
        string AttachedDatabaseConfigurationName { get;  }
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time the data should be kept in cache for fast queries in TimeSpan.",
        SerializedName = @"hotCachePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>The name of the leader cluster</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the leader cluster",
        SerializedName = @"leaderClusterResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string LeaderClusterResourceId { get;  }
        /// <summary>The principals modification kind of the database</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The principals modification kind of the database",
        SerializedName = @"principalsModificationKind",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? PrincipalsModificationKind { get;  }
        /// <summary>The provisioned state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioned state of the resource.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get;  }
        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The time the data should be kept before it stops being accessible to queries in TimeSpan.",
        SerializedName = @"softDeletePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? SoftDeletePeriod { get;  }
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The database size - the total size of compressed data and index in bytes.",
        SerializedName = @"size",
        PossibleTypes = new [] { typeof(float) })]
        float? StatisticsSize { get; set; }

    }
    /// Class representing the Kusto database properties.
    internal partial interface IReadOnlyFollowingDatabasePropertiesInternal

    {
        /// <summary>The name of the attached database configuration cluster</summary>
        string AttachedDatabaseConfigurationName { get; set; }
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>The name of the leader cluster</summary>
        string LeaderClusterResourceId { get; set; }
        /// <summary>The principals modification kind of the database</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.PrincipalsModificationKind? PrincipalsModificationKind { get; set; }
        /// <summary>The provisioned state of the resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? ProvisioningState { get; set; }
        /// <summary>
        /// The time the data should be kept before it stops being accessible to queries in TimeSpan.
        /// </summary>
        global::System.TimeSpan? SoftDeletePeriod { get; set; }
        /// <summary>The statistics of the database.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Statistics { get; set; }
        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        float? StatisticsSize { get; set; }

    }
}