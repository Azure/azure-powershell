namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>Virtual Network resource.</summary>
    public partial class VirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetwork,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.Resource();

        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] AddressPrefix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).AddressSpaceAddressPrefix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).AddressSpaceAddressPrefix = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string DdosProtectionPlanId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DdosProtectionPlanId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DdosProtectionPlanId = value; }

        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] DnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DhcpOptionDnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DhcpOptionDnsServer = value; }

        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection
        /// plan associated with the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"DDOS Protection Enabled")]
        public bool? EnableDdosProtection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).EnableDdosProtection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).EnableDdosProtection = value; }

        /// <summary>
        /// Indicates if VM protection is enabled for all the subnets in the virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4, Label = @"VM Protection Enabled")]
        public bool? EnableVMProtection { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).EnableVMProtection; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).EnableVMProtection = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Location = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for AddressSpace</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkInternal.AddressSpace { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).AddressSpace; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).AddressSpace = value; }

        /// <summary>Internal Acessors for DdosProtectionPlan</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkInternal.DdosProtectionPlan { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DdosProtectionPlan; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DdosProtectionPlan = value; }

        /// <summary>Internal Acessors for DhcpOption</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDhcpOptions Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkInternal.DhcpOption { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DhcpOption; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).DhcpOption = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkPropertiesFormat()); set { {_property = value;} } }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Name; }

        /// <summary>A list of peerings in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeering[] Peering { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).VnetPeering; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).VnetPeering = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormat _property;

        /// <summary>Properties of the virtual network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.VirtualNetworkPropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 5, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>The resourceGuid property of the Virtual Network resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0, Label = @"GUID")]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>A list of subnets in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormatInternal)Property).Subnet = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)__resource).Type; }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }

        /// <summary>Creates an new <see cref="VirtualNetwork" /> instance.</summary>
        public VirtualNetwork()
        {

        }
    }
    /// Virtual Network resource.
    public partial interface IVirtualNetwork :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResource
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of address blocks reserved for this virtual network in CIDR notation.",
        SerializedName = @"addressPrefixes",
        PossibleTypes = new [] { typeof(string) })]
        string[] AddressPrefix { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string DdosProtectionPlanId { get; set; }
        /// <summary>The list of DNS servers IP addresses.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The list of DNS servers IP addresses.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsServer { get; set; }
        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection
        /// plan associated with the resource.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource.",
        SerializedName = @"enableDdosProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableDdosProtection { get; set; }
        /// <summary>
        /// Indicates if VM protection is enabled for all the subnets in the virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates if VM protection is enabled for all the subnets in the virtual network.",
        SerializedName = @"enableVmProtection",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableVMProtection { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>A list of peerings in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of peerings in a Virtual Network.",
        SerializedName = @"virtualNetworkPeerings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeering) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeering[] Peering { get; set; }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The resourceGuid property of the Virtual Network resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resourceGuid property of the Virtual Network resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>A list of subnets in a Virtual Network.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of subnets in a Virtual Network.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Subnet { get; set; }

    }
    /// Virtual Network resource.
    internal partial interface IVirtualNetworkInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal
    {
        /// <summary>A list of address blocks reserved for this virtual network in CIDR notation.</summary>
        string[] AddressPrefix { get; set; }
        /// <summary>
        /// The AddressSpace that contains an array of IP address ranges that can be used by subnets.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IAddressSpace AddressSpace { get; set; }
        /// <summary>The DDoS protection plan associated with the virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource DdosProtectionPlan { get; set; }
        /// <summary>Resource ID.</summary>
        string DdosProtectionPlanId { get; set; }
        /// <summary>
        /// The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IDhcpOptions DhcpOption { get; set; }
        /// <summary>The list of DNS servers IP addresses.</summary>
        string[] DnsServer { get; set; }
        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection
        /// plan associated with the resource.
        /// </summary>
        bool? EnableDdosProtection { get; set; }
        /// <summary>
        /// Indicates if VM protection is enabled for all the subnets in the virtual network.
        /// </summary>
        bool? EnableVMProtection { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>A list of peerings in a Virtual Network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPeering[] Peering { get; set; }
        /// <summary>Properties of the virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkPropertiesFormat Property { get; set; }
        /// <summary>
        /// The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resourceGuid property of the Virtual Network resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>A list of subnets in a Virtual Network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Subnet { get; set; }

    }
}