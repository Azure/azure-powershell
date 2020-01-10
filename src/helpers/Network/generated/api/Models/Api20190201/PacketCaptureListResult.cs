namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>List of packet capture sessions.</summary>
    public partial class PacketCaptureListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureListResult,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureListResultInternal
    {

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResult[] _value;

        /// <summary>Information about packet capture sessions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResult[] Value { get => this._value; set => this._value = value; }

        /// <summary>Creates an new <see cref="PacketCaptureListResult" /> instance.</summary>
        public PacketCaptureListResult()
        {

        }
    }
    /// List of packet capture sessions.
    public partial interface IPacketCaptureListResult :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Information about packet capture sessions.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Information about packet capture sessions.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResult) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResult[] Value { get; set; }

    }
    /// List of packet capture sessions.
    internal partial interface IPacketCaptureListResultInternal

    {
        /// <summary>Information about packet capture sessions.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPacketCaptureResult[] Value { get; set; }

    }
}