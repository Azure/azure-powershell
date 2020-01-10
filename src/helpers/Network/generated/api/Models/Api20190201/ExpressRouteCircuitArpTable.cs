namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>The ARP table associated with the ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCircuitArpTable :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitArpTable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteCircuitArpTableInternal
    {

        /// <summary>Backing field for <see cref="Age" /> property.</summary>
        private int? _age;

        /// <summary>Entry age in minutes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? Age { get => this._age; set => this._age = value; }

        /// <summary>Backing field for <see cref="IPAddress" /> property.</summary>
        private string _iPAddress;

        /// <summary>The IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string IPAddress { get => this._iPAddress; set => this._iPAddress = value; }

        /// <summary>Backing field for <see cref="Interface" /> property.</summary>
        private string _interface;

        /// <summary>Interface address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Interface { get => this._interface; set => this._interface = value; }

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
        /// <summary>Entry age in minutes</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Entry age in minutes",
        SerializedName = @"age",
        PossibleTypes = new [] { typeof(int) })]
        int? Age { get; set; }
        /// <summary>The IP address.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The IP address.",
        SerializedName = @"ipAddress",
        PossibleTypes = new [] { typeof(string) })]
        string IPAddress { get; set; }
        /// <summary>Interface address</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Interface address",
        SerializedName = @"interface",
        PossibleTypes = new [] { typeof(string) })]
        string Interface { get; set; }
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
        /// <summary>Entry age in minutes</summary>
        int? Age { get; set; }
        /// <summary>The IP address.</summary>
        string IPAddress { get; set; }
        /// <summary>Interface address</summary>
        string Interface { get; set; }
        /// <summary>The MAC address.</summary>
        string MacAddress { get; set; }

    }
}