namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>NetworkInterface properties.</summary>
    public partial class NetworkInterfacePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal
    {

        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).DefaultSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).DefaultSecurityRule = value; }

        /// <summary>Backing field for <see cref="DnsSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings _dnsSetting;

        /// <summary>The DNS settings in network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceDnsSettings()); set => this._dnsSetting = value; }

        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] DnsSettingAppliedDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).AppliedDnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).AppliedDnsServer = value; }

        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] DnsSettingDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).DnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).DnsServer = value; }

        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingInternalDnsNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDnsNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDnsNameLabel = value; }

        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingInternalDomainNameSuffix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDomainNameSuffix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDomainNameSuffix = value; }

        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingInternalFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalFqdn = value; }

        /// <summary>Backing field for <see cref="EnableAcceleratedNetworking" /> property.</summary>
        private bool? _enableAcceleratedNetworking;

        /// <summary>If the network interface is accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableAcceleratedNetworking { get => this._enableAcceleratedNetworking; set => this._enableAcceleratedNetworking = value; }

        /// <summary>Backing field for <see cref="EnableIPForwarding" /> property.</summary>
        private bool? _enableIPForwarding;

        /// <summary>Indicates whether IP forwarding is enabled on this network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? EnableIPForwarding { get => this._enableIPForwarding; set => this._enableIPForwarding = value; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] _iPConfiguration;

        /// <summary>A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] IPConfiguration { get => this._iPConfiguration; set => this._iPConfiguration = value; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceDnsSettings()); set { {_dnsSetting = value;} } }

        /// <summary>Internal Acessors for NetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).NetworkInterface = value; }

        /// <summary>Internal Acessors for Nsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroup()); set { {_nsg = value;} } }

        /// <summary>Internal Acessors for NsgName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Name = value; }

        /// <summary>Internal Acessors for NsgProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.NsgProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Property = value; }

        /// <summary>Internal Acessors for NsgType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Type = value; }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Subnet = value; }

        /// <summary>Internal Acessors for VirtualMachine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal.VirtualMachine { get => (this._virtualMachine = this._virtualMachine ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set { {_virtualMachine = value;} } }

        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).NetworkInterface; }

        /// <summary>Backing field for <see cref="Nsg" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup _nsg;

        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroup()); set => this._nsg = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Name; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).ProvisioningState = value; }

        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgPropertiesResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).ResourceGuid = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)Nsg).Type; }

        /// <summary>Backing field for <see cref="Primary" /> property.</summary>
        private bool? _primary;

        /// <summary>Gets whether this is a primary network interface on a virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public bool? Primary { get => this._primary; set => this._primary = value; }

        /// <summary>Backing field for <see cref="ProvisioningState" /> property.</summary>
        private string _provisioningState;

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ProvisioningState { get => this._provisioningState; set => this._provisioningState = value; }

        /// <summary>Backing field for <see cref="ResourceGuid" /> property.</summary>
        private string _resourceGuid;

        /// <summary>The resource GUID property of the network interface resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string ResourceGuid { get => this._resourceGuid; set => this._resourceGuid = value; }

        /// <summary>A collection of security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).SecurityRule = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupInternal)Nsg).Subnet; }

        /// <summary>Backing field for <see cref="VirtualMachine" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource _virtualMachine;

        /// <summary>The reference of a virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource VirtualMachine { get => (this._virtualMachine = this._virtualMachine ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResource()); set => this._virtualMachine = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualMachineId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)VirtualMachine).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)VirtualMachine).Id = value; }

        /// <summary>Creates an new <see cref="NetworkInterfacePropertiesFormat" /> instance.</summary>
        public NetworkInterfacePropertiesFormat()
        {

        }
    }
    /// NetworkInterface properties.
    public partial interface INetworkInterfacePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable
    {
        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The default security rules of network security group.",
        SerializedName = @"defaultSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.",
        SerializedName = @"appliedDnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsSettingAppliedDnsServer { get; set; }
        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS' value cannot be combined with other IPs, it must be the only value in dnsServers collection.",
        SerializedName = @"dnsServers",
        PossibleTypes = new [] { typeof(string) })]
        string[] DnsSettingDnsServer { get; set; }
        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.",
        SerializedName = @"internalDnsNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSettingInternalDnsNameLabel { get; set; }
        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can be constructed by concatenating the VM name with the value of internalDomainNameSuffix.",
        SerializedName = @"internalDomainNameSuffix",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSettingInternalDomainNameSuffix { get; set; }
        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified DNS name supporting internal communications between VMs in the same virtual network.",
        SerializedName = @"internalFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string DnsSettingInternalFqdn { get; set; }
        /// <summary>If the network interface is accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If the network interface is accelerated networking enabled.",
        SerializedName = @"enableAcceleratedNetworking",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>Indicates whether IP forwarding is enabled on this network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Indicates whether IP forwarding is enabled on this network interface.",
        SerializedName = @"enableIPForwarding",
        PossibleTypes = new [] { typeof(bool) })]
        bool? EnableIPForwarding { get; set; }
        /// <summary>A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of IPConfigurations of the network interface.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The MAC address of the network interface.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to network interfaces.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NetworkInterface { get;  }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string NsgEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string NsgId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string NsgLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string NsgName { get;  }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string NsgPropertiesProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the network security group resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string NsgPropertiesResourceGuid { get; set; }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string NsgType { get;  }
        /// <summary>Gets whether this is a primary network interface on a virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets whether this is a primary network interface on a virtual machine.",
        SerializedName = @"primary",
        PossibleTypes = new [] { typeof(bool) })]
        bool? Primary { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network interface resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the network interface resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string ResourceGuid { get; set; }
        /// <summary>A collection of security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A collection of security rules of the network security group.",
        SerializedName = @"securityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to subnets.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get;  }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string VirtualMachineId { get; set; }

    }
    /// NetworkInterface properties.
    internal partial interface INetworkInterfacePropertiesFormatInternal

    {
        /// <summary>The default security rules of network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>The DNS settings in network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings DnsSetting { get; set; }
        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        string[] DnsSettingAppliedDnsServer { get; set; }
        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        string[] DnsSettingDnsServer { get; set; }
        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        string DnsSettingInternalDnsNameLabel { get; set; }
        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        string DnsSettingInternalDomainNameSuffix { get; set; }
        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        string DnsSettingInternalFqdn { get; set; }
        /// <summary>If the network interface is accelerated networking enabled.</summary>
        bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>Indicates whether IP forwarding is enabled on this network interface.</summary>
        bool? EnableIPForwarding { get; set; }
        /// <summary>A list of IPConfigurations of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>The MAC address of the network interface.</summary>
        string MacAddress { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NetworkInterface { get; set; }
        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Nsg { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string NsgEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string NsgId { get; set; }
        /// <summary>Resource location.</summary>
        string NsgLocation { get; set; }
        /// <summary>Resource name.</summary>
        string NsgName { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string NsgPropertiesProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        string NsgPropertiesResourceGuid { get; set; }
        /// <summary>Properties of the network security group</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat NsgProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        string NsgType { get; set; }
        /// <summary>Gets whether this is a primary network interface on a virtual machine.</summary>
        bool? Primary { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network interface resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>A collection of security rules of the network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get; set; }
        /// <summary>The reference of a virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource VirtualMachine { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualMachineId { get; set; }

    }
}