namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The arp table associated with the ExpressRouteCircuit</summary>
    public partial class ExpressRouteCircuitArpTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitArpTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20150501Preview.IExpressRouteCircuitArpTableInternal
    {

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>Gets ipAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>Gets macAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitArpTable" /> instance.</summary>
        public ExpressRouteCircuitArpTable()
        {

        }
    }
    /// The arp table associated with the ExpressRouteCircuit
    public partial interface IExpressRouteCircuitArpTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Gets ipAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets ipAddress.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>Gets macAddress.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets macAddress.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get; set; }

    }
    /// The arp table associated with the ExpressRouteCircuit
    internal partial interface IExpressRouteCircuitArpTableInternal

    {
        /// <summary>Gets ipAddress.</summary>
        string IPAddress { get; set; }
        /// <summary>Gets macAddress.</summary>
        string MacAddress { get; set; }

    }
}