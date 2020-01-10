namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of Inbound NAT pool.</summary>
    public partial class InboundNatPoolPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPoolPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPoolPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="BackendPort" /> property.</summary>
        private int _backendPort;

        /// <summary>
        /// The port used for internal connections on the endpoint. Acceptable values are between 1 and 65535.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int BackendPort { get => this._backendPort; set => this._backendPort = value; }

        /// <summary>Backing field for <see cref="EnableFloatingIP" /> property.</summary>
        private bool? _enableFloatingIP;

        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableFloatingIP { get => this._enableFloatingIP; set => this._enableFloatingIP = value; }

        /// <summary>Backing field for <see cref="EnableTcpReset" /> property.</summary>
        private bool? _enableTcpReset;

        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableTcpReset { get => this._enableTcpReset; set => this._enableTcpReset = value; }

        /// <summary>Backing field for <see cref="FrontendIPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _frontendIPConfiguration;

        /// <summary>A reference to frontend IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource FrontendIPConfiguration { get => (this._frontendIPConfiguration = this._frontendIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._frontendIPConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string FrontendIPConfigurationId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)FrontendIPConfiguration).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)FrontendIPConfiguration).Id = value; }

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

        /// <summary>Backing field for <see cref="IdleTimeoutInMinutes" /> property.</summary>
        private int? _idleTimeoutInMinutes;

        /// <summary>
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public int? IdleTimeoutInMinutes { get => this._idleTimeoutInMinutes; set => this._idleTimeoutInMinutes = value; }

        /// <summary>Internal Acessors for FrontendIPConfiguration</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatPoolPropertiesFormatInternal.FrontendIPConfiguration { get => (this._frontendIPConfiguration = this._frontendIPConfiguration ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_frontendIPConfiguration = value;} } }

        /// <summary>Backing field for <see cref="Protocol" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol _protocol;

        /// <summary>The reference to the transport protocol used by the inbound NAT pool.</summary>
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
        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.",
        SerializedName = @"enableFloatingIP",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableFloatingIP { get; set; }
        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.",
        SerializedName = @"enableTcpReset",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableTcpReset { get; set; }
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
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.",
        SerializedName = @"idleTimeoutInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The reference to the transport protocol used by the inbound NAT pool.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"The reference to the transport protocol used by the inbound NAT pool.",
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
        /// <summary>
        /// Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability
        /// Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed
        /// after you create the endpoint.
        /// </summary>
        bool? EnableFloatingIP { get; set; }
        /// <summary>
        /// Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used
        /// when the protocol is set to TCP.
        /// </summary>
        bool? EnableTcpReset { get; set; }
        /// <summary>A reference to frontend IP addresses.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource FrontendIPConfiguration { get; set; }
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
        /// The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes.
        /// This element is only used when the protocol is set to TCP.
        /// </summary>
        int? IdleTimeoutInMinutes { get; set; }
        /// <summary>The reference to the transport protocol used by the inbound NAT pool.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol Protocol { get; set; }
        /// <summary>
        /// Gets the provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }

    }
}