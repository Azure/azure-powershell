---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azloadbalancerinboundnatrule
schema: 2.0.0
---

# New-AzLoadBalancerInboundNatRule

## SYNOPSIS
Creates or updates a load balancer inbound nat rule.

## SYNTAX

### Create (Default)
```
New-AzLoadBalancerInboundNatRule -LoadBalancerName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-ResourceName <String>] [-InboundNatRule <IInboundNatRule>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpanded
```
New-AzLoadBalancerInboundNatRule -LoadBalancerName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -Name <String> [-ResourceName <String>]
 [-ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-ApplicationSecurityGroup <IApplicationSecurityGroup[]>] [-BackendIPConfigurationEtag <String>]
 [-BackendIPConfigurationId <String>] [-BackendIPConfigurationName <String>]
 [-BackendIPConfigurationProvisioningState <String>] [-BackendPort <Int32>] [-EnableFloatingIP]
 [-EnableTcpReset] [-Etag <String>] [-FrontendIPConfigurationId <String>] [-FrontendPort <Int32>]
 [-Id <String>] [-IdleTimeoutInMinutes <Int32>] [-LoadBalancerBackendAddressPool <IBackendAddressPool[]>]
 [-LoadBalancerInboundNatRule <IInboundNatRule[]>] [-Primary] [-PrivateIPAddress <String>]
 [-PrivateIPAddressVersion <IPVersion>] [-PrivateIPAllocationMethod <IPAllocationMethod>]
 [-Protocol <TransportProtocol>] [-ProvisioningState <String>] [-PublicIPAddress <IPublicIPAddress>]
 [-Subnet <ISubnet>] [-VnetTap <IVirtualNetworkTap[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzLoadBalancerInboundNatRule -InputObject <INetworkIdentity> [-ResourceName <String>]
 [-ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]
 [-ApplicationSecurityGroup <IApplicationSecurityGroup[]>] [-BackendIPConfigurationEtag <String>]
 [-BackendIPConfigurationId <String>] [-BackendIPConfigurationName <String>]
 [-BackendIPConfigurationProvisioningState <String>] [-BackendPort <Int32>] [-EnableFloatingIP]
 [-EnableTcpReset] [-Etag <String>] [-FrontendIPConfigurationId <String>] [-FrontendPort <Int32>]
 [-Id <String>] [-IdleTimeoutInMinutes <Int32>] [-LoadBalancerBackendAddressPool <IBackendAddressPool[]>]
 [-LoadBalancerInboundNatRule <IInboundNatRule[]>] [-Primary] [-PrivateIPAddress <String>]
 [-PrivateIPAddressVersion <IPVersion>] [-PrivateIPAllocationMethod <IPAllocationMethod>]
 [-Protocol <TransportProtocol>] [-ProvisioningState <String>] [-PublicIPAddress <IPublicIPAddress>]
 [-Subnet <ISubnet>] [-VnetTap <IVirtualNetworkTap[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzLoadBalancerInboundNatRule -InputObject <INetworkIdentity> [-InboundNatRule <IInboundNatRule>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a load balancer inbound nat rule.

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

### -ApplicationGatewayBackendAddressPool
The reference of ApplicationGatewayBackendAddressPool resource.
To construct, see NOTES section for APPLICATIONGATEWAYBACKENDADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IApplicationGatewayBackendAddressPool[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApplicationSecurityGroup
Application security groups in which the IP configuration is included.
To construct, see NOTES section for APPLICATIONSECURITYGROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -BackendIPConfigurationEtag
A unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendIPConfigurationId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendIPConfigurationName
The name of the resource that is unique within a resource group.
This name can be used to access the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendIPConfigurationProvisioningState
The provisioning state of the network interface IP configuration.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackendPort
The port used for the internal endpoint.
Acceptable values range from 1 to 65535.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
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

### -EnableFloatingIP
Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group.
This setting is required when using the SQL AlwaysOn Availability Groups in SQL server.
This setting can't be changed after you create the endpoint.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnableTcpReset
Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination.
This element is only used when the protocol is set to TCP.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FrontendIPConfigurationId
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FrontendPort
The port for the external endpoint.
Port numbers for each rule must be unique within the Load Balancer.
Acceptable values range from 1 to 65534.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IdleTimeoutInMinutes
The timeout for the TCP idle connection.
The value can be set between 4 and 30 minutes.
The default value is 4 minutes.
This element is only used when the protocol is set to TCP.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InboundNatRule
Inbound NAT rule of the load balancer.
To construct, see NOTES section for INBOUNDNATRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerBackendAddressPool
The reference of LoadBalancerBackendAddressPool resource.
To construct, see NOTES section for LOADBALANCERBACKENDADDRESSPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IBackendAddressPool[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerInboundNatRule
A list of references of LoadBalancerInboundNatRules.
To construct, see NOTES section for LOADBALANCERINBOUNDNATRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LoadBalancerName
The name of the load balancer.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the inbound nat rule.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: InboundNatRuleName

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

### -Primary
Gets whether this is a primary customer address on the network interface.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrivateIPAddress
Private IP address of the IP configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrivateIPAddressVersion
Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6.
Default is taken as IPv4.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PrivateIPAllocationMethod
The private IP address allocation method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Protocol
The reference to the transport protocol used by the load balancing rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Support.TransportProtocol
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Gets the provisioning state of the public IP resource.
Possible values are: 'Updating', 'Deleting', and 'Failed'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PublicIPAddress
Public IP address bound to the IP configuration.
To construct, see NOTES section for PUBLICIPADDRESS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IPublicIPAddress
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the inbound nat rule.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Subnet
Subnet bound to the IP configuration.
To construct, see NOTES section for SUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.ISubnet
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetTap
The reference to Virtual Network Taps.
To construct, see NOTES section for VNETTAP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IVirtualNetworkTap[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases: VirtualNetworkTap

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

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.IInboundNatRule

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### APPLICATIONGATEWAYBACKENDADDRESSPOOL <IApplicationGatewayBackendAddressPool[]>: The reference of ApplicationGatewayBackendAddressPool resource.
  - `[Id <String>]`: Resource ID.
  - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
    - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
    - `[IPAddress <String>]`: IP address
  - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
    - `[Id <String>]`: Resource ID.
    - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[Id <String>]`: Resource ID.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[OutboundRuleId <String>]`: Resource ID.
      - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
      - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[BackendIPConfigurationId <String>]`: Resource ID.
      - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
      - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
      - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[FrontendIPConfigurationId <String>]`: Resource ID.
      - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
      - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
      - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
        - `[DdosCustomPolicyId <String>]`: Resource ID.
        - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
          - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
          - `[Subnet <ISubnet>]`: The reference of the subnet resource.
            - `[Id <String>]`: Resource ID.
            - `[AddressPrefix <String>]`: The address prefix for the subnet.
            - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
              - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
              - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
              - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
              - `[Id <String>]`: Resource ID.
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
            - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
              - `[Id <String>]`: Resource ID.
              - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
              - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
            - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
            - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[NatGatewayId <String>]`: Resource ID.
            - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[NetworkSecurityGroupId <String>]`: Resource ID.
            - `[NetworkSecurityGroupLocation <String>]`: Resource location.
            - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
            - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
            - `[ProvisioningState <String>]`: The provisioning state of the resource.
            - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
            - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
              - `[Id <String>]`: Resource ID.
              - `[Link <String>]`: Link to the external resource
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
              - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
              - `[Id <String>]`: Resource ID.
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
            - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
              - `[Id <String>]`: Resource ID.
              - `[Link <String>]`: Link to the external resource.
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
              - `[Location <String[]>]`: A list of locations.
              - `[ProvisioningState <String>]`: The provisioning state of the resource.
              - `[Service <String>]`: The type of the endpoint service.
            - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
              - `[Id <String>]`: Resource ID.
              - `[Location <String>]`: Resource location.
              - `[Tag <IResourceTags>]`: Resource tags.
              - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
                - `[Id <String>]`: Resource ID.
                - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                - `[Service <String>]`: Service endpoint name.
                - `[ServiceResource <String[]>]`: A list of service resources.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
          - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
          - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
        - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
        - `[PublicIPPrefixId <String>]`: Resource ID.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Version <IPVersion?>]`: The public IP address version.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
    - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
    - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
    - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
    - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
    - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
  - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[Type <String>]`: Type of the resource.

#### APPLICATIONSECURITYGROUP <IApplicationSecurityGroup[]>: Application security groups in which the IP configuration is included.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

#### INBOUNDNATRULE <IInboundNatRule>: Inbound NAT rule of the load balancer.
  - `[Id <String>]`: Resource ID.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[Id <String>]`: Resource ID.
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
          - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[Id <String>]`: Resource ID.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[OutboundRuleId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
        - `[DdosCustomPolicyId <String>]`: Resource ID.
        - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
          - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
          - `[Subnet <ISubnet>]`: The reference of the subnet resource.
            - `[Id <String>]`: Resource ID.
            - `[AddressPrefix <String>]`: The address prefix for the subnet.
            - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
              - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
              - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
              - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
              - `[Id <String>]`: Resource ID.
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
            - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
              - `[Id <String>]`: Resource ID.
              - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
              - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
            - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
            - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[NatGatewayId <String>]`: Resource ID.
            - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[NetworkSecurityGroupId <String>]`: Resource ID.
            - `[NetworkSecurityGroupLocation <String>]`: Resource location.
            - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
            - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
            - `[ProvisioningState <String>]`: The provisioning state of the resource.
            - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
            - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
              - `[Id <String>]`: Resource ID.
              - `[Link <String>]`: Link to the external resource
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
              - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
              - `[Id <String>]`: Resource ID.
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
            - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
              - `[Id <String>]`: Resource ID.
              - `[Link <String>]`: Link to the external resource.
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
              - `[Location <String[]>]`: A list of locations.
              - `[ProvisioningState <String>]`: The provisioning state of the resource.
              - `[Service <String>]`: The type of the endpoint service.
            - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
              - `[Id <String>]`: Resource ID.
              - `[Location <String>]`: Resource location.
              - `[Tag <IResourceTags>]`: Resource tags.
              - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
                - `[Id <String>]`: Resource ID.
                - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                - `[Service <String>]`: Service endpoint name.
                - `[ServiceResource <String[]>]`: A list of service resources.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
          - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
          - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
        - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
        - `[PublicIPPrefixId <String>]`: Resource ID.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Version <IPVersion?>]`: The public IP address version.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[BackendIPConfigurationId <String>]`: Resource ID.
  - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
  - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
  - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.

#### LOADBALANCERBACKENDADDRESSPOOL <IBackendAddressPool[]>: The reference of LoadBalancerBackendAddressPool resource.
  - `[Id <String>]`: Resource ID.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[OutboundRuleId <String>]`: Resource ID.
  - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.

#### LOADBALANCERINBOUNDNATRULE <IInboundNatRule[]>: A list of references of LoadBalancerInboundNatRules.
  - `[Id <String>]`: Resource ID.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[Id <String>]`: Resource ID.
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
          - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[Id <String>]`: Resource ID.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[OutboundRuleId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
        - `[DdosCustomPolicyId <String>]`: Resource ID.
        - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
        - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
        - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
        - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
        - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPConfigurationId <String>]`: Resource ID.
        - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
          - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
          - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
          - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
          - `[Subnet <ISubnet>]`: The reference of the subnet resource.
            - `[Id <String>]`: Resource ID.
            - `[AddressPrefix <String>]`: The address prefix for the subnet.
            - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
              - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
              - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
              - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
              - `[Id <String>]`: Resource ID.
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
            - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
              - `[Id <String>]`: Resource ID.
              - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
              - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
            - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
            - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[NatGatewayId <String>]`: Resource ID.
            - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
            - `[NetworkSecurityGroupId <String>]`: Resource ID.
            - `[NetworkSecurityGroupLocation <String>]`: Resource location.
            - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
            - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
            - `[ProvisioningState <String>]`: The provisioning state of the resource.
            - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
            - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
              - `[Id <String>]`: Resource ID.
              - `[Link <String>]`: Link to the external resource
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
              - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
              - `[Id <String>]`: Resource ID.
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
            - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
              - `[Id <String>]`: Resource ID.
              - `[Link <String>]`: Link to the external resource.
              - `[LinkedResourceType <String>]`: Resource type of the linked resource.
              - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
            - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
              - `[Location <String[]>]`: A list of locations.
              - `[ProvisioningState <String>]`: The provisioning state of the resource.
              - `[Service <String>]`: The type of the endpoint service.
            - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
              - `[Id <String>]`: Resource ID.
              - `[Location <String>]`: Resource location.
              - `[Tag <IResourceTags>]`: Resource tags.
              - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
                - `[Id <String>]`: Resource ID.
                - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                - `[Service <String>]`: Service endpoint name.
                - `[ServiceResource <String[]>]`: A list of service resources.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
          - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
          - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
        - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
        - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
        - `[PublicIPPrefixId <String>]`: Resource ID.
        - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
        - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
        - `[Version <IPVersion?>]`: The public IP address version.
        - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[BackendIPConfigurationId <String>]`: Resource ID.
  - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
  - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
  - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[FrontendIPConfigurationId <String>]`: Resource ID.
  - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
  - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
  - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
  - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
  - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.

#### PUBLICIPADDRESS <IPublicIPAddress>: Public IP address bound to the IP configuration.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[DdosCustomPolicyId <String>]`: Resource ID.
  - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
  - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
  - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
  - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
  - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPConfigurationId <String>]`: Resource ID.
  - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
    - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
    - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
    - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
    - `[Subnet <ISubnet>]`: The reference of the subnet resource.
      - `[Id <String>]`: Resource ID.
      - `[AddressPrefix <String>]`: The address prefix for the subnet.
      - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
        - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
        - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
        - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
        - `[Id <String>]`: Resource ID.
        - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
        - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
        - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
          - `[Id <String>]`: Resource ID.
          - `[Location <String>]`: Resource location.
          - `[Tag <IResourceTags>]`: Resource tags.
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
      - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
        - `[Id <String>]`: Resource ID.
        - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
        - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
      - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[NatGatewayId <String>]`: Resource ID.
      - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[NetworkSecurityGroupId <String>]`: Resource ID.
      - `[NetworkSecurityGroupLocation <String>]`: Resource location.
      - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
      - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
      - `[ProvisioningState <String>]`: The provisioning state of the resource.
      - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
      - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
        - `[Id <String>]`: Resource ID.
        - `[Link <String>]`: Link to the external resource
        - `[LinkedResourceType <String>]`: Resource type of the linked resource.
        - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
        - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
        - `[Id <String>]`: Resource ID.
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
      - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
        - `[Id <String>]`: Resource ID.
        - `[Link <String>]`: Link to the external resource.
        - `[LinkedResourceType <String>]`: Resource type of the linked resource.
        - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
        - `[Location <String[]>]`: A list of locations.
        - `[ProvisioningState <String>]`: The provisioning state of the resource.
        - `[Service <String>]`: The type of the endpoint service.
      - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
        - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
          - `[Id <String>]`: Resource ID.
          - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[Service <String>]`: Service endpoint name.
          - `[ServiceResource <String[]>]`: A list of service resources.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
    - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
    - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
  - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
  - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
  - `[PublicIPPrefixId <String>]`: Resource ID.
  - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
  - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
  - `[Version <IPVersion?>]`: The public IP address version.
  - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.

#### SUBNET <ISubnet>: Subnet bound to the IP configuration.
  - `[Id <String>]`: Resource ID.
  - `[AddressPrefix <String>]`: The address prefix for the subnet.
  - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
    - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
    - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
    - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
    - `[Id <String>]`: Resource ID.
    - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
    - `[DestinationAddressPrefix <String>]`: The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
    - `[DestinationApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: The application security group specified as destination.
      - `[Id <String>]`: Resource ID.
      - `[Location <String>]`: Resource location.
      - `[Tag <IResourceTags>]`: Resource tags.
        - `[(Any) <String>]`: This indicates any property can be added to this object.
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
  - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
    - `[Id <String>]`: Resource ID.
    - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
    - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
  - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[NatGatewayId <String>]`: Resource ID.
  - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[NetworkSecurityGroupId <String>]`: Resource ID.
  - `[NetworkSecurityGroupLocation <String>]`: Resource location.
  - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
  - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
  - `[ProvisioningState <String>]`: The provisioning state of the resource.
  - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
  - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
    - `[Id <String>]`: Resource ID.
    - `[Link <String>]`: Link to the external resource
    - `[LinkedResourceType <String>]`: Resource type of the linked resource.
    - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
    - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
    - `[Id <String>]`: Resource ID.
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
  - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
    - `[Id <String>]`: Resource ID.
    - `[Link <String>]`: Link to the external resource.
    - `[LinkedResourceType <String>]`: Resource type of the linked resource.
    - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
    - `[Location <String[]>]`: A list of locations.
    - `[ProvisioningState <String>]`: The provisioning state of the resource.
    - `[Service <String>]`: The type of the endpoint service.
  - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
    - `[Id <String>]`: Resource ID.
    - `[Location <String>]`: Resource location.
    - `[Tag <IResourceTags>]`: Resource tags.
    - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
      - `[Id <String>]`: Resource ID.
      - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Service <String>]`: Service endpoint name.
      - `[ServiceResource <String[]>]`: A list of service resources.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.

#### VNETTAP <IVirtualNetworkTap[]>: The reference to Virtual Network Taps.
  - `[Id <String>]`: Resource ID.
  - `[Location <String>]`: Resource location.
  - `[Tag <IResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
    - `[Id <String>]`: Resource ID.
    - `[BackendAddress <IApplicationGatewayBackendAddress[]>]`: Backend addresses
      - `[Fqdn <String>]`: Fully qualified domain name (FQDN).
      - `[IPAddress <String>]`: IP address
    - `[BackendIPConfiguration <INetworkInterfaceIPConfiguration[]>]`: Collection of references to IPs defined in network interfaces.
      - `[Id <String>]`: Resource ID.
      - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
      - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[Id <String>]`: Resource ID.
        - `[Location <String>]`: Resource location.
        - `[Tag <IResourceTags>]`: Resource tags.
      - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
      - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[Id <String>]`: Resource ID.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[OutboundRuleId <String>]`: Resource ID.
        - `[ProvisioningState <String>]`: Get provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
        - `[Id <String>]`: Resource ID.
        - `[ApplicationGatewayBackendAddressPool <IApplicationGatewayBackendAddressPool[]>]`: The reference of ApplicationGatewayBackendAddressPool resource.
        - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
        - `[BackendIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[BackendIPConfigurationId <String>]`: Resource ID.
        - `[BackendIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[BackendIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[BackendPort <Int32?>]`: The port used for the internal endpoint. Acceptable values range from 1 to 65535.
        - `[EnableFloatingIP <Boolean?>]`: Configures a virtual machine's endpoint for the floating IP capability required to configure a SQL AlwaysOn Availability Group. This setting is required when using the SQL AlwaysOn Availability Groups in SQL server. This setting can't be changed after you create the endpoint.
        - `[EnableTcpReset <Boolean?>]`: Receive bidirectional TCP Reset on TCP flow idle timeout or unexpected connection termination. This element is only used when the protocol is set to TCP.
        - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
        - `[FrontendIPConfigurationId <String>]`: Resource ID.
        - `[FrontendPort <Int32?>]`: The port for the external endpoint. Port numbers for each rule must be unique within the Load Balancer. Acceptable values range from 1 to 65534.
        - `[IdleTimeoutInMinute <Int32?>]`: The timeout for the TCP idle connection. The value can be set between 4 and 30 minutes. The default value is 4 minutes. This element is only used when the protocol is set to TCP.
        - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
        - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
        - `[Name <String>]`: Gets name of the resource that is unique within a resource group. This name can be used to access the resource.
        - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
        - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
        - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
        - `[Protocol <TransportProtocol?>]`: The reference to the transport protocol used by the load balancing rule.
        - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
        - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
          - `[Id <String>]`: Resource ID.
          - `[Location <String>]`: Resource location.
          - `[Tag <IResourceTags>]`: Resource tags.
          - `[DdosCustomPolicyId <String>]`: Resource ID.
          - `[DdosSettingProtectionCoverage <DdosSettingsProtectionCoverage?>]`: The DDoS protection policy customizability of the public IP. Only standard coverage will have the ability to be customized.
          - `[DnsSettingDomainNameLabel <String>]`: Gets or sets the Domain name label.The concatenation of the domain name label and the regionalized DNS zone make up the fully qualified domain name associated with the public IP address. If a domain name label is specified, an A DNS record is created for the public IP in the Microsoft Azure DNS system.
          - `[DnsSettingFqdn <String>]`: Gets the FQDN, Fully qualified domain name of the A DNS record associated with the public IP. This is the concatenation of the domainNameLabel and the regionalized DNS zone.
          - `[DnsSettingReverseFqdn <String>]`: Gets or Sets the Reverse FQDN. A user-visible, fully qualified domain name that resolves to this public IP address. If the reverseFqdn is specified, then a PTR DNS record is created pointing from the IP address in the in-addr.arpa domain to the reverse FQDN. 
          - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPAddress <String>]`: The IP address associated with the public IP address resource.
          - `[IPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPConfigurationId <String>]`: Resource ID.
          - `[IPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
          - `[IPConfigurationProperty <IIPConfigurationPropertiesFormat>]`: Properties of the IP configuration
            - `[PrivateIPAddress <String>]`: The private IP address of the IP configuration.
            - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
            - `[ProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
            - `[PublicIPAddress <IPublicIPAddress>]`: The reference of the public IP resource.
            - `[Subnet <ISubnet>]`: The reference of the subnet resource.
              - `[Id <String>]`: Resource ID.
              - `[AddressPrefix <String>]`: The address prefix for the subnet.
              - `[DefaultSecurityRule <ISecurityRule[]>]`: The default security rules of network security group.
                - `Access <SecurityRuleAccess>`: The network traffic is allowed or denied.
                - `Direction <SecurityRuleDirection>`: The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
                - `Protocol <SecurityRuleProtocol>`: Network protocol this rule applies to. Possible values are 'Tcp', 'Udp', 'Icmp', 'Esp', and '*'.
                - `[Id <String>]`: Resource ID.
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
              - `[Delegation <IDelegation[]>]`: Gets an array of references to the delegations on the subnet.
                - `[Id <String>]`: Resource ID.
                - `[Action <String[]>]`: Describes the actions permitted to the service upon delegation
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                - `[Name <String>]`: The name of the resource that is unique within a subnet. This name can be used to access the resource.
                - `[ServiceName <String>]`: The name of the service to whom the subnet should be delegated (e.g. Microsoft.Sql/servers)
              - `[DisableBgpRoutePropagation <Boolean?>]`: Gets or sets whether to disable the routes learned by BGP on that route table. True means disable.
              - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[NatGatewayId <String>]`: Resource ID.
              - `[NetworkSecurityGroupEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
              - `[NetworkSecurityGroupId <String>]`: Resource ID.
              - `[NetworkSecurityGroupLocation <String>]`: Resource location.
              - `[NetworkSecurityGroupPropertiesProvisioningState <String>]`: The provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
              - `[NetworkSecurityGroupTag <IResourceTags>]`: Resource tags.
              - `[PropertiesAddressPrefixes <String[]>]`: List of  address prefixes for the subnet.
              - `[ProvisioningState <String>]`: The provisioning state of the resource.
              - `[ResourceGuid <String>]`: The resource GUID property of the network security group resource.
              - `[ResourceNavigationLink <IResourceNavigationLink[]>]`: Gets an array of references to the external resources using subnet.
                - `[Id <String>]`: Resource ID.
                - `[Link <String>]`: Link to the external resource
                - `[LinkedResourceType <String>]`: Resource type of the linked resource.
                - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[Route <IRoute[]>]`: Collection of routes contained within a route table.
                - `NextHopType <RouteNextHopType>`: The type of Azure hop the packet should be sent to.
                - `[Id <String>]`: Resource ID.
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
              - `[ServiceAssociationLink <IServiceAssociationLink[]>]`: Gets an array of references to services injecting into this subnet.
                - `[Id <String>]`: Resource ID.
                - `[Link <String>]`: Link to the external resource.
                - `[LinkedResourceType <String>]`: Resource type of the linked resource.
                - `[Name <String>]`: Name of the resource that is unique within a resource group. This name can be used to access the resource.
              - `[ServiceEndpoint <IServiceEndpointPropertiesFormat[]>]`: An array of service endpoints.
                - `[Location <String[]>]`: A list of locations.
                - `[ProvisioningState <String>]`: The provisioning state of the resource.
                - `[Service <String>]`: The type of the endpoint service.
              - `[ServiceEndpointPolicy <IServiceEndpointPolicy[]>]`: An array of service endpoint policies.
                - `[Id <String>]`: Resource ID.
                - `[Location <String>]`: Resource location.
                - `[Tag <IResourceTags>]`: Resource tags.
                - `[Definition <IServiceEndpointPolicyDefinition[]>]`: A collection of service endpoint policy definitions of the service endpoint policy.
                  - `[Id <String>]`: Resource ID.
                  - `[Description <String>]`: A description for this rule. Restricted to 140 chars.
                  - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
                  - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
                  - `[Service <String>]`: Service endpoint name.
                  - `[ServiceResource <String[]>]`: A list of service resources.
                - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
          - `[IPTag <IIPTag[]>]`: The list of tags associated with the public IP address.
            - `[Tag <String>]`: Gets or sets value of the IpTag associated with the public IP. Example SQL, Storage etc
            - `[Type <String>]`: Gets or sets the ipTag type: Example FirstPartyUsage.
          - `[IdleTimeoutInMinute <Int32?>]`: The idle timeout of the public IP address.
          - `[ProvisioningState <String>]`: The provisioning state of the PublicIP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
          - `[PublicIPAllocationMethod <IPAllocationMethod?>]`: The public IP address allocation method.
          - `[PublicIPPrefixId <String>]`: Resource ID.
          - `[ResourceGuid <String>]`: The resource GUID property of the public IP resource.
          - `[SkuName <PublicIPAddressSkuName?>]`: Name of a public IP address SKU.
          - `[Version <IPVersion?>]`: The public IP address version.
          - `[Zone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
        - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
        - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
      - `[Name <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
      - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
      - `[PrivateIPAddress <String>]`: Private IP address of the IP configuration.
      - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
      - `[PrivateIPAllocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
      - `[ProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
      - `[PublicIPAddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
      - `[Subnet <ISubnet>]`: Subnet bound to the IP configuration.
      - `[VirtualNetworkTap <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
    - `[Etag <String>]`: A unique read-only string that changes whenever the resource is updated.
    - `[Name <String>]`: Name of the backend address pool that is unique within an Application Gateway.
    - `[ProvisioningState <String>]`: Provisioning state of the backend address pool resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
    - `[Type <String>]`: Type of the resource.
  - `[ApplicationSecurityGroup <IApplicationSecurityGroup[]>]`: Application security groups in which the IP configuration is included.
  - `[DestinationLoadBalancerFrontEndIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[DestinationLoadBalancerFrontEndIPConfigurationId <String>]`: Resource ID.
  - `[DestinationLoadBalancerFrontEndIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpaddress <String>]`: The private IP address of the IP configuration.
  - `[DestinationLoadBalancerFrontEndIPConfigurationPropertiesPrivateIpallocationMethod <IPAllocationMethod?>]`: The Private IP allocation method.
  - `[DestinationLoadBalancerFrontEndIPConfigurationPropertiesProvisioningState <String>]`: Gets the provisioning state of the public IP resource. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[DestinationLoadBalancerFrontEndIPConfigurationPropertiesPublicIpaddress <IPublicIPAddress>]`: The reference of the Public IP resource.
  - `[DestinationLoadBalancerFrontEndIPConfigurationPropertiesSubnet <ISubnet>]`: The reference of the subnet resource.
  - `[DestinationLoadBalancerFrontEndIPConfigurationZone <String[]>]`: A list of availability zones denoting the IP allocated for the resource needs to come from.
  - `[DestinationNetworkInterfaceIPConfigurationEtag <String>]`: A unique read-only string that changes whenever the resource is updated.
  - `[DestinationNetworkInterfaceIPConfigurationId <String>]`: Resource ID.
  - `[DestinationNetworkInterfaceIPConfigurationName <String>]`: The name of the resource that is unique within a resource group. This name can be used to access the resource.
  - `[DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpaddress <String>]`: Private IP address of the IP configuration.
  - `[DestinationNetworkInterfaceIPConfigurationPropertiesPrivateIpallocationMethod <IPAllocationMethod?>]`: The private IP address allocation method.
  - `[DestinationNetworkInterfaceIPConfigurationPropertiesProvisioningState <String>]`: The provisioning state of the network interface IP configuration. Possible values are: 'Updating', 'Deleting', and 'Failed'.
  - `[DestinationNetworkInterfaceIPConfigurationPropertiesPublicIpaddress <IPublicIPAddress>]`: Public IP address bound to the IP configuration.
  - `[DestinationNetworkInterfaceIPConfigurationPropertiesSubnet <ISubnet>]`: Subnet bound to the IP configuration.
  - `[DestinationPort <Int32?>]`: The VXLAN destination port that will receive the tapped traffic.
  - `[Etag <String>]`: Gets a unique read-only string that changes whenever the resource is updated.
  - `[LoadBalancerBackendAddressPool <IBackendAddressPool[]>]`: The reference of LoadBalancerBackendAddressPool resource.
  - `[LoadBalancerInboundNatRule <IInboundNatRule[]>]`: A list of references of LoadBalancerInboundNatRules.
  - `[Primary <Boolean?>]`: Gets whether this is a primary customer address on the network interface.
  - `[PrivateIPAddressVersion <IPVersion?>]`: Available from Api-Version 2016-03-30 onwards, it represents whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
  - `[PropertiesDestinationNetworkInterfaceIPConfigurationPropertiesVirtualNetworkTaps <IVirtualNetworkTap[]>]`: The reference to Virtual Network Taps.
  - `[PublicIPPrefixId <String>]`: Resource ID.

## RELATED LINKS

