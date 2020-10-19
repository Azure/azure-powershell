namespace Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Extensions;

    /// <summary>Defines NIC IP configuration properties.</summary>
    public partial class NicIPConfigurationResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettings,
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal
    {

        /// <summary>Backing field for <see cref="LoadBalancerBackendAddressPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference[] _loadBalancerBackendAddressPool;

        /// <summary>Gets or sets the references of the load balancer backend address pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference[] LoadBalancerBackendAddressPool { get => this._loadBalancerBackendAddressPool; set => this._loadBalancerBackendAddressPool = value; }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.INicIPConfigurationResourceSettingsInternal.Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.SubnetReference()); set { {_subnet = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>Gets or sets the IP configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Primary" /> property.</summary>
        private bool? _primary;

        /// <summary>Gets or sets a value indicating whether this IP configuration is the primary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public bool? Primary { get => this._primary; set => this._primary = value; }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>Gets or sets the private IP address of the network interface IP Configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; set => this._privateIPAddress = value; }

        /// <summary>Backing field for <see cref="PrivateIPAllocationMethod" /> property.</summary>
        private string _privateIPAllocationMethod;

        /// <summary>Gets or sets the private IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        public string PrivateIPAllocationMethod { get => this._privateIPAllocationMethod; set => this._privateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference _subnet;

        /// <summary>Defines reference to subnet.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.SubnetReference()); set => this._subnet = value; }

        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string SubnetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IProxyResourceReferenceInternal)Subnet).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IProxyResourceReferenceInternal)Subnet).Name = value; }

        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Origin(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.PropertyOrigin.Inlined)]
        public string SubnetSourceArmResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAzureResourceReferenceInternal)Subnet).SourceArmResourceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.IAzureResourceReferenceInternal)Subnet).SourceArmResourceId = value; }

        /// <summary>Creates an new <see cref="NicIPConfigurationResourceSettings" /> instance.</summary>
        public NicIPConfigurationResourceSettings()
        {

        }
    }
    /// Defines NIC IP configuration properties.
    public partial interface INicIPConfigurationResourceSettings :
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.IJsonSerializable
    {
        /// <summary>Gets or sets the references of the load balancer backend address pools.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the references of the load balancer backend address pools.",
        SerializedName = @"loadBalancerBackendAddressPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference) })]
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>Gets or sets the IP configuration name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the IP configuration name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>Gets or sets a value indicating whether this IP configuration is the primary.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets a value indicating whether this IP configuration is the primary.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Primary { get; set; }
        /// <summary>Gets or sets the private IP address of the network interface IP Configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the private IP address of the network interface IP Configuration.",
        SerializedName = @"privateIpAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>Gets or sets the private IP address allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets or sets the private IP address allocation method.",
        SerializedName = @"privateIpAllocationMethod",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAllocationMethod { get; set; }
        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets the name of the proxy resource on the target side.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetName { get; set; }
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.Info(
        Required = true,
        ReadOnly = false,
        Description = @"Gets the ARM resource ID of the tracked resource being referenced.",
        SerializedName = @"sourceArmResourceId",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetSourceArmResourceId { get; set; }

    }
    /// Defines NIC IP configuration properties.
    internal partial interface INicIPConfigurationResourceSettingsInternal

    {
        /// <summary>Gets or sets the references of the load balancer backend address pools.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ILoadBalancerBackendAddressPoolReference[] LoadBalancerBackendAddressPool { get; set; }
        /// <summary>Gets or sets the IP configuration name.</summary>
        string Name { get; set; }
        /// <summary>Gets or sets a value indicating whether this IP configuration is the primary.</summary>
        bool? Primary { get; set; }
        /// <summary>Gets or sets the private IP address of the network interface IP Configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>Gets or sets the private IP address allocation method.</summary>
        string PrivateIPAllocationMethod { get; set; }
        /// <summary>Defines reference to subnet.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api20191001Preview.ISubnetReference Subnet { get; set; }
        /// <summary>Gets the name of the proxy resource on the target side.</summary>
        string SubnetName { get; set; }
        /// <summary>Gets the ARM resource ID of the tracked resource being referenced.</summary>
        string SubnetSourceArmResourceId { get; set; }

    }
}