namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Status of packet capture session.</summary>
    public partial class PacketCaptureQueryStatusResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureQueryStatusResultInternal
    {

        /// <summary>Backing field for <see cref="CaptureStartTime" /> property.</summary>
        private global::System.DateTime? _captureStartTime;

        /// <summary>The start time of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public global::System.DateTime? CaptureStartTime { get => this._captureStartTime; set => this._captureStartTime = value; }

        /// <summary>Backing field for <see cref="Id" /> property.</summary>
        private string _id;

        /// <summary>The ID of the packet capture resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Id { get => this._id; set => this._id = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the packet capture resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="PacketCaptureError" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError[] _packetCaptureError;

        /// <summary>List of errors of packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError[] PacketCaptureError { get => this._packetCaptureError; set => this._packetCaptureError = value; }

        /// <summary>Backing field for <see cref="PacketCaptureStatus" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus? _packetCaptureStatus;

        /// <summary>The status of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus? PacketCaptureStatus { get => this._packetCaptureStatus; set => this._packetCaptureStatus = value; }

        /// <summary>Backing field for <see cref="StopReason" /> property.</summary>
        private string _stopReason;

        /// <summary>The reason the current packet capture session was stopped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string StopReason { get => this._stopReason; set => this._stopReason = value; }

        /// <summary>Creates an new <see cref="PacketCaptureQueryStatusResult" /> instance.</summary>
        public PacketCaptureQueryStatusResult()
        {

        }
    }
    /// Status of packet capture session.
    public partial interface IPacketCaptureQueryStatusResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The start time of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The start time of the packet capture session.",
        SerializedName = @"captureStartTime",
        PossibleTypes = new [] { typeof(global::System.DateTime) })]
        global::System.DateTime? CaptureStartTime { get; set; }
        /// <summary>The ID of the packet capture resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the packet capture resource.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string Id { get; set; }
        /// <summary>The name of the packet capture resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the packet capture resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>List of errors of packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of errors of packet capture session.",
        SerializedName = @"packetCaptureError",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError[] PacketCaptureError { get; set; }
        /// <summary>The status of the packet capture session.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The status of the packet capture session.",
        SerializedName = @"packetCaptureStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus? PacketCaptureStatus { get; set; }
        /// <summary>The reason the current packet capture session was stopped.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reason the current packet capture session was stopped.",
        SerializedName = @"stopReason",
        PossibleTypes = new [] { typeof(string) })]
        string StopReason { get; set; }

    }
    /// Status of packet capture session.
    internal partial interface IPacketCaptureQueryStatusResultInternal

    {
        /// <summary>The start time of the packet capture session.</summary>
        global::System.DateTime? CaptureStartTime { get; set; }
        /// <summary>The ID of the packet capture resource.</summary>
        string Id { get; set; }
        /// <summary>The name of the packet capture resource.</summary>
        string Name { get; set; }
        /// <summary>List of errors of packet capture session.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcError[] PacketCaptureError { get; set; }
        /// <summary>The status of the packet capture session.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PcStatus? PacketCaptureStatus { get; set; }
        /// <summary>The reason the current packet capture session was stopped.</summary>
        string StopReason { get; set; }

    }
}