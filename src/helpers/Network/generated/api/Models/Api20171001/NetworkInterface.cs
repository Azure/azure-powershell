namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Extensions;

    /// <summary>A network interface in a resource group.</summary>
    public partial class NetworkInterface :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.Resource();

        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] AppliedDnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingAppliedDnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingAppliedDnsServer = value; }

        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DefaultSecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DefaultSecurityRule = value; }

        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string[] DnsServer { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingDnsServer; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingDnsServer = value; }

        /// <summary>If the network interface is accelerated networking enabled.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 5, Label = @"Accelerated Networking Enabled")]
        public bool? EnableAcceleratedNetworking { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).EnableAcceleratedNetworking; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).EnableAcceleratedNetworking = value; }

        /// <summary>Indicates whether IP forwarding is enabled on this network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 6, Label = @"IP Forwarding Enabled")]
        public bool? EnableIPForwarding { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).EnableIPForwarding; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).EnableIPForwarding = value; }

        /// <summary>Backing field for <see cref="Etag" /> property.</summary>
        private string _etag;

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Etag { get => this._etag; set => this._etag = value; }

        /// <summary>A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] IPConfiguration { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).IPConfiguration; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).IPConfiguration = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Id = value; }

        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string InternalDnsNameLabel { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingInternalDnsNameLabel; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingInternalDnsNameLabel = value; }

        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string InternalDomainNameSuffix { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingInternalDomainNameSuffix; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingInternalDomainNameSuffix = value; }

        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string InternalFqdn { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingInternalFqdn; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSettingInternalFqdn = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 2)]
        public string Location { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Location = value; }

        /// <summary>The MAC address of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 3, Label = @"MAC Address")]
        public string MacAddress { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).MacAddress; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).MacAddress = value; }

        /// <summary>Internal Acessors for DnsSetting</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.DnsSetting { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSetting; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).DnsSetting = value; }

        /// <summary>Internal Acessors for Nsg</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.Nsg { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Nsg; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Nsg = value; }

        /// <summary>Internal Acessors for NsgAdditionalNetworkInterface</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.NsgAdditionalNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NetworkInterface; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NetworkInterface = value; }

        /// <summary>Internal Acessors for NsgName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgName = value; }

        /// <summary>Internal Acessors for NsgProperty</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.NsgProperty { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgProperty; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgProperty = value; }

        /// <summary>Internal Acessors for NsgType</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgType = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfacePropertiesFormat()); set { {_property = value;} } }

        /// <summary>Internal Acessors for Subnet</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Subnet; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Subnet = value; }

        /// <summary>Internal Acessors for VirtualMachine</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceInternal.VirtualMachine { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).VirtualMachine; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).VirtualMachine = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 1)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Name; }

        /// <summary>A collection of references to network interfaces.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NsgAdditionalNetworkInterface { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NetworkInterface; }

        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgEtag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgEtag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgEtag = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgId = value; }

        /// <summary>Resource location.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgLocation { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgLocation; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgLocation = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgName; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgPropertiesProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgPropertiesProvisioningState = value; }

        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgPropertiesResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgPropertiesResourceGuid = value; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgTag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgTag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string NsgType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).NsgType; }

        /// <summary>Gets whether this is a primary network interface on a virtual machine.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 4)]
        public bool? Primary { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Primary; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Primary = value; }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat _property;

        /// <summary>Properties of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        internal Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfacePropertiesFormat()); set => this._property = value; }

        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 7, Label = @"Provisioning State")]
        public string ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).ProvisioningState = value; }

        /// <summary>The resource GUID property of the network interface resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.FormatTable(Index = 0, Label = @"GUID")]
        public string ResourceGuid { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).ResourceGuid; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).ResourceGuid = value; }

        /// <summary>A collection of security rules of the network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] SecurityRule { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).SecurityRule; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).SecurityRule = value; }

        /// <summary>A collection of references to subnets.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[] Subnet { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).Subnet; }

        /// <summary>Resource tags.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags Tag { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Tag = value; }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal)__resource).Type; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Origin(Microsoft.Azure.PowerShell.Cmdlets.Network.PropertyOrigin.Inlined)]
        [Microsoft.Azure.PowerShell.Cmdlets.Network.DoNotFormat]
        public string VirtualMachineId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).VirtualMachineId; set => ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)Property).VirtualMachineId = value; }

        /// <summary>Creates an new <see cref="NetworkInterface" /> instance.</summary>
        public NetworkInterface()
        {

        }

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
    }
    /// A network interface in a resource group.
    public partial interface INetworkInterface :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResource
    {
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
        string[] AppliedDnsServer { get; set; }
        /// <summary>The default security rules of network security group.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The default security rules of network security group.",
        SerializedName = @"defaultSecurityRules",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get; set; }
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
        string[] DnsServer { get; set; }
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
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A unique read-only string that changes whenever the resource is updated.",
        SerializedName = @"etag",
        PossibleTypes = new [] { typeof(string) })]
        string Etag { get; set; }
        /// <summary>A list of IPConfigurations of the network interface.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of IPConfigurations of the network interface.",
        SerializedName = @"ipConfigurations",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration) })]
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.",
        SerializedName = @"internalDnsNameLabel",
        PossibleTypes = new [] { typeof(string) })]
        string InternalDnsNameLabel { get; set; }
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
        string InternalDomainNameSuffix { get; set; }
        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Fully qualified DNS name supporting internal communications between VMs in the same virtual network.",
        SerializedName = @"internalFqdn",
        PossibleTypes = new [] { typeof(string) })]
        string InternalFqdn { get; set; }
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
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NsgAdditionalNetworkInterface { get;  }
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
        string NsgProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The resource GUID property of the network security group resource.",
        SerializedName = @"resourceGuid",
        PossibleTypes = new [] { typeof(string) })]
        string NsgResourceGuid { get; set; }
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
    /// A network interface in a resource group.
    internal partial interface INetworkInterfaceInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceInternal
    {
        /// <summary>
        /// If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from
        /// all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
        /// </summary>
        string[] AppliedDnsServer { get; set; }
        /// <summary>The default security rules of network security group.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[] DefaultSecurityRule { get; set; }
        /// <summary>
        /// List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS'
        /// value cannot be combined with other IPs, it must be the only value in dnsServers collection.
        /// </summary>
        string[] DnsServer { get; set; }
        /// <summary>The DNS settings in network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings DnsSetting { get; set; }
        /// <summary>If the network interface is accelerated networking enabled.</summary>
        bool? EnableAcceleratedNetworking { get; set; }
        /// <summary>Indicates whether IP forwarding is enabled on this network interface.</summary>
        bool? EnableIPForwarding { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string Etag { get; set; }
        /// <summary>A list of IPConfigurations of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[] IPConfiguration { get; set; }
        /// <summary>
        /// Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
        /// </summary>
        string InternalDnsNameLabel { get; set; }
        /// <summary>
        /// Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can
        /// be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
        /// </summary>
        string InternalDomainNameSuffix { get; set; }
        /// <summary>
        /// Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
        /// </summary>
        string InternalFqdn { get; set; }
        /// <summary>The MAC address of the network interface.</summary>
        string MacAddress { get; set; }
        /// <summary>The reference of the NetworkSecurityGroup resource.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup Nsg { get; set; }
        /// <summary>A collection of references to network interfaces.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[] NsgAdditionalNetworkInterface { get; set; }
        /// <summary>A unique read-only string that changes whenever the resource is updated.</summary>
        string NsgEtag { get; set; }
        /// <summary>Resource ID.</summary>
        string NsgId { get; set; }
        /// <summary>Resource location.</summary>
        string NsgLocation { get; set; }
        /// <summary>Resource name.</summary>
        string NsgName { get; set; }
        /// <summary>Properties of the network security group</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat NsgProperty { get; set; }
        /// <summary>
        /// The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        /// </summary>
        string NsgProvisioningState { get; set; }
        /// <summary>The resource GUID property of the network security group resource.</summary>
        string NsgResourceGuid { get; set; }
        /// <summary>Resource tags.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags NsgTag { get; set; }
        /// <summary>Resource type.</summary>
        string NsgType { get; set; }
        /// <summary>Gets whether this is a primary network interface on a virtual machine.</summary>
        bool? Primary { get; set; }
        /// <summary>Properties of the network interface.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat Property { get; set; }
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