namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties specific to ExpressRoutePort resources.</summary>
    public partial class ExpressRoutePortPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AllocationDate" /> property.</summary>
        private string _allocationDate;

        /// <summary>Date of the physical port allocation to be used in Letter of Authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string AllocationDate { get => this._allocationDate; }

        /// <summary>Backing field for <see cref="BandwidthInGbps" /> property.</summary>
        private int? _bandwidthInGbps;

        /// <summary>Bandwidth of procured ports in Gbps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? BandwidthInGbps { get => this._bandwidthInGbps; set => this._bandwidthInGbps = value; }

        /// <summary>Backing field for <see cref="Circuit" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _circuit;

        /// <summary>
        /// Reference the ExpressRoute circuit(s) that are provisioned on this ExpressRoutePort resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Circuit { get => this._circuit; }

        /// <summary>Backing field for <see cref="Encapsulation" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation? _encapsulation;

        /// <summary>Encapsulation method on physical ports.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation? Encapsulation { get => this._encapsulation; set => this._encapsulation = value; }

        /// <summary>Backing field for <see cref="EtherType" /> property.</summary>
        private string _etherType;

        /// <summary>Ether type of the physical port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string EtherType { get => this._etherType; }

        /// <summary>Backing field for <see cref="Link" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink[] _link;

        /// <summary>The set of physical links of the ExpressRoutePort resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink[] Link { get => this._link; set => this._link = value; }

        /// <summary>Internal Acessors for AllocationDate</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal.AllocationDate { get => this._allocationDate; set { {_allocationDate = value;} } }

        /// <summary>Internal Acessors for Circuit</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal.Circuit { get => this._circuit; set { {_circuit = value;} } }

        /// <summary>Internal Acessors for EtherType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal.EtherType { get => this._etherType; set { {_etherType = value;} } }

        /// <summary>Internal Acessors for Mtu</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal.Mtu { get => this._mtu; set { {_mtu = value;} } }

        /// <summary>Internal Acessors for ProvisionedBandwidthInGbps</summary>
        float? Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal.ProvisionedBandwidthInGbps { get => this._provisionedBandwidthInGbps; set { {_provisionedBandwidthInGbps = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRoutePortPropertiesFormatInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="Mtu" /> property.</summary>
        private string _mtu;

        /// <summary>Maximum transmission unit of the physical port pair(s)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Mtu { get => this._mtu; }

        /// <summary>Backing field for <see cref="PeeringLocation" /> property.</summary>
        private string _peeringLocation;

        /// <summary>
        /// The name of the peering location that the ExpressRoutePort is mapped to physically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PeeringLocation { get => this._peeringLocation; set => this._peeringLocation = value; }

        /// <summary>Backing field for <see cref="ProvisionedBandwidthInGbps" /> property.</summary>
        private float? _provisionedBandwidthInGbps;

        /// <summary>Aggregate Gbps of associated circuit bandwidths.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public float? ProvisionedBandwidthInGbps { get => this._provisionedBandwidthInGbps; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the ExpressRoutePort resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resource GUID property of the ExpressRoutePort resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>Creates an new <see cref="ExpressRoutePortPropertiesFormat" /> instance.</summary>
        public ExpressRoutePortPropertiesFormat()
        {

        }
    }
    /// Properties specific to ExpressRoutePort resources.
    public partial interface IExpressRoutePortPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Date of the physical port allocation to be used in Letter of Authorization.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Date of the physical port allocation to be used in Letter of Authorization.",
        SerializedName = @"allocationDate",
        PossibleTypes = new [] { typeof(string) })]
        string AllocationDate { get;  }
        /// <summary>Bandwidth of procured ports in Gbps</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Bandwidth of procured ports in Gbps",
        SerializedName = @"bandwidthInGbps",
        PossibleTypes = new [] { typeof(int) })]
        int? BandwidthInGbps { get; set; }
        /// <summary>
        /// Reference the ExpressRoute circuit(s) that are provisioned on this ExpressRoutePort resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Reference the ExpressRoute circuit(s) that are provisioned on this ExpressRoutePort resource.",
        SerializedName = @"circuits",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Circuit { get;  }
        /// <summary>Encapsulation method on physical ports.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Encapsulation method on physical ports.",
        SerializedName = @"encapsulation",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation? Encapsulation { get; set; }
        /// <summary>Ether type of the physical port.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Ether type of the physical port.",
        SerializedName = @"etherType",
        PossibleTypes = new [] { typeof(string) })]
        string EtherType { get;  }
        /// <summary>The set of physical links of the ExpressRoutePort resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The set of physical links of the ExpressRoutePort resource",
        SerializedName = @"links",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink[] Link { get; set; }
        /// <summary>Maximum transmission unit of the physical port pair(s)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Maximum transmission unit of the physical port pair(s)",
        SerializedName = @"mtu",
        PossibleTypes = new [] { typeof(string) })]
        string Mtu { get;  }
        /// <summary>
        /// The name of the peering location that the ExpressRoutePort is mapped to physically.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the peering location that the ExpressRoutePort is mapped to physically.",
        SerializedName = @"peeringLocation",
        PossibleTypes = new [] { typeof(string) })]
        string PeeringLocation { get; set; }
        /// <summary>Aggregate Gbps of associated circuit bandwidths.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Aggregate Gbps of associated circuit bandwidths.",
        SerializedName = @"provisionedBandwidthInGbps",
        PossibleTypes = new [] { typeof(float) })]
        float? ProvisionedBandwidthInGbps { get;  }
        /// <summary>
        /// The provisioning state of the ExpressRoutePort resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the ExpressRoutePort resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The resource GUID property of the ExpressRoutePort resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the ExpressRoutePort resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }

    }
    /// Properties specific to ExpressRoutePort resources.
    internal partial interface IExpressRoutePortPropertiesFormatInternal

    {
        /// <summary>Date of the physical port allocation to be used in Letter of Authorization.</summary>
        string AllocationDate { get; set; }
        /// <summary>Bandwidth of procured ports in Gbps</summary>
        int? BandwidthInGbps { get; set; }
        /// <summary>
        /// Reference the ExpressRoute circuit(s) that are provisioned on this ExpressRoutePort resource.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Circuit { get; set; }
        /// <summary>Encapsulation method on physical ports.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ExpressRoutePortsEncapsulation? Encapsulation { get; set; }
        /// <summary>Ether type of the physical port.</summary>
        string EtherType { get; set; }
        /// <summary>The set of physical links of the ExpressRoutePort resource</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IExpressRouteLink[] Link { get; set; }
        /// <summary>Maximum transmission unit of the physical port pair(s)</summary>
        string Mtu { get; set; }
        /// <summary>
        /// The name of the peering location that the ExpressRoutePort is mapped to physically.
        /// </summary>
        string PeeringLocation { get; set; }
        /// <summary>Aggregate Gbps of associated circuit bandwidths.</summary>
        float? ProvisionedBandwidthInGbps { get; set; }
        /// <summary>
        /// The provisioning state of the ExpressRoutePort resource. Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the ExpressRoutePort resource.</summary>
        string ResourceGuid { get; set; }

    }
}