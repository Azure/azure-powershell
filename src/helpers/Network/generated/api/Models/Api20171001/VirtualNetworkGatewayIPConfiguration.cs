namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>IP configuration for virtual network gateway</summary>
    public partial class VirtualNetworkGatewayIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfiguration,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource __subResource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource();

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)__subResource).Id = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayIPConfigurationPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for PublicIPAddress</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationInternal.PublicIPAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).PublicIPAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).PublicIPAddress = value; }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationInternal.Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).Subnet = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>The private IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).PrivateIPAllocationMethod; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).PrivateIPAllocationMethod = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormat _property;

        /// <summary>Properties of the virtual network gateway ip configuration.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.VirtualNetworkGatewayIPConfigurationPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).ProvisioningState; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string PublicIPAddressId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).PublicIPAddressId = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string SubnetId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).SubnetId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormatInternal)Property).SubnetId = value; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__subResource), __subResource);
            await eventListener.AssertObjectIsValid(nameof(__subResource), __subResource);
        }

        /// <summary>Creates an new <see cref="VirtualNetworkGatewayIPConfiguration" /> instance.</summary>
        public VirtualNetworkGatewayIPConfiguration()
        {

        }
    }
    /// IP configuration for virtual network gateway
    public partial interface IVirtualNetworkGatewayIPConfiguration :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the resource that is unique within a resource group. This name can be used to access the resource.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The private IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The private IP allocation method. Possible values are: 'Static' and 'Dynamic'.",
        SerializedName = @"privateIPAllocationMethod",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PublicIPAddressId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string SubnetId { get; set; }

    }
    /// IP configuration for virtual network gateway
    internal partial interface IVirtualNetworkGatewayIPConfigurationInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal
    {
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        string Name { get; set; }
        /// <summary>The private IP allocation method. Possible values are: 'Static' and 'Dynamic'.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod? PrivateIPAllocationMethod { get; set; }
        /// <summary>Properties of the virtual network gateway ip configuration.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IVirtualNetworkGatewayIPConfigurationPropertiesFormat Property { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The reference of the public IP resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource PublicIPAddress { get; set; }
        /// <summary>Resource ID.</summary>
        string PublicIPAddressId { get; set; }
        /// <summary>The reference of the subnet resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Subnet { get; set; }
        /// <summary>Resource ID.</summary>
        string SubnetId { get; set; }

    }
}