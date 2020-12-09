namespace Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Extensions;

    /// <summary>Class representing the Kusto database properties.</summary>
    public partial class ReadWriteDatabaseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabaseProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal
    {

        /// <summary>Backing field for <see cref="HotCachePeriod" /> property.</summary>
        private global::System.TimeSpan? _hotCachePeriod;

        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public global::System.TimeSpan? HotCachePeriod { get => this._hotCachePeriod; set => this._hotCachePeriod = value; }

        /// <summary>Backing field for <see cref="IsFollowed" /> property.</summary>
        private bool? _isFollowed;

        /// <summary>Indicates whether the database is followed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        public bool? IsFollowed { get => this._isFollowed; }

        /// <summary>Internal Acessors for IsFollowed</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal.IsFollowed { get => this._isFollowed; set { {_isFollowed = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Support.ProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Internal Acessors for Statistics</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IReadWriteDatabasePropertiesInternal.Statistics { get => (this._statistics = this._statistics ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DatabaseStatistics()); set { {_statistics = value;} } }

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
        public global::System.TimeSpan? SoftDeletePeriod { get => this._softDeletePeriod; set => this._softDeletePeriod = value; }

        /// <summary>Backing field for <see cref="Statistics" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics _statistics;

        /// <summary>The statistics of the database.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatistics Statistics { get => (this._statistics = this._statistics ?? new Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.DatabaseStatistics()); }

        /// <summary>The database size - the total size of compressed data and index in bytes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Origin(Microsoft.Azure.PowerShell.Cmdlets.Kusto.PropertyOrigin.Inlined)]
        public float? StatisticsSize { get => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatisticsInternal)Statistics).Size; set => ((Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20200614.IDatabaseStatisticsInternal)Statistics).Size = value; }

        /// <summary>Creates an new <see cref="ReadWriteDatabaseProperties" /> instance.</summary>
        public ReadWriteDatabaseProperties()
        {

        }
    }
    /// Class representing the Kusto database properties.
    public partial interface IReadWriteDatabaseProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.IJsonSerializable
    {
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The time the data should be kept in cache for fast queries in TimeSpan.",
        SerializedName = @"hotCachePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>Indicates whether the database is followed.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Kusto.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Indicates whether the database is followed.",
        SerializedName = @"isFollowed",
        PossibleTypes = new [] { typeof(bool) })]
        bool? IsFollowed { get;  }
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
        ReadOnly = false,
        Description = @"The time the data should be kept before it stops being accessible to queries in TimeSpan.",
        SerializedName = @"softDeletePeriod",
        PossibleTypes = new [] { typeof(global::System.TimeSpan) })]
        global::System.TimeSpan? SoftDeletePeriod { get; set; }
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
    internal partial interface IReadWriteDatabasePropertiesInternal

    {
        /// <summary>The time the data should be kept in cache for fast queries in TimeSpan.</summary>
        global::System.TimeSpan? HotCachePeriod { get; set; }
        /// <summary>Indicates whether the database is followed.</summary>
        bool? IsFollowed { get; set; }
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