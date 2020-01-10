namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains stats associated with the peering.</summary>
    public partial class ExpressRouteCircuitStats :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitStats,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitStatsInternal
    {

        /// <summary>Backing field for <see cref="PrimarybytesIn" /> property.</summary>
        private long? _primarybytesIn;

        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? PrimarybytesIn { get => this._primarybytesIn; set => this._primarybytesIn = value; }

        /// <summary>Backing field for <see cref="PrimarybytesOut" /> property.</summary>
        private long? _primarybytesOut;

        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? PrimarybytesOut { get => this._primarybytesOut; set => this._primarybytesOut = value; }

        /// <summary>Backing field for <see cref="SecondarybytesIn" /> property.</summary>
        private long? _secondarybytesIn;

        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? SecondarybytesIn { get => this._secondarybytesIn; set => this._secondarybytesIn = value; }

        /// <summary>Backing field for <see cref="SecondarybytesOut" /> property.</summary>
        private long? _secondarybytesOut;

        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public long? SecondarybytesOut { get => this._secondarybytesOut; set => this._secondarybytesOut = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitStats" /> instance.</summary>
        public ExpressRouteCircuitStats()
        {

        }
    }
    /// Contains stats associated with the peering.
    public partial interface IExpressRouteCircuitStats :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesIn of the peering.",
        SerializedName = @"primarybytesIn",
        PossibleTypes = new [] { typeof(long) })]
        long? PrimarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesOut of the peering.",
        SerializedName = @"primarybytesOut",
        PossibleTypes = new [] { typeof(long) })]
        long? PrimarybytesOut { get; set; }
        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesIn of the peering.",
        SerializedName = @"secondarybytesIn",
        PossibleTypes = new [] { typeof(long) })]
        long? SecondarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesOut of the peering.",
        SerializedName = @"secondarybytesOut",
        PossibleTypes = new [] { typeof(long) })]
        long? SecondarybytesOut { get; set; }

    }
    /// Contains stats associated with the peering.
    internal partial interface IExpressRouteCircuitStatsInternal

    {
        /// <summary>Gets BytesIn of the peering.</summary>
        long? PrimarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        long? PrimarybytesOut { get; set; }
        /// <summary>Gets BytesIn of the peering.</summary>
        long? SecondarybytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        long? SecondarybytesOut { get; set; }

    }
}