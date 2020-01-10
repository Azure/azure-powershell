namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Contains Stats associated with the peering</summary>
    public partial class ExpressRouteCircuitStats :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStats,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitStatsInternal
    {

        /// <summary>Backing field for <see cref="BytesIn" /> property.</summary>
        private int? _bytesIn;

        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? BytesIn { get => this._bytesIn; set => this._bytesIn = value; }

        /// <summary>Backing field for <see cref="BytesOut" /> property.</summary>
        private int? _bytesOut;

        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? BytesOut { get => this._bytesOut; set => this._bytesOut = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitStats" /> instance.</summary>
        public ExpressRouteCircuitStats()
        {

        }
    }
    /// Contains Stats associated with the peering
    public partial interface IExpressRouteCircuitStats :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets BytesIn of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesIn of the peering.",
        SerializedName = @"bytesIn",
        PossibleTypes = new [] { typeof(int) })]
        int? BytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets BytesOut of the peering.",
        SerializedName = @"bytesOut",
        PossibleTypes = new [] { typeof(int) })]
        int? BytesOut { get; set; }

    }
    /// Contains Stats associated with the peering
    internal partial interface IExpressRouteCircuitStatsInternal

    {
        /// <summary>Gets BytesIn of the peering.</summary>
        int? BytesIn { get; set; }
        /// <summary>Gets BytesOut of the peering.</summary>
        int? BytesOut { get; set; }

    }
}