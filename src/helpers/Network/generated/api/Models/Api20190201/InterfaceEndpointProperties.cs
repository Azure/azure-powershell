namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of the interface endpoint.</summary>
    public partial class InterfaceEndpointProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal
    {

        /// <summary>Backing field for <see cref="EndpointService" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService _endpointService;

        /// <summary>A reference to the service being brought into the virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService EndpointService { get => (this._endpointService = this._endpointService ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EndpointService()); set => this._endpointService = value; }

        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string EndpointServiceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceInternal)EndpointService).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointServiceInternal)EndpointService).Id = value; }

        /// <summary>Backing field for <see cref="Fqdn" /> property.</summary>
        private string _fqdn;

        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Fqdn { get => this._fqdn; set => this._fqdn = value; }

        /// <summary>Internal Acessors for EndpointService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal.EndpointService { get => (this._endpointService = this._endpointService ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.EndpointService()); set { {_endpointService = value;} } }

        /// <summary>Internal Acessors for NetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal.NetworkInterface { get => this._networkInterface; set { {_networkInterface = value;} } }

        /// <summary>Internal Acessors for Owner</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal.Owner { get => this._owner; set { {_owner = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointPropertiesInternal.ProvisioningState { get => this._provisioningState; set { {_provisioningState = value;} } }

        /// <summary>Backing field for <see cref="NetworkInterface" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] _networkInterface;

        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get => this._networkInterface; }

        /// <summary>Backing field for <see cref="Owner" /> property.</summary>
        private string _owner;

        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Owner { get => this._owner; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet _subnet;

        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Subnet()); set => this._subnet = value; }

        /// <summary>Creates an new <see cref="InterfaceEndpointProperties" /> instance.</summary>
        public InterfaceEndpointProperties()
        {

        }
    }
    /// Properties of the interface endpoint.
    public partial interface IInterfaceEndpointProperties :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique identifier of the service being referenced by the interface endpoint.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string EndpointServiceId { get; set; }
        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.",
        SerializedName = @"fqdn",
        PossibleTypes = new [] { typeof(string) })]
        string Fqdn { get; set; }
        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets an array of references to the network interfaces created for this interface endpoint.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get;  }
        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A read-only property that identifies who created this interface endpoint.",
        SerializedName = @"owner",
        PossibleTypes = new [] { typeof(string) })]
        string Owner { get;  }
        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the subnet from which the private IP will be allocated.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }

    }
    /// Properties of the interface endpoint.
    internal partial interface IInterfaceEndpointPropertiesInternal

    {
        /// <summary>A reference to the service being brought into the virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService EndpointService { get; set; }
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        string EndpointServiceId { get; set; }
        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        string Fqdn { get; set; }
        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NetworkInterface { get; set; }
        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        string Owner { get; set; }
        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }

    }
}