namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of ExpressRouteCircuit.</summary>
    public partial class ExpressRouteCircuitPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="AllowClassicOperation" /> property.</summary>
        private bool? _allowClassicOperation;

        /// <summary>Allow classic operations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? AllowClassicOperation { get => this._allowClassicOperation; set => this._allowClassicOperation = value; }

        /// <summary>Backing field for <see cref="Authorization" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] _authorization;

        /// <summary>The list of authorizations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] Authorization { get => this._authorization; set => this._authorization = value; }

        /// <summary>Backing field for <see cref="CircuitProvisioningState" /> property.</summary>
        private string _circuitProvisioningState;

        /// <summary>The CircuitProvisioningState state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string CircuitProvisioningState { get => this._circuitProvisioningState; set => this._circuitProvisioningState = value; }

        /// <summary>Backing field for <see cref="GatewayManagerEtag" /> property.</summary>
        private string _gatewayManagerEtag;

        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string GatewayManagerEtag { get => this._gatewayManagerEtag; set => this._gatewayManagerEtag = value; }

        /// <summary>Internal Acessors for ServiceProviderProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPropertiesFormatInternal.ServiceProviderProperty { get => (this._serviceProviderProperty = this._serviceProviderProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitServiceProviderProperties()); set { {_serviceProviderProperty = value;} } }

        /// <summary>Backing field for <see cref="Peering" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] _peering;

        /// <summary>The list of peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Peering { get => this._peering; set => this._peering = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="ServiceKey" /> property.</summary>
        private string _serviceKey;

        /// <summary>The ServiceKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceKey { get => this._serviceKey; set => this._serviceKey = value; }

        /// <summary>Backing field for <see cref="ServiceProviderNote" /> property.</summary>
        private string _serviceProviderNote;

        /// <summary>The ServiceProviderNotes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ServiceProviderNote { get => this._serviceProviderNote; set => this._serviceProviderNote = value; }

        /// <summary>Backing field for <see cref="ServiceProviderProperty" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderProperties _serviceProviderProperty;

        /// <summary>The ServiceProviderProperties.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderProperties ServiceProviderProperty { get => (this._serviceProviderProperty = this._serviceProviderProperty ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ExpressRouteCircuitServiceProviderProperties()); set => this._serviceProviderProperty = value; }

        /// <summary>The BandwidthInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public int? ServiceProviderPropertyBandwidthInMbps { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderPropertiesInternal)ServiceProviderProperty).BandwidthInMbps; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderPropertiesInternal)ServiceProviderProperty).BandwidthInMbps = value; }

        /// <summary>The peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ServiceProviderPropertyPeeringLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderPropertiesInternal)ServiceProviderProperty).PeeringLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderPropertiesInternal)ServiceProviderProperty).PeeringLocation = value; }

        /// <summary>The serviceProviderName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ServiceProviderPropertyServiceProviderName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderPropertiesInternal)ServiceProviderProperty).ServiceProviderName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderPropertiesInternal)ServiceProviderProperty).ServiceProviderName = value; }

        /// <summary>Backing field for <see cref="ServiceProviderProvisioningState" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? _serviceProviderProvisioningState;

        /// <summary>
        /// The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned',
        /// and 'Deprovisioning'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get => this._serviceProviderProvisioningState; set => this._serviceProviderProvisioningState = value; }

        /// <summary>Creates an new <see cref="ExpressRouteCircuitPropertiesFormat" /> instance.</summary>
        public ExpressRouteCircuitPropertiesFormat()
        {

        }
    }
    /// Properties of ExpressRouteCircuit.
    public partial interface IExpressRouteCircuitPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Allow classic operations</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Allow classic operations",
        SerializedName = @"allowClassicOperations",
        PossibleTypes = new [] { typeof(bool) })]
        bool? AllowClassicOperation { get; set; }
        /// <summary>The list of authorizations.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of authorizations.",
        SerializedName = @"authorizations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] Authorization { get; set; }
        /// <summary>The CircuitProvisioningState state of the resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The CircuitProvisioningState state of the resource.",
        SerializedName = @"circuitProvisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string CircuitProvisioningState { get; set; }
        /// <summary>The GatewayManager Etag.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The GatewayManager Etag.",
        SerializedName = @"gatewayManagerEtag",
        PossibleTypes = new [] { typeof(string) })]
        string GatewayManagerEtag { get; set; }
        /// <summary>The list of peerings.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of peerings.",
        SerializedName = @"peerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The ServiceKey.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ServiceKey.",
        SerializedName = @"serviceKey",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceKey { get; set; }
        /// <summary>The ServiceProviderNotes.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ServiceProviderNotes.",
        SerializedName = @"serviceProviderNotes",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderNote { get; set; }
        /// <summary>The BandwidthInMbps.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The BandwidthInMbps.",
        SerializedName = @"bandwidthInMbps",
        PossibleTypes = new [] { typeof(int) })]
        int? ServiceProviderPropertyBandwidthInMbps { get; set; }
        /// <summary>The peering location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The peering location.",
        SerializedName = @"peeringLocation",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderPropertyPeeringLocation { get; set; }
        /// <summary>The serviceProviderName.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The serviceProviderName.",
        SerializedName = @"serviceProviderName",
        PossibleTypes = new [] { typeof(string) })]
        string ServiceProviderPropertyServiceProviderName { get; set; }
        /// <summary>
        /// The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned',
        /// and 'Deprovisioning'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned', and 'Deprovisioning'.",
        SerializedName = @"serviceProviderProvisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get; set; }

    }
    /// Properties of ExpressRouteCircuit.
    internal partial interface IExpressRouteCircuitPropertiesFormatInternal

    {
        /// <summary>Allow classic operations</summary>
        bool? AllowClassicOperation { get; set; }
        /// <summary>The list of authorizations.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitAuthorization[] Authorization { get; set; }
        /// <summary>The CircuitProvisioningState state of the resource.</summary>
        string CircuitProvisioningState { get; set; }
        /// <summary>The GatewayManager Etag.</summary>
        string GatewayManagerEtag { get; set; }
        /// <summary>The list of peerings.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitPeering[] Peering { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The ServiceKey.</summary>
        string ServiceKey { get; set; }
        /// <summary>The ServiceProviderNotes.</summary>
        string ServiceProviderNote { get; set; }
        /// <summary>The ServiceProviderProperties.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IExpressRouteCircuitServiceProviderProperties ServiceProviderProperty { get; set; }
        /// <summary>The BandwidthInMbps.</summary>
        int? ServiceProviderPropertyBandwidthInMbps { get; set; }
        /// <summary>The peering location.</summary>
        string ServiceProviderPropertyPeeringLocation { get; set; }
        /// <summary>The serviceProviderName.</summary>
        string ServiceProviderPropertyServiceProviderName { get; set; }
        /// <summary>
        /// The ServiceProviderProvisioningState state of the resource. Possible values are 'NotProvisioned', 'Provisioning', 'Provisioned',
        /// and 'Deprovisioning'.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.ServiceProviderProvisioningState? ServiceProviderProvisioningState { get; set; }

    }
}