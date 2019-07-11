---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-aznetworkinterface
schema: 2.0.0
---

# New-AzNetworkInterface

## SYNOPSIS
Creates or updates a network interface.

## SYNTAX

### Create1 (Default)
```
New-AzNetworkInterface -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <INetworkInterface>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpanded1
```
New-AzNetworkInterface -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-AppliedDnsServer <String[]>] [-DefaultSecurityRule <ISecurityRule[]>] [-DnsServer <String[]>]
 [-EnableAcceleratedNetworking] [-EnableIPForwarding] [-Etag <String>]
 [-IPConfiguration <INetworkInterfaceIPConfiguration[]>] [-Id <String>] [-InternalDnsNameLabel <String>]
 [-InternalDomainNameSuffix <String>] [-InternalFqdn <String>] [-Location <String>] [-MacAddress <String>]
 [-NsgEtag <String>] [-NsgId <String>] [-NsgLocation <String>] [-NsgProvisioningState <String>]
 [-NsgResourceGuid <String>] [-NsgTag <Hashtable>] [-Primary] [-ProvisioningState <String>]
 [-ResourceGuid <String>] [-SecurityRule <ISecurityRule[]>] [-Tag <Hashtable>] [-VMId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded1
```
New-AzNetworkInterface -InputObject <INetworkIdentity> [-AppliedDnsServer <String[]>]
 [-DefaultSecurityRule <ISecurityRule[]>] [-DnsServer <String[]>] [-EnableAcceleratedNetworking]
 [-EnableIPForwarding] [-Etag <String>] [-IPConfiguration <INetworkInterfaceIPConfiguration[]>] [-Id <String>]
 [-InternalDnsNameLabel <String>] [-InternalDomainNameSuffix <String>] [-InternalFqdn <String>]
 [-Location <String>] [-MacAddress <String>] [-NsgEtag <String>] [-NsgId <String>] [-NsgLocation <String>]
 [-NsgProvisioningState <String>] [-NsgResourceGuid <String>] [-NsgTag <Hashtable>] [-Primary]
 [-ProvisioningState <String>] [-ResourceGuid <String>] [-SecurityRule <ISecurityRule[]>] [-Tag <Hashtable>]
 [-VMId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity1
```
New-AzNetworkInterface -InputObject <INetworkIdentity> [-Parameter <INetworkInterface>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a network interface.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AppliedDnsServer
If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from all NICs that are part of the Availability Set.
This property is what is configured on each of those VMs.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultSecurityRule
The default security rules of network security group.
To construct, see NOTES section for DEFAULTSECURITYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DnsServer
List of DNS servers IP addresses.
Use 'AzureProvidedDNS' to switch to azure provided DNS resolution.
'AzureProvidedDNS' value cannot be combined with other IPs, it must be the only value in dnsServers collection.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableAcceleratedNetworking
If the network interface is accelerated networking enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableIPForwarding
Indicates whether IP forwarding is enabled on this network interface.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Etag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded1, CreateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InternalDnsNameLabel
Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InternalDomainNameSuffix
Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM.
This DNS name can be constructed by concatenating the VM name with the value of internalDomainNameSuffix.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InternalFqdn
Fully qualified DNS name supporting internal communications between VMs in the same virtual network.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IPConfiguration
A list of IPConfigurations of the network interface.
To construct, see NOTES section for IPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MacAddress
The MAC address of the network interface.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the network interface.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: NetworkInterfaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsgEtag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroupEtag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsgId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroupId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsgLocation
Resource location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroupLocation

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsgProvisioningState
The provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroupProvisioningState

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsgResourceGuid
The resource GUID property of the network security group resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroupResourceGuid

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NsgTag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: NetworkSecurityGroupTag

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
A network interface in a resource group.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface
Parameter Sets: Create1, CreateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Primary
Gets whether this is a primary network interface on a virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
The provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases: SubnetId, PublicIpAddressId, PublicIpAddress, LoadBalancerBackendAddressPoolId, LoadBalancerBackendAddressPool, LoadBalancerInboundNatRuleId, LoadBalancerInboundNatRule, ApplicationGatewayBackendAddressPoolId, ApplicationGatewayBackendAddressPool, ApplicationSecurityGroupId, ApplicationSecurityGroup, PrivateIpAddress, IpConfigurationName, NetworkSecurityGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGuid
The resource GUID property of the network interface resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SecurityRule
A collection of security rules of the network security group.
To construct, see NOTES section for SECURITYRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded1, CreateViaIdentityExpanded1
Aliases: VirtualMachineId

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### DEFAULTSECURITYRULE <ISecurityRule[]>: The default security rules of network security group.
  - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied. Possible values are: 'Allow' and 'Deny'.
  - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. Possible values are: 'Inbound' and 'Outbound'.
  - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', and '*'.
  - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
  - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
  - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
  - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
  - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
  - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
  - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
  - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
  - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
  - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
  - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.

#### IPCONFIGURATION <INetworkInterfaceIPConfiguration[]>: A list of IPConfigurations of the network interface.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Resource that is unique within a resource group. This name can be used to access the resource.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[OutboundNatRuleId <String>]`: Resource ID.
    - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
    - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[BackendIPConfigurationId <String>]`: Resource ID.
    - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
    - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[FrontendIPConfigurationId <String>]`: Resource ID.
    - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
    - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
    - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
    - `[Protocol <TransportProtocol?>]`: The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All'.
    - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
      - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
      - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
      - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
      - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[IPConfigurationId <String>]`: Resource ID.
      - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[IPConfigurationPropertiesProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
      - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP allocation method. Possible values are 'Static' and 'Dynamic'.
      - `[PropertiesIpConfigurationPropertiesPublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
      - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.
      - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
      - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
      - `[Subnet <ISubnet>]`: The reference of the subnet resource.
        - `[AddressPrefix <String>]`: The address prefix for the subnet.
        - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
          - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied. Possible values are: 'Allow' and 'Deny'.
          - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. Possible values are: 'Inbound' and 'Outbound'.
          - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', and '*'.
          - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
          - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
          - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
          - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
          - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
          - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
          - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
          - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
          - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
          - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
          - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
        - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[NetworkSecurityGroupId <String>]`: Resource ID.
        - `[NetworkSecurityGroupLocation <String>]`: Resource location.
        - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
        - `[ProvisioningState <String>]`: The provisioning state of the resource.
        - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
        - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
          - `[Link <String>]`: Link to the external resource
          - `[LinkedResourceType <String>]`: Resource type of the linked resource.
          - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
          - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
          - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
          - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[RouteTableEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
        - `[RouteTableId <String>]`: Resource ID.
        - `[RouteTableLocation <String>]`: Resource location.
        - `[RouteTablePropertiesProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[RouteTableTag <IResourceTags>]`: Resource tags.
        - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
        - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
          - `[Location <String[]>]`: A list of locations.
          - `[ProvisioningState <String>]`: The provisioning state of the resource.
          - `[Service <String>]`: The type of the endpoint service.
      - `[Version <IPVersion?>]`: The public IP address version. Possible values are: 'IPv4' and 'IPv6'.
      - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
  - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.

#### PARAMETER <INetworkInterface>: A network interface in a resource group.
  - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
    - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied. Possible values are: 'Allow' and 'Deny'.
    - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. Possible values are: 'Inbound' and 'Outbound'.
    - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', and '*'.
    - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
    - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
    - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
    - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
    - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
    - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
    - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
    - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
    - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
    - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
    - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
  - `[DnsSettingAppliedDnsServer <String[]>]`: If the VM that uses this NIC is part of an Availability Set, then this list will have the union of all DNS servers from all NICs that are part of the Availability Set. This property is what is configured on each of those VMs.
  - `[DnsSettingDnsServer <String[]>]`: List of DNS servers IP addresses. Use 'AzureProvidedDNS' to switch to azure provided DNS resolution. 'AzureProvidedDNS' value cannot be combined with other IPs, it must be the only value in dnsServers collection.
  - `[DnsSettingInternalDnsNameLabel <String>]`: Relative DNS name for this NIC used for internal communications between VMs in the same virtual network.
  - `[DnsSettingInternalDomainNameSuffix <String>]`: Even if internalDnsNameLabel is not specified, a DNS entry is created for the primary NIC of the VM. This DNS name can be constructed by concatenating the VM name with the value of internalDomainNameSuffix.
  - `[DnsSettingInternalFqdn <String>]`: Fully qualified DNS name supporting internal communications between VMs in the same virtual network.
  - `[EnableAcceleratedNetworking <Boolean?>]`: If the network interface is accelerated networking enabled.
  - `[EnableIPForwarding <Boolean?>]`: Indicates whether IP forwarding is enabled on this network interface.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPConfiguration <INetworkInterfaceIPConfiguration[]>]`: A list of IPConfigurations of the network interface.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
        - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
        - `[IPAddress <String>]`: IP address
      - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Resource that is unique within a resource group. This name can be used to access the resource.
      - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[Type <String>]`: Type of the resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[OutboundNatRuleId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[BackendIPConfigurationId <String>]`: Resource ID.
      - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
      - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[FrontendIPConfigurationId <String>]`: Resource ID.
      - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
      - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
      - `[Protocol <TransportProtocol?>]`: The transport protocol for the endpoint. Possible values are 'Udp' or 'Tcp' or 'All'.
      - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPConfigurationPropertiesProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
        - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
        - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP allocation method. Possible values are 'Static' and 'Dynamic'.
        - `[PropertiesIpConfigurationPropertiesPublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP allocation method. Possible values are: 'Static' and 'Dynamic'.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Subnet <ISubnet>]`: The reference of the subnet resource.
          - `[AddressPrefix <String>]`: The address prefix for the subnet.
          - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
          - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[NetworkSecurityGroupId <String>]`: Resource ID.
          - `[NetworkSecurityGroupLocation <String>]`: Resource location.
          - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
            - `[(Any) <String>]`: This indicates any property can be added to this object.
          - `[ProvisioningState <String>]`: The provisioning state of the resource.
          - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
          - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
            - `[Link <String>]`: Link to the external resource
            - `[LinkedResourceType <String>]`: Resource type of the linked resource.
            - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
            - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
            - `[AddressPrefix <String>]`: The destination CIDR to which the route applies.
            - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[NextHopIPAddress <String>]`: The IP address packets should be forwarded to. Next hop values are only allowed in routes where the next hop type is VirtualAppliance.
            - `[ProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[RouteTableEtag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
          - `[RouteTableId <String>]`: Resource ID.
          - `[RouteTableLocation <String>]`: Resource location.
          - `[RouteTablePropertiesProvisioningState <String>]`: The provisioning state of the resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[RouteTableTag <IResourceTags>]`: Resource tags.
          - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
          - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
            - `[Location <String[]>]`: A list of locations.
            - `[ProvisioningState <String>]`: The provisioning state of the resource.
            - `[Service <String>]`: The type of the endpoint service.
        - `[Version <IPVersion?>]`: The public IP address version. Possible values are: 'IPv4' and 'IPv6'.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: Defines how a private IP address is assigned. Possible values are: 'Static' and 'Dynamic'.
    - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[MacAddress <String>]`: The MAC address of the network interface.
  - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[NetworkSecurityGroupId <String>]`: Resource ID.
  - `[NetworkSecurityGroupLocation <String>]`: Resource location.
  - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[NetworkSecurityGroupPropertiesResourceGuid <String>]`: The resource GUID property of the network security group resource.
  - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
  - `[Primary <Boolean?>]`: Gets whether this is a primary network interface on a virtual machine.
  - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[ResourceGuid <String>]`: The resource GUID property of the network interface resource.
  - `[SecurityRule <ISecurityRule[]>]`: A collection of security rules of the network security group.
  - `[VirtualMachineId <String>]`: Resource ID.

#### SECURITYRULE <ISecurityRule[]>: A collection of security rules of the network security group.
  - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied. Possible values are: 'Allow' and 'Deny'.
  - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic. Possible values are: 'Inbound' and 'Outbound'.
  - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', and '*'.
  - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
  - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
  - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
  - `[DestinationPortRange <String>]`: The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Priority <Int32?>]`: The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
  - `[PropertiesDestinationAddressPrefixes <String[]>]`: The destination address prefixes. CIDR or destination IP ranges.
  - `[PropertiesDestinationPortRanges <String[]>]`: The destination port ranges.
  - `[PropertiesSourceAddressPrefixes <String[]>]`: The CIDR or source IP ranges.
  - `[PropertiesSourcePortRanges <String[]>]`: The source port ranges.
  - `[ProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[SourceAddressPrefix <String>]`: The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from. 
  - `[SourceApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as source.
  - `[SourcePortRange <String>]`: The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.

## RELATED LINKS

