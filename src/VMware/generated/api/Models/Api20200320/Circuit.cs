namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320
{
    using static Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Extensions;

    /// <summary>An ExpressRoute Circuit</summary>
    public partial class Circuit :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuit,
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal
    {

        /// <summary>Backing field for <see cref="ExpressRouteId" /> property.</summary>
        private string _expressRouteId;

        /// <summary>Identifier of the ExpressRoute Circuit (Microsoft Colo only)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ExpressRouteId { get => this._expressRouteId; }

        /// <summary>Backing field for <see cref="ExpressRoutePrivatePeeringId" /> property.</summary>
        private string _expressRoutePrivatePeeringId;

        /// <summary>ExpressRoute Circuit private peering identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string ExpressRoutePrivatePeeringId { get => this._expressRoutePrivatePeeringId; }

        /// <summary>Internal Acessors for ExpressRouteId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal.ExpressRouteId { get => this._expressRouteId; set { {_expressRouteId = value;} } }

        /// <summary>Internal Acessors for ExpressRoutePrivatePeeringId</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal.ExpressRoutePrivatePeeringId { get => this._expressRoutePrivatePeeringId; set { {_expressRoutePrivatePeeringId = value;} } }

        /// <summary>Internal Acessors for PrimarySubnet</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal.PrimarySubnet { get => this._primarySubnet; set { {_primarySubnet = value;} } }

        /// <summary>Internal Acessors for SecondarySubnet</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Api20200320.ICircuitInternal.SecondarySubnet { get => this._secondarySubnet; set { {_secondarySubnet = value;} } }

        /// <summary>Backing field for <see cref="PrimarySubnet" /> property.</summary>
        private string _primarySubnet;

        /// <summary>CIDR of primary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string PrimarySubnet { get => this._primarySubnet; }

        /// <summary>Backing field for <see cref="SecondarySubnet" /> property.</summary>
        private string _secondarySubnet;

        /// <summary>CIDR of secondary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Origin(Microsoft.Azure.PowerShell.Cmdlets.VMware.PropertyOrigin.Owned)]
        public string SecondarySubnet { get => this._secondarySubnet; }

        /// <summary>Creates an new <see cref="Circuit" /> instance.</summary>
        public Circuit()
        {

        }
    }
    /// An ExpressRoute Circuit
    public partial interface ICircuit :
        Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.IJsonSerializable
    {
        /// <summary>Identifier of the ExpressRoute Circuit (Microsoft Colo only)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Identifier of the ExpressRoute Circuit (Microsoft Colo only)",
        SerializedName = @"expressRouteID",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRouteId { get;  }
        /// <summary>ExpressRoute Circuit private peering identifier</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"ExpressRoute Circuit private peering identifier",
        SerializedName = @"expressRoutePrivatePeeringID",
        PossibleTypes = new [] { typeof(string) })]
        string ExpressRoutePrivatePeeringId { get;  }
        /// <summary>CIDR of primary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"CIDR of primary subnet",
        SerializedName = @"primarySubnet",
        PossibleTypes = new [] { typeof(string) })]
        string PrimarySubnet { get;  }
        /// <summary>CIDR of secondary subnet</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"CIDR of secondary subnet",
        SerializedName = @"secondarySubnet",
        PossibleTypes = new [] { typeof(string) })]
        string SecondarySubnet { get;  }

    }
    /// An ExpressRoute Circuit
    internal partial interface ICircuitInternal

    {
        /// <summary>Identifier of the ExpressRoute Circuit (Microsoft Colo only)</summary>
        string ExpressRouteId { get; set; }
        /// <summary>ExpressRoute Circuit private peering identifier</summary>
        string ExpressRoutePrivatePeeringId { get; set; }
        /// <summary>CIDR of primary subnet</summary>
        string PrimarySubnet { get; set; }
        /// <summary>CIDR of secondary subnet</summary>
        string SecondarySubnet { get; set; }

    }
}