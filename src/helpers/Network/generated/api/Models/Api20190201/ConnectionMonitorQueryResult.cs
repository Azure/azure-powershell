namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>List of connection states snapshots.</summary>
    public partial class ConnectionMonitorQueryResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionMonitorQueryResultInternal
    {

        /// <summary>Backing field for <see cref="SourceStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus? _sourceStatus;

        /// <summary>Status of connection monitor source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus? SourceStatus { get => this._sourceStatus; set => this._sourceStatus = value; }

        /// <summary>Backing field for <see cref="State" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot[] _state;

        /// <summary>Information about connection states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot[] State { get => this._state; set => this._state = value; }

        /// <summary>Creates an new <see cref="ConnectionMonitorQueryResult" /> instance.</summary>
        public ConnectionMonitorQueryResult()
        {

        }
    }
    /// List of connection states snapshots.
    public partial interface IConnectionMonitorQueryResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Status of connection monitor source.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Status of connection monitor source.",
        SerializedName = @"sourceStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus? SourceStatus { get; set; }
        /// <summary>Information about connection states.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Information about connection states.",
        SerializedName = @"states",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot[] State { get; set; }

    }
    /// List of connection states snapshots.
    internal partial interface IConnectionMonitorQueryResultInternal

    {
        /// <summary>Status of connection monitor source.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ConnectionMonitorSourceStatus? SourceStatus { get; set; }
        /// <summary>Information about connection states.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IConnectionStateSnapshot[] State { get; set; }

    }
}