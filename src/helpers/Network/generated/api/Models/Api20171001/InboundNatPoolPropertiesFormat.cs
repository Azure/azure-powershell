namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of Inbound NAT pool.</summary>
    public partial class InboundNatPoolPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BackendPort" /> property.</summary>
        private int _backendPort;

        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int BackendPort { get => this._backendPort; set => this._backendPort = value; }

        /// <summary>Backing field for <see cref="FrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _frontendIPConfiguration;

        /// <summary>A reference to frontend IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource FrontendIPConfiguration { get => (this._frontendIPConfiguration = this._frontendIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._frontendIPConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string FrontendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)FrontendIPConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)FrontendIPConfiguration).Id = value; }

        /// <summary>Backing field for <see cref="FrontendPortRangeEnd" /> property.</summary>
        private int _frontendPortRangeEnd;

        /// <summary>
        /// The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a
        /// load balancer. Acceptable values range between 1 and 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int FrontendPortRangeEnd { get => this._frontendPortRangeEnd; set => this._frontendPortRangeEnd = value; }

        /// <summary>Backing field for <see cref="FrontendPortRangeStart" /> property.</summary>
        private int _frontendPortRangeStart;

        /// <summary>
        /// The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with
        /// a load balancer. Acceptable values range between 1 and 65534.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int FrontendPortRangeStart { get => this._frontendPortRangeStart; set => this._frontendPortRangeStart = value; }

        /// <summary>Internal Acessors for FrontendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatPoolPropertiesFormatInternal.FrontendIPConfiguration { get => (this._frontendIPConfiguration = this._frontendIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_frontendIPConfiguration = value;} } }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol _protocol;

        /// <summary>
        /// The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get => this._protocol; set => this._protocol = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Creates an new <see cref="InboundNatPoolPropertiesFormat" /> instance.</summary>
        public InboundNatPoolPropertiesFormat()
        {

        }
    }
    /// Properties of Inbound NAT pool.
    public partial interface IInboundNatPoolPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535.",
        SerializedName = @"backendPort",
        PossibleTypes = new [] { typeof(int) })]
        int BackendPort { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string FrontendIPConfigurationId { get; set; }
        /// <summary>
        /// The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a
        /// load balancer. Acceptable values range between 1 and 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65535.",
        SerializedName = @"frontendPortRangeEnd",
        PossibleTypes = new [] { typeof(int) })]
        int FrontendPortRangeEnd { get; set; }
        /// <summary>
        /// The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with
        /// a load balancer. Acceptable values range between 1 and 65534.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a load balancer. Acceptable values range between 1 and 65534.",
        SerializedName = @"frontendPortRangeStart",
        PossibleTypes = new [] { typeof(int) })]
        int FrontendPortRangeStart { get; set; }
        /// <summary>
        /// The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'",
        SerializedName = @"protocol",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }

    }
    /// Properties of Inbound NAT pool.
    internal partial interface IInboundNatPoolPropertiesFormatInternal

    {
        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535.
        /// </summary>
        int BackendPort { get; set; }
        /// <summary>A reference to frontend IP addresses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource FrontendIPConfiguration { get; set; }
        /// <summary>Resource ID.</summary>
        string FrontendIPConfigurationId { get; set; }
        /// <summary>
        /// The last port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with a
        /// load balancer. Acceptable values range between 1 and 65535.
        /// </summary>
        int FrontendPortRangeEnd { get; set; }
        /// <summary>
        /// The first port number in the range of external ports that will be used to provide Inbound Nat to NICs associated with
        /// a load balancer. Acceptable values range between 1 and 65534.
        /// </summary>
        int FrontendPortRangeStart { get; set; }
        /// <summary>
        /// The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All.'
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}