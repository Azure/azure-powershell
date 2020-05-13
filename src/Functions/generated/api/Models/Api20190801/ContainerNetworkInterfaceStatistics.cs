namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    public partial class ContainerNetworkInterfaceStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatistics,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IContainerNetworkInterfaceStatisticsInternal
    {

        /// <summary>Backing field for <see cref="RxByte" /> property.</summary>
        private long? _rxByte;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? RxByte { get => this._rxByte; set => this._rxByte = value; }

        /// <summary>Backing field for <see cref="RxDropped" /> property.</summary>
        private long? _rxDropped;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? RxDropped { get => this._rxDropped; set => this._rxDropped = value; }

        /// <summary>Backing field for <see cref="RxError" /> property.</summary>
        private long? _rxError;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? RxError { get => this._rxError; set => this._rxError = value; }

        /// <summary>Backing field for <see cref="RxPacket" /> property.</summary>
        private long? _rxPacket;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? RxPacket { get => this._rxPacket; set => this._rxPacket = value; }

        /// <summary>Backing field for <see cref="TxByte" /> property.</summary>
        private long? _txByte;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? TxByte { get => this._txByte; set => this._txByte = value; }

        /// <summary>Backing field for <see cref="TxDropped" /> property.</summary>
        private long? _txDropped;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? TxDropped { get => this._txDropped; set => this._txDropped = value; }

        /// <summary>Backing field for <see cref="TxError" /> property.</summary>
        private long? _txError;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? TxError { get => this._txError; set => this._txError = value; }

        /// <summary>Backing field for <see cref="TxPacket" /> property.</summary>
        private long? _txPacket;

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public long? TxPacket { get => this._txPacket; set => this._txPacket = value; }

        /// <summary>Creates an new <see cref="ContainerNetworkInterfaceStatistics" /> instance.</summary>
        public ContainerNetworkInterfaceStatistics()
        {

        }
    }
    public partial interface IContainerNetworkInterfaceStatistics :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? RxByte { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxDropped",
        PossibleTypes = new [] { typeof(long) })]
        long? RxDropped { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxErrors",
        PossibleTypes = new [] { typeof(long) })]
        long? RxError { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"rxPackets",
        PossibleTypes = new [] { typeof(long) })]
        long? RxPacket { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txBytes",
        PossibleTypes = new [] { typeof(long) })]
        long? TxByte { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txDropped",
        PossibleTypes = new [] { typeof(long) })]
        long? TxDropped { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txErrors",
        PossibleTypes = new [] { typeof(long) })]
        long? TxError { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"txPackets",
        PossibleTypes = new [] { typeof(long) })]
        long? TxPacket { get; set; }

    }
    internal partial interface IContainerNetworkInterfaceStatisticsInternal

    {
        long? RxByte { get; set; }

        long? RxDropped { get; set; }

        long? RxError { get; set; }

        long? RxPacket { get; set; }

        long? TxByte { get; set; }

        long? TxDropped { get; set; }

        long? TxError { get; set; }

        long? TxPacket { get; set; }

    }
}