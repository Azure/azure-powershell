namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when
    /// geo-redundant replication is enabled for the storage account.
    /// </summary>
    public partial class GeoReplicationStats :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStats,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal
    {

        /// <summary>Backing field for <see cref="CanFailover" /> property.</summary>
        private bool? _canFailover;

        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public bool? CanFailover { get => this._canFailover; }

        /// <summary>Backing field for <see cref="LastSyncTime" /> property.</summary>
        private global::System.DateTime? _lastSyncTime;

        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public global::System.DateTime? LastSyncTime { get => this._lastSyncTime; }

        /// <summary>Internal Acessors for CanFailover</summary>
        bool? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal.CanFailover { get => this._canFailover; set { {_canFailover = value;} } }

        /// <summary>Internal Acessors for LastSyncTime</summary>
        global::System.DateTime? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal.LastSyncTime { get => this._lastSyncTime; set { {_lastSyncTime = value;} } }

        /// <summary>Internal Acessors for Status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190401.IGeoReplicationStatsInternal.Status { get => this._status; set { {_status = value;} } }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? _status;

        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? Status { get => this._status; }

        /// <summary>Creates an new <see cref="GeoReplicationStats" /> instance.</summary>
        public GeoReplicationStats()
        {

        }
    }
    /// Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when
    /// geo-redundant replication is enabled for the storage account.
    public partial interface IGeoReplicationStats :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A boolean flag which indicates whether or not account failover is supported for the account.",
        SerializedName = @"canFailover",
        PossibleTypes = new [] { typeof(bool) })]
        bool? CanFailover { get;  }
        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime is not available, this can happen if secondary is offline or we are in bootstrap.",
        SerializedName = @"lastSyncTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? LastSyncTime { get;  }
        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location is temporarily unavailable.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? Status { get;  }

    }
    /// Statistics related to replication for storage account's Blob, Table, Queue and File services. It is only available when
    /// geo-redundant replication is enabled for the storage account.
    internal partial interface IGeoReplicationStatsInternal

    {
        /// <summary>
        /// A boolean flag which indicates whether or not account failover is supported for the account.
        /// </summary>
        bool? CanFailover { get; set; }
        /// <summary>
        /// All primary writes preceding this UTC date/time value are guaranteed to be available for read operations. Primary writes
        /// following this point in time may or may not be available for reads. Element may be default value if value of LastSyncTime
        /// is not available, this can happen if secondary is offline or we are in bootstrap.
        /// </summary>
        global::System.DateTime? LastSyncTime { get; set; }
        /// <summary>
        /// The status of the secondary location. Possible values are: - Live: Indicates that the secondary location is active and
        /// operational. - Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in
        /// progress.This typically occurs when replication is first enabled. - Unavailable: Indicates that the secondary location
        /// is temporarily unavailable.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Support.GeoReplicationStatus? Status { get; set; }

    }
}