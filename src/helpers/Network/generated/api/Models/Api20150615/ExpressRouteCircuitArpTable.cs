namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The ARP table associated with the ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCircuitArpTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150615.IExpressRouteCircuitArpTableInternal
    {

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>The MAC address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitArpTable" /> instance.</summary>
        public ExpressRouteCircuitArpTable()
        {

        }
    }
    /// The ARP table associated with the ExpressRouteCircuit.
    public partial interface IExpressRouteCircuitArpTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>The MAC address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The MAC address.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get; set; }

    }
    /// The ARP table associated with the ExpressRouteCircuit.
    internal partial interface IExpressRouteCircuitArpTableInternal

    {
        /// <summary>The IP address.</summary>
        string IPAddress { get; set; }
        /// <summary>The MAC address.</summary>
        string MacAddress { get; set; }

    }
}