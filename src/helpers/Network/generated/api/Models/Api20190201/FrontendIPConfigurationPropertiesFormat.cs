namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Properties of Frontend IP Configuration of the load balancer.</summary>
    public partial class FrontendIPConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormatInternal
    {

        /// <summary>Backing field for <see cref="InboundNatPool" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _inboundNatPool;

        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatPool { get => this._inboundNatPool; }

        /// <summary>Backing field for <see cref="InboundNatRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _inboundNatRule;

        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatRule { get => this._inboundNatRule; }

        /// <summary>Backing field for <see cref="LoadBalancingRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _loadBalancingRule;

        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get => this._loadBalancingRule; }

        /// <summary>Internal Acessors for InboundNatPool</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormatInternal.InboundNatPool { get => this._inboundNatPool; set { {_inboundNatPool = value;} } }

        /// <summary>Internal Acessors for InboundNatRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormatInternal.InboundNatRule { get => this._inboundNatRule; set { {_inboundNatRule = value;} } }

        /// <summary>Internal Acessors for LoadBalancingRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormatInternal.LoadBalancingRule { get => this._loadBalancingRule; set { {_loadBalancingRule = value;} } }

        /// <summary>Internal Acessors for OutboundRule</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormatInternal.OutboundRule { get => this._outboundRule; set { {_outboundRule = value;} } }

        /// <summary>Internal Acessors for PublicIPPrefix</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IFrontendIPConfigurationPropertiesFormatInternal.PublicIPPrefix { get => (this._publicIPPrefix = this._publicIPPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_publicIPPrefix = value;} } }

        /// <summary>Backing field for <see cref="OutboundRule" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] _outboundRule;

        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] OutboundRule { get => this._outboundRule; }

        /// <summary>Backing field for <see cref="PrivateIPAddress" /> property.</summary>
        private string _privateIPAddress;

        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string PrivateIPAddress { get => this._privateIPAddress; set => this._privateIPAddress = value; }

        /// <summary>Backing field for <see cref="PrivateIPAllocationMethod" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? _privateIPAllocationMethod;

        /// <summary>The Private IP allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get => this._privateIPAllocationMethod; set => this._privateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="PublicIPAddress" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress _publicIPAddress;

        /// <summary>The reference of the Public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get => (this._publicIPAddress = this._publicIPAddress ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.PublicIPAddress()); set => this._publicIPAddress = value; }

        /// <summary>Backing field for <see cref="PublicIPPrefix" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _publicIPPrefix;

        /// <summary>The reference of the Public IP Prefix resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource PublicIPPrefix { get => (this._publicIPPrefix = this._publicIPPrefix ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set => this._publicIPPrefix = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPPrefixId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)PublicIPPrefix).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)PublicIPPrefix).Id = value; }

        /// <summary>Backing field for <see cref="Subnet" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet _subnet;

        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get => (this._subnet = this._subnet ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Subnet()); set => this._subnet = value; }

        /// <summary>Creates an new <see cref="FrontendIPConfigurationPropertiesFormat" /> instance.</summary>
        public FrontendIPConfigurationPropertiesFormat()
        {

        }
    }
    /// Properties of Frontend IP Configuration of the load balancer.
    public partial interface IFrontendIPConfigurationPropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Inbound pools URIs that use this frontend IP.",
        SerializedName = @"inboundNatPools",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatPool { get;  }
        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Inbound rules URIs that use this frontend IP.",
        SerializedName = @"inboundNatRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatRule { get;  }
        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets load balancing rules URIs that use this frontend IP.",
        SerializedName = @"loadBalancingRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get;  }
        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Read only. Outbound rules URIs that use this frontend IP.",
        SerializedName = @"outboundRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] OutboundRule { get;  }
        /// <summary>The private IP address of the IP configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP address of the IP configuration.",
        SerializedName = @"privateIPAddress",
        PossibleTypes = new [] { typeof(string) })]
        string PrivateIPAddress { get; set; }
        /// <summary>The Private IP allocation method.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Private IP allocation method.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
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
        /// <summary>The reference of the Public IP resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of the Public IP resource.",
        SerializedName = @"publicIPAddress",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPPrefixId { get; set; }
        /// <summary>The reference of the subnet resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The reference of the subnet resource.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }

    }
    /// Properties of Frontend IP Configuration of the load balancer.
    internal partial interface IFrontendIPConfigurationPropertiesFormatInternal

    {
        /// <summary>Read only. Inbound pools URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatPool { get; set; }
        /// <summary>Read only. Inbound rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] InboundNatRule { get; set; }
        /// <summary>Gets load balancing rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] LoadBalancingRule { get; set; }
        /// <summary>Read only. Outbound rules URIs that use this frontend IP.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource[] OutboundRule { get; set; }
        /// <summary>The private IP address of the IP configuration.</summary>
        string PrivateIPAddress { get; set; }
        /// <summary>The Private IP allocation method.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>
        /// Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the Public IP resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress PublicIPAddress { get; set; }
        /// <summary>The reference of the Public IP Prefix resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource PublicIPPrefix { get; set; }
        /// <summary>Resource ID.</summary>
        string PublicIPPrefixId { get; set; }
        /// <summary>The reference of the subnet resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }

    }
}