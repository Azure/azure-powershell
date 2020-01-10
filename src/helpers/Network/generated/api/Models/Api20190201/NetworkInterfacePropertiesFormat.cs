namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>NetworkInterface properties.</summary>
    public partial class NetworkInterfacePropertiesFormat :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormat,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal
    {

        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).DefaultSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).DefaultSecurityRule = value; }

        /// <summary>Backing field for <see cref="DnsSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettings _dnsSetting;

        /// <summary>The DNS settings in network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettings DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceDnsSettings()); set => this._dnsSetting = value; }

        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] DnsSettingAppliedDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).AppliedDnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).AppliedDnsServer = value; }

        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string[] DnsSettingDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).DnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).DnsServer = value; }

        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingInternalDnsNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDnsNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDnsNameLabel = value; }

        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingInternalDomainNameSuffix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDomainNameSuffix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalDomainNameSuffix = value; }

        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string DnsSettingInternalFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettingsInternal)DnsSetting).InternalFqdn = value; }

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

        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string EndpointServiceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).EndpointServiceId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).EndpointServiceId = value; }

        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Fqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Fqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Fqdn = value; }

        /// <summary>Backing field for <see cref="HostedWorkload" /> property.</summary>
        private string[] _hostedWorkload;

        /// <summary>A list of references to linked BareMetal resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string[] HostedWorkload { get => this._hostedWorkload; }

        /// <summary>Backing field for <see cref="IPConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration[] _iPConfiguration;

        /// <summary>A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration[] IPConfiguration { get => this._iPConfiguration; set => this._iPConfiguration = value; }

        /// <summary>Backing field for <see cref="InterfaceEndpoint" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint _interfaceEndpoint;

        /// <summary>A reference to the interface endpoint to which the network interface is linked.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint InterfaceEndpoint { get => (this._interfaceEndpoint = this._interfaceEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InterfaceEndpoint()); }

        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceEndpointEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceEndpointId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceEndpointLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceEndpointName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Name; }

        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] InterfaceEndpointPropertiesNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).NetworkInterface; }

        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceEndpointPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).ProvisioningState; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags InterfaceEndpointTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string InterfaceEndpointType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Type; }

        /// <summary>Backing field for <see cref="MacAddress" /> property.</summary>
        private string _macAddress;

        /// <summary>The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public string MacAddress { get => this._macAddress; set => this._macAddress = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.DnsSetting { get => (this._dnsSetting = this._dnsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkInterfaceDnsSettings()); set { {_dnsSetting = value;} } }

        /// <summary>Internal Acessors for EndpointService</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.EndpointService { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).EndpointService; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).EndpointService = value; }

        /// <summary>Internal Acessors for HostedWorkload</summary>
        string[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.HostedWorkload { get => this._hostedWorkload; set { {_hostedWorkload = value;} } }

        /// <summary>Internal Acessors for InterfaceEndpoint</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.InterfaceEndpoint { get => (this._interfaceEndpoint = this._interfaceEndpoint ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.InterfaceEndpoint()); set { {_interfaceEndpoint = value;} } }

        /// <summary>Internal Acessors for InterfaceEndpointName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.InterfaceEndpointName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Name = value; }

        /// <summary>Internal Acessors for InterfaceEndpointPropertiesNetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.InterfaceEndpointPropertiesNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).NetworkInterface = value; }

        /// <summary>Internal Acessors for InterfaceEndpointPropertiesProvisioningState</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.InterfaceEndpointPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).ProvisioningState = value; }

        /// <summary>Internal Acessors for InterfaceEndpointProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.InterfaceEndpointProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Property = value; }

        /// <summary>Internal Acessors for InterfaceEndpointType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.InterfaceEndpointType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)InterfaceEndpoint).Type = value; }

        /// <summary>Internal Acessors for Nsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroup()); set { {_nsg = value;} } }

        /// <summary>Internal Acessors for NsgName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Name = value; }

        /// <summary>Internal Acessors for NsgPropertiesNetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.NsgPropertiesNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).NetworkInterface = value; }

        /// <summary>Internal Acessors for NsgPropertiesSubnets</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.NsgPropertiesSubnets { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Subnet = value; }

        /// <summary>Internal Acessors for NsgProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.NsgProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Property = value; }

        /// <summary>Internal Acessors for NsgType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Type = value; }

        /// <summary>Internal Acessors for Owner</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.Owner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Owner; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Owner = value; }

        /// <summary>Internal Acessors for VirtualMachine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfacePropertiesFormatInternal.VirtualMachine { get => (this._virtualMachine = this._virtualMachine ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); set { {_virtualMachine = value;} } }

        /// <summary>Backing field for <see cref="Nsg" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup _nsg;

        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup Nsg { get => (this._nsg = this._nsg ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.NetworkSecurityGroup()); set => this._nsg = value; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Etag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Etag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Id = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Location = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Name; }

        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NsgPropertiesNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).NetworkInterface; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgPropertiesProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ProvisioningState = value; }

        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgPropertiesResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).ResourceGuid = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] NsgPropertiesSubnets { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).Subnet; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags NsgTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceInternal)Nsg).Type; }

        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string Owner { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Owner; }

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
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupInternal)Nsg).SecurityRule = value; }

        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointInternal)InterfaceEndpoint).Subnet = value; }

        /// <summary>Backing field for <see cref="TapConfiguration" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] _tapConfiguration;

        /// <summary>A list of TapConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] TapConfiguration { get => this._tapConfiguration; set => this._tapConfiguration = value; }

        /// <summary>Backing field for <see cref="VirtualMachine" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource _virtualMachine;

        /// <summary>The reference of a virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualMachine { get => (this._virtualMachine = this._virtualMachine ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.SubResource()); }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        public string VirtualMachineId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualMachine).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResourceInternal)VirtualMachine).Id = value; }

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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get; set; }
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
        /// <summary>A list of references to linked BareMetal resources</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A list of references to linked BareMetal resources",
        SerializedName = @"hostedWorkloads",
        PossibleTypes = new [] { typeof(string) })]
        string[] HostedWorkload { get;  }
        /// <summary>A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of IPConfigurations of the network interface.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Gets a unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointEtag { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointId { get; set; }
        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource location.",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointLocation { get; set; }
        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource name.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointName { get;  }
        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Gets an array of references to the network interfaces created for this interface endpoint.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] InterfaceEndpointPropertiesNetworkInterface { get;  }
        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointPropertiesProvisioningState { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags InterfaceEndpointTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string InterfaceEndpointType { get;  }
        /// <summary>The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The MAC address of the network interface.",
        SerializedName = @"macAddress",
        PossibleTypes = new [] { typeof(string) })]
        string MacAddress { get; set; }
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
        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to network interfaces.",
        SerializedName = @"networkInterfaces",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NsgPropertiesNetworkInterface { get;  }
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
        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A collection of references to subnets.",
        SerializedName = @"subnets",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] NsgPropertiesSubnets { get;  }
        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource tags.",
        SerializedName = @"tags",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Resource type.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string NsgType { get;  }
        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"A read-only property that identifies who created this interface endpoint.",
        SerializedName = @"owner",
        PossibleTypes = new [] { typeof(string) })]
        string Owner { get;  }
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
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The ID of the subnet from which the private IP will be allocated.",
        SerializedName = @"subnet",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }
        /// <summary>A list of TapConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of TapConfigurations of the network interface.",
        SerializedName = @"tapConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] TapConfiguration { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>The DNS settings in network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceDnsSettings DnsSetting { get; set; }
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
        /// <summary>A reference to the service being brought into the virtual network.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IEndpointService EndpointService { get; set; }
        /// <summary>A unique identifier of the service being referenced by the interface endpoint.</summary>
        string EndpointServiceId { get; set; }
        /// <summary>
        /// A first-party service's FQDN that is mapped to the private IP allocated via this interface endpoint.
        /// </summary>
        string Fqdn { get; set; }
        /// <summary>A list of references to linked BareMetal resources</summary>
        string[] HostedWorkload { get; set; }
        /// <summary>A list of IPConfigurations of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>A reference to the interface endpoint to which the network interface is linked.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpoint InterfaceEndpoint { get; set; }
        /// <summary>Gets a unique read-only string that changes whenever the resource is updated.</summary>
        string InterfaceEndpointEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string InterfaceEndpointId { get; set; }
        /// <summary>Resource location.</summary>
        string InterfaceEndpointLocation { get; set; }
        /// <summary>Resource name.</summary>
        string InterfaceEndpointName { get; set; }
        /// <summary>
        /// Gets an array of references to the network interfaces created for this interface endpoint.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] InterfaceEndpointPropertiesNetworkInterface { get; set; }
        /// <summary>
        /// The provisioning state of the interface endpoint. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string InterfaceEndpointPropertiesProvisioningState { get; set; }
        /// <summary>Properties of the interface endpoint.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInterfaceEndpointProperties InterfaceEndpointProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags InterfaceEndpointTag { get; set; }
        /// <summary>Resource type.</summary>
        string InterfaceEndpointType { get; set; }
        /// <summary>The MAC address of the network interface.</summary>
        string MacAddress { get; set; }
        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroup Nsg { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string NsgEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string NsgId { get; set; }
        /// <summary>Resource location.</summary>
        string NsgLocation { get; set; }
        /// <summary>Resource name.</summary>
        string NsgName { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface[] NsgPropertiesNetworkInterface { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string NsgPropertiesProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        string NsgPropertiesResourceGuid { get; set; }
        /// <summary>A collection of references to subnets.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet[] NsgPropertiesSubnets { get; set; }
        /// <summary>Properties of the network security group</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkSecurityGroupPropertiesFormat NsgProperty { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        string NsgType { get; set; }
        /// <summary>A read-only property that identifies who created this interface endpoint.</summary>
        string Owner { get; set; }
        /// <summary>Gets whether this is a primary network interface on a virtual machine.</summary>
        bool? Primary { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string ProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network interface resource.</summary>
        string ResourceGuid { get; set; }
        /// <summary>A collection of security rules of the network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISecurityRule[] SecurityRule { get; set; }
        /// <summary>The ID of the subnet from which the private IP will be allocated.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet Subnet { get; set; }
        /// <summary>A list of TapConfigurations of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterfaceTapConfiguration[] TapConfiguration { get; set; }
        /// <summary>The reference of a virtual machine.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubResource VirtualMachine { get; set; }
        /// <summary>Resource ID.</summary>
        string VirtualMachineId { get; set; }

    }
}